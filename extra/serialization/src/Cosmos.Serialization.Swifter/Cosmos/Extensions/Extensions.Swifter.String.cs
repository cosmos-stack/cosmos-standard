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
        /// From SwiftJson
        /// </summary>
        /// <param name="str"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T FromSwifterJson<T>(this string str)
        {
            return SwifterHelper.Deserialize<T>(str);
        }

        /// <summary>
        /// From SwiftJson
        /// </summary>
        /// <param name="str"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T FromSwifterJson<T>(this string str, JsonFormatterOptions options)
        {
            return SwifterHelper.Deserialize<T>(str, options);
        }

        /// <summary>
        /// From SwiftJson
        /// </summary>
        /// <param name="str"></param>
        /// <param name="optionAct"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T FromSwifterJson<T>(this string str, Action<JsonFormatterOptions> optionAct)
        {
            return SwifterHelper.Deserialize<T>(str, optionAct);
        }

        /// <summary>
        /// From SwiftJson
        /// </summary>
        /// <param name="str"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object FromSwifterJson(this string str, Type type)
        {
            return SwifterHelper.Deserialize(str, type);
        }

        /// <summary>
        /// From SwiftJson
        /// </summary>
        /// <param name="str"></param>
        /// <param name="type"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static object FromSwifterJson(this string str, Type type, JsonFormatterOptions options)
        {
            return SwifterHelper.Deserialize(str, type, options);
        }

        /// <summary>
        /// From SwiftJson
        /// </summary>
        /// <param name="str"></param>
        /// <param name="type"></param>
        /// <param name="optionAct"></param>
        /// <returns></returns>
        public static object FromSwifterJson(this string str, Type type, Action<JsonFormatterOptions> optionAct)
        {
            return SwifterHelper.Deserialize(str, type, optionAct);
        }
    }
}