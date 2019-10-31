using NodaTime;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    /// <summary>
    /// Period extensions
    /// </summary>
    public static partial class PeriodExtensions
    {
        /// <summary>
        /// From nanoseconds
        /// </summary>
        /// <param name="nanoseconds"></param>
        /// <returns></returns>
        public static Period PeriodNanoseconds(this long nanoseconds) => Period.FromNanoseconds(nanoseconds);

        /// <summary>
        /// From Milliseconds
        /// </summary>
        /// <param name="milliseconds"></param>
        /// <returns></returns>
        public static Period PeriodMilliseconds(this long milliseconds) => Period.FromMilliseconds(milliseconds);

        /// <summary>
        /// From seconds
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static Period PeriodSeconds(this long seconds) => Period.FromSeconds(seconds);

        /// <summary>
        /// From Minutes
        /// </summary>
        /// <param name="minutes"></param>
        /// <returns></returns>
        public static Period PeriodMinutes(this long minutes) => Period.FromMinutes(minutes);

        /// <summary>
        /// From hours
        /// </summary>
        /// <param name="hours"></param>
        /// <returns></returns>
        public static Period PeriodHours(this long hours) => Period.FromHours(hours);

        /// <summary>
        /// From days
        /// </summary>
        /// <param name="days"></param>
        /// <returns></returns>
        public static Period PeriodDays(this int days) => Period.FromDays(days);

        /// <summary>
        /// From weeks
        /// </summary>
        /// <param name="weeks"></param>
        /// <returns></returns>
        public static Period PeriodWeeks(this int weeks) => Period.FromWeeks(weeks);

        /// <summary>
        /// From months
        /// </summary>
        /// <param name="months"></param>
        /// <returns></returns>
        public static Period PeriodMonths(this int months) => Period.FromMonths(months);

        /// <summary>
        /// From quarters
        /// </summary>
        /// <param name="quarters"></param>
        /// <returns></returns>
        public static Period FromQuarters(this int quarters) => Period.FromMonths(quarters * 3);

        /// <summary>
        /// From years
        /// </summary>
        /// <param name="years"></param>
        /// <returns></returns>
        public static Period PeriodYears(this int years) => Period.FromYears(years);
    }
}