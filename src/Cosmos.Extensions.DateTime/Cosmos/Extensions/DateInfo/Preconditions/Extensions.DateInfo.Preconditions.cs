using System;
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
        /// Is before
        /// </summary>
        /// <param name="d"></param>
        /// <param name="toCompareWith"></param>
        /// <returns></returns>
        public static bool IsBefore(this DateInfo d, DateInfo toCompareWith) => d < toCompareWith;

        /// <summary>
        /// Is after
        /// </summary>
        /// <param name="d"></param>
        /// <param name="toCompareWith"></param>
        /// <returns></returns>
        public static bool IsAfter(this DateInfo d, DateInfo toCompareWith) => d > toCompareWith;

        /// <summary>
        /// Is in future
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static bool IsInFuture(this DateInfo d) => d > DateTime.Now;

        /// <summary>
        /// Is in past
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static bool IsInPast(this DateInfo d) => d < DateTime.Now;

        /// <summary>
        /// Is same day
        /// </summary>
        /// <param name="d"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsSameDay(this DateInfo d, DateInfo date) => d.DateTimeRef == date.DateTimeRef;

        /// <summary>
        /// Is same month
        /// </summary>
        /// <param name="d"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsSameMonth(this DateInfo d, DateInfo date) => d.Month == date.Month && d.Year == date.Year;

        /// <summary>
        /// Is same year
        /// </summary>
        /// <param name="d"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsSameYear(this DateInfo d, DateInfo date) => d.Year == date.Year;
    }
}