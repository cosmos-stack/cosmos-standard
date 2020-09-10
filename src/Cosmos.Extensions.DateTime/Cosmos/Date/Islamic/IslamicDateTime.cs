using System;
using NodaTime;
using NodaTime.Calendars;
using NodaTime.Extensions;

namespace Cosmos.Date.Islamic
{
    /// <summary>
    /// Islamic Date Time<br />
    /// 伊斯兰历日期与时间
    /// </summary>
    public class IslamicDateTime
    {
        private static CalendarSystem _islamicCalendar = CalendarSystem.GetIslamicCalendar(IslamicLeapYearPattern.Base16, IslamicEpoch.Civil);

        private DateTime InternalDateTime { get; set; }
        private LocalDateTime InternalLocalDateTime { get; set; }
        private CalendarSystem Calendar { get; set; }

        /// <summary>
        /// Create a new instance for <see cref="IslamicDateTime"/><br />
        /// 创建一个 <see cref="IslamicDateTime"/> 的新实例
        /// </summary>
        /// <param name="dt"></param>
        public IslamicDateTime(DateTime dt) : this(dt, _islamicCalendar) { }

        /// <summary>
        /// Create a new instance for <see cref="IslamicDateTime"/><br />
        /// 创建一个 <see cref="IslamicDateTime"/> 的新实例
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="calendar"></param>
        public IslamicDateTime(DateTime dt, CalendarSystem calendar)
        {
            var ldt = new LocalDateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond, CalendarSystem.Iso);
            ldt = ldt.WithCalendar(calendar);

            InternalDateTime = dt;
            InternalLocalDateTime = ldt;
            Calendar = calendar;
        }

        private IslamicDateTime(LocalDateTime ldt)
        {
            InternalDateTime = ldt.ToDateTimeUnspecified();
            InternalLocalDateTime = ldt;
            Calendar = ldt.Calendar;
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
        public int IslamicYear => InternalLocalDateTime.Year;

        /// <summary>
        /// Gets Islamic month.<br />
        /// 获取伊斯兰历月份
        /// </summary>
        public int IslamicMonth => InternalLocalDateTime.Month;

        /// <summary>
        /// Gets Islamic day.<br />
        /// 获取伊斯兰农历日份
        /// </summary>
        public int IslamicDay => InternalLocalDateTime.Day;

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
        public IslamicDateTime Tomorrow()
        {
            return AddDays(1);
        }

        /// <summary>
        /// Yesterday<br />
        /// 昨天
        /// </summary>
        /// <returns></returns>
        public IslamicDateTime Yesterday()
        {
            return AddDays(-1);
        }

        /// <summary>
        /// Add days<br />
        /// 添加若干天
        /// </summary>
        /// <param name="days"></param>
        /// <returns></returns>
        public IslamicDateTime AddDays(int days)
        {
            return new IslamicDateTime(InternalLocalDateTime.PlusDays(days));
        }

        /// <summary>
        /// Add months<br />
        /// 添加月份
        /// </summary>
        /// <param name="months"></param>
        /// <returns></returns>
        public IslamicDateTime AddMonths(int months)
        {
            return new IslamicDateTime(InternalLocalDateTime.PlusMonths(months));
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
        public int GetDayOfYear() => InternalLocalDateTime.DayOfYear;

        /// <summary>
        /// Calculates the day of the Islamic month in the special date.<br />
        /// 伊斯兰历月中的第几天 
        /// </summary>
        /// <returns></returns>
        public int GetDayOfMonth() => InternalLocalDateTime.Day;

        /// <summary>
        /// Calculates the day of the week in the special date.<br />
        /// 一周中的第几天 
        /// </summary>
        /// <returns></returns>
        public DayOfWeek GetDayOfWeek() => InternalLocalDateTime.DayOfWeek.ToDayOfWeek();

        /// <summary>
        /// Convert <see cref="IslamicDateTime"/> to <see cref="DateTime"/>
        /// </summary>
        /// <param name="di"></param>
        public static implicit operator DateTime(IslamicDateTime di)
        {
            return di.InternalDateTime;
        }

        /// <summary>
        /// Convert <see cref="DateTime"/> to <see cref="IslamicDateTime"/>
        /// </summary>
        /// <param name="dt"></param>
        public static implicit operator IslamicDateTime(DateTime dt)
        {
            return new IslamicDateTime(dt);
        }

        /// <summary>
        /// Gets <see cref="CalendarSystem"/> instance internal.
        /// </summary>
        internal CalendarSystem InternalCalendarSystem => Calendar;

        /// <summary>
        /// Gets internal datetime
        /// </summary>
        internal DateTime InternalTime => InternalDateTime;

        /// <summary>
        /// Gets internal local datetime
        /// </summary>
        internal LocalDateTime InternalLocalTime => InternalLocalDateTime;

        /// <summary>
        /// Convert to <see cref="DateTime"/><br />
        /// 转换为 <see cref="DateTime"/>
        /// </summary>
        /// <returns></returns>
        public DateTime ToDateTime() => InternalDateTime;

        /// <summary>
        /// Create a new instance of <see cref="IslamicDateTime"/><br />
        /// 创建一个新的 <see cref="IslamicDateTime"/> 实例。
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <param name="calendar"></param>
        /// <returns></returns>
        public static IslamicDateTime Of(int year, int month, int day, CalendarSystem calendar = null)
        {
            return new IslamicDateTime(DateTimeFactory.Create(year, month, day), calendar ?? _islamicCalendar);
        }

        /// <summary>
        /// Create a new instance of <see cref="IslamicDateTime"/><br />
        /// 创建一个新的 <see cref="IslamicDateTime"/> 实例。
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <param name="second"></param>
        /// <param name="calendar"></param>
        /// <returns></returns>
        public static IslamicDateTime Of(int year, int month, int day, int hour, int minute, int second, CalendarSystem calendar = null)
        {
            return new IslamicDateTime(DateTimeFactory.Create(year, month, day, hour, minute, second), calendar ?? _islamicCalendar);
        }

        /// <summary>
        /// Create a new instance of <see cref="IslamicDateTime"/><br />
        /// 创建一个新的 <see cref="IslamicDateTime"/> 实例。
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <param name="second"></param>
        /// <param name="millisecond"></param>
        /// <param name="calendar"></param>
        /// <returns></returns>
        public static IslamicDateTime Of(int year, int month, int day, int hour, int minute, int second, int millisecond, CalendarSystem calendar = null)
        {
            return new IslamicDateTime(DateTimeFactory.Create(year, month, day, hour, minute, second, millisecond), calendar ?? _islamicCalendar);
        }

        /// <summary>
        /// Create a new instance of <see cref="IslamicDateTime"/><br />
        /// 创建一个新的 <see cref="IslamicDateTime"/> 实例。
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <param name="calendar"></param>
        /// <returns></returns>
        public static IslamicDateTime OfIslamic(int year, int month, int day, CalendarSystem calendar = null)
        {
            var ldt = new LocalDateTime(year, month, day, 0, 0, 0, 0, calendar ?? _islamicCalendar);
            return new IslamicDateTime(ldt);
        }

        /// <summary>
        /// Create a new instance of <see cref="IslamicDateTime"/><br />
        /// 创建一个新的 <see cref="IslamicDateTime"/> 实例。
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <param name="second"></param>
        /// <param name="calendar"></param>
        /// <returns></returns>
        public static IslamicDateTime OfLunar(int year, int month, int day, int hour, int minute, int second, CalendarSystem calendar = null)
        {
            var ldt = new LocalDateTime(year, month, day, hour, minute, second, 0, calendar ?? _islamicCalendar);
            return new IslamicDateTime(ldt);
        }

        /// <summary>
        /// Create a new instance of <see cref="IslamicDateTime"/><br />
        /// 创建一个新的 <see cref="IslamicDateTime"/> 实例。
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <param name="second"></param>
        /// <param name="millisecond"></param>
        /// <param name="calendar"></param>
        /// <returns></returns>
        public static IslamicDateTime OfLunar(int year, int month, int day, int hour, int minute, int second, int millisecond, CalendarSystem calendar = null)
        {
            var ldt = new LocalDateTime(year, month, day, hour, minute, second, millisecond, calendar ?? _islamicCalendar);
            return new IslamicDateTime(ldt);
        }
    }
}