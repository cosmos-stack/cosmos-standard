using System;
using System.Text;
using Swifter.Json;

namespace Cosmos.Swifter
{
    /// <summary>
    /// SwiftJson Helper
    /// </summary>
    public static class SwifterHelper
    {
        /// <summary>
        /// Serialize
        /// </summary>
        /// <param name="o"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string Serialize<T>(T o)
        {
            return JsonFormatter.SerializeObject(o);
        }

        /// <summary>
        /// Serialize
        /// </summary>
        /// <param name="o"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string Serialize<T>(T o, JsonFormatterOptions options)
        {
            return JsonFormatter.SerializeObject(o, options);
        }

        /// <summary>
        /// Serialize
        /// </summary>
        /// <param name="o"></param>
        /// <param name="optionAct"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string Serialize<T>(T o, Action<JsonFormatterOptions> optionAct)
        {
            var options = new JsonFormatterOptions();
            optionAct?.Invoke(options);
            return JsonFormatter.SerializeObject(o, options);
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="json"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Deserialize<T>(string json)
        {
            return string.IsNullOrWhiteSpace(json) ? default : JsonFormatter.DeserializeObject<T>(json);
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="json"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Deserialize<T>(string json, JsonFormatterOptions options)
        {
            return string.IsNullOrWhiteSpace(json) ? default : JsonFormatter.DeserializeObject<T>(json, options);
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="json"></param>
        /// <param name="optionAct"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Deserialize<T>(string json, Action<JsonFormatterOptions> optionAct)
        {
            var options = new JsonFormatterOptions();
            optionAct?.Invoke(options);
            return string.IsNullOrWhiteSpace(json) ? default : JsonFormatter.DeserializeObject<T>(json, options);
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="json"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object Deserialize(string json, Type type)
        {
            return string.IsNullOrWhiteSpace(json) ? null : JsonFormatter.DeserializeObject(json, type);
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="json"></param>
        /// <param name="type"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static object Deserialize(string json, Type type, JsonFormatterOptions options)
        {
            return string.IsNullOrWhiteSpace(json) ? null : JsonFormatter.DeserializeObject(json, type, options);
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="json"></param>
        /// <param name="type"></param>
        /// <param name="optionAct"></param>
        /// <returns></returns>
        public static object Deserialize(string json, Type type, Action<JsonFormatterOptions> optionAct)
        {
            var options = new JsonFormatterOptions();
            optionAct?.Invoke(options);
            return string.IsNullOrWhiteSpace(json) ? null : JsonFormatter.DeserializeObject(json, type, options);
        }
    }
}