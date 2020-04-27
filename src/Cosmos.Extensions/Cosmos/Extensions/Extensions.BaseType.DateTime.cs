using System;
using System.Globalization;

// ReSharper disable once CheckNamespace
namespace Cosmos {
    /// <summary>
    /// DateTime Extensions
    /// </summary>
    public static partial class BaseTypeExtensions {
        /// <summary>
        /// 获得本月的总天数
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static int GetCountDaysOfMonth(this DateTime date) => DateTime.DaysInMonth(date.Year, date.Month);

        /// <summary>
        /// 获得下一个工作日
        /// </summary>
        /// <param name="date"></param>
        /// <param name="weekday"></param>
        /// <returns></returns>
        public static DateTime GetNextWeekday(this DateTime date, DayOfWeek weekday) {
            while (date.DayOfWeek != weekday) date = date.AddDays(1);
            return date;
        }

        /// <summary>
        /// 获得上一个工作日
        /// </summary>
        /// <param name="date">   </param>
        /// <param name="weekday"></param>
        /// <returns></returns>
        public static DateTime GetPreviousWeekday(this DateTime date, DayOfWeek weekday) {
            while (date.DayOfWeek != weekday) date = date.AddDays(-1);
            return date;
        }

        #region GetTimeSpan(获得两个时间的间隔)

        /// <summary>
        /// 获得两个时间的间隔
        /// </summary>
        /// <param name="fecha"></param>
        /// <param name="endFecha">  </param>
        /// <returns></returns>
        public static TimeSpan GetTimeSpan(this DateTime fecha, DateTime endFecha)
            => endFecha - fecha;

        #endregion 获得时间间隔

        #region GetFirstDayOfMonth(获得本月第一天/本月第一个周几)

        /// <summary>
        /// 获得本月第一天
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime GetFirstDayOfMonth(this DateTime date)
            => new DateTime(date.Year, date.Month, 1);

        /// <summary>
        /// 获得本月第一个周几的日期
        /// </summary>
        /// <param name="date">     </param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateTime GetFirstDayOfMonth(this DateTime date, DayOfWeek dayOfWeek) {
            var dt = date.GetFirstDayOfMonth();
            while (dt.DayOfWeek != dayOfWeek) {
                dt = dt.AddDays(1);
            }

            return dt;
        }

        #endregion

        #region GetLastDayOfMonth(获得本月最后一天/本月最后一个周几)

        /// <summary>
        /// 获得本月最后一天
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime GetLastDayOfMonth(this DateTime date)
            => new DateTime(date.Year, date.Month, date.GetCountDaysOfMonth());

        /// <summary>
        /// 获得本月最后一个指定的星期几
        /// </summary>
        /// <param name="date">     </param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateTime GetLastDayOfMonth(this DateTime date, DayOfWeek dayOfWeek) {
            var dt = date.GetLastDayOfMonth();
            while (dt.DayOfWeek != dayOfWeek) {
                dt = dt.AddDays(-1);
            }

            return dt;
        }

        #endregion GetLastDayOfMonth(获得本月最后一天/本月最后一个周几)

        #region GetFirstDayOfWeek(获得本周第一天)

        /// <summary>
        /// 获得本周第一天
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime GetFirstDayOfWeek(this DateTime date)
            => date.GetFirstDayOfWeek(null);

        /// <summary>
        /// 获得本周第一天
        /// </summary>
        /// <param name="date">       </param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public static DateTime GetFirstDayOfWeek(this DateTime date, CultureInfo cultureInfo) {
            cultureInfo = (cultureInfo ?? CultureInfo.CurrentCulture);

            var firstDayOfWeek = cultureInfo.DateTimeFormat.FirstDayOfWeek;
            while (date.DayOfWeek != firstDayOfWeek) date = date.AddDays(-1);

            return date;
        }

        #endregion GetFirstDayOfWeek(获得本周第一天)

        #region GetLastDayOfWeek(获得本周最后一天)

        /// <summary>
        /// 获得本周最后一天
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime GetLastDayOfWeek(this DateTime date)
            => date.GetLastDayOfWeek(null);

        /// <summary>
        /// 获得本周最后一天
        /// </summary>
        /// <param name="date">       </param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public static DateTime GetLastDayOfWeek(this DateTime date, CultureInfo cultureInfo)
            => date.GetFirstDayOfWeek(cultureInfo).AddDays(6);

        #endregion GetLastDayOfWeek(获得本周最后一天)

        #region GetWeekday(获得本周第一个工作日)

        /// <summary>
        /// 获得本周第一个工作日
        /// </summary>
        /// <param name="date">   </param>
        /// <param name="weekday"></param>
        /// <returns></returns>
        public static DateTime GetWeekday(this DateTime date, DayOfWeek weekday)
            => date.GetWeekday(weekday, null);

        /// <summary>
        /// 获得本周第一个工作日
        /// </summary>
        /// <param name="date">       </param>
        /// <param name="weekday">    </param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public static DateTime GetWeekday(this DateTime date, DayOfWeek weekday, CultureInfo cultureInfo)
            => date.GetFirstDayOfWeek(cultureInfo).GetNextWeekday(weekday);

        #endregion GetWeekday(获得本周第一个工作日)

        #region GetMonthDiff(获得两个时间之间相隔的月份)

        /// <summary>
        /// Compute dateTime difference
        /// </summary>
        /// <param name="dt1"></param>
        /// <param name="dt2"></param>
        /// <returns></returns>
        public static int GetMonthDiff(this DateTime dt1, DateTime dt2) {
            var l = dt1 < dt2 ? dt1 : dt2;
            var r = dt1 >= dt2 ? dt1 : dt2;
            return (l.Day == r.Day ? 0 : l.Day > r.Day ? 0 : 1)
                 + (l.Month == r.Month ? 0 : r.Month - l.Month)
                 + (l.Year == r.Year ? 0 : (r.Year - l.Year) * 12);
        }

        /// <summary>
        /// Compute dateTime difference precisely
        /// </summary>
        /// <param name="dt1"></param>
        /// <param name="dt2"></param>
        /// <returns></returns>
        public static double GetTotalMonthDiff(this DateTime dt1, DateTime dt2) {
            var l = dt1 < dt2 ? dt1 : dt2;
            var r = dt1 >= dt2 ? dt1 : dt2;
            var lDfM = DateTime.DaysInMonth(l.Year, l.Month);
            var rDfM = DateTime.DaysInMonth(r.Year, r.Month);

            var dayFixOne = l.Day == r.Day
                ? 0d
                : l.Day > r.Day
                    ? r.Day * 1d / rDfM - l.Day * 1d / lDfM
                    : (r.Day - l.Day) * 1d / rDfM;

            return dayFixOne
                 + (l.Month == r.Month ? 0 : r.Month - l.Month)
                 + (l.Year == r.Year ? 0 : (r.Year - l.Year) * 12);
        }

        #endregion

        #region GetWeekOfYear(获得指定日期所在的周是第几周)

        /// <summary>
        /// 获得指定日期所在的周是第几周
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static int GetWeekOfYear(this DateTime datetime)
            => GetWeekOfYear(datetime, new DateTimeFormatInfo().CalendarWeekRule,
                new DateTimeFormatInfo().FirstDayOfWeek);

        /// <summary>
        /// 获得指定日期所在的周是第几周
        /// </summary>
        /// <param name="datetime"></param>
        /// <param name="weekrule"></param>
        /// <returns></returns>
        public static int GetWeekOfYear(this DateTime datetime, CalendarWeekRule weekrule)
            => GetWeekOfYear(datetime, weekrule, new DateTimeFormatInfo().FirstDayOfWeek);

        /// <summary>
        /// 获得指定日期所在的周是第几周
        /// </summary>
        /// <param name="datetime"></param>
        /// <param name="firstDayOfWeek"></param>
        /// <returns></returns>
        public static int GetWeekOfYear(this DateTime datetime, DayOfWeek firstDayOfWeek)
            => GetWeekOfYear(datetime, new DateTimeFormatInfo().CalendarWeekRule, firstDayOfWeek);

        /// <summary>
        /// 获得指定日期所在的周是第几周
        /// </summary>
        /// <param name="datetime"></param>
        /// <param name="weekrule"></param>
        /// <param name="firstDayOfWeek"></param>
        /// <returns></returns>
        public static int GetWeekOfYear(this DateTime datetime, CalendarWeekRule weekrule, DayOfWeek firstDayOfWeek)
            => CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(datetime, weekrule, firstDayOfWeek);

        #endregion 获得周


        /// <summary>
        /// 获取当前最后时间（即当天的 23:59:59:999）
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static DateTime GetEndOfDay(this DateTime @this) {
            return new DateTime(@this.Year, @this.Month, @this.Day).AddDays(1).Subtract(new TimeSpan(0, 0, 0, 0, 1));
        }

        /// <summary>
        /// 获取当月最后时间（当月最后一天的 23:59:59.999）
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static DateTime GetEndOfMonth(this DateTime @this) {
            return new DateTime(@this.Year, @this.Month, 1).AddMonths(1).Subtract(new TimeSpan(0, 0, 0, 0, 1));
        }

        /// <summary>
        /// 获取当周最后时间（当周最后一天的 23:59:59.999）
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="startDayOfWeek"></param>
        /// <returns></returns>
        public static DateTime GetEndOfWeek(this DateTime dt, DayOfWeek startDayOfWeek = DayOfWeek.Sunday) {
            DateTime end = dt;
            DayOfWeek endDayOfWeek = startDayOfWeek - 1;
            if (endDayOfWeek < 0) {
                endDayOfWeek = DayOfWeek.Saturday;
            }

            if (end.DayOfWeek != endDayOfWeek) {
                if (endDayOfWeek < end.DayOfWeek) {
                    end = end.AddDays(7 - (end.DayOfWeek - endDayOfWeek));
                } else {
                    end = end.AddDays(endDayOfWeek - end.DayOfWeek);
                }
            }

            return new DateTime(end.Year, end.Month, end.Day, 23, 59, 59, 999);
        }

        /// <summary>
        /// 获取当年最后时间（当年最后一天的 23:59:59.999）
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static DateTime GetEndOfYear(this DateTime @this) {
            return new DateTime(@this.Year, 1, 1).AddYears(1).Subtract(new TimeSpan(0, 0, 0, 0, 1));
        }

        /// <summary>
        /// 转换为 Epoch time span
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static TimeSpan ToEpochTimeSpan(this DateTime @this) {
            return @this.Subtract(new DateTime(1970, 1, 1));
        }

        /// <summary>
        /// 获得明天
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static DateTime Tomorrow(this DateTime @this) {
            return @this.AddDays(1);
        }

        /// <summary>
        /// 获取昨天
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static DateTime Yesterday(this DateTime @this) {
            return @this.AddDays(-1);
        }

        /// <summary>
        /// Set time
        /// </summary>
        /// <param name="originalDate"></param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static DateTime SetTime(this DateTime originalDate, int hour, int minute, int second) {
            return new DateTime(originalDate.Year, originalDate.Month, originalDate.Day, hour, minute, second, originalDate.Millisecond);
        }

        /// <summary>
        /// Set hour
        /// </summary>
        /// <param name="originalDate"></param>
        /// <param name="hour"></param>
        /// <returns></returns>
        public static DateTime SetHour(this DateTime originalDate, int hour) {
            return new DateTime(originalDate.Year, originalDate.Month, originalDate.Day, hour, originalDate.Minute, originalDate.Second, originalDate.Millisecond);
        }

        /// <summary>
        /// Set minute
        /// </summary>
        /// <param name="originalDate"></param>
        /// <param name="minute"></param>
        /// <returns></returns>
        public static DateTime SetMinute(this DateTime originalDate, int minute) {
            return new DateTime(originalDate.Year, originalDate.Month, originalDate.Day, originalDate.Hour, minute, originalDate.Second, originalDate.Millisecond);
        }

        /// <summary>
        /// Set second
        /// </summary>
        /// <param name="originalDate"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static DateTime SetSecond(this DateTime originalDate, int second) {
            return new DateTime(originalDate.Year, originalDate.Month, originalDate.Day, originalDate.Hour, originalDate.Minute, second, originalDate.Millisecond);
        }

        /// <summary>
        /// Set date
        /// </summary>
        /// <param name="value"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public static DateTime SetDate(this DateTime value, int year, int month, int day) {
            return new DateTime(year, month, day, value.Hour, value.Minute, value.Second, value.Millisecond);
        }

        /// <summary>
        /// Set year
        /// </summary>
        /// <param name="value"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime SetYear(this DateTime value, int year) {
            return new DateTime(year, value.Month, value.Day, value.Hour, value.Minute, value.Second, value.Millisecond);
        }

        /// <summary>
        /// Set month
        /// </summary>
        /// <param name="value"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public static DateTime SetMonth(this DateTime value, int month) {
            return new DateTime(value.Year, month, value.Day, value.Hour, value.Minute, value.Second, value.Millisecond);
        }

        /// <summary>
        /// Set day
        /// </summary>
        /// <param name="value"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public static DateTime SetDay(this DateTime value, int day) {
            return new DateTime(value.Year, value.Month, day, value.Hour, value.Minute, value.Second, value.Millisecond);
        }
    }
}