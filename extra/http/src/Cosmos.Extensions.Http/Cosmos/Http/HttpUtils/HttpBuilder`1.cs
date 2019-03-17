using System;
using System.Net.Http;
using System.Threading.Tasks;

/*
 * Reference to:
 *      StackExchange.Utils
 *      Author: StackExchange / StackOverflow
 *      URL: https://github.com/StackExchange/StackExchange.Utils
 *      MIT
 */

namespace Cosmos.Http.HttpUtils
{
    internal class HttpBuilder<T> : IRequestBuilder<T>
    {
        public IRequestBuilder Inner { get; }

        public Func<HttpResponseMessage, Task<T>> Handler { get; }

        public HttpBuilder(HttpBuilder builder, Func<HttpResponseMessage, Task<T>> handler)
        {
            Inner = builder;
            Handler = handler;
        }
    }
}
