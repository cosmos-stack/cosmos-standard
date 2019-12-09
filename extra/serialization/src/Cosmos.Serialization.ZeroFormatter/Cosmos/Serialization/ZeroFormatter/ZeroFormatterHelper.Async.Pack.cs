using System;
using System.IO;
using System.Threading.Tasks;
using ZeroFormatter;

namespace Cosmos.Serialization.ZeroFormatter {
    /// <summary>
    /// ZeroFormatter helper
    /// </summary>
    public static partial class ZeroFormatterHelper {
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

            return ms;
        }

        /// <summary>
        /// Pack async
        /// </summary>
        /// <param name="o"></param>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        public static async Task PackAsync<T>(T o, Stream stream) {
            if (o != null) {
                await Task.Run(() => ZeroFormatterSerializer.Serialize(stream, o));
            }
        }

        /// <summary>
        /// Pack async
        /// </summary>
        /// <param name="type"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static async Task<Stream> PackAsync(Type type, object obj) {
            var ms = new MemoryStream();

            if (obj is null)
                return ms;

            await PackAsync(obj, type, ms);

            return ms;
        }

        /// <summary>
        /// Pack async
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <param name="stream"></param>
        public static async Task PackAsync(object obj, Type type, Stream stream) {
            if (obj != null) {
                await Task.Run(() => ZeroFormatterSerializer.NonGeneric.Serialize(type, stream, obj));
            }
        }

        /// <summary>
        /// Unpack async
        /// </summary>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<T> UnpackAsync<T>(Stream stream) {
            return stream is null
                ? default
                : await Task.Run(() => ZeroFormatterSerializer.Deserialize<T>(stream));
        }

        /// <summary>
        /// Unpack async
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static async Task<object> UnpackAsync(Stream stream, Type type) {
            return stream is null
                ? default(Type)
                : await Task.Run(() => ZeroFormatterSerializer.NonGeneric.Deserialize(type, stream));
        }
    }
}