using System;
using System.Threading.Tasks;
using Cosmos.Serialization.MessagePack.Neuecc;

// ReSharper disable once CheckNamespace
namespace Cosmos.Serialization.MessagePack
{
    /// <summary>
    /// MessagePack extensions
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// To neuecc's message pack
        /// </summary>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static byte[] ToMessagePack<T>(this T obj)
        {
            return NeueccMsgPackHelper.Serialize(obj);
        }

        /// <summary>
        /// To neuecc's message pack
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static byte[] ToMessagePack(this object obj, Type type)
        {
            return NeueccMsgPackHelper.Serialize(obj, type);
        }

        /// <summary>
        /// To neuecc's message pack async
        /// </summary>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<byte[]> ToMessagePackAsync<T>(this T obj)
        {
            return NeueccMsgPackHelper.SerializeAsync(obj);
        }

        /// <summary>
        /// To neuecc's message pack async
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Task<byte[]> ToMessagePackAsync(this object obj, Type type)
        {
            return NeueccMsgPackHelper.SerializeAsync(obj, type);
        }
    }
}
