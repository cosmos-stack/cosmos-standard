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
        public static byte[] ToProtoBuf<T>(this T obj)
        {
            return ProtobufHelper.Serialize(obj);
        }
    }
}
