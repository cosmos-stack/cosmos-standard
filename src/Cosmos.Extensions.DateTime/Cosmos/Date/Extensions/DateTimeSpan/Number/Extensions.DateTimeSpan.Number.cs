using System;

// ReSharper disable once CheckNamespace
namespace Cosmos.Date
{
    /// <summary>
    /// DateTimeSpan Extensions<br />
    /// DateTimeSpan 扩展方法
    /// </summary>
    public static partial class DateTimeSpanExtensions
    {
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
    }
}