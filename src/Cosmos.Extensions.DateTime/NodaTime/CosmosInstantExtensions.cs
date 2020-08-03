using System;
using Cosmos.Date;

namespace NodaTime
{
    /// <summary>
    /// Cosmos <see cref="Instant"/> extensions.
    /// </summary>
    public static class CosmosInstantExtensions
    {
        #region Add

        /// <summary>
        /// Add nanoseconds
        /// </summary>
        /// <param name="i"></param>
        /// <param name="nanoseconds"></param>
        /// <returns></returns>
        public static Instant AddNanoseconds(this Instant i, long nanoseconds) => i.PlusNanoseconds(nanoseconds);

        /// <summary>
        /// Add milliseconds
        /// </summary>
        /// <param name="i"></param>
        /// <param name="milliseconds"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Instant AddMilliseconds(this Instant i, long milliseconds) => i.PlusMilliseconds(milliseconds);

        /// <summary>
        /// Add milliseconds
        /// </summary>
        /// <param name="i"></param>
        /// <param name="milliseconds"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Instant AddMilliseconds(this Instant i, double milliseconds) => i.PlusMilliseconds(milliseconds);

        /// <summary>
        /// Add seconds
        /// </summary>
        /// <param name="i"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Instant AddSeconds(this Instant i, long seconds) => i.PlusSeconds(seconds);

        /// <summary>
        /// Add seconds
        /// </summary>
        /// <param name="i"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Instant AddSeconds(this Instant i, double seconds) => i.PlusSeconds(seconds);

        /// <summary>
        /// Add Minutes
        /// </summary>
        /// <param name="i"></param>
        /// <param name="minutes"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Instant AddMinutes(this Instant i, long minutes) => i.PlusMinutes(minutes);

        /// <summary>
        /// Add Minutes
        /// </summary>
        /// <param name="i"></param>
        /// <param name="minutes"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Instant AddMinutes(this Instant i, double minutes) => i.PlusMinutes(minutes);

        /// <summary>
        /// Add hours
        /// </summary>
        /// <param name="i"></param>
        /// <param name="hours"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Instant AddHours(this Instant i, int hours) => i.PlusHours(hours);

        /// <summary>
        /// Add hours
        /// </summary>
        /// <param name="i"></param>
        /// <param name="hours"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Instant AddHours(this Instant i, double hours) => i.PlusHours(hours);

        /// <summary>
        /// Add days
        /// </summary>
        /// <param name="i"></param>
        /// <param name="days"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Instant AddDays(this Instant i, int days) => i.PlusDays(days);

        /// <summary>
        /// Add days
        /// </summary>
        /// <param name="i"></param>
        /// <param name="days"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Instant AddDays(this Instant i, double days) => i.PlusDays(days);

        /// <summary>
        /// Add TimeSpan
        /// </summary>
        /// <param name="i"></param>
        /// <param name="ts"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Instant AddTimeSpan(this Instant i, TimeSpan ts) => i.PlusTimeSpan(ts);

        /// <summary>
        /// Add DateTimeSpan
        /// </summary>
        /// <param name="i"></param>
        /// <param name="ts"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Instant AddTimeSpan(this Instant i, DateTimeSpan ts) => i.PlusTimeSpan(ts);

        #endregion

        #region Plus (shortcut)

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
            return i.Plus(milliseconds.AsDurationOfMilliseconds());
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
            return i.Plus(milliseconds.AsDurationOfMilliseconds());
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
            return i.Plus(seconds.AsDurationOfSeconds());
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
            return i.Plus(seconds.AsDurationOfSeconds());
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
            return i.Plus(minutes.AsDurationOfMinutes());
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
            return i.Plus(minutes.AsDurationOfMinutes());
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
            return i.Plus(hours.AsDurationOfHours());
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
            return i.Plus(hours.AsDurationOfHours());
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
            return i.Plus(days.AsDurationOfDays());
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
            return i.Plus(days.AsDurationOfDays());
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

        #endregion
    }
}
