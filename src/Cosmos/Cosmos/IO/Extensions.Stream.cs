using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Cosmos.Collections;

namespace Cosmos.IO
{
    /// <summary>
    /// Extensions for stream
    /// </summary>
    public static class StreamExtensions
    {
        #region Seek

        /// <summary>
        /// Try seek
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="offset"></param>
        /// <param name="origin"></param>
        /// <returns></returns>
        public static long TrySeek(this Stream stream, long offset, SeekOrigin origin)
            => stream.CanSeek ? stream.Seek(offset, origin) : default;

        #endregion

        #region Read

        /// <summary>
        /// Read all bytes
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static byte[] ReadAllBytes(this Stream stream)
        {
            long originalPosition = 0;

            if (stream.CanSeek)
            {
                originalPosition = stream.Position;
                stream.Position = 0;
            }

            try
            {
                var readBuffer = new byte[4096];

                var totalBytesRead = 0;
                int bytesRead;

                while ((bytesRead = stream.Read(readBuffer, totalBytesRead, readBuffer.Length - totalBytesRead)) > 0)
                {
                    totalBytesRead += bytesRead;

                    if (totalBytesRead == readBuffer.Length)
                    {
                        var nextByte = stream.ReadByte();
                        if (nextByte != -1)
                        {
                            var temp = new byte[readBuffer.Length * 2];
                            readBuffer.BlockCopy(0, temp, 0, readBuffer.Length);
                            temp.SetByte(totalBytesRead, (byte) nextByte);
                            readBuffer = temp;
                            totalBytesRead++;
                        }
                    }
                }

                var buffer = readBuffer;
                if (readBuffer.Length != totalBytesRead)
                {
                    buffer = new byte[totalBytesRead];
                    readBuffer.BlockCopy(0, buffer, 0, totalBytesRead);
                }

                return buffer;
            }
            finally
            {
                if (stream.CanSeek)
                {
                    stream.Position = originalPosition;
                }
            }
        }

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
        /// Try set read timeout
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="milliseconds"></param>
        /// <returns></returns>
        public static bool TrySetReadTimeout(this Stream stream, int milliseconds)
        {
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

        #endregion

        #region Write

        /// <summary>
        /// Try write
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static bool TryWrite(this Stream stream, byte[] buffer, int offset, int count)
        {
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
        public static async Task<bool> TryWriteAsync(this Stream stream, byte[] buffer, int offset, int count, CancellationToken cancellationToken = default)
        {
            if (stream.CanWrite) await stream.WriteAsync(buffer, offset, count, cancellationToken);
            return stream.CanWrite;
        }

        /// <summary>
        /// Try write byte
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool TryWriteByte(this Stream stream, byte value)
        {
            if (stream.CanWrite) stream.WriteByte(value);
            return stream.CanWrite;
        }

        /// <summary>
        /// Try set write timeout
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="milliseconds"></param>
        /// <returns></returns>
        public static bool TrySetWriteTimeout(this Stream stream, int milliseconds)
        {
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

        #endregion
    }
}