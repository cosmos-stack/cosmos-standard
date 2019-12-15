using System;
using System.IO;
using System.Threading.Tasks;
using MessagePack;

namespace Cosmos.Serialization.MessagePack.Neuecc {
    /// <summary>
    /// Neuecc's MessagePack helper
    /// </summary>
    public static partial class NeueccMsgPackHelper {
        /// <summary>
        /// Pack async
        /// </summary>
        /// <param name="t"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<Stream> PackAsync<T>(T t) {
            var ms = new MemoryStream();

            if (t == null)
                return ms;

            await PackAsync(t, ms);

            ms.Seek(0, SeekOrigin.Begin);

            return ms;
        }

        /// <summary>
        /// Pack async
        /// </summary>
        /// <param name="t"></param>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        public static async Task PackAsync<T>(T t, Stream stream) {
            if (t == null)
                return;

            await MessagePackSerializer.SerializeAsync(stream, t);
        }

        /// <summary>
        /// Pack async
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static async Task<Stream> PackAsync(object obj, Type type) {
            var ms = new MemoryStream();

            if (obj is null)
                return ms;

            await PackAsync(obj, type, ms);

            ms.Seek(0, SeekOrigin.Begin);

            return ms;
        }

        /// <summary>
        /// Pack async
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <param name="stream"></param>
        public static async Task PackAsync(object obj, Type type, Stream stream) {
            if (obj is null)
                return;

#if NETFRAMEWORK
            await Task.Run(() => MessagePackSerializer.NonGeneric.Serialize(type, stream, obj));
#else
            await MessagePackSerializer.SerializeAsync(type, stream, obj);
#endif
        }

        /// <summary>
        /// Unpack async
        /// </summary>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<T> UnpackAsync<T>(Stream stream) {
            if (stream is null)
                return default;

            if (stream.CanSeek && stream.Position > 0)
                stream.Position = 0;

            return await MessagePackSerializer.DeserializeAsync<T>(stream);
        }

        /// <summary>
        /// Unpack async
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static async Task<object> UnpackAsync(Stream stream, Type type) {
            if (stream is null)
                return null;

            if (stream.CanSeek && stream.Position > 0)
                stream.Position = 0;

#if NETFRAMEWORK
            return await Task.Run(() => MessagePackSerializer.NonGeneric.Deserialize(type, stream));
#else
            return await MessagePackSerializer.DeserializeAsync(type, stream);
#endif
        }

        private static async Task<byte[]> StreamToBytesAsync(Stream stream) {
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