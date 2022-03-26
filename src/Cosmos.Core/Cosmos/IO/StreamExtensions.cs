namespace Cosmos.IO;

/// <summary>
/// Cosmos.Core <see cref="Stream"/> extensions. <br />
/// 流扩展
/// </summary>
public static class StreamExtensions
{
    #region Seek

    /// <summary>
    /// Try seek <br />
    /// 尝试根据给定的偏移量定位
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="offset"></param>
    /// <param name="origin"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static long TrySeek(this Stream stream, long offset, SeekOrigin origin)
        => stream.CanSeek ? stream.Seek(offset, origin) : default;

    #endregion

    #region Read

    /// <summary>
    /// Read all bytes <br />
    /// 读取所有字节
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
                        Buffer.BlockCopy(readBuffer,0, temp, 0, readBuffer.Length);
                        Buffer.SetByte(temp,totalBytesRead, (byte) nextByte);
                        readBuffer = temp;
                        totalBytesRead++;
                    }
                }
            }

            var buffer = readBuffer;
            if (readBuffer.Length != totalBytesRead)
            {
                buffer = new byte[totalBytesRead];
                Buffer.BlockCopy(readBuffer,0, buffer, 0, totalBytesRead);
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
    /// Try read <br />
    /// 尝试读取
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="buffer"></param>
    /// <param name="offset"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int TryRead(this Stream stream, byte[] buffer, int offset, int count)
        => stream.CanRead ? stream.Read(buffer, offset, count) : default;

    /// <summary>
    /// Try read async <br />
    /// 尝试异步读取
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="buffer"></param>
    /// <param name="offset"></param>
    /// <param name="count"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<int> TryReadAsync(this Stream stream, byte[] buffer, int offset, int count, CancellationToken cancellationToken = default)
        => stream.CanRead ? await stream.ReadAsync(buffer, offset, count, cancellationToken) : default;

    /// <summary>
    /// Try read byte <br />
    /// 尝试读取字节
    /// </summary>
    /// <param name="stream"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int TryReadByte(this Stream stream)
        => stream.CanRead ? stream.ReadByte() : default;

    /// <summary>
    /// Try set read timeout <br />
    /// 尝试为读取设置超时时间
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="milliseconds"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TrySetReadTimeout(this Stream stream, int milliseconds)
    {
        if (stream.CanTimeout) stream.ReadTimeout = milliseconds;
        return stream.CanTimeout;
    }

    /// <summary>
    /// Try set read timeout <br />
    /// 尝试为读取设置超时时间
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="timeout"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TrySetReadTimeout(this Stream stream, TimeSpan timeout)
        => stream.TrySetReadTimeout(timeout.Milliseconds);

    #endregion

    #region Write

    /// <summary>
    /// Try write <br />
    /// 尝试写入
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="buffer"></param>
    /// <param name="offset"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryWrite(this Stream stream, byte[] buffer, int offset, int count)
    {
        if (stream.CanWrite) stream.Write(buffer, offset, count);
        return stream.CanWrite;
    }

    /// <summary>
    /// Try write async <br />
    /// 尝试异步写入
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="buffer"></param>
    /// <param name="offset"></param>
    /// <param name="count"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<bool> TryWriteAsync(this Stream stream, byte[] buffer, int offset, int count, CancellationToken cancellationToken = default)
    {
        if (stream.CanWrite) await stream.WriteAsync(buffer, offset, count, cancellationToken);
        return stream.CanWrite;
    }

    /// <summary>
    /// Try write byte <br />
    /// 尝试写入字节
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryWriteByte(this Stream stream, byte value)
    {
        if (stream.CanWrite) stream.WriteByte(value);
        return stream.CanWrite;
    }

    /// <summary>
    /// Try set write timeout <br />
    /// 尝试为写入设置超时时间
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="milliseconds"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TrySetWriteTimeout(this Stream stream, int milliseconds)
    {
        if (stream.CanTimeout) stream.WriteTimeout = milliseconds;
        return stream.CanTimeout;
    }

    /// <summary>
    /// Try set write timeout <br />
    /// 尝试为写入设置超时时间
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="timeout"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TrySetWriteTimeout(this Stream stream, TimeSpan timeout)
        => stream.TrySetWriteTimeout(timeout.Milliseconds);

    #endregion
}