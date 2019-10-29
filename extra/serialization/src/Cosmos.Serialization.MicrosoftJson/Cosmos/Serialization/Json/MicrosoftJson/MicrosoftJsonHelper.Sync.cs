using System;
using System.Text.Json;

namespace Cosmos.Serialization.Json.MicrosoftJson
{
    /// <summary>
    /// Microsoft System.Text.Json helper
    /// </summary>
    public static partial class MicrosoftJsonHelper
    {
        /// <summary>
        /// Serialize
        /// </summary>
        /// <param name="o"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static string Serialize(object o, JsonSerializerOptions options = null)
        {
            return o is null
                ? string.Empty
                : JsonSerializer.Serialize(o, options ?? MicrosoftJsonManager.DefaultOptions);
        }

        /// <summary>
        /// Serialize to bytes
        /// </summary>
        /// <param name="o"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static byte[] SerializeToBytes(object o, JsonSerializerOptions options = null)
        {
            return o is null
                ? new byte[0]
                : JsonSerializer.SerializeToUtf8Bytes(o, options ?? MicrosoftJsonManager.DefaultOptions);
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="json"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Deserialize<T>(string json, JsonSerializerOptions options = null)
        {
            return string.IsNullOrWhiteSpace(json)
                ? default
                : JsonSerializer.Deserialize<T>(json, options ?? MicrosoftJsonManager.DefaultOptions);
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="json"></param>
        /// <param name="type"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static object Deserialize(string json, Type type, JsonSerializerOptions options = null)
        {
            return string.IsNullOrWhiteSpace(json)
                ? null
                : JsonSerializer.Deserialize(json, type, options ?? MicrosoftJsonManager.DefaultOptions);
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="data"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T DeserializeFromBytes<T>(byte[] data, JsonSerializerOptions options = null)
        {
            return data is null || data.Length is 0
                ? default
                : JsonSerializer.Deserialize<T>(data, options);
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static object DeserializeFromBytes(byte[] data, Type type, JsonSerializerOptions options = null)
        {
            return data is null || data.Length is 0
                ? null
                : JsonSerializer.Deserialize(data, type, options);
        }
    }
}