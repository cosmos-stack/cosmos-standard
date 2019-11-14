using System;
using System.IO;
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
        /// To stream
        /// </summary>
        /// <param name="t"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Stream ToMsgPackStream<T>(this T t) => MsgPackCliHelper.Pack(t);

        /// <summary>
        /// To stream
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Stream ToMsgPackStream(this object obj, Type type) => MsgPackCliHelper.Pack(obj, type);

        /// <summary>
        /// To stream
        /// </summary>
        /// <param name="t"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<Stream> ToMsgPackStreamAsync<T>(this T t) => await MsgPackCliHelper.PackAsync(t);

        /// <summary>
        /// To stream
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static async Task<Stream> ToMsgPackStreamAsync(this object obj, Type type) => await MsgPackCliHelper.PackAsync(obj, type);
    }
}