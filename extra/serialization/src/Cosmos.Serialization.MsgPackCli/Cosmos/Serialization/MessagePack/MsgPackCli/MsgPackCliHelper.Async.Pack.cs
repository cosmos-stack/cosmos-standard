using System;
using System.IO;
using System.Threading.Tasks;
using MsgPack.Serialization;

namespace Cosmos.Serialization.MessagePack.MsgPackCli {
    /// <summary>
    /// MessagePack-Cli helper
    /// </summary>
    public static partial class MsgPackCliHelper {
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

            var serializer = MessagePackSerializer.Get<T>();

            await serializer.PackAsync(stream, t);
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

            var serializer = MessagePackSerializer.Get(type);

            await Task.Run(() => serializer.Pack(stream, obj));
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

            var serializer = MessagePackSerializer.Get<T>();

            if (stream.CanSeek && stream.Position > 0)
                stream.Position = 0;

            return await serializer.UnpackAsync(stream);
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

            var serializer = MessagePackSerializer.Get(type);

            if (stream.CanSeek && stream.Position > 0)
                stream.Position = 0;

            return await Task.Run(() => serializer.Unpack(stream));
        }
    }
}