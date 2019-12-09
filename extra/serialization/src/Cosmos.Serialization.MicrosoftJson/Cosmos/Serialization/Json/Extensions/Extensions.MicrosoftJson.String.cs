using System;
using System.Text.Json;
using System.Threading.Tasks;
using Cosmos.Serialization.Json.MicrosoftJson;

// ReSharper disable once CheckNamespace
namespace Cosmos.Serialization.Json {
    using MS = MicrosoftJsonHelper;

    /// <summary>
    /// Microsoft System.Text.Json extensions
    /// </summary>
    public static partial class MsJsonExtensions {
        /// <summary>
        /// From Microsoft System.Text.Json
        /// </summary>
        /// <param name="json"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T FromMicrosoftJson<T>(this string json, JsonSerializerOptions options = null) => MS.Deserialize<T>(json, options);


        /// <summary>
        /// From Microsoft System.Text.Json
        /// </summary>
        /// <param name="json"></param>
        /// <param name="type"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static object FromMicrosoftJson(this string json, Type type, JsonSerializerOptions options = null) => MS.Deserialize(json, type, options);


        /// <summary>
        /// From Microsoft System.Text.Json async
        /// </summary>
        /// <param name="json"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<T> FromMicrosoftJsonAsync<T>(this string json, JsonSerializerOptions options = null) => MS.DeserializeAsync<T>(json, options);


        /// <summary>
        /// From Microsoft System.Text.Json async
        /// </summary>
        /// <param name="json"></param>
        /// <param name="type"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static Task<object> FromMicrosoftJsonAsync(this string json, Type type, JsonSerializerOptions options = null) => MS.DeserializeAsync(json, type, options);

    }
}