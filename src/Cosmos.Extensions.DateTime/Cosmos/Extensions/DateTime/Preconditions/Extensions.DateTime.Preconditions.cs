using System;

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
        /// Is before
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="toCompareWith"></param>
        /// <returns></returns>
        public static bool IsBefore(this DateTime dt, DateTime toCompareWith) => dt < toCompareWith;

        /// <summary>
        /// Is after
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="toCompareWith"></param>
        /// <returns></returns>
        public static bool IsAfter(this DateTime dt, DateTime toCompareWith) => dt > toCompareWith;

        /// <summary>
        /// Is in future
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static bool IsInFuture(this DateTime dt) => dt > DateTime.Now;

        /// <summary>
        /// Is in past
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static bool IsInPast(this DateTime dt) => dt < DateTime.Now;

        /// <summary>
        /// Is same day
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsSameDay(this DateTime dt, DateTime date) => dt.Date == date.Date;

        /// <summary>
        /// Is same month
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsSameMonth(this DateTime dt, DateTime date) => dt.Month == date.Month && dt.Year == date.Year;

        /// <summary>
        /// Is same year
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsSameYear(this DateTime dt, DateTime date) => dt.Year == date.Year;
    }
}