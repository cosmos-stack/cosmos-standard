using System;
using System.IO;
using Tommy = Nett.Toml;

namespace Cosmos.Serialization.Toml.Nett {
    /// <summary>
    /// Yaml Helper
    /// </summary>
    public static partial class NettHelper {
        /// <summary>
        /// Pack
        /// </summary>
        /// <param name="o"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Stream Pack<T>(T o) {
            var ms = new MemoryStream();

            if (o is null)
                return ms;

            Pack(o, ms);

            return ms;
        }

        /// <summary>
        /// Pack
        /// </summary>
        /// <param name="o"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Stream Pack(object o, Type type) {
            var ms = new MemoryStream();

            if (o is null)
                return ms;

            Pack(o, type, ms);

            return ms;
        }

        /// <summary>
        /// Pack
        /// </summary>
        /// <param name="o"></param>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        public static void Pack<T>(T o, Stream stream) {
            if (o is null || !stream.CanWrite)
                return;

            Tommy.WriteStream(o, stream, NettManager.DefaultSettings);
        }

        /// <summary>
        /// Pack
        /// </summary>
        /// <param name="o"></param>
        /// <param name="type"></param>
        /// <param name="stream"></param>
        public static void Pack(object o, Type type, Stream stream) {
            if (o is null || !stream.CanWrite)
                return;

            Tommy.WriteStream(o, stream, NettManager.DefaultSettings);
        }

        /// <summary>
        /// Unpack
        /// </summary>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Unpack<T>(Stream stream) {
            return stream == null
                ? default
                : Tommy.ReadStream<T>(stream, NettManager.DefaultSettings);
        }

        /// <summary>
        /// Unpack
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object Unpack(Stream stream, Type type) {
            return stream is null
                ? null
                : Tommy.ReadStream(stream, NettManager.DefaultSettings).Get(type);
        }
    }
}