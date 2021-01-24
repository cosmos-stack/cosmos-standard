using System;
using Cosmos.Verba.Time;
using NodaTime;

namespace Cosmos.Date
{
    // ReSharper disable once IdentifierTypo
    using VERBA = GlobalTimeVerbaManager;

    public static partial class DateTimeExtensions
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
            return DateTimeCalc.OffsetByWeeks(dt, weeks);
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
            return DateTimeCalc.OffsetByQuarters(dt, quarters);
        }

        /// <summary>
        /// Add duration. <br />
        /// 添加一段持续的时间
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        public static DateTime AddDuration(this DateTime dt, Duration duration) => DateTimeCalc.OffsetByDuration(dt, duration);

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

        #region Clone

        /// <summary>
        /// Clone<br />
        /// 克隆
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime Clone(this DateTime dt) => new(dt.Ticks, dt.Kind);

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

        #region To

        /// <summary>
        /// Convert to utc date<br />
        /// 转换为 UTC 时间
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime ToUtc(this DateTime date)
        {
            return new(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, DateTimeKind.Utc);
        }

        /// <summary>
        /// Convert <see cref="DateTime"/> to <see cref="DateInfo"/>.<br />
        /// 将 <see cref="DateTime"/> 转换为 <see cref="DateInfo"/>。
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateInfo ToDateInfo(this DateTime date)
        {
            return new(date);
        }

        /// <summary>
        /// Convert <see cref="DateTime"/> to Epoch time span.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static TimeSpan ToEpochTimeSpan(this DateTime dt)
        {
            return dt.Subtract(DateTimeFactory.Create(1970, 1, 1));
        }

        /// <summary>
        /// Convert <see cref="DateTime"/> to <see cref="LocalDateTime"/>.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static LocalDateTime ToLocalDateTime(this DateTime dateTime)
        {
            return LocalDateTime.FromDateTime(dateTime);
        }

        /// <summary>
        /// Convert <see cref="DateTime"/> to <see cref="LocalDate"/>.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static LocalDate ToLocalDate(this DateTime date)
        {
            return LocalDate.FromDateTime(date);
        }

        /// <summary>
        /// Convert <see cref="DateTime"/> to <see cref="LocalTime"/>.
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static LocalTime ToLocalTime(this DateTime t)
        {
            return new(t.Hour, t.Minute, t.Second, t.Millisecond);
        }

        #endregion
    }
}