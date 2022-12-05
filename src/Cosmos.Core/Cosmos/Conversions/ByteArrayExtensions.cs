namespace Cosmos.Conversions;

public static class ByteArrayExtensions
{
    /// <summary>
    /// Convert byte[] to <see cref="MemoryStream"/> <br />
    /// 转换类型，将 <see cref="byte"/>[] 转换为 <see cref="MemoryStream"/>
    /// </summary>
    /// <param name="buff"></param>
    /// <returns></returns>
    public static MemoryStream CastToMemoryStream(this byte[] buff) => new(buff);
}