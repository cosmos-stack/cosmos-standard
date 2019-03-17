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
    public class HttpCallResponse<T> : HttpCallResponse
    {
        public HttpCallResponse(HttpResponseMessage response, T data) : base(response)
        {
            Data = data;
        }

        public HttpCallResponse(HttpRequestMessage request, Exception error) : base(request, error) { }

        public HttpCallResponse(HttpResponseMessage response, Exception error) : base(response, error) { }

        public T Data { get; }
    }
}
