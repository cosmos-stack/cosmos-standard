namespace NodaTime;

/// <summary>
/// Cosmos.Core <see cref="LocalDate"/> extensions.
/// </summary>
public static class NodaLocalDateExtensions
{
    #region Add

    /// <summary>
    /// Add days.<br />
    /// 添加天数。
    /// </summary>
    /// <param name="ld"></param>
    /// <param name="days"></param>
    /// <returns></returns>
    public static LocalDate AddDays(this LocalDate ld, int days) => ld.PlusDays(days);

    /// <summary>
    /// Add weeks.<br />
    /// 添加周数。
    /// </summary>
    /// <param name="ld"></param>
    /// <param name="weeks"></param>
    /// <returns></returns>
    public static LocalDate AddWeeks(this LocalDate ld, int weeks) => ld.PlusWeeks(weeks);

    /// <summary>
    /// Add months.<br />
    /// 添加月数。
    /// </summary>
    /// <param name="ld"></param>
    /// <param name="months"></param>
    /// <returns></returns>
    public static LocalDate AddMonths(this LocalDate ld, int months) => ld.PlusMonths(months);

    /// <summary>
    /// Add quarters.<br />
    /// 添加季数。
    /// </summary>
    /// <param name="ld"></param>
    /// <param name="quarters"></param>
    /// <returns></returns>
    public static LocalDate AddQuarters(this LocalDate ld, int quarters) => ld.PlusMonths(quarters * 3);

    /// <summary>
    /// Add years.<br />
    /// 添加年数。
    /// </summary>
    /// <param name="ld"></param>
    /// <param name="years"></param>
    /// <returns></returns>
    public static LocalDate AddYears(this LocalDate ld, int years) => ld.PlusYears(years);

    /// <summary>
    /// Add period. <br />
    /// 添加一段时间。
    /// </summary>
    /// <param name="ts"></param>
    /// <param name="period"></param>
    /// <returns></returns>
    public static LocalDate Add(this LocalDate ts, Period period) => ts.Plus(period);

    #endregion

    #region Begin

    /// <summary>
    /// Get the day that the month starts. <br />
    /// 获得一个月开始的那一天。
    /// </summary>
    /// <param name="ld"></param>
    /// <returns></returns>
    public static LocalDate BeginningOfMonth(this LocalDate ld) => DateAdjusters.StartOfMonth(ld);

    #endregion

    #region First

    /// <summary>
    /// Gets first day of year. <br />
    /// 获取一年的第一天。
    /// </summary>
    /// <param name="ld"></param>
    /// <returns></returns>
    public static LocalDate FirstDayOfYear(this LocalDate ld) => ld.SetDate(ld.Year, 1, 1);

    /// <summary>
    /// Gets first day of quarter. <br />
    /// 获取一个季度的第一天。
    /// </summary>
    /// <param name="ld"></param>
    /// <returns></returns>
    public static LocalDate FirstDayOfQuarter(this LocalDate ld)
    {
        var currentQuarter = (ld.Month - 1) / 3 + 1;
        var firstDay = new LocalDate(ld.Year, 3 * currentQuarter - 2, 1);

        return ld.SetDate(firstDay.Year, firstDay.Month, firstDay.Day);
    }

    /// <summary>
    /// Gets first day of month. <br />
    /// 获取一个月的第一天。
    /// </summary>
    /// <param name="ld"></param>
    /// <returns></returns>
    public static LocalDate FirstDayOfMonth(this LocalDate ld) => ld.SetDay(1);

    /// <summary>
    /// First day of week. <br />
    /// 获取一周的第一天。
    /// </summary>
    /// <param name="ld"></param>
    /// <returns></returns>
    public static LocalDate FirstDayOfWeek(this LocalDate ld)
    {
        var currentCulture = CultureInfo.CurrentCulture;
        var firstDayOfWeek = (int) currentCulture.DateTimeFormat.FirstDayOfWeek;

        var currentDayOfWeek = (int) ld.DayOfWeek;

        var offset = currentDayOfWeek - firstDayOfWeek < 0 ? 7 : 0;
        var numberOfDaysSinceBeginningOfTheWeek = currentDayOfWeek + offset - firstDayOfWeek;

        return ld.AddDays(-numberOfDaysSinceBeginningOfTheWeek);
    }

    #endregion

    #region End

    /// <summary>
    /// Get the last day of the month. <br />
    /// 获得一个月最后的那一天。
    /// </summary>
    /// <param name="ld"></param>
    /// <returns></returns>
    public static LocalDate EndOfMonth(this LocalDate ld) => DateAdjusters.EndOfMonth(ld);

    #endregion

    #region Last

    /// <summary>
    /// Gets last day of year.<br />
    /// 获取一年的最后一天。
    /// </summary>
    /// <param name="ld"></param>
    /// <returns></returns>
    public static LocalDate LastDayOfYear(this LocalDate ld) => ld.SetDate(ld.Year, 12, 31);

    /// <summary>
    /// Gets last day of quarter.<br />
    /// 获取一个季度的最后一天。
    /// </summary>
    /// <param name="ld"></param>
    /// <returns></returns>
    public static LocalDate LastDayOfQuarter(this LocalDate ld)
    {
        var currentQuarter = (ld.Month - 1) / 3 + 1;
        var firstDay = ld.SetDate(ld.Year, 3 * currentQuarter - 2, 1);
        return firstDay.SetMonth(firstDay.Month + 2).LastDayOfMonth();
    }

    /// <summary>
    /// Gets last day of month.<br />
    /// 获取一个月的最后一天。
    /// </summary>
    /// <param name="ld"></param>
    /// <returns></returns>
    public static LocalDate LastDayOfMonth(this LocalDate ld) => ld.SetDay(ld.Calendar.GetDaysInMonth(ld.Year, ld.Month));

    /// <summary>
    /// Gets last day of week.<br />
    /// 获取一周的最后一天。
    /// </summary>
    /// <param name="ld"></param>
    /// <returns></returns>
    public static LocalDate LastDayOfWeek(this LocalDate ld) => ld.FirstDayOfWeek().AddDays(6);

    #endregion

    #region Previous and Next

    /// <summary>
    /// Next year.<br />
    /// 下一年。
    /// </summary>
    /// <param name="ld"></param>
    /// <returns></returns>
    public static LocalDate NextYear(this LocalDate ld)
    {
        var year = ld.Year + 1;
        var daysOfMonth = DateTime.DaysInMonth(year, ld.Month);

        if (daysOfMonth == ld.Day)
            return new LocalDate(ld.Era, year, ld.Month, ld.Day);

        var d = ld.Day - daysOfMonth;
        var p = new LocalDate(ld.Era, year, ld.Month, daysOfMonth);
        return p.AddDays(d);
    }

    /// <summary>
    /// Previous Year.<br />
    /// 上一年。
    /// </summary>
    /// <param name="ld"></param>
    /// <returns></returns>
    public static LocalDate PreviousYear(this LocalDate ld)
    {
        var year = ld.Year - 1;
        var daysOfMonth = DateTime.DaysInMonth(year, ld.Month);

        if (daysOfMonth == ld.Day)
            return new LocalDate(ld.Era, year, ld.Month, ld.Day);

        var d = ld.Day - daysOfMonth;
        var p = new LocalDate(ld.Era, year, ld.Month, daysOfMonth);
        return p.AddDays(d);
    }

    /// <summary>
    /// Gets next month.<br />
    /// 下一个月。
    /// </summary>
    /// <param name="ld"></param>
    /// <returns></returns>
    public static LocalDate NextMonth(this LocalDate ld)
    {
        var year = ld.Month == 12 ? ld.Year + 1 : ld.Year;

        var month = ld.Month == 12 ? 1 : ld.Month + 1;

        var firstDayOfNextMonth = ld.SetDate(year, month, 1);

        var lastDayOfPreviousMonth = firstDayOfNextMonth.LastDayOfMonth().Day;

        var day = ld.Day > lastDayOfPreviousMonth ? lastDayOfPreviousMonth : ld.Day;

        return firstDayOfNextMonth.SetDay(day);
    }

    /// <summary>
    /// Gets previous month.<br />
    /// 上一个月。
    /// </summary>
    /// <param name="ld"></param>
    /// <returns></returns>
    public static LocalDate PreviousMonth(this LocalDate ld)
    {
        var year = ld.Month == 1 ? ld.Year - 1 : ld.Year;

        var month = ld.Month == 1 ? 12 : ld.Month - 1;

        var firstDayOfPreviousMonth = ld.SetDate(year, month, 1);

        var lastDayOfPreviousMonth = firstDayOfPreviousMonth.LastDayOfMonth().Day;

        var day = ld.Day > lastDayOfPreviousMonth ? lastDayOfPreviousMonth : ld.Day;

        return firstDayOfPreviousMonth.SetDay(day);
    }

    /// <summary>
    /// Next Week.<br />
    /// 下一周。
    /// </summary>
    /// <param name="ld"></param>
    /// <returns></returns>
    public static LocalDate NextWeek(this LocalDate ld) => ld.AddWeeks(1);

    /// <summary>
    /// Previous Week.<br />
    /// 上一周。
    /// </summary>
    /// <param name="ld"></param>
    /// <returns></returns>
    public static LocalDate PreviousWeek(this LocalDate ld) => ld.AddWeeks(-1);

    /// <summary>
    /// Next day.<br />
    /// 下一天。
    /// </summary>
    /// <param name="ld"></param>
    /// <returns></returns>
    public static LocalDate NextDay(this LocalDate ld) => ld.AddDays(1);

    /// <summary>
    /// Previous Day.<br />
    /// 上一天。
    /// </summary>
    /// <param name="ld"></param>
    /// <returns></returns>
    public static LocalDate PreviousDay(this LocalDate ld) => ld.AddDays(-1);

    /// <summary>
    /// Returns the next date with the specified day-of-week. <br/>
    /// 返回具有指定星期几的下一个日期。
    /// </summary>
    /// <param name="ld"></param>
    /// <param name="dayOfWeek"></param>
    /// <returns></returns>
    public static LocalDate Next(this LocalDate ld, DayOfWeek dayOfWeek)
    {
        return DateAdjusters.Next(dayOfWeek.AsIsoDayOfWeek())(ld);
    }

    /// <summary>
    /// Returns the next date with the specified day-of-week. <br/>
    /// 返回具有指定星期几的下一个日期。
    /// </summary>
    /// <param name="ld"></param>
    /// <param name="dayOfWeek"></param>
    /// <returns></returns>
    public static LocalDate Next(this LocalDate ld, IsoDayOfWeek dayOfWeek)
    {
        return DateAdjusters.Next(dayOfWeek)(ld);
    }

    /// <summary>
    /// Returns the next date with the specified day-of-week, or the original date, if the day is already correct.<br/>
    /// 返回具有指定星期几的下一个日期，或者返回原始日期（如果该日期已经正确）。
    /// </summary>
    /// <param name="ld"></param>
    /// <param name="dayOfWeek"></param>
    /// <returns></returns>
    public static LocalDate NextOrSame(this LocalDate ld, DayOfWeek dayOfWeek)
    {
        return DateAdjusters.NextOrSame(dayOfWeek.AsIsoDayOfWeek())(ld);
    }

    /// <summary>
    /// Returns the next date with the specified day-of-week, or the original date, if the day is already correct.<br/>
    /// 返回具有指定星期几的下一个日期，或者返回原始日期（如果该日期已经正确）。
    /// </summary>
    /// <param name="ld"></param>
    /// <param name="dayOfWeek"></param>
    /// <returns></returns>
    public static LocalDate NextOrSame(this LocalDate ld, IsoDayOfWeek dayOfWeek)
    {
        return DateAdjusters.NextOrSame(dayOfWeek)(ld);
    }

    /// <summary>
    /// Returns the previous date with the specified day-of-week.<br/>
    /// 返回具有指定星期几的上一个日期。
    /// </summary>
    /// <param name="ld"></param>
    /// <param name="dayOfWeek"></param>
    /// <returns></returns>
    public static LocalDate Previous(this LocalDate ld, DayOfWeek dayOfWeek)
    {
        return DateAdjusters.Previous(dayOfWeek.AsIsoDayOfWeek())(ld);
    }

    /// <summary>
    /// Returns the previous date with the specified day-of-week.<br/>
    /// 返回具有指定星期几的上一个日期。
    /// </summary>
    /// <param name="ld"></param>
    /// <param name="dayOfWeek"></param>
    /// <returns></returns>
    public static LocalDate Previous(this LocalDate ld, IsoDayOfWeek dayOfWeek)
    {
        return DateAdjusters.Previous(dayOfWeek)(ld);
    }

    /// <summary>
    /// Returns the previous date with the specified day-of-week, or the original date, if the day is already correct.<br/>
    /// 返回具有指定星期几的上一个日期，或者返回原始日期（如果该日期已经正确）。
    /// </summary>
    /// <param name="ld"></param>
    /// <param name="dayOfWeek"></param>
    /// <returns></returns>
    public static LocalDate PreviousOrSame(this LocalDate ld, DayOfWeek dayOfWeek)
    {
        return DateAdjusters.PreviousOrSame(dayOfWeek.AsIsoDayOfWeek())(ld);
    }

    /// <summary>
    /// Returns the previous date with the specified day-of-week, or the original date, if the day is already correct.<br/>
    /// 返回具有指定星期几的上一个日期，或者返回原始日期（如果该日期已经正确）。
    /// </summary>
    /// <param name="ld"></param>
    /// <param name="dayOfWeek"></param>
    /// <returns></returns>
    public static LocalDate PreviousOrSame(this LocalDate ld, IsoDayOfWeek dayOfWeek)
    {
        return DateAdjusters.PreviousOrSame(dayOfWeek)(ld);
    }

    #endregion

    #region Set

    /// <summary>
    /// Set the year.<br />
    /// 设置年份。
    /// </summary>
    /// <param name="ld"></param>
    /// <param name="year"></param>
    /// <returns></returns>
    public static LocalDate SetDate(this LocalDate ld, int year) =>
        new LocalDate(ld.Era, year, ld.Month, ld.Day, ld.Calendar);

    /// <summary>
    /// Set the year and month.<br />
    /// 设置年和月。
    /// </summary>
    /// <param name="ld"></param>
    /// <param name="year"></param>
    /// <param name="month"></param>
    /// <returns></returns>
    public static LocalDate SetDate(this LocalDate ld, int year, int month) =>
        new LocalDate(ld.Era, year, month, ld.Day, ld.Calendar);

    /// <summary>
    /// Set the year, month, and day.<br />
    /// 设置年、月和日。
    /// </summary>
    /// <param name="ld"></param>
    /// <param name="year"></param>
    /// <param name="month"></param>
    /// <param name="day"></param>
    /// <returns></returns>
    public static LocalDate SetDate(this LocalDate ld, int year, int month, int day) =>
        new LocalDate(ld.Era, year, month, day, ld.Calendar);

    /// <summary>
    /// Set the year.<br />
    /// 设置年份。
    /// </summary>
    /// <param name="ld"></param>
    /// <param name="year"></param>
    /// <returns></returns>
    public static LocalDate SetYear(this LocalDate ld, int year) =>
        new LocalDate(ld.Era, year, ld.Month, ld.Day, ld.Calendar);

    /// <summary>
    /// Set the month.<br />
    /// 设置月份。
    /// </summary>
    /// <param name="ld"></param>
    /// <param name="month"></param>
    /// <returns></returns>
    public static LocalDate SetMonth(this LocalDate ld, int month) =>
        DateAdjusters.Month(month)(ld);

    /// <summary>
    /// Set the day.<br />
    /// 设置日期中的天。
    /// </summary>
    /// <param name="ld"></param>
    /// <param name="day"></param>
    /// <returns></returns>
    public static LocalDate SetDay(this LocalDate ld, int day) =>
        DateAdjusters.DayOfMonth(day)(ld);

    #endregion

    #region To

    /// <summary>
    /// To DateTime
    /// </summary>
    /// <param name="ld"></param>
    /// <returns></returns>
    public static DateTime ToDateTime(this LocalDate ld) => ld.ToDateTimeUnspecified();

    /// <summary>
    /// To Datetime
    /// </summary>
    /// <param name="ld"></param>
    /// <param name="kind"></param>
    /// <returns></returns>
    public static DateTime ToDateTime(this LocalDate ld, DateTimeKind kind) =>
        DateTimeFactory.Create(ld.Year, ld.Month, ld.Day, 0, 0, 0, 0, kind);

    /// <summary>
    /// To DateInfo
    /// </summary>
    /// <param name="ld"></param>
    /// <returns></returns>
    public static DateInfo ToDateInfo(this LocalDate ld) => new DateInfo(ld.Year, ld.Month, ld.Day);

    /// <summary>
    /// To LocalDateTime
    /// </summary>
    /// <param name="ld"></param>
    /// <returns></returns>
    public static LocalDateTime ToLocalDateTime(this LocalDate ld) =>
        new LocalDateTime(ld.Year, ld.Month, ld.Day, 0, 0);

    /// <summary>
    /// To LocalDateTime
    /// </summary>
    /// <param name="ld"></param>
    /// <param name="calendar"></param>
    /// <returns></returns>
    public static LocalDateTime ToLocalDateTime(this LocalDate ld, CalendarSystem calendar) =>
        new LocalDateTime(ld.Year, ld.Month, ld.Day, 0, 0, calendar);

    /// <summary>
    /// To LocalDateTime
    /// </summary>
    /// <param name="ld"></param>
    /// <param name="hours"></param>
    /// <returns></returns>
    public static LocalDateTime ToLocalDateTime(this LocalDate ld, int hours) =>
        new LocalDateTime(ld.Year, ld.Month, ld.Day, hours, 0);

    /// <summary>
    /// To LocalDateTime
    /// </summary>
    /// <param name="ld"></param>
    /// <param name="hours"></param>
    /// <param name="calendar"></param>
    /// <returns></returns>
    public static LocalDateTime ToLocalDateTime(this LocalDate ld, int hours, CalendarSystem calendar) =>
        new LocalDateTime(ld.Year, ld.Month, ld.Day, hours, 0, calendar);

    /// <summary>
    /// To LocalDateTime
    /// </summary>
    /// <param name="ld"></param>
    /// <param name="hours"></param>
    /// <param name="minutes"></param>
    /// <returns></returns>
    public static LocalDateTime ToLocalDateTime(this LocalDate ld, int hours, int minutes) =>
        new LocalDateTime(ld.Year, ld.Month, ld.Day, hours, minutes);

    /// <summary>
    /// To LocalDateTime
    /// </summary>
    /// <param name="ld"></param>
    /// <param name="hours"></param>
    /// <param name="minutes"></param>
    /// <param name="calendar"></param>
    /// <returns></returns>
    public static LocalDateTime ToLocalDateTime(this LocalDate ld, int hours, int minutes, CalendarSystem calendar) =>
        new LocalDateTime(ld.Year, ld.Month, ld.Day, hours, minutes, calendar);

    /// <summary>
    /// To LocalDateTime
    /// </summary>
    /// <param name="ld"></param>
    /// <param name="hours"></param>
    /// <param name="minutes"></param>
    /// <param name="seconds"></param>
    /// <returns></returns>
    public static LocalDateTime ToLocalDateTime(this LocalDate ld, int hours, int minutes, int seconds) =>
        new LocalDateTime(ld.Year, ld.Month, ld.Day, hours, minutes, seconds);

    /// <summary>
    /// To LocalDateTime
    /// </summary>
    /// <param name="ld"></param>
    /// <param name="hours"></param>
    /// <param name="minutes"></param>
    /// <param name="seconds"></param>
    /// <param name="calendar"></param>
    /// <returns></returns>
    public static LocalDateTime ToLocalDateTime(this LocalDate ld, int hours, int minutes, int seconds, CalendarSystem calendar) =>
        new LocalDateTime(ld.Year, ld.Month, ld.Day, hours, minutes, seconds, calendar);

    /// <summary>
    /// To LocalDateTime
    /// </summary>
    /// <param name="ld"></param>
    /// <param name="hours"></param>
    /// <param name="minutes"></param>
    /// <param name="seconds"></param>
    /// <param name="milliseconds"></param>
    /// <returns></returns>
    public static LocalDateTime ToLocalDateTime(this LocalDate ld, int hours, int minutes, int seconds, int milliseconds) =>
        new LocalDateTime(ld.Year, ld.Month, ld.Day, hours, minutes, seconds, milliseconds);

    /// <summary>
    /// To LocalDateTime
    /// </summary>
    /// <param name="ld"></param>
    /// <param name="hours"></param>
    /// <param name="minutes"></param>
    /// <param name="seconds"></param>
    /// <param name="milliseconds"></param>
    /// <param name="calendar"></param>
    /// <returns></returns>
    public static LocalDateTime ToLocalDateTime(this LocalDate ld, int hours, int minutes, int seconds, int milliseconds, CalendarSystem calendar) =>
        new LocalDateTime(ld.Year, ld.Month, ld.Day, hours, minutes, seconds, milliseconds, calendar);

    #endregion
}