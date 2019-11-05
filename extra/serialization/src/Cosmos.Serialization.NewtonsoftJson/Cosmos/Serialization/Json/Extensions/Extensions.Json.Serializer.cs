using System;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

// ReSharper disable once CheckNamespace
namespace Cosmos.Serialization.Json
{
    /// <summary>
    /// Newtonsoft Json Extensions
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// Serialize to string
        /// </summary>
        /// <param name="serializer"></param>
        /// <param name="request"></param>
        /// <typeparam name="TRequest"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string SerializeToString<TRequest>(this JsonSerializer serializer, TRequest request)
        {
            if (serializer == null)
                throw new ArgumentNullException(nameof(serializer));
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            using var stringWriter = new StringWriter(CultureInfo.InvariantCulture);
            using var jsonWriter = new JsonTextWriter(stringWriter);
            serializer.Serialize(jsonWriter, request);
            jsonWriter.Flush();
            return stringWriter.ToString();
        }

        /// <summary>
        /// Deserialize From String
        /// </summary>
        /// <param name="serializer"></param>
        /// <param name="json"></param>
        /// <typeparam name="TResponse"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static TResponse DeserializeFromString<TResponse>(this JsonSerializer serializer, string json)
        {
            if (serializer == null)
                throw new ArgumentNullException(nameof(json));
            if (string.IsNullOrWhiteSpace(json))
                throw new ArgumentNullException(nameof(json));

            using var stringReader = new StringReader(json);
            using var jsonReader = new JsonTextReader(stringReader);
            return serializer.Deserialize<TResponse>(jsonReader);

        }

        /// <summary>
        /// Serialize To Memory Stream Async
        /// </summary>
        /// <param name="serializer"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TRequest"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public static async Task<MemoryStream> SerializeToMemoryStreamAsync<TRequest>(
            this JsonSerializer serializer, TRequest request, CancellationToken cancellationToken)
        {
            if (serializer == null)
                throw new ArgumentNullException(nameof(serializer));
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            using var stream = new MemoryStream();
            using TextWriter textWriter = new StreamWriter(stream);
            using var jsonWriter = new JsonTextWriter(textWriter);
            serializer.Serialize(jsonWriter, request);

            await jsonWriter.FlushAsync(cancellationToken).ConfigureAwait(false);
            await textWriter.FlushAsync().ConfigureAwait(false);

            stream.Position = 0;

            if (!stream.TryGetBuffer(out ArraySegment<byte> buffer))
                throw new InvalidOperationException($"The call to {nameof(stream.TryGetBuffer)} returned false.");

            return new MemoryStream(buffer.Array, buffer.Offset, buffer.Count);
        }
    }
}