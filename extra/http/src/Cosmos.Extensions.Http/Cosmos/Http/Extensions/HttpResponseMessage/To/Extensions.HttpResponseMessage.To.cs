using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Jil;
using Newtonsoft.Json;

// ReSharper disable once CheckNamespace
namespace Cosmos.Http {
    /// <summary>
    /// HttpResponseMessage extensions
    /// </summary>
    public static partial class HttpResponseMessageExtensions {
        /// <summary>
        /// To Object async
        /// </summary>
        /// <param name="httpResponseMessage"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Task<T> ToObjectAsync<T>(this HttpResponseMessage httpResponseMessage,
            CancellationToken cancellationToken) {
            if (httpResponseMessage == null)
                throw new ArgumentNullException(nameof(httpResponseMessage));
            return httpResponseMessage.ToObjectAsync<T>(JsonSerializer.CreateDefault(), cancellationToken);
        }

        /// <summary>
        /// To Object async
        /// </summary>
        /// <param name="httpResponseMessage"></param>
        /// <param name="jsonSerializerSettings"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Task<T> ToObjectAsync<T>(this HttpResponseMessage httpResponseMessage,
            JsonSerializerSettings jsonSerializerSettings, CancellationToken cancellationToken) {
            if (httpResponseMessage == null)
                throw new ArgumentNullException(nameof(httpResponseMessage));
            if (jsonSerializerSettings == null)
                throw new ArgumentNullException(nameof(jsonSerializerSettings));
            return httpResponseMessage.ToObjectAsync<T>(JsonSerializer.Create(jsonSerializerSettings), cancellationToken);
        }

        /// <summary>
        /// To Object async
        /// </summary>
        /// <param name="httpResponseMessage"></param>
        /// <param name="jsonSerializer"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static async Task<T> ToObjectAsync<T>(this HttpResponseMessage httpResponseMessage,
            JsonSerializer jsonSerializer, CancellationToken cancellationToken) {
            if (httpResponseMessage == null)
                throw new ArgumentNullException(nameof(httpResponseMessage));
            if (jsonSerializer == null)
                throw new ArgumentNullException(nameof(jsonSerializer));

            using (var stream = await httpResponseMessage.Content.ReadAsStreamAsync().ConfigureAwait(false)) {
                using (var streamReader = new StreamReader(stream)) {
                    using (JsonReader jsonReader = new JsonTextReader(streamReader)) {
                        return jsonSerializer.Deserialize<T>(jsonReader);
                    }
                }
            }
        }

        /// <summary>
        /// To object async
        /// </summary>
        /// <param name="httpResponseMessage"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static async Task<T> ToObjectAsync<T>(this HttpResponseMessage httpResponseMessage,
            Options options, CancellationToken cancellationToken) {
            if (httpResponseMessage == null)
                throw new ArgumentNullException(nameof(httpResponseMessage));
            if (options == null)
                options = Options.Default;

            using (var stream = await httpResponseMessage.Content.ReadAsStreamAsync().ConfigureAwait(false)) {
                using (var streamReader = new StreamReader(stream)) {
                    return JSON.Deserialize<T>(streamReader, options);
                }
            }
        }
    }
}