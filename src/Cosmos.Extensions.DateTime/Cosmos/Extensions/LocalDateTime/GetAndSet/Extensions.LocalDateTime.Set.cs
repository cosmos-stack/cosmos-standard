using System;
using Cosmos.Date;
using NodaTime;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    /// <summary>
    /// LocalDateTime extensions
    /// </summary>
    public static partial class LocalDateTimeExtensions
    {
        /// <summary>
        /// Set time
        /// </summary>
        /// <param name="ldt"></param>
        /// <param name="lt"></param>
        /// <returns></returns>
        public static LocalDateTime SetTime(this LocalDateTime ldt, LocalTime lt) =>
            ldt.SetTime(lt.Hour, lt.Minute, lt.Second, lt.Millisecond);
        
        /// <summary>
        /// Set time
        /// </summary>
        /// <param name="ldt"></param>
        /// <param name="hour"></param>
        /// <returns></returns>
        public static LocalDateTime SetTime(this LocalDateTime ldt, int hour) =>
            new LocalDateTime(ldt.Year, ldt.Month, ldt.Day, hour, ldt.Minute, ldt.Second, ldt.Millisecond, ldt.Calendar);

        /// <summary>
        /// Set time
        /// </summary>
        /// <param name="ldt"></param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <returns></returns>
        public static LocalDateTime SetTime(this LocalDateTime ldt, int hour, int minute) =>
            new LocalDateTime(ldt.Year, ldt.Month, ldt.Day, hour, minute, ldt.Second, ldt.Millisecond, ldt.Calendar);

        /// <summary>
        /// Set time
        /// </summary>
        /// <param name="ldt"></param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static LocalDateTime SetTime(this LocalDateTime ldt, int hour, int minute, int second) =>
            new LocalDateTime(ldt.Year, ldt.Month, ldt.Day, hour, minute, second, ldt.Millisecond, ldt.Calendar);

        /// <summary>
        /// Set time
        /// </summary>
        /// <param name="ldt"></param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <param name="second"></param>
        /// <param name="millisecond"></param>
        /// <returns></returns>
        public static LocalDateTime SetTime(this LocalDateTime ldt, int hour, int minute, int second, int millisecond) =>
            new LocalDateTime(ldt.Year, ldt.Month, ldt.Day, hour, minute, second, millisecond, ldt.Calendar);

        /// <summary>
        /// Set time
        /// </summary>
        /// <param name="ldt"></param>
        /// <param name="hour"></param>
        /// <returns></returns>
        public static LocalDateTime SetHour(this LocalDateTime ldt, int hour) =>
            new LocalDateTime(ldt.Year, ldt.Month, ldt.Day, hour, ldt.Minute, ldt.Second, ldt.Millisecond, ldt.Calendar);

        /// <summary>
        /// Set time
        /// </summary>
        /// <param name="ldt"></param>
        /// <param name="minute"></param>
        /// <returns></returns>
        public static LocalDateTime SetMinute(this LocalDateTime ldt, int minute) =>
            new LocalDateTime(ldt.Year, ldt.Month, ldt.Day, ldt.Hour, minute, ldt.Second, ldt.Millisecond, ldt.Calendar);

        /// <summary>
        /// Set time
        /// </summary>
        /// <param name="ldt"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static LocalDateTime SetSecond(this LocalDateTime ldt, int second) =>
            new LocalDateTime(ldt.Year, ldt.Month, ldt.Day, ldt.Hour, ldt.Minute, second, ldt.Millisecond, ldt.Calendar);

        /// <summary>
        /// Set time
        /// </summary>
        /// <param name="ldt"></param>
        /// <param name="millisecond"></param>
        /// <returns></returns>
        public static LocalDateTime SetMillisecond(this LocalDateTime ldt, int millisecond) =>
            new LocalDateTime(ldt.Year, ldt.Month, ldt.Day, ldt.Hour, ldt.Minute, ldt.Second, millisecond, ldt.Calendar);

        /// <summary>
        /// Midnight
        /// </summary>
        /// <param name="ldt"></param>
        /// <returns></returns>
        public static LocalDateTime Midnight(this LocalDateTime ldt) => ldt.BeginningOfDay();

        /// <summary>
        /// Noon
        /// </summary>
        /// <param name="ldt"></param>
        /// <returns></returns>
        public static LocalDateTime Noon(this LocalDateTime ldt) => ldt.SetTime(12, 0, 0, 0);

        /// <summary>
        /// Set date
        /// </summary>
        /// <param name="ldt"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public static LocalDateTime SetDate(this LocalDateTime ldt, int year) =>
            new LocalDateTime(year, ldt.Month, ldt.Day, ldt.Hour, ldt.Minute, ldt.Second, ldt.Millisecond, ldt.Calendar);

        /// <summary>
        /// Set date
        /// </summary>
        /// <param name="ldt"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public static LocalDateTime SetDate(this LocalDateTime ldt, int year, int month) =>
            new LocalDateTime(year, month, ldt.Day, ldt.Hour, ldt.Minute, ldt.Second, ldt.Millisecond, ldt.Calendar);

        /// <summary>
        /// Set date
        /// </summary>
        /// <param name="ldt"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public static LocalDateTime SetDate(this LocalDateTime ldt, int year, int month, int day) =>
            new LocalDateTime(year, month, day, ldt.Hour, ldt.Minute, ldt.Second, ldt.Millisecond, ldt.Calendar);

        /// <summary>
        /// Set date
        /// </summary>
        /// <param name="ldt"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public static LocalDateTime SetYear(this LocalDateTime ldt, int year) =>
            new LocalDateTime(year, ldt.Month, ldt.Day, ldt.Hour, ldt.Minute, ldt.Second, ldt.Millisecond, ldt.Calendar);

        /// <summary>
        /// Set date
        /// </summary>
        /// <param name="ldt"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public static LocalDateTime SetMonth(this LocalDateTime ldt, int month) =>
            new LocalDateTime(ldt.Year, month, ldt.Day, ldt.Hour, ldt.Minute, ldt.Second, ldt.Millisecond, ldt.Calendar);

        /// <summary>
        /// Set date
        /// </summary>
        /// <param name="ldt"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public static LocalDateTime SetDay(this LocalDateTime ldt, int day) =>
            new LocalDateTime(ldt.Year, ldt.Month, day, ldt.Hour, ldt.Minute, ldt.Second, ldt.Millisecond, ldt.Calendar);
    }
}