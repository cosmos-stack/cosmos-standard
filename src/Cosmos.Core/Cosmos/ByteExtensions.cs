namespace Cosmos;

/// <summary>
/// Byte extensions <br />
/// Byte 扩展
/// </summary>
public static class ByteExtensions
{
    /// <summary>
    /// Gets max one. <br />
    /// 获取大值。
    /// </summary>
    /// <param name="val1"></param>
    /// <param name="val2"></param>
    /// <returns></returns>
    public static byte Max(this byte val1, byte val2) => Math.Max(val1, val2);

    /// <summary>
    /// Gets min one. <br />
    /// 获取小值。
    /// </summary>
    /// <param name="val1"></param>
    /// <param name="val2"></param>
    /// <returns></returns>
    public static byte Min(this byte val1, byte val2) => Math.Min(val1, val2);

    /// <summary>
    /// Resize <br />
    /// 重新设置尺寸
    /// </summary>
    /// <param name="buff"></param>
    /// <param name="newSize"></param>
    /// <returns></returns>
    public static byte[] Resize(this byte[] buff, int newSize)
    {
        Array.Resize(ref buff, newSize);
        return buff;
    }
}