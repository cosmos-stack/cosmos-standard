using System;
using System.IO;
using Swifter.Json;

namespace Cosmos.Serialization.Json.Swifter
{
    /// <summary>
    /// SwiftJson Helper
    /// </summary>
    public static partial class SwifterHelper
    {
        /// <summary>
        /// Serialize
        /// </summary>
        /// <param name="o"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string Serialize<T>(T o, JsonFormatterOptions? options = null)
        {
            return o is null
                ? string.Empty
                : JsonFormatter.SerializeObject(o, TouchSerializeOptions(options));
        }

        /// <summary>
        /// Serialize to bytes
        /// </summary>
        /// <param name="o"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static byte[] SerializeToBytes<T>(T o, JsonFormatterOptions? options = null)
        {
            return SwifterJsonManager.DefaultEncoding.GetBytes(Serialize(o, options));
        }

        /// <summary>
        /// Serialize
        /// </summary>
        /// <param name="o"></param>
        /// <param name="output"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        public static void Serialize<T>(T o, TextWriter output, JsonFormatterOptions? options = null)
        {
            JsonFormatter.SerializeObject(o, output, TouchSerializeOptions(options));
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="json"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Deserialize<T>(string json, JsonFormatterOptions? options = null)
        {
            return string.IsNullOrWhiteSpace(json)
                ? default
                : JsonFormatter.DeserializeObject<T>(json, TouchDeserializeOptions(options));
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="json"></param>
        /// <param name="type"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static object Deserialize(string json, Type type, JsonFormatterOptions? options = null)
        {
            return string.IsNullOrWhiteSpace(json)
                ? null
                : JsonFormatter.DeserializeObject(json, type, TouchDeserializeOptions(options));
        }

        /// <summary>
        /// Deserialize from bytes
        /// </summary>
        /// <param name="data"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T DeserializeFromBytes<T>(byte[] data, JsonFormatterOptions? options = null)
        {
            return data is null || data.Length is 0
                ? default
                : Deserialize<T>(SwifterJsonManager.DefaultEncoding.GetString(data), TouchDeserializeOptions(options));
        }

        /// <summary>
        /// Deserialize from bytes
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static object DeserializeFromBytes(byte[] data, Type type, JsonFormatterOptions? options = null)
        {
            return data is null || data.Length is 0
                ? null
                : Deserialize(SwifterJsonManager.DefaultEncoding.GetString(data), type, TouchDeserializeOptions(options));
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Deserialize<T>(TextReader reader, JsonFormatterOptions? options = null)
        {
            return reader == null
                ? default
                : JsonFormatter.DeserializeObject<T>(reader, TouchDeserializeOptions(options));
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="type"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static object Deserialize(TextReader reader, Type type, JsonFormatterOptions? options = null)
        {
            return reader == null
                ? null
                : JsonFormatter.DeserializeObject(reader, type, TouchDeserializeOptions(options));
        }

        private static JsonFormatterOptions TouchSerializeOptions(JsonFormatterOptions? options = null)
        {
            return options ?? SwifterJsonManager.DefaultOptions;
        }

        private static JsonFormatterOptions TouchDeserializeOptions(JsonFormatterOptions? options = null)
        {
            return options ?? SwifterJsonManager.DefaltDeserializeOptions;
        }
    }
}