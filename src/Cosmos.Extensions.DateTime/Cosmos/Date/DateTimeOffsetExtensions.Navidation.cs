using Cosmos.Date.DateUtils;

namespace Cosmos.Date;

/// <summary>
/// DateTimeOffset Extensions <br />
/// DateTimeOffset 扩展
/// </summary>
public static partial class DateTimeOffsetExtensions
{
    #region Begin

    /// <summary>
    /// Beginning of day <br />
    /// 一天的开始
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTimeOffset BeginningOfDay(this DateTimeOffset dto)
        => new(dto.Year, dto.Month, dto.Day, 0, 0, 0, dto.Offset);

    #endregion

    #region End

    /// <summary>
    /// End of day <br />
    /// 一天的结束
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTimeOffset EndOfDay(this DateTimeOffset dto)
        => new(dto.Year, dto.Month, dto.Day, 23, 59, 59, 999, dto.Offset);

    #endregion

    #region Get

    /// <summary>
    /// First day of year <br />
    /// 一年的第一天
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTimeOffset FirstDayOfYear(this DateTimeOffset dto) => dto.SetDate(dto.Year, 1, 1);

    /// <summary>
    /// First day of quarter <br />
    /// 一个季度的第一天
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTimeOffset FirstDayOfQuarter(this DateTimeOffset dto)
    {
        var currentQuarter = (dto.Month - 1) / 3 + 1;
        return dto.SetDate(dto.Year, 3 * currentQuarter - 2, 1);
    }

    /// <summary>
    /// First day of month <br />
    /// 一个月的第一天
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTimeOffset FirstDayOfMonth(this DateTimeOffset dto) => dto.SetDay(1);

    /// <summary>
    /// First day of week <br />
    /// 一周的第一天
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public static DateTimeOffset FirstDayOfWeek(this DateTimeOffset dto)
    {
        var currentCulture = CultureInfo.CurrentCulture;
        var firstDayOfWeek = currentCulture.DateTimeFormat.FirstDayOfWeek;
        var offset = dto.DayOfWeek - firstDayOfWeek < 0 ? 7 : 0;
        var numberOfDaysSinceBeginningOfTheWeek = dto.DayOfWeek + offset - firstDayOfWeek;

        return dto.AddDays(-numberOfDaysSinceBeginningOfTheWeek);
    }

    /// <summary>
    /// Last day of year <br />
    /// 一年的最后一天
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTimeOffset LastDayOfYear(this DateTimeOffset dto) => dto.SetDate(dto.Year, 12, 31);

    /// <summary>
    /// Last day of quarter <br />
    /// 一个季度的最后一天
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public static DateTimeOffset LastDayOfQuarter(this DateTimeOffset dto)
    {
        var currentQuarter = (dto.Month - 1) / 3 + 1;
        var firstDay = dto.SetDate(dto.Year, 3 * currentQuarter - 2, 1);
        return firstDay.SetMonth(firstDay.Month + 2).LastDayOfMonth();
    }

    /// <summary>
    /// Last day of month <br />
    /// 一个月的最后一天
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTimeOffset LastDayOfMonth(this DateTimeOffset dto) => dto.SetDay(DateTime.DaysInMonth(dto.Year, dto.Month));

    /// <summary>
    /// Last day of week <br />
    /// 一周的最后一天
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTimeOffset LastDayOfWeek(this DateTimeOffset dto) => dto.FirstDayOfWeek().AddDays(6);

    /// <summary>
    /// Gets week after <br />
    /// 获取给定日期的下一周的对应那天
    /// </summary>
    /// <param name="start"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTimeOffset WeekAfter(this DateTimeOffset start) => start + 1.Weeks();

    /// <summary>
    /// Gets week before <br />
    /// 获取给定日期的上一周的对应那天
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTimeOffset WeekBefore(this DateTimeOffset dto) => dto - 1.Weeks();

    /// <summary>
    /// Midnight <br />
    /// 午夜
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTimeOffset Midnight(this DateTimeOffset dto) => dto.BeginningOfDay();

    /// <summary>
    /// Noon <br />
    /// 正午
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTimeOffset Noon(this DateTimeOffset dto) => dto.SetTime(12, 0, 0, 0);

    #endregion

    #region Navigation

    /// <summary>
    /// Next year <br />
    /// 下一年
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTimeOffset NextYear(this DateTimeOffset dto) => dto.ToLocalDateTime().NextYear();

    /// <summary>
    /// Previous year <br />
    /// 上一年
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTimeOffset PreviousYear(this DateTimeOffset dto) => dto.ToLocalDateTime().PreviousYear();

    /// <summary>
    /// Gets next quarter <br />
    /// 下一季度
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTimeOffset NextQuarter(this DateTimeOffset dto) => dto.ToLocalDateTime().NextQuarter();

    /// <summary>
    /// Gets previous quarter <br />
    /// 上一季度
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTimeOffset PreviousQuarter(this DateTimeOffset dto) => dto.ToLocalDateTime().PreviousQuarter();

    /// <summary>
    /// Next month <br />
    /// 下个月
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTimeOffset NextMonth(this DateTimeOffset dto) => dto.ToLocalDateTime().NextMonth();

    /// <summary>
    /// Previous month <br />
    /// 上个月
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTimeOffset PreviousMonth(this DateTimeOffset dto) => dto.ToLocalDateTime().PreviousMonth();

    /// <summary>
    /// Next week <br />
    /// 下周
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTimeOffset NextWeek(this DateTimeOffset dto) => dto.ToLocalDateTime().NextWeek();

    /// <summary>
    /// Previous week <br />
    /// 上周
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTimeOffset PreviousWeek(this DateTimeOffset dto) => dto.ToLocalDateTime().PreviousWeek();

    /// <summary>
    /// Next day <br />
    /// 下一天
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTimeOffset NextDay(this DateTimeOffset dto) => dto.ToLocalDateTime().NextDay();

    /// <summary>
    /// Previous day <br />
    /// 上一天
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTimeOffset PreviousDay(this DateTimeOffset dto) => dto.ToLocalDateTime().PreviousDay();

    /// <summary>
    /// Tomorrow <br />
    /// 明天
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTimeOffset Tomorrow(this DateTimeOffset dto) => dto.NextDay();

    /// <summary>
    /// Yesterday <br />
    /// 昨天
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTimeOffset Yesterday(this DateTimeOffset dto) => dto.PreviousDay();

    /// <summary>
    /// Next <br />
    /// 下一周对应的那天
    /// </summary>
    /// <param name="start"></param>
    /// <param name="dayOfWeek"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTimeOffset NextDayOfWeek(this DateTimeOffset start, DayOfWeek dayOfWeek) => DateTimeCalc.OffsetByDayOfWeek(start.ToLocalDateTime(), dayOfWeek, 1);

    /// <summary>
    /// Previous <br />
    /// 上一周对应的那天
    /// </summary>
    /// <param name="start"></param>
    /// <param name="dayOfWeek"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTimeOffset PreviousDayOfWeek(this DateTimeOffset start, DayOfWeek dayOfWeek) => DateTimeCalc.OffsetByDayOfWeek(start.ToLocalDateTime(), dayOfWeek, -1);

    #endregion
}