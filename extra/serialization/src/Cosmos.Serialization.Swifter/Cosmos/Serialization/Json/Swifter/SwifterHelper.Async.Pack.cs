using System;
using System.IO;
using System.Threading.Tasks;
using Swifter.Json;

namespace Cosmos.Serialization.Json.Swifter
{
    /// <summary>
    /// SwiftJson Helper
    /// </summary>
    public static partial class SwifterHelper
    {
         /// <summary>
        /// Pack async
        /// </summary>
        /// <param name="o"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<Stream> PackAsync<T>(T o, JsonFormatterOptions?  options = null)
        {
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
        public static async Task PackAsync<T>(T o, Stream stream, JsonFormatterOptions?  options = null)
        {
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
        public static async Task<T> UnpackAsync<T>(Stream stream, JsonFormatterOptions?  options = null)
        {
            return stream is null
                ? default
                : await DeserializeFromBytesAsync<T>(await StreamToBytesAsync(stream), options ?? SwifterJsonManager.DefaltDeserializeOptions);
        }

        /// <summary>
        /// Unpack async
        /// </summary>
        /// <param name="type"></param>
        /// <param name="stream"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static async Task<object> UnpackAsync(Stream stream, Type type, JsonFormatterOptions?  options = null)
        {
            return stream is null
                ? default
                : await DeserializeFromBytesAsync(await StreamToBytesAsync(stream), type, options ?? SwifterJsonManager.DefaltDeserializeOptions);
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