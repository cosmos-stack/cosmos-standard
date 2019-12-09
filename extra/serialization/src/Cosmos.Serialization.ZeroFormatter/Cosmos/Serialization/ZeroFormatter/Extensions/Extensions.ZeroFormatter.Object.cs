using System;
using System.IO;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace Cosmos.Serialization.ZeroFormatter {
    using Z = ZeroFormatterHelper;

    public static partial class ZeroFormatterExtensions {
        /// <summary>
        /// To ZeroFormatter
        /// </summary>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static byte[] ToZeroFormatter<T>(this T obj) => Z.Serialize(obj);

        /// <summary>
        /// o ZeroFormatter
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static byte[] ToZeroFormatter(this object obj, Type type) => Z.Serialize(obj, type);

        /// <summary>
        /// To ZeroFormatter async
        /// </summary>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<byte[]> ToZeroFormatterAsync<T>(this T obj) => Z.SerializeAsync(obj);

        /// <summary>
        /// To ZeroFormatter async
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Task<byte[]> ToZeroFormatterAsync(this object obj, Type type) => Z.SerializeAsync(obj, type);
    }
}