using System;
using System.IO;
using System.Threading.Tasks;
using Kooboo.Json;
using Cosmos.Serialization.Json.Kooboo;

// ReSharper disable once CheckNamespace
namespace Cosmos.Serialization.Json {
    using K = KoobooJsonHelper;

    /// <summary>
    /// KoobooJson extensions
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// Kooboo pack to
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Stream KoobooPack<T>(this T obj, JsonSerializerOption options = null) => K.Pack(obj, options);

        /// <summary>
        /// Kooboo pack to
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="stream"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        public static void KoobooPackTo<T>(this T obj, Stream stream, JsonSerializerOption options = null) => K.Pack(obj, stream, options);

        /// <summary>
        /// Kooboo pack by
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="obj"></param>
        /// <param name="options"></param>
        public static void KoobooPackBy(this Stream stream, object obj, JsonSerializerOption options = null) => K.Pack(obj, stream, options);

        /// <summary>
        /// Kooboo pack to
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<Stream> KoobooPackAsync<T>(this T obj, JsonSerializerOption options = null) => K.PackAsync(obj, options);

        /// <summary>
        /// Kooboo pack to
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="stream"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        public static Task KoobooPackToAsync<T>(this T obj, Stream stream, JsonSerializerOption options = null) => K.PackAsync(obj, stream, options);

        /// <summary>
        /// Kooboo pack by async
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="obj"></param>
        /// <param name="options"></param>
        public static Task KoobooPackByAsync(this Stream stream, object obj, JsonSerializerOption options = null) => K.PackAsync(obj, stream, options);

        /// <summary>
        /// Kooboo unpack
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T KoobooUnpack<T>(this Stream stream, JsonDeserializeOption options = null) => K.Unpack<T>(stream, options);

        /// <summary>
        /// Kooboo unpack
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="type"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static object KoobooUnpack(this Stream stream, Type type, JsonDeserializeOption options = null) => K.Unpack(stream, type, options);

        /// <summary>
        /// Kooboo unpack async
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<T> KoobooUnpackAsync<T>(this Stream stream, JsonDeserializeOption options = null) => await K.UnpackAsync<T>(stream, options);

        /// <summary>
        /// Kooboo unpack async
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="type"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static async Task<object> KoobooUnpackAsync(this Stream stream, Type type, JsonDeserializeOption options = null) => await K.UnpackAsync(stream, type, options);
    }
}