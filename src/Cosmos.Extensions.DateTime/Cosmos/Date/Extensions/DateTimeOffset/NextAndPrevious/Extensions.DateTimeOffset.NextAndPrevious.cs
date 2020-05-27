using System;

// ReSharper disable once CheckNamespace
namespace Cosmos.Date
{
    /// <summary>
    /// DateTimeOffset Extensions<br />
    /// DateTimeOffset 扩展方法
    /// </summary>
    public static partial class DateTimeOffsetExtensions
    {
        /// <summary>
        /// Next year
        /// </summary>
        /// <param name="start"></param>
        /// <returns></returns>
        public static DateTimeOffset NextYear(this DateTimeOffset start)
        {
            var nextYear = start.Year + 1;
            var numberOfDaysInSameMonthNextYear = DateTime.DaysInMonth(nextYear, start.Month);

            if (numberOfDaysInSameMonthNextYear < start.Day)
            {
                var differenceInDays = start.Day - numberOfDaysInSameMonthNextYear;
                var dateTimeOffset = new DateTimeOffset(nextYear, start.Month, numberOfDaysInSameMonthNextYear, start.Hour, start.Minute, start.Second, start.Millisecond,
                    start.Offset);
                return dateTimeOffset + differenceInDays.Days();
            }

            return new DateTimeOffset(nextYear, start.Month, start.Day, start.Hour, start.Minute, start.Second, start.Millisecond, start.Offset);
        }

        /// <summary>
        /// Previous year
        /// </summary>
        /// <param name="start"></param>
        /// <returns></returns>
        public static DateTimeOffset PreviousYear(this DateTimeOffset start)
        {
            var previousYear = start.Year - 1;
            var numberOfDaysInSameMonthPreviousYear = DateTime.DaysInMonth(previousYear, start.Month);

            if (numberOfDaysInSameMonthPreviousYear < start.Day)
            {
                var differenceInDays = start.Day - numberOfDaysInSameMonthPreviousYear;
                var dateTime = new DateTimeOffset(previousYear, start.Month, numberOfDaysInSameMonthPreviousYear, start.Hour, start.Minute, start.Second, start.Millisecond,
                    start.Offset);
                return dateTime + differenceInDays.Days();
            }

            return new DateTimeOffset(previousYear, start.Month, start.Day, start.Hour, start.Minute, start.Second, start.Millisecond, start.Offset);
        }

        /// <summary>
        /// Next month
        /// </summary>
        /// <param name="current"></param>
        /// <returns></returns>
        public static DateTimeOffset NextMonth(this DateTimeOffset current)
        {
            var year = current.Month == 12 ? current.Year + 1 : current.Year;

            var month = current.Month == 12 ? 1 : current.Month + 1;

            var firstDayOfNextMonth = current.SetDate(year, month, 1);

            var lastDayOfPreviousMonth = firstDayOfNextMonth.LastDayOfMonth().Day;

            var day = current.Day > lastDayOfPreviousMonth ? lastDayOfPreviousMonth : current.Day;

            return firstDayOfNextMonth.SetDay(day);
        }

        /// <summary>
        /// Previous month
        /// </summary>
        /// <param name="current"></param>
        /// <returns></returns>
        public static DateTimeOffset PreviousMonth(this DateTimeOffset current)
        {
            var year = current.Month == 1 ? current.Year - 1 : current.Year;

            var month = current.Month == 1 ? 12 : current.Month - 1;

            var firstDayOfPreviousMonth = current.SetDate(year, month, 1);

            var lastDayOfPreviousMonth = firstDayOfPreviousMonth.LastDayOfMonth().Day;

            var day = current.Day > lastDayOfPreviousMonth ? lastDayOfPreviousMonth : current.Day;

            return firstDayOfPreviousMonth.SetDay(day);
        }

        /// <summary>
        /// Next day
        /// </summary>
        /// <param name="start"></param>
        /// <returns></returns>
        public static DateTimeOffset NextDay(this DateTimeOffset start)
        {
            return start + 1.Days();
        }

        /// <summary>
        /// Previous day
        /// </summary>
        /// <param name="start"></param>
        /// <returns></returns>
        public static DateTimeOffset PreviousDay(this DateTimeOffset start)
        {
            return start - 1.Days();
        }

        /// <summary>
        /// Next
        /// </summary>
        /// <param name="start"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public static DateTimeOffset Next(this DateTimeOffset start, DayOfWeek day)
        {
            do
            {
                start = start.NextDay();
            }
            while (start.DayOfWeek != day);

            return start;
        }

        /// <summary>
        /// Previous
        /// </summary>
        /// <param name="start"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public static DateTimeOffset Previous(this DateTimeOffset start, DayOfWeek day)
        {
            do
            {
                start = start.PreviousDay();
            }
            while (start.DayOfWeek != day);

            return start;
        }

        /// <summary>
        /// Increase Time
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="toAdd"></param>
        /// <returns></returns>
        public static DateTimeOffset IncreaseTime(this DateTimeOffset startDate, TimeSpan toAdd)
        {
            return startDate + toAdd;
        }

        /// <summary>
        /// Decrease Time
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="toSubtract"></param>
        /// <returns></returns>
        public static DateTimeOffset DecreaseTime(this DateTimeOffset startDate, TimeSpan toSubtract)
        {
            return startDate - toSubtract;
        }
    }
}