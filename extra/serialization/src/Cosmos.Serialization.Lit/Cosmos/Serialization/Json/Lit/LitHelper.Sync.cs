using System;
using LitJson;

namespace Cosmos.Serialization.Json.Lit
{
    /// <summary>
    /// Lit Helper
    /// </summary>
    public static partial class LitHelper
    {
        /// <summary>
        /// Serialize
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string Serialize(object o)
        {
            return o is null
                ? string.Empty
                : JsonMapper.ToJson(o);
        }

        /// <summary>
        /// Serialize to bytes
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static byte[] SerializeToBytes(object o)
        {
            return o is null
                ? new byte[0]
                : LitManager.DefaultEncoding.GetBytes(Serialize(o));
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="json"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Deserialize<T>(string json)
        {
            return string.IsNullOrWhiteSpace(json) 
                ? default 
                : JsonMapper.ToObject<T>(json);
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="json"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object Deserialize(string json, Type type)
        {
            return string.IsNullOrWhiteSpace(json)
                ? null 
                : JsonMapper.ToObject(json, type);
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="data"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T DeserializeFromBytes<T>(byte[] data)
        {
            return data is null || data.Length is 0
                ? default
                : Deserialize<T>(LitManager.DefaultEncoding.GetString(data));
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object DeserializeFromBytes(byte[] data, Type type)
        {
            return data is null || data.Length is 0
                ? null
                : Deserialize(LitManager.DefaultEncoding.GetString(data), type);
        }
    }
}