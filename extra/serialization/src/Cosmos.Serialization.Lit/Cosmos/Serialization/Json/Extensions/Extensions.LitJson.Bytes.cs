using System;
using System.Threading.Tasks;
using Cosmos.Serialization.Json.Lit;

// ReSharper disable once CheckNamespace
namespace Cosmos.Serialization.Json {
    /// <summary>
    /// LitJson extensions
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// To LitJson bytes
        /// </summary>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static byte[] ToLitBytes<T>(this T obj) => LitHelper.SerializeToBytes(obj);

        /// <summary>
        /// To LitJson bytes async
        /// </summary>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<byte[]> ToLitBytesAsync<T>(this T obj) => LitHelper.SerializeToBytesAsync(obj);

        /// <summary>
        /// From LitJson bytes 
        /// </summary>
        /// <param name="data"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T FromLitBytes<T>(this byte[] data) => LitHelper.DeserializeFromBytes<T>(data);

        /// <summary>
        /// From LitJson bytes 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object FromLitBytes(this byte[] data, Type type) => LitHelper.DeserializeFromBytes(data, type);

        /// <summary>
        /// From LitJson bytes async
        /// </summary>
        /// <param name="data"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<T> FromLitBytesAsync<T>(this byte[] data) => LitHelper.DeserializeFromBytesAsync<T>(data);

        /// <summary>
        /// From LitJson bytes async
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Task<object> FromLitBytesAsync(this byte[] data, Type type) => LitHelper.DeserializeFromBytesAsync(data, type);
    }
}