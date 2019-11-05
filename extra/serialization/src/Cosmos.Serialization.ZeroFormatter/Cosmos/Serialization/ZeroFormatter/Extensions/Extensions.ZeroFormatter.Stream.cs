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
        /// To stream
        /// </summary>
        /// <param name="t"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Stream ToStream<T>(this T t) => Z.Pack(t);

        /// <summary>
        /// To stream
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Stream ToStream(this object obj, Type type) => Z.Pack(obj, type);


        /// <summary>
        /// To stream async
        /// </summary>
        /// <param name="t"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<Stream> ToStreamAsync<T>(this T t) => await Z.PackAsync(t);

        /// <summary>
        /// To stream async
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static async Task<Stream> ToStreamAsync(this object obj, Type type) => await Z.PackAsync(type, obj);
    }
}