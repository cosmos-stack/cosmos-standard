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
        /// To message pack
        /// </summary>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static byte[] ToMsgPack<T>(this T obj) => MsgPackCliHelper.Serialize(obj);

        /// <summary>
        /// To message pack
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static byte[] ToMsgPack(this object obj, Type type) => MsgPackCliHelper.Serialize(obj, type);

        /// <summary>
        /// To message pack async
        /// </summary>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<byte[]> ToMsgPackAsync<T>(this T obj) => MsgPackCliHelper.SerializeAsync(obj);

        /// <summary>
        /// To message pack async
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Task<byte[]> ToMsgPackAsync(this object obj, Type type) => MsgPackCliHelper.SerializeAsync(obj, type);
    }
}