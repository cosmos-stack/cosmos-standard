using System.Threading.Tasks;
using Cosmos.Serialization.Yaml.SharpYaml;

// ReSharper disable once CheckNamespace
namespace Cosmos.Serialization.Yaml {

    /// <summary>
    /// SharpYaml extensions
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// To Yaml
        /// </summary>
        /// <param name="o"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string ToSharpYaml<T>(this T o) => SharpYamlHelper.Serialize(o);

        /// <summary>
        /// To Yaml async
        /// </summary>
        /// <param name="o"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<string> ToSharpYamlAsync<T>(this T o) => SharpYamlHelper.SerializeAsync(o);
    }
}