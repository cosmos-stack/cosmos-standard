using System;
using Kooboo.Json;

namespace Cosmos.Serialization.Json.Kooboo
{
    /// <summary>
    /// KoobooJson helper
    /// </summary>
    public static partial class KoobooJsonHelper
    {
        /// <summary>
        /// Serialize
        /// </summary>
        /// <param name="o"></param>
        /// <param name="option"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string Serialize<T>(T o, JsonSerializerOption option = null)
        {
            return o is null
                ? string.Empty
                : JsonSerializer.ToJson(o, option ?? KoobooManager.DefaultSerializerOptions);
        }

        /// <summary>
        /// Serialize
        /// </summary>
        /// <param name="o"></param>
        /// <param name="optionAct"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string Serialize<T>(T o, Action<JsonSerializerOption> optionAct)
        {
            var option = new JsonSerializerOption();
            optionAct?.Invoke(option);

            return Serialize(o, option);
        }

        /// <summary>
        /// Serialize to bytes
        /// </summary>
        /// <param name="o"></param>
        /// <param name="option"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static byte[] SerializeToBytes<T>(T o, JsonSerializerOption option = null)
        {
            return o is null
                ? new byte[0]
                : KoobooManager.DefaultEncoding.GetBytes(Serialize(o, option ?? KoobooManager.DefaultSerializerOptions));
        }

        /// <summary>
        /// Serialize to bytes
        /// </summary>
        /// <param name="o"></param>
        /// <param name="optionAct"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static byte[] SerializeToBytes<T>(T o, Action<JsonSerializerOption> optionAct)
        {
            var option = new JsonSerializerOption();
            optionAct?.Invoke(option);

            return SerializeToBytes(o, option);
        }
        
        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="json"></param>
        /// <param name="type"></param>
        /// <param name="option"></param>
        /// <returns></returns>
        public static object Deserialize(string json, Type type, JsonDeserializeOption option = null)
        {
            return string.IsNullOrWhiteSpace(json)
                ? default
                : JsonSerializer.ToObject(json, type, option ?? KoobooManager.DefaultDeserializeOptions);
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="json"></param>
        /// <param name="type"></param>
        /// <param name="optionAct"></param>
        /// <returns></returns>
        public static object Deserialize(string json, Type type, Action<JsonDeserializeOption> optionAct)
        {
            var option = new JsonDeserializeOption();
            optionAct?.Invoke(option);

            return Deserialize(json, type, option);
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="json"></param>
        /// <param name="option"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Deserialize<T>(string json, JsonDeserializeOption option = null)
        {
            return string.IsNullOrWhiteSpace(json)
                ? default
                : JsonSerializer.ToObject<T>(json, option ?? KoobooManager.DefaultDeserializeOptions);
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="json"></param>
        /// <param name="optionAct"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Deserialize<T>(string json, Action<JsonDeserializeOption> optionAct)
        {
            var option = new JsonDeserializeOption();
            optionAct?.Invoke(option);

            return Deserialize<T>(json, option);
        }

        /// <summary>
        /// Deserialize from bytes
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <param name="option"></param>
        /// <returns></returns>
        public static object DeserializeFromBytes(byte[] data, Type type, JsonDeserializeOption option = null)
        {
            return data is null || data.Length is 0
                ? default
                : Deserialize(KoobooManager.DefaultEncoding.GetString(data), type, option ?? KoobooManager.DefaultDeserializeOptions);
        }

        /// <summary>
        /// Deserialize from bytes
        /// </summary>
        /// <param name="type"></param>
        /// <param name="optionAct"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static object DeserializeFromBytes(byte[] data, Type type, Action<JsonDeserializeOption> optionAct)
        {
            var option = new JsonDeserializeOption();
            optionAct?.Invoke(option);

            return DeserializeFromBytes(data, type, option);
        }

        /// <summary>
        /// Deserialize from bytes
        /// </summary>
        /// <param name="data"></param>
        /// <param name="option"></param>
        /// <returns></returns>
        public static T DeserializeFromBytes<T>(byte[] data, JsonDeserializeOption option = null)
        {
            return data is null || data.Length is 0
                ? default
                : Deserialize<T>(KoobooManager.DefaultEncoding.GetString(data), option ?? KoobooManager.DefaultDeserializeOptions);
        }

        /// <summary>
        /// Deserialize from bytes
        /// </summary>
        /// <param name="optionAct"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static T DeserializeFromBytes<T>(byte[] data, Action<JsonDeserializeOption> optionAct)
        {
            var option = new JsonDeserializeOption();
            optionAct?.Invoke(option);

            return DeserializeFromBytes<T>(data, option);
        }
    }
}