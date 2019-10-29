using System;
using System.Threading.Tasks;
using Utf8Json;

namespace Cosmos.Serialization.Json.Utf8Json
{
    /// <summary>
    /// Utf8Json helper
    /// </summary>
    public static partial class Utf8JsonHelper
    {
        /// <summary>
        /// Serialize async
        /// </summary>
        /// <param name="o"></param>
        /// <param name="resolver"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<string> SerializeAsync<T>(T o, IJsonFormatterResolver resolver = null)
        {
            return o is null
                ? string.Empty
                : await Task.Run(() => JsonSerializer.ToJsonString(o, resolver));
        }

        /// <summary>
        /// Serialize async
        /// </summary>
        /// <param name="o"></param>
        /// <param name="resolver"></param>
        /// <returns></returns>
        public static async Task<string> SerializeAsync(object o, IJsonFormatterResolver resolver = null)
        {
            return o is null
                ? string.Empty
                : await Task.Run(() => JsonSerializer.NonGeneric.ToJsonString(o, resolver));
        }

        /// <summary>
        /// Serialize async
        /// </summary>
        /// <param name="o"></param>
        /// <param name="type"></param>
        /// <param name="resolver"></param>
        /// <returns></returns>
        public static async Task<string> SerializeAsync(object o, Type type, IJsonFormatterResolver resolver = null)
        {
            return o is null
                ? string.Empty
                : await Task.Run(() => JsonSerializer.NonGeneric.ToJsonString(type, o, resolver));
        }

        /// <summary>
        /// Serialize to bytes async
        /// </summary>
        /// <param name="o"></param>
        /// <param name="resolver"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<byte[]> SerializeToBytesAsync<T>(T o, IJsonFormatterResolver resolver = null)
        {
            return o is null
                ? new byte[0]
                : await Task.Run(() => JsonSerializer.Serialize(o, resolver));
        }

        /// <summary>
        /// Serialize to bytes async
        /// </summary>
        /// <param name="o"></param>
        /// <param name="resolver"></param>
        /// <returns></returns>
        public static async Task<byte[]> SerializeToBytesAsync(object o, IJsonFormatterResolver resolver = null)
        {
            return o is null
                ? new byte[0]
                : await Task.Run(() => JsonSerializer.NonGeneric.Serialize(o, resolver));
        }

        /// <summary>
        /// Serialize to bytes async
        /// </summary>
        /// <param name="o"></param>
        /// <param name="type"></param>
        /// <param name="resolver"></param>
        /// <returns></returns>
        public static async Task<byte[]> SerializeToBytesAsync(object o, Type type, IJsonFormatterResolver resolver = null)
        {
            return o is null
                ? new byte[0]
                : await Task.Run(() => JsonSerializer.NonGeneric.Serialize(type, o, resolver));
        }

        /// <summary>
        /// Deserialize async
        /// </summary>
        /// <param name="json"></param>
        /// <param name="resolver"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<T> DeserializeAsync<T>(string json, IJsonFormatterResolver resolver = null)
        {
            return string.IsNullOrWhiteSpace(json)
                ? default
                : await Task.Run(() => JsonSerializer.Deserialize<T>(json, resolver));
        }

        /// <summary>
        /// Deserialize async
        /// </summary>
        /// <param name="json"></param>
        /// <param name="type"></param>
        /// <param name="resolver"></param>
        /// <returns></returns>
        public static async Task<object> DeserializeAsync(string json, Type type, IJsonFormatterResolver resolver = null)
        {
            return string.IsNullOrWhiteSpace(json)
                ? null
                : await Task.Run(() => JsonSerializer.NonGeneric.Deserialize(type, json, resolver));
        }

        /// <summary>
        /// Deserialize async
        /// </summary>
        /// <param name="data"></param>
        /// <param name="resolver"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<T> DeserializeFromBytesAsync<T>(byte[] data, IJsonFormatterResolver resolver = null)
        {
            return data is null || data.Length is 0
                ? default
                : await Task.Run(() => JsonSerializer.Deserialize<T>(data, resolver));
        }

        /// <summary>
        /// Deserialize async
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <param name="resolver"></param>
        /// <returns></returns>
        public static async Task<object> DeserializeFromBytesAsync(byte[] data, Type type, IJsonFormatterResolver resolver = null)
        {
            if (data is null || data.Length is 0)
                return null;

            var reader = new JsonReader(data, 0);

            return await Task.Run(() => JsonSerializer.NonGeneric.Deserialize(type, ref reader, resolver));
        }
    }
}