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
        /// To KoobooJson
        /// </summary>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string ToKoobooJson<T>(this T obj)
        {
            return KoobooJsonHelper.Serialize(obj);
        }

        /// <summary>
        /// To KoobooJson
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="option"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string ToKoobooJson<T>(this T obj, JsonSerializerOption option)
        {
            return KoobooJsonHelper.Serialize(obj, option);
        }
        
        
        /// <summary>
        /// To KoobooJson
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="optionAct"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string ToKoobooJson<T>(this T obj, Action<JsonSerializerOption> optionAct)
        {
            return KoobooJsonHelper.Serialize(obj, optionAct);
        }
    }
}
