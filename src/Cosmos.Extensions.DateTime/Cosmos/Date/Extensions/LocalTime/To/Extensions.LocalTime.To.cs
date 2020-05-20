using System;
using NodaTime;

// ReSharper disable once CheckNamespace
namespace Cosmos.Date
{
    /// <summary>
    /// LocalTime extensions
    /// </summary>
    public static partial class LocalTimeExtensions
    {
        /// <summary>
        /// To DateTime
        /// </summary>
        /// <param name="lt"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this LocalTime lt) =>
            DateTime.Today.SetTime(lt.Hour, lt.Minute, lt.Second, lt.Millisecond);

        /// <summary>
        /// To Datetime
        /// </summary>
        /// <param name="lt"></param>
        /// <param name="kind"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this LocalTime lt, DateTimeKind kind) =>
            DateTime.Today.SetTime(lt.Hour, lt.Minute, lt.Second, lt.Millisecond).SetKind(kind);

        /// <summary>
        /// To DateTime
        /// </summary>
        /// <param name="lt"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this LocalTime lt, int year, int month, int day) =>
            DateTimeFactory.Create(year, month, day, lt.Hour, lt.Minute, lt.Second, lt.Millisecond);

        /// <summary>
        /// To Datetime
        /// </summary>
        /// <param name="lt"></param>
        /// <param name="day"></param>
        /// <param name="kind"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this LocalTime lt, int year, int month, int day, DateTimeKind kind) =>
            DateTimeFactory.Create(year, month, day, lt.Hour, lt.Minute, lt.Second, lt.Millisecond, kind);

        /// <summary>
        /// To LocalDateTime
        /// </summary>
        /// <param name="lt"></param>
        /// <returns></returns>
        public static LocalDateTime ToLocalDateTime(this LocalTime lt) =>
            LocalDateTime.FromDateTime(DateTime.Today).SetTime(lt);

        /// <summary>
        /// To LocalDateTime
        /// </summary>
        /// <param name="lt"></param>
        /// <param name="calendar"></param>
        /// <returns></returns>
        public static LocalDateTime ToLocalDateTime(this LocalTime lt, CalendarSystem calendar) =>
            LocalDateTime.FromDateTime(DateTime.Today, calendar).SetTime(lt);

        /// <summary>
        /// To LocalDateTime
        /// </summary>
        /// <param name="lt"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public static LocalDateTime ToLocalDateTime(this LocalTime lt, int year, int month, int day) =>
            new LocalDateTime(year, month, day, lt.Hour, lt.Minute, lt.Second, lt.Millisecond);

        /// <summary>
        /// To LocalDateTime
        /// </summary>
        /// <param name="lt"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <param name="calendar"></param>
        /// <returns></returns>
        public static LocalDateTime ToLocalDateTime(this LocalTime lt, int year, int month, int day, CalendarSystem calendar) =>
            new LocalDateTime(year, month, day, lt.Hour, lt.Minute, lt.Second, lt.Millisecond, calendar);
    }
}