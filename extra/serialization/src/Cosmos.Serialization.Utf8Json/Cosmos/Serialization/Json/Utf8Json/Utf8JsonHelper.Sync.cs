using System;
using Utf8Json;

namespace Cosmos.Serialization.Json.Utf8Json
{
    /// <summary>
    /// Utf8Json helper
    /// </summary>
    public static partial class Utf8JsonHelper
    {
        /// <summary>
        /// Serialize
        /// </summary>
        /// <param name="o"></param>
        /// <param name="resolver"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string Serialize<T>(T o, IJsonFormatterResolver resolver = null)
        {
            return o is null
                ? string.Empty
                : JsonSerializer.ToJsonString(o, resolver);
        }

        /// <summary>
        /// Serialize
        /// </summary>
        /// <param name="o"></param>
        /// <param name="resolver"></param>
        /// <returns></returns>
        public static string Serialize(object o, IJsonFormatterResolver resolver = null)
        {
            return o is null
                ? string.Empty
                : JsonSerializer.NonGeneric.ToJsonString(o, resolver);
        }

        /// <summary>
        /// Serialize
        /// </summary>
        /// <param name="o"></param>
        /// <param name="type"></param>
        /// <param name="resolver"></param>
        /// <returns></returns>
        public static string Serialize(object o, Type type, IJsonFormatterResolver resolver = null)
        {
            return o is null
                ? string.Empty
                : JsonSerializer.NonGeneric.ToJsonString(type, o, resolver);
        }

        /// <summary>
        /// Serialize to bytes
        /// </summary>
        /// <param name="o"></param>
        /// <param name="resolver"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static byte[] SerializeToBytes<T>(T o, IJsonFormatterResolver resolver = null)
        {
            return o is null
                ? new byte[0]
                : JsonSerializer.Serialize(o, resolver);
        }

        /// <summary>
        /// Serialize to bytes
        /// </summary>
        /// <param name="o"></param>
        /// <param name="resolver"></param>
        /// <returns></returns>
        public static byte[] SerializeToBytes(object o, IJsonFormatterResolver resolver = null)
        {
            return o is null
                ? new byte[0]
                : JsonSerializer.NonGeneric.Serialize(o, resolver);
        }

        /// <summary>
        /// Serialize to bytes
        /// </summary>
        /// <param name="o"></param>
        /// <param name="type"></param>
        /// <param name="resolver"></param>
        /// <returns></returns>
        public static byte[] SerializeToBytes(object o, Type type, IJsonFormatterResolver resolver = null)
        {
            return o is null
                ? new byte[0]
                : JsonSerializer.NonGeneric.Serialize(type, o, resolver);
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="json"></param>
        /// <param name="resolver"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Deserialize<T>(string json, IJsonFormatterResolver resolver = null)
        {
            return string.IsNullOrWhiteSpace(json)
                ? default
                : JsonSerializer.Deserialize<T>(json, resolver);
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="json"></param>
        /// <param name="type"></param>
        /// <param name="resolver"></param>
        /// <returns></returns>
        public static object Deserialize(string json, Type type, IJsonFormatterResolver resolver = null)
        {
            return string.IsNullOrWhiteSpace(json)
                ? null
                : JsonSerializer.NonGeneric.Deserialize(type, json, resolver);
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="data"></param>
        /// <param name="resolver"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T DeserializeFromBytes<T>(byte[] data, IJsonFormatterResolver resolver = null)
        {
            return data is null || data.Length is 0
                ? default
                : JsonSerializer.Deserialize<T>(data, resolver);
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <param name="resolver"></param>
        /// <returns></returns>
        public static object DeserializeFromBytes(byte[] data, Type type, IJsonFormatterResolver resolver = null)
        {
            if (data is null || data.Length is 0)
                return null;

            var reader = new JsonReader(data, 0);

            return JsonSerializer.NonGeneric.Deserialize(type, ref reader, resolver);
        }
    }
}