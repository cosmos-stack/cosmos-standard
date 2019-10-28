using System;
using System.Threading.Tasks;

/*
 * Reference to:
 *      Mutuduxf/Zaabee.Serializers
 *          Author: Mutuduxf
 *          Url:    https://github.com/Mutuduxf/Zaabee.Serializers
 *          MIT
 */

// ReSharper disable once CheckNamespace
namespace Cosmos.Serialization.ProtoBuf
{
    /// <summary>
    /// ProtoBuf extensions
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// From ProtoBuf
        /// </summary>
        /// <param name="data"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T FromProtoBytes<T>(this byte[] data)
        {
            return ProtobufHelper.Deserialize<T>(data);
        }

        /// <summary>
        /// From ProtoBuf
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object FromProtoBytes(this byte[] data, Type type)
        {
            return ProtobufHelper.Deserialize(data, type);
        }

        /// <summary>
        /// From ProtoBuf async
        /// </summary>
        /// <param name="data"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<T> FromProtoBytesAsync<T>(this byte[] data)
        {
            return ProtobufHelper.DeserializeAsync<T>(data);
        }

        /// <summary>
        /// From ProtoBuf async
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Task<object> FromProtoBytesAsync(this byte[] data, Type type)
        {
            return ProtobufHelper.DeserializeAsync(data, type);
        }
    }
}