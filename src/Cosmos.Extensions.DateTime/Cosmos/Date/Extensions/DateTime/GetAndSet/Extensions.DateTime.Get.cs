using System;
using System.Globalization;

// ReSharper disable once CheckNamespace
namespace Cosmos.Date
{
    /// <summary>
    /// DateTime Extensions<br />
    /// DateTime 扩展方法
    /// </summary>
    public static partial class DateTimeExtensions
    {
        /// <summary>
        /// Gets first day of year
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime FirstDayOfYear(this DateTime dt) => dt.SetDate(dt.Year, 1, 1);

        /// <summary>
        /// Get the day of the first specified week of the year.
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateTime FirstDayOfYear(this DateTime dt, DayOfWeek dayOfWeek)
        {
            var ret = dt.FirstDayOfYear();
            return DayOfWeekCalc.TryDaysBetween(ret.DayOfWeek, dayOfWeek, out var day) && day > 0
                ? ret.AddDays(day)
                : ret;
        }

        /// <summary>
        /// Gets first day of quarter
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime FirstDayOfQuarter(this DateTime dt)
        {
            var currentQuarter = dt.QuarterOfMonth();
            var month = 3 * currentQuarter - 2;
            return DateTimeFactory.Create(dt.Year, month, 1);
        }

        /// <summary>
        /// Get the day of the first specified week of the quarter.
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateTime FirstDayOfQuarter(this DateTime dt, DayOfWeek dayOfWeek)
        {
            var ret = dt.FirstDayOfQuarter();
            return DayOfWeekCalc.TryDaysBetween(ret.DayOfWeek, dayOfWeek, out var day) && day > 0
                ? ret.AddDays(day)
                : ret;
        }

        /// <summary>
        /// Gets first day of month
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime FirstDayOfMonth(this DateTime dt) => dt.SetDay(1);

        /// <summary>
        /// Get the day of the first specified week of the month.
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateTime FirstDayOfMonth(this DateTime dt, DayOfWeek dayOfWeek)
        {
            var ret = dt.FirstDayOfMonth();
            return DayOfWeekCalc.TryDaysBetween(ret.DayOfWeek, dayOfWeek, out var day) && day > 0
                ? ret.AddDays(day)
                : ret;
        }

        /// <summary>
        /// Gets first day of week
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime FirstDayOfWeek(this DateTime dt) => dt.FirstDayOfWeek(null);

        /// <summary>
        /// Gets first day of week
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public static DateTime FirstDayOfWeek(this DateTime dt, CultureInfo cultureInfo)
        {
            cultureInfo ??= CultureInfo.CurrentCulture;
            var firstDayOfWeek = cultureInfo.DateTimeFormat.FirstDayOfWeek;
            var offset = dt.DayOfWeek - firstDayOfWeek < 0 ? 7 : 0;
            var numberOfDaysSinceBeginningOfTheWeek = dt.DayOfWeek + offset - firstDayOfWeek;

            return dt.AddDays(-numberOfDaysSinceBeginningOfTheWeek);
        }

        /// <summary>
        /// Gets last day of year
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime LastDayOfYear(this DateTime dt) => dt.SetDate(dt.Year, 12, 31);

        /// <summary>
        /// Get the day of the last specified week of the year.
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateTime LastDayOfYear(this DateTime dt, DayOfWeek dayOfWeek)
        {
            var ret = dt.LastDayOfYear();
            return DayOfWeekCalc.TryDaysBetween(ret.DayOfWeek, dayOfWeek, out var day) && day == 0
                ? ret
                : ret.AddDays(-day);
        }

        /// <summary>
        /// Gets last day of quarter
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime LastDayOfQuarter(this DateTime dt)
        {
            var currentQuarter = dt.QuarterOfMonth();
            var month = 3 * currentQuarter;
            var day = DateTime.DaysInMonth(dt.Year, month);
            return DateTimeFactory.Create(dt.Year, month, day);
        }

        /// <summary>
        /// Get the day of the last designated week of the quarter.
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateTime LastDayOfQuarter(this DateTime dt, DayOfWeek dayOfWeek)
        {
            var ret = dt.LastDayOfQuarter();
            return DayOfWeekCalc.TryDaysBetween(ret.DayOfWeek, dayOfWeek, out var day) && day == 0
                ? ret
                : ret.AddDays(-day);
        }

        /// <summary>
        /// Gets last day of month
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime LastDayOfMonth(this DateTime dt) => dt.SetDay(dt.DaysInMonth());

        /// <summary>
        /// Get the day of the last specified week of the month.
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateTime LastDayOfMonth(this DateTime dt, DayOfWeek dayOfWeek)
        {
            var ret = dt.LastDayOfMonth();
            return DayOfWeekCalc.TryDaysBetween(ret.DayOfWeek, dayOfWeek, out var day) && day == 0
                ? ret
                : ret.AddDays(-day);
        }

        /// <summary>
        /// Gets last day of week
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime LastDayOfWeek(this DateTime dt) => dt.LastDayOfWeek(null);

        /// <summary>
        /// Gets last day of week
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public static DateTime LastDayOfWeek(this DateTime dt, CultureInfo cultureInfo) => dt.FirstDayOfWeek(cultureInfo).AddDays(6);

        /// <summary>
        /// Days in month
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static int DaysInMonth(this DateTime dt) => DateTime.DaysInMonth(dt.Year, dt.Month);

        /// <summary>
        /// Get the quarter number of the month.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static int QuarterOfMonth(this DateTime dt) => (dt.Month - 1) / 3 + 1;

        /// <summary>
        /// Get the specified week is the week of the year
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static int GetWeekOfYear(this DateTime datetime)
            => GetWeekOfYear(datetime, new DateTimeFormatInfo().CalendarWeekRule, new DateTimeFormatInfo().FirstDayOfWeek);

        /// <summary>
        /// Get the specified week is the week of the year
        /// </summary>
        /// <param name="datetime"></param>
        /// <param name="weekRule"></param>
        /// <returns></returns>
        public static int GetWeekOfYear(this DateTime datetime, CalendarWeekRule weekRule)
            => GetWeekOfYear(datetime, weekRule, new DateTimeFormatInfo().FirstDayOfWeek);

        /// <summary>
        /// Get the specified week is the week of the year
        /// </summary>
        /// <param name="datetime"></param>
        /// <param name="firstDayOfWeek"></param>
        /// <returns></returns>
        public static int GetWeekOfYear(this DateTime datetime, DayOfWeek firstDayOfWeek)
            => GetWeekOfYear(datetime, new DateTimeFormatInfo().CalendarWeekRule, firstDayOfWeek);

        /// <summary>
        /// Get the specified week is the week of the year
        /// </summary>
        /// <param name="datetime"></param>
        /// <param name="weekRule"></param>
        /// <param name="firstDayOfWeek"></param>
        /// <returns></returns>
        public static int GetWeekOfYear(this DateTime datetime, CalendarWeekRule weekRule, DayOfWeek firstDayOfWeek)
            => CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(datetime, weekRule, firstDayOfWeek);
    }
}