using Cosmos.Conversions.Common;
using Cosmos.Reflection;
using NodaTime;

namespace Cosmos.Date;

/// <summary>
/// DateInfo <br />
/// 日期信息
/// </summary>
public partial class DateInfo
{
    // ReSharper disable once InconsistentNaming
    private DateTime _internalDateTime { get; set; }

    internal DateInfo() { }

    /// <summary>
    /// Create a new instance of <see cref="DateInfo"/>.<br />
    /// 创建一个新的 <see cref="DateInfo"/> 实例。
    /// </summary>
    /// <param name="dt"></param>
    public DateInfo(DateTime dt)
    {
        _internalDateTime = dt.Date;
    }

    /// <summary>
    /// Create a new instance of <see cref="DateInfo"/>.<br />
    /// 创建一个新的 <see cref="DateInfo"/> 实例。
    /// </summary>
    /// <param name="year"></param>
    /// <param name="month"></param>
    /// <param name="day"></param>
    public DateInfo(int year, int month, int day)
    {
        _internalDateTime = new DateTime(year, month, day);
    }

    static DateInfo()
    {
        // to register DateInfo ConvertHandler and Checker into CustomConvertManager
        CustomConvertManager.RegisterOrOverride(
            TypeClass.StringClazz,
            typeof(DateInfo),
            StringConvBeHandler,
            StringConvToHandler);
    }

    /// <summary>
    /// Year<br />
    /// 年
    /// </summary>
    public virtual int Year
    {
        get => _internalDateTime.Year;
        set => _internalDateTime = _internalDateTime.SetYear(value);
    }

    /// <summary>
    /// Month<br />
    /// 月份
    /// </summary>
    public virtual int Month
    {
        get => _internalDateTime.Month;
        set => _internalDateTime = _internalDateTime.SetMonth(DateChecker.CheckMonth(value));
    }

    /// <summary>
    /// Day<br />
    /// 日
    /// </summary>
    public virtual int Day
    {
        get => _internalDateTime.Day;
        set => _internalDateTime = _internalDateTime.SetDay(value);
    }

    /// <summary>
    /// Ticks<br />
    /// 获取表示此实例的日期的计时周期数。
    /// </summary>
    public virtual long Ticks => _internalDateTime.Ticks;

    public static DateInfo Today => new(DateTime.Today);

    /// <summary>
    /// Convert to <see cref="DateTime"/><br />
    /// 转换为 <see cref="DateTime"/>
    /// </summary>
    /// <returns></returns>
    public virtual DateTime ToDateTime() => _internalDateTime.Clone();

    /// <summary>
    /// Convert to <see cref="DateOnly"/><br />
    /// 转换为 <see cref="DateOnly"/>
    /// </summary>
    /// <returns></returns>
    public virtual DateOnly ToDateOnly() => DateOnly.FromDateTime(_internalDateTime);

    /// <summary>
    /// Convert to <see cref="LocalDate"/>. <br />
    /// 转换为本地日期
    /// </summary>
    /// <returns></returns>
    public LocalDate ToLocalDate() => LocalDate.FromDateTime(_internalDateTime);

    /// <summary>
    /// Convert to <see cref="LocalDateTime"/>. <br />
    /// 转换为本地日期时间
    /// </summary>
    /// <returns></returns>
    public LocalDateTime ToLocalDateTime() => LocalDateTime.FromDateTime(_internalDateTime);

    internal DateTime DateTimeRef => _internalDateTime;

    private static class DateChecker
    {
        public static int CheckMonth(int monthValue)
        {
            if (monthValue < 0 || monthValue > 12)
                throw new ArgumentOutOfRangeException(nameof(monthValue), monthValue, "Month should be from 1 to 12.");
            return monthValue;
        }
    }

    /// <summary>
    /// Add days<br />
    /// 添加天数
    /// </summary>
    /// <param name="days"></param>
    /// <returns></returns>
    public DateInfo AddDays(int days)
    {
        _internalDateTime += days.Days();
        return this;
    }

    /// <summary>
    /// Add months<br />
    /// 添加月份
    /// </summary>
    /// <param name="months"></param>
    /// <returns></returns>
    public DateInfo AddMonths(int months)
    {
        _internalDateTime += months.Months();
        return this;
    }

    /// <summary>
    /// Add years<br />
    /// 添加年份
    /// </summary>
    /// <param name="years"></param>
    /// <returns></returns>
    public DateInfo AddYears(int years)
    {
        _internalDateTime += years.Years();
        return this;
    }

    /// <summary>
    /// Add duration<br />
    /// 添加一段时间段
    /// </summary>
    /// <param name="duration"></param>
    /// <returns></returns>
    public DateInfo AddDuration(Duration duration)
    {
        _internalDateTime = _internalDateTime.AddDuration(duration);
        return this;
    }

    /// <summary>
    /// Gets day of week <br />
    /// 获取 DayOfWeek
    /// </summary>
    public DayOfWeek DayOfWeek => DateTimeRef.DayOfWeek;

    /// <summary>
    /// Convert <see cref="DateTime"/> to <see cref="DateInfo"/><br />
    /// 将 <see cref="DateTime"/> 转换为 <see cref="DateInfo"/>。
    /// </summary>
    /// <param name="di"></param>
    public static implicit operator DateTime(DateInfo di)
    {
        return di.ToDateTime();
    }

    /// <summary>
    /// Convert <see cref="DateInfo"/> to <see cref="DateTime"/><br />
    /// 将 <see cref="DateInfo"/> 转换为 <see cref="DateTime"/>。
    /// </summary>
    /// <param name="dt"></param>
    public static implicit operator DateInfo(DateTime dt)
    {
        return new(dt);
    }

    /// <summary>
    /// Convert <see cref="DateOnly"/> to <see cref="DateInfo"/><br />
    /// 将 <see cref="DateOnly"/> 转换为 <see cref="DateInfo"/>。
    /// </summary>
    /// <param name="di"></param>
    public static implicit operator DateOnly(DateInfo di)
    {
        return di.ToDateOnly();
    }

    /// <summary>
    /// Convert <see cref="DateInfo"/> to <see cref="DateOnly"/><br />
    /// 将 <see cref="DateInfo"/> 转换为 <see cref="DateOnly"/>。
    /// </summary>
    /// <param name="dt"></param>
    public static implicit operator DateInfo(DateOnly dt)
    {
        return FromDateOnly(dt);
    }

    /// <summary>
    /// +
    /// </summary>
    /// <param name="d"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    public static DateInfo operator +(DateInfo d, TimeSpan t)
    {
        return new(d._internalDateTime + t);
    }

    /// <summary>
    /// -
    /// </summary>
    /// <param name="d"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    public static DateInfo operator -(DateInfo d, TimeSpan t)
    {
        return new(d._internalDateTime - t);
    }

    /// <summary>
    /// &gt;
    /// </summary>
    /// <param name="d1"></param>
    /// <param name="d2"></param>
    /// <returns></returns>
    public static bool operator >(DateInfo d1, DateInfo d2)
    {
        if (d1 is null || d2 is null)
            return false;
        if (d1.Year > d2.Year)
            return true;
        if (d1.Year < d2.Year)
            return false;
        if (d1.Month > d2.Month)
            return true;
        if (d1.Month < d2.Month)
            return false;
        return d1.Day > d2.Day;
    }

    /// <summary>
    /// &gt;
    /// </summary>
    /// <param name="d"></param>
    /// <param name="dt"></param>
    /// <returns></returns>
    public static bool operator >(DateInfo d, DateTime dt)
    {
        if (d is null)
            return false;
        if (d.Year > dt.Year)
            return true;
        if (d.Year < dt.Year)
            return false;
        if (d.Month > dt.Month)
            return true;
        if (d.Month < dt.Month)
            return false;
        return d.Day > dt.Day;
    }

    /// <summary>
    /// &gt;
    /// </summary>
    /// <param name="d"></param>
    /// <param name="dt"></param>
    /// <returns></returns>
    public static bool operator >(DateInfo d, DateOnly dt)
    {
        if (d is null)
            return false;
        if (d.Year > dt.Year)
            return true;
        if (d.Year < dt.Year)
            return false;
        if (d.Month > dt.Month)
            return true;
        if (d.Month < dt.Month)
            return false;
        return d.Day > dt.Day;
    }

    /// <summary>
    /// &lt;
    /// </summary>
    /// <param name="d1"></param>
    /// <param name="d2"></param>
    /// <returns></returns>
    public static bool operator <(DateInfo d1, DateInfo d2)
    {
        if (d1 is null || d2 is null)
            return false;
        if (d1.Year < d2.Year)
            return true;
        if (d1.Year > d2.Year)
            return false;
        if (d1.Month < d2.Month)
            return true;
        if (d1.Month > d2.Month)
            return false;
        return d1.Day < d2.Day;
    }

    /// <summary>
    /// &lt;
    /// </summary>
    /// <param name="d"></param>
    /// <param name="dt"></param>
    /// <returns></returns>
    public static bool operator <(DateInfo d, DateTime dt)
    {
        if (d is null)
            return false;
        if (d.Year < dt.Year)
            return true;
        if (d.Year > dt.Year)
            return false;
        if (d.Month < dt.Month)
            return true;
        if (d.Month > dt.Month)
            return false;
        return d.Day < dt.Day;
    }

    /// <summary>
    /// &lt;
    /// </summary>
    /// <param name="d"></param>
    /// <param name="dt"></param>
    /// <returns></returns>
    public static bool operator <(DateInfo d, DateOnly dt)
    {
        if (d is null)
            return false;
        if (d.Year < dt.Year)
            return true;
        if (d.Year > dt.Year)
            return false;
        if (d.Month < dt.Month)
            return true;
        if (d.Month > dt.Month)
            return false;
        return d.Day < dt.Day;
    }

    /// <summary>
    /// &gt;=
    /// </summary>
    /// <param name="d1"></param>
    /// <param name="d2"></param>
    /// <returns></returns>
    public static bool operator >=(DateInfo d1, DateInfo d2)
    {
        if (d1 is null || d2 is null)
            return false;
        return !(d1 < d2);
    }

    /// <summary>
    /// &gt;=
    /// </summary>
    /// <param name="d"></param>
    /// <param name="dt"></param>
    /// <returns></returns>
    public static bool operator >=(DateInfo d, DateTime dt)
    {
        if (d is null)
            return false;
        return !(d < dt);
    }

    /// <summary>
    /// &gt;=
    /// </summary>
    /// <param name="d"></param>
    /// <param name="dt"></param>
    /// <returns></returns>
    public static bool operator >=(DateInfo d, DateOnly dt)
    {
        if (d is null)
            return false;
        return !(d < dt);
    }

    /// <summary>
    /// &lt;=
    /// </summary>
    /// <param name="d1"></param>
    /// <param name="d2"></param>
    /// <returns></returns>
    public static bool operator <=(DateInfo d1, DateInfo d2)
    {
        if (d1 is null || d2 is null)
            return false;
        return !(d1 > d2);
    }

    /// <summary>
    /// &lt;=
    /// </summary>
    /// <param name="d"></param>
    /// <param name="dt"></param>
    /// <returns></returns>
    public static bool operator <=(DateInfo d, DateTime dt)
    {
        if (d is null)
            return false;
        return !(d > dt);
    }

    /// <summary>
    /// &lt;=
    /// </summary>
    /// <param name="d"></param>
    /// <param name="dt"></param>
    /// <returns></returns>
    public static bool operator <=(DateInfo d, DateOnly dt)
    {
        if (d is null)
            return false;
        return !(d > dt);
    }

    /// <summary>
    /// ==
    /// </summary>
    /// <param name="d1"></param>
    /// <param name="d2"></param>
    /// <returns></returns>
    public static bool operator ==(DateInfo d1, DateInfo d2)
    {
        try
        {
            return d1!.Year == d2!.Year && d1.Month == d2.Month && d1.Day == d2.Day;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// ==
    /// </summary>
    /// <param name="d"></param>
    /// <param name="dt"></param>
    /// <returns></returns>
    public static bool operator ==(DateInfo d, DateTime dt)
    {
        if (d is null)
            return false;
        return d.Year == dt.Year && d.Month == dt.Month && d.Day == dt.Day;
    }

    /// <summary>
    /// ==
    /// </summary>
    /// <param name="d"></param>
    /// <param name="dt"></param>
    /// <returns></returns>
    public static bool operator ==(DateInfo d, DateOnly dt)
    {
        if (d is null)
            return false;
        return d.Year == dt.Year && d.Month == dt.Month && d.Day == dt.Day;
    }

    /// <summary>
    /// !=
    /// </summary>
    /// <param name="d1"></param>
    /// <param name="d2"></param>
    /// <returns></returns>
    public static bool operator !=(DateInfo d1, DateInfo d2)
    {
        if (d1 is null || d2 is null)
            return false;
        return !(d1 == d2);
    }

    /// <summary>
    /// !=
    /// </summary>
    /// <param name="d"></param>
    /// <param name="dt"></param>
    /// <returns></returns>
    public static bool operator !=(DateInfo d, DateTime dt)
    {
        if (d is null)
            return false;
        return !(d == dt);
    }

    /// <summary>
    /// !=
    /// </summary>
    /// <param name="d"></param>
    /// <param name="dt"></param>
    /// <returns></returns>
    public static bool operator !=(DateInfo d, DateOnly dt)
    {
        if (d is null)
            return false;
        return !(d == dt);
    }

    /// <summary>
    /// Equals<br />
    /// 相等
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object obj)
    {
        if (obj is null)
            return false;

        if (obj is DateInfo date)
        {
            return _internalDateTime.Equals(date._internalDateTime);
        }

        return false;
    }

    /// <summary>
    /// Get hashcode<br />
    /// 获取哈希值
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
        return Day.GetHashCode() ^ Month.GetHashCode() ^ Year.GetHashCode();
    }

    public override string ToString()
    {
        // ReSharper disable once SpecifyACultureInStringConversionExplicitly
        return _internalDateTime.ToString();
    }

    public string ToString(string format)
    {
        return _internalDateTime.ToString(format);
    }

    public string ToString(IFormatProvider provider)
    {
        return _internalDateTime.ToString(provider);
    }

    public string ToString(string format, IFormatProvider provider)
    {
        return _internalDateTime.ToString(format, provider);
    }

    public static int DaysInMonth(int year, int month)
    {
        return DateTime.DaysInMonth(year, month);
    }

    public static int DaysInYear(int year)
    {
        return DateTime.IsLeapYear(year) ? 366 : 365;
    }

    public static bool IsLeapYear(int year) => DateTime.IsLeapYear(year);

    /// <summary>
    /// To get an instance of Infinite Future Info. <br />
    /// 获取一个无限未来日期信息
    /// </summary>
    public static InfiniteFutureInfo InfiniteFuture => InfiniteFutureInfo.Instance;

    /// <summary>
    /// To get an instance of Infinite Past Info. <br />
    /// 获取一个无限过去日期信息
    /// </summary>
    public static InfinitePastInfo InfinitePast => InfinitePastInfo.Instance;

    /// <summary>
    /// Create a new instance of <see cref="DateInfo"/> from a <see cref="DateTime"/> object. <br />
    /// 从一个 <see cref="DateTime"/> 对象中创建一个 <see cref="DateInfo"/> 实例
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    public static DateInfo FromDateTime(DateTime dt)
    {
        return new(dt);
    }

    /// <summary>
    /// Create a new instance of <see cref="DateInfo"/> from a <see cref="DateOnly"/> object. <br />
    /// 从一个 <see cref="DateOnly"/> 对象中创建一个 <see cref="DateInfo"/> 实例
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public static DateInfo FromDateOnly(DateOnly date)
    {
        return new(date.Year, date.Month, date.Day);
    }
}