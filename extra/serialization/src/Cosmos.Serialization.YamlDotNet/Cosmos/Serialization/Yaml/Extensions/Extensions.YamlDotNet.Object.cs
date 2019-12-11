using System.Threading.Tasks;
using Cosmos.Serialization.Yaml.YamlDotNet;

// ReSharper disable once CheckNamespace
namespace Cosmos.Serialization.Yaml {
    /// <summary>
    /// YamlDotNet extensions
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// To Yaml
        /// </summary>
        /// <param name="o"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string ToYaml<T>(this T o) => YamlHelper.Serialize(o);

        /// <summary>
        /// To Yaml async
        /// </summary>
        /// <param name="o"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<string> ToYamlAsync<T>(this T o) => YamlHelper.SerializeAsync(o);
    }
}