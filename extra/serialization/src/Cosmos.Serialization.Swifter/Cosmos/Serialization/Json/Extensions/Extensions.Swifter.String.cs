using System;
using System.Threading.Tasks;
using Cosmos.Serialization.Json.Swifter;
using Swifter.Json;

// ReSharper disable once CheckNamespace
namespace Cosmos.Serialization.Json
{
    /// <summary>
    /// SwiftJson extensions
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// From SwiftJson
        /// </summary>
        /// <param name="json"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T FromSwifterJson<T>(this string json, JsonFormatterOptions? options = null)
        {
            return SwifterHelper.Deserialize<T>(json, options);
        }

        /// <summary>
        /// From SwiftJson
        /// </summary>
        /// <param name="json"></param>
        /// <param name="type"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static object FromSwifterJson(this string json, Type type, JsonFormatterOptions? options = null)
        {
            return SwifterHelper.Deserialize(json, type, options);
        }

        /// <summary>
        /// From SwiftJson async
        /// </summary>
        /// <param name="json"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<T> FromSwifterJsonAsync<T>(this string json, JsonFormatterOptions? options = null)
        {
            return SwifterHelper.DeserializeAsync<T>(json, options);
        }

        /// <summary>
        /// From SwiftJson async
        /// </summary>
        /// <param name="json"></param>
        /// <param name="type"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static Task<object> FromSwifterJsonAsync(this string json, Type type, JsonFormatterOptions? options = null)
        {
            return SwifterHelper.DeserializeAsync(json, type, options);
        }
    }
}