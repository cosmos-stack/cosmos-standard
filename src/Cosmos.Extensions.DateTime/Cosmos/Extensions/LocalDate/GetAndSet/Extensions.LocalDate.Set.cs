using NodaTime;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    /// <summary>
    /// LocalDate extensions
    /// </summary>
    public static partial class LocalDateExtensions
    {
        /// <summary>
        /// Set date
        /// </summary>
        /// <param name="ld"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public static LocalDate SetDate(this LocalDate ld, int year) =>
            new LocalDate(ld.Era, year, ld.Month, ld.Day, ld.Calendar);

        /// <summary>
        /// Set date
        /// </summary>
        /// <param name="ld"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public static LocalDate SetDate(this LocalDate ld, int year, int month) =>
            new LocalDate(ld.Era, year, month, ld.Day, ld.Calendar);

        /// <summary>
        /// Set date
        /// </summary>
        /// <param name="ld"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public static LocalDate SetDate(this LocalDate ld, int year, int month, int day) =>
            new LocalDate(ld.Era, year, month, day, ld.Calendar);

        /// <summary>
        /// Set date
        /// </summary>
        /// <param name="ld"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public static LocalDate SetYear(this LocalDate ld, int year) =>
            new LocalDate(ld.Era, year, ld.Month, ld.Day, ld.Calendar);

        /// <summary>
        /// Set date
        /// </summary>
        /// <param name="ld"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public static LocalDate SetMonth(this LocalDate ld, int month) =>
            DateAdjusters.Month(month)(ld);

        /// <summary>
        /// Set date
        /// </summary>
        /// <param name="ld"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public static LocalDate SetDay(this LocalDate ld, int day) =>
            DateAdjusters.DayOfMonth(day)(ld);
    }
}