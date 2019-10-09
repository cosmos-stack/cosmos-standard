using System;
using Cosmos.Lit;

namespace Cosmos.Extensions
{
    /// <summary>
    /// LitJson extensions
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// From LitJson
        /// </summary>
        /// <param name="str"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T FromLitJson<T>(this string str)
        {
            return LitHelper.Deserialize<T>(str);
        }

        /// <summary>
        /// From LitJson
        /// </summary>
        /// <param name="str"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object FromLitJson(this string str, Type type)
        {
            return LitHelper.Deserialize(str, type);
        }
    }
}
