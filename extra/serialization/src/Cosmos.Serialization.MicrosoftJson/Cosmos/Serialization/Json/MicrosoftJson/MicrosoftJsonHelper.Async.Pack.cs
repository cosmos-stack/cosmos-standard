using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Cosmos.IO;

namespace Cosmos.Serialization.Json.MicrosoftJson {
    /// <summary>
    /// Microsoft System.Text.Json helper
    /// </summary>
    public static partial class MicrosoftJsonHelper {
        /// <summary>
        /// Pack async
        /// </summary>
        /// <param name="o"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<Stream> PackAsync<T>(T o, JsonSerializerOptions options = null) {
            var ms = new MemoryStream();

            if (o == null)
                return ms;

            await PackAsync(o, ms, options);

            return ms;
        }

        /// <summary>
        /// Pack async
        /// </summary>
        /// <param name="t"></param>
        /// <param name="stream"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        public static async Task PackAsync<T>(T t, Stream stream, JsonSerializerOptions options = null) {
            if (t == null || !stream.CanWrite)
                return;

            var bytes = await SerializeToBytesAsync(t, options);

            await stream.WriteAsync(bytes, 0, bytes.Length);
        }

        /// <summary>
        /// Unpack async
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<T> UnpackAsync<T>(Stream stream, JsonSerializerOptions options = null) {
            return stream == null
                ? default
                : await DeserializeFromBytesAsync<T>(await stream.StreamToBytesAsync(), options);
        }

        /// <summary>
        /// Unpack async
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="type"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static async Task<object> UnpackAsync(Stream stream, Type type, JsonSerializerOptions options = null) {
            return stream == null
                ? null
                : await DeserializeFromBytesAsync(await stream.StreamToBytesAsync(), type, options);
        }
    }
}