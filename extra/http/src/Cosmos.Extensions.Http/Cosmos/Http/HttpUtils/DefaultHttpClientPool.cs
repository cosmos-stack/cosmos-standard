using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

/*
 * Reference to:
 *      StackExchange.Utils
 *      Author: StackExchange / StackOverflow
 *      URL: https://github.com/StackExchange/StackExchange.Utils
 *      MIT
 */

namespace Cosmos.Http.HttpUtils
{
    public class DefaultHttpClientPool : IHttpClientPool
    {
        private readonly ConcurrentDictionary<HttpClientCacheKey, HttpClient> _clientPool = new ConcurrentDictionary<HttpClientCacheKey, HttpClient>();
        private HttpSettings Settings { get; set; }

        public DefaultHttpClientPool(HttpSettings settings) => Settings = settings;

        public HttpClient Get(IRequestBuilder builder)
        {
            return _clientPool.GetOrAdd(new HttpClientCacheKey(builder.Timeout), CreateHttpClient);
        }

        private HttpClient CreateHttpClient(HttpClientCacheKey options)
        {
            var handler = new HttpClientHandler { UseCookies = false };
            if (handler.SupportsAutomaticDecompression)
                handler.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;

            var client = new HttpClient(handler)
            {
                Timeout = options.Timeout,
                DefaultRequestHeaders =
                {
                    AcceptEncoding =
                    {
                        new StringWithQualityHeaderValue("gzip"),
                        new StringWithQualityHeaderValue("deflate")
                    }
                }
            };

            if (!string.IsNullOrEmpty(Settings.UserAgent))
                client.DefaultRequestHeaders.Add("User_Agent", Settings.UserAgent);

            return client;
        }

        public void Clear()
        {
            _clientPool.Clear();
        }

        private struct HttpClientCacheKey
        {
            public TimeSpan Timeout { get; }

            public HttpClientCacheKey(TimeSpan timeout) => Timeout = timeout;
        }
    }
}
