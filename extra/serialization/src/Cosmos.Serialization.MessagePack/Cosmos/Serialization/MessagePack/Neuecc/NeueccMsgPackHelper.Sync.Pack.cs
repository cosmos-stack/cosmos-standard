using System;
using System.IO;
using MessagePack;

namespace Cosmos.Serialization.MessagePack.Neuecc
{
    /// <summary>
    /// Neuecc's MessagePack helper
    /// </summary>
    public static partial class NeueccMsgPackHelper
    {
        /// <summary>
        /// Pack
        /// </summary>
        /// <param name="t"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Stream Pack<T>(T t)
        {
            var ms = new MemoryStream();

            if (t == null)
                return ms;

            Pack(t, ms);

            ms.Seek(0, SeekOrigin.Begin);

            return ms;
        }

        /// <summary>
        /// Pack
        /// </summary>
        /// <param name="t"></param>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        public static void Pack<T>(T t, Stream stream)
        {
            if (t == null)
                return;

            MessagePackSerializer.Serialize(stream, t);
        }

        /// <summary>
        /// Pack
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Stream Pack(object obj, Type type)
        {
            var ms = new MemoryStream();

            if (obj is null)
                return ms;

            Pack(obj, type, ms);

            ms.Seek(0, SeekOrigin.Begin);

            return ms;
        }

        /// <summary>
        /// Pack
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <param name="stream"></param>
        public static void Pack(object obj, Type type, Stream stream)
        {
            if (obj is null)
                return;

            MessagePackSerializer.NonGeneric.Serialize(type, stream, obj);
        }

        /// <summary>
        /// Unpack
        /// </summary>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Unpack<T>(Stream stream)
        {
            if (stream is null)
                return default;

            if (stream.CanSeek && stream.Position > 0)
                stream.Position = 0;

            return MessagePackSerializer.Deserialize<T>(stream);
        }

        /// <summary>
        /// Unpack
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object Unpack(Stream stream, Type type)
        {
            if (stream is null)
                return null;

            if (stream.CanSeek && stream.Position > 0)
                stream.Position = 0;

            return MessagePackSerializer.NonGeneric.Deserialize(type, stream);
        }
    }
}