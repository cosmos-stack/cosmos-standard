using System;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace Cosmos.Serialization.Binary
{
    /// <summary>
    /// Binary extensions
    /// </summary>
    public static partial class BinaryExtensions
    {
        /// <summary>
        /// From bytes
        /// </summary>
        /// <param name="bytes"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T FromBytes<T>(this byte[] bytes) => BinaryHelper.Deserialize<T>(bytes);

        /// <summary>
        /// From bytes
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object FromBytes(this byte[] bytes, Type type) => BinaryHelper.Deserialize(bytes);

        /// <summary>
        /// From bytes async
        /// </summary>
        /// <param name="bytes"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<T> FromBytesAsync<T>(this byte[] bytes) => BinaryHelper.DeserializeAsync<T>(bytes);

        /// <summary>
        /// From bytes async
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Task<object> FromBytesAsync(this byte[] bytes, Type type) => BinaryHelper.DeserializeAsync(bytes);
    }
}