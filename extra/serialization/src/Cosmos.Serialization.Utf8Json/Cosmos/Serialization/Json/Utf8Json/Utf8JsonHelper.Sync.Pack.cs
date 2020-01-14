using System;
using System.IO;
using Utf8Json;

namespace Cosmos.Serialization.Json.Utf8Json {
    /// <summary>
    /// Utf8Json helper
    /// </summary>
    public static partial class Utf8JsonHelper {
        /// <summary>
        /// Pack
        /// </summary>
        /// <param name="o"></param>
        /// <param name="resolver"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Stream Pack<T>(T o, IJsonFormatterResolver resolver = null) {
            var ms = new MemoryStream();

            if (o == null)
                return ms;

            Pack(o, ms, resolver);

            return ms;
        }

        /// <summary>
        /// Pack
        /// </summary>
        /// <param name="t"></param>
        /// <param name="stream"></param>
        /// <param name="resolver"></param>
        /// <typeparam name="T"></typeparam>
        public static void Pack<T>(T t, Stream stream, IJsonFormatterResolver resolver = null) {
            if (t == null || !stream.CanWrite)
                return;

            var bytes = SerializeToBytes(t, resolver);

            stream.Write(bytes, 0, bytes.Length);
        }

        /// <summary>
        /// Unpack
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="resolver"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Unpack<T>(Stream stream, IJsonFormatterResolver resolver = null) {
            return stream == null
                ? default
                : DeserializeFromBytes<T>(stream.CastToBytes(), resolver);
        }

        /// <summary>
        /// Unpack
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="type"></param>
        /// <param name="resolver"></param>
        /// <returns></returns>
        public static object Unpack(Stream stream, Type type, IJsonFormatterResolver resolver = null) {
            return stream == null
                ? null
                : DeserializeFromBytes(stream.CastToBytes(), type, resolver);
        }
    }
}