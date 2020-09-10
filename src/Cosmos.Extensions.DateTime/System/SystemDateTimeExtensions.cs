using System.Globalization;
using Cosmos.Date;
using Cosmos.Verba.Time;
using NodaTime;

namespace System
{
    // ReSharper disable once IdentifierTypo
    using VERBA = GlobalTimeVerbaManager;

    /// <summary>
    /// Cosmos <see cref="DateTime"/> extensions
    /// </summary>
    public static class SystemDateTimeExtensions
    {
        #region Add

        /// <summary>
        /// Add weeks. <br />
        /// 添加一个星期。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="weeks"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static DateTime AddWeeks(this DateTime dt, int weeks)
        {
            if (dt == null)
                throw new ArgumentNullException(nameof(dt));

            return dt + weeks.Weeks();
        }

        /// <summary>
        /// Add quarters. <br />
        /// 添加一个季度。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="quarters"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static DateTime AddQuarters(this DateTime dt, int quarters)
        {
            if (dt == null)
                throw new ArgumentNullException(nameof(dt));

            return dt + quarters.Quarters();
        }

        /// <summary>
        /// Add duration. <br />
        /// 添加一段持续的时间
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        public static DateTime AddDuration(this DateTime dt, Duration duration)
        {
            if (dt == null)
                throw new ArgumentNullException(nameof(dt));

            return dt + duration.ToTimeSpan();
        }

        /// <summary>
        /// Add business days. <br />
        /// 添加指定个数量的工作日
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="days"></param>
        /// <returns></returns>
        public static DateTime AddBusinessDays(this DateTime dt, int days)
        {
            var sign = Math.Sign(days);
            var unsignedDays = Math.Abs(days);
            for (var i = 0; i < unsignedDays; i++)
            {
                do
                {
                    dt = dt.AddDays(sign);
                } while (dt.DayOfWeek == DayOfWeek.Saturday ||
                         dt.DayOfWeek == DayOfWeek.Sunday);
            }

            return dt;
        }

        /// <summary>
        /// Subtract business days. <br />
        /// 减去指定个数量的工作日
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="days"></param>
        /// <returns></returns>
        public static DateTime SubtractBusinessDays(this DateTime dt, int days) => AddBusinessDays(dt, -days);

        #endregion

        #region Age & Birthday

        /// <summary>
        /// Calculate the current age based on the given birthday time. <br />
        /// 根据给定的生日时间计算当前的年纪。
        /// </summary>
        /// <param name="birthday"></param>
        /// <returns></returns>
        public static int ToCalculateAge(this DateTime birthday) => birthday.ToCalculateAge(DateTime.Today);

        /// <summary>
        /// Calculate the age relative to another time based on a given birthday time. <br />
        /// 根据生日和参照时间，计算当时年纪
        /// </summary>
        /// <param name="birthday">     </param>
        /// <param name="referenceDate"></param>
        /// <returns></returns>
        public static int ToCalculateAge(this DateTime birthday, DateTime referenceDate)
        {
            var years = referenceDate.Year - birthday.Year;
            if (referenceDate.Month < birthday.Month || (referenceDate.Month == birthday.Month && referenceDate.Day < birthday.Day))
                --years;
            return years;
        }

        #endregion

        #region Ago

        /// <summary>
        /// 格式化时间间隔
        /// </summary>
        /// <param name="timeSpan">时间间隔</param>
        [Obsolete("将会被 Cosmos.I18N 取代")]
        public static string ToAgo(this TimeSpan timeSpan)
        {
            if (timeSpan < TimeSpan.Zero)
            {
                return VERBA.Future; //未来
            }

            if (timeSpan < TimeVerbaConstant.OneMinute)
            {
                return VERBA.Now; //现在
            }

            if (timeSpan < TimeVerbaConstant.TwoMinutes)
            {
                return $"1 {VERBA.Minutes}{VERBA.SpaceString}{VERBA.Ago}"; //1 分钟前
            }

            if (timeSpan < TimeVerbaConstant.OneHour)
            {
                return $"{timeSpan.Minutes} {VERBA.Minutes}{VERBA.ComplexString}{VERBA.SpaceString}{VERBA.Ago}"; //n 分钟前
            }

            if (timeSpan < TimeVerbaConstant.TwoHours)
            {
                return $"1 {VERBA.Hours}{VERBA.SpaceString}{VERBA.Ago}"; //1 小时前
            }

            if (timeSpan < TimeVerbaConstant.OneDay)
            {
                return $"{timeSpan.Hours} {VERBA.Hours}{VERBA.ComplexString}{VERBA.SpaceString}{VERBA.Ago}"; //n 小时前
            }

            if (timeSpan < TimeVerbaConstant.TwoDays)
            {
                return VERBA.Yesterday; //昨天
            }

            if (timeSpan < TimeVerbaConstant.OneWeek)
            {
                return $"{timeSpan.Days} {VERBA.Days}{VERBA.ComplexString}{VERBA.SpaceString}{VERBA.Ago}"; //n 天前
            }

            if (timeSpan < TimeVerbaConstant.TwoWeeks)
            {
                return $"1 {VERBA.Weeks}{VERBA.SpaceString}{VERBA.Ago}"; //1 周前
            }

            if (timeSpan < TimeVerbaConstant.OneMonth)
            {
                return $"{timeSpan.Days / 7} {VERBA.Weeks}{VERBA.ComplexString}{VERBA.SpaceString}{VERBA.Ago}"; //n 周前
            }

            if (timeSpan < TimeVerbaConstant.TwoMonths)
            {
                return $"1 {VERBA.Months}{VERBA.SpaceString}{VERBA.Ago}"; //1 月前
            }

            if (timeSpan < TimeVerbaConstant.OneYear)
            {
                return $"{timeSpan.Days / 31} {VERBA.Months}{VERBA.ComplexString}{VERBA.SpaceString}{VERBA.Ago}"; //n 月前
            }

            if (timeSpan < TimeVerbaConstant.TwoYears)
            {
                return $"1 {VERBA.Year}{VERBA.SpaceString}{VERBA.Ago}"; //1 年前
            }

            return $"{timeSpan.Days / 365} {VERBA.Year}{VERBA.ComplexString}{VERBA.SpaceString}{VERBA.Ago}"; //n 年前
        }

        /// <summary>
        /// 格式化时间间隔
        /// </summary>
        /// <param name="date">對比的時間</param>
        /// <returns></returns>
        [Obsolete("将会被 Cosmos.I18N 取代")]
        public static string ToAgo(this DateTime date)
        {
            return (DateTime.Now - date).ToAgo();
        }

        #endregion

        #region At

        /// <summary>
        /// At, to set hour, minute and second.<br />
        /// 时间，修改它的时分秒。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static DateTime At(this DateTime dt, int hour, int minute, int second) => dt.SetTime(hour, minute, second);

        /// <summary>
        /// At, to set hour, minute, second and milliseconds.<br />
        /// 时间，修改它的时分秒，以及毫秒。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <param name="second"></param>
        /// <param name="milliseconds"></param>
        /// <returns></returns>
        public static DateTime At(this DateTime dt, int hour, int minute, int second, int milliseconds) => dt.SetTime(hour, minute, second, milliseconds);

        #endregion

        #region Begin

        /// <summary>
        /// Beginning of day.<br />
        /// 获取一天的开始时间。
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime BeginningOfDay(this DateTime dt) =>
            DateTimeFactory.Create(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0, dt.Kind);

        /// <summary>
        /// Beginning of day.<br />
        /// 获取一天的开始时间。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="timeZoneOffset"></param>
        /// <returns></returns>
        public static DateTime BeginningOfDay(this DateTime dt, int timeZoneOffset) =>
            DateTimeFactory.Create(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0, dt.Kind).AddHours(timeZoneOffset);

        /// <summary>
        /// Beginning of week.<br />
        /// 获取一周的开始时间。
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime BeginningOfWeek(this DateTime dt) => dt.FirstDayOfWeek().BeginningOfDay();

        /// <summary>
        /// Beginning of week.<br />
        /// 获取一周的开始时间。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="timeZoneOffset"></param>
        /// <returns></returns>
        public static DateTime BeginningOfWeek(this DateTime dt, int timeZoneOffset) => dt.FirstDayOfWeek().BeginningOfDay(timeZoneOffset);

        /// <summary>
        /// Beginning of month.<br />
        /// 获取一个月的开始时间。
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime BeginningOfMonth(this DateTime dt) => dt.FirstDayOfMonth().BeginningOfDay();

        /// <summary>
        /// Beginning of month.<br />
        /// 获取一个月的开始时间。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="timeZoneOffset"></param>
        /// <returns></returns>
        public static DateTime BeginningOfMonth(this DateTime dt, int timeZoneOffset) => dt.FirstDayOfMonth().BeginningOfDay(timeZoneOffset);

        /// <summary>
        /// Beginning of quarter.<br />
        /// 获取一个季度的开始时间。
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime BeginningOfQuarter(this DateTime dt) => dt.FirstDayOfQuarter().BeginningOfDay();

        /// <summary>
        /// Beginning of quarter.<br />
        /// 获取一个季度的开始时间。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="timeZoneOffset"></param>
        /// <returns></returns>
        public static DateTime BeginningOfQuarter(this DateTime dt, int timeZoneOffset) => dt.FirstDayOfQuarter().BeginningOfDay(timeZoneOffset);

        /// <summary>
        /// Beginning of year.<br />
        /// 获取一年的开始时间。
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime BeginningOfYear(this DateTime dt) => dt.FirstDayOfYear().BeginningOfDay();

        /// <summary>
        /// Beginning of year.<br />
        /// 获取一年的开始时间。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="timeZoneOffset"></param>
        /// <returns></returns>
        public static DateTime BeginningOfYear(this DateTime dt, int timeZoneOffset) => dt.FirstDayOfYear().BeginningOfDay(timeZoneOffset);

        #endregion

        #region Clone

        /// <summary>
        /// Clone<br />
        /// 克隆
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime Clone(this DateTime dt) => new DateTime(dt.Ticks, dt.Kind);

        #endregion

        #region Diff

        /// <summary>
        /// Calculate the number of months between two dates.<br />
        /// 计算两个时间之间相差的月份数。
        /// </summary>
        /// <param name="dt1"></param>
        /// <param name="dt2"></param>
        /// <returns></returns>
        public static int GetMonthDiff(this DateTime dt1, DateTime dt2)
        {
            var l = dt1 < dt2 ? dt1 : dt2;
            var r = dt1 >= dt2 ? dt1 : dt2;
            return (l.Day == r.Day ? 0 : l.Day > r.Day ? 0 : 1)
                 + (l.Month == r.Month ? 0 : r.Month - l.Month)
                 + (l.Year == r.Year ? 0 : (r.Year - l.Year) * 12);
        }

        /// <summary>
        /// Calculate the exact number of months between two dates.<br />
        /// 计算两个日期之间相差的确切月份数。
        /// </summary>
        /// <param name="dt1"></param>
        /// <param name="dt2"></param>
        /// <returns></returns>
        public static double GetTotalMonthDiff(this DateTime dt1, DateTime dt2)
        {
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

        #region Elapsed

        /// <summary>
        /// Elapsed Time<br />
        /// 计算此刻与指定时间之间的时间差
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static TimeSpan ElapsedTime(this DateTime dt) => DateTime.Now - dt;

        /// <summary>
        /// Elapsed Time<br />
        /// 计算此刻与指定时间之间的时间差（毫秒）
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static int ElapsedMilliseconds(this DateTime dt) => (int) (DateTime.Now - dt).TotalMilliseconds;

        #endregion

        #region End

        /// <summary>
        /// End of day.<br />
        /// 获取一天中的结束时间。
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime EndOfDay(this DateTime dt) =>
            DateTimeFactory.Create(dt.Year, dt.Month, dt.Day, 23, 59, 59, 999, dt.Kind);

        /// <summary>
        /// End of day (timezone-adjusted).<br />
        /// 获取一天中的结束时间。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="timeZoneOffset"></param>
        /// <returns></returns>
        public static DateTime EndOfDay(this DateTime dt, int timeZoneOffset) =>
            DateTimeFactory.Create(dt.Year, dt.Month, dt.Day, 23, 59, 59, 999, dt.Kind).AddHours(timeZoneOffset);

        /// <summary>
        /// End of week.<br />
        /// 一周的结束时间。
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime EndOfWeek(this DateTime dt) => dt.LastDayOfWeek().EndOfDay();

        /// <summary>
        /// End of week.<br />
        /// 一周的结束时间。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="timeZoneOffset"></param>
        /// <returns></returns>
        public static DateTime EndOfWeek(this DateTime dt, int timeZoneOffset) => dt.LastDayOfWeek().EndOfDay(timeZoneOffset);

        /// <summary>
        /// End of month.<br />
        /// 一个月的结束时间。
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime EndOfMonth(this DateTime dt) => dt.LastDayOfMonth().EndOfDay();

        /// <summary>
        /// End of month.<br />
        /// 一个月的结束时间。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="timeZoneOffset"></param>
        /// <returns></returns>
        public static DateTime EndOfMonth(this DateTime dt, int timeZoneOffset) => dt.LastDayOfMonth().EndOfDay(timeZoneOffset);

        /// <summary>
        /// End of quarter.<br />
        /// 一个季度的结束时间。
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime EndOfQuarter(this DateTime dt) => dt.LastDayOfQuarter().EndOfDay();

        /// <summary>
        /// End of quarter.<br />
        /// 一个季度的结束时间。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="timeZoneOffset"></param>
        /// <returns></returns>
        public static DateTime EndOfQuarter(this DateTime dt, int timeZoneOffset) => dt.LastDayOfQuarter().EndOfDay(timeZoneOffset);

        /// <summary>
        /// End of year.<br />
        /// 一年的结束时间。
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime EndOfYear(this DateTime dt) => dt.LastDayOfYear().EndOfDay();

        /// <summary>
        /// End of year.<br />
        /// 一年的结束时间。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="timeZoneOffset"></param>
        /// <returns></returns>
        public static DateTime EndOfYear(this DateTime dt, int timeZoneOffset) => dt.LastDayOfYear().EndOfDay(timeZoneOffset);

        #endregion

        #region Get

        /// <summary>
        /// Gets two time intervals. <br />
        /// 获取两个时间之间的间隔。
        /// </summary>
        /// <param name="leftDt"></param>
        /// <param name="rightDt">  </param>
        /// <returns></returns>
        public static TimeSpan GetTimeSpan(this DateTime leftDt, DateTime rightDt)
            => rightDt - leftDt;

        /// <summary>
        /// Get the first day of the specified year. <br />
        /// 获取指定年份的第一天。
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime FirstDayOfYear(this DateTime dt) => dt.SetDate(dt.Year, 1, 1);

        /// <summary>
        /// Get the specified day of the first week of the specified year. <br />
        /// 获取指定年份的第一个礼拜指定的某一天。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateTime FirstDayOfYear(this DateTime dt, DayOfWeek dayOfWeek)
        {
            var ret = dt.FirstDayOfYear();
            return DayOfWeekCalc.TryDaysBetween(ret.DayOfWeek, dayOfWeek, out var day) && day > 0
                ? ret.AddDays(day)
                : ret;
        }

        /// <summary>
        /// Get the first day of the specified quarter. <br />
        /// 获取指定季度的第一天。
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime FirstDayOfQuarter(this DateTime dt)
        {
            var currentQuarter = dt.QuarterOfMonth();
            var month = 3 * currentQuarter - 2;
            return DateTimeFactory.Create(dt.Year, month, 1);
        }

        /// <summary>
        /// Get the specified day of the first week of the specified quarter. <br />
        /// 获取指定季度的第一个礼拜指定的某一天。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateTime FirstDayOfQuarter(this DateTime dt, DayOfWeek dayOfWeek)
        {
            var ret = dt.FirstDayOfQuarter();
            return DayOfWeekCalc.TryDaysBetween(ret.DayOfWeek, dayOfWeek, out var day) && day > 0
                ? ret.AddDays(day)
                : ret;
        }

        /// <summary>
        /// Get the first day of the specified month. <br />
        /// 获取指定月份的第一天。
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime FirstDayOfMonth(this DateTime dt) => dt.SetDay(1);

        /// <summary>
        /// Get the specified day of the first week of the specified month. <br />
        /// 获取指定月份的第一个礼拜指定的某一天。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateTime FirstDayOfMonth(this DateTime dt, DayOfWeek dayOfWeek)
        {
            var ret = dt.FirstDayOfMonth();
            return DayOfWeekCalc.TryDaysBetween(ret.DayOfWeek, dayOfWeek, out var day) && day > 0
                ? ret.AddDays(day)
                : ret;
        }

        /// <summary>
        /// Get the first day of the specified week. <br />
        /// 获取指礼拜的第一天。
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime FirstDayOfWeek(this DateTime dt) => dt.FirstDayOfWeek(null);

        /// <summary>
        /// Get the first day of the specified week. <br />
        /// 获取指礼拜的第一天。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public static DateTime FirstDayOfWeek(this DateTime dt, CultureInfo cultureInfo)
        {
            cultureInfo ??= CultureInfo.CurrentCulture;
            var firstDayOfWeek = cultureInfo.DateTimeFormat.FirstDayOfWeek;
            var offset = dt.DayOfWeek - firstDayOfWeek < 0 ? 7 : 0;
            var numberOfDaysSinceBeginningOfTheWeek = dt.DayOfWeek + offset - firstDayOfWeek;

            return dt.AddDays(-numberOfDaysSinceBeginningOfTheWeek);
        }

        /// <summary> 
        /// Get the last day of the specified year. <br />
        /// 获取指定年份的最后一天。
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime LastDayOfYear(this DateTime dt) => dt.SetDate(dt.Year, 12, 31);

        /// <summary>
        /// Get the specified day of the first week of the specified year. <br />
        /// 获取指定年份的最后一个礼拜指定的某一天。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateTime LastDayOfYear(this DateTime dt, DayOfWeek dayOfWeek)
        {
            var ret = dt.LastDayOfYear();
            return DayOfWeekCalc.TryDaysBetween(ret.DayOfWeek, dayOfWeek, out var day) && day == 0
                ? ret
                : ret.AddDays(-day);
        }

        /// <summary>
        /// Get the last day of the specified quarter. <br />
        /// 获取指定季度的最后一天。
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime LastDayOfQuarter(this DateTime dt)
        {
            var currentQuarter = dt.QuarterOfMonth();
            var month = 3 * currentQuarter;
            var day = DateTime.DaysInMonth(dt.Year, month);
            return DateTimeFactory.Create(dt.Year, month, day);
        }

        /// <summary>
        /// Get the specified day of the first week of the specified quarter. <br />
        /// 获取指定季度的最后一个礼拜指定的某一天。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateTime LastDayOfQuarter(this DateTime dt, DayOfWeek dayOfWeek)
        {
            var ret = dt.LastDayOfQuarter();
            return DayOfWeekCalc.TryDaysBetween(ret.DayOfWeek, dayOfWeek, out var day) && day == 0
                ? ret
                : ret.AddDays(-day);
        }

        /// <summary>
        /// Get the last day of the specified month. <br />
        /// 获取指定月份的最后一天。
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime LastDayOfMonth(this DateTime dt) => dt.SetDay(dt.DaysInMonth());

        /// <summary>
        /// Get the specified day of the first week of the specified month. <br />
        /// 获取指定月份的最后一个礼拜指定的某一天。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateTime LastDayOfMonth(this DateTime dt, DayOfWeek dayOfWeek)
        {
            var ret = dt.LastDayOfMonth();
            return DayOfWeekCalc.TryDaysBetween(ret.DayOfWeek, dayOfWeek, out var day) && day == 0
                ? ret
                : ret.AddDays(-day);
        }

        /// <summary>
        /// Get the last day of the specified week. <br />
        /// 获取指定礼拜的最后一天。
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime LastDayOfWeek(this DateTime dt) => dt.LastDayOfWeek(null);

        /// <summary>
        /// Get the last day of the specified week. <br />
        /// 获取指定礼拜的最后一天。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public static DateTime LastDayOfWeek(this DateTime dt, CultureInfo cultureInfo) => dt.FirstDayOfWeek(cultureInfo).AddDays(6);

        /// <summary>
        /// Get the number of days in the specified month.<br />
        /// 获取指定月份中的天数。
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static int DaysInMonth(this DateTime dt) => DateTime.DaysInMonth(dt.Year, dt.Month);

        /// <summary>
        /// Get the quarter of the specified month.<br />
        /// 获取指定月份是第几季度。
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static int QuarterOfMonth(this DateTime dt) => (dt.Month - 1) / 3 + 1;

        /// <summary>
        /// Get the specified week is the week of the year.<br />
        /// 获取指定的星期是一年中的第几个星期。
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static int GetWeekOfYear(this DateTime datetime)
            => GetWeekOfYear(datetime, new DateTimeFormatInfo().CalendarWeekRule, new DateTimeFormatInfo().FirstDayOfWeek);

        /// <summary>
        /// Get the specified week is the week of the year.<br />
        /// 获取指定的星期是一年中的第几个星期。
        /// </summary>
        /// <param name="datetime"></param>
        /// <param name="weekRule"></param>
        /// <returns></returns>
        public static int GetWeekOfYear(this DateTime datetime, CalendarWeekRule weekRule)
            => GetWeekOfYear(datetime, weekRule, new DateTimeFormatInfo().FirstDayOfWeek);

        /// <summary>
        /// Get the specified week is the week of the year.<br />
        /// 获取指定的星期是一年中的第几个星期。
        /// </summary>
        /// <param name="datetime"></param>
        /// <param name="firstDayOfWeek"></param>
        /// <returns></returns>
        public static int GetWeekOfYear(this DateTime datetime, DayOfWeek firstDayOfWeek)
            => GetWeekOfYear(datetime, new DateTimeFormatInfo().CalendarWeekRule, firstDayOfWeek);

        /// <summary>
        /// Get the specified week is the week of the year.<br />
        /// 获取指定的星期是一年中的第几个星期。
        /// </summary>
        /// <param name="datetime"></param>
        /// <param name="weekRule"></param>
        /// <param name="firstDayOfWeek"></param>
        /// <returns></returns>
        public static int GetWeekOfYear(this DateTime datetime, CalendarWeekRule weekRule, DayOfWeek firstDayOfWeek)
            => CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(datetime, weekRule, firstDayOfWeek);

        #endregion

        #region Is

        /// <summary>
        /// Is current date between <paramref name="from"/> and <paramref to="to"/>.<br />
        /// 判断当前日期是否在 from 和 to 之间
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="includeBoundary"></param>
        /// <returns></returns>
        public static bool IsBetween(this DateTime dt, DateTime from, DateTime to, bool includeBoundary = true)
        {
            return includeBoundary
                ? dt >= from && dt <= to
                : dt > from && dt < to;
        }

        /// <summary>
        /// Is current date between <paramref name="min"/> and <paramref name="max"/> with boundary.<br />
        /// 判断当前日期是否在 min 和 max 之间，闭包区间。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static bool IsDateBetweenWithBoundary(this DateTime dt, DateTime min, DateTime max)
            => dt.IsBetween(min, max.AddDays(+1), false);

        /// <summary>
        /// Is current date between <paramref name="min"/> and <paramref name="max"/> with boundary.<br />
        /// 判断当前日期是否在 min 和 max 之间，闭包区间。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static bool IsDateBetweenWithBoundary(this DateTime dt, DateTime? min, DateTime? max)
        {
            if (min.HasValue && max.HasValue)
                return dt.IsDateBetweenWithBoundary(min.Value, max.Value);

            if (min.HasValue)
                return dt >= min.Value;

            if (max.HasValue)
                return dt < max.Value.AddDays(+1);

            return true;
        }

        /// <summary>
        /// Is current date between <paramref name="min"/> and <paramref name="max"/> without boundary.<br />
        /// 判断当前日期是否在 min 和 max 之间，开区间。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static bool IsDateBetweenWithoutBoundary(this DateTime dt, DateTime min, DateTime max)
            => dt.IsBetween(min, max, false);

        /// <summary>
        /// Determine whether the given time is today. <br />
        /// 判断给定时间是否是今天。
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsToday(this DateTime date) => date.Date == DateTime.Today;

        /// <summary>
        /// Determine whether the given time is today. <br />
        /// 判断给定时间是否是今天。
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsToday(this DateTime? date) => date.GetValueOrDefault().Date == DateTime.Today;

        /// <summary>
        /// Determine whether the given time is morning. <br />
        /// 判断给定时间是否是早晨。
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static bool IsMorning(this DateTime dt)
        {
            var hour = dt.Hour;
            return 6 <= hour && hour < 12;
        }

        /// <summary>
        /// Determine whether the given time is early morning. <br />
        /// 判断给定时间是否是清晨。
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static bool IsEarlyMorning(this DateTime dt)
        {
            var hour = dt.Hour;
            return 0 <= hour && hour < 6;
        }

        /// <summary>
        /// Determine whether the given time is afternoon. <br />
        /// 判断给定时间是否是下午。
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static bool IsAfternoon(this DateTime dt)
        {
            var hour = dt.Hour;
            return 12 <= hour && hour < 18;
        }

        /// <summary>
        /// Determine whether the given time is dusk. <br />
        /// 判断给定时间是否是黄昏。
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static bool IsDusk(this DateTime dt)
        {
            var hour = dt.Hour;
            return 16 <= hour && hour < 19;
        }

        /// <summary>
        /// Determine whether the given time is evening. <br />
        /// 判断给定时间是否是夜晚。
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static bool IsEvening(this DateTime dt)
        {
            var hour = dt.Hour;
            return 18 < hour && hour <= 24 || 0 <= hour && hour < 6;
        }

        /// <summary>
        /// Determine whether the specified time is in the past relative to the specified time. <br />
        /// 判断指定时间是否相对给定时间的过去。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="toCompareWith"></param>
        /// <returns></returns>
        public static bool IsBefore(this DateTime dt, DateTime toCompareWith) => dt < toCompareWith;

        /// <summary>
        /// Determine whether the specified time is in the future relative to the specified time. <br />
        /// 判断指定时间是否相对给定时间的未来。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="toCompareWith"></param>
        /// <returns></returns>
        public static bool IsAfter(this DateTime dt, DateTime toCompareWith) => dt > toCompareWith;

        /// <summary>
        /// Determine whether the specified time is in the future relative to the specified time. <br />
        /// 判断指定时间是否相对给定时间的未来。
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static bool IsInTheFuture(this DateTime dt) => dt > DateTime.Now;

        /// <summary>
        /// Determine whether the specified time is in the past relative to the specified time. <br />
        /// 判断指定时间是否相对给定时间的过去。
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static bool IsInThePast(this DateTime dt) => dt < DateTime.Now;

        /// <summary>
        /// Is Weekday <br />
        /// 判断是否为工作日
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsWeekday(this DateTime date) => !date.IsWeekend();

        /// <summary>
        /// Is Weekday <br />
        /// 判断是否为工作日
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsWeekday(this DateTime? date) => date.GetValueOrDefault().IsWeekday();

        /// <summary>
        /// Is Weekday <br />
        /// 判断是否为周末
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsWeekend(this DateTime date) => date.DayOfWeek == DayOfWeek.Sunday || date.DayOfWeek == DayOfWeek.Saturday;

        /// <summary>
        /// Is Weekday <br />
        /// 判断是否为周末
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsWeekend(this DateTime? date) => date.GetValueOrDefault().IsWeekend();

        /// <summary>
        /// Is same day
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsSameDay(this DateTime dt, DateTime date) => dt.Date == date.Date;

        /// <summary>
        /// Is same month
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsSameMonth(this DateTime dt, DateTime date) => dt.Month == date.Month;

        /// <summary>
        /// Is same year
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsSameYear(this DateTime dt, DateTime date) => dt.Year == date.Year;

        /// <summary>
        /// Is date equal...
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsDateEqual(this DateTime dt, DateTime date) => dt.IsSameDay(date);

        /// <summary>
        /// Is time equal...
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsTimeEqual(this DateTime dt, DateTime date) => dt.TimeOfDay == date.TimeOfDay;

        #endregion

        #region Next and Previous

        /// <summary>
        /// Next year
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime NextYear(this DateTime dt)
        {
            var year = dt.Year + 1;
            var daysOfMonth = DateTime.DaysInMonth(year, dt.Month);

            if (daysOfMonth == dt.Day)
                return DateTimeFactory.Create(year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond, dt.Kind);

            var d = dt.Day - daysOfMonth;
            var p = DateTimeFactory.Create(year, dt.Month, daysOfMonth, dt.Hour, dt.Minute, dt.Second, dt.Millisecond, dt.Kind);
            return p + d.Days();
        }

        /// <summary>
        /// Previous Year
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime PreviousYear(this DateTime dt)
        {
            var year = dt.Year - 1;
            var daysOfMonth = DateTime.DaysInMonth(year, dt.Month);

            if (daysOfMonth == dt.Day)
                return DateTimeFactory.Create(year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond, dt.Kind);

            var d = dt.Day - daysOfMonth;
            var p = DateTimeFactory.Create(year, dt.Month, daysOfMonth, dt.Hour, dt.Minute, dt.Second, dt.Millisecond, dt.Kind);
            return p + d.Days();
        }

        /// <summary>
        /// Gets next month
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime NextMonth(this DateTime dt)
        {
            var year = dt.Month == 12 ? dt.Year + 1 : dt.Year;

            var month = dt.Month == 12 ? 1 : dt.Month + 1;

            var firstDayOfNextMonth = dt.SetDate(year, month, 1);

            var lastDayOfPreviousMonth = firstDayOfNextMonth.LastDayOfMonth().Day;

            var day = dt.Day > lastDayOfPreviousMonth ? lastDayOfPreviousMonth : dt.Day;

            return firstDayOfNextMonth.SetDay(day);
        }

        /// <summary>
        /// Gets previous month
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime PreviousMonth(this DateTime dt)
        {
            var year = dt.Month == 1 ? dt.Year - 1 : dt.Year;

            var month = dt.Month == 1 ? 12 : dt.Month - 1;

            var firstDayOfPreviousMonth = dt.SetDate(year, month, 1);

            var lastDayOfPreviousMonth = firstDayOfPreviousMonth.LastDayOfMonth().Day;

            var day = dt.Day > lastDayOfPreviousMonth ? lastDayOfPreviousMonth : dt.Day;

            return firstDayOfPreviousMonth.SetDay(day);
        }

        /// <summary>
        /// Next day
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime NextDay(this DateTime dt) => dt + 1.Days();

        /// <summary>
        /// Previous Day
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime PreviousDay(this DateTime dt) => dt - 1.Days();

        /// <summary>
        /// Tomorrow
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime Tomorrow(this DateTime dt) => dt.NextDay();

        /// <summary>
        /// Yesterday
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime Yesterday(this DateTime dt) => dt.PreviousDay();

        /// <summary>
        /// Next
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateTime NextDayOfWeek(this DateTime dt, DayOfWeek dayOfWeek)
        {
            var offset = DayOfWeekCalc.DaysBetween(dt.DayOfWeek, dayOfWeek);
            offset = offset == 0 ? 7 : offset;
            return dt.AddDays(offset);
        }

        /// <summary>
        /// Previous
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateTime PreviousDayOfWeek(this DateTime dt, DayOfWeek dayOfWeek)
        {
            var offset = DayOfWeekCalc.DaysBetween(dt.DayOfWeek, dayOfWeek);
            offset = offset == 0 ? 7 : offset;
            return dt.AddDays(-offset);
        }

        /// <summary>
        /// Week after
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime WeekAfter(this DateTime dt) => dt + 1.Weeks();

        /// <summary>
        /// Week before
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime WeekBefore(this DateTime dt) => dt - 1.Weeks();

        /// <summary>
        /// Increase time
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="toAdd"></param>
        /// <returns></returns>
        public static DateTime IncreaseTime(this DateTime dt, TimeSpan toAdd) => dt + toAdd;

        /// <summary>
        /// Decrease time
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="toSubtract"></param>
        /// <returns></returns>
        public static DateTime DecreaseTime(this DateTime dt, TimeSpan toSubtract) => dt - toSubtract;

        #endregion

        #region Round

        /// <summary>
        /// Round the time to the nearest value to the given precision. <br />
        /// 将时间四舍五入到最接近给定精度的值。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="rt"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static DateTime Round(this DateTime dt, RoundTo rt)
        {
            DateTime rounded;

            switch (rt)
            {
                case RoundTo.Second:
                {
                    rounded = new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Kind);
                    if (dt.Millisecond >= 500)
                    {
                        rounded = rounded.AddSeconds(1);
                    }

                    break;
                }
                case RoundTo.Minute:
                {
                    rounded = new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, 0, dt.Kind);
                    if (dt.Second >= 30)
                    {
                        rounded = rounded.AddMinutes(1);
                    }

                    break;
                }
                case RoundTo.Hour:
                {
                    rounded = new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, 0, 0, dt.Kind);
                    if (dt.Minute >= 30)
                    {
                        rounded = rounded.AddHours(1);
                    }

                    break;
                }
                case RoundTo.Day:
                {
                    rounded = new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0, dt.Kind);
                    if (dt.Hour >= 12)
                    {
                        rounded = rounded.AddDays(1);
                    }

                    break;
                }
                default:
                {
                    throw new ArgumentOutOfRangeException("rt");
                }
            }

            return rounded;
        }

        #endregion

        #region Set

        /// <summary>
        /// Set the hour for the given time. <br />
        /// 对给定的时间设置小时。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="hour"></param>
        /// <returns></returns>
        public static DateTime SetTime(this DateTime dt, int hour) =>
            DateTimeFactory.Create(dt.Year, dt.Month, dt.Day, hour, dt.Minute, dt.Second, dt.Millisecond, dt.Kind);

        /// <summary>
        /// Set the hour and minute for the given time. <br />
        /// 对给定的时间设置时分。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <returns></returns>
        public static DateTime SetTime(this DateTime dt, int hour, int minute) =>
            DateTimeFactory.Create(dt.Year, dt.Month, dt.Day, hour, minute, dt.Second, dt.Millisecond, dt.Kind);

        /// <summary>
        /// Set the hour, minute and second for the given time. <br />
        /// 对给定的时间设置时分秒。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static DateTime SetTime(this DateTime dt, int hour, int minute, int second) =>
            DateTimeFactory.Create(dt.Year, dt.Month, dt.Day, hour, minute, second, dt.Millisecond, dt.Kind);

        /// <summary>
        /// Set the hour, minute, second and millisecond for the given time. <br />
        /// 对给定的时间设置时分秒和毫秒。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <param name="second"></param>
        /// <param name="millisecond"></param>
        /// <returns></returns>
        public static DateTime SetTime(this DateTime dt, int hour, int minute, int second, int millisecond) =>
            DateTimeFactory.Create(dt.Year, dt.Month, dt.Day, hour, minute, second, millisecond, dt.Kind);

        /// <summary>
        /// Set the hour for the given time. <br />
        /// 对给定的时间设置小时。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="hour"></param>
        /// <returns></returns>
        public static DateTime SetHour(this DateTime dt, int hour) =>
            DateTimeFactory.Create(dt.Year, dt.Month, dt.Day, hour, dt.Minute, dt.Second, dt.Millisecond, dt.Kind);

        /// <summary>
        /// Set the minute for the given time. <br />
        /// 对给定的时间设置分钟。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="minute"></param>
        /// <returns></returns>
        public static DateTime SetMinute(this DateTime dt, int minute) =>
            DateTimeFactory.Create(dt.Year, dt.Month, dt.Day, dt.Hour, minute, dt.Second, dt.Millisecond, dt.Kind);

        /// <summary>
        /// Set the second for the given time. <br />
        /// 对给定的时间设置秒。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static DateTime SetSecond(this DateTime dt, int second) =>
            DateTimeFactory.Create(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, second, dt.Millisecond, dt.Kind);

        /// <summary>
        /// Set the millisecond for the given time. <br />
        /// 对给定的时间设置毫秒。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="millisecond"></param>
        /// <returns></returns>
        public static DateTime SetMillisecond(this DateTime dt, int millisecond) =>
            DateTimeFactory.Create(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, millisecond, dt.Kind);

        /// <summary>
        /// Set the given time to midnight. <br />
        /// 将给定的时间设置为午夜。
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime Midnight(this DateTime dt) => dt.BeginningOfDay();

        /// <summary>
        /// Set the given time to noon. <br />
        /// 将给定的时间设置为正午。
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime Noon(this DateTime dt) => dt.SetTime(12, 0, 0, 0);

        /// <summary>
        /// Set the year for the given time. <br />
        /// 对给定的时间设置年份。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime SetDate(this DateTime dt, int year) =>
            DateTimeFactory.Create(year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond, dt.Kind);

        /// <summary>
        /// Set the year and month for the given time. <br />
        /// 对给定的时间设置年份和月份。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public static DateTime SetDate(this DateTime dt, int year, int month) =>
            DateTimeFactory.Create(year, month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond, dt.Kind);

        /// <summary>
        /// Set the year, month and day for the given time. <br />
        /// 对给定的时间设置年月日。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public static DateTime SetDate(this DateTime dt, int year, int month, int day) =>
            DateTimeFactory.Create(year, month, day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond, dt.Kind);

        /// <summary>
        /// Set the year for the given time. <br />
        /// 对给定的时间设置年份。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime SetYear(this DateTime dt, int year) =>
            DateTimeFactory.Create(year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond, dt.Kind);

        /// <summary>
        /// Set the month for the given time. <br />
        /// 对给定的时间设置月份。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public static DateTime SetMonth(this DateTime dt, int month) =>
            DateTimeFactory.Create(dt.Year, month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond, dt.Kind);

        /// <summary>
        /// Set the day for the given time. <br />
        /// 对给定的时间设置日。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public static DateTime SetDay(this DateTime dt, int day) =>
            DateTimeFactory.Create(dt.Year, dt.Month, day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond, dt.Kind);

        /// <summary>
        /// Set kind
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="kind"></param>
        /// <returns></returns>
        public static DateTime SetKind(this DateTime dt, DateTimeKind kind) =>
            DateTimeFactory.Create(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond, kind);

        #endregion

        #region To

        /// <summary>
        /// Convert to utc date<br />
        /// 转换为 UTC 时间
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime ToUtc(this DateTime date) => new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, DateTimeKind.Utc);

        /// <summary>
        /// Convert <see cref="DateTime"/> to <see cref="DateInfo"/>.<br />
        /// 将 <see cref="DateTime"/> 转换为 <see cref="DateInfo"/>。
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateInfo ToDateInfo(this DateTime date) => new DateInfo(date);

        /// <summary>
        /// Convert <see cref="DateTime"/> to <see cref="LocalDateTime"/>.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static LocalDateTime ToLocalDateTime(this DateTime dateTime) => LocalDateTime.FromDateTime(dateTime);

        /// <summary>
        /// Convert <see cref="DateTime"/> to <see cref="LocalDate"/>.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static LocalDate ToLocalDate(this DateTime date) => LocalDate.FromDateTime(date);

        /// <summary>
        /// Convert <see cref="DateTime"/> to <see cref="LocalTime"/>.
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static LocalTime ToLocalTime(this DateTime t) => new LocalTime(t.Hour, t.Minute, t.Second, t.Millisecond);

        /// <summary>
        /// Convert <see cref="DateTime"/> to Epoch time span.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static TimeSpan ToEpochTimeSpan(this DateTime dt) => dt.Subtract(DateTimeFactory.Create(1970, 1, 1));

        #endregion
    }
}