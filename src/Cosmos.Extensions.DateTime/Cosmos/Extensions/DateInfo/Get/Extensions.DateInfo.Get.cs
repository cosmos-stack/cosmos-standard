using System;
using System.Globalization;
using Cosmos.Date;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    /// <summary>
    /// DateInfo Extensions<br />
    /// DateInfo 扩展方法
    /// </summary>
    public static partial class DateInfoExtensions
    {
        /// <summary>
        /// Get next weekday.
        /// </summary>
        /// <param name="date"></param>
        /// <param name="weekday"></param>
        /// <returns></returns>
        public static DateInfo GetNextWeekdayInfo(this DateTime date, DayOfWeek weekday)
        {
            while (date.DayOfWeek != weekday) date = date.AddDays(1);
            return date;
        }

        /// <summary>
        /// Get previous weekday.
        /// </summary>
        /// <param name="date"></param>
        /// <param name="weekday"></param>
        /// <returns></returns>
        public static DateInfo GetPreviousWeekdayInfo(this DateTime date, DayOfWeek weekday)
        {
            while (date.DayOfWeek != weekday) date = date.AddDays(-1);
            return date;
        }

        /// <summary>
        /// Get first day of this month.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateInfo GetFirstDayInfoOfMonth(this DateTime dt)
        {
            return new DateInfo(dt.Year, dt.Month, 1);
        }

        /// <summary>
        /// Get first day (of week) of this month.
        /// </summary>
        /// <param name="date"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateInfo GetFirstDayInfoOfMonth(this DateTime date, DayOfWeek dayOfWeek)
        {
            var dt = new DateTime(date.Year, date.Month, 1);
            while (dt.DayOfWeek != dayOfWeek)
                dt = dt.AddDays(1);
            return dt;
        }

        /// <summary>
        /// Get last day of this month.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateInfo GetLastDayInfoOfMonth(this DateTime dt)
        {
            return new DateInfo(dt.Year, dt.Month, DateTime.DaysInMonth(dt.Year, dt.Month));
        }

        /// <summary>
        /// Get last day (of week) of this month.
        /// </summary>
        /// <param name="date"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateInfo GetLastDayInfoOfMonth(this DateTime date, DayOfWeek dayOfWeek)
        {
            var dt = new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
            while (dt.DayOfWeek != dayOfWeek)
                dt = dt.AddDays(-1);
            return dt;
        }

        /// <summary>
        /// Get last day of this week
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateInfo GetFirstDayInfoOfWeek(this DateTime date)
        {
            return date.GetFirstDayInfoOfWeek(null);
        }

        /// <summary>
        /// Get last day of this week
        /// </summary>
        /// <param name="date"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public static DateInfo GetFirstDayInfoOfWeek(this DateTime date, CultureInfo cultureInfo)
        {
            cultureInfo = (cultureInfo ?? CultureInfo.CurrentCulture);
            var firstDayOfWeek = cultureInfo.DateTimeFormat.FirstDayOfWeek;
            while (date.DayOfWeek != firstDayOfWeek) date = date.AddDays(-1);
            return date;
        }

        /// <summary>
        /// Get last day of this week
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateInfo GetLastDayInfoOfWeek(this DateTime date)
        {
            return date.GetLastDayInfoOfWeek(null);
        }

        /// <summary>
        /// Get last day of this week
        /// </summary>
        /// <param name="date"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public static DateInfo GetLastDayInfoOfWeek(this DateTime date, CultureInfo cultureInfo)
        {
            cultureInfo = (cultureInfo ?? CultureInfo.CurrentCulture);
            var firstDayOfWeek = cultureInfo.DateTimeFormat.FirstDayOfWeek;
            while (date.DayOfWeek != firstDayOfWeek) date = date.AddDays(-1);
            return date.AddDays(6);
        }
    }
}
