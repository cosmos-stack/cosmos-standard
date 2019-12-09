using System;
using System.Globalization;

// ReSharper disable once CheckNamespace
namespace Cosmos {
    /// <summary>
    /// DateTimeOffset Extensions<br />
    /// DateTimeOffset 扩展方法
    /// </summary>
    public static partial class DateTimeOffsetExtensions {
        /// <summary>
        /// First day of year
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static DateTimeOffset FirstDayOfYear(this DateTimeOffset dto) {
            return dto.SetDate(dto.Year, 1, 1);
        }

        /// <summary>
        /// First day of quarter
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static DateTimeOffset FirstDayOfQuarter(this DateTimeOffset dto) {
            var currentQuarter = (dto.Month - 1) / 3 + 1;
            return dto.SetDate(dto.Year, 3 * currentQuarter - 2, 1);
        }

        /// <summary>
        /// First day of month
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static DateTimeOffset FirstDayOfMonth(this DateTimeOffset dto) {
            return dto.SetDay(1);
        }

        /// <summary>
        /// First day of week
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static DateTimeOffset FirstDayOfWeek(this DateTimeOffset dto) {
            var currentCulture = CultureInfo.CurrentCulture;
            var firstDayOfWeek = currentCulture.DateTimeFormat.FirstDayOfWeek;
            var offset = dto.DayOfWeek - firstDayOfWeek < 0 ? 7 : 0;
            var numberOfDaysSinceBeginningOfTheWeek = dto.DayOfWeek + offset - firstDayOfWeek;

            return dto.AddDays(-numberOfDaysSinceBeginningOfTheWeek);
        }

        /// <summary>
        /// Last day of year
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static DateTimeOffset LastDayOfYear(this DateTimeOffset dto) {
            return dto.SetDate(dto.Year, 12, 31);
        }

        /// <summary>
        /// Last day of quarter
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static DateTimeOffset LastDayOfQuarter(this DateTimeOffset dto) {
            var currentQuarter = (dto.Month - 1) / 3 + 1;
            var firstDay = dto.SetDate(dto.Year, 3 * currentQuarter - 2, 1);
            return firstDay.SetMonth(firstDay.Month + 2).LastDayOfMonth();
        }

        /// <summary>
        /// Last day of month
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static DateTimeOffset LastDayOfMonth(this DateTimeOffset dto) {
            return dto.SetDay(DateTime.DaysInMonth(dto.Year, dto.Month));
        }

        /// <summary>
        /// Last day of week
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static DateTimeOffset LastDayOfWeek(this DateTimeOffset dto) {
            return dto.FirstDayOfWeek().AddDays(6);
        }

        /// <summary>
        /// Gets week after
        /// </summary>
        /// <param name="start"></param>
        /// <returns></returns>
        public static DateTimeOffset WeekAfter(this DateTimeOffset start) {
            return start + 1.Weeks();
        }

        /// <summary>
        /// Gets week before
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static DateTimeOffset WeekBefore(this DateTimeOffset dto) {
            return dto - 1.Weeks();
        }

        /// <summary>
        /// Midnight
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static DateTimeOffset Midnight(this DateTimeOffset dto) {
            return dto.BeginningOfDay();
        }

        /// <summary>
        /// Noon
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static DateTimeOffset Noon(this DateTimeOffset dto) {
            return dto.SetTime(12, 0, 0, 0);
        }
    }
}