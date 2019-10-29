using System;
using System.Threading.Tasks;
using Cosmos.Serialization.MessagePack.MsgPackCli;

// ReSharper disable once CheckNamespace
namespace Cosmos.Serialization.MessagePack
{
    /// <summary>
    /// MessagePack extensions
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// From message pack
        /// </summary>
        /// <param name="data"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T FromMsgPack<T>(this byte[] data)
        {
            return MsgPackCliHelper.Deserialize<T>(data);
        }

        /// <summary>
        /// From message pack
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object FromMsgPack(this byte[] data, Type type)
        {
            return MsgPackCliHelper.Deserialize(data, type);
        }

        /// <summary>
        /// From message pack async
        /// </summary>
        /// <param name="data"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<T> FromMsgPackAsync<T>(this byte[] data)
        {
            return MsgPackCliHelper.DeserializeAsync<T>(data);
        }

        /// <summary>
        /// From message pack async
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Task<object> FromMsgPackAsync(this byte[] data, Type type)
        {
            return MsgPackCliHelper.DeserializeAsync(data, type);
        }
    }
}