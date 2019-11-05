using System;
using System.IO;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace Cosmos.Serialization.ZeroFormatter
{
    using Z = ZeroFormatterHelper;

    public static partial class ZeroFormatterExtensions
    {
        /// <summary>
        /// Pack to
        /// </summary>
        /// <param name="t"></param>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        public static void PackTo<T>(this T t, Stream stream) => Z.Pack(t, stream);

        /// <summary>
        /// Pack to
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <param name="stream"></param>
        public static void PackTo(this object obj, Type type, Stream stream) => Z.Pack(obj, type, stream);

        /// <summary>
        /// Pack by
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        public static void PackBy<T>(this Stream stream, T obj) => Z.Pack(obj, stream);

        /// <summary>
        /// Pack by
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        public static void PackBy(this Stream stream, object obj, Type type) => Z.Pack(obj, type, stream);

        /// <summary>
        /// Unpack
        /// </summary>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Unpack<T>(this Stream stream) => Z.Unpack<T>(stream);

        /// <summary>
        /// Unpack
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object Unpack(this Stream stream, Type type) => Z.Unpack(stream, type);

        /// <summary>
        /// Pack to async
        /// </summary>
        /// <param name="t"></param>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task PackToAsync<T>(this T t, Stream stream) => await Z.PackAsync(t, stream);

        /// <summary>
        /// Pack to async
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static async Task PackToAsync(this object obj, Type type, Stream stream) => await Z.PackAsync(obj, type, stream);

        /// <summary>
        /// Pack by async
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        public static async Task PackByAsync<T>(this Stream stream, T obj) => await Z.PackAsync(obj, stream);

        /// <summary>
        /// Pack by async
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        public static async Task PackByAsync(this Stream stream, object obj, Type type) => await Z.PackAsync(obj, type, stream);

        /// <summary>
        /// Unpack async
        /// </summary>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<T> UnpackAsync<T>(this Stream stream) => await Z.UnpackAsync<T>(stream);

        /// <summary>
        /// Unpack async
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static async Task<object> UnpackAsync(this Stream stream, Type type) => await Z.UnpackAsync(stream, type);
    }
}