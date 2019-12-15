using System;
using System.Threading.Tasks;
using Kooboo.Json;
using Cosmos.Serialization.Json.Kooboo;

// ReSharper disable once CheckNamespace
namespace Cosmos.Serialization.Json {
    using K = KoobooJsonHelper;

    /// <summary>
    /// KoobooJson extensions
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// To KoobooJson
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="option"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string ToKoobooJson<T>(this T obj, JsonSerializerOption option = null) => K.Serialize(obj, option);

        /// <summary>
        /// To KoobooJson
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="optionAct"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string ToKoobooJson<T>(this T obj, Action<JsonSerializerOption> optionAct) => K.Serialize(obj, optionAct);

        /// <summary>
        /// To KoobooJson async
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="option"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<string> ToKoobooJsonAsync<T>(this T obj, JsonSerializerOption option = null) => K.SerializeAsync(obj, option);


        /// <summary>
        /// To KoobooJson async
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="optionAct"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<string> ToKoobooJsonAsync<T>(this T obj, Action<JsonSerializerOption> optionAct) => K.SerializeAsync(obj, optionAct);
    }
}