using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Jil;
using Newtonsoft.Json;

// ReSharper disable once CheckNamespace
namespace Cosmos.Http {
    /// <summary>
    /// HttpClient extensions
    /// </summary>
    public static partial class HttpClientExtensions {
        /// <summary>
        /// Delete json async
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="uri"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Task<TResult> DeleteJsonAsync<TResult>(this HttpClient httpClient, string uri, CancellationToken cancellationToken) {
            if (httpClient == null)
                throw new ArgumentNullException(nameof(httpClient));
            if (string.IsNullOrWhiteSpace(uri)) throw new ArgumentNullException(nameof(uri));
            return httpClient.DeleteJsonAsync<TResult>(uri, JsonSerializer.CreateDefault(), cancellationToken);
        }

        /// <summary>
        /// Delete json async
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="uri"></param>
        /// <param name="jsonSerializerSettings"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TResponse"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Task<TResponse> DeleteJsonAsync<TResponse>(this HttpClient httpClient, string uri,
            JsonSerializerSettings jsonSerializerSettings, CancellationToken cancellationToken) {
            if (httpClient == null)
                throw new ArgumentNullException(nameof(httpClient));
            if (string.IsNullOrWhiteSpace(uri))
                throw new ArgumentNullException(nameof(uri));
            if (jsonSerializerSettings == null)
                throw new ArgumentNullException(nameof(jsonSerializerSettings));
            return httpClient.DeleteJsonAsync<TResponse>(uri, JsonSerializer.Create(jsonSerializerSettings), cancellationToken);
        }

        /// <summary>
        /// Delete json async
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="uri"></param>
        /// <param name="jsonSerializer"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TResponse"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static async Task<TResponse> DeleteJsonAsync<TResponse>(this HttpClient httpClient, string uri,
            JsonSerializer jsonSerializer, CancellationToken cancellationToken) {
            if (httpClient == null)
                throw new ArgumentNullException(nameof(httpClient));
            if (string.IsNullOrWhiteSpace(uri))
                throw new ArgumentNullException(nameof(uri));
            if (jsonSerializer == null)
                throw new ArgumentNullException(nameof(jsonSerializer));
            using (var httpResponseMessage = await httpClient.DeleteAsync(uri, cancellationToken).ConfigureAwait(false)) {
                httpResponseMessage.EnsureSuccessStatusCode();
                return await httpResponseMessage.ToObjectAsync<TResponse>(jsonSerializer, cancellationToken).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Delete json async
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="uri"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TResponse"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static async Task<TResponse> DeleteJsonAsync<TResponse>(this HttpClient httpClient, string uri,
            Options options, CancellationToken cancellationToken) {
            if (httpClient == null)
                throw new ArgumentNullException(nameof(httpClient));
            if (string.IsNullOrWhiteSpace(uri))
                throw new ArgumentNullException(nameof(uri));
            if (options == null)
                options = Options.Default;
            using (var httpResponseMessage = await httpClient.DeleteAsync(uri, cancellationToken).ConfigureAwait(false)) {
                httpResponseMessage.EnsureSuccessStatusCode();
                return await httpResponseMessage.ToObjectAsync<TResponse>(options, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}