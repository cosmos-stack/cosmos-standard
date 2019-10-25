using System;
using System.IO;
using System.Threading.Tasks;
using Cosmos.Serialization.Json.Lit;

// ReSharper disable once CheckNamespace
namespace Cosmos.Serialization.Json
{
    /// <summary>
    /// LitJson extensions
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// Lit pack to
        /// </summary>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Stream LitPack<T>(this T obj)
        {
            return LitHelper.Pack(obj);
        }

        /// <summary>
        /// Lit pack to
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        public static void LitPackTo<T>(this T obj, Stream stream)
        {
            LitHelper.Pack(obj, stream);
        }

        /// <summary>
        /// Lit pack by
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="obj"></param>
        public static void LitPackBy(this Stream stream, object obj)
        {
            LitHelper.Pack(obj, stream);
        }

        /// <summary>
        /// Lit pack to
        /// </summary>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<Stream> LitPackAsync<T>(this T obj)
        {
            return LitHelper.PackAsync(obj);
        }

        /// <summary>
        /// Lit pack to
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        public static Task LitPackToAsync<T>(this T obj, Stream stream)
        {
            return LitHelper.PackAsync(obj, stream);
        }

        /// <summary>
        /// Lit pack by async
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="obj"></param>
        public static Task LitPackByAsync(this Stream stream, object obj)
        {
            return LitHelper.PackAsync(obj, stream);
        }

        /// <summary>
        /// Lit unpack
        /// </summary>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T LitUnpack<T>(this Stream stream)
        {
            return LitHelper.Unpack<T>(stream);
        }

        /// <summary>
        /// Lit unpack
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object LitUnpack(this Stream stream, Type type)
        {
            return LitHelper.Unpack(stream, type);
        }

        /// <summary>
        /// Lit unpack async
        /// </summary>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<T> LitUnpackAsync<T>(this Stream stream)
        {
            return await LitHelper.UnpackAsync<T>(stream);
        }

        /// <summary>
        /// Lit unpack async
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static async Task<object> LitUnpackAsync(this Stream stream, Type type)
        {
            return await LitHelper.UnpackAsync(stream, type);
        }
    }
}