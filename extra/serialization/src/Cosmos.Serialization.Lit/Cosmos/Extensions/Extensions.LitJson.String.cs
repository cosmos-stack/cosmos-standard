using System;
using Cosmos.Lit;

namespace Cosmos.Extensions
{
    public static partial class Extensions
    {
        public static T FromLitJson<T>(this string str)
        {
            return LitHelper.Deserialize<T>(str);
        }

        public static object FromLitJson(this string str, Type type)
        {
            return LitHelper.Deserialize(str, type);
        }
    }
}
