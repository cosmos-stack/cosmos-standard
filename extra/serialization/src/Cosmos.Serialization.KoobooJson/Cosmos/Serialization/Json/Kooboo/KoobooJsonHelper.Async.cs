using System;
using System.Threading.Tasks;
using Kooboo.Json;

namespace Cosmos.Serialization.Json.Kooboo
{
    /// <summary>
    /// KoobooJson helper
    /// </summary>
    public static partial class KoobooJsonHelper
    {
        /// <summary>
        /// Serialize async
        /// </summary>
        /// <param name="o"></param>
        /// <param name="option"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<string> SerializeAsync<T>(T o, JsonSerializerOption option = null)
        {
            return o is null
                ? string.Empty
                : await Task.Run(() => JsonSerializer.ToJson(o, option ?? KoobooManager.DefaultSerializerOptions));
        }

        /// <summary>
        /// Serialize async
        /// </summary>
        /// <param name="o"></param>
        /// <param name="optionAct"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<string> SerializeAsync<T>(T o, Action<JsonSerializerOption> optionAct)
        {
            var option = new JsonSerializerOption();
            optionAct?.Invoke(option);

            return SerializeAsync(o, option);
        }

        /// <summary>
        /// Serialize to bytes async
        /// </summary>
        /// <param name="o"></param>
        /// <param name="option"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<byte[]> SerializeToBytesAsync<T>(T o, JsonSerializerOption option = null)
        {
            return o is null
                ? new byte[0]
                : await Task.Run(() => KoobooManager.DefaultEncoding.GetBytes(Serialize(o, option ?? KoobooManager.DefaultSerializerOptions)));
        }

        /// <summary>
        /// Serialize to bytes async
        /// </summary>
        /// <param name="o"></param>
        /// <param name="optionAct"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<byte[]> SerializeToBytesAsync<T>(T o, Action<JsonSerializerOption> optionAct)
        {
            var option = new JsonSerializerOption();
            optionAct?.Invoke(option);

            return SerializeToBytesAsync(o, option);
        }

        /// <summary>
        /// Deserialize async
        /// </summary>
        /// <param name="json"></param>
        /// <param name="type"></param>
        /// <param name="option"></param>
        /// <returns></returns>
        public static async Task<object> DeserializeAsync(string json, Type type, JsonDeserializeOption option = null)
        {
            return string.IsNullOrWhiteSpace(json)
                ? default
                : await Task.Run(() => JsonSerializer.ToObject(json, type, option ?? KoobooManager.DefaultDeserializeOptions));
        }

        /// <summary>
        /// Deserialize async
        /// </summary>
        /// <param name="json"></param>
        /// <param name="type"></param>
        /// <param name="optionAct"></param>
        /// <returns></returns>
        public static Task<object> DeserializeAsync(string json, Type type, Action<JsonDeserializeOption> optionAct)
        {
            var option = new JsonDeserializeOption();
            optionAct?.Invoke(option);

            return DeserializeAsync(json, type, option);
        }

        /// <summary>
        /// Deserialize async
        /// </summary>
        /// <param name="json"></param>
        /// <param name="option"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<T> DeserializeAsync<T>(string json, JsonDeserializeOption option = null)
        {
            return string.IsNullOrWhiteSpace(json)
                ? default
                : await Task.Run(() => JsonSerializer.ToObject<T>(json, option ?? KoobooManager.DefaultDeserializeOptions));
        }

        /// <summary>
        /// Deserialize async
        /// </summary>
        /// <param name="json"></param>
        /// <param name="optionAct"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<T> DeserializeAsync<T>(string json, Action<JsonDeserializeOption> optionAct)
        {
            var option = new JsonDeserializeOption();
            optionAct?.Invoke(option);

            return DeserializeAsync<T>(json, option);
        }

        /// <summary>
        /// Deserialize from bytes async
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <param name="option"></param>
        /// <returns></returns>
        public static async Task<object> DeserializeFromBytesAsync(byte[] data, Type type, JsonDeserializeOption option = null)
        {
            return data is null || data.Length is 0
                ? default
                : await DeserializeAsync(KoobooManager.DefaultEncoding.GetString(data), type, option ?? KoobooManager.DefaultDeserializeOptions);
        }

        /// <summary>
        /// Deserialize from bytes async
        /// </summary>
        /// <param name="type"></param>
        /// <param name="optionAct"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static Task<object> DeserializeFromBytesAsync(byte[] data, Type type, Action<JsonDeserializeOption> optionAct)
        {
            var option = new JsonDeserializeOption();
            optionAct?.Invoke(option);

            return DeserializeFromBytesAsync(data, type, option);
        }

        /// <summary>
        /// Deserialize from bytes async
        /// </summary>
        /// <param name="data"></param>
        /// <param name="option"></param>
        /// <returns></returns>
        public static async Task<T> DeserializeFromBytesAsync<T>(byte[] data, JsonDeserializeOption option = null)
        {
            return data is null || data.Length is 0
                ? default
                : await DeserializeAsync<T>(KoobooManager.DefaultEncoding.GetString(data), option ?? KoobooManager.DefaultDeserializeOptions);
        }

        /// <summary>
        /// Deserialize from bytes async
        /// </summary>
        /// <param name="optionAct"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static Task<T> DeserializeFromBytesAsync<T>(byte[] data, Action<JsonDeserializeOption> optionAct)
        {
            var option = new JsonDeserializeOption();
            optionAct?.Invoke(option);

            return DeserializeFromBytesAsync<T>(data, option);
        }
    }
}