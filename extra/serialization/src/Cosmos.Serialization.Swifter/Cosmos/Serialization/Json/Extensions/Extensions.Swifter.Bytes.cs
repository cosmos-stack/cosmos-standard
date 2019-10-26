using System;
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
        /// To Swifter bytes
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static byte[] ToSwifterBytes<T>(this T obj, JsonFormatterOptions? options = null)
        {
            return SwifterHelper.SerializeToBytes(obj, options);
        }

        /// <summary>
        /// To Swifter bytes async
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<byte[]> ToSwifterBytesAsync<T>(this T obj, JsonFormatterOptions? options = null)
        {
            return SwifterHelper.SerializeToBytesAsync(obj, options);
        }

        /// <summary>
        /// From Swifter bytes 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T FromSwifterBytes<T>(this byte[] data, JsonFormatterOptions? options = null)
        {
            return SwifterHelper.DeserializeFromBytes<T>(data, options);
        }

        /// <summary>
        /// From Swifter bytes 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static object FromSwifterBytes(this byte[] data, Type type, JsonFormatterOptions? options = null)
        {
            return SwifterHelper.DeserializeFromBytes(data, type, options);
        }

        /// <summary>
        /// From Swifter bytes async
        /// </summary>
        /// <param name="data"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<T> FromSwifterBytesAsync<T>(this byte[] data, JsonFormatterOptions? options = null)
        {
            return SwifterHelper.DeserializeFromBytesAsync<T>(data, options);
        }

        /// <summary>
        /// From Swifter bytes async
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static Task<object> FromSwifterBytesAsync(this byte[] data, Type type, JsonFormatterOptions? options = null)
        {
            return SwifterHelper.DeserializeFromBytesAsync(data, type, options);
        }
    }
}