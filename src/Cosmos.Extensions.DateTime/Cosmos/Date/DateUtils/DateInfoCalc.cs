using Cosmos.Conversions;

namespace Cosmos.Date.DateUtils;

public static class DateInfoCalc
{
    #region Offset by Days

    /// <summary>
    /// Add days. <br />
    /// 添加一个季度。
    /// </summary>
    /// <param name="di"></param>
    /// <param name="days"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateInfo OffsetByDays(DateInfo di, int days)
    {
        return di + days.Days();
    }

    #endregion

    #region Offset by Week

    /// <summary>
    /// Create <see cref="DateInfo"/> by special year, month and offset info.<br />
    /// 根据指定的年月和偏移信息创建 <see cref="DateInfo"/>
    /// </summary>
    /// <param name="year"></param>
    /// <param name="month"></param>
    /// <param name="weekAtMonth"></param>
    /// <param name="dayOfWeek"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateInfo OffsetByWeek(int year, int month, int weekAtMonth, DayOfWeek dayOfWeek)
    {
        return OffsetByWeek(year, month, weekAtMonth, dayOfWeek.CastToInt32(0));
    }

    /// <summary>
    /// Create <see cref="DateInfo"/> by special year, month and offset info.<br />
    /// 根据指定的年月和偏移信息创建 <see cref="DateInfo"/>
    /// </summary>
    /// <param name="year"></param>
    /// <param name="month"></param>
    /// <param name="weekAtMonth"></param>
    /// <param name="dayOfWeek"></param>
    /// <returns></returns>
    public static DateInfo OffsetByWeek(int year, int month, int weekAtMonth, int dayOfWeek)
    {
        if (weekAtMonth == 0 || weekAtMonth > 5)
            throw new ArgumentException("weekAtMonth is invalid.", nameof(weekAtMonth));

        var targetDay = DateTimeCalcHelper.GetTargetDays(year, month, weekAtMonth, dayOfWeek);

        if (targetDay > DateInfo.DaysInMonth(year, month))
            return DateInfo.InfinitePast;

        return DateInfoFactory.Create(year, month, targetDay);
    }

    /// <summary>
    /// Create <see cref="DateInfo"/> by special year, month and offset info.<br />
    /// 根据指定的年月和偏移信息创建 <see cref="DateInfo"/>
    /// </summary>
    /// <param name="year"></param>
    /// <param name="month"></param>
    /// <param name="weekAtMonth"></param>
    /// <param name="dayOfWeek"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryOffsetByWeek(int year, int month, int weekAtMonth, DayOfWeek dayOfWeek, out DateInfo result)
    {
        return TryOffsetByWeek(year, month, weekAtMonth, dayOfWeek.CastToInt32(0), out result);
    }

    /// <summary>
    /// Create <see cref="DateInfo"/> by special year, month and offset info.<br />
    /// 根据指定的年月和偏移信息创建 <see cref="DateInfo"/>
    /// </summary>
    /// <param name="year"></param>
    /// <param name="month"></param>
    /// <param name="weekAtMonth"></param>
    /// <param name="dayOfWeek"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    public static bool TryOffsetByWeek(int year, int month, int weekAtMonth, int dayOfWeek, out DateInfo result)
    {
        if (weekAtMonth == 0 || weekAtMonth > 5)
            throw new ArgumentException("weekAtMonth is invalid.", nameof(weekAtMonth));

        var targetDay = DateTimeCalcHelper.GetTargetDays(year, month, weekAtMonth, dayOfWeek);

        var invalid = targetDay > DateTime.DaysInMonth(year, month);
        result = invalid
            ? DateTime.MinValue
            : DateTimeFactory.Create(year, month, targetDay);

        return !invalid;
    }

    #endregion

    #region Offset by Week Before / After

    /// <summary>
    /// Add weeks. <br />
    /// 偏移一个星期。
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="weeks"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateInfo OffsetByWeeks(DateInfo dt, int weeks)
    {
        return dt + weeks.Weeks();
    }

    /// <summary>
    /// Find the next weekday for example Monday before a special date.<br />
    /// 根据指定的日期，获得上一个工作日（如周一）
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="dayOfWeek"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateInfo OffsetByWeekBefore(DateInfo dt, DayOfWeek dayOfWeek)
    {
        var daysSubtract = (int) dayOfWeek - (int) dt.DayOfWeek;
        return (int) dayOfWeek < (int) dt.DayOfWeek
            ? dt.AddDays(daysSubtract)
            : dt.AddDays(daysSubtract - 7);
    }

    /// <summary>
    /// Find the next weekday for example Monday from a special date.<br />
    /// 根据指定的日期，获得下一个工作日（如周一）
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="dayOfWeek"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateInfo OffsetByWeekAfter(DateInfo dt, DayOfWeek dayOfWeek)
    {
        var daysNeeded = (int) dayOfWeek - (int) dt.DayOfWeek;
        return (int) dayOfWeek >= (int) dt.DayOfWeek
            ? dt.AddDays(daysNeeded)
            : dt.AddDays(daysNeeded + 7);
    }

    #endregion

    #region Offset by DayOfWeek

    public static DateInfo OffsetByDayOfWeek(DateInfo d, DayOfWeek dayOfWeek, int weekOffset)
    {
        var z = weekOffset > 0 ? 1 : -1;
        var offset = DayOfWeekCalc.DaysBetween(d.DayOfWeek, dayOfWeek);
        offset = offset == 0 ? 7 : offset;
        return d.OffsetBy(offset * z * weekOffset, DateOffsetStyles.Day);
    }

    #endregion

    #region Offset by Months

    /// <summary>
    /// Add quarters. <br />
    /// 添加一个季度。
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="months"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static DateInfo OffsetByMonths(DateInfo dt, int months, DateTimeOffsetOptions options = DateTimeOffsetOptions.Absolute)
    {
        if (options == DateTimeOffsetOptions.Absolute)
            return dt + months.Months();

        var (year, month) = DateTimeCalcHelper.Calc(dt.Year, dt.Month, months);

        var firstDayOfMonth = dt.SetDate(year, month, 1);

        var lastDayOfMonth = firstDayOfMonth.LastDayOfMonth().Day;

        var day = dt.Day > lastDayOfMonth ? lastDayOfMonth : dt.Day;

        return dt.SetDate(year, month, day);
    }

    #endregion

    #region Offset by Quarters

    /// <summary>
    /// Add quarters. <br />
    /// 添加一个季度。
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="quarters"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static DateInfo OffsetByQuarters(DateInfo dt, int quarters, DateTimeOffsetOptions options = DateTimeOffsetOptions.Absolute)
    {
        if (options == DateTimeOffsetOptions.Absolute)
            return dt + quarters.Quarters();
        return OffsetByMonths(dt, quarters * 3, DateTimeOffsetOptions.Relatively);
    }

    #endregion

    #region Offset by Years

    /// <summary>
    /// Add years. <br />
    /// 添加一个季度。
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="years"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static DateInfo OffsetByYears(DateInfo dt, int years, DateTimeOffsetOptions options = DateTimeOffsetOptions.Absolute)
    {
        if (options == DateTimeOffsetOptions.Absolute)
            return dt + years.Years();
        return OffsetByMonths(dt, years * 12, DateTimeOffsetOptions.Relatively);
    }

    #endregion
}