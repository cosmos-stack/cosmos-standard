using System;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace Cosmos.Serialization.ZeroFormatter
{
    /// <summary>
    /// ZeroFormatter extensions
    /// </summary>
    public static partial class ZeroFormatterExtensions
    {
        /// <summary>
        /// From ZeroFormatter 
        /// </summary>
        /// <param name="data"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T FromZeroFormatter<T>(this byte[] data)
        {
            return ZeroFormatterHelper.Deserialize<T>(data);
        }

        /// <summary>
        /// From ZeroFormatter 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object FromZeroFormatter(this byte[] data, Type type)
        {
            return ZeroFormatterHelper.Deserialize(data, type);
        }

        /// <summary>
        /// From ZeroFormatter async
        /// </summary>
        /// <param name="data"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<T> FromZeroFormatterAsync<T>(this byte[] data)
        {
            return ZeroFormatterHelper.DeserializeAsync<T>(data);
        }

        /// <summary>
        /// From ZeroFormatter async
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Task<object> FromZeroFormatterAsync(this byte[] data, Type type)
        {
            return ZeroFormatterHelper.DeserializeAsync(data, type);
        }
    }
}