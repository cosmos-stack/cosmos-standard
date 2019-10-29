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
        /// From neuecc's message pack
        /// </summary>
        /// <param name="data"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T FromMessagePack<T>(this byte[] data)
        {
            return NeueccMsgPackHelper.Deserialize<T>(data);
        }

        /// <summary>
        /// From neuecc's message pack
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object FromMessagePack(this byte[] data, Type type)
        {
            return NeueccMsgPackHelper.Deserialize(data, type);
        }

        /// <summary>
        /// From neuecc's message pack async
        /// </summary>
        /// <param name="data"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<T> FromMessagePackAsync<T>(this byte[] data)
        {
            return NeueccMsgPackHelper.DeserializeAsync<T>(data);
        }

        /// <summary>
        /// From neuecc's message pack async
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Task<object> FromMessagePackAsync(this byte[] data, Type type)
        {
            return NeueccMsgPackHelper.DeserializeAsync(data, type);
        }
    }
}