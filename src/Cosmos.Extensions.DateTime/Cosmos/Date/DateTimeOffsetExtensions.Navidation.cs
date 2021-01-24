using System;
using System.Globalization;

namespace Cosmos.Date
{
    public static partial class DateTimeOffsetExtensions
    {
        #region Begin

        /// <summary>
        /// Beginning of day
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static DateTimeOffset BeginningOfDay(this DateTimeOffset dto)
        {
            return new DateTimeOffset(dto.Year, dto.Month, dto.Day, 0, 0, 0, dto.Offset);
        }

        #endregion

        #region End

        /// <summary>
        /// End of day
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static DateTimeOffset EndOfDay(this DateTimeOffset dto)
        {
            return new DateTimeOffset(dto.Year, dto.Month, dto.Day, 23, 59, 59, 999, dto.Offset);
        }

        #endregion

        #region Get

        /// <summary>
        /// First day of year
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static DateTimeOffset FirstDayOfYear(this DateTimeOffset dto)
        {
            return dto.SetDate(dto.Year, 1, 1);
        }

        /// <summary>
        /// First day of quarter
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static DateTimeOffset FirstDayOfQuarter(this DateTimeOffset dto)
        {
            var currentQuarter = (dto.Month - 1) / 3 + 1;
            return dto.SetDate(dto.Year, 3 * currentQuarter - 2, 1);
        }

        /// <summary>
        /// First day of month
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static DateTimeOffset FirstDayOfMonth(this DateTimeOffset dto)
        {
            return dto.SetDay(1);
        }

        /// <summary>
        /// First day of week
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static DateTimeOffset FirstDayOfWeek(this DateTimeOffset dto)
        {
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
        public static DateTimeOffset LastDayOfYear(this DateTimeOffset dto)
        {
            return dto.SetDate(dto.Year, 12, 31);
        }

        /// <summary>
        /// Last day of quarter
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static DateTimeOffset LastDayOfQuarter(this DateTimeOffset dto)
        {
            var currentQuarter = (dto.Month - 1) / 3 + 1;
            var firstDay = dto.SetDate(dto.Year, 3 * currentQuarter - 2, 1);
            return firstDay.SetMonth(firstDay.Month + 2).LastDayOfMonth();
        }

        /// <summary>
        /// Last day of month
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static DateTimeOffset LastDayOfMonth(this DateTimeOffset dto)
        {
            return dto.SetDay(DateTime.DaysInMonth(dto.Year, dto.Month));
        }

        /// <summary>
        /// Last day of week
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static DateTimeOffset LastDayOfWeek(this DateTimeOffset dto)
        {
            return dto.FirstDayOfWeek().AddDays(6);
        }

        /// <summary>
        /// Gets week after
        /// </summary>
        /// <param name="start"></param>
        /// <returns></returns>
        public static DateTimeOffset WeekAfter(this DateTimeOffset start)
        {
            return start + 1.Weeks();
        }

        /// <summary>
        /// Gets week before
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static DateTimeOffset WeekBefore(this DateTimeOffset dto)
        {
            return dto - 1.Weeks();
        }

        /// <summary>
        /// Midnight
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static DateTimeOffset Midnight(this DateTimeOffset dto)
        {
            return dto.BeginningOfDay();
        }

        /// <summary>
        /// Noon
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static DateTimeOffset Noon(this DateTimeOffset dto)
        {
            return dto.SetTime(12, 0, 0, 0);
        }

        #endregion

        #region Navigation

        /// <summary>
        /// Next year
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static DateTimeOffset NextYear(this DateTimeOffset dto) => dto.ToLocalDateTime().NextYear();

        /// <summary>
        /// Previous year
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static DateTimeOffset PreviousYear(this DateTimeOffset dto) => dto.ToLocalDateTime().PreviousYear();

        /// <summary>
        /// Gets next quarter
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static DateTimeOffset NextQuarter(this DateTimeOffset dto) => dto.ToLocalDateTime().NextQuarter();

        /// <summary>
        /// Gets previous quarter
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static DateTimeOffset PreviousQuarter(this DateTimeOffset dto) => dto.ToLocalDateTime().PreviousQuarter();

        /// <summary>
        /// Next month
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static DateTimeOffset NextMonth(this DateTimeOffset dto) => dto.ToLocalDateTime().NextMonth();

        /// <summary>
        /// Previous month
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static DateTimeOffset PreviousMonth(this DateTimeOffset dto) => dto.ToLocalDateTime().PreviousMonth();

        /// <summary>
        /// Next week
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static DateTimeOffset NextWeek(this DateTimeOffset dto) => dto.ToLocalDateTime().NextWeek();

        /// <summary>
        /// Previous week
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static DateTimeOffset PreviousWeek(this DateTimeOffset dto) => dto.ToLocalDateTime().PreviousWeek();
        
        /// <summary>
        /// Next day
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static DateTimeOffset NextDay(this DateTimeOffset dto) => dto.ToLocalDateTime().NextDay();

        /// <summary>
        /// Previous day
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static DateTimeOffset PreviousDay(this DateTimeOffset dto) => dto.ToLocalDateTime().PreviousDay();

        /// <summary>
        /// Tomorrow
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static DateTimeOffset Tomorrow(this DateTimeOffset dto) => dto.NextDay();

        /// <summary>
        /// Yesterday
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static DateTimeOffset Yesterday(this DateTimeOffset dto) => dto.PreviousDay();
        
        /// <summary>
        /// Next
        /// </summary>
        /// <param name="start"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateTimeOffset NextDayOfWeek(this DateTimeOffset start, DayOfWeek dayOfWeek) => DateTimeCalc.OffsetByDayOfWeek(start.ToLocalDateTime(), dayOfWeek, 1);

        /// <summary>
        /// Previous
        /// </summary>
        /// <param name="start"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateTimeOffset PreviousDayOfWeek(this DateTimeOffset start, DayOfWeek dayOfWeek) => DateTimeCalc.OffsetByDayOfWeek(start.ToLocalDateTime(), dayOfWeek, -1);

        #endregion
    }
}