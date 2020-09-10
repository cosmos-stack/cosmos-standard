using System;
using Cosmos.Date;

namespace NodaTime
{
    /// <summary>
    /// Cosmos <see cref="Period"/> extensions.
    /// </summary>
    public static class NodaPeriodExtensions
    {
        #region As period

        /// <summary>
        /// From TimeSpan
        /// </summary>
        /// <param name="ts"></param>
        /// <returns></returns>
        public static Period AsPeriod(this TimeSpan ts) => Period.FromTicks(ts.Ticks);

        /// <summary>
        /// From DateTimeSpan
        /// </summary>
        /// <param name="ts"></param>
        /// <returns></returns>
        public static Period AsPeriod(this DateTimeSpan ts) => ts;

        /// <summary>
        /// From duration
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static Period AsPeriod(this Duration d) => Period.FromTicks(d.ToTimeSpan().Ticks);

        /// <summary>
        /// To TimeSpan
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static TimeSpan AsTimeSpan(this Period p) => TimeSpan.FromTicks(p.Ticks);

        /// <summary>
        /// To DateTimeSpan
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static DateTimeSpan AsDateTimeSpan(this Period p) => p;

        /// <summary>
        /// TO Duration
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Duration AsDuration(this Period p) => Duration.FromTicks(p.Ticks);

        #endregion

        #region As period of number

        /// <summary>
        /// From nanoseconds
        /// </summary>
        /// <param name="nanoseconds"></param>
        /// <returns></returns>
        public static Period AsPeriodOfNanoseconds(this long nanoseconds) => Period.FromNanoseconds(nanoseconds);

        /// <summary>
        /// From Milliseconds
        /// </summary>
        /// <param name="milliseconds"></param>
        /// <returns></returns>
        public static Period AsPeriodOfMilliseconds(this long milliseconds) => Period.FromMilliseconds(milliseconds);

        /// <summary>
        /// From seconds
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static Period AsPeriodOfSeconds(this long seconds) => Period.FromSeconds(seconds);

        /// <summary>
        /// From Minutes
        /// </summary>
        /// <param name="minutes"></param>
        /// <returns></returns>
        public static Period AsPeriodOfMinutes(this long minutes) => Period.FromMinutes(minutes);

        /// <summary>
        /// From hours
        /// </summary>
        /// <param name="hours"></param>
        /// <returns></returns>
        public static Period AsPeriodOfHours(this long hours) => Period.FromHours(hours);

        /// <summary>
        /// From days
        /// </summary>
        /// <param name="days"></param>
        /// <returns></returns>
        public static Period AsPeriodOfDays(this int days) => Period.FromDays(days);

        /// <summary>
        /// From weeks
        /// </summary>
        /// <param name="weeks"></param>
        /// <returns></returns>
        public static Period AsPeriodOfWeeks(this int weeks) => Period.FromWeeks(weeks);

        /// <summary>
        /// From months
        /// </summary>
        /// <param name="months"></param>
        /// <returns></returns>
        public static Period AsPeriodOfMonths(this int months) => Period.FromMonths(months);

        /// <summary>
        /// From quarters
        /// </summary>
        /// <param name="quarters"></param>
        /// <returns></returns>
        public static Period AsPeriodOfQuarters(this int quarters) => Period.FromMonths(quarters * 3);

        /// <summary>
        /// From years
        /// </summary>
        /// <param name="years"></param>
        /// <returns></returns>
        public static Period AsPeriodOfYears(this int years) => Period.FromYears(years);

        #endregion
    }
}