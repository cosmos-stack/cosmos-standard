using System;
using System.IO;
using System.Threading.Tasks;

namespace Cosmos.Serialization.Yaml.YamlDotNet {
    /// <summary>
    /// Yaml Helper
    /// </summary>
    public static partial class YamlHelper {
        /// <summary>
        /// Pack async
        /// </summary>
        /// <param name="o"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<Stream> PackAsync<T>(T o) {
            var ms = new MemoryStream();

            if (o is null)
                return ms;

            await PackAsync(o, ms);

            return ms;
        }

        /// <summary>
        /// Pack
        /// </summary>
        /// <param name="o"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static async Task<Stream> PackAsync(object o, Type type) {
            var ms = new MemoryStream();

            if (o is null)
                return ms;

            await PackAsync(o, type, ms);

            return ms;
        }

        /// <summary>
        /// Pack async
        /// </summary>
        /// <param name="o"></param>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        public static async Task PackAsync<T>(T o, Stream stream) {
            if (o == null || !stream.CanWrite)
                return;

            var bytes = await SerializeToBytesAsync(o);

            await stream.WriteAsync(bytes, 0, bytes.Length);
        }

        /// <summary>
        /// Pack
        /// </summary>
        /// <param name="o"></param>
        /// <param name="type"></param>
        /// <param name="stream"></param>
        public static async Task PackAsync(object o, Type type, Stream stream) {
            if (o == null || !stream.CanWrite)
                return;

            var bytes = await SerializeToBytesAsync(o);

            await stream.WriteAsync(bytes, 0, bytes.Length);
        }

        /// <summary>
        /// Unpack async
        /// </summary>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<T> UnpackAsync<T>(Stream stream) {
            return stream == null
                ? default
                : await DeserializeFromBytesAsync<T>(await StreamToBytesAsync(stream));
        }

        /// <summary>
        /// Unpack async
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static async Task<object> UnpackAsync(Stream stream, Type type) {
            return stream == null
                ? null
                : await DeserializeFromBytesAsync(await StreamToBytesAsync(stream), type);
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