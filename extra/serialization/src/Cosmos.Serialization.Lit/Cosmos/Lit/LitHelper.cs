using System;
using LitJson;

namespace Cosmos.Lit
{
    /// <summary>
    /// Lit Helper
    /// </summary>
    public static class LitHelper
    {
        /// <summary>
        /// Serialize
        /// </summary>
        /// <param name="o"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string Serialize<T>(T o)
        {
            return JsonMapper.ToJson(o);
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="json"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Deserialize<T>(string json)
        {
            return string.IsNullOrWhiteSpace(json) ? default(T) : JsonMapper.ToObject<T>(json);
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="json"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object Deserialize(string json, Type type)
        {
            return string.IsNullOrWhiteSpace(json) ? null : JsonMapper.ToObject(json, type);
        }
    }
}