using Cosmos.MessagePack;

namespace Cosmos.Extensions
{
    public static partial class Extensions
    {
        public static T FromMessagePack<T>(this byte[] bytes)
        {
            return MessagePackHelper.Deserialize<T>(bytes);
        }
    }
}
