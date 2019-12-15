using System;
using System.IO;
using ZeroFormatter;

namespace Cosmos.Serialization.ZeroFormatter {
    /// <summary>
    /// ZeroFormatter helper
    /// </summary>
    public static partial class ZeroFormatterHelper {
        /// <summary>
        /// Pack
        /// </summary>
        /// <param name="t"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Stream Pack<T>(T t) {
            var ms = new MemoryStream();

            if (t == null)
                return ms;

            Pack(t, ms);

            return ms;
        }

        /// <summary>
        /// Pack
        /// </summary>
        /// <param name="o"></param>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        public static void Pack<T>(T o, Stream stream) {
            if (o != null) {
                ZeroFormatterSerializer.Serialize(stream, o);
            }
        }

        /// <summary>
        /// Pack
        /// </summary>
        /// <param name="type"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Stream Pack(object obj, Type type) {
            var ms = new MemoryStream();

            if (obj is null)
                return ms;

            Pack(obj, type, ms);

            return ms;
        }

        /// <summary>
        /// Pack
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <param name="stream"></param>
        public static void Pack(object obj, Type type, Stream stream) {
            if (obj != null) {
                ZeroFormatterSerializer.NonGeneric.Serialize(type, stream, obj);
            }
        }

        /// <summary>
        /// Unpack
        /// </summary>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Unpack<T>(Stream stream) {
            return stream is null
                ? default
                : ZeroFormatterSerializer.Deserialize<T>(stream);
        }

        /// <summary>
        /// Unpack
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object Unpack(Stream stream, Type type) {
            return stream is null
                ? default(Type)
                : ZeroFormatterSerializer.NonGeneric.Deserialize(type, stream);
        }
    }
}