using System;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Cosmos.Serialization.Json.Newtonsoft
{
    /// <summary>
    /// Newtonsoft Json Helper
    /// </summary>
    public static partial class JsonHelper
    {
        /// <summary>
        /// Pack async
        /// </summary>
        /// <param name="o"></param>
        /// <param name="settings"></param>
        /// <param name="withNodaTime"></param>
        /// <returns></returns>
        public static async Task<Stream> PackAsync(object o, JsonSerializerSettings settings = null, bool withNodaTime = false)
        {
            var ms = new MemoryStream();

            if (o is null)
                return ms;

            await PackAsync(o, ms, settings, withNodaTime);

            return ms;
        }

        /// <summary>
        /// Pack async
        /// </summary>
        /// <param name="o"></param>
        /// <param name="stream"></param>
        /// <param name="settings"></param>
        /// <param name="withNodaTime"></param>
        public static async Task PackAsync(object o, Stream stream, JsonSerializerSettings settings = null, bool withNodaTime = false)
        {
            if (o is null)
                return;

            var bytes = await JsonHelper.SerializeToBytesAsync(o, settings, withNodaTime);

            await stream.WriteAsync(bytes, 0, bytes.Length);
        }

        /// <summary>
        /// Unpack async
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="settings"></param>
        /// <param name="withNodaTime"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<T> UnpackAsync<T>(Stream stream, JsonSerializerSettings settings = null, bool withNodaTime = false)
        {
            return stream is null
                ? default
                : await JsonHelper.DeserializeAsync<T>(JsonManager.DefaultEncoding.GetString(await StreamToBytesAsync(stream)), settings, withNodaTime);
        }

        /// <summary>
        /// Unpack async
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="type"></param>
        /// <param name="settings"></param>
        /// <param name="withNodaTime"></param>
        /// <returns></returns>
        public static async Task<object> UnpackAsync(Stream stream, Type type, JsonSerializerSettings settings = null, bool withNodaTime = false)
        {
            return stream is null
                ? default
                : await JsonHelper.DeserializeAsync(JsonManager.DefaultEncoding.GetString(await StreamToBytesAsync(stream)), type, settings, withNodaTime);
        }

        private static async Task<byte[]> StreamToBytesAsync(Stream stream)
        {
            var bytes = new byte[stream.Length];

            if (stream.Position > 0 && stream.CanSeek)
                stream.Seek(0, SeekOrigin.Begin);

            await stream.ReadAsync(bytes, 0, bytes.Length);

            if (stream.CanSeek)
                stream.Seek(0, SeekOrigin.Begin);

            return bytes;
        }
    }
}