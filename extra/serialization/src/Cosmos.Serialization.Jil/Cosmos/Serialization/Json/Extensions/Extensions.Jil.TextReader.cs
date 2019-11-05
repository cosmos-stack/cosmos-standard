using System;
using System.IO;
using System.Threading.Tasks;
using Jil;
using Cosmos.Serialization.Json.Jil;

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
        /// <param name="reader"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T FromJil<T>(this TextReader reader, Options options = null) => JilHelper.Deserialize<T>(reader, options);

        /// <summary>
        /// From Jil
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="optionsAct"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T FromJil<T>(this TextReader reader, Action<Options> optionsAct) => JilHelper.Deserialize<T>(reader, optionsAct);

        /// <summary>
        /// From Jil
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="type"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static object FromJil(this TextReader reader, Type type, Options options = null) => JilHelper.Deserialize(reader, type, options);

        /// <summary>
        /// From Jil
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="type"></param>
        /// <param name="optionsAct"></param>
        /// <returns></returns>
        public static object FromJil(this TextReader reader, Type type, Action<Options> optionsAct) => JilHelper.Deserialize(reader, type, optionsAct);


        /// <summary>
        /// From Jil async
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<T> FromJilAsync<T>(this TextReader reader, Options options = null) => JilHelper.DeserializeAsync<T>(reader, options);

        /// <summary>
        /// From Jil async
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="optionsAct"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<T> FromJilAsync<T>(this TextReader reader, Action<Options> optionsAct) => JilHelper.DeserializeAsync<T>(reader, optionsAct);

        /// <summary>
        /// From Jil async
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="type"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static Task<object> FromJilAsync(this TextReader reader, Type type, Options options = null) => JilHelper.DeserializeAsync(reader, type, options);

        /// <summary>
        /// From Jil async
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="type"></param>
        /// <param name="optionsAct"></param>
        /// <returns></returns>
        public static Task<object> FromJilAsync(this TextReader reader, Type type, Action<Options> optionsAct) => JilHelper.DeserializeAsync(reader, type, optionsAct);
    }
}