using System.Collections.Generic;
using Newtonsoft.Json.Linq;

// ReSharper disable once CheckNamespace
namespace Cosmos.Serialization.Json
{
    public static partial class JTokenConversionExtensions
    {
        /// <summary>
        /// Gets token
        /// </summary>
        /// <param name="token"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static JToken GetToken(this JToken token, string key) => token[key];

        /// <summary>
        /// Gets string
        /// </summary>
        /// <param name="token"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetString(this JToken token, string key) => token[key].ToString();

        /// <summary>
        /// Gets bool
        /// </summary>
        /// <param name="token"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool GetBool(this JToken token, string key) => token[key].ToObject<bool>();

        /// <summary>
        /// Gets int
        /// </summary>
        /// <param name="token"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static int GetInt(this JToken token, string key) => token[key].ToObject<int>();

        /// <summary>
        /// Gets double
        /// </summary>
        /// <param name="token"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static double GetDouble(this JToken token, string key) => token[key].ToObject<double>();

        /// <summary>
        /// Gets list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="token"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static List<T> GetList<T>(this JToken token, string key) => token[key].ToObject<List<T>>();

        /// <summary>
        /// Gets dictionary
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="token"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static Dictionary<TKey, TValue> GetDictionary<TKey, TValue>(this JToken token, string key) => token[key].ToObject<Dictionary<TKey, TValue>>();

        /// <summary>
        /// Gets object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="token"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T GetObject<T>(this JToken token, string key) => token[key].ToObject<T>();
    }
}