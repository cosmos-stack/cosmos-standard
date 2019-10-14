using Cosmos.MessagePack;

namespace Cosmos.Extensions
{
    /// <summary>
    /// MessagePack extensions
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// From MessagePack
        /// </summary>
        /// <param name="bytes"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T FromMessagePack<T>(this byte[] bytes)
        {
            return MessagePackHelper.Deserialize<T>(bytes);
        }
    }
}