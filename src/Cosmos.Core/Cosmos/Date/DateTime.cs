namespace Cosmos.Date;

/// <summary>
/// Datetime Output Styles <br />
/// 时间输出风格
/// </summary>
public enum DateTimeOutputStyles
{
    /// <summary>
    /// DateTime
    /// </summary>
    DateTime,

    /// <summary>
    /// Date
    /// </summary>
    Date,

    /// <summary>
    /// Time
    /// </summary>
    Time,

    /// <summary>
    /// LongDate
    /// </summary>
    LongDate,

    /// <summary>
    /// LongTime
    /// </summary>
    LongTime,

    /// <summary>
    /// ShortDate
    /// </summary>
    ShortDate,

    /// <summary>
    /// ShortTime
    /// </summary>
    ShortTime,

    /// <summary>
    /// Millisecond
    /// </summary>
    Millisecond,
}

/// <summary>
/// DateTime Helper (internal)
/// </summary>
internal static class DateTimeHelper
{
    /// <summary>
    /// If this then that...
    /// </summary>
    /// <param name="condition"></param>
    /// <param name="format1"></param>
    /// <param name="format2"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Ifttt(bool condition, string format1, string format2)
    {
        return condition ? format1 : format2;
    }
}

/// <summary>
/// DateTime to String extensions <br />
/// DateTime 转换为 String 的扩展
/// </summary>
public static class DateTimeToStringExtensions
{
    /// <summary>
    /// Convert DateTime value to String. <br />
    /// 将 DateTime 转换为字符串。
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="styles"></param>
    /// <param name="isRemoveSecond"></param>
    /// <returns></returns>
    public static string ToString(this DateTime dt, DateTimeOutputStyles styles, bool isRemoveSecond = false)
    {
        return styles switch
        {
            DateTimeOutputStyles.DateTime => dt.ToString(DateTimeHelper.Ifttt(isRemoveSecond, "yyyy-MM-dd HH:mm", "yyyy-MM-dd HH:mm:ss")),
            DateTimeOutputStyles.Date => dt.ToString("yyyy-MM-dd"),
            DateTimeOutputStyles.Time => dt.ToString(DateTimeHelper.Ifttt(isRemoveSecond, "HH:mm", "HH:mm:ss")),
            DateTimeOutputStyles.LongDate => dt.ToLongDateString(),
            DateTimeOutputStyles.LongTime => dt.ToLongTimeString(),
            DateTimeOutputStyles.ShortDate => dt.ToShortDateString(),
            DateTimeOutputStyles.ShortTime => dt.ToShortTimeString(),
            DateTimeOutputStyles.Millisecond => dt.ToString("yyyy-MM-dd HH:mm:ss.fff"),
            _ => dt.ToString(CultureInfo.InvariantCulture)
        };
    }

    /// <summary>
    /// Convert DateTime value to String. <br />
    /// 将 DateTime 转换为字符串。
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="styles"></param>
    /// <param name="isRemoveSecond"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string ToString(this DateTime? dt, DateTimeOutputStyles styles, bool isRemoveSecond = false)
    {
        return dt is null ? string.Empty : dt.Value.ToString(styles, isRemoveSecond);
    }

    /// <summary>
    /// Convert DateTime to DateTimeOffset. <br />
    /// 将时间转换为时间点
    /// </summary>
    /// <param name="localDateTime"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTimeOffset ToDateTimeOffset(this DateTime localDateTime)
    {
        return localDateTime.ToDateTimeOffset(null);
    }

    /// <summary>
    /// Convert DateTime to  DateTimeOffset. <br />
    /// 将时间转换为时间点
    /// </summary>
    /// <param name="localDateTime"></param>
    /// <param name="localTimeZone"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTimeOffset ToDateTimeOffset(this DateTime localDateTime, TimeZoneInfo localTimeZone)
    {
        if (localDateTime.Kind != DateTimeKind.Unspecified)
            localDateTime = new DateTime(localDateTime.Ticks, DateTimeKind.Unspecified);

        return TimeZoneInfo.ConvertTime(localDateTime, localTimeZone ?? TimeZoneInfo.Local);
    }

    /// <summary>
    /// Convert DateTimeOffset to DateTime. <br />
    /// 将时间点转换为时间
    /// </summary>
    /// <param name="dateTimeUtc"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTime ToLocalDateTime(this DateTimeOffset dateTimeUtc)
    {
        return dateTimeUtc.ToLocalDateTime(null);
    }

    /// <summary>
    /// Convert DateTimeOffset to DateTime. <br />
    /// 将时间点转换为时间
    /// </summary>
    /// <param name="dateTimeUtc"></param>
    /// <param name="localTimeZone"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTime ToLocalDateTime(this DateTimeOffset dateTimeUtc, TimeZoneInfo localTimeZone)
    {
        return TimeZoneInfo.ConvertTime(dateTimeUtc, localTimeZone ?? TimeZoneInfo.Local).DateTime;
    }
}