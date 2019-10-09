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
        /// <summary>
        /// User agent
        /// </summary>
        public string UserAgent { get; set; } = "CosmosLoops-Http Client";

        /// <summary>
        /// Error data prefix
        /// </summary>
        public string ErrorDataPrefix { get; set; } = "ExceptionalCustom-";

        /// <summary>
        /// Before Send
        /// </summary>
        public event EventHandler<IRequestBuilder> BeforeSend;

        /// <summary>
        /// Exception
        /// </summary>
        public event EventHandler<HttpExceptionArgs> Exception;

        /// <summary>
        /// Profile request
        /// </summary>
        public Func<HttpRequestMessage, IDisposable> ProfileRequest { get; set; }

        /// <summary>
        /// Profile general
        /// </summary>
        public Func<string, IDisposable> ProfileGeneral { get; set; }

        /// <summary>
        /// Client pool
        /// </summary>
        public IHttpClientPool ClientPool { get; set; }

        /// <summary>
        /// Default timeout
        /// </summary>
        public TimeSpan DefaultTimeout { get; set; } = TimeSpan.FromSeconds(30);

        internal void OnBeforeSend(object sender, IRequestBuilder builder) => BeforeSend?.Invoke(sender, builder);

        internal void OnException(object sender, HttpExceptionArgs args) => Exception?.Invoke(sender, args);

        /// <summary>
        /// Create a new instance of <see cref="HttpSettings"/>.
        /// </summary>
        public HttpSettings()
        {
            ClientPool = new DefaultHttpClientPool(this);
        }
    }
}