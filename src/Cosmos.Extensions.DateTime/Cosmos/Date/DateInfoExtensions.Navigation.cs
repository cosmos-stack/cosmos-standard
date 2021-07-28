using System;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Cosmos.Date
{
    /// <summary>
    /// Cosmos <see cref="DateInfo"/> extensions.
    /// </summary>
    public static partial class DateInfoExtensions
    {
        #region Offset

        public static DateInfo OffsetBy(this DateInfo dt, int offsetVal, DateTimeOffsetStyles styles)
        {
            return styles switch
            {
                DateTimeOffsetStyles.Day => DateInfoCalc.OffsetByDays(dt, offsetVal),
                DateTimeOffsetStyles.Week => DateInfoCalc.OffsetByWeeks(dt, offsetVal),
                DateTimeOffsetStyles.Month => DateInfoCalc.OffsetByMonths(dt, offsetVal, DateTimeOffsetOptions.Relatively),
                DateTimeOffsetStyles.Quarters => DateInfoCalc.OffsetByQuarters(dt, offsetVal, DateTimeOffsetOptions.Relatively),
                DateTimeOffsetStyles.Year => DateInfoCalc.OffsetByYears(dt, offsetVal, DateTimeOffsetOptions.Relatively),
                _ => DateInfoCalc.OffsetByDays(dt, offsetVal)
            };
        }

        #endregion

        #region Begin

        /// <summary>
        /// Beginning of week, same as 'GetFirstDayInfoOfWeek'. <br />
        /// 一周的开始日期，等价于 'GetFirstDayInfoOfWeek'。
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateInfo BeginningOfWeek(this DateInfo d) => d.FirstDayOfWeek();

        /// <summary>
        /// Beginning of month, same as 'GetLastDayInfoOfMonth'. <br />
        /// 一个月的开始日期，等价于 'GetLastDayInfoOfMonth'。
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateInfo BeginningOfMonth(this DateInfo d) => d.FirstDayOfMonth();

        /// <summary>
        /// Beginning of quarter, same as 'GetFirstDayInfoOfQuarter'. <br />
        /// 一个季度的开始日期，等价于 'GetFirstDayInfoOfQuarter'。
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateInfo BeginningOfQuarter(this DateInfo d) => d.FirstDayOfQuarter();

        /// <summary>
        /// Beginning of year, same as 'GetFirstDayInfoOfYear'. <br />
        /// 一年的开始日期，等价于 'GetFirstDayInfoOfYear'。
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateInfo BeginningOfYear(this DateInfo d) => d.FirstDayOfYear();

        #endregion

        #region End

        /// <summary>
        /// End of week, same as 'GetLastDayInfoOfWeek'. <br />
        /// 一周的结束日期，等价于 'GetLastDayInfoOfWeek'。
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateInfo EndOfWeek(this DateInfo d) => d.LastDayOfWeek();

        /// <summary>
        /// End of month, same as 'GetLastDayInfoOfMonth'. <br />
        /// 一个月份的结束日期，等价于 'GetLastDayInfoOfMonth'。
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateInfo EndOfMonth(this DateInfo d) => d.LastDayOfMonth();

        /// <summary>
        /// End of quarter, same as 'GetLastDayInfoOfQuarter'. <br />
        /// 一个季度的结束日期，等价于 'GetLastDayInfoOfQuarter'。
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateInfo EndOfQuarter(this DateInfo d) => d.LastDayOfQuarter();

        /// <summary>
        /// End of year, same as 'GetLastDayOfYear'. <br />
        /// 一年的结束日期，等价于 'GetLastDayOfYear'。
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateInfo EndOfYear(this DateInfo d) => d.LastDayOfYear();

        #endregion

        #region Get

        /// <summary>
        /// Get first day of this year. <br />
        /// 获取本年度的第一天。
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateInfo FirstDayOfYear(this DateInfo d) => new(d.Year, 1, 1);

        /// <summary>
        /// Get first day of this year. <br />
        /// 获取本年度的第一天。
        /// </summary>
        /// <param name="d"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateInfo FirstDayOfYear(this DateInfo d, DayOfWeek dayOfWeek)
        {
            var ret = d.FirstDayOfYear();
            return DayOfWeekCalc.TryDaysBetween(ret.DayOfWeek, dayOfWeek, out var day) && day > 0
                ? ret.AddDays(day)
                : ret;
        }

        /// <summary>
        /// Get first day of this quarter. <br />
        /// 获取本季度的第一天。
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateInfo FirstDayOfQuarter(this DateInfo d)
        {
            var currentQuarter = d.QuarterOfMonth();
            var month = 3 * currentQuarter - 2;
            return DateInfoFactory.Create(d.Year, month, 1);
        }

        /// <summary>
        /// Get first day of this quarter. <br />
        /// 获取本季度的第一天。
        /// </summary>
        /// <param name="d"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateInfo FirstDayOfQuarter(this DateInfo d, DayOfWeek dayOfWeek)
        {
            var ret = d.FirstDayOfQuarter();
            return DayOfWeekCalc.TryDaysBetween(ret.DayOfWeek, dayOfWeek, out var day) && day > 0
                ? ret.AddDays(day)
                : ret;
        }

        /// <summary>
        /// Get first day of this month. <br />
        /// 获取本月份的第一天。
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateInfo FirstDayOfMonth(this DateInfo dt) => new(dt.Year, dt.Month, 1);

        /// <summary>
        /// Get first day of (the week of) this month. <br />
        /// 获取本月份第一周的第一天。
        /// </summary>
        /// <param name="d"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateInfo FirstDayOfMonth(this DateInfo d, DayOfWeek dayOfWeek)
        {
            var ret = d.FirstDayOfMonth();
            return DayOfWeekCalc.TryDaysBetween(ret.DayOfWeek, dayOfWeek, out var day) && day > 0
                ? ret.AddDays(day)
                : ret;
        }

        /// <summary>
        /// Get first day of this week. <br />
        /// 获取本周的第一天。
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateInfo FirstDayOfWeek(this DateInfo d) => d.FirstDayOfWeek(null);

        /// <summary>
        /// Get first day of this week. <br />
        /// 获取本周的第一天。
        /// </summary>
        /// <param name="d"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public static DateInfo FirstDayOfWeek(this DateInfo d, CultureInfo cultureInfo)
        {
            cultureInfo ??= CultureInfo.CurrentCulture;
            var firstDayOfWeek = cultureInfo.DateTimeFormat.FirstDayOfWeek;
            var offset = d.DayOfWeek - firstDayOfWeek < 0 ? 7 : 0;
            var numberOfDaysSinceBeginningOfTheWeek = d.DayOfWeek + offset - firstDayOfWeek;

            return d.AddDays(-numberOfDaysSinceBeginningOfTheWeek);
        }

        /// <summary>
        /// Get last day info of year. <br />
        /// 获取本年度的最后一天。
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateInfo LastDayOfYear(this DateInfo d) => DateInfoFactory.Create(d.Year, 12, 31);

        /// <summary>
        /// Get last day info of year. <br />
        /// 获取本年度的最后一天。
        /// </summary>
        /// <param name="d"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateInfo LastDayOfYear(this DateInfo d, DayOfWeek dayOfWeek)
        {
            var ret = d.LastDayOfYear();
            return DayOfWeekCalc.TryDaysBetween(ret.DayOfWeek, dayOfWeek, out var day) && day == 0
                ? ret
                : ret.AddDays(-day);
        }

        /// <summary>
        /// Gets last day info of quarter. <br />
        /// 获取本季节的最后一天。
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateInfo LastDayOfQuarter(this DateInfo d)
        {
            var currentQuarter = d.QuarterOfMonth();
            var month = 3 * currentQuarter;
            var day = DateInfo.DaysInMonth(d.Year, month);
            return DateInfoFactory.Create(d.Year, month, day);
        }

        /// <summary>
        /// Gets last day info of quarter. <br />
        /// 获取本季节的最后一天。
        /// </summary>
        /// <param name="d"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateInfo LastDayOfQuarter(this DateInfo d, DayOfWeek dayOfWeek)
        {
            var ret = d.LastDayOfQuarter();
            return DayOfWeekCalc.TryDaysBetween(ret.DayOfWeek, dayOfWeek, out var day) && day == 0
                ? ret
                : ret.AddDays(-day);
        }

        /// <summary>
        /// Get last day of this month. <br />
        /// 获取本月份的最后一天。
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateInfo LastDayOfMonth(this DateInfo dt) => dt.Clone().SetDay(dt.DaysInMonth());

        /// <summary>
        /// Get last day (of week) of this month. <br />
        /// 获取本月份最后一周的最后一天。
        /// </summary>
        /// <param name="d"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateInfo LastDayOfMonth(this DateInfo d, DayOfWeek dayOfWeek)
        {
            var ret = d.LastDayOfMonth();
            return DayOfWeekCalc.TryDaysBetween(ret.DayOfWeek, dayOfWeek, out var day) && day == 0
                ? ret
                : ret.AddDays(-day);
        }

        /// <summary>
        /// Get last day of this week. <br />
        /// 获取本周的最后一天。
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateInfo LastDayOfWeek(this DateInfo d) => d.LastDayOfWeek(null);

        /// <summary>
        /// Get last day of this week. <br />
        /// 获取本周的最后一天。
        /// </summary>
        /// <param name="d"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateInfo LastDayOfWeek(this DateInfo d, CultureInfo cultureInfo) => d.FirstDayOfWeek(cultureInfo).AddDays(6);
        
        /// <summary>
        /// Get the specified week is the week of the year.<br />
        /// 获取指定的星期是一年中的第几个星期。
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetWeekOfYear(this DateInfo d)
            => GetWeekOfYear(d, new DateTimeFormatInfo().CalendarWeekRule, new DateTimeFormatInfo().FirstDayOfWeek);

        /// <summary>
        /// Get the specified week is the week of the year.<br />
        /// 获取指定的星期是一年中的第几个星期。
        /// </summary>
        /// <param name="d"></param>
        /// <param name="weekRule"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetWeekOfYear(this DateInfo d, CalendarWeekRule weekRule)
            => GetWeekOfYear(d, weekRule, new DateTimeFormatInfo().FirstDayOfWeek);

        /// <summary>
        /// Get the specified week is the week of the year.<br />
        /// 获取指定的星期是一年中的第几个星期。
        /// </summary>
        /// <param name="d"></param>
        /// <param name="firstDayOfWeek"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetWeekOfYear(this DateInfo d, DayOfWeek firstDayOfWeek)
            => GetWeekOfYear(d, new DateTimeFormatInfo().CalendarWeekRule, firstDayOfWeek);

        /// <summary>
        /// Get the specified week is the week of the year.<br />
        /// 获取指定的星期是一年中的第几个星期。
        /// </summary>
        /// <param name="d"></param>
        /// <param name="weekRule"></param>
        /// <param name="firstDayOfWeek"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetWeekOfYear(this DateInfo d, CalendarWeekRule weekRule, DayOfWeek firstDayOfWeek)
            => CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(d.DateTimeRef, weekRule, firstDayOfWeek);

        /// <summary>
        /// Get the days' count of the specified month.<br />
        /// 获取指定月份是总天数。
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int DaysInMonth(this DateInfo d) => DateInfo.DaysInMonth(d.Year, d.Month);

        /// <summary>
        /// Get the days' count of the specified year.<br />
        /// 获取指定月份是总天数。
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int DaysInYear(this DateInfo d) => DateInfo.DaysInYear(d.Year);

        /// <summary>
        /// Get the quarter of the specified month.<br />
        /// 获取指定月份是第几季度。
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int QuarterOfMonth(this DateInfo dt) => (dt.Month - 1) / 3 + 1;

        #endregion

        #region Navigation

        /// <summary>
        /// According to the specified time, get the day of the next year.<br />
        /// 根据指定的时间，获取下一年的当天。
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateInfo NextYear(this DateInfo d) => d.OffsetBy(1, DateTimeOffsetStyles.Year);

        /// <summary>
        /// According to the specified time, get the day of the previous year.<br />
        /// 根据指定的时间，获取上一年的当天。
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateInfo PreviousYear(this DateInfo d) => d.OffsetBy(-1, DateTimeOffsetStyles.Year);

        /// <summary>
        /// Gets next quarter
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateInfo NextQuarter(this DateInfo dt) => dt.OffsetBy(1, DateTimeOffsetStyles.Quarters);

        /// <summary>
        /// Gets previous quarter
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateInfo PreviousQuarter(this DateInfo dt) => dt.OffsetBy(-1, DateTimeOffsetStyles.Quarters);

        /// <summary>
        /// Gets next month
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateInfo NextMonth(this DateInfo dt) => dt.OffsetBy(1, DateTimeOffsetStyles.Month);

        /// <summary>
        /// Gets previous month
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateInfo PreviousMonth(this DateInfo dt) => dt.OffsetBy(-1, DateTimeOffsetStyles.Month);

        /// <summary>
        /// Next week
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateInfo NextWeek(this DateInfo dt) => dt.OffsetBy(1, DateTimeOffsetStyles.Week);

        /// <summary>
        /// Previous week
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateInfo PreviousWeek(this DateInfo dt) => dt.OffsetBy(-1, DateTimeOffsetStyles.Week);

        /// <summary>
        /// Next day
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateInfo NextDay(this DateInfo dt) => dt.OffsetBy(1, DateTimeOffsetStyles.Day);

        /// <summary>
        /// Previous Day
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateInfo PreviousDay(this DateInfo dt) => dt.OffsetBy(-1, DateTimeOffsetStyles.Day);

        /// <summary>
        /// Tomorrow
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateInfo Tomorrow(this DateInfo dt) => dt.NextDay();

        /// <summary>
        /// Yesterday
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateInfo Yesterday(this DateInfo dt) => dt.PreviousDay();
        
        /// <summary>
        /// Next, same as 'GetNextWeekdayInfo'.<br />
        /// 获取下一个工作日。
        /// </summary>
        /// <param name="d"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateInfo NextDayOfWeek(this DateInfo d, DayOfWeek dayOfWeek) => DateInfoCalc.OffsetByDayOfWeek(d, dayOfWeek, 1);

        /// <summary>
        /// Previous, same as 'GetPreviousWeekdayInfo'.<br />
        /// 获取上一个工作日。
        /// </summary>
        /// <param name="d"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateInfo PreviousDayOfWeek(this DateInfo d, DayOfWeek dayOfWeek) => DateInfoCalc.OffsetByDayOfWeek(d, dayOfWeek, -1);

        #endregion
    }
}