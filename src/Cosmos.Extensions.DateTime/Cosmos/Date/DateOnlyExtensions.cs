#if NET6_0_OR_GREATER
using Cosmos.Verba.Time;
using NodaTime;

namespace Cosmos.Date;

// ReSharper disable once IdentifierTypo
using VERBA = GlobalTimeVerbaManager;

public static class DateOnlyExtensions
{
    #region Add

    /// <summary>
    /// Add weeks. <br />
    /// 添加一个星期。
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="weeks"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateOnly AddWeeks(this DateOnly dt, int weeks) => dt.ToDateTime().AddWeeks(weeks).ToDateOnly();

    /// <summary>
    /// Add quarters. <br />
    /// 添加一个季度。
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="quarters"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateOnly AddQuarters(this DateOnly dt, int quarters) => dt.ToDateTime().AddQuarters(quarters).ToDateOnly();

    /// <summary>
    /// Add duration. <br />
    /// 添加一段持续的时间
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="duration"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateOnly AddDuration(this DateOnly dt, Duration duration) => dt.ToDateTime().AddDuration(duration).ToDateOnly();

    /// <summary>
    /// Add business days. <br />
    /// 添加指定个数量的工作日
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="days"></param>
    /// <returns></returns>
    public static DateOnly AddBusinessDays(this DateOnly dt, int days) => dt.ToDateTime().AddBusinessDays(days).ToDateOnly();

    #endregion

    #region Age & Birthday

    /// <summary>
    /// Calculate the current age based on the given birthday time. <br />
    /// 根据给定的生日时间计算当前的年纪。
    /// </summary>
    /// <param name="birthday"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int ToCalculateAge(this DateOnly birthday) => birthday.ToDateTime().ToCalculateAge();

    /// <summary>
    /// Calculate the age relative to another time based on a given birthday time. <br />
    /// 根据生日和参照时间，计算当时年纪
    /// </summary>
    /// <param name="birthday">     </param>
    /// <param name="referenceDate"></param>
    /// <returns></returns>
    public static int ToCalculateAge(this DateOnly birthday, DateOnly referenceDate)
        => birthday.ToDateTime().ToCalculateAge(referenceDate.ToDateTime());

    #endregion

    #region Ago

    /// <summary>
    /// Format time interval <br />
    /// 格式化时间间隔
    /// </summary>
    /// <param name="date">對比的時間</param>
    /// <returns></returns>
    [Obsolete("将会被 Cosmos.Core.I18N 取代")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string ToAgo(this DateOnly date) => (DateTime.Now - date.ToDateTime()).ToAgo();

    #endregion

    #region Diff

    /// <summary>
    /// Calculate the number of months between two dates.<br />
    /// 计算两个时间之间相差的月份数。
    /// </summary>
    /// <param name="dt1"></param>
    /// <param name="dt2"></param>
    /// <returns></returns>
    public static int GetMonthDiff(this DateOnly dt1, DateOnly dt2) => dt1.ToDateTime().GetMonthDiff(dt2.ToDateTime());

    /// <summary>
    /// Calculate the exact number of months between two dates.<br />
    /// 计算两个日期之间相差的确切月份数。
    /// </summary>
    /// <param name="dt1"></param>
    /// <param name="dt2"></param>
    /// <returns></returns>
    public static double GetTotalMonthDiff(this DateOnly dt1, DateOnly dt2) => dt1.ToDateTime().GetTotalMonthDiff(dt2.ToDateTime());

    #endregion

    #region Elapsed

    /// <summary>
    /// Elapsed Time<br />
    /// 计算此刻与指定时间之间的时间差
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TimeSpan ElapsedTime(this DateOnly dt) => dt.ToDateTime().ElapsedTime();

    /// <summary>
    /// Elapsed Time<br />
    /// 计算此刻与指定时间之间的时间差（毫秒）
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int ElapsedMilliseconds(this DateOnly dt) => dt.ToDateTime().ElapsedMilliseconds();

    #endregion

    #region Is

    /// <summary>
    /// Is current date between <paramref name="from"/> and <paramref to="to"/>.<br />
    /// 判断当前日期是否在 from 和 to 之间
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <param name="includeBoundary"></param>
    /// <returns></returns>
    public static bool IsBetween(this DateOnly dt, DateOnly from, DateOnly to, bool includeBoundary = true)
    {
        return includeBoundary
            ? dt >= from && dt <= to
            : dt > from && dt < to;
    }

    /// <summary>
    /// Is current date between <paramref name="min"/> and <paramref name="max"/> with boundary.<br />
    /// 判断当前日期是否在 min 和 max 之间，闭包区间。
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsDateBetweenWithBoundary(this DateOnly dt, DateOnly min, DateOnly max)
        => dt.IsBetween(min, max.AddDays(+1), false);

    /// <summary>
    /// Is current date between <paramref name="min"/> and <paramref name="max"/> with boundary.<br />
    /// 判断当前日期是否在 min 和 max 之间，闭包区间。
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    public static bool IsDateBetweenWithBoundary(this DateOnly dt, DateOnly? min, DateOnly? max)
    {
        if (min.HasValue && max.HasValue)
            return dt.IsDateBetweenWithBoundary(min.Value, max.Value);

        if (min.HasValue)
            return dt >= min.Value;

        if (max.HasValue)
            return dt < max.Value.AddDays(+1);

        return true;
    }

    /// <summary>
    /// Is current date between <paramref name="min"/> and <paramref name="max"/> without boundary.<br />
    /// 判断当前日期是否在 min 和 max 之间，开区间。
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsDateBetweenWithoutBoundary(this DateOnly dt, DateOnly min, DateOnly max)
        => dt.IsBetween(min, max, false);

    /// <summary>
    /// Determine whether the given time is today. <br />
    /// 判断给定时间是否是今天。
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsToday(this DateOnly date) => date.ToDateTime().Date == DateTime.Today;

    /// <summary>
    /// Determine whether the given time is today. <br />
    /// 判断给定时间是否是今天。
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsToday(this DateOnly? date) => date.GetValueOrDefault().ToDateTime().Date == DateTime.Today;

    /// <summary>
    /// Determine whether the specified time is in the past relative to the specified time. <br />
    /// 判断指定时间是否相对给定时间的过去。
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="toCompareWith"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsBefore(this DateOnly dt, DateOnly toCompareWith) => dt < toCompareWith;

    /// <summary>
    /// Determine whether the specified time is in the future relative to the specified time. <br />
    /// 判断指定时间是否相对给定时间的未来。
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="toCompareWith"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsAfter(this DateOnly dt, DateOnly toCompareWith) => dt > toCompareWith;

    /// <summary>
    /// Determine whether the specified time is in the future relative to the specified time. <br />
    /// 判断指定时间是否相对给定时间的未来。
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsInTheFuture(this DateOnly dt) => dt.ToDateTime() > DateTime.Now;

    /// <summary>
    /// Determine whether the specified time is in the past relative to the specified time. <br />
    /// 判断指定时间是否相对给定时间的过去。
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsInThePast(this DateOnly dt) => dt.ToDateTime() < DateTime.Now;

    /// <summary>
    /// Is Weekday <br />
    /// 判断是否为工作日
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsWeekday(this DateOnly date) => !date.ToDateTime().IsWeekend();

    /// <summary>
    /// Is Weekday <br />
    /// 判断是否为工作日
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsWeekday(this DateOnly? date) => date.GetValueOrDefault().IsWeekday();

    /// <summary>
    /// Is Weekday <br />
    /// 判断是否为周末
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsWeekend(this DateOnly date) => date.DayOfWeek == DayOfWeek.Sunday || date.DayOfWeek == DayOfWeek.Saturday;

    /// <summary>
    /// Is Weekday <br />
    /// 判断是否为周末
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsWeekend(this DateOnly? date) => date.GetValueOrDefault().IsWeekend();

    /// <summary>
    /// Is same day
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="date"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsSameDay(this DateOnly dt, DateOnly date, DateDiffStrictOptions options = DateDiffStrictOptions.Default)
    {
        return options switch
        {
            DateDiffStrictOptions.Default => dt.Day == date.Day,
            DateDiffStrictOptions.Strict => dt.Day == date.Day && dt.Month == date.Month && dt.Year == date.Year,
            _ => dt.Day == date.Day
        };
    }

    /// <summary>
    /// Is same month
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="date"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsSameMonth(this DateOnly dt, DateOnly date, DateDiffStrictOptions options = DateDiffStrictOptions.Default)
    {
        return options switch
        {
            DateDiffStrictOptions.Default => dt.Month == date.Month,
            DateDiffStrictOptions.Strict => dt.Month == date.Month && dt.Year == date.Year,
            _ => dt.Month == date.Month
        };
    }

    /// <summary>
    /// Is same year
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="date"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsSameYear(this DateOnly dt, DateOnly date) => dt.Year == date.Year;

    /// <summary>
    /// Is date equal...
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="date"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsDateEqual(this DateOnly dt, DateOnly date) => dt.IsSameDay(date);

    #endregion

    #region To

    /// <summary>
    /// Convert <see cref="DateOnly"/> to <see cref="DateInfo"/>.<br />
    /// 将 <see cref="DateOnly"/> 转换为 <see cref="DateInfo"/>。
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateInfo ToDateInfo(this DateOnly date) => DateInfo.FromDateOnly(date);

    /// <summary>
    /// Convert <see cref="DateOnly"/> to <see cref="DateTime"/>.<br />
    /// 将 <see cref="DateOnly"/> 转换为 <see cref="DateTime"/>。
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public static DateTime ToDateTime(this DateOnly date) => date.ToDateTime(new TimeOnly(0, 0, 0));

    #endregion
}
#endif