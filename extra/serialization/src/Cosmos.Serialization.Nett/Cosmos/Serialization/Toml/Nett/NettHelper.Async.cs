using System;
using System.Threading.Tasks;

namespace Cosmos.Serialization.Toml.Nett {
    /// <summary>
    /// Yaml Helper
    /// </summary>
    public static partial class NettHelper {
        /// <summary>
        /// Serialize async
        /// </summary>
        /// <param name="o"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<string> SerializeAsync<T>(T o) {
            return Task.Run(() => Serialize(o));
        }

        /// <summary>
        /// Serialize to bytes async
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static async Task<byte[]> SerializeToBytesAsync<T>(T o) {
            return o is null
                ? new byte[0]
                : NettManager.DefaultEncoding.GetBytes(await SerializeAsync(o));
        }

        /// <summary>
        /// Deserialize async
        /// </summary>
        /// <param name="data"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<T> DeserializeAsync<T>(string data) {
            return string.IsNullOrWhiteSpace(data)
                ? default
                : await Task.Run(() => Deserialize<T>(data));
        }

        /// <summary>
        /// Deserialize async
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static async Task<object> DeserializeAsync(string data, Type type) {
            return string.IsNullOrWhiteSpace(data)
                ? null
                : await Task.Run(() => Deserialize(data, type));
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="data"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<T> DeserializeFromBytesAsync<T>(byte[] data) {
            return data is null || data.Length is 0
                ? default
                : await DeserializeAsync<T>(NettManager.DefaultEncoding.GetString(data));
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static async Task<object> DeserializeFromBytesAsync(byte[] data, Type type) {
            return data is null || data.Length is 0
                ? null
                : await DeserializeAsync(NettManager.DefaultEncoding.GetString(data), type);
        }
    }
}