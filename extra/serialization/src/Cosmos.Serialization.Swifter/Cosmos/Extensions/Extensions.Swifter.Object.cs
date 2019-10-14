using System;
using Cosmos.Swifter;
using Swifter.Json;

namespace Cosmos.Extensions
{
    /// <summary>
    /// SwiftJson extensions
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// ToSwifterJson
        /// </summary>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string ToSwifterJson<T>(this T obj)
        {
            return SwifterHelper.Serialize(obj);
        }

        /// <summary>
        /// ToSwifterJson
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string ToSwifterJson<T>(this T obj, JsonFormatterOptions options)
        {
            return SwifterHelper.Serialize(obj, options);
        }

        /// <summary>
        /// ToSwifterJson
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="optionAct"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string ToSwifterJson<T>(this T obj, Action<JsonFormatterOptions> optionAct)
        {
            return SwifterHelper.Serialize(obj, optionAct);
        }
    }
}