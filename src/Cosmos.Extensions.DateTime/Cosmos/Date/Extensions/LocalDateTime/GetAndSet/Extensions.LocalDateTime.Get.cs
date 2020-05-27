using System.Globalization;
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
        /// Gets first day of year
        /// </summary>
        /// <param name="ldt"></param>
        /// <returns></returns>
        public static LocalDateTime FirstDayOfYear(this LocalDateTime ldt) => ldt.SetDate(ldt.Year, 1, 1);

        /// <summary>
        /// Gets first day of quarter
        /// </summary>
        /// <param name="ldt"></param>
        /// <returns></returns>
        public static LocalDateTime FirstDayOfQuarter(this LocalDateTime ldt)
        {
            var currentQuarter = (ldt.Month - 1) / 3 + 1;
            var firstDay = new LocalDateTime(ldt.Year, 3 * currentQuarter - 2, 1, ldt.Hour, ldt.Minute);

            return ldt.SetDate(firstDay.Year, firstDay.Month, firstDay.Day);
        }

        /// <summary>
        /// Gets first day of month
        /// </summary>
        /// <param name="ldt"></param>
        /// <returns></returns>
        public static LocalDateTime FirstDayOfMonth(this LocalDateTime ldt) => ldt.SetDay(1);

        /// <summary>
        /// First day of week
        /// </summary>
        /// <param name="ldt"></param>
        /// <returns></returns>
        public static LocalDateTime FirstDayOfWeek(this LocalDateTime ldt)
        {
            var currentCulture = CultureInfo.CurrentCulture;
            var firstDayOfWeek = (int) currentCulture.DateTimeFormat.FirstDayOfWeek;

            var currentDayOfWeek = (int) ldt.DayOfWeek;

            var offset = currentDayOfWeek - firstDayOfWeek < 0 ? 7 : 0;
            var numberOfDaysSinceBeginningOfTheWeek = currentDayOfWeek + offset - firstDayOfWeek;

            return ldt.AddDays(-numberOfDaysSinceBeginningOfTheWeek);
        }

        /// <summary>
        /// Gets last day of year
        /// </summary>
        /// <param name="ldt"></param>
        /// <returns></returns>
        public static LocalDateTime LastDayOfYear(this LocalDateTime ldt) => ldt.SetDate(ldt.Year, 12, 31);

        /// <summary>
        /// Gets last day of quarter
        /// </summary>
        /// <param name="ldt"></param>
        /// <returns></returns>
        public static LocalDateTime LastDayOfQuarter(this LocalDateTime ldt)
        {
            var currentQuarter = (ldt.Month - 1) / 3 + 1;
            var firstDay = ldt.SetDate(ldt.Year, 3 * currentQuarter - 2, 1);
            return firstDay.SetMonth(firstDay.Month + 2).LastDayOfMonth();
        }

        /// <summary>
        /// Gets last day of month
        /// </summary>
        /// <param name="ldt"></param>
        /// <returns></returns>
        public static LocalDateTime LastDayOfMonth(this LocalDateTime ldt) => ldt.SetDay(ldt.Calendar.GetDaysInMonth(ldt.Year, ldt.Month));

        /// <summary>
        /// Gets last day of week
        /// </summary>
        /// <param name="ldt"></param>
        /// <returns></returns>
        public static LocalDateTime LastDayOfWeek(this LocalDateTime ldt) => ldt.FirstDayOfWeek().AddDays(6);
    }
}