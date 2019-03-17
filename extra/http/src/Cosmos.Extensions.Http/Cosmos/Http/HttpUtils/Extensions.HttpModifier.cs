using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Net;
using System.Net.Http.Headers;
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
    public static class HttpModifierExtensions
    {
        public static IRequestBuilder WithTimeout(this IRequestBuilder builder, TimeSpan timeout)
        {
            builder.Timeout = timeout;
            return builder;
        }

        public static IRequestBuilder WithoutErrorLogging(this IRequestBuilder builder)
        {
            builder.LogErrors = false;
            return builder;
        }

        public static IRequestBuilder WithoutLogging(this IRequestBuilder builder, IEnumerable<HttpStatusCode> ignoredStatusCodes)
        {
            builder.IgnoreResponseStatuses = ignoredStatusCodes;
            return builder;
        }

        private static readonly ConcurrentDictionary<HttpStatusCode, ImmutableHashSet<HttpStatusCode>> _ignoreCache = new ConcurrentDictionary<HttpStatusCode, ImmutableHashSet<HttpStatusCode>>();

        public static IRequestBuilder WithoutLogging(this IRequestBuilder builder, HttpStatusCode ignoredStatusCode)
        {
            builder.IgnoreResponseStatuses = _ignoreCache.GetOrAdd(ignoredStatusCode, ImmutableHashSet.Create);
            return builder;
        }

        public static IRequestBuilder OnException(this IRequestBuilder builder, EventHandler<HttpExceptionArgs> beforeLogHandler)
        {
            builder.BeforeExceptionLog += beforeLogHandler;
            return builder;
        }

        public static IRequestBuilder AddHeader(this IRequestBuilder builder, string name, string value)
        {
            if (!string.IsNullOrEmpty(name))
            {
                try
                {
                    builder.Message.Headers.Add(name, value);
                }
                catch (Exception e)
                {
                    var wrapper = new HttpClientException($"Unable to set header: {name} to '{value}'", builder.Message.RequestUri, e);
                    builder.GetSettings().OnException(builder, new HttpExceptionArgs(builder, wrapper));
                }
            }

            return builder;
        }

        public static IRequestBuilder AddHeaders(this IRequestBuilder builder, IDictionary<string, string> headers)
        {
            if (headers == null)
                return builder;

            var pHeaders = builder.Message.Headers;

            foreach (var kv in headers)
            {
                try
                {
                    switch (kv.Key)
                    {
                        case "Accept":
                            pHeaders.Accept.ParseAdd(kv.Value);
                            break;

                        case "Connect-Type":
                            builder.Message.Content.Headers.ContentType = new MediaTypeHeaderValue(kv.Value);
                            break;

                        default:
                            pHeaders.Add(kv.Key, kv.Value);
                            break;
                    }
                }
                catch (Exception e)
                {
                    var wrapper = new HttpClientException($"Unable to set header: {kv.Key} to '{kv.Value}'", builder.Message.RequestUri, e);
                    builder.GetSettings().OnException(builder, new HttpExceptionArgs(builder, wrapper));
                }
            }

            return builder;
        }
    }
}
