using System;
using Cosmos.Date;
using NodaTime;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    /// <summary>
    /// Instant extensions
    /// </summary>
    public static partial class InstantExtensions
    {
        /// <summary>
        /// Add milliseconds
        /// </summary>
        /// <param name="i"></param>
        /// <param name="milliseconds"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Instant PlusMilliseconds(this Instant i, long milliseconds)
        {
            if (i == null)
                throw new ArgumentNullException(nameof(i));
            return i.Plus(milliseconds.DurationMilliseconds());
        }
        
        /// <summary>
        /// Add milliseconds
        /// </summary>
        /// <param name="i"></param>
        /// <param name="milliseconds"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Instant PlusMilliseconds(this Instant i, double milliseconds)
        {
            if (i == null)
                throw new ArgumentNullException(nameof(i));
            return i.Plus(milliseconds.DurationMilliseconds());
        }

        /// <summary>
        /// Add seconds
        /// </summary>
        /// <param name="i"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Instant PlusSeconds(this Instant i, long seconds)
        {
            if (i == null)
                throw new ArgumentNullException(nameof(i));
            return i.Plus(seconds.DurationSeconds());
        }

        /// <summary>
        /// Add seconds
        /// </summary>
        /// <param name="i"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Instant PlusSeconds(this Instant i, double seconds)
        {
            if (i == null)
                throw new ArgumentNullException(nameof(i));
            return i.Plus(seconds.DurationSeconds());
        }

        /// <summary>
        /// Add Minutes
        /// </summary>
        /// <param name="i"></param>
        /// <param name="minutes"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Instant PlusMinutes(this Instant i, long minutes)
        {
            if (i == null)
                throw new ArgumentNullException(nameof(i));
            return i.Plus(minutes.DurationMinutes());
        }

        /// <summary>
        /// Add Minutes
        /// </summary>
        /// <param name="i"></param>
        /// <param name="minutes"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Instant PlusMinutes(this Instant i, double minutes)
        {
            if (i == null)
                throw new ArgumentNullException(nameof(i));
            return i.Plus(minutes.DurationMinutes());
        }

        /// <summary>
        /// Add hours
        /// </summary>
        /// <param name="i"></param>
        /// <param name="hours"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Instant PlusHours(this Instant i, int hours)
        {
            if (i == null)
                throw new ArgumentNullException(nameof(i));
            return i.Plus(hours.DurationHours());
        }

        /// <summary>
        /// Add hours
        /// </summary>
        /// <param name="i"></param>
        /// <param name="hours"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Instant PlusHours(this Instant i, double hours)
        {
            if (i == null)
                throw new ArgumentNullException(nameof(i));
            return i.Plus(hours.DurationHours());
        }

        /// <summary>
        /// Add days
        /// </summary>
        /// <param name="i"></param>
        /// <param name="days"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Instant PlusDays(this Instant i, int days)
        {
            if (i == null)
                throw new ArgumentNullException(nameof(i));
            return i.Plus(days.DurationDays());
        }

        /// <summary>
        /// Add days
        /// </summary>
        /// <param name="i"></param>
        /// <param name="days"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Instant PlusDays(this Instant i, double days)
        {
            if (i == null)
                throw new ArgumentNullException(nameof(i));
            return i.Plus(days.DurationDays());
        }

        /// <summary>
        /// Add TimeSpan
        /// </summary>
        /// <param name="i"></param>
        /// <param name="ts"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Instant PlusTimeSpan(this Instant i, TimeSpan ts)
        {
            if (i == null)
                throw new ArgumentNullException(nameof(i));
            return i.Plus(ts.AsDuration());
        }

        /// <summary>
        /// Add DateTimeSpan
        /// </summary>
        /// <param name="i"></param>
        /// <param name="ts"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Instant PlusTimeSpan(this Instant i, DateTimeSpan ts)
        {
            if (i == null)
                throw new ArgumentNullException(nameof(i));
            return i.Plus(ts.AsDuration());
        }
    }
}