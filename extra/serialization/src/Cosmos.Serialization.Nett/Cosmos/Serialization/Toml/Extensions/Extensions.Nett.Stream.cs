using System;
using System.IO;
using System.Threading.Tasks;
using Cosmos.Serialization.Toml.Nett;

// ReSharper disable once CheckNamespace
namespace Cosmos.Serialization.Toml {
    /// <summary>
    /// Nett extensions
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// To stream
        /// </summary>
        /// <param name="t"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Stream ToTomlStream<T>(this T t) => NettHelper.Pack(t);

        /// <summary>
        /// To stream
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Stream ToTomlStream(this object obj, Type type) => NettHelper.Pack(obj, type);

        /// <summary>
        /// To stream
        /// </summary>
        /// <param name="t"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<Stream> ToTomlStreamAsync<T>(this T t) => await NettHelper.PackAsync(t);

        /// <summary>
        /// To stream
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static async Task<Stream> ToTomlStreamAsync(this object obj, Type type) => await NettHelper.PackAsync(obj, type);
    }
}