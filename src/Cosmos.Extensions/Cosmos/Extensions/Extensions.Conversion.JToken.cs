using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    /// <summary>
    /// JToken conversion extensions
    /// </summary>
    public static partial class JTokenConversionExtensions
    {
        /// <summary>
        /// To int
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static int ToInt(this JToken token)
        {
            return token?.ToObject<int>() ?? default(int);
        }

        /// <summary>
        /// To int
        /// </summary>
        /// <param name="token"></param>
        /// <param name="sectionName"></param>
        /// <returns></returns>
        public static int ToInt(this JToken token, string sectionName)
        {
            return token[sectionName]?.ToObject<int>() ?? default(int);
        }

        /// <summary>
        /// To long
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static long ToLong(this JToken token)
        {
            return token?.ToObject<long>() ?? default(long);
        }

        /// <summary>
        /// To long
        /// </summary>
        /// <param name="token"></param>
        /// <param name="sectionName"></param>
        /// <returns></returns>
        public static long ToLong(this JToken token, string sectionName)
        {
            return token[sectionName]?.ToObject<long>() ?? default(long);
        }

        /// <summary>
        /// To double
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static double ToDouble(this JToken token)
        {
            return token?.ToObject<double>() ?? default(double);
        }

        /// <summary>
        /// To double
        /// </summary>
        /// <param name="token"></param>
        /// <param name="sectionName"></param>
        /// <returns></returns>
        public static double ToDouble(this JToken token, string sectionName)
        {
            return token[sectionName]?.ToObject<double>() ?? default(double);
        }

        /// <summary>
        /// To float
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static float ToFloat(this JToken token)
        {
            return token?.ToObject<float>() ?? default(float);
        }

        /// <summary>
        /// To float
        /// </summary>
        /// <param name="token"></param>
        /// <param name="sectionName"></param>
        /// <returns></returns>
        public static float ToFloat(this JToken token, string sectionName)
        {
            return token[sectionName]?.ToObject<float>() ?? default(float);
        }

        /// <summary>
        /// To list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="token"></param>
        /// <returns></returns>
        public static List<T> ToList<T>(this JToken token)
        {
            return token?.ToObject<List<T>>();
        }

        /// <summary>
        /// To list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="token"></param>
        /// <param name="sectionName"></param>
        /// <returns></returns>
        public static List<T> ToList<T>(this JToken token, string sectionName)
        {
            return token[sectionName]?.ToObject<List<T>>();
        }

        /// <summary>
        /// To enumerable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="token"></param>
        /// <returns></returns>
        public static IEnumerable<T> ToEnumerable<T>(this JToken token)
        {
            return token?.ToObject<IEnumerable<T>>();
        }

        /// <summary>
        /// To enumerable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="token"></param>
        /// <param name="sectionName"></param>
        /// <returns></returns>
        public static IEnumerable<T> ToEnumerable<T>(this JToken token, string sectionName)
        {
            return token[sectionName]?.ToObject<IEnumerable<T>>();
        }

        /// <summary>
        /// To dictionary
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <param name="token"></param>
        /// <returns></returns>
        public static Dictionary<T, K> ToDictionary<T, K>(this JToken token)
        {
            return token?.ToObject<Dictionary<T, K>>();
        }

        /// <summary>
        /// To dictionary
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <param name="token"></param>
        /// <param name="sectionName"></param>
        /// <returns></returns>
        public static Dictionary<T, K> ToDictionary<T, K>(this JToken token, string sectionName)
        {
            return token[sectionName]?.ToObject<Dictionary<T, K>>();
        }

        /// <summary>
        /// To dateime
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this JToken token)
        {
            return token?.ToObject<DateTime>() ?? default(DateTime);
        }

        /// <summary>
        /// To datetime
        /// </summary>
        /// <param name="token"></param>
        /// <param name="sectionName"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this JToken token, string sectionName)
        {
            return token[sectionName]?.ToObject<DateTime>() ?? default(DateTime);
        }

        /// <summary>
        /// To guid
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static Guid ToGuid(this JToken token)
        {
            return token?.ToObject<Guid>() ?? default(Guid);
        }

        /// <summary>
        /// To guid
        /// </summary>
        /// <param name="token"></param>
        /// <param name="sectionName"></param>
        /// <returns></returns>
        public static Guid ToGuid(this JToken token, string sectionName)
        {
            return token[sectionName]?.ToObject<Guid>() ?? default(Guid);
        }
    }
}