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
        /// Beginning of day
        /// </summary>
        /// <param name="ldt"></param>
        /// <returns></returns>
        public static LocalDateTime BeginningOfDay(this LocalDateTime ldt) =>
            new LocalDateTime(ldt.Year, ldt.Month, ldt.Day, 0, 0, 0, 0, ldt.Calendar);

        /// <summary>
        /// Beginning of day
        /// </summary>
        /// <param name="ldt"></param>
        /// <param name="timeZoneOffset"></param>
        /// <returns></returns>
        public static LocalDateTime BeginningOfDay(this LocalDateTime ldt, int timeZoneOffset) =>
            new LocalDateTime(ldt.Year, ldt.Month, ldt.Day, 0, 0, 0, 0, ldt.Calendar).AddHours(timeZoneOffset);

        /// <summary>
        /// Beginning of week
        /// </summary>
        /// <param name="ld"></param>
        /// <returns></returns>
        public static LocalDateTime BeginningOfWeek(this LocalDateTime ld) => ld.FirstDayOfWeek().BeginningOfDay();

        /// <summary>
        /// Beginning of week
        /// </summary>
        /// <param name="ld"></param>
        /// <param name="timeZoneOffset"></param>
        /// <returns></returns>
        public static LocalDateTime BeginningOfWeek(this LocalDateTime ld, int timeZoneOffset) => ld.FirstDayOfWeek().BeginningOfDay(timeZoneOffset);

        /// <summary>
        /// Beginning of month
        /// </summary>
        /// <param name="ld"></param>
        /// <returns></returns>
        public static LocalDateTime BeginningOfMonth(this LocalDateTime ld) => ld.FirstDayOfMonth().BeginningOfDay();

        /// <summary>
        /// Beginning of month
        /// </summary>
        /// <param name="ld"></param>
        /// <param name="timeZoneOffset"></param>
        /// <returns></returns>
        public static LocalDateTime BeginningOfMonth(this LocalDateTime ld, int timeZoneOffset) => ld.FirstDayOfMonth().BeginningOfDay(timeZoneOffset);

        /// <summary>
        /// Beginning of quarter
        /// </summary>
        /// <param name="ld"></param>
        /// <returns></returns>
        public static LocalDateTime BeginningOfQuarter(this LocalDateTime ld) => ld.FirstDayOfQuarter().BeginningOfDay();

        /// <summary>
        /// Beginning of quarter
        /// </summary>
        /// <param name="ld"></param>
        /// <param name="timeZoneOffset"></param>
        /// <returns></returns>
        public static LocalDateTime BeginningOfQuarter(this LocalDateTime ld, int timeZoneOffset) => ld.FirstDayOfQuarter().BeginningOfDay(timeZoneOffset);

        /// <summary>
        /// Beginning of year
        /// </summary>
        /// <param name="ld"></param>
        /// <returns></returns>
        public static LocalDateTime BeginningOfYear(this LocalDateTime ld) => ld.FirstDayOfYear().BeginningOfDay();

        /// <summary>
        /// Beginning of year
        /// </summary>
        /// <param name="ld"></param>
        /// <param name="timeZoneOffset"></param>
        /// <returns></returns>
        public static LocalDateTime BeginningOfYear(this LocalDateTime ld, int timeZoneOffset) => ld.FirstDayOfYear().BeginningOfDay(timeZoneOffset);
    }
}