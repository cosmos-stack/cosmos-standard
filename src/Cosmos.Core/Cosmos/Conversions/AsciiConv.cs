namespace Cosmos.Conversions;

/// <summary>
/// ASCII Conv Helper (internal)
/// </summary>
internal static class AsciiConvHelper
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static byte CharToAscii(char @char)
    {
        return (byte) @char;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static byte[] StringToAscii(string @string)
    {
        return Encoding.ASCII.GetBytes(@string);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static char AsciiToChar(byte @byte)
    {
        return (char) @byte;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string AsciiToString(byte[] bytes)
    {
        return Encoding.ASCII.GetString(bytes, 0, bytes.Length);
    }
}

/// <summary>
/// ASCII Conv <br />
/// ASCII 转换工具
/// </summary>
public static class AsciiConv
{
    /// <summary>
    /// Convert from bytes to ASCII <see cref="string"/>. <br />
    /// 从字节转换为 ASCII
    /// </summary>
    /// <example>in: new byte[] {65, 66, 67}; out: ABC</example>
    /// <param name="bytes"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string BytesToAsciiString(byte[] bytes)
    {
        return AsciiConvHelper.AsciiToString(bytes);
    }

    /// <summary>
    /// Convert from ASCII <see cref="string"/> to bytes. <br />
    /// 从 ASCII 转换为字节
    /// </summary>
    /// <example>in: ABC; out: new byte[] {65, 66, 67}</example>
    /// <param name="asciiStr"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static byte[] AsciiStringToBytes(string asciiStr)
    {
        return AsciiConvHelper.StringToAscii(asciiStr);
    }
}