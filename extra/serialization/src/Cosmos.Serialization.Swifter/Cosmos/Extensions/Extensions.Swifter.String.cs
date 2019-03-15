using System;
using Cosmos.Swifter;

namespace Cosmos.Extensions
{
    public static partial class Extensions
    {
        public static T FromSwifterJson<T>(this string str)
        {
            return SwifterHelper.Deserialize<T>(str);
        }

        public static object FromSwifterJson(this string str, Type type)
        {
            return SwifterHelper.Deserialize(str, type);
        }
    }
}
