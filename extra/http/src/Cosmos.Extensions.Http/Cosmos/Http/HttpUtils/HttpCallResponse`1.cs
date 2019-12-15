using System;
using System.Net.Http;

/*
 * Reference to:
 *      StackExchange.Utils
 *      Author: StackExchange / StackOverflow
 *      URL: https://github.com/StackExchange/StackExchange.Utils
 *      MIT
 */

namespace Cosmos.Http.HttpUtils {
    /// <summary>
    /// Http Call Response
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class HttpCallResponse<T> : HttpCallResponse {
        /// <summary>
        /// Create a new instance of <see cref="HttpCallResponse"/>.
        /// </summary>
        /// <param name="response"></param>
        /// <param name="data"></param>
        public HttpCallResponse(HttpResponseMessage response, T data) : base(response) {
            Data = data;
        }

        /// <summary>
        /// Create a new instance of <see cref="HttpCallResponse"/>.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="error"></param>
        public HttpCallResponse(HttpRequestMessage request, Exception error) : base(request, error) { }

        /// <summary>
        /// Create a new instance of <see cref="HttpCallResponse"/>.
        /// </summary>
        /// <param name="response"></param>
        /// <param name="error"></param>
        public HttpCallResponse(HttpResponseMessage response, Exception error) : base(response, error) { }

        /// <summary>
        /// Data
        /// </summary>
        public T Data { get; }
    }
}