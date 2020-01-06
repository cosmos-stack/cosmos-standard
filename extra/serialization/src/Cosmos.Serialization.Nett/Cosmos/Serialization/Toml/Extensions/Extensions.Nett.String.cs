using System;
using System.Threading.Tasks;
using Cosmos.Serialization.Toml.Nett;

// ReSharper disable once CheckNamespace
namespace Cosmos.Serialization.Toml {
    /// <summary>
    /// Nett extensions
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// From Toml
        /// </summary>
        /// <param name="str"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T FromToml<T>(this string str) => NettHelper.Deserialize<T>(str);

        /// <summary>
        /// From Toml
        /// </summary>
        /// <param name="str"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object FromToml(this string str, Type type) => NettHelper.Deserialize(str, type);

        /// <summary>
        /// From Toml async
        /// </summary>
        /// <param name="str"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<T> FromTomlAsync<T>(this string str) => NettHelper.DeserializeAsync<T>(str);

        /// <summary>
        /// From Toml async
        /// </summary>
        /// <param name="str"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Task<object> FromTomlAsync(this string str, Type type) => NettHelper.DeserializeAsync(str, type);
    }
}