using Cosmos.MessagePack;

namespace Cosmos.Extensions
{
    /// <summary>
    /// MessagePack extensions
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// To MessagePack
        /// </summary>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static byte[] ToMessagePack<T>(this T obj)
        {
            return MessagePackHelper.Serialize(obj);
        }
    }
}
