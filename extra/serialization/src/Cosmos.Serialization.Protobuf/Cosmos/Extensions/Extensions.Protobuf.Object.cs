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
        /// To ProtoBuf
        /// </summary>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static byte[] ToProtoBuf<T>(this T obj)
        {
            return ProtoBufHelper.Serialize(obj);
        }

        /// <summary>
        /// To ProtoBuf
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static byte[] ToProtoBuf(this object obj, Type type)
        {
            return ProtoBufHelper.Serialize(obj, type);
        }
    }
}