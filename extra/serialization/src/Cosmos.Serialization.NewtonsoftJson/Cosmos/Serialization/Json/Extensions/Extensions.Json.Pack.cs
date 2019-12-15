using System;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Cosmos.Serialization.Json.Newtonsoft;

// ReSharper disable once CheckNamespace
namespace Cosmos.Serialization.Json {
    /// <summary>
    /// Newtonsoft Json Extensions
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// Pack
        /// </summary>
        /// <param name="o"></param>
        /// <param name="settings"></param>
        /// <param name="withNodaTime"></param>
        /// <returns></returns>
        public static Stream JsonPack(this object o, JsonSerializerSettings settings = null, bool withNodaTime = false) {
            return JsonHelper.Pack(o, settings, withNodaTime);
        }

        /// <summary>
        /// Pack to
        /// </summary>
        /// <param name="o"></param>
        /// <param name="stream"></param>
        /// <param name="settings"></param>
        /// <param name="withNodaTime"></param>
        public static void JsonPackTo(this object o, Stream stream, JsonSerializerSettings settings = null, bool withNodaTime = false) {
            JsonHelper.Pack(o, stream, settings, withNodaTime);
        }

        /// <summary>
        /// Pack by
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="obj"></param>
        /// <param name="settings"></param>
        /// <param name="withNodaTime"></param>
        public static void JsonPackBy(this Stream stream, object obj, JsonSerializerSettings settings = null, bool withNodaTime = false) {
            JsonHelper.Pack(obj, stream, settings, withNodaTime);
        }

        /// <summary>
        /// Pack async
        /// </summary>
        /// <param name="o"></param>
        /// <param name="settings"></param>
        /// <param name="withNodaTime"></param>
        /// <returns></returns>
        public static Task<Stream> JsonPackAsync(this object o, JsonSerializerSettings settings = null, bool withNodaTime = false) {
            return JsonHelper.PackAsync(o, settings, withNodaTime);
        }

        /// <summary>
        /// Pack to async
        /// </summary>
        /// <param name="o"></param>
        /// <param name="stream"></param>
        /// <param name="settings"></param>
        /// <param name="withNodaTime"></param>
        /// <returns></returns>
        public static Task JsonPackToAsync(this object o, Stream stream, JsonSerializerSettings settings = null, bool withNodaTime = false) {
            return JsonHelper.PackAsync(o, stream, settings, withNodaTime);
        }

        /// <summary>
        /// Pack by async
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="obj"></param>
        /// <param name="settings"></param>
        /// <param name="withNodaTime"></param>
        public static Task JsonPackByAsync(this Stream stream, object obj, JsonSerializerSettings settings = null, bool withNodaTime = false) {
            return JsonHelper.PackAsync(obj, stream, settings, withNodaTime);
        }

        /// <summary>
        /// Unpack
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="settings"></param>
        /// <param name="withNodaTime"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T JsonUnpack<T>(this Stream stream, JsonSerializerSettings settings = null, bool withNodaTime = false) {
            return JsonHelper.Unpack<T>(stream, settings, withNodaTime);
        }

        /// <summary>
        /// Unpack
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="type"></param>
        /// <param name="settings"></param>
        /// <param name="withNodaTime"></param>
        /// <returns></returns>
        public static object JsonUnpack(this Stream stream, Type type, JsonSerializerSettings settings = null, bool withNodaTime = false) {
            return JsonHelper.Unpack(stream, type, settings, withNodaTime);
        }

        /// <summary>
        /// Unpack async
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="settings"></param>
        /// <param name="withNodaTime"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<T> JsonUnpackAsync<T>(this Stream stream, JsonSerializerSettings settings = null, bool withNodaTime = false) {
            return await JsonHelper.UnpackAsync<T>(stream, settings, withNodaTime);
        }

        /// <summary>
        /// Unpack async
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="type"></param>
        /// <param name="settings"></param>
        /// <param name="withNodaTime"></param>
        /// <returns></returns>
        public static async Task<object> JsonUnpackAsync(this Stream stream, Type type, JsonSerializerSettings settings = null, bool withNodaTime = false) {
            return await JsonHelper.UnpackAsync(stream, type, settings, withNodaTime);
        }
    }
}