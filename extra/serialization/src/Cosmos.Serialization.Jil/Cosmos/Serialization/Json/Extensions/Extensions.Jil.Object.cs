using System;
using System.IO;
using System.Threading.Tasks;
using Jil;
using Cosmos.Serialization.Json.Jil;

/*
 * Reference to:
 *      Mutuduxf/Zaabee.Serializers
 *          Author: Mutuduxf
 *          Url:    https://github.com/Mutuduxf/Zaabee.Serializers
 *          MIT
 */

// ReSharper disable once CheckNamespace
namespace Cosmos.Serialization.Json
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

        /// <summary>
        /// To Jil
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="textWriter"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        public static void ToJil<T>(this T obj, TextWriter textWriter, Options options = null)
        {
            JilHelper.Serialize(obj, textWriter, options);
        }

        /// <summary>
        /// To Jil async
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<string> ToJilAsync<T>(this T obj, Options options = null)
        {
            return JilHelper.SerializeAsync(obj, options);
        }

        /// <summary>
        /// To Jil async
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="optionsAct"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<string> ToJilAsync<T>(this T obj, Action<Options> optionsAct)
        {
            return JilHelper.SerializeAsync(obj, optionsAct);
        }

        /// <summary>
        /// To Jil async
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="textWriter"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        public static Task ToJilAsync<T>(this T obj, TextWriter textWriter, Options options = null)
        {
            return JilHelper.SerializeAsync(obj, textWriter, options);
        }
    }
}