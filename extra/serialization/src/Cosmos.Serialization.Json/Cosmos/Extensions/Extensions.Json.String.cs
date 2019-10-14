using System;
using Cosmos.Json;

/*
 * Reference to:
 *      Mutuduxf/Zaabee.Serializers
 *          Author: Mutuduxf
 *          Url:    https://github.com/Mutuduxf/Zaabee.Serializers
 *          MIT
 */

namespace Cosmos.Extensions
{
    /// <summary>
    /// Newtonsoft Json Extensions
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// From Json
        /// </summary>
        /// <param name="str"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T FromJson<T>(this string str)
        {
            return JsonHelper.Deserialize<T>(str);
        }

        /// <summary>
        /// From Json
        /// </summary>
        /// <param name="str"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object FromJson(this string str, Type type)
        {
            return JsonHelper.Deserialize(str, type);
        }
    }
}