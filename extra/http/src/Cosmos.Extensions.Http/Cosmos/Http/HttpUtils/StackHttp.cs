using System;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Cosmos.Http.HttpUtils.Internals;

/*
 * Reference to:
 *      StackExchange.Utils
 *      Author: StackExchange / StackOverflow
 *      URL: https://github.com/StackExchange/StackExchange.Utils
 *      MIT
 */

namespace Cosmos.Http.HttpUtils
{
    public static class StackHttp
    {
        public static HttpSettings DefaultSettings { get; } = new HttpSettings();

        public static IRequestBuilder Request(
            string uri,
            HttpSettings settings = null,
            [CallerMemberName]string callerName = null,
            [CallerFilePath]string callerFile = null,
            [CallerLineNumber]int callerLine = 0) => new HttpBuilder(uri, settings, callerName, callerFile, callerLine);

        private static readonly FieldInfo stackTraceString = typeof(Exception).GetField("_stackTraceString", BindingFlags.Instance | BindingFlags.NonPublic);

        internal static async Task<HttpCallResponse<T>> SendAsync<T>(IRequestBuilder<T> builder, HttpMethod method, CancellationToken cancellationToken = default)
        {
            var settings = builder.GetSettings();

            settings.OnBeforeSend(builder, builder.Inner);

            var request = builder.Inner.Message;
            request.Method = method;

            Exception exception = null;
            HttpResponseMessage response = null;

            try
            {
                using (settings.ProfileRequest?.Invoke(request))
                {
                    using (request)
                    {
                        using (response = await settings.ClientPool.Get(builder.Inner).SendAsync(request, cancellationToken))
                        {
                            if (!response.IsSuccessStatusCode && !builder.Inner.IgnoreResponseStatuses.Contains(response.StatusCode))
                            {
                                exception = new HttpClientException(
                                    $"Response code was {(int)response.StatusCode} ({response.StatusCode}) from {response.RequestMessage.RequestUri}: {response.ReasonPhrase}",
                                    response.StatusCode,
                                    response.RequestMessage.RequestUri);

                                stackTraceString.SetValue(exception, new StackTrace(true).ToString());
                            }
                            else
                            {
                                var data = await builder.Handler(response);
                                return HttpCallResponse.Create(response, data);
                            }
                        }
                    }
                }
            }
            catch (TaskCanceledException ex)
            {
                exception = cancellationToken.IsCancellationRequested
                    ? new HttpClientException($"HttpClient request cancelled by token request.", builder.Inner.Message.RequestUri, ex)
                    : new HttpClientException($"HttpClient request time out: {builder.Inner.Timeout.TotalMilliseconds:N0}ms", builder.Inner.Message.RequestUri, ex);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            var ret = response == null
                ? HttpCallResponse.Create<T>(request, exception)
                : HttpCallResponse.Create<T>(response, exception);

            (builder.Inner as HttpBuilder)?.AddExceptionData(exception);

            if (builder.Inner.LogErrors)
            {
                var args = new HttpExceptionArgs(builder.Inner, exception);
                builder.Inner.OnBeforeExceptionLog(args);

                if (!args.AbortLogging)
                    settings.OnException(builder, args);
            }

            return ret;
        }
    }
}
