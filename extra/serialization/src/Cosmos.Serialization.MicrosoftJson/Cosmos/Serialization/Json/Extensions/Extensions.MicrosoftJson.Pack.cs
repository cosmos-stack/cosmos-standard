using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Cosmos.Serialization.Json.MicrosoftJson;

// ReSharper disable once CheckNamespace
namespace Cosmos.Serialization.Json {
    using MS = MicrosoftJsonHelper;

    /// <summary>
    /// Microsoft System.Text.Json extensions
    /// </summary>
    public static partial class MsJsonExtensions {
        /// <summary>
        /// Microsoft System.Text.Json pack to
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Stream MicrosoftJsonPack<T>(this T obj, JsonSerializerOptions options = null) => MS.Pack(obj, options);


        /// <summary>
        /// Microsoft System.Text.Json pack to
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="stream"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        public static void MicrosoftJsonPackTo<T>(this T obj, Stream stream, JsonSerializerOptions options = null) => MS.Pack(obj, stream, options);


        /// <summary>
        /// Microsoft System.Text.Json pack by
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="obj"></param>
        /// <param name="options"></param>
        public static void MicrosoftJsonPackBy(this Stream stream, object obj, JsonSerializerOptions options = null) => MS.Pack(obj, stream, options);


        /// <summary>
        /// Microsoft System.Text.Json pack to
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<Stream> MicrosoftJsonPackAsync<T>(this T obj, JsonSerializerOptions options = null) => MS.PackAsync(obj, options);


        /// <summary>
        /// Microsoft System.Text.Json pack to
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="stream"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        public static Task MicrosoftJsonPackToAsync<T>(this T obj, Stream stream, JsonSerializerOptions options = null) => MS.PackAsync(obj, stream, options);


        /// <summary>
        /// Microsoft System.Text.Json pack by async
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="obj"></param>
        /// <param name="options"></param>
        public static Task MicrosoftJsonPackByAsync(this Stream stream, object obj, JsonSerializerOptions options = null) => MS.PackAsync(obj, stream, options);


        /// <summary>
        /// Microsoft System.Text.Json unpack
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T MicrosoftJsonUnpack<T>(this Stream stream, JsonSerializerOptions options = null) => MS.Unpack<T>(stream, options);


        /// <summary>
        /// Microsoft System.Text.Json unpack
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="type"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static object MicrosoftJsonUnpack(this Stream stream, Type type, JsonSerializerOptions options = null) => MS.Unpack(stream, type, options);


        /// <summary>
        /// Microsoft System.Text.Json unpack async
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<T> MicrosoftJsonUnpackAsync<T>(this Stream stream, JsonSerializerOptions options = null) => await MS.UnpackAsync<T>(stream, options);


        /// <summary>
        /// Microsoft System.Text.Json unpack async
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="type"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static async Task<object> MicrosoftJsonUnpackAsync(this Stream stream, Type type, JsonSerializerOptions options = null) =>
            await MS.UnpackAsync(stream, type, options);

    }
}