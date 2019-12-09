using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Cosmos.Serialization.Json;
using Newtonsoft.Json;

// ReSharper disable once CheckNamespace
namespace Cosmos.Http {
    /// <summary>
    /// HttpClient extensions
    /// </summary>
    public static partial class HttpClientExtensions {
        /// <summary>
        /// Post json async
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="uri"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TRequest"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Task PostJsonAsync<TRequest>(this HttpClient httpClient, string uri,
            TRequest request, CancellationToken cancellationToken) {
            if (httpClient == null)
                throw new ArgumentNullException(nameof(httpClient));
            if (string.IsNullOrWhiteSpace(uri))
                throw new ArgumentNullException(nameof(uri));
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            return httpClient.PostJsonAsync(uri, JsonSerializer.CreateDefault(), request, cancellationToken);
        }

        /// <summary>
        /// Post json async
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="uri"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TRequest"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Task<TResult> PostJsonAsync<TRequest, TResult>(this HttpClient httpClient, string uri,
            TRequest request, CancellationToken cancellationToken) {
            if (httpClient == null)
                throw new ArgumentNullException(nameof(httpClient));
            if (string.IsNullOrWhiteSpace(uri))
                throw new ArgumentNullException(nameof(uri));
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            return httpClient.PostJsonAsync<TRequest, TResult>(uri, JsonSerializer.CreateDefault(), request, cancellationToken);
        }

        /// <summary>
        /// Post json async
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="uri"></param>
        /// <param name="jsonSerializerSettings"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TRequest"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Task PostJsonAsync<TRequest>(this HttpClient httpClient, string uri,
            JsonSerializerSettings jsonSerializerSettings, TRequest request, CancellationToken cancellationToken) {
            if (httpClient == null)
                throw new ArgumentNullException(nameof(httpClient));
            if (string.IsNullOrWhiteSpace(uri))
                throw new ArgumentNullException(nameof(uri));
            if (jsonSerializerSettings == null)
                throw new ArgumentNullException(nameof(jsonSerializerSettings));
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            return httpClient.PostJsonAsync(uri, JsonSerializer.Create(jsonSerializerSettings), request, cancellationToken);
        }

        /// <summary>
        /// Post json async
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="uri"></param>
        /// <param name="jsonSerializerSettings"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TRequest"></typeparam>
        /// <typeparam name="TResponse"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Task<TResponse> PostJsonAsync<TRequest, TResponse>(this HttpClient httpClient, string uri,
            JsonSerializerSettings jsonSerializerSettings, TRequest request, CancellationToken cancellationToken) {
            if (httpClient == null)
                throw new ArgumentNullException(nameof(httpClient));
            if (string.IsNullOrWhiteSpace(uri))
                throw new ArgumentNullException(nameof(uri));
            if (jsonSerializerSettings == null)
                throw new ArgumentNullException(nameof(jsonSerializerSettings));
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return httpClient.PostJsonAsync<TRequest, TResponse>(uri, JsonSerializer.Create(jsonSerializerSettings), request, cancellationToken);
        }

        /// <summary>
        /// Post json async
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="uri"></param>
        /// <param name="jsonSerializer"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TRequest"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static async Task PostJsonAsync<TRequest>(this HttpClient httpClient,
            string uri, JsonSerializer jsonSerializer, TRequest request, CancellationToken cancellationToken) {
            if (httpClient == null)
                throw new ArgumentNullException(nameof(httpClient));
            if (string.IsNullOrWhiteSpace(uri))
                throw new ArgumentNullException(nameof(uri));
            if (jsonSerializer == null)
                throw new ArgumentNullException(nameof(jsonSerializer));
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            using (var httpResponseMessage =
                await httpClient.PostJsonForHttpResponseMessageAsync(uri, jsonSerializer, request, cancellationToken).ConfigureAwait(false)) {
                httpResponseMessage.EnsureSuccessStatusCode();
            }
        }

        /// <summary>
        /// Post json async
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="uri"></param>
        /// <param name="jsonSerializer"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TRequest"></typeparam>
        /// <typeparam name="TResponse"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static async Task<TResponse> PostJsonAsync<TRequest, TResponse>(this HttpClient httpClient,
            string uri, JsonSerializer jsonSerializer, TRequest request, CancellationToken cancellationToken) {
            if (httpClient == null)
                throw new ArgumentNullException(nameof(httpClient));
            if (string.IsNullOrWhiteSpace(uri))
                throw new ArgumentNullException(nameof(uri));
            if (jsonSerializer == null)
                throw new ArgumentNullException(nameof(jsonSerializer));
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            using (var httpResponseMessage =
                await httpClient.PostJsonForHttpResponseMessageAsync(uri, jsonSerializer, request, cancellationToken).ConfigureAwait(false)) {
                httpResponseMessage.EnsureSuccessStatusCode();
                return await httpResponseMessage.ToObjectAsync<TResponse>(jsonSerializer, cancellationToken).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Post json for HttpResponseMessage async
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="uri"></param>
        /// <param name="jsonSerializerSettings"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TRequest"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Task<HttpResponseMessage> PostJsonForHttpResponseMessageAsync<TRequest>(this HttpClient httpClient,
            string uri, JsonSerializerSettings jsonSerializerSettings, TRequest request, CancellationToken cancellationToken) {
            if (httpClient == null)
                throw new ArgumentNullException(nameof(httpClient));
            if (string.IsNullOrWhiteSpace(uri))
                throw new ArgumentNullException(nameof(uri));
            if (jsonSerializerSettings == null)
                throw new ArgumentNullException(nameof(jsonSerializerSettings));
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return httpClient.PostJsonForHttpResponseMessageAsync(uri, JsonSerializer.Create(jsonSerializerSettings), request, cancellationToken);
        }

        /// <summary>
        /// Post json for HttpResponseMessage async
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="uri"></param>
        /// <param name="jsonSerializer"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TRequest"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static async Task<HttpResponseMessage> PostJsonForHttpResponseMessageAsync<TRequest>(this HttpClient httpClient,
            string uri, JsonSerializer jsonSerializer, TRequest request, CancellationToken cancellationToken) {
            if (httpClient == null)
                throw new ArgumentNullException(nameof(httpClient));
            if (string.IsNullOrWhiteSpace(uri))
                throw new ArgumentNullException(nameof(uri));
            if (jsonSerializer == null)
                throw new ArgumentNullException(nameof(jsonSerializer));
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var json = jsonSerializer.SerializeToString(request);

            using (HttpContent content = new StringContent(json, Encoding.UTF8, "application/json")) {
                return await httpClient.PostAsync(uri, content, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}