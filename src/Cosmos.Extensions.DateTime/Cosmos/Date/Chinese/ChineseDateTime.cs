namespace Cosmos.Date.Chinese;

/// <summary>
/// Chinese Date Time<br />
/// 中国农历日期与时间
/// </summary>
public class ChineseDateTime
{
    private DateTime InternalDateTime { get; }
    private ChineseLunisolarCalendar Calendar { get; }

    /// <summary>
    /// Create a new instance for <see cref="ChineseDateTime"/><br />
    /// 创建一个 <see cref="ChineseDateTime"/> 的新实例
    /// </summary>
    /// <param name="dt"></param>
    public ChineseDateTime(DateTime dt)
    {
        InternalDateTime = dt;
        Calendar = new ChineseLunisolarCalendar();
    }

    /// <summary>
    /// Create a new instance for <see cref="ChineseDateTime"/><br />
    /// 创建一个 <see cref="ChineseDateTime"/> 的新实例
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="calendar"></param>
    private ChineseDateTime(DateTime dt, ChineseLunisolarCalendar calendar)
    {
        InternalDateTime = dt;
        Calendar = calendar;
    }

    /// <summary>
    /// Is current year a leap year.<br />
    /// 当前年份是否为闰年
    /// </summary>
    /// <returns></returns>
    public bool IsLeapYear() => ChineseDateHelper.IsLeapYear(Calendar, InternalDateTime);

    /// <summary>
    /// Is current month a leap month.<br />
    /// 当前月份是否为闰月
    /// </summary>
    /// <returns></returns>
    public bool IsLeapMonth() => ChineseDateHelper.IsLeapMonth(Calendar, InternalDateTime);

    /// <summary>
    /// Is current day a leap day.<br />
    /// 当前日份是否为闰日
    /// </summary>
    /// <returns></returns>
    public bool IsLeapDay() => ChineseDateHelper.IsLeapDay(Calendar, InternalDateTime);

    /// <summary>
    /// Is current day weekend<br />
    /// 当天日期是否为周末
    /// </summary>
    /// <returns></returns>
    public bool IsWeekend() => InternalDateTime.IsWeekend();

    /// <summary>
    /// Is current day a work day<br />
    /// 当前日期是否为工作日
    /// </summary>
    /// <returns></returns>
    public bool IsWorkDay() => InternalDateTime.IsWeekday();

    /// <summary>
    /// Gets Chinese year<br />
    /// 获取农历年份
    /// </summary>
    public int ChineseYear => Calendar.GetYear(InternalDateTime);

    /// <summary>
    /// Gets Chinese year as string<br />
    /// 获取汉字农历年份
    /// </summary>
    /// <param name="traditionalChineseCharacters"></param>
    /// <returns></returns>
    public string GetChineseYear(bool traditionalChineseCharacters = false) => ChineseDateHelper.GetChineseYear(InternalDateTime, traditionalChineseCharacters);

    /// <summary>
    /// Gets Chines Sexagenary Year<br />
    /// 获取干支年
    /// </summary>
    /// <param name="traditionalChineseCharacters"></param>
    /// <returns></returns>
    public string GetSexagenaryYear(bool traditionalChineseCharacters = false) => ChineseDateHelper.GetSexagenaryYear(Calendar, InternalDateTime, traditionalChineseCharacters);

    /// <summary>
    /// Gets Chinese month.<br />
    /// 获取农历月份
    /// </summary>
    public int ChineseMonth => Calendar.GetMonth(InternalDateTime);

    /// <summary>
    /// Gets Chinese month as string.<br />
    /// 获取汉字农历月份
    /// </summary>
    /// <param name="traditionalChineseCharacters"></param>
    /// <returns></returns>
    public string GetChineseMonth(bool traditionalChineseCharacters = false) => ChineseDateHelper.GetChineseMonth(Calendar, InternalDateTime, traditionalChineseCharacters);

    /// <summary>
    /// Gets Chinese day.<br />
    /// 获取农历日份
    /// </summary>
    public int ChineseDay => Calendar.GetDayOfMonth(InternalDateTime);

    /// <summary>
    /// Gets Chinese day as string.<br />
    /// 获取汉字农历日份
    /// </summary>
    public string GetChineseDay(bool traditionalChineseCharacters = false) => ChineseDateHelper.GetChineseDay(Calendar, InternalDateTime, traditionalChineseCharacters);

    /// <summary>
    /// Gets Chinese date<br />
    /// 获取农历日期
    /// </summary>
    /// <param name="traditionalChineseCharacters"></param>
    /// <returns></returns>
    public string GetChineseDate(bool traditionalChineseCharacters = false) => $"{GetChineseMonth(traditionalChineseCharacters)}{GetChineseDay(traditionalChineseCharacters)}";

    /// <summary>
    /// Gets Chinese date with Chinese year<br />
    /// 获取农历日期（带年份）
    /// </summary>
    /// <param name="traditionalChineseCharacters"></param>
    /// <returns></returns>
    public string GetChineseDateWithYear(bool traditionalChineseCharacters = false) =>
        $"{GetChineseYear(traditionalChineseCharacters)}{GetChineseDate(traditionalChineseCharacters)}";

    /// <summary>
    /// Gets Chinese date with Chinese Sexagenary year<br />
    /// 获取农历日期（带干支年分）
    /// </summary>
    /// <param name="traditionalChineseCharacters"></param>
    /// <returns></returns>
    public string GetChineseDateWithSexagenaryYear(bool traditionalChineseCharacters = false) =>
        $"{GetSexagenaryYear(traditionalChineseCharacters)}{GetChineseDate(traditionalChineseCharacters)}";

    /// <summary>
    /// Gets Chinese Time<br />
    /// 获取农历时辰信息
    /// </summary>
    /// <param name="traditionalChineseCharacters"></param>
    /// <returns></returns>
    public string GetChineseTime(bool traditionalChineseCharacters = false) => ChineseDateHelper.GetChineseHour(Calendar, InternalDateTime, traditionalChineseCharacters);

    /// <summary>
    /// Gets solar term<br />
    /// 获取节气
    /// </summary>
    /// <param name="traditionalChineseCharacters"></param>
    /// <returns></returns>
    public string GetSolarTerm(bool traditionalChineseCharacters = false) => ChineseSolarTermHelper.GetSolarTerm(Calendar, InternalDateTime, traditionalChineseCharacters);

    /// <summary>
    /// Gets last solar term<br />
    /// 获得上一个节气
    /// </summary>
    /// <param name="traditionalChineseCharacters"></param>
    /// <returns></returns>
    public string GetLastSolarTerm(bool traditionalChineseCharacters = false) =>
        ChineseSolarTermHelper.GetLastSolarTerm(Calendar, InternalDateTime, traditionalChineseCharacters);

    /// <summary>
    /// Gets last solar term<br />
    /// 获得上一个节气和具体的公历时间
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="traditionalChineseCharacters"></param>
    /// <returns></returns>
    public string GetLastSolarTerm(out DateTime dt, bool traditionalChineseCharacters = false) =>
        ChineseSolarTermHelper.GetLastSolarTerm(Calendar, InternalDateTime, out dt, traditionalChineseCharacters);

    /// <summary>
    /// Gets next solar term<br />
    /// 获得下一个节气
    /// </summary>
    /// <param name="traditionalChineseCharacters"></param>
    /// <returns></returns>
    public string GetNextSolarTerm(bool traditionalChineseCharacters = false) =>
        ChineseSolarTermHelper.GetNextSolarTerm(Calendar, InternalDateTime, traditionalChineseCharacters);

    /// <summary>
    /// Gets next solar term<br />
    /// 获得下一个节气和具体的公历时间
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="traditionalChineseCharacters"></param>
    /// <returns></returns>
    public string GetNextSolarTerm(out DateTime dt, bool traditionalChineseCharacters = false) =>
        ChineseSolarTermHelper.GetNextSolarTerm(Calendar, InternalDateTime, out dt, traditionalChineseCharacters);

    /// <summary>
    /// Tomorrow<br />
    /// 明天
    /// </summary>
    /// <returns></returns>
    public ChineseDateTime Tomorrow() => AddDays(1);

    /// <summary>
    /// Yesterday<br />
    /// 昨天
    /// </summary>
    /// <returns></returns>
    public ChineseDateTime Yesterday() => AddDays(-1);

    /// <summary>
    /// Add days<br />
    /// 添加若干天
    /// </summary>
    /// <param name="days"></param>
    /// <returns></returns>
    public ChineseDateTime AddDays(int days) => new(InternalDateTime.AddDays(days));

    /// <summary>
    /// Add work days<br />
    /// 添加若干工作日
    /// </summary>
    /// <param name="days"></param>
    /// <returns></returns>
    public ChineseDateTime AddWorkDays(int days)
    {
        var cc = new ChineseDateTime(InternalDateTime);
        if (days <= 0)
            days = 1;

        while (true)
        {
            cc = cc.Tomorrow();
            if (cc.IsWorkDay())
            {
                days--;
            }

            if (days == 0)
            {
                return cc;
            }
        }
    }

    /// <summary>
    /// Add months<br />
    /// 添加月份
    /// </summary>
    /// <param name="months"></param>
    /// <returns></returns>
    public ChineseDateTime AddMonths(int months) => new(InternalDateTime.AddMonths(months));

    /// <summary>
    /// Gets days in year.<br />
    /// 农历年中共有几天
    /// </summary>
    /// <returns></returns>
    public int GetDaysInYear() => Calendar.GetDaysInYear(InternalDateTime.Year);

    /// <summary>
    /// Gets days in month.<br />
    /// 农历月中共有几天
    /// </summary>
    /// <returns></returns>
    public int GetDaysInMonth() => Calendar.GetDaysInMonth(InternalDateTime.Year, InternalDateTime.Month);

    /// <summary>
    /// Calculates the day of the Chinese year in the special date.<br />
    /// 农历年中的第几天
    /// </summary>
    /// <returns></returns>
    public int GetDayOfYear() => Calendar.GetDayOfYear(InternalDateTime);

    /// <summary>
    /// Calculates the day of the Chinese month in the special date.<br />
    /// 农历月中的第几天
    /// </summary>
    /// <returns></returns>
    public int GetDayOfMonth() => Calendar.GetDayOfMonth(InternalDateTime);

    /// <summary>
    /// Calculates the day of the week in the special date.<br />
    /// 一周中的第几天
    /// </summary>
    /// <returns></returns>
    public DayOfWeek GetDayOfWeek() => Calendar.GetDayOfWeek(InternalDateTime);

    /// <summary>
    /// Convert <see cref="ChineseDateTime"/> to <see cref="DateTime"/>
    /// </summary>
    /// <param name="di"></param>
    public static implicit operator DateTime(ChineseDateTime di)
    {
        return di.InternalDateTime;
    }

    /// <summary>
    /// Convert <see cref="DateTime"/> to <see cref="ChineseDateTime"/>
    /// </summary>
    /// <param name="dt"></param>
    public static implicit operator ChineseDateTime(DateTime dt)
    {
        return new(dt);
    }

    /// <summary>
    /// Gets <see cref="ChineseLunisolarCalendar"/> instance internal.
    /// </summary>
    internal ChineseLunisolarCalendar InternalChineseLunisolarCalendar => Calendar;

    /// <summary>
    /// Gets internal datetime
    /// </summary>
    internal DateTime InternalTime => InternalDateTime;

    /// <summary>
    /// Convert to <see cref="DateTime"/><br />
    /// 转换为 <see cref="DateTime"/>
    /// </summary>
    /// <returns></returns>
    public DateTime ToDateTime() => InternalDateTime;

    /// <summary>
    /// Create a new instance of <see cref="ChineseDateTime"/><br />
    /// 创建一个新的 <see cref="ChineseDateTime"/> 实例。
    /// </summary>
    /// <param name="year"></param>
    /// <param name="month"></param>
    /// <param name="day"></param>
    /// <returns></returns>
    public static ChineseDateTime Of(int year, int month, int day)
    {
        return new(DateTimeFactory.Create(year, month, day));
    }

    /// <summary>
    /// Create a new instance of <see cref="ChineseDateTime"/><br />
    /// 创建一个新的 <see cref="ChineseDateTime"/> 实例。
    /// </summary>
    /// <param name="year"></param>
    /// <param name="month"></param>
    /// <param name="day"></param>
    /// <param name="hour"></param>
    /// <param name="minute"></param>
    /// <param name="second"></param>
    /// <returns></returns>
    public static ChineseDateTime Of(int year, int month, int day, int hour, int minute, int second)
    {
        return new(DateTimeFactory.Create(year, month, day, hour, minute, second));
    }

    /// <summary>
    /// Create a new instance of <see cref="ChineseDateTime"/><br />
    /// 创建一个新的 <see cref="ChineseDateTime"/> 实例。
    /// </summary>
    /// <param name="year"></param>
    /// <param name="month"></param>
    /// <param name="day"></param>
    /// <param name="hour"></param>
    /// <param name="minute"></param>
    /// <param name="second"></param>
    /// <param name="millisecond"></param>
    /// <returns></returns>
    public static ChineseDateTime Of(int year, int month, int day, int hour, int minute, int second, int millisecond)
    {
        return new(DateTimeFactory.Create(year, month, day, hour, minute, second, millisecond));
    }

    /// <summary>
    /// Create a new instance of <see cref="ChineseDateTime"/><br />
    /// 创建一个新的 <see cref="ChineseDateTime"/> 实例。
    /// </summary>
    /// <param name="year"></param>
    /// <param name="month"></param>
    /// <param name="day"></param>
    /// <returns></returns>
    public static ChineseDateTime OfLunar(int year, int month, int day)
    {
        var calendar = new ChineseLunisolarCalendar();
        return new ChineseDateTime(calendar.ToDateTime(year, month, day, 0, 0, 0, 0), calendar);
    }

    /// <summary>
    /// Create a new instance of <see cref="ChineseDateTime"/><br />
    /// 创建一个新的 <see cref="ChineseDateTime"/> 实例。
    /// </summary>
    /// <param name="year"></param>
    /// <param name="month"></param>
    /// <param name="day"></param>
    /// <param name="hour"></param>
    /// <param name="minute"></param>
    /// <param name="second"></param>
    /// <returns></returns>
    public static ChineseDateTime OfLunar(int year, int month, int day, int hour, int minute, int second)
    {
        var calendar = new ChineseLunisolarCalendar();
        return new ChineseDateTime(calendar.ToDateTime(year, month, day, hour, minute, second, 0), calendar);
    }

    /// <summary>
    /// Create a new instance of <see cref="ChineseDateTime"/><br />
    /// 创建一个新的 <see cref="ChineseDateTime"/> 实例。
    /// </summary>
    /// <param name="year"></param>
    /// <param name="month"></param>
    /// <param name="day"></param>
    /// <param name="hour"></param>
    /// <param name="minute"></param>
    /// <param name="second"></param>
    /// <param name="millisecond"></param>
    /// <returns></returns>
    public static ChineseDateTime OfLunar(int year, int month, int day, int hour, int minute, int second, int millisecond)
    {
        var calendar = new ChineseLunisolarCalendar();
        return new ChineseDateTime(calendar.ToDateTime(year, month, day, hour, minute, second, millisecond), calendar);
    }
}