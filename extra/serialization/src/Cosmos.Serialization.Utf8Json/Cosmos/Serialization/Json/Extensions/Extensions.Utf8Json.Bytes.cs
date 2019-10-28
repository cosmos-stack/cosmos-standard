using System;
using System.Threading.Tasks;
using Cosmos.Serialization.Json.Utf8Json;
using Utf8Json;

// ReSharper disable once CheckNamespace
namespace Cosmos.Serialization.Json
{
    /// <summary>
    /// Utf8Json extensions
    /// </summary>
    public static partial class Utf8JsonExtensions
    {
        /// <summary>
        /// To Utf8Json bytes
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="resolver"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static byte[] ToUtf8JsonBytes<T>(this T obj, IJsonFormatterResolver resolver = null)
        {
            return Utf8JsonHelper.SerializeToBytes(obj, resolver);
        }

        /// <summary>
        /// To Utf8Json bytes async
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="resolver"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<byte[]> ToUtf8JsonBytesAsync<T>(this T obj, IJsonFormatterResolver resolver = null)
        {
            return Utf8JsonHelper.SerializeToBytesAsync(obj, resolver);
        }

        /// <summary>
        /// From Utf8Json bytes 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="resolver"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T FromUtf8JsonBytes<T>(this byte[] data, IJsonFormatterResolver resolver = null)
        {
            return Utf8JsonHelper.DeserializeFromBytes<T>(data, resolver);
        }

        /// <summary>
        /// From Utf8Json bytes 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <param name="resolver"></param>
        /// <returns></returns>
        public static object FromUtf8JsonBytes(this byte[] data, Type type, IJsonFormatterResolver resolver = null)
        {
            return Utf8JsonHelper.DeserializeFromBytes(data, type, resolver);
        }

        /// <summary>
        /// From Utf8Json bytes async
        /// </summary>
        /// <param name="data"></param>
        /// <param name="resolver"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<T> FromUtf8JsonBytesAsync<T>(this byte[] data, IJsonFormatterResolver resolver = null)
        {
            return Utf8JsonHelper.DeserializeFromBytesAsync<T>(data, resolver);
        }

        /// <summary>
        /// From Utf8Json bytes async
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <param name="resolver"></param>
        /// <returns></returns>
        public static Task<object> FromUtf8JsonBytesAsync(this byte[] data, Type type, IJsonFormatterResolver resolver = null)
        {
            return Utf8JsonHelper.DeserializeFromBytesAsync(data, type, resolver);
        }
    }
}