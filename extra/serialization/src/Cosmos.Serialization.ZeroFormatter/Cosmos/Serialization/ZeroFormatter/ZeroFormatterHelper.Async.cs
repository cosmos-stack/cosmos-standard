using System;
using System.Threading.Tasks;
using ZeroFormatter;

namespace Cosmos.Serialization.ZeroFormatter {
    /// <summary>
    /// ZeroFormatter helper
    /// </summary>
    public static partial class ZeroFormatterHelper {
        /// <summary>
        /// Serialize async
        /// </summary>
        /// <param name="o"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<byte[]> SerializeAsync<T>(T o) {
            return o is null
                ? new byte[0]
                : await Task.Run(() => ZeroFormatterSerializer.Serialize(o));
        }

        /// <summary>
        /// Serialize async
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static async Task<byte[]> SerializeAsync(object obj, Type type) {
            return obj is null
                ? new byte[0]
                : await Task.Run(() => ZeroFormatterSerializer.NonGeneric.Serialize(type, obj));
        }

        /// <summary>
        /// Deserialize async
        /// </summary>
        /// <param name="bytes"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<T> DeserializeAsync<T>(byte[] bytes) {
            return bytes is null || bytes.Length == 0
                ? default
                : await Task.Run(() => ZeroFormatterSerializer.Deserialize<T>(bytes));
        }

        /// <summary>
        /// Deserialize async
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static async Task<object> DeserializeAsync(byte[] bytes, Type type) {
            return bytes is null || bytes.Length == 0
                ? null
                : await Task.Run(() => ZeroFormatterSerializer.NonGeneric.Deserialize(type, bytes));
        }
    }
}