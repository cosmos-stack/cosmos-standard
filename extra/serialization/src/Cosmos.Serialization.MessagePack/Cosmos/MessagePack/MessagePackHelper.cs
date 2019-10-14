using System;
using MessagePack;

namespace Cosmos.MessagePack
{
    /// <summary>
    /// MessagePack helper
    /// </summary>
    public static class MessagePackHelper
    {
        /// <summary>
        /// Serialize
        /// </summary>
        /// <param name="o"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static byte[] Serialize<T>(T o)
        {
            return MessagePackSerializer.Serialize(o);
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="bytes"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Deserialize<T>(byte[] bytes)
        {
            return MessagePackSerializer.Deserialize<T>(bytes);
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object Deserialize(byte[] bytes, Type type)
        {
            return MessagePackSerializer.NonGeneric.Deserialize(type, bytes);
        }

        /// <summary>
        /// Json bytes to string
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static string JsonBytesToString(byte[] json)
        {
            return MessagePackSerializer.ToJson(json);
        }

        /// <summary>
        /// Json string to bytes
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static byte[] JsonStringToBytes(string json)
        {
            return MessagePackSerializer.FromJson(json);
        }

        /// <summary>
        /// Json Object to string
        /// </summary>
        /// <param name="o"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string JsonObjectToString<T>(T o)
        {
            return MessagePackSerializer.ToJson(o);
        }

        /// <summary>
        /// Json object to bytes
        /// </summary>
        /// <param name="o"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static byte[] JsonObjectToBytes<T>(T o)
        {
            return JsonStringToBytes(JsonObjectToString(o));
        }

        /// <summary>
        /// Json string to object
        /// </summary>
        /// <param name="json"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T JsonStringToObject<T>(string json)
        {
            return Deserialize<T>(JsonStringToBytes(json));
        }
    }
}