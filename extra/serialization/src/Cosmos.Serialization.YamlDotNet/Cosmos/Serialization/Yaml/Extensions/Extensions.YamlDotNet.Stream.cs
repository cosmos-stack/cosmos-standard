using System;
using System.IO;
using System.Threading.Tasks;
using Cosmos.Serialization.Yaml.YamlDotNet;

// ReSharper disable once CheckNamespace
namespace Cosmos.Serialization.Yaml {
    /// <summary>
    /// YamlDotNet extensions
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// To stream
        /// </summary>
        /// <param name="t"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Stream ToYamlStream<T>(this T t) => YamlHelper.Pack(t);

        /// <summary>
        /// To stream
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Stream ToYamlStream(this object obj, Type type) => YamlHelper.Pack(obj, type);

        /// <summary>
        /// To stream
        /// </summary>
        /// <param name="t"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<Stream> ToYamlStreamAsync<T>(this T t) => await YamlHelper.PackAsync(t);

        /// <summary>
        /// To stream
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static async Task<Stream> ToYamlStreamAsync(this object obj, Type type) => await YamlHelper.PackAsync(obj, type);
    }
}