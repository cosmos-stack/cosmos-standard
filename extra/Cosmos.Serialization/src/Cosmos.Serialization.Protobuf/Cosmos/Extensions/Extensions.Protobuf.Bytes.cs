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
    public static partial class Extensions
    {
        public static T FromProtoBuf<T>(this byte[] bytes)
        {
            return ProtobufHelper.Deserialize<T>(bytes);
        }

        public static object FromProtoBuf(this byte[] bytes, Type type)
        {
            return ProtobufHelper.Deserialize(bytes, type);
        }
    }
}
