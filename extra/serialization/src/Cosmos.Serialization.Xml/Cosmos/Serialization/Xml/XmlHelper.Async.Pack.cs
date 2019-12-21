using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Cosmos.Serialization.Xml {
    /// <summary>
    /// Xml Helper
    /// </summary>
    public static partial class XmlHelper {
        /// <summary>
        /// Pack
        /// </summary>
        /// <param name="o"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<Stream> PackAsync<T>(T o) {
            return PackAsync(o, typeof(T));
        }

        /// <summary>
        /// Pack async
        /// </summary>
        /// <param name="o"></param>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        public static Task PackAsync<T>(T o, Stream stream) {
            return PackAsync(o, typeof(T), stream);
        }

        /// <summary>
        /// Pack async
        /// </summary>
        /// <param name="type"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static async Task<Stream> PackAsync(object obj, Type type) {
            if (obj is null)
                return new MemoryStream();

            var ms = new MemoryStream();

            await PackAsync(obj, type, ms);

            return ms;
        }

        /// <summary>
        /// Pack async
        /// </summary>
        /// <param name="type"></param>
        /// <param name="obj"></param>
        /// <param name="stream"></param>
        public static async Task PackAsync(object obj, Type type, Stream stream) {
            if (obj is null)
                return;

            var serializer = new XmlSerializer(type);

            await Task.Run(() => serializer.Serialize(stream, obj));
        }

        /// <summary>
        /// Unpack async
        /// </summary>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<T> UnpackAsync<T>(Stream stream) {
            return (T) await UnpackAsync(stream, typeof(T));
        }

        /// <summary>
        /// Unpack async
        /// </summary>
        /// <param name="type"></param>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static Task<object> UnpackAsync(Stream stream, Type type) {
            if (stream is null || stream.Length == 0)
                return default;

            if (stream.CanSeek && stream.Position > 0)
                stream.Position = 0;

            var xmlSerializer = new XmlSerializer(type);

            return Task.Run(() => xmlSerializer.Deserialize(stream));
        }
    }
}