using System.IO;
using System.Threading.Tasks;
using Cosmos.IO;

namespace Cosmos.Serialization.Binary {
    /// <summary>
    /// Binary helper
    /// </summary>
    public static partial class BinaryHelper {
        /// <summary>
        /// Serialize
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static async Task<byte[]> SerializeAsync(object obj) {
            using var stream = await PackAsync(obj);
            return await stream.StreamToBytesAsync();
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="bytes"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<T> DeserializeAsync<T>(byte[] bytes) {
            return (T) await DeserializeAsync(bytes);
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static async Task<object> DeserializeAsync(byte[] bytes) {
            if (bytes is null || bytes.Length is 0)
                return default;

            using var ms = new MemoryStream(bytes);
            return await UnpackAsync(ms);
        }
    }
}