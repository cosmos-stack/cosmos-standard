using System;
using System.Threading.Tasks;
using Cosmos.Serialization.Yaml.SharpYaml;

// ReSharper disable once CheckNamespace
namespace Cosmos.Serialization.Yaml {

    /// <summary>
    /// SharpYaml extensions
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// To SharpYaml bytes
        /// </summary>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static byte[] ToSharpYamlBytes<T>(this T obj) => SharpYamlHelper.SerializeToBytes(obj);

        /// <summary>
        /// To SharpYaml bytes async
        /// </summary>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<byte[]> ToSharpYamlBytesAsync<T>(this T obj) => SharpYamlHelper.SerializeToBytesAsync(obj);

        /// <summary>
        /// From SharpYaml bytes 
        /// </summary>
        /// <param name="data"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T FromSharpYamlBytes<T>(this byte[] data) => SharpYamlHelper.DeserializeFromBytes<T>(data);

        /// <summary>
        /// From SharpYaml bytes 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object FromSharpYamlBytes(this byte[] data, Type type) => SharpYamlHelper.DeserializeFromBytes(data, type);

        /// <summary>
        /// From SharpYaml bytes async
        /// </summary>
        /// <param name="data"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<T> FromSharpYamlBytesAsync<T>(this byte[] data) => SharpYamlHelper.DeserializeFromBytesAsync<T>(data);

        /// <summary>
        /// From SharpYaml bytes async
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Task<object> FromSharpYamlBytesAsync(this byte[] data, Type type) => SharpYamlHelper.DeserializeFromBytesAsync(data, type);
    }
}