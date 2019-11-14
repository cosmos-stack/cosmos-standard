using System;
using System.IO;
using System.Threading.Tasks;
using Jil;
using Cosmos.Serialization.Json.Jil;

// ReSharper disable once CheckNamespace
namespace Cosmos.Serialization.Json
{
    /// <summary>
    /// JilJson extensions
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// Jil pack to
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Stream JilPack<T>(this T obj, Options options = null) => JilHelper.Pack(obj, options);

        /// <summary>
        /// Jil pack to
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="stream"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        public static void JilPackTo<T>(this T obj, Stream stream, Options options = null) => JilHelper.Pack(obj, stream, options);

        /// <summary>
        /// Jil pack by
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="obj"></param>
        /// <param name="options"></param>
        public static void JilPackBy(this Stream stream, object obj, Options options = null) => JilHelper.Pack(obj, stream, options);

        /// <summary>
        /// Jil pack to
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<Stream> JilPackAsync<T>(this T obj, Options options = null) => JilHelper.PackAsync(obj, options);

        /// <summary>
        /// Jil pack to
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="stream"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        public static Task JilPackToAsync<T>(this T obj, Stream stream, Options options = null) => JilHelper.PackAsync(obj, stream, options);

        /// <summary>
        /// Jil pack by async
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="obj"></param>
        /// <param name="options"></param>
        public static Task JilPackByAsync(this Stream stream, object obj, Options options = null) => JilHelper.PackAsync(obj, stream, options);

        /// <summary>
        /// Jil unpack
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T JilUnpack<T>(this Stream stream, Options options = null) => JilHelper.Unpack<T>(stream, options);

        /// <summary>
        /// Jil unpack
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="type"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static object JilUnpack(this Stream stream, Type type, Options options = null) => JilHelper.Unpack(stream, type, options);

        /// <summary>
        /// Jil unpack async
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<T> JilUnpackAsync<T>(this Stream stream, Options options = null) => await JilHelper.UnpackAsync<T>(stream, options);

        /// <summary>
        /// Jil unpack async
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="type"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static async Task<object> JilUnpackAsync(this Stream stream, Type type, Options options = null) => await JilHelper.UnpackAsync(stream, type, options);
    }
}