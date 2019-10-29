using System;
using System.Text.Json;
using System.Threading.Tasks;

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
        public static async Task<string> SerializeAsync(object o, JsonSerializerOptions options = null)
        {
            return o is null
                ? string.Empty
                : await Task.Run(() => JsonSerializer.Serialize(o, options ?? MicrosoftJsonManager.DefaultOptions));
        }

        /// <summary>
        /// Serialize to bytes
        /// </summary>
        /// <param name="o"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static async Task<byte[]> SerializeToBytesAsync(object o, JsonSerializerOptions options = null)
        {
            return o is null
                ? new byte[0]
                : await Task.Run(() => JsonSerializer.SerializeToUtf8Bytes(o, options ?? MicrosoftJsonManager.DefaultOptions));
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="json"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<T> DeserializeAsync<T>(string json, JsonSerializerOptions options = null)
        {
            return string.IsNullOrWhiteSpace(json)
                ? default
                : await Task.Run(() => JsonSerializer.Deserialize<T>(json, options ?? MicrosoftJsonManager.DefaultOptions));
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="json"></param>
        /// <param name="type"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static async Task<object> DeserializeAsync(string json, Type type, JsonSerializerOptions options = null)
        {
            return string.IsNullOrWhiteSpace(json)
                ? null
                : await Task.Run(() => JsonSerializer.Deserialize(json, type, options ?? MicrosoftJsonManager.DefaultOptions));
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="data"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<T> DeserializeFromBytesAsync<T>(byte[] data, JsonSerializerOptions options = null)
        {
            return data is null || data.Length is 0
                ? default
                : await Task.Run(() => JsonSerializer.Deserialize<T>(data, options ?? MicrosoftJsonManager.DefaultOptions));
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static async Task<object> DeserializeFromBytesAsync(byte[] data, Type type, JsonSerializerOptions options = null)
        {
            return data is null || data.Length is 0
                ? null
                : await Task.Run(() => JsonSerializer.Deserialize(data, type, options ?? MicrosoftJsonManager.DefaultOptions));
        }
    }
}