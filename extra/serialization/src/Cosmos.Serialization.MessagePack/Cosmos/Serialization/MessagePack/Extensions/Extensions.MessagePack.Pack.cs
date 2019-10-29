using System;
using System.IO;
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
        /// Pack to
        /// </summary>
        /// <param name="t"></param>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        public static void NeueccPackTo<T>(this T t, Stream stream)
        {
            NeueccMsgPackHelper.Pack(t, stream);
        }

        /// <summary>
        /// Pack to
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <param name="stream"></param>
        public static void NeueccPackTo(this object obj, Type type, Stream stream)
        {
            NeueccMsgPackHelper.Pack(obj, type, stream);
        }

        /// <summary>
        /// Pack by
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="t"></param>
        /// <typeparam name="T"></typeparam>
        public static void NeueccPackBy<T>(this Stream stream, T t)
        {
            NeueccMsgPackHelper.Pack(t, stream);
        }

        /// <summary>
        /// Pack by
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        public static void NeueccPackBy(this Stream stream, object obj, Type type)
        {
            NeueccMsgPackHelper.Pack(obj, type, stream);
        }

        /// <summary>
        /// Pack to async
        /// </summary>
        /// <param name="t"></param>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task NeueccPackToAsync<T>(this T t, Stream stream)
        {
            await NeueccMsgPackHelper.PackAsync(t, stream);
        }

        /// <summary>
        /// Pack to async
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static async Task NeueccPackToAsync(this object obj, Type type, Stream stream)
        {
            await NeueccMsgPackHelper.PackAsync(obj, type, stream);
        }

        /// <summary>
        /// Pack by
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="t"></param>
        /// <typeparam name="T"></typeparam>
        public static async Task NeueccPackByAsync<T>(this Stream stream, T t)
        {
            await NeueccMsgPackHelper.PackAsync(t, stream);
        }

        /// <summary>
        /// Pack by
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        public static async Task NeueccPackByAsync(this Stream stream, object obj, Type type)
        {
            await NeueccMsgPackHelper.PackAsync(obj, type, stream);
        }

        /// <summary>
        /// Unpack
        /// </summary>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T NeueccUnpack<T>(this Stream stream)
        {
            return NeueccMsgPackHelper.Unpack<T>(stream);
        }

        /// <summary>
        /// Unpack
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object NeueccUnpack(this Stream stream, Type type)
        {
            return NeueccMsgPackHelper.Unpack(stream, type);
        }

        /// <summary>
        /// Unpack async
        /// </summary>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<T> NeueccUnpackAsync<T>(this Stream stream)
        {
            return NeueccMsgPackHelper.UnpackAsync<T>(stream);
        }

        /// <summary>
        /// Unpack async
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Task<object> NeueccUnpackAsync(this Stream stream, Type type)
        {
            return NeueccMsgPackHelper.UnpackAsync(stream, type);
        }
    }
}