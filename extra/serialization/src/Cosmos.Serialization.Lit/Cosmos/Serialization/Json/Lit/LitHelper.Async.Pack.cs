using System;
using System.IO;
using System.Threading.Tasks;

namespace Cosmos.Serialization.Json.Lit
{
    /// <summary>
    /// Lit Helper
    /// </summary>
    public static partial class LitHelper
    {
        /// <summary>
        /// Pack async
        /// </summary>
        /// <param name="o"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<Stream> PackAsync<T>(T o)
        {
            var ms = new MemoryStream();

            if (o == null)
                return ms;

            await PackAsync(o, ms);

            return ms;
        }

        /// <summary>
        /// Pack async
        /// </summary>
        /// <param name="o"></param>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task PackAsync<T>(T o, Stream stream)
        {
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
        public static async Task<T> UnpackAsync<T>(Stream stream)
        {
            return stream is null
                ? default
                : await DeserializeFromBytesAsync<T>(await StreamToBytesAsync(stream));
        }

        /// <summary>
        /// Unpack async
        /// </summary>
        /// <param name="type"></param>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static async Task<object> UnpackAsync(Stream stream, Type type)
        {
            return stream is null
                ? default
                : await DeserializeFromBytesAsync(await StreamToBytesAsync(stream), type);
        }

        private static async Task<byte[]> StreamToBytesAsync(Stream stream)
        {
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