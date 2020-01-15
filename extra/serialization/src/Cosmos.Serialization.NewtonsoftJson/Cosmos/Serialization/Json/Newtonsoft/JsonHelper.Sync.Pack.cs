using System;
using System.IO;
using Newtonsoft.Json;

namespace Cosmos.Serialization.Json.Newtonsoft {
    /// <summary>
    /// Newtonsoft Json Helper
    /// </summary>
    public static partial class JsonHelper {
        /// <summary>
        /// Pack
        /// </summary>
        /// <param name="o"></param>
        /// <param name="settings"></param>
        /// <param name="withNodaTime"></param>
        /// <returns></returns>
        public static Stream Pack(object o, JsonSerializerSettings settings = null, bool withNodaTime = false) {
            var ms = new MemoryStream();

            if (o is null)
                return ms;

            Pack(o, ms, settings, withNodaTime);

            return ms;
        }

        /// <summary>
        /// Pack
        /// </summary>
        /// <param name="o"></param>
        /// <param name="stream"></param>
        /// <param name="settings"></param>
        /// <param name="withNodaTime"></param>
        public static void Pack(object o, Stream stream, JsonSerializerSettings settings = null, bool withNodaTime = false) {
            if (o is null)
                return;

            var bytes = SerializeToBytes(o, settings, withNodaTime);

            stream.Write(bytes, 0, bytes.Length);
        }

        /// <summary>
        /// Unpack
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="settings"></param>
        /// <param name="withNodaTime"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Unpack<T>(Stream stream, JsonSerializerSettings settings = null, bool withNodaTime = false) {
            return stream is null
                ? default
                : Deserialize<T>(JsonManager.DefaultEncoding.GetString(stream.CastToBytes()), settings, withNodaTime);
        }

        /// <summary>
        /// Unpack
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="type"></param>
        /// <param name="settings"></param>
        /// <param name="withNodaTime"></param>
        /// <returns></returns>
        public static object Unpack(Stream stream, Type type, JsonSerializerSettings settings = null, bool withNodaTime = false) {
            return stream is null
                ? default
                : Deserialize(JsonManager.DefaultEncoding.GetString(stream.CastToBytes()), type, settings, withNodaTime);
        }
    }
}