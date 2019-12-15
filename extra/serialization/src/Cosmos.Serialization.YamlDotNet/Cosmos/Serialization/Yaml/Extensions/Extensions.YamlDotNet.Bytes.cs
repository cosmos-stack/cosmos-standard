using System;
using System.Threading.Tasks;
using Cosmos.Serialization.Yaml.YamlDotNet;

// ReSharper disable once CheckNamespace
namespace Cosmos.Serialization.Yaml {
    /// <summary>
    /// YamlDotNet extensions
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// To YamlDotNet bytes
        /// </summary>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static byte[] ToYamlBytes<T>(this T obj) => YamlHelper.SerializeToBytes(obj);

        /// <summary>
        /// To YamlDotNet bytes async
        /// </summary>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<byte[]> ToYamlBytesAsync<T>(this T obj) => YamlHelper.SerializeToBytesAsync(obj);

        /// <summary>
        /// From YamlDotNet bytes 
        /// </summary>
        /// <param name="data"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T FromYamlBytes<T>(this byte[] data) => YamlHelper.DeserializeFromBytes<T>(data);

        /// <summary>
        /// From YamlDotNet bytes 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object FromYamlBytes(this byte[] data, Type type) => YamlHelper.DeserializeFromBytes(data, type);

        /// <summary>
        /// From YamlDotNet bytes async
        /// </summary>
        /// <param name="data"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<T> FromYamlBytesAsync<T>(this byte[] data) => YamlHelper.DeserializeFromBytesAsync<T>(data);

        /// <summary>
        /// From YamlDotNet bytes async
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Task<object> FromYamlBytesAsync(this byte[] data, Type type) => YamlHelper.DeserializeFromBytesAsync(data, type);
    }
}