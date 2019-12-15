using System;

// ReSharper disable once CheckNamespace
namespace Cosmos {
    /// <summary>
    /// DateTimeOffset Extensions<br />
    /// DateTimeOffset 扩展方法
    /// </summary>
    public static partial class DateTimeOffsetExtensions {
        /// <summary>
        /// Is before
        /// </summary>
        /// <param name="current"></param>
        /// <param name="toCompareWith"></param>
        /// <returns></returns>
        public static bool IsBefore(this DateTimeOffset current, DateTimeOffset toCompareWith) {
            return current < toCompareWith;
        }

        /// <summary>
        /// Is after
        /// </summary>
        /// <param name="current"></param>
        /// <param name="toCompareWith"></param>
        /// <returns></returns>
        public static bool IsAfter(this DateTimeOffset current, DateTimeOffset toCompareWith) {
            return current > toCompareWith;
        }

        /// <summary>
        /// Is in future
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static bool IsInFuture(this DateTimeOffset dateTime) {
            return dateTime > DateTimeOffset.Now;
        }

        /// <summary>
        /// Is in past
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static bool IsInPast(this DateTimeOffset dateTime) {
            return dateTime < DateTimeOffset.Now;
        }

        /// <summary>
        /// Is same day
        /// </summary>
        /// <param name="current"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsSameDay(this DateTimeOffset current, DateTimeOffset date) {
            return current.Date == date.Date;
        }

        /// <summary>
        /// Is same month
        /// </summary>
        /// <param name="current"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsSameMonth(this DateTimeOffset current, DateTimeOffset date) {
            return current.Month == date.Month && current.Year == date.Year;
        }

        /// <summary>
        /// Is same year
        /// </summary>
        /// <param name="current"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsSameYear(this DateTimeOffset current, DateTimeOffset date) {
            return current.Year == date.Year;
        }
    }
}