using System;
using System.IO;
using System.Threading.Tasks;
using Utf8Json;

namespace Cosmos.Serialization.Json.Utf8Json {
    /// <summary>
    /// Utf8Json helper
    /// </summary>
    public static partial class Utf8JsonHelper {
        /// <summary>
        /// Pack async
        /// </summary>
        /// <param name="o"></param>
        /// <param name="resolver"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<Stream> PackAsync<T>(T o, IJsonFormatterResolver resolver = null) {
            var ms = new MemoryStream();

            if (o == null)
                return ms;

            await PackAsync(o, ms, resolver);

            return ms;
        }

        /// <summary>
        /// Pack async
        /// </summary>
        /// <param name="t"></param>
        /// <param name="stream"></param>
        /// <param name="resolver"></param>
        /// <typeparam name="T"></typeparam>
        public static async Task PackAsync<T>(T t, Stream stream, IJsonFormatterResolver resolver = null) {
            if (t == null || !stream.CanWrite)
                return;

            var bytes = await SerializeToBytesAsync(t, resolver);

            await stream.WriteAsync(bytes, 0, bytes.Length);
        }

        /// <summary>
        /// Unpack async
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="resolver"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<T> UnpackAsync<T>(Stream stream, IJsonFormatterResolver resolver = null) {
            return stream == null
                ? default
                : await DeserializeFromBytesAsync<T>(await StreamToBytesAsync(stream), resolver);
        }

        /// <summary>
        /// Unpack async
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="type"></param>
        /// <param name="resolver"></param>
        /// <returns></returns>
        public static async Task<object> UnpackAsync(Stream stream, Type type, IJsonFormatterResolver resolver = null) {
            return stream == null
                ? null
                : await DeserializeFromBytesAsync(await StreamToBytesAsync(stream), type, resolver);
        }

        private static async Task<byte[]> StreamToBytesAsync(Stream stream) {
            var bytes = new byte[stream.Length];

            if (stream.CanSeek && stream.Position > 0)
                stream.Seek(0, SeekOrigin.Begin);

            await stream.ReadAsync(bytes, 0, bytes.Length);

            if (stream.CanSeek)
                stream.Seek(0, SeekOrigin.Begin);

            return bytes;
        }
    }
}