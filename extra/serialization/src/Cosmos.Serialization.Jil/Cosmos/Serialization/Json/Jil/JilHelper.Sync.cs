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

namespace Cosmos.Serialization.Json.Jil
{
    /// <summary>
    /// JilJson helper
    /// </summary>
    public static partial class JilHelper
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
            return o == null
                ? string.Empty
                : JSON.Serialize(o, options ?? JilManager.DefaultOptions);
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
            return Serialize(o, options);
        }

        /// <summary>
        /// Serialize to bytes
        /// </summary>
        /// <param name="o"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static byte[] SerializeToBytes<T>(T o, Options options = null)
        {
            return o == null
                ? new byte[0]
                : JilManager.DefaultEncoding.GetBytes(Serialize(o, options ?? JilManager.DefaultOptions));
        }

        /// <summary>
        /// Serialize to bytes
        /// </summary>
        /// <param name="o"></param>
        /// <param name="optionAct"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static byte[] SerializeToBytes<T>(T o, Action<Options> optionAct)
        {
            return o == null
                ? new byte[0]
                : JilManager.DefaultEncoding.GetBytes(Serialize(o, optionAct));
        }

        /// <summary>
        /// Serialize
        /// </summary>
        /// <param name="o"></param>
        /// <param name="output"></param>
        /// <param name="options"></param>
        public static void Serialize(object o, TextWriter output, Options options = null)
        {
            if (o != null)
            {
                JSON.SerializeDynamic(o, output, options ?? JilManager.DefaultOptions);
            }
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
            return string.IsNullOrWhiteSpace(json)
                ? default
                : JSON.Deserialize<T>(json, options ?? JilManager.DefaultOptions);
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
            return string.IsNullOrWhiteSpace(json)
                ? default
                : JSON.Deserialize<T>(json, options);
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
            using var reader = new StringReader(json);
            return Deserialize(reader, type, options ?? JilManager.DefaultOptions);
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
            using var reader = new StringReader(json);
            return Deserialize(reader, type, optionAct);
        }

        /// <summary>
        /// Deserialize from bytes
        /// </summary>
        /// <param name="data"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T DeserializeFromBytes<T>(byte[] data, Options options = null)
        {
            return data is null || data.Length is 0
                ? default
                : JSON.Deserialize<T>(JilManager.DefaultEncoding.GetString(data), options ?? JilManager.DefaultOptions);
        }

        /// <summary>
        /// Deserialize from bytes
        /// </summary>
        /// <param name="data"></param>
        /// <param name="optionAct"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T DeserializeFromBytes<T>(byte[] data, Action<Options> optionAct)
        {
            var options = new Options();
            optionAct?.Invoke(options);
            return DeserializeFromBytes<T>(data, options);
        }

        /// <summary>
        /// Deserialize from bytes
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static object DeserializeFromBytes(byte[] data, Type type, Options options = null)
        {
            return data is null || data.Length is 0
                ? null
                : JSON.Deserialize(JilManager.DefaultEncoding.GetString(data), type, options ?? JilManager.DefaultOptions);
        }

        /// <summary>
        /// Deserialize from bytes
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <param name="optionAct"></param>
        /// <returns></returns>
        public static object DeserializeFromBytes(byte[] data, Type type, Action<Options> optionAct)
        {
            var options = new Options();
            optionAct?.Invoke(options);
            return DeserializeFromBytes(data, type, options);
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Deserialize<T>(TextReader reader, Options options = null)
        {
            return reader == null
                ? default
                : JSON.Deserialize<T>(reader, options ?? JilManager.DefaultOptions);
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="optionAct"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Deserialize<T>(TextReader reader, Action<Options> optionAct)
        {
            var options = new Options();
            optionAct?.Invoke(options);
            return Deserialize<T>(reader, options);
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
            return reader == null
                ? null
                : JSON.Deserialize(reader, type, options ?? JilManager.DefaultOptions);
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