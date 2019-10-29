using System;
using System.IO;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace Cosmos.Serialization.ZeroFormatter
{
    public static partial class ZeroFormatterExtensions
    {
        /// <summary>
        /// To ZeroFormatter
        /// </summary>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static byte[] ToZeroFormatter<T>(this T obj)
        {
            return ZeroFormatterHelper.Serialize(obj);
        }

        /// <summary>
        /// o ZeroFormatter
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static byte[] ToZeroFormatter(this object obj, Type type)
        {
            return ZeroFormatterHelper.Serialize(obj, type);
        }

        /// <summary>
        /// To ZeroFormatter async
        /// </summary>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<byte[]> ToZeroFormatterAsync<T>(this T obj)
        {
            return ZeroFormatterHelper.SerializeAsync(obj);
        }

        /// <summary>
        /// To ZeroFormatter async
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Task<byte[]> ToZeroFormatterAsync(this object obj, Type type)
        {
            return ZeroFormatterHelper.SerializeAsync(obj, type);
        }    
    }
}