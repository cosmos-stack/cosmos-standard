using System;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace Cosmos.Serialization.ZeroFormatter {
    using Z = ZeroFormatterHelper;

    /// <summary>
    /// ZeroFormatter extensions
    /// </summary>
    public static partial class ZeroFormatterExtensions {
        /// <summary>
        /// From ZeroFormatter 
        /// </summary>
        /// <param name="data"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T FromZeroFormatter<T>(this byte[] data) => Z.Deserialize<T>(data);

        /// <summary>
        /// From ZeroFormatter 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object FromZeroFormatter(this byte[] data, Type type) => Z.Deserialize(data, type);

        /// <summary>
        /// From ZeroFormatter async
        /// </summary>
        /// <param name="data"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<T> FromZeroFormatterAsync<T>(this byte[] data) => Z.DeserializeAsync<T>(data);

        /// <summary>
        /// From ZeroFormatter async
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Task<object> FromZeroFormatterAsync(this byte[] data, Type type) => Z.DeserializeAsync(data, type);
    }
}