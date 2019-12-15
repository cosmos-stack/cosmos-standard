using System;
using Cosmos.Date;

// ReSharper disable once CheckNamespace
namespace Cosmos {
    /// <summary>
    /// DateInfo Extensions<br />
    /// DateInfo 扩展方法
    /// </summary>
    public static partial class DateInfoExtensions {
        /// <summary>
        /// Next year
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateInfo NextYear(this DateInfo d) {
            var year = d.Year + 1;
            var daysOfMonth = DateTime.DaysInMonth(year, d.Month);

            if (daysOfMonth == d.Day)
                return new DateInfo(year, d.Month, d.Day);

            var m = d.Day - daysOfMonth;
            var p = new DateInfo(year, d.Month, daysOfMonth);
            return p + m.Days();
        }

        /// <summary>
        /// Previous Year
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateInfo PreviousYear(this DateInfo d) {
            var year = d.Year - 1;
            var daysOfMonth = DateTime.DaysInMonth(year, d.Month);

            if (daysOfMonth == d.Day)
                return new DateInfo(year, d.Month, d.Day);

            var m = d.Day - daysOfMonth;
            var p = new DateInfo(year, d.Month, daysOfMonth);
            return p + m.Days();
        }

        /// <summary>
        /// Next day, same as 'Tomorrow'
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateInfo NextDay(this DateInfo d) => d.Tomorrow();

        /// <summary>
        /// Previous Day, same aa 'Yesterday'
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateInfo PreviousDay(this DateInfo d) => d.Yesterday();

        /// <summary>
        /// Next, same as 'GetNextWeekdayInfo'
        /// </summary>
        /// <param name="d"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateInfo NextDayOfWeek(this DateInfo d, DayOfWeek dayOfWeek) => d.GetNextWeekdayInfo(dayOfWeek);

        /// <summary>
        /// Previous, same as 'GetPreviousWeekdayInfo'
        /// </summary>
        /// <param name="d"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateInfo PreviousDayOfWeek(this DateInfo d, DayOfWeek dayOfWeek) => d.GetPreviousWeekdayInfo(dayOfWeek);

        /// <summary>
        /// Week after
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateInfo WeekAfter(this DateInfo d) => d + 1.Weeks();

        /// <summary>
        /// Week before
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateInfo WeekBefore(this DateInfo d) => d - 1.Weeks();

        /// <summary>
        /// Increase time
        /// </summary>
        /// <param name="d"></param>
        /// <param name="toAdd"></param>
        /// <returns></returns>
        public static DateInfo IncreaseTime(this DateInfo d, TimeSpan toAdd) => d + toAdd;

        /// <summary>
        /// Decrease time
        /// </summary>
        /// <param name="d"></param>
        /// <param name="toSubtract"></param>
        /// <returns></returns>
        public static DateInfo DecreaseTime(this DateInfo d, TimeSpan toSubtract) => d - toSubtract;
    }
}