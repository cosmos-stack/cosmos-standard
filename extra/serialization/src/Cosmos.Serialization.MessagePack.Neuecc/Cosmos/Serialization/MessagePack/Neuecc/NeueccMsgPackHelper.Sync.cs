using System;
using MessagePack;

namespace Cosmos.Serialization.MessagePack.Neuecc
{
    /// <summary>
    /// Neuecc's MessagePack helper
    /// </summary>
    public static partial class NeueccMsgPackHelper
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

            return MessagePackSerializer.Serialize(t);
        }

        /// <summary>
        /// Serialize
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static byte[] Serialize(object obj, Type type)
        {
            if(obj is null)
                return new byte[0];

            return MessagePackSerializer.NonGeneric.Serialize(type, obj);
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

            return MessagePackSerializer.Deserialize<T>(data);
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

            return MessagePackSerializer.NonGeneric.Deserialize(type, data);
        }
    }
}