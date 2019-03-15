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
    public static partial class Extensions
    {
        public static T FromJson<T>(this string str)
        {
            return JsonHelper.Deserialize<T>(str);
        }

        public static object FromJson(this string str, Type type)
        {
            return JsonHelper.Deserialize(str, type);
        }
    }
}
