using Cosmos.Conversions;
using Cosmos.Date.DateUtils;

namespace Cosmos.Date;

/// <summary>
/// DateTime Factory<br />
/// 时间工厂
/// </summary>
public static class DateTimeFactory
{
    #region Now

    /// <summary>
    /// Now<br />
    /// 此刻
    /// </summary>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTime Now() => DateTime.Now;

    /// <summary>
    /// Now<br />
    /// 此刻
    /// </summary>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTime UtcNow() => DateTime.UtcNow;

    #endregion

    #region Create

    /// <summary>
    /// Create <see cref="DateTime"/> by special date.<br />
    /// 根据指定的日期创建 <see cref="DateTime"/>
    /// </summary>
    /// <param name="year"></param>
    /// <param name="month"></param>
    /// <param name="day"></param>
    /// <returns></returns>
    public static DateTime Create(int year, int month, int day)
    {
        try
        {
            return new (year, month, day);
        }
        catch (ArgumentOutOfRangeException exception)
        {
            throw new DateTimeOutOfRangeException($"Date '{year}-{month}-{day}' out of range.", exception);
        }
        catch (Exception exception)
        {
            throw new InvalidDateTimeException($"Date '{year}-{month}-{day}' is invalid.", exception);
        }
    }

    /// <summary>
    /// Create <see cref="DateTime"/> by special date.<br />
    /// 根据指定的日期创建 <see cref="DateTime"/>
    /// </summary>
    /// <param name="year"></param>
    /// <param name="month"></param>
    /// <param name="day"></param>
    /// <param name="hour"></param>
    /// <param name="minute"></param>
    /// <param name="second"></param>
    /// <returns></returns>
    public static DateTime Create(int year, int month, int day, int hour, int minute, int second)
    {
        try
        {
            return new (year, month, day, hour, minute, second);
        }
        catch (ArgumentOutOfRangeException exception)
        {
            throw new DateTimeOutOfRangeException($"Date '{year}-{month}-{day} {hour}:{minute}:{second}' out of range.", exception);
        }
        catch (Exception exception)
        {
            throw new InvalidDateTimeException($"Date '{year}-{month}-{day} {hour}:{minute}:{second}' is invalid.", exception);
        }
    }

    /// <summary>
    /// Create <see cref="DateTime"/> by special date.<br />
    /// 根据指定的日期创建 <see cref="DateTime"/>
    /// </summary>
    /// <param name="year"></param>
    /// <param name="month"></param>
    /// <param name="day"></param>
    /// <param name="hour"></param>
    /// <param name="minute"></param>
    /// <param name="second"></param>
    /// <param name="millisecond"></param>
    /// <returns></returns>
    public static DateTime Create(int year, int month, int day, int hour, int minute, int second, int millisecond)
    {
        try
        {
            return new (year, month, day, hour, minute, second, millisecond);
        }
        catch (ArgumentOutOfRangeException exception)
        {
            throw new DateTimeOutOfRangeException($"Date '{year}-{month}-{day} {hour}:{minute}:{second}.{millisecond}' out of range.", exception);
        }
        catch (Exception exception)
        {
            throw new InvalidDateTimeException($"Date '{year}-{month}-{day} {hour}:{minute}:{second}.{millisecond}' is invalid.", exception);
        }
    }

    /// <summary>
    /// Create <see cref="DateTime"/> by special date.<br />
    /// 根据指定的日期创建 <see cref="DateTime"/>
    /// </summary>
    /// <param name="year"></param>
    /// <param name="month"></param>
    /// <param name="day"></param>
    /// <param name="hour"></param>
    /// <param name="minute"></param>
    /// <param name="second"></param>
    /// <param name="millisecond"></param>
    /// <param name="kind"></param>
    /// <returns></returns>
    /// <exception cref="DateTimeOutOfRangeException"></exception>
    /// <exception cref="InvalidDateTimeException"></exception>
    public static DateTime Create(int year, int month, int day, int hour, int minute, int second, int millisecond, DateTimeKind kind)
    {
        try
        {
            return new (year, month, day, hour, minute, second, millisecond, kind);
        }
        catch (ArgumentOutOfRangeException exception)
        {
            throw new DateTimeOutOfRangeException($"Date '{year}-{month}-{day} {hour}:{minute}:{second}.{millisecond}' out of range.", exception);
        }
        catch (Exception exception)
        {
            throw new InvalidDateTimeException($"Date '{year}-{month}-{day} {hour}:{minute}:{second}.{millisecond}' is invalid.", exception);
        }
    }

    #endregion

    #region Create Last Day of Month

    /// <summary>
    /// To get the latest weekday for example Monday in a month.<br />
    /// 寻找一个月中的最后一个日期
    /// </summary>
    /// <param name="year"></param>
    /// <param name="month"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTime CreateLastDayOfMonth(int year, int month)
        => Create(year, month, DateTime.DaysInMonth(year, month));

    /// <summary>
    /// To get the latest weekday for example Monday in a month.<br />
    /// 寻找一个月中的最后一个工作日（如周一）
    /// </summary>
    /// <param name="year"></param>
    /// <param name="month"></param>
    /// <param name="dayOfWeek"></param>
    /// <returns></returns>
    public static DateTime CreateLastDayOfMonth(int year, int month, DayOfWeek dayOfWeek)
    {
        return DateTimeCalc.TryOffsetByWeek(year, month, 5, dayOfWeek, out var resultedDay)
            ? resultedDay
            : DateTimeCalc.OffsetByWeek(year, month, 4, dayOfWeek);
    }

    /// <summary>
    /// To get the latest weekday for example Monday in a month.<br />
    /// 寻找一个月中的最后一个工作日（如周一）
    /// </summary>
    /// <param name="year"></param>
    /// <param name="month"></param>
    /// <param name="dayOfWeek"></param>
    /// <returns></returns>
    public static DateTime CreateLastDayOfMonth(int year, int month, int dayOfWeek)
    {
        return DateTimeCalc.TryOffsetByWeek(year, month, 5, dayOfWeek, out var resultedDay)
            ? resultedDay
            : DateTimeCalc.OffsetByWeek(year, month, 4, dayOfWeek);
    }

    #endregion

    #region Create First Day of Month

    /// <summary>
    /// To get the first weekday for example Monday in a month.<br />
    /// 寻找一个月中的最后一个日期
    /// </summary>
    /// <param name="year"></param>
    /// <param name="month"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTime CreateFirstDayOfMonth(int year, int month) => Create(year, month, 1);

    /// <summary>
    /// To get the first weekday for example Monday in a month.<br />
    /// 寻找一个月中的最后一个日期
    /// </summary>
    /// <param name="year"></param>
    /// <param name="month"></param>
    /// <param name="dayOfWeek"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTime CreateFirstDayOfMonth(int year, int month, DayOfWeek dayOfWeek)
        => DateTimeCalc.OffsetByWeek(year, month, 1, dayOfWeek);

    /// <summary>
    /// To get the first weekday for example Monday in a month.<br />
    /// 寻找一个月中的最后一个日期
    /// </summary>
    /// <param name="year"></param>
    /// <param name="month"></param>
    /// <param name="dayOfWeek"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTime CreateFirstDayOfMonth(int year, int month, int dayOfWeek)
        => DateTimeCalc.OffsetByWeek(year, month, 1, dayOfWeek);

    #endregion

    #region Create Next Day by Week

    /// <summary>
    /// Find the next weekday for example Monday from a special date.<br />
    /// 根据指定的日期，获得下一个工作日（如周一）
    /// </summary>
    /// <param name="year"></param>
    /// <param name="month"></param>
    /// <param name="day"></param>
    /// <param name="dayOfWeek"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTime CreateNextDayByWeek(int year, int month, int day, DayOfWeek dayOfWeek)
        => DateTimeCalc.OffsetByWeekAfter(Create(year, month, day), dayOfWeek);

    /// <summary>
    /// Find the next weekday for example Monday from a special date.<br />
    /// 根据指定的日期，获得下一个工作日（如周一）
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="dayOfWeek"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTime CreateNextDayByWeek(DateTime dt, DayOfWeek dayOfWeek)
        => DateTimeCalc.OffsetByWeekAfter(dt, dayOfWeek);

    #endregion

    #region Create Previous Day by Week

    /// <summary>
    /// Find the next weekday for example Monday before a special date.<br />
    /// 根据指定的日期，获得上一个工作日（如周一）
    /// </summary>
    /// <param name="year"></param>
    /// <param name="month"></param>
    /// <param name="day"></param>
    /// <param name="dayOfWeek"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTime CreatePreviousDayByWeek(int year, int month, int day, DayOfWeek dayOfWeek)
        => DateTimeCalc.OffsetByWeekBefore(Create(year, month, day), dayOfWeek);

    /// <summary>
    /// Find the next weekday for example Monday before a special date.<br />
    /// 根据指定的日期，获得上一个工作日（如周一）
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="dayOfWeek"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTime CreatePreviousDayByWeek(DateTime dt, DayOfWeek dayOfWeek)
        => DateTimeCalc.OffsetByWeekBefore(dt, dayOfWeek);

    #endregion

    #region Create Day by Week

    /// <summary>
    /// Find for example the 3th Monday in a month.<br />
    /// 寻找指定的日期（如一个月的第三个周一）
    /// </summary>
    /// <param name="year"></param>
    /// <param name="month"></param>
    /// <param name="dayOfWeek"></param>
    /// <param name="occurrence"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTime CreateByWeek(int year, int month, DayOfWeek dayOfWeek, int occurrence)
        => DateTimeCalc.OffsetByWeek(year, month, occurrence, dayOfWeek.CastToInt(0));

    #endregion
}