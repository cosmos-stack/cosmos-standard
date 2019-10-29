using System;
using System.IO;
using System.Threading.Tasks;
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
        public static async Task<string> SerializeAsync<T>(T o, JsonFormatterOptions? options = null)
        {
            return o is null
                ? string.Empty
                : await Task.Run(() => JsonFormatter.SerializeObject(o, TouchSerializeOptions(options)));
        }

        /// <summary>
        /// Serialize to bytes
        /// </summary>
        /// <param name="o"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<byte[]> SerializeToBytesAsync<T>(T o, JsonFormatterOptions? options = null)
        {
            return SwifterJsonManager.DefaultEncoding.GetBytes(await SerializeAsync(o, options));
        }

        /// <summary>
        /// Serialize
        /// </summary>
        /// <param name="o"></param>
        /// <param name="output"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        public static Task SerializeAsync<T>(T o, TextWriter output, JsonFormatterOptions? options = null)
        {
            return JsonFormatter.SerializeObjectAsync(o, output, TouchSerializeOptions(options));
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="json"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<T> DeserializeAsync<T>(string json, JsonFormatterOptions? options = null)
        {
            return string.IsNullOrWhiteSpace(json)
                ? default
                : await Task.Run(() => JsonFormatter.DeserializeObject<T>(json, TouchDeserializeOptions(options)));
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="json"></param>
        /// <param name="type"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static async Task<object> DeserializeAsync(string json, Type type, JsonFormatterOptions? options = null)
        {
            return string.IsNullOrWhiteSpace(json)
                ? null
                : await Task.Run(() => JsonFormatter.DeserializeObject(json, type, TouchDeserializeOptions(options)));
        }

        /// <summary>
        /// Deserialize from bytes
        /// </summary>
        /// <param name="data"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<T> DeserializeFromBytesAsync<T>(byte[] data, JsonFormatterOptions? options = null)
        {
            return data is null || data.Length is 0
                ? default
                : await DeserializeAsync<T>(SwifterJsonManager.DefaultEncoding.GetString(data), TouchDeserializeOptions(options));
        }

        /// <summary>
        /// Deserialize from bytes
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static async Task<object> DeserializeFromBytesAsync(byte[] data, Type type, JsonFormatterOptions? options = null)
        {
            return data is null || data.Length is 0
                ? null
                : await DeserializeAsync(SwifterJsonManager.DefaultEncoding.GetString(data), type, TouchDeserializeOptions(options));
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<T> DeserializeAsync<T>(TextReader reader, JsonFormatterOptions? options = null)
        {
            return reader == null
                ? default
                : JsonFormatter.DeserializeObjectAsync<T>(reader, TouchDeserializeOptions(options));
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="type"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static Task<object> DeserializeAsync(TextReader reader, Type type, JsonFormatterOptions? options = null)
        {
            return reader == null
                ? null
                : JsonFormatter.DeserializeObjectAsync(reader, type, TouchDeserializeOptions(options));
        }
    }
}