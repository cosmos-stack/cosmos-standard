using System;
using System.IO;
using System.Threading.Tasks;
using Cosmos.Serialization.Json.Utf8Json;
using Utf8Json;

// ReSharper disable once CheckNamespace
namespace Cosmos.Serialization.Json
{
    /// <summary>
    /// Utf8Json extensions
    /// </summary>
    public static partial  class Utf8JsonExtensions
    {
         /// <summary>
        /// Utf8Json pack to
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="resolver"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Stream Utf8JsonPack<T>(this T obj, IJsonFormatterResolver resolver = null)
        {
            return Utf8JsonHelper.Pack(obj, resolver);
        }

        /// <summary>
        /// Utf8Json pack to
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="stream"></param>
        /// <param name="resolver"></param>
        /// <typeparam name="T"></typeparam>
        public static void Utf8JsonPackTo<T>(this T obj, Stream stream, IJsonFormatterResolver resolver = null)
        {
            Utf8JsonHelper.Pack(obj, stream, resolver);
        }

        /// <summary>
        /// Utf8Json pack by
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="obj"></param>
        /// <param name="resolver"></param>
        public static void Utf8JsonPackBy(this Stream stream, object obj, IJsonFormatterResolver resolver = null)
        {
            Utf8JsonHelper.Pack(obj, stream, resolver);
        }

        /// <summary>
        /// Utf8Json pack to
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="resolver"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<Stream> Utf8JsonPackAsync<T>(this T obj, IJsonFormatterResolver resolver = null)
        {
            return Utf8JsonHelper.PackAsync(obj, resolver);
        }

        /// <summary>
        /// Utf8Json pack to
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="stream"></param>
        /// <param name="resolver"></param>
        /// <typeparam name="T"></typeparam>
        public static Task Utf8JsonPackToAsync<T>(this T obj, Stream stream, IJsonFormatterResolver resolver = null)
        {
            return Utf8JsonHelper.PackAsync(obj, stream, resolver);
        }

        /// <summary>
        /// Utf8Json pack by async
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="obj"></param>
        /// <param name="resolver"></param>
        public static Task Utf8JsonPackByAsync(this Stream stream, object obj, IJsonFormatterResolver resolver = null)
        {
            return Utf8JsonHelper.PackAsync(obj, stream, resolver);
        }

        /// <summary>
        /// Utf8Json unpack
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="resolver"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Utf8JsonUnpack<T>(this Stream stream, IJsonFormatterResolver resolver = null)
        {
            return Utf8JsonHelper.Unpack<T>(stream, resolver);
        }

        /// <summary>
        /// Utf8Json unpack
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="type"></param>
        /// <param name="resolver"></param>
        /// <returns></returns>
        public static object Utf8JsonUnpack(this Stream stream, Type type, IJsonFormatterResolver resolver = null)
        {
            return Utf8JsonHelper.Unpack(stream, type, resolver);
        }

        /// <summary>
        /// Utf8Json unpack async
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="resolver"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<T> Utf8JsonUnpackAsync<T>(this Stream stream, IJsonFormatterResolver resolver = null)
        {
            return await Utf8JsonHelper.UnpackAsync<T>(stream, resolver);
        }

        /// <summary>
        /// Utf8Json unpack async
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="type"></param>
        /// <param name="resolver"></param>
        /// <returns></returns>
        public static async Task<object> Utf8JsonUnpackAsync(this Stream stream, Type type, IJsonFormatterResolver resolver = null)
        {
            return await Utf8JsonHelper.UnpackAsync(stream, type, resolver);
        }
    }
}