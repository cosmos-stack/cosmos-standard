using System;
using System.IO;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace Cosmos.Serialization.ZeroFormatter
{
    public static partial class ZeroFormatterExtensions
    {
        /// <summary>
        /// Pack to
        /// </summary>
        /// <param name="t"></param>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        public static void PackTo<T>(this T t, Stream stream)
        {
            ZeroFormatterHelper.Pack(t, stream);
        }

        /// <summary>
        /// Pack to
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <param name="stream"></param>
        public static void PackTo(this object obj, Type type, Stream stream)
        {
            ZeroFormatterHelper.Pack(obj, type, stream);
        }

        /// <summary>
        /// Pack by
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        public static void PackBy<T>(this Stream stream, T obj)
        {
            ZeroFormatterHelper.Pack(obj, stream);
        }

        /// <summary>
        /// Pack by
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        public static void PackBy(this Stream stream, object obj, Type type)
        {
            ZeroFormatterHelper.Pack(obj, type, stream);
        }

        /// <summary>
        /// Unpack
        /// </summary>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Unpack<T>(this Stream stream)
        {
            return ZeroFormatterHelper.Unpack<T>(stream);
        }

        /// <summary>
        /// Unpack
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object Unpack(this Stream stream, Type type)
        {
            return ZeroFormatterHelper.Unpack(stream, type);
        }

        /// <summary>
        /// Pack to async
        /// </summary>
        /// <param name="t"></param>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task PackToAsync<T>(this T t, Stream stream)
        {
            await ZeroFormatterHelper.PackAsync(t, stream);
        }

        /// <summary>
        /// Pack to async
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static async Task PackToAsync(this object obj, Type type, Stream stream)
        {
            await ZeroFormatterHelper.PackAsync(obj, type, stream);
        }

        /// <summary>
        /// Pack by async
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        public static async Task PackByAsync<T>(this Stream stream, T obj)
        {
            await ZeroFormatterHelper.PackAsync(obj, stream);
        }

        /// <summary>
        /// Pack by async
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        public static async Task PackByAsync(this Stream stream, object obj, Type type)
        {
            await ZeroFormatterHelper.PackAsync(obj, type, stream);
        }

        /// <summary>
        /// Unpack async
        /// </summary>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<T> UnpackAsync<T>(this Stream stream)
        {
            return await ZeroFormatterHelper.UnpackAsync<T>(stream);
        }

        /// <summary>
        /// Unpack async
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static async Task<object> UnpackAsync(this Stream stream, Type type)
        {
            return await ZeroFormatterHelper.UnpackAsync(stream, type);
        }

    }
}