using System;
using System.IO;

namespace Cosmos.Serialization.ProtoBuf
{
    /// <summary>
    /// Google protobuf helper
    /// </summary>
    public static partial class ProtobufHelper
    {
        /// <summary>
        /// Serialize
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static byte[] Serialize(object obj)
        {
            if (obj is null)
                return new byte[0];

            using var stream = Pack(obj);
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

            return (T) Deserialize(data, typeof(T));
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
                return default;

            using var ms = new MemoryStream(data);
            return Unpack(ms, type);
        }
    }
}