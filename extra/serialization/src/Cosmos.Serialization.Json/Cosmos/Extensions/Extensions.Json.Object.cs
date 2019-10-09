using System.Collections.Generic;
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
        /// To Json
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="displayFields"></param>
        /// <param name="toLowerCamel"></param>
        /// <param name="dateTimeFormat"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string ToJson<T>(this T obj, IEnumerable<string> displayFields = null, bool toLowerCamel = false, string dateTimeFormat = null)
        {
            return JsonHelper.Serialize(obj, displayFields, toLowerCamel, dateTimeFormat);
        }
    }
}