using System;
using Cosmos.Conversions;
using NodaTime;

namespace Cosmos.Date
{
    public enum DateTimeOffsetOptions
    {
        Absolute,
        Relatively
    }

    public enum DateTimeOffsetStyles
    {
        Week,
        Year,
        Quarters,
        Month,
        Day
    }

    internal static class DateTimeCalcHelper
    {
        public static int GetTargetDays(int year, int month, int weekAtMonth, int dayOfWeek)
        {
            var fd = DateTimeFactory.Create(year, month, 1);
            var daysNeeded = dayOfWeek - (int) fd.DayOfWeek;
            if (daysNeeded < 0) daysNeeded += 7;
            return (daysNeeded + 1) + (7 * (weekAtMonth - 1));
        }

        public static (int Year, int Month) Calc(int year, int month, int offsetMonths)
        {
            if (offsetMonths == 0) return (year, month);

            var z = offsetMonths > 0 ? 1 : -1;
            var offset = Math.Abs(offsetMonths);

            for (var i = 0; i < offset; i++)
            {
                if (z > 0 && month == 12)
                {
                    year++;
                    month = 1;
                }
                else if (z < 0 && month == 1)
                {
                    year--;
                    month = 12;
                }
                else
                {
                    month += 1 * z;
                }
            }

            return (year, month);
        }
    }

    public static class DateTimeCalc
    {
        #region Offset by Seconds

        /// <summary>
        /// Add seconds. <br />
        /// 添加一个季度。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static DateTime OffsetBySeconds(DateTime dt, int seconds)
        {
            return dt + seconds.Seconds();
        }

        #endregion

        #region Offset by Minutes

        /// <summary>
        /// Add minutes. <br />
        /// 添加一个季度。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="minutes"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static DateTime OffsetByMinutes(DateTime dt, int minutes)
        {
            return dt + minutes.Minutes();
        }

        #endregion

        #region Offset by Hours

        /// <summary>
        /// Add hours. <br />
        /// 添加一个季度。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="hours"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static DateTime OffsetByHours(DateTime dt, int hours)
        {
            return dt + hours.Hours();
        }

        #endregion

        #region Offset by Days

        /// <summary>
        /// Add days. <br />
        /// 添加一个季度。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="days"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static DateTime OffsetByDays(DateTime dt, int days)
        {
            return dt + days.Days();
        }

        #endregion

        #region Offset by Week

        /// <summary>
        /// Create <see cref="DateTime"/> by special year, month and offset info.<br />
        /// 根据指定的年月和偏移信息创建 <see cref="DateTime"/>
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="weekAtMonth"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateTime OffsetByWeek(int year, int month, int weekAtMonth, DayOfWeek dayOfWeek)
        {
            return OffsetByWeek(year, month, weekAtMonth, dayOfWeek.CastToInt(0));
        }

        /// <summary>
        /// Create <see cref="DateTime"/> by special year, month and offset info.<br />
        /// 根据指定的年月和偏移信息创建 <see cref="DateTime"/>
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="weekAtMonth"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateTime OffsetByWeek(int year, int month, int weekAtMonth, int dayOfWeek)
        {
            if (weekAtMonth == 0 || weekAtMonth > 5)
                throw new ArgumentException("weekAtMonth is invalid.", nameof(weekAtMonth));

            var targetDay = DateTimeCalcHelper.GetTargetDays(year, month, weekAtMonth, dayOfWeek);

            if (targetDay > DateTime.DaysInMonth(year, month))
                return DateTime.MinValue;

            return DateTimeFactory.Create(year, month, targetDay);
        }

        /// <summary>
        /// Create <see cref="DateTime"/> by special year, month and offset info.<br />
        /// 根据指定的年月和偏移信息创建 <see cref="DateTime"/>
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="weekAtMonth"></param>
        /// <param name="dayOfWeek"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static bool TryOffsetByWeek(int year, int month, int weekAtMonth, DayOfWeek dayOfWeek, out DateTime result)
        {
            return TryOffsetByWeek(year, month, weekAtMonth, dayOfWeek.CastToInt(0), out result);
        }

        /// <summary>
        /// Create <see cref="DateTime"/> by special year, month and offset info.<br />
        /// 根据指定的年月和偏移信息创建 <see cref="DateTime"/>
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="weekAtMonth"></param>
        /// <param name="dayOfWeek"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static bool TryOffsetByWeek(int year, int month, int weekAtMonth, int dayOfWeek, out DateTime result)
        {
            if (weekAtMonth == 0 || weekAtMonth > 5)
                throw new ArgumentException("weekAtMonth is invalid.", nameof(weekAtMonth));

            var targetDay = DateTimeCalcHelper.GetTargetDays(year, month, weekAtMonth, dayOfWeek);

            var invalid = targetDay > DateTime.DaysInMonth(year, month);
            result = invalid
                ? DateTime.MinValue
                : DateTimeFactory.Create(year, month, targetDay);

            return !invalid;
        }

        #endregion

        #region Offset by Week Before / After

        /// <summary>
        /// Add weeks. <br />
        /// 偏移一个星期。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="weeks"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static DateTime OffsetByWeeks(DateTime dt, int weeks)
        {
            return dt + weeks.Weeks();
        }

        /// <summary>
        /// Find the next weekday for example Monday before a special date.<br />
        /// 根据指定的日期，获得上一个工作日（如周一）
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateTime OffsetByWeekBefore(DateTime dt, DayOfWeek dayOfWeek)
        {
            var daysSubtract = (int) dayOfWeek - (int) dt.DayOfWeek;
            return (int) dayOfWeek < (int) dt.DayOfWeek
                ? dt.AddDays(daysSubtract)
                : dt.AddDays(daysSubtract - 7);
        }

        /// <summary>
        /// Find the next weekday for example Monday from a special date.<br />
        /// 根据指定的日期，获得下一个工作日（如周一）
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateTime OffsetByWeekAfter(DateTime dt, DayOfWeek dayOfWeek)
        {
            var daysNeeded = (int) dayOfWeek - (int) dt.DayOfWeek;
            return (int) dayOfWeek >= (int) dt.DayOfWeek
                ? dt.AddDays(daysNeeded)
                : dt.AddDays(daysNeeded + 7);
        }

        #endregion

        #region Offset by DayOfWeek

        public static DateTime OffsetByDayOfWeek(DateTime dt, DayOfWeek dayOfWeek, int weekOffset)
        {
            var z = weekOffset > 0 ? 1 : -1;
            var offset = DayOfWeekCalc.DaysBetween(dt.DayOfWeek, dayOfWeek);
            offset = offset == 0 ? 7 : offset;
            return dt.OffsetBy(offset * z * weekOffset, DateTimeOffsetStyles.Day);
        }

        #endregion

        #region Offset by Months

        /// <summary>
        /// Add quarters. <br />
        /// 添加一个季度。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="months"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static DateTime OffsetByMonths(DateTime dt, int months, DateTimeOffsetOptions options = DateTimeOffsetOptions.Absolute)
        {
            if (options == DateTimeOffsetOptions.Absolute)
                return dt + months.Months();

            var (year, month) = DateTimeCalcHelper.Calc(dt.Year, dt.Month, months);

            var firstDayOfMonth = dt.SetDate(year, month, 1);

            var lastDayOfMonth = firstDayOfMonth.LastDayOfMonth().Day;

            var day = dt.Day > lastDayOfMonth ? lastDayOfMonth : dt.Day;

            return dt.SetDate(year, month, day);
        }

        #endregion

        #region Offset by Quarters

        /// <summary>
        /// Add quarters. <br />
        /// 添加一个季度。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="quarters"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static DateTime OffsetByQuarters(DateTime dt, int quarters, DateTimeOffsetOptions options = DateTimeOffsetOptions.Absolute)
        {
            if (options == DateTimeOffsetOptions.Absolute)
                return dt + quarters.Quarters();
            return OffsetByMonths(dt, quarters * 3, DateTimeOffsetOptions.Relatively);
        }

        #endregion

        #region Offset by Years

        /// <summary>
        /// Add years. <br />
        /// 添加一个季度。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="years"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static DateTime OffsetByYears(DateTime dt, int years, DateTimeOffsetOptions options = DateTimeOffsetOptions.Absolute)
        {
            if (options == DateTimeOffsetOptions.Absolute)
                return dt + years.Years();
            return OffsetByMonths(dt, years * 12, DateTimeOffsetOptions.Relatively);
        }

        #endregion

        #region Offset by Duration

        /// <summary>
        /// Add duration. <br />
        /// 添加一段持续的时间
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static DateTime OffsetByDuration(DateTime dt, Duration duration)
        {
            return dt + duration.ToTimeSpan();
        }

        #endregion
    }
}