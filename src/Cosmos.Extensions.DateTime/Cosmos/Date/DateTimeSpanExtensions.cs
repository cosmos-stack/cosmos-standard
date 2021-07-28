using System;
using System.Runtime.CompilerServices;

namespace Cosmos.Date
{
    /// <summary>
    /// Cosmos <see cref="DateTimeSpan"/> extensions.
    /// </summary>
    public static class DateTimeSpanExtensions
    {
        #region Ago

        /// <summary>
        /// Ago
        /// </summary>
        /// <param name="ts"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTime Ago(this DateTimeSpan ts) => ts.Before(DateTime.Now);

        /// <summary>
        /// Ago
        /// </summary>
        /// <param name="ts"></param>
        /// <param name="originalValue"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTime Ago(this DateTimeSpan ts, DateTime originalValue) => ts.Before(originalValue);

        /// <summary>
        /// DateTimeOffset Ago
        /// </summary>
        /// <param name="ts"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTimeOffset OffsetAgo(this DateTimeSpan ts) => ts.Before(DateTimeOffset.Now);

        /// <summary>
        /// DateTimeOffset Ago
        /// </summary>
        /// <param name="ts"></param>
        /// <param name="originalValue"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTimeOffset Ago(this DateTimeSpan ts, DateTimeOffset originalValue) => ts.Before(originalValue);

        #endregion

        #region Before

        /// <summary>
        /// Before
        /// </summary>
        /// <param name="ts"></param>
        /// <param name="originalValue"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTime Before(this DateTimeSpan ts, DateTime originalValue) => originalValue.AddMonths(-ts.Months).AddYears(-ts.Years).Add(-ts.TimeSpan);

        /// <summary>
        /// DateTimeOffset Before
        /// </summary>
        /// <param name="ts"></param>
        /// <param name="originalValue"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTimeOffset Before(this DateTimeSpan ts, DateTimeOffset originalValue) => originalValue.AddMonths(-ts.Months).AddYears(-ts.Years).Add(-ts.TimeSpan);

        #endregion

        #region From

        /// <summary>
        /// From now
        /// </summary>
        /// <param name="ts"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTime FromNow(this DateTimeSpan ts) => ts.From(DateTime.Now);

        /// <summary>
        /// From
        /// </summary>
        /// <param name="ts"></param>
        /// <param name="originalValue"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTime From(this DateTimeSpan ts, DateTime originalValue) => originalValue.AddMonths(ts.Months).AddYears(ts.Years).Add(ts.TimeSpan);

        /// <summary>
        /// DateTimeOffset from now
        /// </summary>
        /// <param name="ts"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTimeOffset OffsetFromNow(this DateTimeSpan ts) => ts.From(DateTimeOffset.Now);

        /// <summary>
        /// DateTimeOffset from
        /// </summary>
        /// <param name="ts"></param>
        /// <param name="originalValue"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTimeOffset From(this DateTimeSpan ts, DateTimeOffset originalValue) => originalValue.AddMonths(ts.Months).AddYears(ts.Years).Add(ts.TimeSpan);

        #endregion

        #region Number

        /// <summary>
        /// Create timespan value for given number of years.
        /// </summary>
        /// <param name="years"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTimeSpan Years(this int years) => new() {Years = years};

        /// <summary>
        /// Create timespan value for given number of quarters
        /// </summary>
        /// <param name="quarters"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTimeSpan Quarters(this int quarters) => new() {Months = quarters * 3};

        /// <summary>
        /// Create timespan value for given number of months.
        /// </summary>
        /// <param name="months"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTimeSpan Months(this int months) => new() {Months = months};

        /// <summary>
        /// Create timespan value for given number of weeks.
        /// </summary>
        /// <param name="weeks"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTimeSpan Weeks(this int weeks) => new() {TimeSpan = TimeSpan.FromDays(weeks * 7)};

        /// <summary>
        /// Create timespan value for given number of weeks.
        /// </summary>
        /// <param name="weeks"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTimeSpan Weeks(this double weeks) => new() {TimeSpan = TimeSpan.FromDays(weeks * 7)};

        /// <summary>
        /// Create timespan value for given number of days.
        /// </summary>
        /// <param name="days"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTimeSpan Days(this int days) => new() {TimeSpan = TimeSpan.FromDays(days)};

        /// <summary>
        /// Create timespan value for given number of days.
        /// </summary>
        /// <param name="days"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTimeSpan Days(this double days) => new() {TimeSpan = TimeSpan.FromDays(days)};

        /// <summary>
        /// Create timespan value for given number of hours.
        /// </summary>
        /// <param name="hours"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTimeSpan Hours(this int hours) => new() {TimeSpan = TimeSpan.FromHours(hours)};

        /// <summary>
        /// Create timespan value for given number of hours.
        /// </summary>
        /// <param name="hours"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTimeSpan Hours(this double hours) => new() {TimeSpan = TimeSpan.FromHours(hours)};

        /// <summary>
        /// Create timespan value for given number of minutes.
        /// </summary>
        /// <param name="minutes"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTimeSpan Minutes(this int minutes) => new() {TimeSpan = TimeSpan.FromMinutes(minutes)};

        /// <summary>
        /// Create timespan value for given number of minutes.
        /// </summary>
        /// <param name="minutes"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTimeSpan Minutes(this double minutes) => new() {TimeSpan = TimeSpan.FromMinutes(minutes)};

        /// <summary>
        /// Create timespan value for given number of seconds.
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTimeSpan Seconds(this int seconds) => new() {TimeSpan = TimeSpan.FromSeconds(seconds)};

        /// <summary>
        /// Create timespan value for given number of seconds.
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTimeSpan Seconds(this double seconds) => new() {TimeSpan = TimeSpan.FromSeconds(seconds)};

        /// <summary>
        /// Create timespan value for given number of milliseconds.
        /// </summary>
        /// <param name="milliseconds"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTimeSpan Milliseconds(this int milliseconds) => new() {TimeSpan = TimeSpan.FromMilliseconds(milliseconds)};

        /// <summary>
        /// Create timespan value for given number of milliseconds.
        /// </summary>
        /// <param name="milliseconds"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTimeSpan Milliseconds(this double milliseconds) => new() {TimeSpan = TimeSpan.FromMilliseconds(milliseconds)};

        /// <summary>
        /// Create timespan value for given number of ticks.
        /// </summary>
        /// <param name="ticks"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTimeSpan Ticks(this int ticks) => new() {TimeSpan = TimeSpan.FromTicks(ticks)};

        /// <summary>
        /// Create timespan value for given number of ticks.
        /// </summary>
        /// <param name="ticks"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTimeSpan Ticks(this long ticks) => new() {TimeSpan = TimeSpan.FromTicks(ticks)};

        #endregion

        #region Since

        /// <summary>
        /// Since
        /// </summary>
        /// <param name="ts"></param>
        /// <param name="originalValue"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTime Since(this DateTimeSpan ts, DateTime originalValue) => From(ts, originalValue);

        /// <summary>
        /// DateTimeOffset since
        /// </summary>
        /// <param name="ts"></param>
        /// <param name="originalValue"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTimeOffset Since(this DateTimeSpan ts, DateTimeOffset originalValue) => From(ts, originalValue);

        #endregion

        #region To

        /// <summary>
        /// To display string
        /// </summary>
        /// <param name="ts"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToDisplayString(this DateTimeSpan ts) => ((TimeSpan) ts).ToDisplayString();

        #endregion
    }
}