using System;
using Cosmos.Kooboo;
using Kooboo.Json;

namespace Cosmos.Extensions
{
    /// <summary>
    /// KoobooJson extensions
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// From KoobooJson
        /// </summary>
        /// <param name="json"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T FromKoobooJson<T>(this string json)
        {
            return KoobooJsonHelper.Deserialize<T>(json);
        }

        /// <summary>
        /// From KoobooJson
        /// </summary>
        /// <param name="json"></param>
        /// <param name="option"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T FromKoobooJson<T>(this string json, JsonDeserializeOption option)
        {
            return KoobooJsonHelper.Deserialize<T>(json, option);
        }

        /// <summary>
        /// From KoobooJson
        /// </summary>
        /// <param name="json"></param>
        /// <param name="optionAct"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T FromKoobooJson<T>(this string json, Action<JsonDeserializeOption> optionAct)
        {
            return KoobooJsonHelper.Deserialize<T>(json, optionAct);
        }


        /// <summary>
        /// From KoobooJson
        /// </summary>
        /// <param name="json"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object FromKoobooJson(this string json, Type type)
        {
            return KoobooJsonHelper.Deserialize(json, type);
        }

        /// <summary>
        /// From KoobooJson
        /// </summary>
        /// <param name="json"></param>
        /// <param name="type"></param>
        /// <param name="option"></param>
        /// <returns></returns>
        public static object FromKoobooJson(this string json, Type type, JsonDeserializeOption option)
        {
            return KoobooJsonHelper.Deserialize(json, type, option);
        }

        /// <summary>
        /// From KoobooJson
        /// </summary>
        /// <param name="json"></param>
        /// <param name="type"></param>
        /// <param name="optionAct"></param>
        /// <returns></returns>
        public static object FromKoobooJson(this string json, Type type, Action<JsonDeserializeOption> optionAct)
        {
            return KoobooJsonHelper.Deserialize(json, type, optionAct);
        }
    }
}