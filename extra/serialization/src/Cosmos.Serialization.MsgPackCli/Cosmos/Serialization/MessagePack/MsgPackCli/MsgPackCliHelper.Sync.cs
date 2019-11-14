using System;
using System.IO;

namespace Cosmos.Serialization.MessagePack.MsgPackCli
{
    /// <summary>
    /// MessagePack-Cli helper
    /// </summary>
    public static partial class MsgPackCliHelper
    {
        /// <summary>
        /// Serialize
        /// </summary>
        /// <param name="t"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static byte[] Serialize<T>(T t)
        {
            if (t == null)
                return new byte[0];

            using var stream = Pack(t);
            return StreamToBytes(stream);
        }

        /// <summary>
        /// Serialize
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static byte[] Serialize(object obj, Type type)
        {
            if (obj is null)
                return new byte[0];

            using var stream = Pack(obj, type);
            return StreamToBytes(stream);
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="data"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Deserialize<T>(byte[] data)
        {
            if (data is null || data.Length == 0)
                return default;

            using var ms = new MemoryStream(data);
            return Unpack<T>(ms);
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object Deserialize(byte[] data, Type type)
        {
            if (data is null || data.Length == 0)
                return null;

            using var ms = new MemoryStream(data);
            return Unpack(ms, type);
        }
    }
}