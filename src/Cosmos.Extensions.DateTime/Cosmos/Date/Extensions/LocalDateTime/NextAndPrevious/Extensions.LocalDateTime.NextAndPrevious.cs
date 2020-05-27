using System;
using NodaTime;

// ReSharper disable once CheckNamespace
namespace Cosmos.Date
{
    /// <summary>
    /// LocalDateTime extensions
    /// </summary>
    public static partial class LocalDateTimeExtensions
    {
        /// <summary>
        /// Next year
        /// </summary>
        /// <param name="ld"></param>
        /// <returns></returns>
        public static LocalDateTime NextYear(this LocalDateTime ld)
        {
            var year = ld.Year + 1;
            var daysOfMonth = DateTime.DaysInMonth(year, ld.Month);

            if (daysOfMonth == ld.Day)
                return new LocalDateTime(year, ld.Month, ld.Day, ld.Hour, ld.Minute, ld.Second, ld.Millisecond, ld.Calendar);

            var d = ld.Day - daysOfMonth;
            var p = new LocalDateTime(year, ld.Month, daysOfMonth, ld.Hour, ld.Minute, ld.Second, ld.Millisecond, ld.Calendar);
            return p.AddDays(d);
        }

        /// <summary>
        /// Previous Year
        /// </summary>
        /// <param name="ld"></param>
        /// <returns></returns>
        public static LocalDateTime PreviousYear(this LocalDateTime ld)
        {
            var year = ld.Year - 1;
            var daysOfMonth = DateTime.DaysInMonth(year, ld.Month);

            if (daysOfMonth == ld.Day)
                return new LocalDateTime(year, ld.Month, ld.Day, ld.Hour, ld.Minute, ld.Second, ld.Millisecond, ld.Calendar);

            var d = ld.Day - daysOfMonth;
            var p = new LocalDateTime(year, ld.Month, daysOfMonth, ld.Hour, ld.Minute, ld.Second, ld.Millisecond, ld.Calendar);
            return p.AddDays(d);
        }

        /// <summary>
        /// Gets next month
        /// </summary>
        /// <param name="ldt"></param>
        /// <returns></returns>
        public static LocalDateTime NextMonth(this LocalDateTime ldt)
        {
            var year = ldt.Month == 12 ? ldt.Year + 1 : ldt.Year;

            var month = ldt.Month == 12 ? 1 : ldt.Month + 1;

            var firstDayOfNextMonth = ldt.SetDate(year, month, 1);

            var lastDayOfPreviousMonth = firstDayOfNextMonth.LastDayOfMonth().Day;

            var day = ldt.Day > lastDayOfPreviousMonth ? lastDayOfPreviousMonth : ldt.Day;

            return firstDayOfNextMonth.SetDay(day);
        }

        /// <summary>
        /// Gets previous month
        /// </summary>
        /// <param name="ldt"></param>
        /// <returns></returns>
        public static LocalDateTime PreviousMonth(this LocalDateTime ldt)
        {
            var year = ldt.Month == 1 ? ldt.Year - 1 : ldt.Year;

            var month = ldt.Month == 1 ? 12 : ldt.Month - 1;

            var firstDayOfPreviousMonth = ldt.SetDate(year, month, 1);

            var lastDayOfPreviousMonth = firstDayOfPreviousMonth.LastDayOfMonth().Day;

            var day = ldt.Day > lastDayOfPreviousMonth ? lastDayOfPreviousMonth : ldt.Day;

            return firstDayOfPreviousMonth.SetDay(day);
        }

        /// <summary>
        /// Next day
        /// </summary>
        /// <param name="ldt"></param>
        /// <returns></returns>
        public static LocalDateTime NextDay(this LocalDateTime ldt) => ldt + 1.Days();

        /// <summary>
        /// Previous Day
        /// </summary>
        /// <param name="ldt"></param>
        /// <returns></returns>
        public static LocalDateTime PreviousDay(this LocalDateTime ldt) => ldt - 1.Days();

        /// <summary>
        /// Next
        /// </summary>
        /// <param name="ldt"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static LocalDateTime Next(this LocalDateTime ldt, DayOfWeek dayOfWeek)
        {
            do
            {
                ldt = ldt.NextDay();
            }
            while (ldt.DayOfWeek != NodaTime.Helpers.DayOfWeekHelper.ToNodaTimeWeek(dayOfWeek));

            return ldt;
        }

        /// <summary>
        /// Previous
        /// </summary>
        /// <param name="ldt"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static LocalDateTime Previous(this LocalDateTime ldt, DayOfWeek dayOfWeek)
        {
            do
            {
                ldt = ldt.PreviousDay();
            }
            while (ldt.DayOfWeek != NodaTime.Helpers.DayOfWeekHelper.ToNodaTimeWeek(dayOfWeek));

            return ldt;
        }

        /// <summary>
        /// Week after
        /// </summary>
        /// <param name="ldt"></param>
        /// <returns></returns>
        public static LocalDateTime WeekAfter(this LocalDateTime ldt) => ldt + 1.Weeks();

        /// <summary>
        /// Week before
        /// </summary>
        /// <param name="ldt"></param>
        /// <returns></returns>
        public static LocalDateTime WeekBefore(this LocalDateTime ldt) => ldt - 1.Weeks();

        /// <summary>
        /// Increase time
        /// </summary>
        /// <param name="ldt"></param>
        /// <param name="toAdd"></param>
        /// <returns></returns>
        public static LocalDateTime IncreaseTime(this LocalDateTime ldt, TimeSpan toAdd) => ldt.Add(toAdd);

        /// <summary>
        /// Decrease time
        /// </summary>
        /// <param name="ldt"></param>
        /// <param name="toSubtract"></param>
        /// <returns></returns>
        public static LocalDateTime DecreaseTime(this LocalDateTime ldt, TimeSpan toSubtract) => ldt.Add(-toSubtract);
    }
}