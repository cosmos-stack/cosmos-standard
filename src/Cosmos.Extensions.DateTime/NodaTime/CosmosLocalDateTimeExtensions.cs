using System;
using System.Globalization;
using Cosmos.Date;

namespace NodaTime
{
    /// <summary>
    /// Cosmos <see cref="LocalDateTime"/> extensions.
    /// </summary>
    public static class CosmosLocalDateTimeExtensions
    {
        #region Add

        /// <summary>
        /// Add nanoseconds
        /// </summary>
        /// <param name="lt"></param>
        /// <param name="nanoseconds"></param>
        /// <returns></returns>
        public static LocalDateTime AddNanoseconds(this LocalDateTime lt, long nanoseconds) => lt.PlusNanoseconds(nanoseconds);

        /// <summary>
        /// Add milliseconds
        /// </summary>
        /// <param name="lt"></param>
        /// <param name="milliseconds"></param>
        /// <returns></returns>
        public static LocalDateTime AddMilliseconds(this LocalDateTime lt, long milliseconds) => lt.PlusMilliseconds(milliseconds);

        /// <summary>
        /// Add seconds
        /// </summary>
        /// <param name="lt"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static LocalDateTime AddSeconds(this LocalDateTime lt, long seconds) => lt.PlusSeconds(seconds);

        /// <summary>
        /// Add minutes
        /// </summary>
        /// <param name="lt"></param>
        /// <param name="minutes"></param>
        /// <returns></returns>
        public static LocalDateTime AddMinutes(this LocalDateTime lt, long minutes) => lt.PlusMinutes(minutes);

        /// <summary>
        /// Add hours
        /// </summary>
        /// <param name="lt"></param>
        /// <param name="hours"></param>
        /// <returns></returns>
        public static LocalDateTime AddHours(this LocalDateTime lt, long hours) => lt.PlusHours(hours);

        /// <summary>
        /// Add days
        /// </summary>
        /// <param name="ld"></param>
        /// <param name="days"></param>
        /// <returns></returns>
        public static LocalDateTime AddDays(this LocalDateTime ld, int days) => ld.PlusDays(days);

        /// <summary>
        /// Add weeks
        /// </summary>
        /// <param name="ld"></param>
        /// <param name="weeks"></param>
        /// <returns></returns>
        public static LocalDateTime AddWeeks(this LocalDateTime ld, int weeks) => ld.PlusWeeks(weeks);

        /// <summary>
        /// Add months
        /// </summary>
        /// <param name="ld"></param>
        /// <param name="months"></param>
        /// <returns></returns>
        public static LocalDateTime AddMonths(this LocalDateTime ld, int months) => ld.PlusMonths(months);

        /// <summary>
        /// Add quarters
        /// </summary>
        /// <param name="ld"></param>
        /// <param name="quarters"></param>
        /// <returns></returns>
        public static LocalDateTime AddQuarters(this LocalDateTime ld, int quarters) => ld.PlusMonths(quarters * 3);

        /// <summary>
        /// Add years
        /// </summary>
        /// <param name="ld"></param>
        /// <param name="years"></param>
        /// <returns></returns>
        public static LocalDateTime AddYears(this LocalDateTime ld, int years) => ld.PlusYears(years);

        /// <summary>
        /// Add TimeSpan
        /// </summary>
        /// <param name="lt"></param>
        /// <param name="ts"></param>
        /// <returns></returns>
        public static LocalDateTime Add(this LocalDateTime lt, TimeSpan ts) => lt.PlusTicks(ts.Ticks);

        /// <summary>
        /// Add DateTimeSpan
        /// </summary>
        /// <param name="lt"></param>
        /// <param name="ts"></param>
        /// <returns></returns>
        public static LocalDateTime Add(this LocalDateTime lt, DateTimeSpan ts) => lt.PlusTicks(ts.Ticks);

        /// <summary>
        /// Add period
        /// </summary>
        /// <param name="ts"></param>
        /// <param name="period"></param>
        /// <returns></returns>
        public static LocalDateTime Add(this LocalDateTime ts, Period period) => ts.Plus(period);

        #endregion

        #region At

        /// <summary>
        /// At
        /// </summary>
        /// <param name="ldt"></param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static LocalDateTime At(this LocalDateTime ldt, int hour, int minute, int second) => ldt.SetTime(hour, minute, second);

        /// <summary>
        /// At
        /// </summary>
        /// <param name="ldt"></param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <param name="second"></param>
        /// <param name="milliseconds"></param>
        /// <returns></returns>
        public static LocalDateTime At(this LocalDateTime ldt, int hour, int minute, int second, int milliseconds) => ldt.SetTime(hour, minute, second, milliseconds);

        #endregion

        #region Begin

        /// <summary>
        /// Beginning of day
        /// </summary>
        /// <param name="ldt"></param>
        /// <returns></returns>
        public static LocalDateTime BeginningOfDay(this LocalDateTime ldt) =>
            new LocalDateTime(ldt.Year, ldt.Month, ldt.Day, 0, 0, 0, 0, ldt.Calendar);

        /// <summary>
        /// Beginning of day
        /// </summary>
        /// <param name="ldt"></param>
        /// <param name="timeZoneOffset"></param>
        /// <returns></returns>
        public static LocalDateTime BeginningOfDay(this LocalDateTime ldt, int timeZoneOffset) =>
            new LocalDateTime(ldt.Year, ldt.Month, ldt.Day, 0, 0, 0, 0, ldt.Calendar).AddHours(timeZoneOffset);

        /// <summary>
        /// Beginning of week
        /// </summary>
        /// <param name="ld"></param>
        /// <returns></returns>
        public static LocalDateTime BeginningOfWeek(this LocalDateTime ld) => ld.FirstDayOfWeek().BeginningOfDay();

        /// <summary>
        /// Beginning of week
        /// </summary>
        /// <param name="ld"></param>
        /// <param name="timeZoneOffset"></param>
        /// <returns></returns>
        public static LocalDateTime BeginningOfWeek(this LocalDateTime ld, int timeZoneOffset) => ld.FirstDayOfWeek().BeginningOfDay(timeZoneOffset);

        /// <summary>
        /// Beginning of month
        /// </summary>
        /// <param name="ld"></param>
        /// <returns></returns>
        public static LocalDateTime BeginningOfMonth(this LocalDateTime ld) => ld.FirstDayOfMonth().BeginningOfDay();

        /// <summary>
        /// Beginning of month
        /// </summary>
        /// <param name="ld"></param>
        /// <param name="timeZoneOffset"></param>
        /// <returns></returns>
        public static LocalDateTime BeginningOfMonth(this LocalDateTime ld, int timeZoneOffset) => ld.FirstDayOfMonth().BeginningOfDay(timeZoneOffset);

        /// <summary>
        /// Beginning of quarter
        /// </summary>
        /// <param name="ld"></param>
        /// <returns></returns>
        public static LocalDateTime BeginningOfQuarter(this LocalDateTime ld) => ld.FirstDayOfQuarter().BeginningOfDay();

        /// <summary>
        /// Beginning of quarter
        /// </summary>
        /// <param name="ld"></param>
        /// <param name="timeZoneOffset"></param>
        /// <returns></returns>
        public static LocalDateTime BeginningOfQuarter(this LocalDateTime ld, int timeZoneOffset) => ld.FirstDayOfQuarter().BeginningOfDay(timeZoneOffset);

        /// <summary>
        /// Beginning of year
        /// </summary>
        /// <param name="ld"></param>
        /// <returns></returns>
        public static LocalDateTime BeginningOfYear(this LocalDateTime ld) => ld.FirstDayOfYear().BeginningOfDay();

        /// <summary>
        /// Beginning of year
        /// </summary>
        /// <param name="ld"></param>
        /// <param name="timeZoneOffset"></param>
        /// <returns></returns>
        public static LocalDateTime BeginningOfYear(this LocalDateTime ld, int timeZoneOffset) => ld.FirstDayOfYear().BeginningOfDay(timeZoneOffset);

        #endregion

        #region End

        /// <summary>
        /// End of day
        /// </summary>
        /// <param name="ldt"></param>
        /// <returns></returns>
        public static LocalDateTime EndOfDay(this LocalDateTime ldt) =>
            new LocalDateTime(ldt.Year, ldt.Month, ldt.Day, 23, 59, 59, 999, ldt.Calendar);

        /// <summary>
        /// End of day (timezone-adjusted)
        /// </summary>
        /// <param name="ldt"></param>
        /// <param name="timeZoneOffset"></param>
        /// <returns></returns>
        public static LocalDateTime EndOfDay(this LocalDateTime ldt, int timeZoneOffset) =>
            new LocalDateTime(ldt.Year, ldt.Month, ldt.Day, 23, 59, 59, 999, ldt.Calendar).AddHours(timeZoneOffset);

        /// <summary>
        /// End of week
        /// </summary>
        /// <param name="ldt"></param>
        /// <returns></returns>
        public static LocalDateTime EndOfWeek(this LocalDateTime ldt) => ldt.LastDayOfWeek().EndOfDay();

        /// <summary>
        /// End of week
        /// </summary>
        /// <param name="ldt"></param>
        /// <param name="timeZoneOffset"></param>
        /// <returns></returns>
        public static LocalDateTime EndOfWeek(this LocalDateTime ldt, int timeZoneOffset) => ldt.LastDayOfWeek().EndOfDay(timeZoneOffset);

        /// <summary>
        /// End of month
        /// </summary>
        /// <param name="ldt"></param>
        /// <returns></returns>
        public static LocalDateTime EndOfMonth(this LocalDateTime ldt) => ldt.LastDayOfMonth().EndOfDay();

        /// <summary>
        /// End of month
        /// </summary>
        /// <param name="ldt"></param>
        /// <param name="timeZoneOffset"></param>
        /// <returns></returns>
        public static LocalDateTime EndOfMonth(this LocalDateTime ldt, int timeZoneOffset) => ldt.LastDayOfMonth().EndOfDay(timeZoneOffset);

        /// <summary>
        /// End of quarter
        /// </summary>
        /// <param name="ldt"></param>
        /// <returns></returns>
        public static LocalDateTime EndOfQuarter(this LocalDateTime ldt) => ldt.LastDayOfQuarter().EndOfDay();

        /// <summary>
        /// End of quarter
        /// </summary>
        /// <param name="ldt"></param>
        /// <param name="timeZoneOffset"></param>
        /// <returns></returns>
        public static LocalDateTime EndOfQuarter(this LocalDateTime ldt, int timeZoneOffset) => ldt.LastDayOfQuarter().EndOfDay(timeZoneOffset);

        /// <summary>
        /// End of year
        /// </summary>
        /// <param name="ldt"></param>
        /// <returns></returns>
        public static LocalDateTime EndOfYear(this LocalDateTime ldt) => ldt.LastDayOfYear().EndOfDay();

        /// <summary>
        /// End of year
        /// </summary>
        /// <param name="ldt"></param>
        /// <param name="timeZoneOffset"></param>
        /// <returns></returns>
        public static LocalDateTime EndOfYear(this LocalDateTime ldt, int timeZoneOffset) => ldt.LastDayOfYear().EndOfDay(timeZoneOffset);

        #endregion

        #region Get

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

        #endregion

        #region Previous and Next

        /// <summary>
        /// Next year
        /// </summary>
        /// <param name="ld"></param>
        /// <returns></returns>
        public static LocalDateTime NextYear(this LocalDateTime ld)
        {
            var year = ld.Year + 1;
            var daysOfMonth = DateTime.DaysInMonth(year, ld.Month);

            if (daysOfMonth == ld.Day)
                return new LocalDateTime(year, ld.Month, ld.Day, ld.Hour, ld.Minute, ld.Second, ld.Millisecond, ld.Calendar);

            var d = ld.Day - daysOfMonth;
            var p = new LocalDateTime(year, ld.Month, daysOfMonth, ld.Hour, ld.Minute, ld.Second, ld.Millisecond, ld.Calendar);
            return p.AddDays(d);
        }

        /// <summary>
        /// Previous Year
        /// </summary>
        /// <param name="ld"></param>
        /// <returns></returns>
        public static LocalDateTime PreviousYear(this LocalDateTime ld)
        {
            var year = ld.Year - 1;
            var daysOfMonth = DateTime.DaysInMonth(year, ld.Month);

            if (daysOfMonth == ld.Day)
                return new LocalDateTime(year, ld.Month, ld.Day, ld.Hour, ld.Minute, ld.Second, ld.Millisecond, ld.Calendar);

            var d = ld.Day - daysOfMonth;
            var p = new LocalDateTime(year, ld.Month, daysOfMonth, ld.Hour, ld.Minute, ld.Second, ld.Millisecond, ld.Calendar);
            return p.AddDays(d);
        }

        /// <summary>
        /// Gets next month
        /// </summary>
        /// <param name="ldt"></param>
        /// <returns></returns>
        public static LocalDateTime NextMonth(this LocalDateTime ldt)
        {
            var year = ldt.Month == 12 ? ldt.Year + 1 : ldt.Year;

            var month = ldt.Month == 12 ? 1 : ldt.Month + 1;

            var firstDayOfNextMonth = ldt.SetDate(year, month, 1);

            var lastDayOfPreviousMonth = firstDayOfNextMonth.LastDayOfMonth().Day;

            var day = ldt.Day > lastDayOfPreviousMonth ? lastDayOfPreviousMonth : ldt.Day;

            return firstDayOfNextMonth.SetDay(day);
        }

        /// <summary>
        /// Gets previous month
        /// </summary>
        /// <param name="ldt"></param>
        /// <returns></returns>
        public static LocalDateTime PreviousMonth(this LocalDateTime ldt)
        {
            var year = ldt.Month == 1 ? ldt.Year - 1 : ldt.Year;

            var month = ldt.Month == 1 ? 12 : ldt.Month - 1;

            var firstDayOfPreviousMonth = ldt.SetDate(year, month, 1);

            var lastDayOfPreviousMonth = firstDayOfPreviousMonth.LastDayOfMonth().Day;

            var day = ldt.Day > lastDayOfPreviousMonth ? lastDayOfPreviousMonth : ldt.Day;

            return firstDayOfPreviousMonth.SetDay(day);
        }

        /// <summary>
        /// Next day
        /// </summary>
        /// <param name="ldt"></param>
        /// <returns></returns>
        public static LocalDateTime NextDay(this LocalDateTime ldt) => ldt + 1.Days();

        /// <summary>
        /// Previous Day
        /// </summary>
        /// <param name="ldt"></param>
        /// <returns></returns>
        public static LocalDateTime PreviousDay(this LocalDateTime ldt) => ldt - 1.Days();

        /// <summary>
        /// Next
        /// </summary>
        /// <param name="ldt"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static LocalDateTime Next(this LocalDateTime ldt, DayOfWeek dayOfWeek)
        {
            do
            {
                ldt = ldt.NextDay();
            } while (ldt.DayOfWeek != dayOfWeek.AsIsoDayOfWeek());

            return ldt;
        }

        /// <summary>
        /// Previous
        /// </summary>
        /// <param name="ldt"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static LocalDateTime Previous(this LocalDateTime ldt, DayOfWeek dayOfWeek)
        {
            do
            {
                ldt = ldt.PreviousDay();
            } while (ldt.DayOfWeek != dayOfWeek.AsIsoDayOfWeek());

            return ldt;
        }

        /// <summary>
        /// Week after
        /// </summary>
        /// <param name="ldt"></param>
        /// <returns></returns>
        public static LocalDateTime WeekAfter(this LocalDateTime ldt) => ldt + 1.Weeks();

        /// <summary>
        /// Week before
        /// </summary>
        /// <param name="ldt"></param>
        /// <returns></returns>
        public static LocalDateTime WeekBefore(this LocalDateTime ldt) => ldt - 1.Weeks();

        /// <summary>
        /// Increase time
        /// </summary>
        /// <param name="ldt"></param>
        /// <param name="toAdd"></param>
        /// <returns></returns>
        public static LocalDateTime IncreaseTime(this LocalDateTime ldt, TimeSpan toAdd) => ldt.Add(toAdd);

        /// <summary>
        /// Decrease time
        /// </summary>
        /// <param name="ldt"></param>
        /// <param name="toSubtract"></param>
        /// <returns></returns>
        public static LocalDateTime DecreaseTime(this LocalDateTime ldt, TimeSpan toSubtract) => ldt.Add(-toSubtract);

        #endregion

        #region Set

        /// <summary>
        /// Set time
        /// </summary>
        /// <param name="ldt"></param>
        /// <param name="lt"></param>
        /// <returns></returns>
        public static LocalDateTime SetTime(this LocalDateTime ldt, LocalTime lt) =>
            ldt.SetTime(lt.Hour, lt.Minute, lt.Second, lt.Millisecond);

        /// <summary>
        /// Set time
        /// </summary>
        /// <param name="ldt"></param>
        /// <param name="hour"></param>
        /// <returns></returns>
        public static LocalDateTime SetTime(this LocalDateTime ldt, int hour) =>
            new LocalDateTime(ldt.Year, ldt.Month, ldt.Day, hour, ldt.Minute, ldt.Second, ldt.Millisecond, ldt.Calendar);

        /// <summary>
        /// Set time
        /// </summary>
        /// <param name="ldt"></param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <returns></returns>
        public static LocalDateTime SetTime(this LocalDateTime ldt, int hour, int minute) =>
            new LocalDateTime(ldt.Year, ldt.Month, ldt.Day, hour, minute, ldt.Second, ldt.Millisecond, ldt.Calendar);

        /// <summary>
        /// Set time
        /// </summary>
        /// <param name="ldt"></param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static LocalDateTime SetTime(this LocalDateTime ldt, int hour, int minute, int second) =>
            new LocalDateTime(ldt.Year, ldt.Month, ldt.Day, hour, minute, second, ldt.Millisecond, ldt.Calendar);

        /// <summary>
        /// Set time
        /// </summary>
        /// <param name="ldt"></param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <param name="second"></param>
        /// <param name="millisecond"></param>
        /// <returns></returns>
        public static LocalDateTime SetTime(this LocalDateTime ldt, int hour, int minute, int second, int millisecond) =>
            new LocalDateTime(ldt.Year, ldt.Month, ldt.Day, hour, minute, second, millisecond, ldt.Calendar);

        /// <summary>
        /// Set time
        /// </summary>
        /// <param name="ldt"></param>
        /// <param name="hour"></param>
        /// <returns></returns>
        public static LocalDateTime SetHour(this LocalDateTime ldt, int hour) =>
            new LocalDateTime(ldt.Year, ldt.Month, ldt.Day, hour, ldt.Minute, ldt.Second, ldt.Millisecond, ldt.Calendar);

        /// <summary>
        /// Set time
        /// </summary>
        /// <param name="ldt"></param>
        /// <param name="minute"></param>
        /// <returns></returns>
        public static LocalDateTime SetMinute(this LocalDateTime ldt, int minute) =>
            new LocalDateTime(ldt.Year, ldt.Month, ldt.Day, ldt.Hour, minute, ldt.Second, ldt.Millisecond, ldt.Calendar);

        /// <summary>
        /// Set time
        /// </summary>
        /// <param name="ldt"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static LocalDateTime SetSecond(this LocalDateTime ldt, int second) =>
            new LocalDateTime(ldt.Year, ldt.Month, ldt.Day, ldt.Hour, ldt.Minute, second, ldt.Millisecond, ldt.Calendar);

        /// <summary>
        /// Set time
        /// </summary>
        /// <param name="ldt"></param>
        /// <param name="millisecond"></param>
        /// <returns></returns>
        public static LocalDateTime SetMillisecond(this LocalDateTime ldt, int millisecond) =>
            new LocalDateTime(ldt.Year, ldt.Month, ldt.Day, ldt.Hour, ldt.Minute, ldt.Second, millisecond, ldt.Calendar);

        /// <summary>
        /// Midnight
        /// </summary>
        /// <param name="ldt"></param>
        /// <returns></returns>
        public static LocalDateTime Midnight(this LocalDateTime ldt) => ldt.BeginningOfDay();

        /// <summary>
        /// Noon
        /// </summary>
        /// <param name="ldt"></param>
        /// <returns></returns>
        public static LocalDateTime Noon(this LocalDateTime ldt) => ldt.SetTime(12, 0, 0, 0);

        /// <summary>
        /// Set date
        /// </summary>
        /// <param name="ldt"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public static LocalDateTime SetDate(this LocalDateTime ldt, int year) =>
            new LocalDateTime(year, ldt.Month, ldt.Day, ldt.Hour, ldt.Minute, ldt.Second, ldt.Millisecond, ldt.Calendar);

        /// <summary>
        /// Set date
        /// </summary>
        /// <param name="ldt"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public static LocalDateTime SetDate(this LocalDateTime ldt, int year, int month) =>
            new LocalDateTime(year, month, ldt.Day, ldt.Hour, ldt.Minute, ldt.Second, ldt.Millisecond, ldt.Calendar);

        /// <summary>
        /// Set date
        /// </summary>
        /// <param name="ldt"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public static LocalDateTime SetDate(this LocalDateTime ldt, int year, int month, int day) =>
            new LocalDateTime(year, month, day, ldt.Hour, ldt.Minute, ldt.Second, ldt.Millisecond, ldt.Calendar);

        /// <summary>
        /// Set date
        /// </summary>
        /// <param name="ldt"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public static LocalDateTime SetYear(this LocalDateTime ldt, int year) =>
            new LocalDateTime(year, ldt.Month, ldt.Day, ldt.Hour, ldt.Minute, ldt.Second, ldt.Millisecond, ldt.Calendar);

        /// <summary>
        /// Set date
        /// </summary>
        /// <param name="ldt"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public static LocalDateTime SetMonth(this LocalDateTime ldt, int month) =>
            new LocalDateTime(ldt.Year, month, ldt.Day, ldt.Hour, ldt.Minute, ldt.Second, ldt.Millisecond, ldt.Calendar);

        /// <summary>
        /// Set date
        /// </summary>
        /// <param name="ldt"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public static LocalDateTime SetDay(this LocalDateTime ldt, int day) =>
            new LocalDateTime(ldt.Year, ldt.Month, day, ldt.Hour, ldt.Minute, ldt.Second, ldt.Millisecond, ldt.Calendar);

        #endregion

        #region To

        /// <summary>
        /// To DateTime
        /// </summary>
        /// <param name="ldt"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this LocalDateTime ldt) => ldt.ToDateTimeUnspecified();

        /// <summary>
        /// To Datetime
        /// </summary>
        /// <param name="ldt"></param>
        /// <param name="kind"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this LocalDateTime ldt, DateTimeKind kind) => ldt.ToDateTimeUnspecified().SetKind(kind);

        /// <summary>
        /// To DateInfo
        /// </summary>
        /// <param name="ldt"></param>
        /// <returns></returns>
        public static DateInfo ToDateInfo(this LocalDateTime ldt) => new DateInfo(ldt.Year, ldt.Month, ldt.Day);

        /// <summary>
        /// To LocalDate
        /// </summary>
        /// <param name="ldt"></param>
        /// <returns></returns>
        public static LocalDate ToLocalDate(this LocalDateTime ldt) => new LocalDate(ldt.Year, ldt.Month, ldt.Day, ldt.Calendar);

        /// <summary>
        /// To LocalTime
        /// </summary>
        /// <param name="ldt"></param>
        /// <returns></returns>
        public static LocalTime ToLocalTime(this LocalDateTime ldt) => new LocalTime(ldt.Hour, ldt.Minute, ldt.Second, ldt.Millisecond);

        #endregion
    }
}