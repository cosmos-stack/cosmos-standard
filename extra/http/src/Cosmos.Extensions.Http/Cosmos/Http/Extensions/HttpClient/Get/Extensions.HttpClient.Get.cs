using System;
using System.IO;
using System.Net.Http;
using System.Reactive.Disposables;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

// ReSharper disable once CheckNamespace
namespace Cosmos.Http {
    /// <summary>
    /// HttpClient extensions
    /// </summary>
    public static partial class HttpClientExtensions {
        /// <summary>
        /// Get json async
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="uri"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Task<T> GetJsonAsync<T>(this HttpClient httpClient, string uri, CancellationToken cancellationToken) {
            if (httpClient == null)
                throw new ArgumentNullException(nameof(httpClient));
            if (string.IsNullOrWhiteSpace(uri))
                throw new ArgumentNullException(nameof(uri));
            return httpClient.GetJsonAsync<T>(uri, JsonSerializer.CreateDefault(), cancellationToken);
        }

        /// <summary>
        /// Get json async
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="uri"></param>
        /// <param name="jsonSerializerSettings"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Task<T> GetJsonAsync<T>(this HttpClient httpClient, string uri, JsonSerializerSettings jsonSerializerSettings, CancellationToken cancellationToken) {
            if (httpClient == null)
                throw new ArgumentNullException(nameof(httpClient));
            if (string.IsNullOrWhiteSpace(uri))
                throw new ArgumentNullException(nameof(uri));
            if (jsonSerializerSettings == null)
                throw new ArgumentNullException(nameof(jsonSerializerSettings));
            return httpClient.GetJsonAsync<T>(uri, JsonSerializer.Create(jsonSerializerSettings), cancellationToken);
        }

        /// <summary>
        /// Get json async
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="uri"></param>
        /// <param name="jsonSerializer"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static async Task<T> GetJsonAsync<T>(this HttpClient httpClient, string uri, JsonSerializer jsonSerializer, CancellationToken cancellationToken) {
            if (httpClient == null)
                throw new ArgumentNullException(nameof(httpClient));
            if (string.IsNullOrWhiteSpace(uri))
                throw new ArgumentNullException(nameof(uri));
            if (jsonSerializer == null)
                throw new ArgumentNullException(nameof(jsonSerializer));
            using (var httpResponseMessage = await httpClient.GetAsync(uri, cancellationToken).ConfigureAwait(false)) {
                httpResponseMessage.EnsureSuccessStatusCode();
                return await httpResponseMessage.ToObjectAsync<T>(jsonSerializer, cancellationToken).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Get stream async
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="requestUri"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Task<Stream> GetStreamAsync(this HttpClient httpClient, string requestUri, CancellationToken cancellationToken) {
            if (httpClient == null)
                throw new ArgumentNullException(nameof(httpClient));
            if (string.IsNullOrWhiteSpace(requestUri))
                throw new ArgumentNullException(nameof(requestUri));
            return httpClient.GetStreamAsync(new Uri(requestUri), true, cancellationToken);
        }

        /// <summary>
        /// Get stream async
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="requestUri"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Task<Stream> GetStreamAsync(this HttpClient httpClient, Uri requestUri, CancellationToken cancellationToken) {
            if (httpClient == null)
                throw new ArgumentNullException(nameof(httpClient));
            if (requestUri == null)
                throw new ArgumentNullException(nameof(requestUri));
            return httpClient.GetStreamAsync(requestUri, true, cancellationToken);
        }

        /// <summary>
        /// Get stream async
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="requestUri"></param>
        /// <param name="disposeHttpClient"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Task<Stream> GetStreamAsync(this HttpClient httpClient, string requestUri, bool disposeHttpClient, CancellationToken cancellationToken) {
            if (httpClient == null)
                throw new ArgumentNullException(nameof(httpClient));
            if (string.IsNullOrWhiteSpace(requestUri))
                throw new ArgumentNullException(nameof(requestUri));
            return httpClient.GetStreamAsync(new Uri(requestUri), disposeHttpClient, cancellationToken);
        }

        /// <summary>
        /// Get stream async
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="requestUri"></param>
        /// <param name="disposeHttpClient"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static async Task<Stream> GetStreamAsync(this HttpClient httpClient, Uri requestUri, bool disposeHttpClient, CancellationToken cancellationToken) {
            if (httpClient == null)
                throw new ArgumentNullException(nameof(httpClient));
            if (requestUri == null)
                throw new ArgumentNullException(nameof(requestUri));

            var compositeDisposable = new CompositeDisposable();
            var compositeDisposableCopy = compositeDisposable;

            try {
                if (disposeHttpClient)
                    compositeDisposable.Add(httpClient);

                HttpResponseMessage httpResponseMessage;
                compositeDisposable.Add(httpResponseMessage =
                    await httpClient.GetAsync(requestUri, cancellationToken).ConfigureAwait(false));

                Stream stream;
                compositeDisposable.Add(stream =
                    await httpResponseMessage.Content.ReadAsStreamAsync().ConfigureAwait(false));

                compositeDisposableCopy = null;

                return new StreamWithState<IDisposable>(stream, compositeDisposable);
            }
            catch {
                using (compositeDisposableCopy)
                    throw;
            }
        }
    }
}