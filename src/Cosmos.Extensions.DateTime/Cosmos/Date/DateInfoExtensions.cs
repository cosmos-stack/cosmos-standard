namespace Cosmos.Date;

/// <summary>
/// Cosmos.Core <see cref="DateInfo"/> extensions. <br />
/// DateInfo 扩展
/// </summary>
public static partial class DateInfoExtensions
{
    #region Add

    /// <summary>
    /// Add weeks. <br />
    /// 加一周
    /// </summary>
    /// <param name="d"></param>
    /// <param name="weeks"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateInfo AddWeeks(this DateInfo d, int weeks) => d.AddDays(weeks * 7);

    /// <summary>
    /// Add quarters
    /// </summary>
    /// <param name="d"></param>
    /// <param name="quarters"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateInfo AddQuarters(this DateInfo d, int quarters) => d.AddMonths(quarters * 3);

    /// <summary>
    /// Add business days<br />
    /// 添加指定个数量的工作日
    /// </summary>
    /// <param name="d"></param>
    /// <param name="days"></param>
    /// <returns></returns>
    public static DateInfo AddBusinessDays(this DateInfo d, int days)
    {
        var sign = Math.Sign(days);
        var unsignedDays = Math.Abs(days);
        for (var i = 0; i < unsignedDays; i++)
        {
            do
            {
                d = d.AddDays(sign);
            } while (d.DayOfWeek == DayOfWeek.Saturday ||
                     d.DayOfWeek == DayOfWeek.Sunday);
        }

        return d;
    }

    #endregion

    #region Ago

    /// <summary>
    /// To ago.<br />
    /// 转换为 Ago
    /// </summary>
    /// <param name="d"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string ToAgo(this DateInfo d) => (DateTime.Now - d).ToAgo();

    #endregion

    #region Between

    /// <summary>
    /// Is current date between <paramref name="from"/> and <paramref name="to"/>.<br />
    /// 判断当前日期是否在 from 和 to 之间
    /// </summary>
    /// <param name="d"></param>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <param name="includeBoundary"></param>
    /// <returns></returns>
    public static bool IsBetween(this DateInfo d, DateInfo from, DateInfo to, bool includeBoundary = true)
    {
        var dtRef = d.DateTimeRef;
        var fromRef = from.DateTimeRef;
        var toRef = to.DateTimeRef;
        return dtRef.IsBetween(fromRef, toRef, includeBoundary);
    }

    /// <summary>
    /// Is current date between <paramref name="min"/> and <paramref name="max"/> with boundary.<br />
    /// 判断当前日期是否在 min 和 max 之间，闭包区间。
    /// </summary>
    /// <param name="d"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    public static bool IsDateBetweenWithBoundary(this DateInfo d, DateInfo min, DateInfo max)
    {
        var dtRef = d.DateTimeRef;
        var minRef = min.DateTimeRef;
        var maxRef = max.DateTimeRef;
        return dtRef.IsDateBetweenWithBoundary(minRef, maxRef);
    }

    /// <summary>
    /// Is current date between <paramref name="min"/> and <paramref name="max"/> without boundary.<br />
    /// 判断当前日期是否在 min 和 max 之间，开区间。
    /// </summary>
    /// <param name="d"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    public static bool IsDateBetweenWithoutBoundary(this DateInfo d, DateInfo min, DateInfo max)
    {
        var dtRef = d.DateTimeRef;
        var minRef = min.DateTimeRef;
        var maxRef = max.DateTimeRef;
        return dtRef.IsDateBetweenWithoutBoundary(minRef, maxRef);
    }

    #endregion

    #region Clone

    /// <summary>
    /// Clone<br />
    /// 克隆
    /// </summary>
    /// <param name="d"></param>
    /// <returns></returns>
    public static DateInfo Clone(this DateInfo d)
    {
        if (d is null)
            throw new ArgumentNullException(nameof(d));
        return new DateInfo(d.DateTimeRef);
    }

    #endregion

    #region Is

    /// <summary>
    /// Is the nextDay the day after current date.<br />
    /// 判断是否为第二天
    /// </summary>
    /// <param name="d"></param>
    /// <param name="next"></param>
    /// <returns></returns>
    public static bool IsNextMatched(this DateInfo d, DateInfo next)
    {
        if (d is null || next is null)
            return false;
        return d.Tomorrow().Equals(next);
    }

    /// <summary>
    /// Determine whether the specified time is in the past relative to the specified time. <br />
    /// 判断指定时间是否是相对给定时间的过去。
    /// </summary>
    /// <param name="d"></param>
    /// <param name="toCompareWith"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsBefore(this DateInfo d, DateInfo toCompareWith) => d < toCompareWith;

    /// <summary>
    /// Determine whether the specified time is in the future relative to the specified time. <br />
    /// 判断指定时间是否是相对给定时间的未来。
    /// </summary>
    /// <param name="d"></param>
    /// <param name="toCompareWith"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsAfter(this DateInfo d, DateInfo toCompareWith) => d > toCompareWith;

    /// <summary>
    /// Determine whether the given time is in the future. <br />
    /// 判断给定的时间是否在未来。
    /// </summary>
    /// <param name="d"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsInTheFuture(this DateInfo d) => d > DateTime.Now;

    /// <summary>
    /// Determine whether the given time is in the past. <br />
    /// 判断给定的时间是否在过去。
    /// </summary>
    /// <param name="d"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsInThePast(this DateInfo d) => d < DateTime.Now;

    /// <summary>
    /// Determine whether it is in the same day. <br />
    /// 判断是否在同一天。
    /// </summary>
    /// <param name="d"></param>
    /// <param name="date"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsSameDay(this DateInfo d, DateInfo date) => d.DateTimeRef == date.DateTimeRef;

    /// <summary>
    /// Determine whether it is in the same month. <br />
    /// 判断是否在同一个月。
    /// </summary>
    /// <param name="d"></param>
    /// <param name="date"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsSameMonth(this DateInfo d, DateInfo date) => d.Month == date.Month && d.Year == date.Year;

    /// <summary>
    /// Determine whether it is in the same year. <br />
    /// 判断是否在同一年。
    /// </summary>
    /// <param name="d"></param>
    /// <param name="date"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsSameYear(this DateInfo d, DateInfo date) => d.Year == date.Year;

    #endregion

    #region Set

    /// <summary>
    /// Set the year of the date. <br />
    /// 设置日期的年份。
    /// </summary>
    /// <param name="d"></param>
    /// <param name="year"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateInfo SetDate(this DateInfo d, int year)
    {
        d.Year = year;
        return d;
    }

    /// <summary>
    /// Set the year and month of the date. <br />
    /// 设置日期的年份和月份。
    /// </summary>
    /// <param name="d"></param>
    /// <param name="year"></param>
    /// <param name="month"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateInfo SetDate(this DateInfo d, int year, int month)
    {
        d.Year = year;
        d.Month = month;
        return d;
    }

    /// <summary>
    /// Set the year, month and day of the date. <br />
    /// 设置日期的年月日。
    /// </summary>
    /// <param name="d"></param>
    /// <param name="year"></param>
    /// <param name="month"></param>
    /// <param name="day"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateInfo SetDate(this DateInfo d, int year, int month, int day)
    {
        d.Year = year;
        d.Month = month;
        d.Day = day;
        return d;
    }

    /// <summary>
    /// Set the year of the date. <br />
    /// 设置日期的年份。
    /// </summary>
    /// <param name="d"></param>
    /// <param name="year"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateInfo SetYear(this DateInfo d, int year)
    {
        d.Year = year;
        return d;
    }

    /// <summary>
    /// Set the month of the date. <br />
    /// 设置日期的月份。
    /// </summary>
    /// <param name="d"></param>
    /// <param name="month"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateInfo SetMonth(this DateInfo d, int month)
    {
        d.Month = month;
        return d;
    }

    /// <summary>
    /// Set the day of the date. <br />
    /// 设置日期的具体的那一天。
    /// </summary>
    /// <param name="d"></param>
    /// <param name="day"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateInfo SetDay(this DateInfo d, int day)
    {
        d.Day = day;
        return d;
    }

    #endregion
}