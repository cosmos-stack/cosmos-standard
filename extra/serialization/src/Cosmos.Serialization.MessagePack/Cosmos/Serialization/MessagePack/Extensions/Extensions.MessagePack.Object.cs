using System;
using System.Threading.Tasks;
using Cosmos.Serialization.MessagePack.Neuecc;

// ReSharper disable once CheckNamespace
namespace Cosmos.Serialization.MessagePack {
    using N = NeueccMsgPackHelper;

    /// <summary>
    /// MessagePack extensions
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// To neuecc's message pack
        /// </summary>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static byte[] ToMessagePack<T>(this T obj) => N.Serialize(obj);

        /// <summary>
        /// To neuecc's message pack
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static byte[] ToMessagePack(this object obj, Type type) => N.Serialize(obj, type);

        /// <summary>
        /// To neuecc's message pack async
        /// </summary>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<byte[]> ToMessagePackAsync<T>(this T obj) => N.SerializeAsync(obj);

        /// <summary>
        /// To neuecc's message pack async
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Task<byte[]> ToMessagePackAsync(this object obj, Type type) => N.SerializeAsync(obj, type);
    }
}