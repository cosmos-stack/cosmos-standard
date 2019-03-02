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
    public static partial class Extensions
    {
        public static string ToJson<T>(this T obj, IEnumerable<string> displayFields = null, bool toLowerCamel = false, string dateTimeFormat = null)
        {
            return JsonHelper.Serialize(obj, displayFields, toLowerCamel, dateTimeFormat);
        }
    }
}
