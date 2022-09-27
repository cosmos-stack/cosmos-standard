﻿using Cosmos.Conversions.StringDeterminers;

namespace Cosmos.Date;

/// <summary>
/// DateInfo <br />
/// 日期信息
/// </summary>
public partial class DateInfo
{
    /// <summary>
    /// Try convert string to <see cref="DateInfo"/> <br />
    /// 尝试将字符串转换为 <see cref="DateInfo"/>
    /// </summary>
    /// <param name="s"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(string s, out DateInfo result)
        => DateInfoParse.TryParse(s, DateTimeFormatInfo.CurrentInfo, DateTimeStyles.None, out result);

    /// <summary>
    /// Try convert string to <see cref="DateInfo"/> <br />
    /// 尝试将字符串转换为 <see cref="DateInfo"/>
    /// </summary>
    /// <param name="s"></param>
    /// <param name="provider"></param>
    /// <param name="styles"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(string s, IFormatProvider provider, DateTimeStyles styles, out DateInfo result)
        => DateInfoParse.TryParse(s, DateTimeFormatInfo.GetInstance(provider), styles, out result);

    /// <summary>
    /// Try convert string to <see cref="DateInfo"/> <br />
    /// 尝试将字符串转换为 <see cref="DateInfo"/>
    /// </summary>
    /// <param name="s"></param>
    /// <param name="format"></param>
    /// <param name="provider"></param>
    /// <param name="styles"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParseExact(string s, string format, IFormatProvider provider, DateTimeStyles styles, out DateInfo result)
        => DateInfoParse.TryParseExact(s, format, DateTimeFormatInfo.GetInstance(provider), styles, out result);

    /// <summary>
    /// Try convert string to <see cref="DateInfo"/> <br />
    /// 尝试将字符串转换为 <see cref="DateInfo"/>
    /// </summary>
    /// <param name="s"></param>
    /// <param name="formats"></param>
    /// <param name="provider"></param>
    /// <param name="styles"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParseExact(string s, string[] formats, IFormatProvider provider, DateTimeStyles styles, out DateInfo result)
        => DateInfoParse.TryParseExactMultiple(s, formats, DateTimeFormatInfo.GetInstance(provider), styles, out result);

    private static Func<object, bool> StringConvBeHandler => o =>
    {
        if (o is string str)
            return StringDateInfoDeterminer.Is(str);
        return false;
    };

    private static Func<object, object> StringConvToHandler => o =>
    {
        if (o is string str)
            return StringDateInfoDeterminer.To(str);
        return default(DateInfo);
    };
}

internal static class DateInfoParse
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(string s, DateTimeFormatInfo formatInfo, DateTimeStyles styles, out DateInfo result)
    {
        return TryCreateDateInfo(DateTime.TryParse(s, formatInfo, styles, out var time), time, out result);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParseExact(string s, string format, DateTimeFormatInfo formatInfo, DateTimeStyles styles, out DateInfo result)
    {
        return TryCreateDateInfo(DateTime.TryParseExact(s, format, formatInfo, styles, out var time), time, out result);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParseExactMultiple(string s, string[] formats, DateTimeFormatInfo formatInfo, DateTimeStyles styles, out DateInfo result)
    {
        return TryCreateDateInfo(DateTime.TryParseExact(s, formats, formatInfo, styles, out var time), time, out result);
    }

    private static bool TryCreateDateInfo(bool condition, DateTime time, out DateInfo result)
    {
        result = default;
        if (!condition) return false;
        result = new DateInfo(time);
        return true;
    }
}