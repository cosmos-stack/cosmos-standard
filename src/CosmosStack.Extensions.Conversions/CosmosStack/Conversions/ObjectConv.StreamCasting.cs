using System.IO;
using System.Threading.Tasks;

namespace CosmosStack.Conversions
{
    /// <summary>
    /// CosmosStack <see cref="Stream"/> extensions.
    /// </summary>
    public static class StreamCastingExtensions
    {
        /// <summary>
        /// Convert <see cref="Stream"/> to <see cref="byte"/> array. <br />
        /// 将 <see cref="Stream"/> 转换为 <see cref="byte"/> 数组。
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static byte[] CastToBytes(this Stream stream)
        {
            var bytes = new byte[stream.Length];

            if (stream.CanSeek && stream.Position > 0)
                stream.Seek(0, SeekOrigin.Begin);

            stream.Read(bytes, 0, bytes.Length);

            if (stream.CanSeek)
                stream.Seek(0, SeekOrigin.Begin);

            return bytes;
        }

        /// <summary>
        /// Convert <see cref="Stream"/> to <see cref="byte"/> array async. <br />
        /// 将 <see cref="Stream"/> 异步地转换为 <see cref="byte"/> 数组。
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static async Task<byte[]> CastToBytesAsync(this Stream stream)
        {
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