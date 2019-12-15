using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Cosmos.Serialization.Json.Newtonsoft;

/*
 * Reference to:
 *      Mutuduxf/Zaabee.Serializers
 *          Author: Mutuduxf
 *          Url:    https://github.com/Mutuduxf/Zaabee.Serializers
 *          MIT
 */

// ReSharper disable once CheckNamespace
namespace Cosmos.Serialization.Json {
    /// <summary>
    /// Newtonsoft Json Extensions
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// From Json
        /// </summary>
        /// <param name="json"></param>
        /// <param name="settings"></param>
        /// <param name="withNodaTime"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T FromJson<T>(this string json, JsonSerializerSettings settings = null, bool withNodaTime = false) {
            return JsonHelper.Deserialize<T>(json, settings, withNodaTime);
        }

        /// <summary>
        /// From Json
        /// </summary>
        /// <param name="json"></param>
        /// <param name="type"></param>
        /// <param name="settings"></param>
        /// <param name="withNodaTime"></param>
        /// <returns></returns>
        public static object FromJson(this string json, Type type, JsonSerializerSettings settings = null, bool withNodaTime = false) {
            return JsonHelper.Deserialize(json, type, settings, withNodaTime);
        }

        /// <summary>
        /// From Json
        /// </summary>
        /// <param name="json"></param>
        /// <param name="settings"></param>
        /// <param name="withNodaTime"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<T> FromJsonAsync<T>(this string json, JsonSerializerSettings settings = null, bool withNodaTime = false) {
            return JsonHelper.DeserializeAsync<T>(json, settings, withNodaTime);
        }

        /// <summary>
        /// From Json
        /// </summary>
        /// <param name="json"></param>
        /// <param name="type"></param>
        /// <param name="settings"></param>
        /// <param name="withNodaTime"></param>
        /// <returns></returns>
        public static Task<object> FromJsonAsync(this string json, Type type, JsonSerializerSettings settings = null, bool withNodaTime = false) {
            return JsonHelper.DeserializeAsync(json, type, settings, withNodaTime);
        }
    }
}