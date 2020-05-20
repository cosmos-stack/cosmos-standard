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
        /// To DateTime
        /// </summary>
        /// <param name="ldt"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this LocalDateTime ldt) => ldt.ToDateTimeUnspecified();

        /// <summary>
        /// To Datetime
        /// </summary>
        /// <param name="ldt"></param>
        /// <param name="kind"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this LocalDateTime ldt, DateTimeKind kind) => ldt.ToDateTimeUnspecified().SetKind(kind);

        /// <summary>
        /// To DateInfo
        /// </summary>
        /// <param name="ldt"></param>
        /// <returns></returns>
        public static DateInfo ToDateInfo(this LocalDateTime ldt) => new DateInfo(ldt.Year, ldt.Month, ldt.Day);

        /// <summary>
        /// To LocalDate
        /// </summary>
        /// <param name="ldt"></param>
        /// <returns></returns>
        public static LocalDate ToLocalDate(this LocalDateTime ldt) => new LocalDate(ldt.Year, ldt.Month, ldt.Day, ldt.Calendar);

        /// <summary>
        /// To LocalTime
        /// </summary>
        /// <param name="ldt"></param>
        /// <returns></returns>
        public static LocalTime ToLocalTime(this LocalDateTime ldt) => new LocalTime(ldt.Hour, ldt.Minute, ldt.Second, ldt.Millisecond);
    }
}