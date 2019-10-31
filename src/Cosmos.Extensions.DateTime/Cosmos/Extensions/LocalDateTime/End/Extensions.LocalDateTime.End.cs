using System;
using Cosmos.Date;
using NodaTime;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    /// <summary>
    /// LocalLocalDateTime extensions
    /// </summary>
    public static partial class LocalLocalDateTimeExtensions
    {
        /// <summary>
        /// End of day
        /// </summary>
        /// <param name="ldt"></param>
        /// <returns></returns>
        public static LocalDateTime EndOfDay(this LocalDateTime ldt) =>
            new LocalDateTime(ldt.Year, ldt.Month, ldt.Day, 23, 59, 59, 999, ldt.Calendar);

        /// <summary>
        /// End of day (timezone-adjusted)
        /// </summary>
        /// <param name="ldt"></param>
        /// <param name="timeZoneOffset"></param>
        /// <returns></returns>
        public static LocalDateTime EndOfDay(this LocalDateTime ldt, int timeZoneOffset) =>
            new LocalDateTime(ldt.Year, ldt.Month, ldt.Day, 23, 59, 59, 999, ldt.Calendar).AddHours(timeZoneOffset);

        /// <summary>
        /// End of week
        /// </summary>
        /// <param name="ldt"></param>
        /// <returns></returns>
        public static LocalDateTime EndOfWeek(this LocalDateTime ldt) => ldt.LastDayOfWeek().EndOfDay();

        /// <summary>
        /// End of week
        /// </summary>
        /// <param name="ldt"></param>
        /// <param name="timeZoneOffset"></param>
        /// <returns></returns>
        public static LocalDateTime EndOfWeek(this LocalDateTime ldt, int timeZoneOffset) => ldt.LastDayOfWeek().EndOfDay(timeZoneOffset);

        /// <summary>
        /// End of month
        /// </summary>
        /// <param name="ldt"></param>
        /// <returns></returns>
        public static LocalDateTime EndOfMonth(this LocalDateTime ldt) => ldt.LastDayOfMonth().EndOfDay();

        /// <summary>
        /// End of month
        /// </summary>
        /// <param name="ldt"></param>
        /// <param name="timeZoneOffset"></param>
        /// <returns></returns>
        public static LocalDateTime EndOfMonth(this LocalDateTime ldt, int timeZoneOffset) => ldt.LastDayOfMonth().EndOfDay(timeZoneOffset);

        /// <summary>
        /// End of quarter
        /// </summary>
        /// <param name="ldt"></param>
        /// <returns></returns>
        public static LocalDateTime EndOfQuarter(this LocalDateTime ldt) => ldt.LastDayOfQuarter().EndOfDay();

        /// <summary>
        /// End of quarter
        /// </summary>
        /// <param name="ldt"></param>
        /// <param name="timeZoneOffset"></param>
        /// <returns></returns>
        public static LocalDateTime EndOfQuarter(this LocalDateTime ldt, int timeZoneOffset) => ldt.LastDayOfQuarter().EndOfDay(timeZoneOffset);

        /// <summary>
        /// End of year
        /// </summary>
        /// <param name="ldt"></param>
        /// <returns></returns>
        public static LocalDateTime EndOfYear(this LocalDateTime ldt) => ldt.LastDayOfYear().EndOfDay();

        /// <summary>
        /// End of year
        /// </summary>
        /// <param name="ldt"></param>
        /// <param name="timeZoneOffset"></param>
        /// <returns></returns>
        public static LocalDateTime EndOfYear(this LocalDateTime ldt, int timeZoneOffset) => ldt.LastDayOfYear().EndOfDay(timeZoneOffset);
    }
}