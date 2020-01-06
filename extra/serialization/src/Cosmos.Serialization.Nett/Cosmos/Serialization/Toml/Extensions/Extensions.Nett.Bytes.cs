using System;
using System.Threading.Tasks;
using Cosmos.Serialization.Toml.Nett;

// ReSharper disable once CheckNamespace
namespace Cosmos.Serialization.Toml {
    /// <summary>
    /// TomlDotNet extensions
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// To TomlDotNet bytes
        /// </summary>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static byte[] ToTomlBytes<T>(this T obj) => NettHelper.SerializeToBytes(obj);

        /// <summary>
        /// To TomlDotNet bytes async
        /// </summary>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<byte[]> ToTomlBytesAsync<T>(this T obj) => NettHelper.SerializeToBytesAsync(obj);

        /// <summary>
        /// From TomlDotNet bytes 
        /// </summary>
        /// <param name="data"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T FromTomlBytes<T>(this byte[] data) => NettHelper.DeserializeFromBytes<T>(data);

        /// <summary>
        /// From TomlDotNet bytes 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object FromTomlBytes(this byte[] data, Type type) => NettHelper.DeserializeFromBytes(data, type);

        /// <summary>
        /// From TomlDotNet bytes async
        /// </summary>
        /// <param name="data"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<T> FromTomlBytesAsync<T>(this byte[] data) => NettHelper.DeserializeFromBytesAsync<T>(data);

        /// <summary>
        /// From TomlDotNet bytes async
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Task<object> FromTomlBytesAsync(this byte[] data, Type type) => NettHelper.DeserializeFromBytesAsync(data, type);
    }
}