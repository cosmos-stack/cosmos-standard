using System;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Jil;

// ReSharper disable once CheckNamespace
namespace Cosmos.Serialization.Json {
    /// <summary>
    /// JilJson extensions
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// Serialize to string
        /// </summary>
        /// <param name="options"></param>
        /// <param name="request"></param>
        /// <typeparam name="TRequest"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string SerializeToString<TRequest>(this Options options, TRequest request) {
            if (options == null)
                throw new ArgumentNullException(nameof(options));
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            using var stringWriter = new StringWriter(CultureInfo.InvariantCulture);
            JSON.Serialize(request, stringWriter, options);
            return stringWriter.ToString();
        }

        /// <summary>
        /// Deserialize from string
        /// </summary>
        /// <param name="options"></param>
        /// <param name="json"></param>
        /// <typeparam name="TResponse"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static TResponse DeserializeFromString<TResponse>(this Options options, string json) {
            if (options == null)
                throw new ArgumentNullException(nameof(options));
            if (string.IsNullOrWhiteSpace(json))
                throw new ArgumentNullException(nameof(json));

            using var stringReader = new StringReader(json);
            return JSON.Deserialize<TResponse>(stringReader, options);
        }

        /// <summary>
        /// Serialize To Memory Stream Async
        /// </summary>
        /// <param name="options"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TRequest"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public static async Task<MemoryStream> SerializeToMemoryStreamAsync<TRequest>(
            this Options options, TRequest request, CancellationToken cancellationToken) {
            if (options == null)
                throw new ArgumentNullException(nameof(options));
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            using var stream = new MemoryStream();
            using TextWriter textWriter = new StreamWriter(stream);
            JSON.Serialize(request, textWriter, options);

            await textWriter.FlushAsync().ConfigureAwait(false);

            stream.Position = 0;
#if NET451
            ArraySegment<byte> buffer;
            try
            {
                buffer = new ArraySegment<byte>(stream.GetBuffer());
            }
            catch
            {
                throw new InvalidOperationException($"The call to {nameof(stream.GetBuffer)} returned false.");
            }
#else
            if (!stream.TryGetBuffer(out ArraySegment<byte> buffer))
                throw new InvalidOperationException($"The call to {nameof(stream.TryGetBuffer)} returned false.");
#endif
            return new MemoryStream(buffer.Array, buffer.Offset, buffer.Count);

        }
    }
}