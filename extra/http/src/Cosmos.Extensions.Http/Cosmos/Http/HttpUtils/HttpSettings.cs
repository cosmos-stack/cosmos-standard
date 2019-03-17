using System;
using System.Net.Http;

/*
 * Reference to:
 *      StackExchange.Utils
 *      Author: StackExchange / StackOverflow
 *      URL: https://github.com/StackExchange/StackExchange.Utils
 *      MIT
 */

namespace Cosmos.Http.HttpUtils
{
    /// <summary>
    /// Settings for HTTP
    /// </summary>
    public class HttpSettings
    {
        public string UserAgent { get; set; } = "CosmosLoops-Http Client";

        public string ErrorDataPrefix { get; set; } = "ExceptionalCustom-";

        public event EventHandler<IRequestBuilder> BeforeSend;

        public event EventHandler<HttpExceptionArgs> Exception;

        public Func<HttpRequestMessage, IDisposable> ProfileRequest { get; set; }

        public Func<string, IDisposable> ProfileGeneral { get; set; }

        public IHttpClientPool ClientPool { get; set; }

        public TimeSpan DefaultTimeout { get; set; } = TimeSpan.FromSeconds(30);

        internal void OnBeforeSend(object sender, IRequestBuilder builder) => BeforeSend?.Invoke(sender, builder);

        internal void OnException(object sender, HttpExceptionArgs args) => Exception?.Invoke(sender, args);

        public HttpSettings()
        {
            ClientPool = new DefaultHttpClientPool(this);
        }
    }
}
