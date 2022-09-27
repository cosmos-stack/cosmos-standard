using Cosmos.Date.DateUtils;

namespace Cosmos.Date;

/// <summary>
/// DateTime Extensions <br />
/// 日期扩展
/// </summary>
public static partial class DateTimeExtensions
{
    #region Offset

    /// <summary>
    /// DateTime Offset <br />
    /// 日期偏移
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="offsetVal"></param>
    /// <param name="styles"></param>
    /// <returns></returns>
    public static DateTime OffsetBy(this DateTime dt, int offsetVal, DateOffsetStyles styles)
    {
        return styles switch
        {
            DateOffsetStyles.Day => DateTimeCalc.OffsetByDays(dt, offsetVal),
            DateOffsetStyles.Week => DateTimeCalc.OffsetByWeeks(dt, offsetVal),
            DateOffsetStyles.Month => DateTimeCalc.OffsetByMonths(dt, offsetVal, DateTimeOffsetOptions.Relatively),
            DateOffsetStyles.Quarters => DateTimeCalc.OffsetByQuarters(dt, offsetVal, DateTimeOffsetOptions.Relatively),
            DateOffsetStyles.Year => DateTimeCalc.OffsetByYears(dt, offsetVal, DateTimeOffsetOptions.Relatively),
            _ => DateTimeCalc.OffsetByDays(dt, offsetVal)
        };
    }

    /// <summary>
    /// DateTime Offset <br />
    /// 时间偏移
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="offsetVal"></param>
    /// <param name="styles"></param>
    /// <returns></returns>
    public static DateTime OffsetBy(this DateTime dt, int offsetVal, TimeOffsetStyles styles)
    {
        return styles switch
        {
            TimeOffsetStyles.Millisecond => DateTimeCalc.OffsetByMilliseconds(dt, offsetVal),
            TimeOffsetStyles.Second => DateTimeCalc.OffsetBySeconds(dt, offsetVal),
            TimeOffsetStyles.Minute => DateTimeCalc.OffsetByMinutes(dt, offsetVal),
            TimeOffsetStyles.Hour => DateTimeCalc.OffsetByHours(dt, offsetVal),
            _ => DateTimeCalc.OffsetBySeconds(dt, offsetVal)
        };
    }

    #endregion

    #region Begin

    /// <summary>
    /// Beginning of day.<br />
    /// 获取一天的开始时间。
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTime BeginningOfDay(this DateTime dt) =>
        DateTimeFactory.Create(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0, dt.Kind);

    /// <summary>
    /// Beginning of day.<br />
    /// 获取一天的开始时间。
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="timeZoneOffset"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTime BeginningOfDay(this DateTime dt, int timeZoneOffset) =>
        DateTimeFactory.Create(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0, dt.Kind).AddHours(timeZoneOffset);

    /// <summary>
    /// Beginning of week.<br />
    /// 获取一周的开始时间。
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTime BeginningOfWeek(this DateTime dt) => dt.FirstDayOfWeek().BeginningOfDay();

    /// <summary>
    /// Beginning of week.<br />
    /// 获取一周的开始时间。
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="timeZoneOffset"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTime BeginningOfWeek(this DateTime dt, int timeZoneOffset) => dt.FirstDayOfWeek().BeginningOfDay(timeZoneOffset);

    /// <summary>
    /// Beginning of month.<br />
    /// 获取一个月的开始时间。
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTime BeginningOfMonth(this DateTime dt) => dt.FirstDayOfMonth().BeginningOfDay();

    /// <summary>
    /// Beginning of month.<br />
    /// 获取一个月的开始时间。
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="timeZoneOffset"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTime BeginningOfMonth(this DateTime dt, int timeZoneOffset) => dt.FirstDayOfMonth().BeginningOfDay(timeZoneOffset);

    /// <summary>
    /// Beginning of quarter.<br />
    /// 获取一个季度的开始时间。
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTime BeginningOfQuarter(this DateTime dt) => dt.FirstDayOfQuarter().BeginningOfDay();

    /// <summary>
    /// Beginning of quarter.<br />
    /// 获取一个季度的开始时间。
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="timeZoneOffset"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTime BeginningOfQuarter(this DateTime dt, int timeZoneOffset) => dt.FirstDayOfQuarter().BeginningOfDay(timeZoneOffset);

    /// <summary>
    /// Beginning of year.<br />
    /// 获取一年的开始时间。
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTime BeginningOfYear(this DateTime dt) => dt.FirstDayOfYear().BeginningOfDay();

    /// <summary>
    /// Beginning of year.<br />
    /// 获取一年的开始时间。
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="timeZoneOffset"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTime BeginningOfYear(this DateTime dt, int timeZoneOffset) => dt.FirstDayOfYear().BeginningOfDay(timeZoneOffset);

    #endregion

    #region End

    /// <summary>
    /// End of day.<br />
    /// 获取一天中的结束时间。
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTime EndOfDay(this DateTime dt) =>
        DateTimeFactory.Create(dt.Year, dt.Month, dt.Day, 23, 59, 59, 999, dt.Kind);

    /// <summary>
    /// End of day (timezone-adjusted).<br />
    /// 获取一天中的结束时间。
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="timeZoneOffset"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTime EndOfDay(this DateTime dt, int timeZoneOffset) =>
        DateTimeFactory.Create(dt.Year, dt.Month, dt.Day, 23, 59, 59, 999, dt.Kind).AddHours(timeZoneOffset);

    /// <summary>
    /// End of week.<br />
    /// 一周的结束时间。
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTime EndOfWeek(this DateTime dt) => dt.LastDayOfWeek().EndOfDay();

    /// <summary>
    /// End of week.<br />
    /// 一周的结束时间。
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="timeZoneOffset"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTime EndOfWeek(this DateTime dt, int timeZoneOffset) => dt.LastDayOfWeek().EndOfDay(timeZoneOffset);

    /// <summary>
    /// End of month.<br />
    /// 一个月的结束时间。
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTime EndOfMonth(this DateTime dt) => dt.LastDayOfMonth().EndOfDay();

    /// <summary>
    /// End of month.<br />
    /// 一个月的结束时间。
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="timeZoneOffset"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTime EndOfMonth(this DateTime dt, int timeZoneOffset) => dt.LastDayOfMonth().EndOfDay(timeZoneOffset);

    /// <summary>
    /// End of quarter.<br />
    /// 一个季度的结束时间。
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTime EndOfQuarter(this DateTime dt) => dt.LastDayOfQuarter().EndOfDay();

    /// <summary>
    /// End of quarter.<br />
    /// 一个季度的结束时间。
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="timeZoneOffset"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTime EndOfQuarter(this DateTime dt, int timeZoneOffset) => dt.LastDayOfQuarter().EndOfDay(timeZoneOffset);

    /// <summary>
    /// End of year.<br />
    /// 一年的结束时间。
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTime EndOfYear(this DateTime dt) => dt.LastDayOfYear().EndOfDay();

    /// <summary>
    /// End of year.<br />
    /// 一年的结束时间。
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="timeZoneOffset"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTime EndOfYear(this DateTime dt, int timeZoneOffset) => dt.LastDayOfYear().EndOfDay(timeZoneOffset);

    #endregion

    #region Get

    /// <summary>
    /// Gets two time intervals. <br />
    /// 获取两个时间之间的间隔。
    /// </summary>
    /// <param name="leftDt"></param>
    /// <param name="rightDt">  </param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TimeSpan GetTimeSpan(this DateTime leftDt, DateTime rightDt) => rightDt - leftDt;

    /// <summary>
    /// Get the first day of the specified year. <br />
    /// 获取指定年份的第一天。
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTime FirstDayOfYear(this DateTime dt) => dt.SetDate(dt.Year, 1, 1);

    /// <summary>
    /// Get the specified day of the first week of the specified year. <br />
    /// 获取指定年份的第一个礼拜指定的某一天。
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="dayOfWeek"></param>
    /// <returns></returns>
    public static DateTime FirstDayOfYear(this DateTime dt, DayOfWeek dayOfWeek)
    {
        var ret = dt.FirstDayOfYear();
        return DayOfWeekCalc.TryDaysBetween(ret.DayOfWeek, dayOfWeek, out var day) && day > 0
            ? ret.AddDays(day)
            : ret;
    }

    /// <summary>
    /// Get the first day of the specified quarter. <br />
    /// 获取指定季度的第一天。
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    public static DateTime FirstDayOfQuarter(this DateTime dt)
    {
        var currentQuarter = dt.QuarterOfMonth();
        var month = 3 * currentQuarter - 2;
        return DateTimeFactory.Create(dt.Year, month, 1);
    }

    /// <summary>
    /// Get the specified day of the first week of the specified quarter. <br />
    /// 获取指定季度的第一个礼拜指定的某一天。
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="dayOfWeek"></param>
    /// <returns></returns>
    public static DateTime FirstDayOfQuarter(this DateTime dt, DayOfWeek dayOfWeek)
    {
        var ret = dt.FirstDayOfQuarter();
        return DayOfWeekCalc.TryDaysBetween(ret.DayOfWeek, dayOfWeek, out var day) && day > 0
            ? ret.AddDays(day)
            : ret;
    }

    /// <summary>
    /// Get the first day of the specified month. <br />
    /// 获取指定月份的第一天。
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTime FirstDayOfMonth(this DateTime dt) => dt.SetDay(1);

    /// <summary>
    /// Get the specified day of the first week of the specified month. <br />
    /// 获取指定月份的第一个礼拜指定的某一天。
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="dayOfWeek"></param>
    /// <returns></returns>
    public static DateTime FirstDayOfMonth(this DateTime dt, DayOfWeek dayOfWeek)
    {
        var ret = dt.FirstDayOfMonth();
        return DayOfWeekCalc.TryDaysBetween(ret.DayOfWeek, dayOfWeek, out var day) && day > 0
            ? ret.AddDays(day)
            : ret;
    }

    /// <summary>
    /// Get the first day of the specified week. <br />
    /// 获取指礼拜的第一天。
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTime FirstDayOfWeek(this DateTime dt) => dt.FirstDayOfWeek(null);

    /// <summary>
    /// Get the first day of the specified week. <br />
    /// 获取指礼拜的第一天。
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="cultureInfo"></param>
    /// <returns></returns>
    public static DateTime FirstDayOfWeek(this DateTime dt, CultureInfo cultureInfo)
    {
        cultureInfo ??= CultureInfo.CurrentCulture;
        var firstDayOfWeek = cultureInfo.DateTimeFormat.FirstDayOfWeek;
        var offset = dt.DayOfWeek - firstDayOfWeek < 0 ? 7 : 0;
        var numberOfDaysSinceBeginningOfTheWeek = dt.DayOfWeek + offset - firstDayOfWeek;

        return dt.AddDays(-numberOfDaysSinceBeginningOfTheWeek);
    }

    /// <summary>
    /// Get the last day of the specified year. <br />
    /// 获取指定年份的最后一天。
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTime LastDayOfYear(this DateTime dt) => dt.SetDate(dt.Year, 12, 31);

    /// <summary>
    /// Get the specified day of the first week of the specified year. <br />
    /// 获取指定年份的最后一个礼拜指定的某一天。
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="dayOfWeek"></param>
    /// <returns></returns>
    public static DateTime LastDayOfYear(this DateTime dt, DayOfWeek dayOfWeek)
    {
        var ret = dt.LastDayOfYear();
        return DayOfWeekCalc.TryDaysBetween(ret.DayOfWeek, dayOfWeek, out var day) && day == 0
            ? ret
            : ret.AddDays(-day);
    }

    /// <summary>
    /// Get the last day of the specified quarter. <br />
    /// 获取指定季度的最后一天。
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    public static DateTime LastDayOfQuarter(this DateTime dt)
    {
        var currentQuarter = dt.QuarterOfMonth();
        var month = 3 * currentQuarter;
        var day = DateTime.DaysInMonth(dt.Year, month);
        return DateTimeFactory.Create(dt.Year, month, day);
    }

    /// <summary>
    /// Get the specified day of the first week of the specified quarter. <br />
    /// 获取指定季度的最后一个礼拜指定的某一天。
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="dayOfWeek"></param>
    /// <returns></returns>
    public static DateTime LastDayOfQuarter(this DateTime dt, DayOfWeek dayOfWeek)
    {
        var ret = dt.LastDayOfQuarter();
        return DayOfWeekCalc.TryDaysBetween(ret.DayOfWeek, dayOfWeek, out var day) && day == 0
            ? ret
            : ret.AddDays(-day);
    }

    /// <summary>
    /// Get the last day of the specified month. <br />
    /// 获取指定月份的最后一天。
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTime LastDayOfMonth(this DateTime dt) => dt.SetDay(dt.DaysInMonth());

    /// <summary>
    /// Get the specified day of the first week of the specified month. <br />
    /// 获取指定月份的最后一个礼拜指定的某一天。
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="dayOfWeek"></param>
    /// <returns></returns>
    public static DateTime LastDayOfMonth(this DateTime dt, DayOfWeek dayOfWeek)
    {
        var ret = dt.LastDayOfMonth();
        return DayOfWeekCalc.TryDaysBetween(ret.DayOfWeek, dayOfWeek, out var day) && day == 0
            ? ret
            : ret.AddDays(-day);
    }

    /// <summary>
    /// Get the last day of the specified week. <br />
    /// 获取指定礼拜的最后一天。
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTime LastDayOfWeek(this DateTime dt) => dt.LastDayOfWeek(null);

    /// <summary>
    /// Get the last day of the specified week. <br />
    /// 获取指定礼拜的最后一天。
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="cultureInfo"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTime LastDayOfWeek(this DateTime dt, CultureInfo cultureInfo) => dt.FirstDayOfWeek(cultureInfo).AddDays(6);

    /// <summary>
    /// Get the number of days in the specified month.<br />
    /// 获取指定月份中的天数。
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int DaysInMonth(this DateTime dt) => DateTime.DaysInMonth(dt.Year, dt.Month);

    /// <summary>
    /// Get the number of days in the specified year.<br />
    /// 获取指定年份中的天数。
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int DaysInYear(this DateTime dt) => DateTime.IsLeapYear(dt.Year) ? 366 : 365;

    /// <summary>
    /// Get the quarter of the specified month.<br />
    /// 获取指定月份是第几季度。
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int QuarterOfMonth(this DateTime dt) => (dt.Month - 1) / 3 + 1;

    /// <summary>
    /// Get the specified week is the week of the year.<br />
    /// 获取指定的星期是一年中的第几个星期。
    /// </summary>
    /// <param name="datetime"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int GetWeekOfYear(this DateTime datetime)
        => GetWeekOfYear(datetime, new DateTimeFormatInfo().CalendarWeekRule, new DateTimeFormatInfo().FirstDayOfWeek);

    /// <summary>
    /// Get the specified week is the week of the year.<br />
    /// 获取指定的星期是一年中的第几个星期。
    /// </summary>
    /// <param name="datetime"></param>
    /// <param name="weekRule"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int GetWeekOfYear(this DateTime datetime, CalendarWeekRule weekRule)
        => GetWeekOfYear(datetime, weekRule, new DateTimeFormatInfo().FirstDayOfWeek);

    /// <summary>
    /// Get the specified week is the week of the year.<br />
    /// 获取指定的星期是一年中的第几个星期。
    /// </summary>
    /// <param name="datetime"></param>
    /// <param name="firstDayOfWeek"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int GetWeekOfYear(this DateTime datetime, DayOfWeek firstDayOfWeek)
        => GetWeekOfYear(datetime, new DateTimeFormatInfo().CalendarWeekRule, firstDayOfWeek);

    /// <summary>
    /// Get the specified week is the week of the year.<br />
    /// 获取指定的星期是一年中的第几个星期。
    /// </summary>
    /// <param name="datetime"></param>
    /// <param name="weekRule"></param>
    /// <param name="firstDayOfWeek"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int GetWeekOfYear(this DateTime datetime, CalendarWeekRule weekRule, DayOfWeek firstDayOfWeek)
        => CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(datetime, weekRule, firstDayOfWeek);

    #endregion

    #region Navigation

    /// <summary>
    /// Next year <br />
    /// 下一年
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTime NextYear(this DateTime dt) => dt.OffsetBy(1, DateOffsetStyles.Year);

    /// <summary>
    /// Previous Year <br />
    /// 上一年
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTime PreviousYear(this DateTime dt) => dt.OffsetBy(-1, DateOffsetStyles.Year);

    /// <summary>
    /// Gets next quarter <br />
    /// 下一季度
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTime NextQuarter(this DateTime dt) => dt.OffsetBy(1, DateOffsetStyles.Quarters);

    /// <summary>
    /// Gets previous quarter <br />
    /// 上一季度
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTime PreviousQuarter(this DateTime dt) => dt.OffsetBy(-1, DateOffsetStyles.Quarters);

    /// <summary>
    /// Gets next month <br />
    /// 下个月
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTime NextMonth(this DateTime dt) => dt.OffsetBy(1, DateOffsetStyles.Month);

    /// <summary>
    /// Gets previous month <br />
    /// 上个月
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTime PreviousMonth(this DateTime dt) => dt.OffsetBy(-1, DateOffsetStyles.Month);

    /// <summary>
    /// Next week <br />
    /// 下周
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTime NextWeek(this DateTime dt) => dt.OffsetBy(1, DateOffsetStyles.Week);

    /// <summary>
    /// Previous week <br />
    /// 上周
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTime PreviousWeek(this DateTime dt) => dt.OffsetBy(-1, DateOffsetStyles.Week);

    /// <summary>
    /// Next day <br />
    /// 下一天
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTime NextDay(this DateTime dt) => dt.OffsetBy(1, DateOffsetStyles.Day);

    /// <summary>
    /// Previous Day <br />
    /// 上一天
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTime PreviousDay(this DateTime dt) => dt.OffsetBy(-1, DateOffsetStyles.Day);

    /// <summary>
    /// Tomorrow <br />
    /// 明天
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTime Tomorrow(this DateTime dt) => dt.NextDay();

    /// <summary>
    /// Yesterday <br />
    /// 昨天
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTime Yesterday(this DateTime dt) => dt.PreviousDay();

    /// <summary>
    /// Next <br />
    /// 下一个指定的礼拜几
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="dayOfWeek"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTime NextDayOfWeek(this DateTime dt, DayOfWeek dayOfWeek) => DateTimeCalc.OffsetByDayOfWeek(dt, dayOfWeek, 1);

    /// <summary>
    /// Previous <br />
    /// 上一个指定的礼拜几
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="dayOfWeek"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTime PreviousDayOfWeek(this DateTime dt, DayOfWeek dayOfWeek) => DateTimeCalc.OffsetByDayOfWeek(dt, dayOfWeek, -1);

    #endregion
}