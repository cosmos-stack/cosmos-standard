using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace Cosmos {
    /// <summary>
    /// Extensions for stream
    /// </summary>
    public static class StreamExtensions {
        /// <summary>
        /// Try seek
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="offset"></param>
        /// <param name="origin"></param>
        /// <returns></returns>
        public static long TrySeek(this Stream stream, long offset, SeekOrigin origin)
            => stream.CanSeek ? stream.Seek(offset, origin) : default;

        /// <summary>
        /// Try read
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static int TryRead(this Stream stream, byte[] buffer, int offset, int count)
            => stream.CanRead ? stream.Read(buffer, offset, count) : default;

        /// <summary>
        /// Try read async
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<int> TryReadAsync(this Stream stream, byte[] buffer, int offset, int count, CancellationToken cancellationToken = default)
            => stream.CanRead ? await stream.ReadAsync(buffer, offset, count, cancellationToken) : default;

        /// <summary>
        /// Try read byte
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static int TryReadByte(this Stream stream)
            => stream.CanRead ? stream.ReadByte() : default;

        /// <summary>
        /// Try write
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static bool TryWrite(this Stream stream, byte[] buffer, int offset, int count) {
            if (stream.CanWrite) stream.Write(buffer, offset, count);
            return stream.CanWrite;
        }

        /// <summary>
        /// Try write async
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<bool> TryWriteAsync(this Stream stream, byte[] buffer, int offset, int count, CancellationToken cancellationToken = default) {
            if (stream.CanWrite) await stream.WriteAsync(buffer, offset, count, cancellationToken);
            return stream.CanWrite;
        }

        /// <summary>
        /// Try write byte
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool TryWriteByte(this Stream stream, byte value) {
            if (stream.CanWrite) stream.WriteByte(value);
            return stream.CanWrite;
        }

        /// <summary>
        /// Try set read timeout
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="milliseconds"></param>
        /// <returns></returns>
        public static bool TrySetReadTimeout(this Stream stream, int milliseconds) {
            if (stream.CanTimeout) stream.ReadTimeout = milliseconds;
            return stream.CanTimeout;
        }

        /// <summary>
        /// Try set read timeout
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public static bool TrySetReadTimeout(this Stream stream, TimeSpan timeout)
            => stream.TrySetReadTimeout(timeout.Milliseconds);

        /// <summary>
        /// Try set write timeout
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="milliseconds"></param>
        /// <returns></returns>
        public static bool TrySetWriteTimeout(this Stream stream, int milliseconds) {
            if (stream.CanTimeout) stream.WriteTimeout = milliseconds;
            return stream.CanTimeout;
        }

        /// <summary>
        /// Try set write timeout
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public static bool TrySetWriteTimeout(this Stream stream, TimeSpan timeout)
            => stream.TrySetWriteTimeout(timeout.Milliseconds);
    }
}