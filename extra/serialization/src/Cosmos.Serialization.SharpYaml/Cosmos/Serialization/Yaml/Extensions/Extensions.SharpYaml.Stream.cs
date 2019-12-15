using System;
using System.IO;
using System.Threading.Tasks;
using Cosmos.Serialization.Yaml.SharpYaml;

// ReSharper disable once CheckNamespace
namespace Cosmos.Serialization.Yaml {

    /// <summary>
    /// SharpYaml extensions
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// To stream
        /// </summary>
        /// <param name="t"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Stream ToSharpYamlStream<T>(this T t) => SharpYamlHelper.Pack(t);

        /// <summary>
        /// To stream
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Stream ToSharpYamlStream(this object obj, Type type) => SharpYamlHelper.Pack(obj, type);

        /// <summary>
        /// To stream
        /// </summary>
        /// <param name="t"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<Stream> ToSharpYamlStreamAsync<T>(this T t) => await SharpYamlHelper.PackAsync(t);

        /// <summary>
        /// To stream
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static async Task<Stream> ToSharpYamlStreamAsync(this object obj, Type type) => await SharpYamlHelper.PackAsync(obj, type);
    }
}