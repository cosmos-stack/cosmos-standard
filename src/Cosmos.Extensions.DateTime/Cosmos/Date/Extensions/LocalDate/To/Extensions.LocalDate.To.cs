using System;
using NodaTime;

// ReSharper disable once CheckNamespace
namespace Cosmos.Date
{
    /// <summary>
    /// LocalDate extensions
    /// </summary>
    public static partial class LocalDateExtensions
    {
        /// <summary>
        /// To DateTime
        /// </summary>
        /// <param name="ld"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this LocalDate ld) => ld.ToDateTimeUnspecified();

        /// <summary>
        /// To Datetime
        /// </summary>
        /// <param name="ld"></param>
        /// <param name="kind"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this LocalDate ld, DateTimeKind kind) =>
            DateTimeFactory.Create(ld.Year, ld.Month, ld.Day, 0, 0, 0, 0, kind);

        /// <summary>
        /// To DateInfo
        /// </summary>
        /// <param name="ld"></param>
        /// <returns></returns>
        public static DateInfo ToDateInfo(this LocalDate ld) => new DateInfo(ld.Year, ld.Month, ld.Day);

        /// <summary>
        /// To LocalDateTime
        /// </summary>
        /// <param name="ld"></param>
        /// <returns></returns>
        public static LocalDateTime ToLocalDateTime(this LocalDate ld) =>
            new LocalDateTime(ld.Year, ld.Month, ld.Day, 0, 0);

        /// <summary>
        /// To LocalDateTime
        /// </summary>
        /// <param name="ld"></param>
        /// <param name="calendar"></param>
        /// <returns></returns>
        public static LocalDateTime ToLocalDateTime(this LocalDate ld, CalendarSystem calendar) =>
            new LocalDateTime(ld.Year, ld.Month, ld.Day, 0, 0, calendar);

        /// <summary>
        /// To LocalDateTime
        /// </summary>
        /// <param name="ld"></param>
        /// <param name="hours"></param>
        /// <returns></returns>
        public static LocalDateTime ToLocalDateTime(this LocalDate ld, int hours) =>
            new LocalDateTime(ld.Year, ld.Month, ld.Day, hours, 0);

        /// <summary>
        /// To LocalDateTime
        /// </summary>
        /// <param name="ld"></param>
        /// <param name="hours"></param>
        /// <param name="calendar"></param>
        /// <returns></returns>
        public static LocalDateTime ToLocalDateTime(this LocalDate ld, int hours, CalendarSystem calendar) =>
            new LocalDateTime(ld.Year, ld.Month, ld.Day, hours, 0, calendar);

        /// <summary>
        /// To LocalDateTime
        /// </summary>
        /// <param name="ld"></param>
        /// <param name="hours"></param>
        /// <param name="minutes"></param>
        /// <returns></returns>
        public static LocalDateTime ToLocalDateTime(this LocalDate ld, int hours, int minutes) =>
            new LocalDateTime(ld.Year, ld.Month, ld.Day, hours, minutes);

        /// <summary>
        /// To LocalDateTime
        /// </summary>
        /// <param name="ld"></param>
        /// <param name="hours"></param>
        /// <param name="minutes"></param>
        /// <param name="calendar"></param>
        /// <returns></returns>
        public static LocalDateTime ToLocalDateTime(this LocalDate ld, int hours, int minutes, CalendarSystem calendar) =>
            new LocalDateTime(ld.Year, ld.Month, ld.Day, hours, minutes, calendar);

        /// <summary>
        /// To LocalDateTime
        /// </summary>
        /// <param name="ld"></param>
        /// <param name="hours"></param>
        /// <param name="minutes"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static LocalDateTime ToLocalDateTime(this LocalDate ld, int hours, int minutes, int seconds) =>
            new LocalDateTime(ld.Year, ld.Month, ld.Day, hours, minutes, seconds);

        /// <summary>
        /// To LocalDateTime
        /// </summary>
        /// <param name="ld"></param>
        /// <param name="hours"></param>
        /// <param name="minutes"></param>
        /// <param name="seconds"></param>
        /// <param name="calendar"></param>
        /// <returns></returns>
        public static LocalDateTime ToLocalDateTime(this LocalDate ld, int hours, int minutes, int seconds, CalendarSystem calendar) =>
            new LocalDateTime(ld.Year, ld.Month, ld.Day, hours, minutes, seconds, calendar);

        /// <summary>
        /// To LocalDateTime
        /// </summary>
        /// <param name="ld"></param>
        /// <param name="hours"></param>
        /// <param name="minutes"></param>
        /// <param name="seconds"></param>
        /// <param name="milliseconds"></param>
        /// <returns></returns>
        public static LocalDateTime ToLocalDateTime(this LocalDate ld, int hours, int minutes, int seconds, int milliseconds) =>
            new LocalDateTime(ld.Year, ld.Month, ld.Day, hours, minutes, seconds, milliseconds);

        /// <summary>
        /// To LocalDateTime
        /// </summary>
        /// <param name="ld"></param>
        /// <param name="hours"></param>
        /// <param name="minutes"></param>
        /// <param name="seconds"></param>
        /// <param name="milliseconds"></param>
        /// <param name="calendar"></param>
        /// <returns></returns>
        public static LocalDateTime ToLocalDateTime(this LocalDate ld, int hours, int minutes, int seconds, int milliseconds, CalendarSystem calendar) =>
            new LocalDateTime(ld.Year, ld.Month, ld.Day, hours, minutes, seconds, milliseconds, calendar);
    }
}