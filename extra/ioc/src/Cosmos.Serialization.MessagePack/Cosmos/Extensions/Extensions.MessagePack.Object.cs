using Cosmos.MessagePack;

namespace Cosmos.Extensions
{
    public static partial class Extensions
    {
        public static byte[] ToMessagePack<T>(this T obj)
        {
            return MessagePackHelper.Serialize(obj);
        }
    }
}
