using System.Globalization;
using NodaTime;

// ReSharper disable once CheckNamespace
namespace Cosmos {
    /// <summary>
    /// LocalDate extensions
    /// </summary>
    public static partial class LocalDateExtensions {
        /// <summary>
        /// Gets first day of year
        /// </summary>
        /// <param name="ld"></param>
        /// <returns></returns>
        public static LocalDate FirstDayOfYear(this LocalDate ld) => ld.SetDate(ld.Year, 1, 1);

        /// <summary>
        /// Gets first day of quarter
        /// </summary>
        /// <param name="ld"></param>
        /// <returns></returns>
        public static LocalDate FirstDayOfQuarter(this LocalDate ld) {
            var currentQuarter = (ld.Month - 1) / 3 + 1;
            var firstDay = new LocalDate(ld.Year, 3 * currentQuarter - 2, 1);

            return ld.SetDate(firstDay.Year, firstDay.Month, firstDay.Day);
        }

        /// <summary>
        /// Gets first day of month
        /// </summary>
        /// <param name="ld"></param>
        /// <returns></returns>
        public static LocalDate FirstDayOfMonth(this LocalDate ld) => ld.SetDay(1);

        /// <summary>
        /// First day of week
        /// </summary>
        /// <param name="ld"></param>
        /// <returns></returns>
        public static LocalDate FirstDayOfWeek(this LocalDate ld) {
            var currentCulture = CultureInfo.CurrentCulture;
            var firstDayOfWeek = (int) currentCulture.DateTimeFormat.FirstDayOfWeek;

            var currentDayOfWeek = (int) ld.DayOfWeek;

            var offset = currentDayOfWeek - firstDayOfWeek < 0 ? 7 : 0;
            var numberOfDaysSinceBeginningOfTheWeek = currentDayOfWeek + offset - firstDayOfWeek;

            return ld.AddDays(-numberOfDaysSinceBeginningOfTheWeek);
        }

        /// <summary>
        /// Gets last day of year
        /// </summary>
        /// <param name="ld"></param>
        /// <returns></returns>
        public static LocalDate LastDayOfYear(this LocalDate ld) => ld.SetDate(ld.Year, 12, 31);

        /// <summary>
        /// Gets last day of quarter
        /// </summary>
        /// <param name="ld"></param>
        /// <returns></returns>
        public static LocalDate LastDayOfQuarter(this LocalDate ld) {
            var currentQuarter = (ld.Month - 1) / 3 + 1;
            var firstDay = ld.SetDate(ld.Year, 3 * currentQuarter - 2, 1);
            return firstDay.SetMonth(firstDay.Month + 2).LastDayOfMonth();
        }

        /// <summary>
        /// Gets last day of month
        /// </summary>
        /// <param name="ld"></param>
        /// <returns></returns>
        public static LocalDate LastDayOfMonth(this LocalDate ld) => ld.SetDay(ld.Calendar.GetDaysInMonth(ld.Year, ld.Month));

        /// <summary>
        /// Gets last day of week
        /// </summary>
        /// <param name="ld"></param>
        /// <returns></returns>
        public static LocalDate LastDayOfWeek(this LocalDate ld) => ld.FirstDayOfWeek().AddDays(6);
    }
}