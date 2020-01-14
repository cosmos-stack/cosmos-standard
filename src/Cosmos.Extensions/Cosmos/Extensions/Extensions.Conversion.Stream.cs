using System.IO;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace Cosmos {
    /// <summary>
    /// Conversion extensions
    /// </summary>
    public static partial class ConversionExtensions {
        /// <summary>
        /// Convert stream to bytes
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static byte[] CastToBytes(this Stream stream) {
            var bytes = new byte[stream.Length];
            
            if (stream.CanSeek && stream.Position > 0)
                stream.Seek(0, SeekOrigin.Begin);

            stream.Read(bytes, 0, bytes.Length);

            if (stream.CanSeek)
                stream.Seek(0, SeekOrigin.Begin);

            return bytes;
        }

        /// <summary>
        /// Convert stream to bytes async
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static async Task<byte[]> CastToBytesAsync(this Stream stream) {
            var bytes = new byte[stream.Length];

            if (stream.Position > 0 && stream.CanSeek)
                stream.Seek(0, SeekOrigin.Begin);

            await stream.ReadAsync(bytes, 0, bytes.Length);

            if (stream.CanSeek)
                stream.Seek(0, SeekOrigin.Begin);

            return bytes;
        }
    }
}