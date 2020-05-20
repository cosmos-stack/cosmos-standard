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
        /// Add nanoseconds
        /// </summary>
        /// <param name="lt"></param>
        /// <param name="nanoseconds"></param>
        /// <returns></returns>
        public static LocalTime AddNanoseconds(this LocalTime lt, long nanoseconds) => lt.PlusNanoseconds(nanoseconds);

        /// <summary>
        /// Add milliseconds
        /// </summary>
        /// <param name="lt"></param>
        /// <param name="milliseconds"></param>
        /// <returns></returns>
        public static LocalTime AddMilliseconds(this LocalTime lt, long milliseconds) => lt.PlusMilliseconds(milliseconds);

        /// <summary>
        /// Add seconds
        /// </summary>
        /// <param name="lt"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static LocalTime AddSeconds(this LocalTime lt, long seconds) => lt.PlusSeconds(seconds);

        /// <summary>
        /// Add minutes
        /// </summary>
        /// <param name="lt"></param>
        /// <param name="minutes"></param>
        /// <returns></returns>
        public static LocalTime AddMinutes(this LocalTime lt, long minutes) => lt.PlusMinutes(minutes);

        /// <summary>
        /// Add hours
        /// </summary>
        /// <param name="lt"></param>
        /// <param name="hours"></param>
        /// <returns></returns>
        public static LocalTime AddHours(this LocalTime lt, long hours) => lt.PlusHours(hours);

        /// <summary>
        /// Add TimeSpan
        /// </summary>
        /// <param name="lt"></param>
        /// <param name="ts"></param>
        /// <returns></returns>
        public static LocalTime Add(this LocalTime lt, TimeSpan ts) => lt.PlusTicks(ts.Ticks);

        /// <summary>
        /// Add DateTimeSpan
        /// </summary>
        /// <param name="lt"></param>
        /// <param name="ts"></param>
        /// <returns></returns>
        public static LocalTime Add(this LocalTime lt, DateTimeSpan ts) => lt.PlusTicks(ts.Ticks);

        /// <summary>
        /// Add period
        /// </summary>
        /// <param name="ts"></param>
        /// <param name="period"></param>
        /// <returns></returns>
        public static LocalTime Add(this LocalTime ts, Period period) => ts.Plus(period);
    }
}