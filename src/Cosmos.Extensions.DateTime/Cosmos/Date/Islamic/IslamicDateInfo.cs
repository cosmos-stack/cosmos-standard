using System;
using NodaTime;
using NodaTime.Calendars;
using NodaTime.Extensions;

namespace Cosmos.Date.Islamic
{
    /// <summary>
    /// Islamic Date<br />
    /// 伊斯兰历日期
    /// </summary>
    public class IslamicDateInfo
    {
        private static CalendarSystem _islamicCalendar = CalendarSystem.GetIslamicCalendar(IslamicLeapYearPattern.Base16, IslamicEpoch.Civil);

        private DateTime InternalDateTime { get; set; }
        private LocalDate InternalLocalDate { get; set; }
        private CalendarSystem Calendar { get; set; }

        /// <summary>
        /// Create a new instance for <see cref="IslamicDateInfo"/><br />
        /// 创建一个 <see cref="IslamicDateInfo"/> 的新实例
        /// </summary>
        /// <param name="dt"></param>
        public IslamicDateInfo(DateTime dt) : this(dt, _islamicCalendar) { }

        /// <summary>
        /// Create a new instance for <see cref="IslamicDateInfo"/><br />
        /// 创建一个 <see cref="IslamicDateInfo"/> 的新实例
        /// </summary>
        /// <param name="dt"></param>
        public IslamicDateInfo(IslamicDateTime dt)
        {
            InternalDateTime = dt.InternalTime;
            InternalLocalDate = new LocalDate(dt.IslamicYear, dt.IslamicMonth, dt.IslamicDay, dt.InternalCalendarSystem);
            Calendar = dt.InternalCalendarSystem;
        }

        /// <summary>
        /// Create a new instance for <see cref="IslamicDateInfo"/><br />
        /// 创建一个 <see cref="IslamicDateInfo"/> 的新实例
        /// </summary>
        /// <param name="date"></param>
        public IslamicDateInfo(DateInfo date) : this(date, _islamicCalendar) { }

        /// <summary>
        /// Create a new instance for <see cref="IslamicDateInfo"/><br />
        /// 创建一个 <see cref="IslamicDateInfo"/> 的新实例
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="calendar"></param>
        public IslamicDateInfo(DateTime dt, CalendarSystem calendar)
        {
            var ld = new LocalDate(dt.Year, dt.Month, dt.Day, CalendarSystem.Iso);
            ld = ld.WithCalendar(_islamicCalendar);

            InternalDateTime = dt;
            InternalLocalDate = ld;
            Calendar = calendar;
        }

        /// <summary>
        /// Create a new instance for <see cref="IslamicDateInfo"/><br />
        /// 创建一个 <see cref="IslamicDateInfo"/> 的新实例
        /// </summary>
        /// <param name="date"></param>
        /// <param name="calendar"></param>
        public IslamicDateInfo(DateInfo date, CalendarSystem calendar)
        {
            var ld = new LocalDate(date.Year, date.Month, date.Day, CalendarSystem.Iso);
            ld = ld.WithCalendar(_islamicCalendar);

            InternalDateTime = date;
            InternalLocalDate = ld;
            Calendar = calendar;
        }

        private IslamicDateInfo(LocalDate ld)
        {
            InternalDateTime = ld.ToDateTimeUnspecified();
            InternalLocalDate = ld;
            Calendar = ld.Calendar;
        }

        /// <summary>
        /// Is current year a leap year.<br />
        /// 当前年份是否为闰年
        /// </summary>
        /// <returns></returns>
        public bool IsLeepYear() => Calendar.IsLeapYear(InternalDateTime.Year);

        /// <summary>
        /// Is current day weekend<br />
        /// 当天日期是否为周末
        /// </summary>
        /// <returns></returns>
        public bool IsWeekend() => InternalDateTime.IsWeekend();

        /// <summary>
        /// Is current day a work day<br />
        /// 当前日期是否为工作日
        /// </summary>
        /// <returns></returns>
        public bool IsWorkDay() => InternalDateTime.IsWeekday();

        /// <summary>
        /// Gets Islamic year<br />
        /// 获取伊斯兰历年份
        /// </summary>
        public int IslamicYear => InternalLocalDate.Year;

        /// <summary>
        /// Gets Islamic month.<br />
        /// 获取伊斯兰历月份
        /// </summary>
        public int IslamicMonth => InternalLocalDate.Month;

        /// <summary>
        /// Gets Islamic day.<br />
        /// 获取伊斯兰农历日份
        /// </summary>
        public int IslamicDay => InternalLocalDate.Day;

        /// <summary>
        /// Gets Islamic month.<br />
        /// 获取伊斯兰农历月份
        /// </summary>
        /// <returns></returns>
        public IslamicMonths GetIslamicMonths() => (IslamicMonths) IslamicMonth;

        /// <summary>
        /// Tomorrow<br />
        /// 明天
        /// </summary>
        /// <returns></returns>
        public IslamicDateInfo Tomorrow()
        {
            return AddDays(1);
        }

        /// <summary>
        /// Yesterday<br />
        /// 昨天
        /// </summary>
        /// <returns></returns>
        public IslamicDateInfo Yesterday()
        {
            return AddDays(-1);
        }

        /// <summary>
        /// Add days<br />
        /// 添加若干天
        /// </summary>
        /// <param name="days"></param>
        /// <returns></returns>
        public IslamicDateInfo AddDays(int days)
        {
            return new IslamicDateInfo(InternalLocalDate.PlusDays(days));
        }

        /// <summary>
        /// Add months<br />
        /// 添加月份
        /// </summary>
        /// <param name="months"></param>
        /// <returns></returns>
        public IslamicDateInfo AddMonths(int months)
        {
            return new IslamicDateInfo(InternalLocalDate.PlusMonths(months));
        }

        /// <summary>
        /// Gets days in year.<br />
        /// 伊斯兰历年中共有几天
        /// </summary>
        /// <returns></returns>
        public int GetDaysInYear() => Calendar.GetDaysInYear(InternalDateTime.Year);

        /// <summary>
        /// Gets days in month.<br />
        /// 伊斯兰历月中共有几天
        /// </summary>
        /// <returns></returns>
        public int GetDaysInMonth() => Calendar.GetDaysInMonth(InternalDateTime.Year, InternalDateTime.Month);

        /// <summary>
        /// Calculates the day of the Islamic year in the special date.<br />
        /// 伊斯兰历年中的第几天 
        /// </summary>
        /// <returns></returns>
        public int GetDayOfYear() => InternalLocalDate.DayOfYear;

        /// <summary>
        /// Calculates the day of the Islamic month in the special date.<br />
        /// 伊斯兰历月中的第几天 
        /// </summary>
        /// <returns></returns>
        public int GetDayOfMonth() => InternalLocalDate.Day;

        /// <summary>
        /// Calculates the day of the week in the special date.<br />
        /// 一周中的第几天 
        /// </summary>
        /// <returns></returns>
        public DayOfWeek GetDayOfWeek() => InternalLocalDate.DayOfWeek.ToDayOfWeek();

        /// <summary>
        /// Convert to <see cref="DateTime"/><br />
        /// 转换为 <see cref="DateTime"/>
        /// </summary>
        /// <returns></returns>
        public DateTime ToDateTime() => InternalDateTime;

        /// <summary>
        /// Convert <see cref="IslamicDateInfo"/> to <see cref="DateInfo"/>
        /// </summary>
        /// <param name="di"></param>
        public static implicit operator DateInfo(IslamicDateInfo di)
        {
            return di.InternalDateTime;
        }

        /// <summary>
        /// Convert <see cref="DateInfo"/> to <see cref="IslamicDateInfo"/>
        /// </summary>
        /// <param name="dt"></param>
        public static implicit operator IslamicDateInfo(DateInfo dt)
        {
            return new IslamicDateInfo(dt);
        }

        /// <summary>
        /// Gets internal datetime
        /// </summary>
        internal DateTime InternalTime => InternalDateTime;

        /// <summary>
        /// Create a new instance of <see cref="IslamicDateInfo"/><br />
        /// 创建一个新的 <see cref="IslamicDateInfo"/> 实例。
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <param name="calendar"></param>
        /// <returns></returns>
        public static IslamicDateInfo Of(int year, int month, int day, CalendarSystem calendar = null)
        {
            return new IslamicDateInfo(DateTimeFactory.Create(year, month, day), calendar ?? _islamicCalendar);
        }

        /// <summary>
        /// Create a new instance of <see cref="IslamicDateInfo"/><br />
        /// 创建一个新的 <see cref="IslamicDateInfo"/> 实例。
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <param name="calendar"></param>
        /// <returns></returns>
        public static IslamicDateInfo OfLunar(int year, int month, int day, CalendarSystem calendar = null)
        {
            var ld = new LocalDate(year, month, day, calendar ?? _islamicCalendar);
            return new IslamicDateInfo(ld);
        }
    }
}