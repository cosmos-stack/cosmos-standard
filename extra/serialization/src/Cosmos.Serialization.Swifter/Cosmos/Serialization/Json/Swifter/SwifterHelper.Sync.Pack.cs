using System;
using System.IO;
using Cosmos.IO;
using Swifter.Json;

namespace Cosmos.Serialization.Json.Swifter {
    /// <summary>
    /// SwiftJson Helper
    /// </summary>
    public static partial class SwifterHelper {
        /// <summary>
        /// Pack
        /// </summary>
        /// <param name="o"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Stream Pack<T>(T o, JsonFormatterOptions? options = null) {
            var ms = new MemoryStream();

            if (o == null)
                return ms;

            Pack(o, ms, options);

            return ms;
        }

        /// <summary>
        /// Pack
        /// </summary>
        /// <param name="t"></param>
        /// <param name="stream"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        public static void Pack<T>(T t, Stream stream, JsonFormatterOptions? options = null) {
            if (t == null || !stream.CanWrite)
                return;

            var bytes = SerializeToBytes(t, options);

            stream.Write(bytes, 0, bytes.Length);
        }

        /// <summary>
        /// Unpack
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Unpack<T>(Stream stream, JsonFormatterOptions? options = null) {
            return stream == null
                ? default
                : DeserializeFromBytes<T>(stream.StreamToBytes(), options);
        }

        /// <summary>
        /// Unpack
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="type"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static object Unpack(Stream stream, Type type, JsonFormatterOptions? options = null) {
            return stream == null
                ? null
                : DeserializeFromBytes(stream.StreamToBytes(), type, options);
        }
    }
}