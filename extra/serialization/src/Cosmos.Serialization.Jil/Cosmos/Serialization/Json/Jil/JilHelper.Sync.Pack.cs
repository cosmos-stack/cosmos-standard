using System;
using System.IO;
using Cosmos.IO;
using Jil;

namespace Cosmos.Serialization.Json.Jil {
    /// <summary>
    /// JilJson helper
    /// </summary>
    public static partial class JilHelper {
        /// <summary>
        /// Pack
        /// </summary>
        /// <param name="o"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Stream Pack<T>(T o, Options options = null) {
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
        public static void Pack<T>(T t, Stream stream, Options options = null) {
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
        public static T Unpack<T>(Stream stream, Options options = null) {
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
        public static object Unpack(Stream stream, Type type, Options options = null) {
            return stream == null
                ? null
                : DeserializeFromBytes(stream.StreamToBytes(), type, options);
        }
    }
}