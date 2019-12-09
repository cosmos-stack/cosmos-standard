using System;
using System.IO;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace Cosmos.Serialization.Binary {
    /// <summary>
    /// Binary extensions
    /// </summary>
    public static partial class BinaryExtensions {
        /// <summary>
        /// Pack by
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        public static void PackBy<T>(this Stream stream, T obj) => BinaryHelper.Pack(obj, stream);

        /// <summary>
        /// Unpack
        /// </summary>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Unpack<T>(this Stream stream) => BinaryHelper.Unpack<T>(stream);

        /// <summary>
        /// Unpack
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object Unpack(this Stream stream, Type type) => BinaryHelper.Unpack(stream);

        /// <summary>
        /// Pack by async
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        public static Task PackByAsync<T>(this Stream stream, T obj) => BinaryHelper.PackAsync(obj, stream);

        /// <summary>
        /// Unpack async
        /// </summary>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<T> UnpackAsync<T>(this Stream stream) => BinaryHelper.UnpackAsync<T>(stream);

        /// <summary>
        /// Unpack async
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Task<object> UnpackAsync(this Stream stream, Type type) => BinaryHelper.UnpackAsync(stream);
    }
}