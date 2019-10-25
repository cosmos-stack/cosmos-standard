using System;
using System.Threading.Tasks;
using LitJson;

namespace Cosmos.Serialization.Json.Lit
{
    /// <summary>
    /// Lit Helper
    /// </summary>
    public static partial class LitHelper
    {
        /// <summary>
        /// Serialize async
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static async Task<string> SerializeAsync(object o)
        {
            return o is null
                ? string.Empty
                : await Task.Run(() => JsonMapper.ToJson(o));
        }

        /// <summary>
        /// Serialize to bytes
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static async Task<byte[]> SerializeToBytesAsync(object o)
        {
            return o is null
                ? new byte[0]
                : await Task.Run(() => LitManager.DefaultEncoding.GetBytes(Serialize(o)));
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="json"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<T> DeserializeAsync<T>(string json)
        {
            return string.IsNullOrWhiteSpace(json)
                ? default
                : await Task.Run(() => JsonMapper.ToObject<T>(json));
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="json"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static async Task<object> DeserializeAsync(string json, Type type)
        {
            return string.IsNullOrWhiteSpace(json)
                ? null
                : await Task.Run(() => JsonMapper.ToObject(json, type));
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="data"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<T> DeserializeFromBytesAsync<T>(byte[] data)
        {
            return data is null || data.Length is 0
                ? default
                : DeserializeAsync<T>(LitManager.DefaultEncoding.GetString(data));
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Task<object> DeserializeFromBytesAsync(byte[] data, Type type)
        {
            return data is null || data.Length is 0
                ? null
                : DeserializeAsync(LitManager.DefaultEncoding.GetString(data), type);
        }
    }
}