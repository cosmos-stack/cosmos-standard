using System;
using System.Threading.Tasks;
using Cosmos.Serialization.Json.Lit;

// ReSharper disable once CheckNamespace
namespace Cosmos.Serialization.Json
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

        /// <summary>
        /// From LitJson async
        /// </summary>
        /// <param name="str"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<T> FromLitJsonAsync<T>(this string str)
        {
            return LitHelper.DeserializeAsync<T>(str);
        }

        /// <summary>
        /// From LitJson async
        /// </summary>
        /// <param name="str"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Task<object> FromLitJsonAsync(this string str, Type type)
        {
            return LitHelper.DeserializeAsync(str, type);
        }
    }
}