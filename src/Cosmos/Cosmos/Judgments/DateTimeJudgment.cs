using System;

namespace Cosmos.Judgments
{
    /// <summary>
    /// Datetime Judgment Utilities
    /// </summary>
    public static class DateTimeJudgment
    {
        /// <summary>
        /// To judge whether the day is today.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static bool IsToday(DateTime dt) => dt.Date == DateTime.Today;

        /// <summary>
        /// To judge whether the day is today.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static bool IsToday(DateTime? dt) => IsToday(dt.GetValueOrDefault());

        /// <summary>
        /// To judge whether the day is today.
        /// </summary>
        /// <param name="dtOffset"></param>
        /// <returns></returns>
        public static bool IsToday(DateTimeOffset dtOffset) => IsToday(dtOffset.Date);

        /// <summary>
        /// To judge whether the day is today.
        /// </summary>
        /// <param name="dtOffset"></param>
        /// <returns></returns>
        public static bool IsToday(DateTimeOffset? dtOffset) => IsToday(dtOffset.GetValueOrDefault());

        /// <summary>
        /// To judge whether the day is weekend.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static bool IsWeekend(DateTime dt) => dt.DayOfWeek == DayOfWeek.Sunday || dt.DayOfWeek == DayOfWeek.Saturday;

        /// <summary>
        /// To judge whether the day is weekend.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static bool IsWeekend(DateTime? dt) => IsWeekend(dt.GetValueOrDefault());

        /// <summary>
        /// To judge whether the day is weekday.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static bool IsWeekday(DateTime dt) => !IsWeekend(dt);

        /// <summary>
        /// To judge whether the day is weekday.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static bool IsWeekday(DateTime? dt) => IsWeekday(dt.GetValueOrDefault());

        /// <summary>
        /// To judge whether the day is valid.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static bool IsValid(DateTime dt)
        {
            var min = new DateTime(1900, 1, 1);
            var max = new DateTime(9999, 12, 31, 23, 59, 59, 999);
            return dt >= min && dt <= max;
        }
    }
}