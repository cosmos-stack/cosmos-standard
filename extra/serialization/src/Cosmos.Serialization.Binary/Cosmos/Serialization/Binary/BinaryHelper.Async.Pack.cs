using System.IO;
using System.Threading.Tasks;

namespace Cosmos.Serialization.Binary {
    /// <summary>
    /// Binary helper
    /// </summary>
    public static partial class BinaryHelper {
        /// <summary>
        /// Pack async
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static async Task<Stream> PackAsync(object obj) {
            var ms = new MemoryStream();

            if (obj != null)
                await PackAsync(obj, ms);

            return ms;
        }

        /// <summary>
        /// Pack async
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="stream"></param>
        public static async Task PackAsync(object obj, Stream stream) {
            if (obj is null)
                return;
            await Task.Run(() => BinaryManager.GetBinaryFormatter().Serialize(stream, obj));
        }

        /// <summary>
        /// Unpack async
        /// </summary>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<T> UnpackAsync<T>(Stream stream) {
            return (T) await UnpackAsync(stream);
        }

        /// <summary>
        /// Unpack async
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static async Task<object> UnpackAsync(Stream stream) {
            if (stream is null || stream.Length is 0)
                return null;

            if (stream.CanSeek && stream.Position > 0)
                stream.Position = 0;

            return await Task.Run(() => BinaryManager.GetBinaryFormatter().Deserialize(stream));
        }

        private static async Task<byte[]> StreamToBytesAsync(Stream stream) {
            var bytes = new byte[stream.Length];

            if (stream.CanSeek && stream.Position > 0)
                stream.Seek(0, SeekOrigin.Begin);

            await stream.ReadAsync(bytes, 0, bytes.Length);

            if (stream.CanSeek)
                stream.Seek(0, SeekOrigin.Begin);

            return bytes;
        }
    }
}