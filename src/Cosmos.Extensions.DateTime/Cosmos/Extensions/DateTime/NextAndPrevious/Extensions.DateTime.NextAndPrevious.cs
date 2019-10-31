using System;
using Cosmos.Date;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    /// <summary>
    /// DateTime Extensions<br />
    /// DateTime 扩展方法
    /// </summary>
    public static partial class DateTimeExtensions
    {
        /// <summary>
        /// Next year
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime NextYear(this DateTime dt)
        {
            var year = dt.Year + 1;
            var daysOfMonth = DateTime.DaysInMonth(year, dt.Month);

            if (daysOfMonth == dt.Day)
                return DateTimeFactory.Create(year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond, dt.Kind);

            var d = dt.Day - daysOfMonth;
            var p = DateTimeFactory.Create(year, dt.Month, daysOfMonth, dt.Hour, dt.Minute, dt.Second, dt.Millisecond, dt.Kind);
            return p + d.Days();
        }

        /// <summary>
        /// Previous Year
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime PreviousYear(this DateTime dt)
        {
            var year = dt.Year - 1;
            var daysOfMonth = DateTime.DaysInMonth(year, dt.Month);

            if (daysOfMonth == dt.Day)
                return DateTimeFactory.Create(year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond, dt.Kind);

            var d = dt.Day - daysOfMonth;
            var p = DateTimeFactory.Create(year, dt.Month, daysOfMonth, dt.Hour, dt.Minute, dt.Second, dt.Millisecond, dt.Kind);
            return p + d.Days();
        }
        
        /// <summary>
        /// Gets next month
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime NextMonth(this DateTime dt)
        {
            var year = dt.Month == 12 ? dt.Year + 1 : dt.Year;

            var month = dt.Month == 12 ? 1 : dt.Month + 1;

            var firstDayOfNextMonth = dt.SetDate(year, month, 1);

            var lastDayOfPreviousMonth = firstDayOfNextMonth.LastDayOfMonth().Day;

            var day = dt.Day > lastDayOfPreviousMonth ? lastDayOfPreviousMonth : dt.Day;

            return firstDayOfNextMonth.SetDay(day);
        }
        
        /// <summary>
        /// Gets previous month
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime PreviousMonth(this DateTime dt)
        {
            var year = dt.Month == 1 ? dt.Year - 1 : dt.Year;

            var month = dt.Month == 1 ? 12 : dt.Month - 1;

            var firstDayOfPreviousMonth = dt.SetDate(year, month, 1);

            var lastDayOfPreviousMonth = firstDayOfPreviousMonth.LastDayOfMonth().Day;

            var day = dt.Day > lastDayOfPreviousMonth ? lastDayOfPreviousMonth : dt.Day;

            return firstDayOfPreviousMonth.SetDay(day);
        }

        /// <summary>
        /// Next day
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime NextDay(this DateTime dt) => dt + 1.Days();

        /// <summary>
        /// Previous Day
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime PreviousDay(this DateTime dt) => dt - 1.Days();

        /// <summary>
        /// Next
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateTime Next(this DateTime dt, DayOfWeek dayOfWeek)
        {
            do
            {
                dt = dt.NextDay();
            } while (dt.DayOfWeek != dayOfWeek);

            return dt;
        }

        /// <summary>
        /// Previous
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateTime Previous(this DateTime dt, DayOfWeek dayOfWeek)
        {
            do
            {
                dt = dt.PreviousDay();
            } while (dt.DayOfWeek != dayOfWeek);

            return dt;
        }

        /// <summary>
        /// Week after
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime WeekAfter(this DateTime dt) => dt + 1.Weeks();

        /// <summary>
        /// Week before
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime WeekBefore(this DateTime dt) => dt - 1.Weeks();

        /// <summary>
        /// Increase time
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="toAdd"></param>
        /// <returns></returns>
        public static DateTime IncreaseTime(this DateTime dt, TimeSpan toAdd) => dt + toAdd;

        /// <summary>
        /// Decrease time
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="toSubtract"></param>
        /// <returns></returns>
        public static DateTime DecreaseTime(this DateTime dt, TimeSpan toSubtract) => dt - toSubtract;
    }
}