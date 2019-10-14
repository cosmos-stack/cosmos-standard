using System;
using Cosmos.Protobuf;

/*
 * Reference to:
 *      Mutuduxf/Zaabee.Serializers
 *          Author: Mutuduxf
 *          Url:    https://github.com/Mutuduxf/Zaabee.Serializers
 *          MIT
 */

namespace Cosmos.Extensions
{
    /// <summary>
    /// ProtoBuf extensions
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// From ProtoBuf
        /// </summary>
        /// <param name="bytes"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T FromProtoBuf<T>(this byte[] bytes)
        {
            return ProtoBufHelper.Deserialize<T>(bytes);
        }

        /// <summary>
        /// From ProtoBuf
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object FromProtoBuf(this byte[] bytes, Type type)
        {
            return ProtoBufHelper.Deserialize(bytes, type);
        }
    }
}
