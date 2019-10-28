using System;
using System.Threading.Tasks;
using Cosmos.Serialization.Json.Utf8Json;
using Utf8Json;

// ReSharper disable once CheckNamespace
namespace Cosmos.Serialization.Json
{
    /// <summary>
    /// Utf8Json extensions
    /// </summary>
    public static partial class Utf8JsonExtensions
    {
        /// <summary>
        /// To Utf8Json
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="resolver"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string ToUtf8Json<T>(this T obj, IJsonFormatterResolver resolver = null)
        {
            return Utf8JsonHelper.Serialize(obj, resolver);
        }

        /// <summary>
        /// To Utf8Json
        /// </summary>
        /// <param name="o"></param>
        /// <param name="resolver"></param>
        /// <returns></returns>
        public static string ToUtf8Json(this object o, IJsonFormatterResolver resolver = null)
        {
            return Utf8JsonHelper.Serialize(o, resolver);
        }

        /// <summary>
        /// To Utf8Json
        /// </summary>
        /// <param name="o"></param>
        /// <param name="type"></param>
        /// <param name="resolver"></param>
        /// <returns></returns>
        public static string ToUtf8Json(this object o, Type type, IJsonFormatterResolver resolver = null)
        {
            return Utf8JsonHelper.Serialize(o, type, resolver);
        }

        /// <summary>
        /// To Utf8Json async
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="resolver"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<string> ToUtf8JsonAsync<T>(this T obj, IJsonFormatterResolver resolver = null)
        {
            return Utf8JsonHelper.SerializeAsync(obj, resolver);
        }

        /// <summary>
        /// To Utf8Json async
        /// </summary>
        /// <param name="o"></param>
        /// <param name="resolver"></param>
        /// <returns></returns>
        public static Task<string> ToUtf8JsonAsync(this object o, IJsonFormatterResolver resolver = null)
        {
            return Utf8JsonHelper.SerializeAsync(o, resolver);
        }

        /// <summary>
        /// To Utf8Json async
        /// </summary>
        /// <param name="o"></param>
        /// <param name="type"></param>
        /// <param name="resolver"></param>
        /// <returns></returns>
        public static Task<string> ToUtf8JsonAsync(this object o, Type type, IJsonFormatterResolver resolver = null)
        {
            return Utf8JsonHelper.SerializeAsync(o, type, resolver);
        }
    }
}