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
        /// Add days
        /// </summary>
        /// <param name="ld"></param>
        /// <param name="days"></param>
        /// <returns></returns>
        public static LocalDate AddDays(this LocalDate ld, int days) => ld.PlusDays(days);

        /// <summary>
        /// Add weeks
        /// </summary>
        /// <param name="ld"></param>
        /// <param name="weeks"></param>
        /// <returns></returns>
        public static LocalDate AddWeeks(this LocalDate ld, int weeks) => ld.PlusWeeks(weeks);

        /// <summary>
        /// Add months
        /// </summary>
        /// <param name="ld"></param>
        /// <param name="months"></param>
        /// <returns></returns>
        public static LocalDate AddMonths(this LocalDate ld, int months) => ld.PlusMonths(months);

        /// <summary>
        /// Add quarters
        /// </summary>
        /// <param name="ld"></param>
        /// <param name="quarters"></param>
        /// <returns></returns>
        public static LocalDate AddQuarters(this LocalDate ld, int quarters) => ld.PlusMonths(quarters * 3);

        /// <summary>
        /// Add years
        /// </summary>
        /// <param name="ld"></param>
        /// <param name="years"></param>
        /// <returns></returns>
        public static LocalDate AddYears(this LocalDate ld, int years) => ld.PlusYears(years);

        /// <summary>
        /// Add period
        /// </summary>
        /// <param name="ts"></param>
        /// <param name="period"></param>
        /// <returns></returns>
        public static LocalDate Add(this LocalDate ts, Period period) => ts.Plus(period);
    }
}