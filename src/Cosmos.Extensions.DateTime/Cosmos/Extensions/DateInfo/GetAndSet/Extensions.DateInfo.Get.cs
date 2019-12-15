using System;
using System.Globalization;
using Cosmos.Date;

// ReSharper disable once CheckNamespace
namespace Cosmos {
    /// <summary>
    /// DateInfo Extensions<br />
    /// DateInfo 扩展方法
    /// </summary>
    public static partial class DateInfoExtensions {
        /// <summary>
        /// Get next weekday.
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="weekday"></param>
        /// <returns></returns>
        public static DateInfo GetNextWeekdayInfo(this DateTime dt, DayOfWeek weekday) {
            while (dt.DayOfWeek != weekday) dt = dt.AddDays(1);
            return dt;
        }

        /// <summary>
        /// Get next weekday.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="weekday"></param>
        /// <returns></returns>
        public static DateInfo GetNextWeekdayInfo(this DateInfo d, DayOfWeek weekday) {
            while (d.DayOfWeek != weekday) d = d.AddDays(1);
            return d;
        }

        /// <summary>
        /// Get previous weekday.
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="weekday"></param>
        /// <returns></returns>
        public static DateInfo GetPreviousWeekdayInfo(this DateTime dt, DayOfWeek weekday) {
            while (dt.DayOfWeek != weekday) dt = dt.AddDays(-1);
            return dt;
        }

        /// <summary>
        /// Get previous weekday.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="weekday"></param>
        /// <returns></returns>
        public static DateInfo GetPreviousWeekdayInfo(this DateInfo d, DayOfWeek weekday) {
            while (d.DayOfWeek != weekday) d = d.AddDays(-1);
            return d;
        }

        /// <summary>
        /// Get last day of this week
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateInfo GetLastDayInfoOfWeek(this DateTime dt) => dt.GetLastDayInfoOfWeek(null);

        /// <summary>
        /// Get last day of this week
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateInfo GetLastDayInfoOfWeek(this DateInfo d) => d.GetLastDayInfoOfWeek(null);

        /// <summary>
        /// Get last day of this week
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public static DateInfo GetLastDayInfoOfWeek(this DateTime dt, CultureInfo cultureInfo) {
            cultureInfo = (cultureInfo ?? CultureInfo.CurrentCulture);
            var firstDayOfWeek = cultureInfo.DateTimeFormat.FirstDayOfWeek;
            while (dt.DayOfWeek != firstDayOfWeek) dt = dt.AddDays(-1);
            return dt.AddDays(6);
        }

        /// <summary>
        /// Get last day of this week
        /// </summary>
        /// <param name="d"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public static DateInfo GetLastDayInfoOfWeek(this DateInfo d, CultureInfo cultureInfo) {
            cultureInfo = (cultureInfo ?? CultureInfo.CurrentCulture);
            var firstDayOfWeek = cultureInfo.DateTimeFormat.FirstDayOfWeek;
            while (d.DayOfWeek != firstDayOfWeek) d = d.AddDays(-1);
            return d.AddDays(6);
        }

        /// <summary>
        /// Get last day of this month.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateInfo GetLastDayInfoOfMonth(this DateTime dt) => new DateInfo(dt.Year, dt.Month, DateTime.DaysInMonth(dt.Year, dt.Month));

        /// <summary>
        /// Get last day of this month.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateInfo GetLastDayInfoOfMonth(this DateInfo dt) => new DateInfo(dt.Year, dt.Month, DateTime.DaysInMonth(dt.Year, dt.Month));

        /// <summary>
        /// Get last day (of week) of this month.
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateInfo GetLastDayInfoOfMonth(this DateTime dt, DayOfWeek dayOfWeek) {
            var t = new DateTime(dt.Year, dt.Month, DateTime.DaysInMonth(dt.Year, dt.Month));
            while (t.DayOfWeek != dayOfWeek)
                t = t.AddDays(-1);
            return t;
        }

        /// <summary>
        /// Get last day (of week) of this month.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateInfo GetLastDayInfoOfMonth(this DateInfo d, DayOfWeek dayOfWeek) {
            var t = new DateTime(d.Year, d.Month, DateTime.DaysInMonth(d.Year, d.Month));
            while (t.DayOfWeek != dayOfWeek)
                t = t.AddDays(-1);
            return t;
        }

        /// <summary>
        /// Gets last day info of quarter
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateInfo GetLastDayInfoOfQuarter(this DateTime dt) => dt.LastDayOfQuarter();

        /// <summary>
        /// Gets last day info of quarter
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateInfo GetLastDayInfoOfQuarter(this DateInfo d) => d.DateTimeRef.GetLastDayInfoOfQuarter();

        /// <summary>
        /// Gets last day info of quarter
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateInfo GetLastDayInfoOfQuarter(this DateTime dt, DayOfWeek dayOfWeek) {
            var t = dt.GetLastDayInfoOfQuarter();
            while (t.DayOfWeek != dayOfWeek)
                t = t.AddDays(-1);
            return t;
        }

        /// <summary>
        /// Gets last day info of quarter
        /// </summary>
        /// <param name="d"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateInfo GetLastDayInfoOfQuarter(this DateInfo d, DayOfWeek dayOfWeek) => d.DateTimeRef.GetLastDayInfoOfQuarter(dayOfWeek);

        /// <summary>
        /// Get last day info of year
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateInfo GetLastDayInfoOfYear(this DateTime dt) => dt.LastDayOfYear();

        /// <summary>
        /// Get last day info of year
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateInfo GetLastDayInfoOfYear(this DateInfo d) => d.DateTimeRef.GetLastDayInfoOfYear();

        /// <summary>
        /// Get last day info of year
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateInfo GetLastDayInfoOfYear(this DateTime dt, DayOfWeek dayOfWeek) {
            var t = dt.LastDayOfYear();
            while (t.DayOfWeek != dayOfWeek)
                t = t.AddDays(-1);
            return t;
        }

        /// <summary>
        /// Get last day info of year
        /// </summary>
        /// <param name="d"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateInfo GetLastDayInfoOfYear(this DateInfo d, DayOfWeek dayOfWeek) => d.DateTimeRef.GetLastDayInfoOfYear(dayOfWeek);

        /// <summary>
        /// Get last day of this week
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateInfo GetFirstDayInfoOfWeek(this DateTime dt) => dt.GetFirstDayInfoOfWeek(null);

        /// <summary>
        /// Get last day of this week
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateInfo GetFirstDayInfoOfWeek(this DateInfo d) => d.GetFirstDayInfoOfWeek(null);

        /// <summary>
        /// Get last day of this week
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public static DateInfo GetFirstDayInfoOfWeek(this DateTime dt, CultureInfo cultureInfo) {
            cultureInfo = (cultureInfo ?? CultureInfo.CurrentCulture);
            var firstDayOfWeek = cultureInfo.DateTimeFormat.FirstDayOfWeek;
            while (dt.DayOfWeek != firstDayOfWeek) dt = dt.AddDays(-1);
            return dt;
        }

        /// <summary>
        /// Get last day of this week
        /// </summary>
        /// <param name="d"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public static DateInfo GetFirstDayInfoOfWeek(this DateInfo d, CultureInfo cultureInfo) => d.DateTimeRef.GetFirstDayInfoOfWeek(cultureInfo);

        /// <summary>
        /// Get first day of this month.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateInfo GetFirstDayInfoOfMonth(this DateTime dt) => new DateInfo(dt.Year, dt.Month, 1);

        /// <summary>
        /// Get first day of this month.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateInfo GetFirstDayInfoOfMonth(this DateInfo dt) => new DateInfo(dt.Year, dt.Month, 1);

        /// <summary>
        /// Get first day (of week) of this month.
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateInfo GetFirstDayInfoOfMonth(this DateTime dt, DayOfWeek dayOfWeek) {
            var t = new DateTime(dt.Year, dt.Month, 1);
            while (t.DayOfWeek != dayOfWeek)
                t = t.AddDays(1);
            return t;
        }

        /// <summary>
        /// Get first day (of week) of this month.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateInfo GetFirstDayInfoOfMonth(this DateInfo d, DayOfWeek dayOfWeek) => d.DateTimeRef.GetFirstDayInfoOfMonth(dayOfWeek);

        /// <summary>
        /// Gets first day info of quarter
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateInfo GetFirstDayInfoOfQuarter(this DateTime dt) => dt.FirstDayOfQuarter();

        /// <summary>
        /// Gets first day info of quarter
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateInfo GetFirstDayInfoOfQuarter(this DateInfo d) => d.DateTimeRef.GetFirstDayInfoOfQuarter();

        /// <summary>
        /// Gets first day info of quarter
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateInfo GetFirstDayInfoOfQuarter(this DateTime dt, DayOfWeek dayOfWeek) {
            var d = dt.GetFirstDayInfoOfQuarter();
            while (d.DayOfWeek != dayOfWeek)
                d = d.AddDays(1);
            return d;
        }

        /// <summary>
        /// Gets first day info of quarter
        /// </summary>
        /// <param name="d"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateInfo GetFirstDayInfoOfQuarter(this DateInfo d, DayOfWeek dayOfWeek) => d.DateTimeRef.GetFirstDayInfoOfQuarter(dayOfWeek);

        /// <summary>
        /// Gets first day of year
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateInfo GetFirstDayInfoOfYear(this DateTime dt) => dt.FirstDayOfYear();

        /// <summary>
        /// Gets first day of year
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateInfo GetFirstDayInfoOfYear(this DateInfo d) => new DateInfo(d.Year, 1, 1);

        /// <summary>
        /// Gets first day of year
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateInfo GetFirstDayInfoOfYear(this DateTime dt, DayOfWeek dayOfWeek) {
            var t = DateTimeFactory.Create(dt.Year, 1, 1);
            while (t.DayOfWeek != dayOfWeek)
                t = t.AddDays(-1);
            return t;
        }

        /// <summary>
        /// Gets first day of year
        /// </summary>
        /// <param name="d"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateInfo GetFirstDayInfoOfYear(this DateInfo d, DayOfWeek dayOfWeek) => d.DateTimeRef.GetFirstDayInfoOfYear(dayOfWeek);
    }
}