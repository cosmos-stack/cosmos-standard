using System;
using System.IO;
using System.Threading.Tasks;
using Cosmos.Serialization.Json.Swifter;
using Swifter.Json;

// ReSharper disable once CheckNamespace
namespace Cosmos.Serialization.Json
{
    /// <summary>
    /// SwiftJson extensions
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// Swifter pack to
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Stream SwifterPack<T>(this T obj, JsonFormatterOptions? options = null)
        {
            return SwifterHelper.Pack(obj, options);
        }

        /// <summary>
        /// Swifter pack to
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="stream"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        public static void SwifterPackTo<T>(this T obj, Stream stream, JsonFormatterOptions? options = null)
        {
            SwifterHelper.Pack(obj, stream, options);
        }

        /// <summary>
        /// Swifter pack by
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="obj"></param>
        /// <param name="options"></param>
        public static void SwifterPackBy(this Stream stream, object obj, JsonFormatterOptions? options = null)
        {
            SwifterHelper.Pack(obj, stream, options);
        }

        /// <summary>
        /// Swifter pack to
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<Stream> SwifterPackAsync<T>(this T obj, JsonFormatterOptions? options = null)
        {
            return SwifterHelper.PackAsync(obj, options);
        }

        /// <summary>
        /// Swifter pack to
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="stream"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        public static Task SwifterPackToAsync<T>(this T obj, Stream stream, JsonFormatterOptions? options = null)
        {
            return SwifterHelper.PackAsync(obj, stream, options);
        }

        /// <summary>
        /// Swifter pack by async
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="obj"></param>
        /// <param name="options"></param>
        public static Task SwifterPackByAsync(this Stream stream, object obj, JsonFormatterOptions? options = null)
        {
            return SwifterHelper.PackAsync(obj, stream, options);
        }

        /// <summary>
        /// Swifter unpack
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T SwifterUnpack<T>(this Stream stream, JsonFormatterOptions? options = null)
        {
            return SwifterHelper.Unpack<T>(stream, options);
        }

        /// <summary>
        /// Swifter unpack
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="type"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static object SwifterUnpack(this Stream stream, Type type, JsonFormatterOptions? options = null)
        {
            return SwifterHelper.Unpack(stream, type, options);
        }

        /// <summary>
        /// Swifter unpack async
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<T> SwifterUnpackAsync<T>(this Stream stream, JsonFormatterOptions? options = null)
        {
            return await SwifterHelper.UnpackAsync<T>(stream, options);
        }

        /// <summary>
        /// Swifter unpack async
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="type"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static async Task<object> SwifterUnpackAsync(this Stream stream, Type type, JsonFormatterOptions? options = null)
        {
            return await SwifterHelper.UnpackAsync(stream, type, options);
        }
    }
}