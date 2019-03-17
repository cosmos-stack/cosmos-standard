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

namespace Cosmos.Http.HttpUtils
{
    public class HttpCallResponse
    {
        public bool Success { get; }

        public string RequestUri => RawRequest?.RequestUri?.AbsoluteUri;

        public HttpRequestMessage RawRequest { get; }

        public HttpResponseMessage RawResponse { get; }

        public Exception Error { get; }

        public HttpStatusCode? StatusCode => RawResponse?.StatusCode;

        protected HttpCallResponse(HttpRequestMessage request, Exception error)
        {
            RawRequest = request;
            Success = false;
            Error = error;
        }

        protected HttpCallResponse(HttpResponseMessage response)
        {
            Success = response.IsSuccessStatusCode;
            RawResponse = response;
            RawRequest = response.RequestMessage;
        }

        protected HttpCallResponse(HttpResponseMessage response, Exception error) : this(response)
        {
            Success = false;
            Error = error;
        }

        public static HttpCallResponse<T> Create<T>(HttpRequestMessage request, Exception error = null)
        {
            error = (error ?? new HttpClientException($"Failed to send request for {request.RequestUri}"))
                .AddLoggedData("Request URI", request.RequestUri);
            return new HttpCallResponse<T>(request, error);
        }

        public static HttpCallResponse<T> Create<T>(HttpResponseMessage response, Exception error)
        {
            error
                .AddLoggedData("Response.Code", ((int)response.StatusCode).ToString())
                .AddLoggedData("Response.Status", response.StatusCode.ToString())
                .AddLoggedData("Response.ReasonPhrase", response.ReasonPhrase)
                .AddLoggedData("Response.ContentType", response.Content.Headers.ContentType)
                .AddLoggedData("Request.URI", response.RequestMessage.RequestUri);
            return new HttpCallResponse<T>(response, error);
        }

        public static HttpCallResponse<T> Create<T>(HttpResponseMessage response, T data) => new HttpCallResponse<T>(response, data);
    }
}
