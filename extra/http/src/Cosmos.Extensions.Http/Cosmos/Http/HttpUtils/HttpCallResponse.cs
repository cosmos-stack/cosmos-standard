using System;
using System.Net;
using System.Net.Http;
using Cosmos.Http.HttpUtils.Internals;

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
    public class HttpCallResponse {
        /// <summary>
        /// Success
        /// </summary>
        public bool Success { get; }

        /// <summary>
        /// Request Uri
        /// </summary>
        public string RequestUri => RawRequest?.RequestUri?.AbsoluteUri;

        /// <summary>
        /// Raw request
        /// </summary>
        public HttpRequestMessage RawRequest { get; }

        /// <summary>
        /// Raw response
        /// </summary>
        public HttpResponseMessage RawResponse { get; }

        /// <summary>
        /// Error
        /// </summary>
        public Exception Error { get; }

        /// <summary>
        /// Status code
        /// </summary>
        public HttpStatusCode? StatusCode => RawResponse?.StatusCode;

        /// <summary>
        /// Create a new instance of <see cref="HttpCallResponse"/>.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="error"></param>
        protected HttpCallResponse(HttpRequestMessage request, Exception error) {
            RawRequest = request;
            Success = false;
            Error = error;
        }

        /// <summary>
        /// Create a new instance of <see cref="HttpCallResponse"/>.
        /// </summary>
        /// <param name="response"></param>
        protected HttpCallResponse(HttpResponseMessage response) {
            Success = response.IsSuccessStatusCode;
            RawResponse = response;
            RawRequest = response.RequestMessage;
        }

        /// <summary>
        /// Create a new instance of <see cref="HttpCallResponse"/>.
        /// </summary>
        /// <param name="response"></param>
        /// <param name="error"></param>
        protected HttpCallResponse(HttpResponseMessage response, Exception error) : this(response) {
            Success = false;
            Error = error;
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="request"></param>
        /// <param name="error"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static HttpCallResponse<T> Create<T>(HttpRequestMessage request, Exception error = null) {
            error = (error ?? new HttpClientException($"Failed to send request for {request.RequestUri}"))
               .AddLoggedData("Request URI", request.RequestUri);
            return new HttpCallResponse<T>(request, error);
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="response"></param>
        /// <param name="error"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static HttpCallResponse<T> Create<T>(HttpResponseMessage response, Exception error) {
            error
               .AddLoggedData("Response.Code", ((int) response.StatusCode).ToString())
               .AddLoggedData("Response.Status", response.StatusCode.ToString())
               .AddLoggedData("Response.ReasonPhrase", response.ReasonPhrase)
               .AddLoggedData("Response.ContentType", response.Content.Headers.ContentType)
               .AddLoggedData("Request.URI", response.RequestMessage.RequestUri);
            return new HttpCallResponse<T>(response, error);
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="response"></param>
        /// <param name="data"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static HttpCallResponse<T> Create<T>(HttpResponseMessage response, T data) => new HttpCallResponse<T>(response, data);
    }
}