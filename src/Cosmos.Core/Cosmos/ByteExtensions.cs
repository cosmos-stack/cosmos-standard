namespace Cosmos;

/// <summary>
/// Byte extensions <br />
/// Byte 扩展
/// </summary>
public static class ByteExtensions
{
    #region Min & Max

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

    #endregion

    #region Resize

    /// <summary>
    /// Resize <br />
    /// 重新设置尺寸
    /// </summary>
    /// <param name="this"></param>
    /// <param name="newSize"></param>
    /// <returns></returns>
    public static byte[] Resize(this byte[] @this, int newSize)
    {
        Array.Resize(ref @this, newSize);
        return @this;
    }

    #endregion

    #region To MemoryStream

    /// <summary>
    /// Convert byte[] to <see cref="MemoryStream"/> <br />
    /// 转换类型，将 <see cref="byte"/>[] 转换为 <see cref="MemoryStream"/>
    /// </summary>
    /// <param name="this"></param>
    /// <returns></returns>
    public static MemoryStream ToMemoryStream(this byte[] @this)
    {
        return new MemoryStream(@this);
    }

    #endregion
}