namespace Cosmos.Date;

/// <summary>
/// Cosmos.Core <see cref="DateTimeSpan"/> extensions. <br />
/// DateTimeSpan 扩展
/// </summary>
public static class DateTimeSpanExtensions
{
    #region Before

    /// <summary>
    /// Before <br />
    /// 根据给定的时间和相对过去的 DateTimeSpan，计算出新的时间
    /// </summary>
    /// <param name="ts"></param>
    /// <param name="originalValue"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTime Before(this DateTimeSpan ts, DateTime originalValue) => originalValue.AddMonths(-ts.Months).AddYears(-ts.Years).Add(-ts.TimeSpan);

    /// <summary>
    /// DateTimeOffset Before <br />
    /// 根据给定的时间偏移量和相对过去的 DateTimeSpan，计算出新的 DateTimeOffset
    /// </summary>
    /// <param name="ts"></param>
    /// <param name="originalValue"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTimeOffset Before(this DateTimeSpan ts, DateTimeOffset originalValue) => originalValue.AddMonths(-ts.Months).AddYears(-ts.Years).Add(-ts.TimeSpan);

    #endregion

    #region From

    /// <summary>
    /// From now <br />
    /// 根据给定的偏移量计算出相对当前时刻的 DateTime
    /// </summary>
    /// <param name="ts"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTime FromNow(this DateTimeSpan ts) => ts.From(DateTime.Now);

    /// <summary>
    /// From <br />
    /// 根据给定的 DateTimeSpan 和时间计算出新的 DateTime
    /// </summary>
    /// <param name="ts"></param>
    /// <param name="originalValue"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTime From(this DateTimeSpan ts, DateTime originalValue) => originalValue.AddMonths(ts.Months).AddYears(ts.Years).Add(ts.TimeSpan);

    /// <summary>
    /// DateTimeOffset from now <br />
    /// 根据给定的偏移量计算出相对当前时刻的 DateTimeOffset
    /// </summary>
    /// <param name="ts"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTimeOffset OffsetFromNow(this DateTimeSpan ts) => ts.From(DateTimeOffset.Now);

    /// <summary>
    /// DateTimeOffset from <br />
    /// 根据给定的 DateTimeSpan 和偏移量计算出新的 DateTimeOffset
    /// </summary>
    /// <param name="ts"></param>
    /// <param name="originalValue"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTimeOffset From(this DateTimeSpan ts, DateTimeOffset originalValue) => originalValue.AddMonths(ts.Months).AddYears(ts.Years).Add(ts.TimeSpan);

    #endregion

    #region Number

    /// <summary>
    /// Create timespan value for given number of years. <br />
    /// 将给定的年数转换为 DateTimeSpan
    /// </summary>
    /// <param name="years"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTimeSpan Years(this int years) => new() {Years = years};

    /// <summary>
    /// Create timespan value for given number of quarters <br />
    /// 将给定的季度数转换为 DateTimeSpan
    /// </summary>
    /// <param name="quarters"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTimeSpan Quarters(this int quarters) => new() {Months = quarters * 3};

    /// <summary>
    /// Create timespan value for given number of months. <br />
    /// 将给定的月数转换为 DateTimeSpan
    /// </summary>
    /// <param name="months"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTimeSpan Months(this int months) => new() {Months = months};

    /// <summary>
    /// Create timespan value for given number of weeks. <br />
    /// 将给定的周数转换为 DateTimeSpan
    /// </summary>
    /// <param name="weeks"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTimeSpan Weeks(this int weeks) => new() {TimeSpan = TimeSpan.FromDays(weeks * 7)};

    /// <summary>
    /// Create timespan value for given number of weeks. <br />
    /// 将给定的周数转换为 DateTimeSpan
    /// </summary>
    /// <param name="weeks"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTimeSpan Weeks(this double weeks) => new() {TimeSpan = TimeSpan.FromDays(weeks * 7)};

    /// <summary>
    /// Create timespan value for given number of days. <br />
    /// 将给定的天数转换为 DateTimeSpan
    /// </summary>
    /// <param name="days"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTimeSpan Days(this int days) => new() {TimeSpan = TimeSpan.FromDays(days)};

    /// <summary>
    /// Create timespan value for given number of days. <br />
    /// 将给定的天数转换为 DateTimeSpan
    /// </summary>
    /// <param name="days"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTimeSpan Days(this double days) => new() {TimeSpan = TimeSpan.FromDays(days)};

    /// <summary>
    /// Create timespan value for given number of hours. <br />
    /// 将给定的小时数转换为 DateTimeSpan
    /// </summary>
    /// <param name="hours"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTimeSpan Hours(this int hours) => new() {TimeSpan = TimeSpan.FromHours(hours)};

    /// <summary>
    /// Create timespan value for given number of hours. <br />
    /// 将给定的小时数转换为 DateTimeSpan
    /// </summary>
    /// <param name="hours"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTimeSpan Hours(this double hours) => new() {TimeSpan = TimeSpan.FromHours(hours)};

    /// <summary>
    /// Create timespan value for given number of minutes. <br />
    /// 将给定的分钟数转换为 DateTimeSpan
    /// </summary>
    /// <param name="minutes"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTimeSpan Minutes(this int minutes) => new() {TimeSpan = TimeSpan.FromMinutes(minutes)};

    /// <summary>
    /// Create timespan value for given number of minutes. <br />
    /// 将给定的分钟数转换为 DateTimeSpan
    /// </summary>
    /// <param name="minutes"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTimeSpan Minutes(this double minutes) => new() {TimeSpan = TimeSpan.FromMinutes(minutes)};

    /// <summary>
    /// Create timespan value for given number of seconds. <br />
    /// 将给定的秒数转换为 DateTimeSpan
    /// </summary>
    /// <param name="seconds"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTimeSpan Seconds(this int seconds) => new() {TimeSpan = TimeSpan.FromSeconds(seconds)};

    /// <summary>
    /// Create timespan value for given number of seconds. <br />
    /// 将给定的秒数转换为 DateTimeSpan
    /// </summary>
    /// <param name="seconds"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTimeSpan Seconds(this double seconds) => new() {TimeSpan = TimeSpan.FromSeconds(seconds)};

    /// <summary>
    /// Create timespan value for given number of milliseconds. <br />
    /// 将给定的毫秒数转换为 DateTimeSpan
    /// </summary>
    /// <param name="milliseconds"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTimeSpan Milliseconds(this int milliseconds) => new() {TimeSpan = TimeSpan.FromMilliseconds(milliseconds)};

    /// <summary>
    /// Create timespan value for given number of milliseconds. <br />
    /// 将给定的毫秒数转换为 DateTimeSpan
    /// </summary>
    /// <param name="milliseconds"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTimeSpan Milliseconds(this double milliseconds) => new() {TimeSpan = TimeSpan.FromMilliseconds(milliseconds)};

    /// <summary>
    /// Create timespan value for given number of ticks. <br />
    /// 将给定的 Ticks 转换为 DateTimeSpan
    /// </summary>
    /// <param name="ticks"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTimeSpan Ticks(this int ticks) => new() {TimeSpan = TimeSpan.FromTicks(ticks)};

    /// <summary>
    /// Create timespan value for given number of ticks. <br />
    /// 将给定的 Ticks 转换为 DateTimeSpan
    /// </summary>
    /// <param name="ticks"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTimeSpan Ticks(this long ticks) => new() {TimeSpan = TimeSpan.FromTicks(ticks)};

    #endregion

    #region Since

    /// <summary>
    /// Since <br />
    /// 从给定的日期时间开始
    /// </summary>
    /// <param name="ts"></param>
    /// <param name="originalValue"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTime Since(this DateTimeSpan ts, DateTime originalValue) => From(ts, originalValue);

    /// <summary>
    /// DateTimeOffset since <br />
    /// 从给定的日期时间开始
    /// </summary>
    /// <param name="ts"></param>
    /// <param name="originalValue"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTimeOffset Since(this DateTimeSpan ts, DateTimeOffset originalValue) => From(ts, originalValue);

    #endregion

    #region To

    /// <summary>
    /// To display string <br />
    /// 显示
    /// </summary>
    /// <param name="ts"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string ToDisplayString(this DateTimeSpan ts) => ((TimeSpan) ts).ToDisplayString();

    #endregion
}