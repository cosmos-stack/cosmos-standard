using System;
using System.Globalization;

namespace Cosmos.Date
{
    /// <summary>
    /// Cosmos <see cref="DateInfo"/> extensions.
    /// </summary>
    public static class DateInfoExtensions
    {
        #region Add

        /// <summary>
        /// Add one day<br />
        /// 加一天
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateInfo AddDay(this DateInfo d) => d.AddDays(1);

        /// <summary>
        /// Add weeks. <br />
        /// 加一周
        /// </summary>
        /// <param name="d"></param>
        /// <param name="weeks"></param>
        /// <returns></returns>
        public static DateInfo AddWeeks(this DateInfo d, int weeks) => d.AddDays(weeks * 7);

        /// <summary>
        /// Add one month<br />
        /// 加一个月
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateInfo AddMonth(this DateInfo d) => d.AddMonths(1);

        /// <summary>
        /// Add quarters
        /// </summary>
        /// <param name="d"></param>
        /// <param name="quarters"></param>
        /// <returns></returns>
        public static DateInfo AddQuarters(this DateInfo d, int quarters) => d.AddMonths(quarters * 3);

        /// <summary>
        /// Add one year<br />
        /// 加一年
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateInfo AddYear(this DateInfo d) => d.AddYears(1);

        /// <summary>
        /// Get tomorrow<br />
        /// 第二天
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateInfo Tomorrow(this DateInfo d) => AddDay(d);

        /// <summary>
        /// Get yesterday<br />
        /// 前一天
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateInfo Yesterday(this DateInfo d) => d.AddDays(-1);

        /// <summary>
        /// Add business days<br />
        /// 添加指定个数量的工作日
        /// </summary>
        /// <param name="d"></param>
        /// <param name="days"></param>
        /// <returns></returns>
        public static DateInfo AddBusinessDays(this DateInfo d, int days)
        {
            var sign = Math.Sign(days);
            var unsignedDays = Math.Abs(days);
            for (var i = 0; i < unsignedDays; i++)
            {
                do
                {
                    d = d.AddDays(sign);
                } while (d.DayOfWeek == DayOfWeek.Saturday ||
                         d.DayOfWeek == DayOfWeek.Sunday);
            }

            return d;
        }

        /// <summary>
        /// Subtract business days<br />
        /// 减去指定个数量的工作日
        /// </summary>
        /// <param name="d"></param>
        /// <param name="days"></param>
        /// <returns></returns>
        public static DateInfo SubtractBusinessDays(this DateInfo d, int days) => AddBusinessDays(d, -days);

        #endregion

        #region Ago

        /// <summary>
        /// To ago.<br />
        /// 转换为 Ago
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static string ToAgo(this DateInfo d) => (DateTime.Now - d).ToAgo();

        #endregion

        #region Begin

        /// <summary>
        /// Beginning of week, same as 'GetFirstDayInfoOfWeek'. <br />
        /// 一周的开始日期，等价于 'GetFirstDayInfoOfWeek'。
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateInfo BeginningOfWeek(this DateInfo d) => d.GetFirstDayInfoOfWeek();

        /// <summary>
        /// Beginning of month, same as 'GetLastDayInfoOfMonth'. <br />
        /// 一个月的开始日期，等价于 'GetLastDayInfoOfMonth'。
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateInfo BeginningOfMonth(this DateInfo d) => d.GetFirstDayInfoOfMonth();

        /// <summary>
        /// Beginning of quarter, same as 'GetFirstDayInfoOfQuarter'. <br />
        /// 一个季度的开始日期，等价于 'GetFirstDayInfoOfQuarter'。
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateInfo BeginningOfQuarter(this DateInfo d) => d.GetFirstDayInfoOfQuarter();

        /// <summary>
        /// Beginning of year, same as 'GetFirstDayInfoOfYear'. <br />
        /// 一年的开始日期，等价于 'GetFirstDayInfoOfYear'。
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateInfo BeginningOfYear(this DateInfo d) => d.GetFirstDayInfoOfYear();

        #endregion

        #region Between

        /// <summary>
        /// Is current date between <paramref name="from"/> and <paramref name="to"/>.<br />
        /// 判断当前日期是否在 from 和 to 之间
        /// </summary>
        /// <param name="d"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="includeBoundary"></param>
        /// <returns></returns>
        public static bool IsBetween(this DateInfo d, DateInfo from, DateInfo to, bool includeBoundary = true)
        {
            var dtRef = d.DateTimeRef;
            var fromRef = from.DateTimeRef;
            var toRef = to.DateTimeRef;
            return dtRef.IsBetween(fromRef, toRef, includeBoundary);
        }

        /// <summary>
        /// Is current date between <paramref name="min"/> and <paramref name="max"/> with boundary.<br />
        /// 判断当前日期是否在 min 和 max 之间，闭包区间。
        /// </summary>
        /// <param name="d"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static bool IsDateBetweenWithBoundary(this DateInfo d, DateInfo min, DateInfo max)
        {
            var dtRef = d.DateTimeRef;
            var minRef = min.DateTimeRef;
            var maxRef = max.DateTimeRef;
            return dtRef.IsDateBetweenWithBoundary(minRef, maxRef);
        }

        /// <summary>
        /// Is current date between <paramref name="min"/> and <paramref name="max"/> without boundary.<br />
        /// 判断当前日期是否在 min 和 max 之间，开区间。
        /// </summary>
        /// <param name="d"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static bool IsDateBetweenWithoutBoundary(this DateInfo d, DateInfo min, DateInfo max)
        {
            var dtRef = d.DateTimeRef;
            var minRef = min.DateTimeRef;
            var maxRef = max.DateTimeRef;
            return dtRef.IsDateBetweenWithoutBoundary(minRef, maxRef);
        }

        #endregion

        #region Clone

        /// <summary>
        /// Clone<br />
        /// 克隆
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateInfo Clone(this DateInfo d)
        {
            if (d == null)
                throw new ArgumentNullException(nameof(d));
            return new DateInfo(d.DateTimeRef);
        }

        #endregion

        #region End

        /// <summary>
        /// End of week, same as 'GetLastDayInfoOfWeek'. <br />
        /// 一周的结束日期，等价于 'GetLastDayInfoOfWeek'。
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateInfo EndOfWeek(this DateInfo d) => d.GetLastDayInfoOfWeek();

        /// <summary>
        /// End of month, same as 'GetLastDayInfoOfMonth'. <br />
        /// 一个月份的结束日期，等价于 'GetLastDayInfoOfMonth'。
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateInfo EndOfMonth(this DateInfo d) => d.GetLastDayInfoOfMonth();

        /// <summary>
        /// End of quarter, same as 'GetLastDayInfoOfQuarter'. <br />
        /// 一个季度的结束日期，等价于 'GetLastDayInfoOfQuarter'。
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateInfo EndOfQuarter(this DateInfo d) => d.GetLastDayInfoOfQuarter();

        /// <summary>
        /// End of year, same as 'GetLastDayOfYear'. <br />
        /// 一年的结束日期，等价于 'GetLastDayOfYear'。
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateInfo EndOfYear(this DateInfo d) => d.GetLastDayInfoOfYear();

        #endregion

        #region Get

        /// <summary>
        /// Get next weekday. <br />
        /// 获取下一个工作日。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="weekday"></param>
        /// <returns></returns>
        public static DateInfo GetNextWeekdayInfo(this DateTime dt, DayOfWeek weekday)
        {
            while (dt.DayOfWeek != weekday) dt = dt.AddDays(1);
            return dt;
        }

        /// <summary>
        /// Get next weekday. <br />
        /// 获取下一个的工作日。
        /// </summary>
        /// <param name="d"></param>
        /// <param name="weekday"></param>
        /// <returns></returns>
        public static DateInfo GetNextWeekdayInfo(this DateInfo d, DayOfWeek weekday)
        {
            while (d.DayOfWeek != weekday) d = d.AddDays(1);
            return d;
        }

        /// <summary>
        /// Get previous weekday. <br />
        /// 获取上一个工作日。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="weekday"></param>
        /// <returns></returns>
        public static DateInfo GetPreviousWeekdayInfo(this DateTime dt, DayOfWeek weekday)
        {
            while (dt.DayOfWeek != weekday) dt = dt.AddDays(-1);
            return dt;
        }

        /// <summary>
        /// Get previous weekday. <br />
        /// 获取上一个工作日。
        /// </summary>
        /// <param name="d"></param>
        /// <param name="weekday"></param>
        /// <returns></returns>
        public static DateInfo GetPreviousWeekdayInfo(this DateInfo d, DayOfWeek weekday)
        {
            while (d.DayOfWeek != weekday) d = d.AddDays(-1);
            return d;
        }

        /// <summary>
        /// Get last day of this week. <br />
        /// 获取本周的最后一天。
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateInfo GetLastDayInfoOfWeek(this DateTime dt) => dt.GetLastDayInfoOfWeek(null);

        /// <summary>
        /// Get last day of this week. <br />
        /// 获取本周的最后一天。
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateInfo GetLastDayInfoOfWeek(this DateInfo d) => d.GetLastDayInfoOfWeek(null);

        /// <summary>
        /// Get last day of this week. <br />
        /// 获取本周的最后一天。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public static DateInfo GetLastDayInfoOfWeek(this DateTime dt, CultureInfo cultureInfo)
        {
            cultureInfo = (cultureInfo ?? CultureInfo.CurrentCulture);
            var firstDayOfWeek = cultureInfo.DateTimeFormat.FirstDayOfWeek;
            while (dt.DayOfWeek != firstDayOfWeek) dt = dt.AddDays(-1);
            return dt.AddDays(6);
        }

        /// <summary>
        /// Get last day of this week. <br />
        /// 获取本周的最后一天。
        /// </summary>
        /// <param name="d"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public static DateInfo GetLastDayInfoOfWeek(this DateInfo d, CultureInfo cultureInfo)
        {
            cultureInfo = (cultureInfo ?? CultureInfo.CurrentCulture);
            var firstDayOfWeek = cultureInfo.DateTimeFormat.FirstDayOfWeek;
            while (d.DayOfWeek != firstDayOfWeek) d = d.AddDays(-1);
            return d.AddDays(6);
        }

        /// <summary>
        /// Get last day of this month. <br />
        /// 获取本月份的最后一天。
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateInfo GetLastDayInfoOfMonth(this DateTime dt) => new DateInfo(dt.Year, dt.Month, DateTime.DaysInMonth(dt.Year, dt.Month));

        /// <summary>
        /// Get last day of this month. <br />
        /// 获取本月份的最后一天。
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateInfo GetLastDayInfoOfMonth(this DateInfo dt) => new DateInfo(dt.Year, dt.Month, DateTime.DaysInMonth(dt.Year, dt.Month));

        /// <summary>
        /// Get last day (of week) of this month. <br />
        /// 获取本月份最后一周的最后一天。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateInfo GetLastDayInfoOfMonth(this DateTime dt, DayOfWeek dayOfWeek)
        {
            var t = new DateTime(dt.Year, dt.Month, DateTime.DaysInMonth(dt.Year, dt.Month));
            while (t.DayOfWeek != dayOfWeek)
                t = t.AddDays(-1);
            return t;
        }

        /// <summary>
        /// Get last day (of week) of this month. <br />
        /// 获取本月份最后一周的最后一天。
        /// </summary>
        /// <param name="d"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateInfo GetLastDayInfoOfMonth(this DateInfo d, DayOfWeek dayOfWeek)
        {
            var t = new DateTime(d.Year, d.Month, DateTime.DaysInMonth(d.Year, d.Month));
            while (t.DayOfWeek != dayOfWeek)
                t = t.AddDays(-1);
            return t;
        }

        /// <summary>
        /// Gets last day info of quarter. <br />
        /// 获取本季节的最后一天。
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateInfo GetLastDayInfoOfQuarter(this DateTime dt) => dt.LastDayOfQuarter();

        /// <summary>
        /// Gets last day info of quarter. <br />
        /// 获取本季节的最后一天。
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateInfo GetLastDayInfoOfQuarter(this DateInfo d) => d.DateTimeRef.GetLastDayInfoOfQuarter();

        /// <summary>
        /// Gets last day info of quarter. <br />
        /// 获取本季节的最后一天。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateInfo GetLastDayInfoOfQuarter(this DateTime dt, DayOfWeek dayOfWeek)
        {
            var t = dt.GetLastDayInfoOfQuarter();
            while (t.DayOfWeek != dayOfWeek)
                t = t.AddDays(-1);
            return t;
        }

        /// <summary>
        /// Gets last day info of quarter. <br />
        /// 获取本季节的最后一天。
        /// </summary>
        /// <param name="d"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateInfo GetLastDayInfoOfQuarter(this DateInfo d, DayOfWeek dayOfWeek) => d.DateTimeRef.GetLastDayInfoOfQuarter(dayOfWeek);

        /// <summary>
        /// Get last day info of year. <br />
        /// 获取本年度的最后一天。
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateInfo GetLastDayInfoOfYear(this DateTime dt) => dt.LastDayOfYear();

        /// <summary>
        /// Get last day info of year. <br />
        /// 获取本年度的最后一天。
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateInfo GetLastDayInfoOfYear(this DateInfo d) => d.DateTimeRef.GetLastDayInfoOfYear();

        /// <summary>
        /// Get last day info of year. <br />
        /// 获取本年度的最后一天。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateInfo GetLastDayInfoOfYear(this DateTime dt, DayOfWeek dayOfWeek)
        {
            var t = dt.LastDayOfYear();
            while (t.DayOfWeek != dayOfWeek)
                t = t.AddDays(-1);
            return t;
        }

        /// <summary>
        /// Get last day info of year. <br />
        /// 获取本年度的最后一天。
        /// </summary>
        /// <param name="d"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateInfo GetLastDayInfoOfYear(this DateInfo d, DayOfWeek dayOfWeek) => d.DateTimeRef.GetLastDayInfoOfYear(dayOfWeek);

        /// <summary>
        /// Get first day of this week. <br />
        /// 获取本周的第一天。
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateInfo GetFirstDayInfoOfWeek(this DateTime dt) => dt.GetFirstDayInfoOfWeek(null);

        /// <summary>
        /// Get first day of this week. <br />
        /// 获取本周的第一天。
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateInfo GetFirstDayInfoOfWeek(this DateInfo d) => d.GetFirstDayInfoOfWeek(null);

        /// <summary>
        /// Get first day of this week. <br />
        /// 获取本周的第一天。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public static DateInfo GetFirstDayInfoOfWeek(this DateTime dt, CultureInfo cultureInfo)
        {
            cultureInfo = (cultureInfo ?? CultureInfo.CurrentCulture);
            var firstDayOfWeek = cultureInfo.DateTimeFormat.FirstDayOfWeek;
            while (dt.DayOfWeek != firstDayOfWeek) dt = dt.AddDays(-1);
            return dt;
        }

        /// <summary>
        /// Get first day of this week. <br />
        /// 获取本周的第一天。
        /// </summary>
        /// <param name="d"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public static DateInfo GetFirstDayInfoOfWeek(this DateInfo d, CultureInfo cultureInfo) => d.DateTimeRef.GetFirstDayInfoOfWeek(cultureInfo);

        /// <summary>
        /// Get first day of this month. <br />
        /// 获取本月份的第一天。
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateInfo GetFirstDayInfoOfMonth(this DateTime dt) => new DateInfo(dt.Year, dt.Month, 1);

        /// <summary>
        /// Get first day of this month. <br />
        /// 获取本月份的第一天。
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateInfo GetFirstDayInfoOfMonth(this DateInfo dt) => new DateInfo(dt.Year, dt.Month, 1);

        /// <summary>
        /// Get first day of (the week of) this month. <br />
        /// 获取本月份第一周的第一天。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateInfo GetFirstDayInfoOfMonth(this DateTime dt, DayOfWeek dayOfWeek)
        {
            var t = new DateTime(dt.Year, dt.Month, 1);
            while (t.DayOfWeek != dayOfWeek)
                t = t.AddDays(1);
            return t;
        }

        /// <summary>
        /// Get first day of (the week of) this month. <br />
        /// 获取本月份第一周的第一天。
        /// </summary>
        /// <param name="d"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateInfo GetFirstDayInfoOfMonth(this DateInfo d, DayOfWeek dayOfWeek) => d.DateTimeRef.GetFirstDayInfoOfMonth(dayOfWeek);

        /// <summary>
        /// Get first day of this quarter. <br />
        /// 获取本季度的第一天。
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateInfo GetFirstDayInfoOfQuarter(this DateTime dt) => dt.FirstDayOfQuarter();

        /// <summary>
        /// Get first day of this quarter. <br />
        /// 获取本季度的第一天。
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateInfo GetFirstDayInfoOfQuarter(this DateInfo d) => d.DateTimeRef.GetFirstDayInfoOfQuarter();

        /// <summary>
        /// Get first day of this quarter. <br />
        /// 获取本季度的第一天。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateInfo GetFirstDayInfoOfQuarter(this DateTime dt, DayOfWeek dayOfWeek)
        {
            var d = dt.GetFirstDayInfoOfQuarter();
            while (d.DayOfWeek != dayOfWeek)
                d = d.AddDays(1);
            return d;
        }

        /// <summary>
        /// Get first day of this quarter. <br />
        /// 获取本季度的第一天。
        /// </summary>
        /// <param name="d"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateInfo GetFirstDayInfoOfQuarter(this DateInfo d, DayOfWeek dayOfWeek) => d.DateTimeRef.GetFirstDayInfoOfQuarter(dayOfWeek);

        /// <summary>
        /// Get first day of this year. <br />
        /// 获取本年度的第一天。
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateInfo GetFirstDayInfoOfYear(this DateTime dt) => dt.FirstDayOfYear();

        /// <summary>
        /// Get first day of this year. <br />
        /// 获取本年度的第一天。
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateInfo GetFirstDayInfoOfYear(this DateInfo d) => new DateInfo(d.Year, 1, 1);

        /// <summary>
        /// Get first day of this year. <br />
        /// 获取本年度的第一天。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateInfo GetFirstDayInfoOfYear(this DateTime dt, DayOfWeek dayOfWeek)
        {
            var t = DateTimeFactory.Create(dt.Year, 1, 1);
            while (t.DayOfWeek != dayOfWeek)
                t = t.AddDays(-1);
            return t;
        }

        /// <summary>
        /// Get first day of this year. <br />
        /// 获取本年度的第一天。
        /// </summary>
        /// <param name="d"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateInfo GetFirstDayInfoOfYear(this DateInfo d, DayOfWeek dayOfWeek) => d.DateTimeRef.GetFirstDayInfoOfYear(dayOfWeek);

        #endregion

        #region Is

        /// <summary>
        /// Is the nextDay the day after current date.<br />
        /// 判断是否为第二天
        /// </summary>
        /// <param name="d"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public static bool IsNextMatched(this DateInfo d, DateInfo next)
        {
            if (d == null || next == null)
                return false;

            var tomorrow = d.AddDay();
            return tomorrow.Equals(next);
        }

        /// <summary>
        /// Determine whether the specified time is in the past relative to the specified time. <br />
        /// 判断指定时间是否是相对给定时间的过去。
        /// </summary>
        /// <param name="d"></param>
        /// <param name="toCompareWith"></param>
        /// <returns></returns>
        public static bool IsBefore(this DateInfo d, DateInfo toCompareWith) => d < toCompareWith;

        /// <summary>
        /// Determine whether the specified time is in the future relative to the specified time. <br />
        /// 判断指定时间是否是相对给定时间的未来。
        /// </summary>
        /// <param name="d"></param>
        /// <param name="toCompareWith"></param>
        /// <returns></returns>
        public static bool IsAfter(this DateInfo d, DateInfo toCompareWith) => d > toCompareWith;

        /// <summary>
        /// Determine whether the given time is in the future. <br />
        /// 判断给定的时间是否在未来。
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static bool IsInTheFuture(this DateInfo d) => d > DateTime.Now;

        /// <summary>
        /// Determine whether the given time is in the past. <br />
        /// 判断给定的时间是否在过去。
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static bool IsInThePast(this DateInfo d) => d < DateTime.Now;

        /// <summary>
        /// Determine whether it is in the same day. <br />
        /// 判断是否在同一天。
        /// </summary>
        /// <param name="d"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsSameDay(this DateInfo d, DateInfo date) => d.DateTimeRef == date.DateTimeRef;

        /// <summary>
        /// Determine whether it is in the same month. <br />
        /// 判断是否在同一个月。
        /// </summary>
        /// <param name="d"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsSameMonth(this DateInfo d, DateInfo date) => d.Month == date.Month && d.Year == date.Year;

        /// <summary>
        /// Determine whether it is in the same year. <br />
        /// 判断是否在同一年。
        /// </summary>
        /// <param name="d"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsSameYear(this DateInfo d, DateInfo date) => d.Year == date.Year;

        #endregion

        #region Next and Previous

        /// <summary>
        /// According to the specified time, get the day of the next year.<br />
        /// 根据指定的时间，获取下一年的当天。
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateInfo NextYear(this DateInfo d)
        {
            var year = d.Year + 1;
            var daysOfMonth = DateTime.DaysInMonth(year, d.Month);

            if (daysOfMonth == d.Day)
                return new DateInfo(year, d.Month, d.Day);

            var m = d.Day - daysOfMonth;
            var p = new DateInfo(year, d.Month, daysOfMonth);
            return p + m.Days();
        }

        /// <summary>
        /// According to the specified time, get the day of the previous year.<br />
        /// 根据指定的时间，获取上一年的当天。
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateInfo PreviousYear(this DateInfo d)
        {
            var year = d.Year - 1;
            var daysOfMonth = DateTime.DaysInMonth(year, d.Month);

            if (daysOfMonth == d.Day)
                return new DateInfo(year, d.Month, d.Day);

            var m = d.Day - daysOfMonth;
            var p = new DateInfo(year, d.Month, daysOfMonth);
            return p + m.Days();
        }

        /// <summary>
        /// Next day, same as 'Tomorrow'.<br />
        /// 下一天，即「明天」。
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateInfo NextDay(this DateInfo d) => d.Tomorrow();

        /// <summary>
        /// Previous Day, same aa 'Yesterday'.<br />
        /// 上一天，即「昨天」
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateInfo PreviousDay(this DateInfo d) => d.Yesterday();

        /// <summary>
        /// Next, same as 'GetNextWeekdayInfo'.<br />
        /// 获取下一个工作日。
        /// </summary>
        /// <param name="d"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateInfo NextDayOfWeek(this DateInfo d, DayOfWeek dayOfWeek) => d.GetNextWeekdayInfo(dayOfWeek);

        /// <summary>
        /// Previous, same as 'GetPreviousWeekdayInfo'.<br />
        /// 获取上一个工作日。
        /// </summary>
        /// <param name="d"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateInfo PreviousDayOfWeek(this DateInfo d, DayOfWeek dayOfWeek) => d.GetPreviousWeekdayInfo(dayOfWeek);

        /// <summary>
        /// Week after.<br />
        /// 获取一周后的日期，即加七天。
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateInfo WeekAfter(this DateInfo d) => d + 1.Weeks();

        /// <summary>
        /// Week before.<br />
        /// 获取一周前的日期，即减七天。
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateInfo WeekBefore(this DateInfo d) => d - 1.Weeks();

        /// <summary>
        /// Increase time.<br />
        /// 增加时间。
        /// </summary>
        /// <param name="d"></param>
        /// <param name="toAdd"></param>
        /// <returns></returns>
        public static DateInfo IncreaseTime(this DateInfo d, TimeSpan toAdd) => d + toAdd;

        /// <summary>
        /// Decrease time.<br />
        /// 减少时间。
        /// </summary>
        /// <param name="d"></param>
        /// <param name="toSubtract"></param>
        /// <returns></returns>
        public static DateInfo DecreaseTime(this DateInfo d, TimeSpan toSubtract) => d - toSubtract;

        #endregion

        #region Set

        /// <summary>
        /// Set the year of the date. <br />
        /// 设置日期的年份。
        /// </summary>
        /// <param name="d"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateInfo SetDate(this DateInfo d, int year)
        {
            d.Year = year;
            return d;
        }

        /// <summary>
        /// Set the year and month of the date. <br />
        /// 设置日期的年份和月份。
        /// </summary>
        /// <param name="d"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public static DateInfo SetDate(this DateInfo d, int year, int month)
        {
            d.Year = year;
            d.Month = month;
            return d;
        }

        /// <summary>
        /// Set the year, month and day of the date. <br />
        /// 设置日期的年月日。
        /// </summary>
        /// <param name="d"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public static DateInfo SetDate(this DateInfo d, int year, int month, int day)
        {
            d.Year = year;
            d.Month = month;
            d.Day = day;
            return d;
        }

        /// <summary>
        /// Set the year of the date. <br />
        /// 设置日期的年份。
        /// </summary>
        /// <param name="d"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateInfo SetYear(this DateInfo d, int year)
        {
            d.Year = year;
            return d;
        }

        /// <summary>
        /// Set the month of the date. <br />
        /// 设置日期的月份。
        /// </summary>
        /// <param name="d"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public static DateInfo SetMonth(this DateInfo d, int month)
        {
            d.Month = month;
            return d;
        }

        /// <summary>
        /// Set the day of the date. <br />
        /// 设置日期的具体的那一天。
        /// </summary>
        /// <param name="d"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public static DateInfo SetDay(this DateInfo d, int day)
        {
            d.Day = day;
            return d;
        }

        #endregion
    }
}