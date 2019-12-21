using System;
using System.IO;
using System.Text.Json;
using Cosmos.IO;

namespace Cosmos.Serialization.Json.MicrosoftJson {
    /// <summary>
    /// Microsoft System.Text.Json helper
    /// </summary>
    public static partial class MicrosoftJsonHelper {
        /// <summary>
        /// Pack
        /// </summary>
        /// <param name="o"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Stream Pack<T>(T o, JsonSerializerOptions options = null) {
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
        public static void Pack<T>(T t, Stream stream, JsonSerializerOptions options = null) {
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
        public static T Unpack<T>(Stream stream, JsonSerializerOptions options = null) {
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
        public static object Unpack(Stream stream, Type type, JsonSerializerOptions options = null) {
            return stream == null
                ? null
                : DeserializeFromBytes(stream.StreamToBytes(), type, options);
        }
    }
}