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
        public static string ToJil<T>(this T obj, Options options = null)
        {
            return JilHelper.Serialize(obj, options);
        }
    }
}
