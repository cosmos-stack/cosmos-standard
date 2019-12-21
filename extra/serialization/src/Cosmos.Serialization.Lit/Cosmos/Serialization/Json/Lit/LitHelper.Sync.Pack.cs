using System;
using System.IO;
using Cosmos.IO;

namespace Cosmos.Serialization.Json.Lit {
    /// <summary>
    /// Lit Helper
    /// </summary>
    public static partial class LitHelper {
        /// <summary>
        /// Pack
        /// </summary>
        /// <param name="o"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Stream Pack<T>(T o) {
            var ms = new MemoryStream();

            if (o == null)
                return ms;

            Pack(o, ms);

            return ms;
        }

        /// <summary>
        /// Pack
        /// </summary>
        /// <param name="t"></param>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        public static void Pack<T>(T t, Stream stream) {
            if (t == null || !stream.CanWrite)
                return;

            var bytes = SerializeToBytes(t);

            stream.Write(bytes, 0, bytes.Length);
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
                : DeserializeFromBytes<T>(stream.StreamToBytes());
        }

        /// <summary>
        /// Unpack
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object Unpack(Stream stream, Type type) {
            return stream == null
                ? null
                : DeserializeFromBytes(stream.StreamToBytes(), type);
        }
    }
}