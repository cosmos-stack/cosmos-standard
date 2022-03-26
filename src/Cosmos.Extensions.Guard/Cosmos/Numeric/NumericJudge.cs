using Cosmos.Conversions.Determiners;

namespace Cosmos.Numeric;

/// <summary>
/// Numeric Judgement <br />
/// 数值判断器
/// </summary>
public static class NumericJudge
{
    /// <summary>
    /// To judge whether the string is short or not. <br />
    /// 判断字符串是否为 <see cref="short"/>
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsInt16(string str) => StringShortDeterminer.Is(str);

    /// <summary>
    /// To judge whether the string is integer or not. <br />
    /// 判断字符串是否为 <see cref="int"/>
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsInt32(string str) => StringIntDeterminer.Is(str);

    /// <summary>
    /// To judge whether the string is long or not. <br />
    /// 判断字符串是否为 <see cref="long"/>
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsInt64(string str) => StringLongDeterminer.Is(str);

    /// <summary>
    /// To judge whether the string is ushort or not. <br />
    /// 判断字符串是否为 <see cref="ushort"/>
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsUInt16(string str) => StringUShortDeterminer.Is(str);

    /// <summary>
    /// To judge whether the string is UInt32 or not. <br />
    /// 判断字符串是否为 <see cref="uint"/>
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsUInt32(string str) => StringUIntDeterminer.Is(str);

    /// <summary>
    /// To judge whether the string is ulong or not. <br />
    /// 判断字符串是否为 <see cref="ulong"/>
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsUInt64(string str) => StringULongDeterminer.Is(str);

    /// <summary>
    /// To judge whether the string is numeric or not. <br />
    /// 判断字符串是否为数字
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNumeric(string str) => StringDecimalDeterminer.Is(str);

    /// <summary>
    /// To judge whether the short value is between left and right. <br />
    /// 判断给定的数值是否包含在左值和右值之间
    /// </summary>
    /// <param name="value"></param>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsBetween(short value, short left, short right) => value >= left && value <= right;

    /// <summary>
    /// To judge whether the int value is between left and right. <br />
    /// 判断给定的数值是否包含在左值和右值之间
    /// </summary>
    /// <param name="value"></param>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsBetween(int value, int left, int right) => value >= left && value <= right;

    /// <summary>
    /// To judge whether the long value is between left and right. <br />
    /// 判断给定的数值是否包含在左值和右值之间
    /// </summary>
    /// <param name="value"></param>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsBetween(long value, long left, long right) => value >= left && value <= right;

    /// <summary>
    /// To judge whether the float value is between left and right. <br />
    /// 判断给定的数值是否包含在左值和右值之间
    /// </summary>
    /// <param name="value"></param>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsBetween(float value, float left, float right) => value >= left && value <= right;

    /// <summary>
    /// To judge whether the double value is between left and right. <br />
    /// 判断给定的数值是否包含在左值和右值之间
    /// </summary>
    /// <param name="value"></param>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsBetween(double value, double left, double right) => value >= left && value <= right;

    /// <summary>
    /// To judge whether the decimal value is between left and right. <br />
    /// 判断给定的数值是否包含在左值和右值之间
    /// </summary>
    /// <param name="value"></param>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsBetween(decimal value, decimal left, decimal right) => value >= left && value <= right;

    /// <summary>
    /// Is NaN <br />
    /// 判断是否为非数值
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNaN(double value) => Numbers.IsNaN(value);

    /// <summary>
    /// Is NaN <br />
    /// 判断是否为非数值
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNaN(float value) => Numbers.IsNaN(value);
}