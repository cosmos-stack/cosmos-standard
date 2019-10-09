using System;
using Kooboo.Json;

namespace Cosmos.Kooboo
{
    /// <summary>
    /// KoobooJson helper
    /// </summary>
    public static class KoobooJsonHelper
    {
        /// <summary>
        /// Serialize
        /// </summary>
        /// <param name="o"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string Serialize<T>(T o)
        {
            return JsonSerializer.ToJson(o);
        }

        /// <summary>
        /// Serialize
        /// </summary>
        /// <param name="o"></param>
        /// <param name="option"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string Serialize<T>(T o, JsonSerializerOption option)
        {
            return JsonSerializer.ToJson(o, option);
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
            return JsonSerializer.ToJson(o, option);
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="json"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object Deserialize(string json, Type type)
        {
            return string.IsNullOrWhiteSpace(json) ? default : JsonSerializer.ToObject(json, type);
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="json"></param>
        /// <param name="type"></param>
        /// <param name="option"></param>
        /// <returns></returns>
        public static object Deserialize(string json, Type type, JsonDeserializeOption option)
        {
            return string.IsNullOrWhiteSpace(json) ? default : JsonSerializer.ToObject(json, type, option);
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
            return string.IsNullOrWhiteSpace(json) ? default : JsonSerializer.ToObject(json, type, option);
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="json"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Deserialize<T>(string json)
        {
            return string.IsNullOrWhiteSpace(json) ? default : JsonSerializer.ToObject<T>(json);
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="json"></param>
        /// <param name="option"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Deserialize<T>(string json, JsonDeserializeOption option)
        {
            return string.IsNullOrWhiteSpace(json) ? default : JsonSerializer.ToObject<T>(json, option);
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
            return string.IsNullOrWhiteSpace(json) ? default : JsonSerializer.ToObject<T>(json, option);
        }
    }
}