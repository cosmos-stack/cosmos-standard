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
        /// Add nanoseconds
        /// </summary>
        /// <param name="lt"></param>
        /// <param name="nanoseconds"></param>
        /// <returns></returns>
        public static LocalDateTime AddNanoseconds(this LocalDateTime lt, long nanoseconds) => lt.PlusNanoseconds(nanoseconds);

        /// <summary>
        /// Add milliseconds
        /// </summary>
        /// <param name="lt"></param>
        /// <param name="milliseconds"></param>
        /// <returns></returns>
        public static LocalDateTime AddMilliseconds(this LocalDateTime lt, long milliseconds) => lt.PlusMilliseconds(milliseconds);

        /// <summary>
        /// Add seconds
        /// </summary>
        /// <param name="lt"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static LocalDateTime AddSeconds(this LocalDateTime lt, long seconds) => lt.PlusSeconds(seconds);

        /// <summary>
        /// Add minutes
        /// </summary>
        /// <param name="lt"></param>
        /// <param name="minutes"></param>
        /// <returns></returns>
        public static LocalDateTime AddMinutes(this LocalDateTime lt, long minutes) => lt.PlusMinutes(minutes);

        /// <summary>
        /// Add hours
        /// </summary>
        /// <param name="lt"></param>
        /// <param name="hours"></param>
        /// <returns></returns>
        public static LocalDateTime AddHours(this LocalDateTime lt, long hours) => lt.PlusHours(hours);

        /// <summary>
        /// Add days
        /// </summary>
        /// <param name="ld"></param>
        /// <param name="days"></param>
        /// <returns></returns>
        public static LocalDateTime AddDays(this LocalDateTime ld, int days) => ld.PlusDays(days);

        /// <summary>
        /// Add weeks
        /// </summary>
        /// <param name="ld"></param>
        /// <param name="weeks"></param>
        /// <returns></returns>
        public static LocalDateTime AddWeeks(this LocalDateTime ld, int weeks) => ld.PlusWeeks(weeks);

        /// <summary>
        /// Add months
        /// </summary>
        /// <param name="ld"></param>
        /// <param name="months"></param>
        /// <returns></returns>
        public static LocalDateTime AddMonths(this LocalDateTime ld, int months) => ld.PlusMonths(months);

        /// <summary>
        /// Add quarters
        /// </summary>
        /// <param name="ld"></param>
        /// <param name="quarters"></param>
        /// <returns></returns>
        public static LocalDateTime AddQuarters(this LocalDateTime ld, int quarters) => ld.PlusMonths(quarters * 3);

        /// <summary>
        /// Add years
        /// </summary>
        /// <param name="ld"></param>
        /// <param name="years"></param>
        /// <returns></returns>
        public static LocalDateTime AddYears(this LocalDateTime ld, int years) => ld.PlusYears(years);

        /// <summary>
        /// Add TimeSpan
        /// </summary>
        /// <param name="lt"></param>
        /// <param name="ts"></param>
        /// <returns></returns>
        public static LocalDateTime Add(this LocalDateTime lt, TimeSpan ts) => lt.PlusTicks(ts.Ticks);

        /// <summary>
        /// Add DateTimeSpan
        /// </summary>
        /// <param name="lt"></param>
        /// <param name="ts"></param>
        /// <returns></returns>
        public static LocalDateTime Add(this LocalDateTime lt, DateTimeSpan ts) => lt.PlusTicks(ts.Ticks);

        /// <summary>
        /// Add period
        /// </summary>
        /// <param name="ts"></param>
        /// <param name="period"></param>
        /// <returns></returns>
        public static LocalDateTime Add(this LocalDateTime ts, Period period) => ts.Plus(period);
    }
}