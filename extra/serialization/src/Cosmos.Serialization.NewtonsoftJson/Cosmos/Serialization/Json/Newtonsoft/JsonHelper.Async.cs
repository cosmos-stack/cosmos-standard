using System;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Cosmos.Serialization.Json.Newtonsoft
{
    /// <summary>
    /// Newtonsoft Json Helper
    /// </summary>
    public static partial class JsonHelper
    {
        /// <summary>
        /// Serialize to bytes async
        /// </summary>
        /// <param name="o"></param>
        /// <param name="settings"></param>
        /// <param name="withNodaTime"></param>
        /// <returns></returns>
        public static async Task<byte[]> SerializeToBytesAsync(object o, JsonSerializerSettings settings = null, bool withNodaTime = false)
        {
            return o is null
                ? new byte[0]
                : JsonManager.DefaultEncoding.GetBytes(await SerializeAsync(o, settings, withNodaTime));
        }

        /// <summary>
        /// Serialize async
        /// </summary>
        /// <param name="o"></param>
        /// <param name="settings"></param>
        /// <param name="withNodaTime"></param>
        /// <returns></returns>
        public static async Task<string> SerializeAsync(object o, JsonSerializerSettings settings = null, bool withNodaTime = false)
        {
            return o is null
                ? string.Empty
                : await Task.Run(() => JsonConvert.SerializeObject(o, TouchSettings(settings, withNodaTime)));
        }

        /// <summary>
        /// Deserialize from bytes async
        /// </summary>
        /// <param name="data"></param>
        /// <param name="settings"></param>
        /// <param name="withNodaTime"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<T> DeserializeFromBytesAsync<T>(byte[] data, JsonSerializerSettings settings = null, bool withNodaTime = false)
        {
            return data is null || data.Length is 0
                ? default
                : await DeserializeAsync<T>(JsonManager.DefaultEncoding.GetString(data), settings, withNodaTime);
        }

        /// <summary>
        /// Deserialize from bytes async
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <param name="settings"></param>
        /// <param name="withNodaTime"></param>
        /// <returns></returns>
        public static async Task<object> DeserializeFromBytesAsync(byte[] data, Type type, JsonSerializerSettings settings = null, bool withNodaTime = false)
        {
            return data is null || data.Length is 0
                ? default
                : await DeserializeAsync(JsonManager.DefaultEncoding.GetString(data), type, settings, withNodaTime);
        }

        /// <summary>
        /// Deserialize async
        /// </summary>
        /// <param name="json"></param>
        /// <param name="settings"></param>
        /// <param name="withNodaTime"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<T> DeserializeAsync<T>(string json, JsonSerializerSettings settings = null, bool withNodaTime = false)
        {
            return string.IsNullOrWhiteSpace(json)
                ? default
                : await Task.Run(() => JsonConvert.DeserializeObject<T>(json, TouchSettings(settings, withNodaTime)));
        }

        /// <summary>
        /// Deserialize async
        /// </summary>
        /// <param name="json"></param>
        /// <param name="settings"></param>
        /// <param name="type"></param>
        /// <param name="withNodaTime"></param>
        /// <returns></returns>
        public static async Task<object> DeserializeAsync(string json, Type type, JsonSerializerSettings settings = null, bool withNodaTime = false)
        {
            return string.IsNullOrWhiteSpace(json)
                ? default
                : await Task.Run(() => JsonConvert.DeserializeObject(json, type, TouchSettings(settings, withNodaTime)));
        }
    }
}