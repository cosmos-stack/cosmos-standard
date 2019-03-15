using System;
using Cosmos.Jil;
using Jil;

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
        public static T FromJil<T>(this string json, Options options = null)
        {
            return JilHelper.Deserialize<T>(json, options);
        }

        public static object FromJil(this string json, Type type, Options options = null)
        {
            return JilHelper.Deserialize(json, type, options);
        }
    }
}
