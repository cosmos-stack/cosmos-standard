namespace Cosmos.IO;

/// <summary>
/// File helper <br />
/// 文件工具
/// </summary>
public static class FileHelper
{
    /// <summary>
    /// Read <br />
    /// 读取
    /// </summary>
    /// <param name="targetFilePath"></param>
    /// <returns></returns>
    public static byte[] Read(string targetFilePath)
    {
        if (!File.Exists(targetFilePath))
            return InternalArray.ForEmpty<byte>();

        using var fs = new FileStream(targetFilePath, FileMode.Open, FileAccess.Read);
        var buffer = new byte[fs.Length];
        _ = fs.Read(buffer, 0, buffer.Length);
        return buffer;
    }

    /// <summary>
    /// Read async <br />
    /// 异步读取
    /// </summary>
    /// <param name="targetFilePath"></param>
    /// <returns></returns>
    public static async Task<byte[]> ReadAsync(string targetFilePath)
    {
        if (!File.Exists(targetFilePath))
            return InternalArray.ForEmpty<byte>();

#if NETSTANDARD2_1 || NETCOREAPP3_0_OR_GREATER
        await using var fs = new FileStream(targetFilePath, FileMode.Open, FileAccess.Read);
#else
        using var fs = new FileStream(targetFilePath, FileMode.Open, FileAccess.Read);
#endif

        var buffer = new byte[fs.Length];
        _ = await fs.ReadAsync(buffer, 0, buffer.Length);
        return buffer;
    }

    /// <summary>
    /// Read <br />
    /// 读取
    /// </summary>
    /// <param name="byteArray"></param>
    /// <param name="targetFilePath"></param>
    /// <param name="appendMode"></param>
    /// <returns></returns>
    public static bool Read(byte[] byteArray, string targetFilePath, bool appendMode = false)
    {
        if (string.IsNullOrWhiteSpace(targetFilePath))
            throw new ArgumentNullException(nameof(targetFilePath));
        if (!appendMode && File.Exists(targetFilePath))
            File.Create(targetFilePath);
        var fileMode = appendMode ? FileMode.Append : FileMode.Open;
        using var fs = new FileStream(targetFilePath, fileMode, FileAccess.Write);
        return fs.TryWrite(byteArray, 0, byteArray.Length);
    }

    /// <summary>
    /// Read async <br />
    /// 异步读取
    /// </summary>
    /// <param name="byteArray"></param>
    /// <param name="targetFilePath"></param>
    /// <param name="appendMode"></param>
    /// <returns></returns>
    public static async Task<bool> ReadAsync(byte[] byteArray, string targetFilePath, bool appendMode = false)
    {
        if (string.IsNullOrWhiteSpace(targetFilePath))
            throw new ArgumentNullException(nameof(targetFilePath));
        if (!appendMode && File.Exists(targetFilePath))
            File.Create(targetFilePath);
        var fileMode = appendMode ? FileMode.Append : FileMode.Open;

#if NETSTANDARD2_1 || NETCOREAPP3_0_OR_GREATER
        await using var fs = new FileStream(targetFilePath, fileMode, FileAccess.Write);
#else
        using var fs = new FileStream(targetFilePath, fileMode, FileAccess.Write);
#endif

        return await fs.TryWriteAsync(byteArray, 0, byteArray.Length);
    }
}