using System;
using System.IO;
using Cosmos.IO;
using Kooboo.Json;

namespace Cosmos.Serialization.Json.Kooboo {
    /// <summary>
    /// KoobooJson helper
    /// </summary>
    public static partial class KoobooJsonHelper {
        /// <summary>
        /// Pack
        /// </summary>
        /// <param name="o"></param>
        /// <param name="option"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Stream Pack<T>(T o, JsonSerializerOption option = null) {
            var ms = new MemoryStream();

            if (o is null)
                return ms;

            Pack(o, ms, option);

            return ms;
        }

        /// <summary>
        /// Pack
        /// </summary>
        /// <param name="o"></param>
        /// <param name="stream"></param>
        /// <param name="option"></param>
        /// <typeparam name="T"></typeparam>
        public static void Pack<T>(T o, Stream stream, JsonSerializerOption option = null) {
            if (o is null)
                return;

            var bytes = SerializeToBytes(o, option);

            stream.Write(bytes, 0, bytes.Length);
        }

        /// <summary>
        /// Unpack
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="option"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Unpack<T>(Stream stream, JsonDeserializeOption option = null) {
            return stream is null
                ? default
                : Deserialize<T>(KoobooManager.DefaultEncoding.GetString(stream.StreamToBytes()), option);
        }

        /// <summary>
        /// Unpack
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="type"></param>
        /// <param name="option"></param>
        /// <returns></returns>
        public static object Unpack(Stream stream, Type type, JsonDeserializeOption option = null) {
            return stream is null
                ? default
                : Deserialize(KoobooManager.DefaultEncoding.GetString(stream.StreamToBytes()), type, option);
        }
    }
}