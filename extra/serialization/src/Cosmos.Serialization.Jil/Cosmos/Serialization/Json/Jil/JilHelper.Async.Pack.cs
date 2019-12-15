using System;
using System.IO;
using System.Threading.Tasks;
using Jil;

namespace Cosmos.Serialization.Json.Jil {
    /// <summary>
    /// JilJson helper
    /// </summary>
    public static partial class JilHelper {
        /// <summary>
        /// Pack async
        /// </summary>
        /// <param name="o"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<Stream> PackAsync<T>(T o, Options options = null) {
            var ms = new MemoryStream();

            if (o == null)
                return ms;

            await PackAsync(o, ms, options);

            return ms;
        }

        /// <summary>
        /// Pack async
        /// </summary>
        /// <param name="o"></param>
        /// <param name="stream"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task PackAsync<T>(T o, Stream stream, Options options = null) {
            if (o == null || !stream.CanWrite)
                return;

            var bytes = await SerializeToBytesAsync(o, options);

            await stream.WriteAsync(bytes, 0, bytes.Length);
        }

        /// <summary>
        /// Unpack async
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<T> UnpackAsync<T>(Stream stream, Options options = null) {
            return stream is null
                ? default
                : await DeserializeFromBytesAsync<T>(await StreamToBytesAsync(stream), options ?? JilManager.DefaultOptions);
        }

        /// <summary>
        /// Unpack async
        /// </summary>
        /// <param name="type"></param>
        /// <param name="stream"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static async Task<object> UnpackAsync(Stream stream, Type type, Options options = null) {
            return stream is null
                ? default
                : await DeserializeFromBytesAsync(await StreamToBytesAsync(stream), type, options ?? JilManager.DefaultOptions);
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