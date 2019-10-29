using System;
using System.IO;
using System.Threading.Tasks;
using Jil;

namespace Cosmos.Serialization.Json.Jil
{
    /// <summary>
    /// JilJson helper
    /// </summary>
    public static partial class JilHelper
    {
        /// <summary>
        /// Serialize async
        /// </summary>
        /// <param name="o"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<string> SerializeAsync<T>(T o, Options options = null)
        {
            return o == null
                ? string.Empty
                : await Task.Run(() => JSON.Serialize(o, options ?? JilManager.DefaultOptions));
        }

        /// <summary>
        /// Serialize async
        /// </summary>
        /// <param name="o"></param>
        /// <param name="optionAct"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<string> SerializeAsync<T>(T o, Action<Options> optionAct)
        {
            var options = new Options();
            optionAct?.Invoke(options);
            return SerializeAsync(o, options);
        }

        /// <summary>
        /// Serialize to bytes async
        /// </summary>
        /// <param name="o"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<byte[]> SerializeToBytesAsync<T>(T o, Options options = null)
        {
            return o == null
                ? new byte[0]
                : JilManager.DefaultEncoding.GetBytes(await SerializeAsync(o, options));
        }

        /// <summary>
        /// Serialize to bytes async
        /// </summary>
        /// <param name="o"></param>
        /// <param name="optionAct"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<byte[]> SerializeToBytesAsync<T>(T o, Action<Options> optionAct)
        {
            var options = new Options();
            optionAct?.Invoke(options);
            return SerializeToBytesAsync(o, options);
        }

        /// <summary>
        /// Serialize async
        /// </summary>
        /// <param name="o"></param>
        /// <param name="output"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task SerializeAsync<T>(T o, TextWriter output, Options options = null)
        {
            if (o != null)
            {
                await Task.Run(() => JSON.Serialize(o, output, options ?? JilManager.DefaultOptions));
            }
        }

        /// <summary>
        /// Serialize async
        /// </summary>
        /// <param name="o"></param>
        /// <param name="output"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static async Task SerializeAsync(object o, TextWriter output, Options options = null)
        {
            if (o != null)
            {
                await Task.Run(() => JSON.SerializeDynamic(o, output, options ?? JilManager.DefaultOptions));
            }
        }

        /// <summary>
        /// Deserialize async
        /// </summary>
        /// <param name="json"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<T> DeserializeAsync<T>(string json, Options options = null)
        {
            return string.IsNullOrWhiteSpace(json)
                ? default
                : await Task.Run(() => JSON.Deserialize<T>(json, options ?? JilManager.DefaultOptions));
        }

        /// <summary>
        /// Deserialize async
        /// </summary>
        /// <param name="json"></param>
        /// <param name="optionAct"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<T> DeserializeAsync<T>(string json, Action<Options> optionAct)
        {
            var options = new Options();
            optionAct?.Invoke(options);
            return string.IsNullOrWhiteSpace(json)
                ? default
                : await DeserializeAsync<T>(json, options);
        }

        /// <summary>
        /// Deserialize async
        /// </summary>
        /// <param name="json"></param>
        /// <param name="type"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static async Task<object> DeserializeAsync(string json, Type type, Options options = null)
        {
            if (string.IsNullOrWhiteSpace(json))
                return null;

            using (var reader = new StringReader(json))
            {
                return await Task.Run(() => JSON.Deserialize(reader, type, options ?? JilManager.DefaultOptions));
            }
        }

        /// <summary>
        /// Deserialize async
        /// </summary>
        /// <param name="json"></param>
        /// <param name="type"></param>
        /// <param name="optionAct"></param>
        /// <returns></returns>
        public static Task<object> DeserializeAsync(string json, Type type, Action<Options> optionAct)
        {
            if (string.IsNullOrWhiteSpace(json))
                return null;

            var options = new Options();
            optionAct?.Invoke(options);

            return DeserializeAsync(json, type, options);
        }

        /// <summary>
        /// Deserialize from bytes async
        /// </summary>
        /// <param name="data"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<T> DeserializeFromBytesAsync<T>(byte[] data, Options options = null)
        {
            return data is null || data.Length is 0
                ? default
                : await Task.Run(() => JSON.Deserialize<T>(JilManager.DefaultEncoding.GetString(data), options ?? JilManager.DefaultOptions));
        }

        /// <summary>
        /// Deserialize from bytes async
        /// </summary>
        /// <param name="data"></param>
        /// <param name="optionAct"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<T> DeserializeFromBytesAsync<T>(byte[] data, Action<Options> optionAct)
        {
            var options = new Options();
            optionAct?.Invoke(options);
            return DeserializeFromBytesAsync<T>(data, options);
        }

        /// <summary>
        /// Deserialize from bytes async
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static async Task<object> DeserializeFromBytesAsync(byte[] data, Type type, Options options = null)
        {
            return data is null || data.Length is 0
                ? default
                : await Task.Run(() => JSON.Deserialize(JilManager.DefaultEncoding.GetString(data), type, options ?? JilManager.DefaultOptions));
        }

        /// <summary>
        /// Deserialize from bytes async
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <param name="optionAct"></param>
        /// <returns></returns>
        public static Task<object> DeserializeFromBytesAsync(byte[] data, Type type, Action<Options> optionAct)
        {
            var options = new Options();
            optionAct?.Invoke(options);
            return DeserializeFromBytesAsync(data, type, options);
        }

        /// <summary>
        /// Deserialize async
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<T> DeserializeAsync<T>(TextReader reader, Options options = null)
        {
            return reader is null
                ? default
                : await Task.Run(() => JSON.Deserialize<T>(reader, options ?? JilManager.DefaultOptions));
        }

        /// <summary>
        /// Deserialize async
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="optionAct"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<T> DeserializeAsync<T>(TextReader reader, Action<Options> optionAct)
        {
            var options = new Options();
            optionAct?.Invoke(options);

            return DeserializeAsync<T>(reader, options);
        }

        /// <summary>
        /// Deserialize async
        /// </summary>
        /// <param name="type"></param>
        /// <param name="reader"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static async Task<object> DeserializeAsync(TextReader reader, Type type, Options options = null)
        {
            return reader is null
                ? default(Type)
                : await Task.Run(() => JSON.Deserialize(reader, type, options ?? JilManager.DefaultOptions));
        }

        /// <summary>
        /// Deserialize async
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="type"></param>
        /// <param name="optionAct"></param>
        /// <returns></returns>
        public static Task<object> DeserializeAsync(TextReader reader, Type type, Action<Options> optionAct)
        {
            var options = new Options();
            optionAct?.Invoke(options);

            return DeserializeAsync(reader, type, options);
        }
    }
}