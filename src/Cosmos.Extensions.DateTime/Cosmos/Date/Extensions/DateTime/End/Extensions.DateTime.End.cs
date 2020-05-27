using System;

// ReSharper disable once CheckNamespace
namespace Cosmos.Date
{
    /// <summary>
    /// DateTime Extensions<br />
    /// DateTime 扩展方法
    /// </summary>
    public static partial class DateTimeExtensions
    {
        /// <summary>
        /// End of day
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime EndOfDay(this DateTime dt) =>
            DateTimeFactory.Create(dt.Year, dt.Month, dt.Day, 23, 59, 59, 999, dt.Kind);

        /// <summary>
        /// End of day (timezone-adjusted)
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="timeZoneOffset"></param>
        /// <returns></returns>
        public static DateTime EndOfDay(this DateTime dt, int timeZoneOffset) =>
            DateTimeFactory.Create(dt.Year, dt.Month, dt.Day, 23, 59, 59, 999, dt.Kind).AddHours(timeZoneOffset);

        /// <summary>
        /// End of week
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime EndOfWeek(this DateTime dt) => dt.LastDayOfWeek().EndOfDay();

        /// <summary>
        /// End of week
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="timeZoneOffset"></param>
        /// <returns></returns>
        public static DateTime EndOfWeek(this DateTime dt, int timeZoneOffset) => dt.LastDayOfWeek().EndOfDay(timeZoneOffset);

        /// <summary>
        /// End of month
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime EndOfMonth(this DateTime dt) => dt.LastDayOfMonth().EndOfDay();

        /// <summary>
        /// End of month
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="timeZoneOffset"></param>
        /// <returns></returns>
        public static DateTime EndOfMonth(this DateTime dt, int timeZoneOffset) => dt.LastDayOfMonth().EndOfDay(timeZoneOffset);

        /// <summary>
        /// End of quarter
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime EndOfQuarter(this DateTime dt) => dt.LastDayOfQuarter().EndOfDay();

        /// <summary>
        /// End of quarter
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="timeZoneOffset"></param>
        /// <returns></returns>
        public static DateTime EndOfQuarter(this DateTime dt, int timeZoneOffset) => dt.LastDayOfQuarter().EndOfDay(timeZoneOffset);

        /// <summary>
        /// End of year
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime EndOfYear(this DateTime dt) => dt.LastDayOfYear().EndOfDay();

        /// <summary>
        /// End of year
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="timeZoneOffset"></param>
        /// <returns></returns>
        public static DateTime EndOfYear(this DateTime dt, int timeZoneOffset) => dt.LastDayOfYear().EndOfDay(timeZoneOffset);
    }
}