using System;
using System.IO;
using Jil;

/*
 * Reference to:
 *      Mutuduxf/Zaabee.Serializers
 *          Author: Mutuduxf
 *          Url:    https://github.com/Mutuduxf/Zaabee.Serializers
 *          MIT
 */

namespace Cosmos.Jil
{
    /// <summary>
    /// JilJson helper
    /// </summary>
    public static class JilHelper
    {
        /// <summary>
        /// Serialize
        /// </summary>
        /// <param name="o"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string Serialize<T>(T o, Options options = null)
        {
            return JSON.Serialize(o, options);
        }

        /// <summary>
        /// Serialize
        /// </summary>
        /// <param name="o"></param>
        /// <param name="optionAct"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string Serialize<T>(T o, Action<Options> optionAct)
        {
            var options = new Options();
            optionAct?.Invoke(options);
            return JSON.Serialize(o, options);
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="json"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Deserialize<T>(string json, Options options = null)
        {
            return string.IsNullOrWhiteSpace(json) ? default : JSON.Deserialize<T>(json, options);
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="json"></param>
        /// <param name="optionAct"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Deserialize<T>(string json, Action<Options> optionAct)
        {
            var options = new Options();
            optionAct?.Invoke(options);
            return string.IsNullOrWhiteSpace(json) ? default : JSON.Deserialize<T>(json, options);
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="json"></param>
        /// <param name="type"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static object Deserialize(string json, Type type, Options options = null)
        {
            if (string.IsNullOrWhiteSpace(json))
                return null;
            using (var reader = new StringReader(json))
            {
                return Deserialize(reader, type, options);
            }
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="json"></param>
        /// <param name="type"></param>
        /// <param name="optionAct"></param>
        /// <returns></returns>
        public static object Deserialize(string json, Type type, Action<Options> optionAct)
        {
            if (string.IsNullOrWhiteSpace(json))
                return null;
            using (var reader = new StringReader(json))
            {
                return Deserialize(reader, type, optionAct);
            }
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="type"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static object Deserialize(TextReader reader, Type type, Options options = null)
        {
            return reader == null ? null : JSON.Deserialize(reader, type, options);
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="type"></param>
        /// <param name="optionAct"></param>
        /// <returns></returns>
        public static object Deserialize(TextReader reader, Type type, Action<Options> optionAct)
        {
            var options = new Options();
            optionAct?.Invoke(options);
            return reader == null ? null : JSON.Deserialize(reader, type, options);
        }
    }
}