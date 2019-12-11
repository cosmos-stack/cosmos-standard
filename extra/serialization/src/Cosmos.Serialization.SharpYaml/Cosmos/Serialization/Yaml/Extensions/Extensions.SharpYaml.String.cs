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
        /// From Yaml
        /// </summary>
        /// <param name="str"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T FromSharpYaml<T>(this string str) => SharpYamlHelper.Deserialize<T>(str);

        /// <summary>
        /// From Yaml
        /// </summary>
        /// <param name="str"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object FromSharpYaml(this string str, Type type) => SharpYamlHelper.Deserialize(str, type);
        
        /// <summary>
        /// From Yaml async
        /// </summary>
        /// <param name="str"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<T> FromSharpYamlAsync<T>(this string str) => SharpYamlHelper.DeserializeAsync<T>(str);

        /// <summary>
        /// From Yaml async
        /// </summary>
        /// <param name="str"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Task<object> FromSharpYamlAsync(this string str, Type type) => SharpYamlHelper.DeserializeAsync(str, type);
    }
}