using System;
using Cosmos.Date;

// ReSharper disable once CheckNamespace
namespace Cosmos {
    /// <summary>
    /// DateTime Extensions<br />
    /// DateTime 扩展方法
    /// </summary>
    public static partial class DateTimeExtensions {
        /// <summary>
        /// Beginning of day
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime BeginningOfDay(this DateTime dt) =>
            DateTimeFactory.Create(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0, dt.Kind);

        /// <summary>
        /// Beginning of day
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="timeZoneOffset"></param>
        /// <returns></returns>
        public static DateTime BeginningOfDay(this DateTime dt, int timeZoneOffset) =>
            DateTimeFactory.Create(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0, dt.Kind).AddHours(timeZoneOffset);

        /// <summary>
        /// Beginning of week
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime BeginningOfWeek(this DateTime dt) => dt.FirstDayOfWeek().BeginningOfDay();

        /// <summary>
        /// Beginning of week
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="timeZoneOffset"></param>
        /// <returns></returns>
        public static DateTime BeginningOfWeek(this DateTime dt, int timeZoneOffset) => dt.FirstDayOfWeek().BeginningOfDay(timeZoneOffset);

        /// <summary>
        /// Beginning of month
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime BeginningOfMonth(this DateTime dt) => dt.FirstDayOfMonth().BeginningOfDay();

        /// <summary>
        /// Beginning of month
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="timeZoneOffset"></param>
        /// <returns></returns>
        public static DateTime BeginningOfMonth(this DateTime dt, int timeZoneOffset) => dt.FirstDayOfMonth().BeginningOfDay(timeZoneOffset);

        /// <summary>
        /// Beginning of quarter
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime BeginningOfQuarter(this DateTime dt) => dt.FirstDayOfQuarter().BeginningOfDay();

        /// <summary>
        /// Beginning of quarter
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="timeZoneOffset"></param>
        /// <returns></returns>
        public static DateTime BeginningOfQuarter(this DateTime dt, int timeZoneOffset) => dt.FirstDayOfQuarter().BeginningOfDay(timeZoneOffset);

        /// <summary>
        /// Beginning of year
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime BeginningOfYear(this DateTime dt) => dt.FirstDayOfYear().BeginningOfDay();

        /// <summary>
        /// Beginning of year
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="timeZoneOffset"></param>
        /// <returns></returns>
        public static DateTime BeginningOfYear(this DateTime dt, int timeZoneOffset) => dt.FirstDayOfYear().BeginningOfDay(timeZoneOffset);
    }
}