using System;
using System.IO;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace Cosmos.Serialization.ProtoBuf
{
    /// <summary>
    /// ProtoBuf extensions
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// ProtoBuf Pack to
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="stream"></param>
        public static void ProtoPackTo(this object obj, Stream stream)
        {
            ProtobufHelper.Pack(obj, stream);
        }

        /// <summary>
        /// ProtoBuf Pack by
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        public static void ProtoPackBy<T>(this Stream stream, T obj)
        {
            ProtobufHelper.Pack(obj, stream);
        }

        /// <summary>
        /// ProtoBuf unpack
        /// </summary>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T ProtoUnpack<T>(this Stream stream)
        {
            return ProtobufHelper.Unpack<T>(stream);
        }

        /// <summary>
        /// ProtoBuf unpack
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object ProtoUnpack(this Stream stream, Type type)
        {
            return ProtobufHelper.Unpack(stream, type);
        }

        /// <summary>
        /// ProtoBuf Pack to async
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="stream"></param>
        public static async Task ProtoPackToAsync(this object obj, Stream stream)
        {
            await ProtobufHelper.PackAsync(obj, stream);
        }

        /// <summary>
        /// ProtoBuf Pack by async
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task ProtoPackByAsync<T>(this Stream stream, T obj)
        {
            await ProtobufHelper.PackAsync(obj, stream);
        }

        /// <summary>
        /// ProtoBuf unpack async
        /// </summary>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<T> ProtoUnpackAsync<T>(this Stream stream)
        {
            return await ProtobufHelper.UnpackAsync<T>(stream);
        }

        /// <summary>
        /// ProtoBuf unpack async
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static async Task<object> ProtoUnpackAsync(this Stream stream, Type type)
        {
            return await ProtobufHelper.UnpackAsync(stream, type);
        }
    }
}