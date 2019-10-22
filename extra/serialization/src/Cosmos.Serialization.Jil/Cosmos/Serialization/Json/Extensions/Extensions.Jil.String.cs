using System;
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
        /// From Jil
        /// </summary>
        /// <param name="json"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T FromJil<T>(this string json, Options options = null)
        {
            return JilHelper.Deserialize<T>(json, options);
        }

        /// <summary>
        /// From Jil
        /// </summary>
        /// <param name="json"></param>
        /// <param name="optionsAct"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T FromJil<T>(this string json, Action<Options> optionsAct)
        {
            return JilHelper.Deserialize<T>(json, optionsAct);
        }

        /// <summary>
        /// From Jil
        /// </summary>
        /// <param name="json"></param>
        /// <param name="type"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static object FromJil(this string json, Type type, Options options = null)
        {
            return JilHelper.Deserialize(json, type, options);
        }

        /// <summary>
        /// From Jil
        /// </summary>
        /// <param name="json"></param>
        /// <param name="type"></param>
        /// <param name="optionsAct"></param>
        /// <returns></returns>
        public static object FromJil(this string json, Type type, Action<Options> optionsAct)
        {
            return JilHelper.Deserialize(json, type, optionsAct);
        }

        /// <summary>
        /// From Jil async
        /// </summary>
        /// <param name="json"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<T> FromJilAsync<T>(this string json, Options options = null)
        {
            return JilHelper.DeserializeAsync<T>(json, options);
        }

        /// <summary>
        /// From Jil async
        /// </summary>
        /// <param name="json"></param>
        /// <param name="optionsAct"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<T> FromJilAsync<T>(this string json, Action<Options> optionsAct)
        {
            return JilHelper.DeserializeAsync<T>(json, optionsAct);
        }

        /// <summary>
        /// From Jil async
        /// </summary>
        /// <param name="json"></param>
        /// <param name="typpe"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static Task<object> FromJilAsync(this string json, Type typpe, Options options = null)
        {
            return JilHelper.DeserializeAsync(json, typpe, options);
        }

        /// <summary>
        /// From Jil async
        /// </summary>
        /// <param name="json"></param>
        /// <param name="type"></param>
        /// <param name="optionsAct"></param>
        /// <returns></returns>
        public static Task<object> FromJilAsync(this string json, Type type, Action<Options> optionsAct)
        {
            return JilHelper.DeserializeAsync(json, type, optionsAct);
        }
    }
}