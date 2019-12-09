using System;
using System.Threading.Tasks;
using Cosmos.Serialization.Json.Utf8Json;
using Utf8Json;

// ReSharper disable once CheckNamespace
namespace Cosmos.Serialization.Json {
    /// <summary>
    /// Utf8Json extensions
    /// </summary>
    public static partial class Utf8JsonExtensions {
        /// <summary>
        /// From Utf8Json
        /// </summary>
        /// <param name="json"></param>
        /// <param name="resolver"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T FromUtf8Json<T>(this string json, IJsonFormatterResolver resolver = null) {
            return Utf8JsonHelper.Deserialize<T>(json, resolver);
        }

        /// <summary>
        /// From Utf8Json
        /// </summary>
        /// <param name="json"></param>
        /// <param name="type"></param>
        /// <param name="resolver"></param>
        /// <returns></returns>
        public static object FromUtf8Json(this string json, Type type, IJsonFormatterResolver resolver = null) {
            return Utf8JsonHelper.Deserialize(json, type, resolver);
        }

        /// <summary>
        /// From Utf8Json async
        /// </summary>
        /// <param name="json"></param>
        /// <param name="resolver"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<T> FromUtf8JsonAsync<T>(this string json, IJsonFormatterResolver resolver = null) {
            return Utf8JsonHelper.DeserializeAsync<T>(json, resolver);
        }

        /// <summary>
        /// From Utf8Json async
        /// </summary>
        /// <param name="json"></param>
        /// <param name="type"></param>
        /// <param name="resolver"></param>
        /// <returns></returns>
        public static Task<object> FromUtf8JsonAsync(this string json, Type type, IJsonFormatterResolver resolver = null) {
            return Utf8JsonHelper.DeserializeAsync(json, type, resolver);
        }
    }
}