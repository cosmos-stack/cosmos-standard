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
    /// <summary>
    /// JilJson extensions
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// To Jil
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string ToJil<T>(this T obj, Options options = null)
        {
            return JilHelper.Serialize(obj, options);
        }

        /// <summary>
        /// To Jil
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="optionsAct"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string ToJil<T>(this T obj, Action<Options> optionsAct)
        {
            return JilHelper.Serialize(obj, optionsAct);
        }
    }
}