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
        /// From Yaml
        /// </summary>
        /// <param name="str"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T FromYaml<T>(this string str) => YamlHelper.Deserialize<T>(str);

        /// <summary>
        /// From Yaml
        /// </summary>
        /// <param name="str"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object FromYaml(this string str, Type type) => YamlHelper.Deserialize(str, type);

        /// <summary>
        /// From Yaml async
        /// </summary>
        /// <param name="str"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<T> FromYamlAsync<T>(this string str) => YamlHelper.DeserializeAsync<T>(str);

        /// <summary>
        /// From Yaml async
        /// </summary>
        /// <param name="str"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Task<object> FromYamlAsync(this string str, Type type) => YamlHelper.DeserializeAsync(str, type);
    }
}