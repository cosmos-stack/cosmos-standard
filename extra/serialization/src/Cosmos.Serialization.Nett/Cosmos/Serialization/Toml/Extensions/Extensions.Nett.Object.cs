using System.Threading.Tasks;
using Cosmos.Serialization.Toml.Nett;

// ReSharper disable once CheckNamespace
namespace Cosmos.Serialization.Toml {
    /// <summary>
    /// TomlDotNet extensions
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// To Toml
        /// </summary>
        /// <param name="o"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string ToToml<T>(this T o) => NettHelper.Serialize(o);

        /// <summary>
        /// To Toml async
        /// </summary>
        /// <param name="o"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<string> ToTomlAsync<T>(this T o) => NettHelper.SerializeAsync(o);
    }
}