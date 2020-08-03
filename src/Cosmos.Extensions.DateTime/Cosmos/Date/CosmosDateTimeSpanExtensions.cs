using System;

namespace Cosmos.Date
{
    /// <summary>
    /// Cosmos <see cref="DateTimeSpan"/> extensions.
    /// </summary>
    public static class CosmosDateTimeSpanExtensions
    {
        #region Ago

        /// <summary>
        /// Ago
        /// </summary>
        /// <param name="ts"></param>
        /// <returns></returns>
        public static DateTime Ago(this DateTimeSpan ts)
        {
            return ts.Before(DateTime.Now);
        }

        /// <summary>
        /// Ago
        /// </summary>
        /// <param name="ts"></param>
        /// <param name="originalValue"></param>
        /// <returns></returns>
        public static DateTime Ago(this DateTimeSpan ts, DateTime originalValue)
        {
            return ts.Before(originalValue);
        }

        /// <summary>
        /// DateTimeOffset Ago
        /// </summary>
        /// <param name="ts"></param>
        /// <returns></returns>
        public static DateTimeOffset OffsetAgo(this DateTimeSpan ts)
        {
            return ts.Before(DateTimeOffset.Now);
        }

        /// <summary>
        /// DateTimeOffset Ago
        /// </summary>
        /// <param name="ts"></param>
        /// <param name="originalValue"></param>
        /// <returns></returns>
        public static DateTimeOffset Ago(this DateTimeSpan ts, DateTimeOffset originalValue)
        {
            return ts.Before(originalValue);
        }

        #endregion

        #region Before

        /// <summary>
        /// Before
        /// </summary>
        /// <param name="ts"></param>
        /// <param name="originalValue"></param>
        /// <returns></returns>
        public static DateTime Before(this DateTimeSpan ts, DateTime originalValue)
        {
            return originalValue.AddMonths(-ts.Months).AddYears(-ts.Years).Add(-ts.TimeSpan);
        }

        /// <summary>
        /// DateTimeOffset Before
        /// </summary>
        /// <param name="ts"></param>
        /// <param name="originalValue"></param>
        /// <returns></returns>
        public static DateTimeOffset Before(this DateTimeSpan ts, DateTimeOffset originalValue)
        {
            return originalValue.AddMonths(-ts.Months).AddYears(-ts.Years).Add(-ts.TimeSpan);
        }

        #endregion

        #region From

        /// <summary>
        /// From now
        /// </summary>
        /// <param name="ts"></param>
        /// <returns></returns>
        public static DateTime FromNow(this DateTimeSpan ts)
        {
            return ts.From(DateTime.Now);
        }

        /// <summary>
        /// From
        /// </summary>
        /// <param name="ts"></param>
        /// <param name="originalValue"></param>
        /// <returns></returns>
        public static DateTime From(this DateTimeSpan ts, DateTime originalValue)
        {
            return originalValue.AddMonths(ts.Months).AddYears(ts.Years).Add(ts.TimeSpan);
        }

        /// <summary>
        /// DateTimeOffset from now
        /// </summary>
        /// <param name="ts"></param>
        /// <returns></returns>
        public static DateTimeOffset OffsetFromNow(this DateTimeSpan ts)
        {
            return ts.From(DateTimeOffset.Now);
        }

        /// <summary>
        /// DateTimeOffset from
        /// </summary>
        /// <param name="ts"></param>
        /// <param name="originalValue"></param>
        /// <returns></returns>
        public static DateTimeOffset From(this DateTimeSpan ts, DateTimeOffset originalValue)
        {
            return originalValue.AddMonths(ts.Months).AddYears(ts.Years).Add(ts.TimeSpan);
        }

        #endregion

        #region Number

        /// <summary>
        /// Create timespan value for given number of years.
        /// </summary>
        /// <param name="years"></param>
        /// <returns></returns>
        public static DateTimeSpan Years(this int years) => new DateTimeSpan {Years = years};

        /// <summary>
        /// Create timespan value for given number of quarters
        /// </summary>
        /// <param name="quarters"></param>
        /// <returns></returns>
        public static DateTimeSpan Quarters(this int quarters) => new DateTimeSpan {Months = quarters * 3};

        /// <summary>
        /// Create timespan value for given number of months.
        /// </summary>
        /// <param name="months"></param>
        /// <returns></returns>
        public static DateTimeSpan Months(this int months) => new DateTimeSpan {Months = months};

        /// <summary>
        /// Create timespan value for given number of weeks.
        /// </summary>
        /// <param name="weeks"></param>
        /// <returns></returns>
        public static DateTimeSpan Weeks(this int weeks) => new DateTimeSpan {TimeSpan = TimeSpan.FromDays(weeks * 7)};

        /// <summary>
        /// Create timespan value for given number of weeks.
        /// </summary>
        /// <param name="weeks"></param>
        /// <returns></returns>
        public static DateTimeSpan Weeks(this double weeks) => new DateTimeSpan {TimeSpan = TimeSpan.FromDays(weeks * 7)};

        /// <summary>
        /// Create timespan value for given number of days.
        /// </summary>
        /// <param name="days"></param>
        /// <returns></returns>
        public static DateTimeSpan Days(this int days) => new DateTimeSpan {TimeSpan = TimeSpan.FromDays(days)};

        /// <summary>
        /// Create timespan value for given number of days.
        /// </summary>
        /// <param name="days"></param>
        /// <returns></returns>
        public static DateTimeSpan Days(this double days) => new DateTimeSpan {TimeSpan = TimeSpan.FromDays(days)};

        /// <summary>
        /// Create timespan value for given number of hours.
        /// </summary>
        /// <param name="hours"></param>
        /// <returns></returns>
        public static DateTimeSpan Hours(this int hours) => new DateTimeSpan {TimeSpan = TimeSpan.FromHours(hours)};

        /// <summary>
        /// Create timespan value for given number of hours.
        /// </summary>
        /// <param name="hours"></param>
        /// <returns></returns>
        public static DateTimeSpan Hours(this double hours) => new DateTimeSpan {TimeSpan = TimeSpan.FromHours(hours)};

        /// <summary>
        /// Create timespan value for given number of minutes.
        /// </summary>
        /// <param name="minutes"></param>
        /// <returns></returns>
        public static DateTimeSpan Minutes(this int minutes) => new DateTimeSpan {TimeSpan = TimeSpan.FromMinutes(minutes)};

        /// <summary>
        /// Create timespan value for given number of minutes.
        /// </summary>
        /// <param name="minutes"></param>
        /// <returns></returns>
        public static DateTimeSpan Minutes(this double minutes) => new DateTimeSpan {TimeSpan = TimeSpan.FromMinutes(minutes)};

        /// <summary>
        /// Create timespan value for given number of seconds.
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static DateTimeSpan Seconds(this int seconds) => new DateTimeSpan {TimeSpan = TimeSpan.FromSeconds(seconds)};

        /// <summary>
        /// Create timespan value for given number of seconds.
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static DateTimeSpan Seconds(this double seconds) => new DateTimeSpan {TimeSpan = TimeSpan.FromSeconds(seconds)};

        /// <summary>
        /// Create timespan value for given number of milliseconds.
        /// </summary>
        /// <param name="milliseconds"></param>
        /// <returns></returns>
        public static DateTimeSpan Milliseconds(this int milliseconds) => new DateTimeSpan {TimeSpan = TimeSpan.FromMilliseconds(milliseconds)};

        /// <summary>
        /// Create timespan value for given number of milliseconds.
        /// </summary>
        /// <param name="milliseconds"></param>
        /// <returns></returns>
        public static DateTimeSpan Milliseconds(this double milliseconds) => new DateTimeSpan {TimeSpan = TimeSpan.FromMilliseconds(milliseconds)};

        /// <summary>
        /// Create timespan value for given number of ticks.
        /// </summary>
        /// <param name="ticks"></param>
        /// <returns></returns>
        public static DateTimeSpan Ticks(this int ticks) => new DateTimeSpan {TimeSpan = TimeSpan.FromTicks(ticks)};

        /// <summary>
        /// Create timespan value for given number of ticks.
        /// </summary>
        /// <param name="ticks"></param>
        /// <returns></returns>
        public static DateTimeSpan Ticks(this long ticks) => new DateTimeSpan {TimeSpan = TimeSpan.FromTicks(ticks)};

        #endregion

        #region Since

        /// <summary>
        /// Since
        /// </summary>
        /// <param name="ts"></param>
        /// <param name="originalValue"></param>
        /// <returns></returns>
        public static DateTime Since(this DateTimeSpan ts, DateTime originalValue)
        {
            return From(ts, originalValue);
        }

        /// <summary>
        /// DateTimeOffset since
        /// </summary>
        /// <param name="ts"></param>
        /// <param name="originalValue"></param>
        /// <returns></returns>
        public static DateTimeOffset Since(this DateTimeSpan ts, DateTimeOffset originalValue)
        {
            return From(ts, originalValue);
        }

        #endregion

        #region To

        /// <summary>
        /// To display string
        /// </summary>
        /// <param name="ts"></param>
        /// <returns></returns>
        public static string ToDisplayString(this DateTimeSpan ts)
        {
            return ((TimeSpan) ts).ToDisplayString();
        }

        #endregion
    }
}