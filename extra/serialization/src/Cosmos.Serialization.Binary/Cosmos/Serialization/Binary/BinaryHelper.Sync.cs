using System.IO;
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
        public static byte[] Serialize(object obj) {
            using var stream = Pack(obj);
            return stream.StreamToBytes();
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="bytes"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Deserialize<T>(byte[] bytes) {
            return (T) Deserialize(bytes);
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static object Deserialize(byte[] bytes) {
            if (bytes is null || bytes.Length is 0) return default;
            using var ms = new MemoryStream(bytes);
            return Unpack(ms);
        }
    }
}