using System.Globalization;
using Cosmos.Date;
using NodaTime;

namespace System
{
    /// <summary>
    /// Cosmos <see cref="DateTimeOffset"/> extensions.
    /// </summary>
    public static class SystemDateTimeOffsetExtensions
    {
        #region Add

        /// <summary>
        /// Add DateTmeSpan
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="timeSpan"></param>
        /// <returns></returns>
        public static DateTimeOffset AddDateTimeSpan(this DateTimeOffset dto, DateTimeSpan timeSpan)
        {
            return dto.AddMonths(timeSpan.Months)
                .AddYears(timeSpan.Years)
                .Add(timeSpan.TimeSpan);
        }

        /// <summary>
        /// Subtract DateTmeSpan
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="timeSpan"></param>
        /// <returns></returns>
        public static DateTimeOffset SubtractDateTimeSpan(this DateTimeOffset dto, DateTimeSpan timeSpan)
        {
            return dto.AddMonths(-timeSpan.Months)
                .AddYears(-timeSpan.Years)
                .Subtract(timeSpan.TimeSpan);
        }

        /// <summary>
        /// Add business day
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="days"></param>
        /// <returns></returns>
        public static DateTimeOffset AddBusinessDays(this DateTimeOffset dto, int days)
        {
            var sign = Math.Sign(days);
            var unsignedDays = Math.Abs(days);
            for (var i = 0; i < unsignedDays; i++)
            {
                do
                {
                    dto = dto.AddDays(sign);
                } while (dto.DayOfWeek == DayOfWeek.Saturday ||
                         dto.DayOfWeek == DayOfWeek.Sunday);
            }

            return dto;
        }

        /// <summary>
        /// Subtract business day
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="days"></param>
        /// <returns></returns>
        public static DateTimeOffset SubtractBusinessDays(this DateTimeOffset dto, int days)
        {
            return AddBusinessDays(dto, -days);
        }

        #endregion

        #region At

        /// <summary>
        /// At
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <returns></returns>
        public static DateTimeOffset At(this DateTimeOffset dto, int hour, int minute)
        {
            return dto.SetTime(hour, minute);
        }

        /// <summary>
        /// At
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static DateTimeOffset At(this DateTimeOffset dto, int hour, int minute, int second)
        {
            return dto.SetTime(hour, minute, second);
        }

        /// <summary>
        /// At
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <param name="second"></param>
        /// <param name="milliseconds"></param>
        /// <returns></returns>
        public static DateTimeOffset At(this DateTimeOffset dto, int hour, int minute, int second, int milliseconds)
        {
            return dto.SetTime(hour, minute, second, milliseconds);
        }

        #endregion

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

        #region Is

        /// <summary>
        /// 判断指定
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static bool IsToday(this DateTimeOffset dto) => dto.Date == DateTime.Today;

        /// <summary>
        /// 判断指定
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static bool IsToday(this DateTimeOffset? dto) => dto.GetValueOrDefault().Date == DateTime.Today;

        /// <summary>
        /// Is before
        /// </summary>
        /// <param name="current"></param>
        /// <param name="toCompareWith"></param>
        /// <returns></returns>
        public static bool IsBefore(this DateTimeOffset current, DateTimeOffset toCompareWith)
        {
            return current < toCompareWith;
        }

        /// <summary>
        /// Is after
        /// </summary>
        /// <param name="current"></param>
        /// <param name="toCompareWith"></param>
        /// <returns></returns>
        public static bool IsAfter(this DateTimeOffset current, DateTimeOffset toCompareWith)
        {
            return current > toCompareWith;
        }

        /// <summary>
        /// Is in future
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static bool IsInFuture(this DateTimeOffset dateTime)
        {
            return dateTime > DateTimeOffset.Now;
        }

        /// <summary>
        /// Is in past
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static bool IsInPast(this DateTimeOffset dateTime)
        {
            return dateTime < DateTimeOffset.Now;
        }

        /// <summary>
        /// Is same day
        /// </summary>
        /// <param name="current"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsSameDay(this DateTimeOffset current, DateTimeOffset date)
        {
            return current.Date == date.Date;
        }

        /// <summary>
        /// Is same month
        /// </summary>
        /// <param name="current"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsSameMonth(this DateTimeOffset current, DateTimeOffset date)
        {
            return current.Month == date.Month && current.Year == date.Year;
        }

        /// <summary>
        /// Is same year
        /// </summary>
        /// <param name="current"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsSameYear(this DateTimeOffset current, DateTimeOffset date)
        {
            return current.Year == date.Year;
        }

        #endregion

        #region Next and Previous

        /// <summary>
        /// Next year
        /// </summary>
        /// <param name="start"></param>
        /// <returns></returns>
        public static DateTimeOffset NextYear(this DateTimeOffset start)
        {
            var nextYear = start.Year + 1;
            var numberOfDaysInSameMonthNextYear = DateTime.DaysInMonth(nextYear, start.Month);

            if (numberOfDaysInSameMonthNextYear < start.Day)
            {
                var differenceInDays = start.Day - numberOfDaysInSameMonthNextYear;
                var dateTimeOffset = new DateTimeOffset(nextYear, start.Month, numberOfDaysInSameMonthNextYear, start.Hour, start.Minute, start.Second, start.Millisecond,
                    start.Offset);
                return dateTimeOffset + differenceInDays.Days();
            }

            return new DateTimeOffset(nextYear, start.Month, start.Day, start.Hour, start.Minute, start.Second, start.Millisecond, start.Offset);
        }

        /// <summary>
        /// Previous year
        /// </summary>
        /// <param name="start"></param>
        /// <returns></returns>
        public static DateTimeOffset PreviousYear(this DateTimeOffset start)
        {
            var previousYear = start.Year - 1;
            var numberOfDaysInSameMonthPreviousYear = DateTime.DaysInMonth(previousYear, start.Month);

            if (numberOfDaysInSameMonthPreviousYear < start.Day)
            {
                var differenceInDays = start.Day - numberOfDaysInSameMonthPreviousYear;
                var dateTime = new DateTimeOffset(previousYear, start.Month, numberOfDaysInSameMonthPreviousYear, start.Hour, start.Minute, start.Second, start.Millisecond,
                    start.Offset);
                return dateTime + differenceInDays.Days();
            }

            return new DateTimeOffset(previousYear, start.Month, start.Day, start.Hour, start.Minute, start.Second, start.Millisecond, start.Offset);
        }

        /// <summary>
        /// Next month
        /// </summary>
        /// <param name="current"></param>
        /// <returns></returns>
        public static DateTimeOffset NextMonth(this DateTimeOffset current)
        {
            var year = current.Month == 12 ? current.Year + 1 : current.Year;

            var month = current.Month == 12 ? 1 : current.Month + 1;

            var firstDayOfNextMonth = current.SetDate(year, month, 1);

            var lastDayOfPreviousMonth = firstDayOfNextMonth.LastDayOfMonth().Day;

            var day = current.Day > lastDayOfPreviousMonth ? lastDayOfPreviousMonth : current.Day;

            return firstDayOfNextMonth.SetDay(day);
        }

        /// <summary>
        /// Previous month
        /// </summary>
        /// <param name="current"></param>
        /// <returns></returns>
        public static DateTimeOffset PreviousMonth(this DateTimeOffset current)
        {
            var year = current.Month == 1 ? current.Year - 1 : current.Year;

            var month = current.Month == 1 ? 12 : current.Month - 1;

            var firstDayOfPreviousMonth = current.SetDate(year, month, 1);

            var lastDayOfPreviousMonth = firstDayOfPreviousMonth.LastDayOfMonth().Day;

            var day = current.Day > lastDayOfPreviousMonth ? lastDayOfPreviousMonth : current.Day;

            return firstDayOfPreviousMonth.SetDay(day);
        }

        /// <summary>
        /// Next day
        /// </summary>
        /// <param name="start"></param>
        /// <returns></returns>
        public static DateTimeOffset NextDay(this DateTimeOffset start)
        {
            return start + 1.Days();
        }

        /// <summary>
        /// Previous day
        /// </summary>
        /// <param name="start"></param>
        /// <returns></returns>
        public static DateTimeOffset PreviousDay(this DateTimeOffset start)
        {
            return start - 1.Days();
        }

        /// <summary>
        /// Next
        /// </summary>
        /// <param name="start"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public static DateTimeOffset Next(this DateTimeOffset start, DayOfWeek day)
        {
            do
            {
                start = start.NextDay();
            } while (start.DayOfWeek != day);

            return start;
        }

        /// <summary>
        /// Previous
        /// </summary>
        /// <param name="start"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public static DateTimeOffset Previous(this DateTimeOffset start, DayOfWeek day)
        {
            do
            {
                start = start.PreviousDay();
            } while (start.DayOfWeek != day);

            return start;
        }

        /// <summary>
        /// Increase Time
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="toAdd"></param>
        /// <returns></returns>
        public static DateTimeOffset IncreaseTime(this DateTimeOffset startDate, TimeSpan toAdd)
        {
            return startDate + toAdd;
        }

        /// <summary>
        /// Decrease Time
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="toSubtract"></param>
        /// <returns></returns>
        public static DateTimeOffset DecreaseTime(this DateTimeOffset startDate, TimeSpan toSubtract)
        {
            return startDate - toSubtract;
        }

        #endregion

        #region Round

        /// <summary>
        /// Round
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="rt"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static DateTimeOffset Round(this DateTimeOffset dateTime, RoundTo rt)
        {
            DateTimeOffset rounded;

            switch (rt)
            {
                case RoundTo.Second:
                {
                    rounded = new DateTimeOffset(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second, dateTime.Offset);
                    if (dateTime.Millisecond >= 500)
                    {
                        rounded = rounded.AddSeconds(1);
                    }

                    break;
                }
                case RoundTo.Minute:
                {
                    rounded = new DateTimeOffset(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, 0, dateTime.Offset);
                    if (dateTime.Second >= 30)
                    {
                        rounded = rounded.AddMinutes(1);
                    }

                    break;
                }
                case RoundTo.Hour:
                {
                    rounded = new DateTimeOffset(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, 0, 0, dateTime.Offset);
                    if (dateTime.Minute >= 30)
                    {
                        rounded = rounded.AddHours(1);
                    }

                    break;
                }
                case RoundTo.Day:
                {
                    rounded = new DateTimeOffset(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0, dateTime.Offset);
                    if (dateTime.Hour >= 12)
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
        /// Set time
        /// </summary>
        /// <param name="originalDate"></param>
        /// <param name="hour"></param>
        /// <returns></returns>
        public static DateTimeOffset SetTime(this DateTimeOffset originalDate, int hour)
        {
            return new DateTimeOffset(originalDate.Year, originalDate.Month, originalDate.Day, hour, originalDate.Minute, originalDate.Second, originalDate.Millisecond,
                originalDate.Offset);
        }

        /// <summary>
        /// Set time
        /// </summary>
        /// <param name="originalDate"></param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <returns></returns>
        public static DateTimeOffset SetTime(this DateTimeOffset originalDate, int hour, int minute)
        {
            return new DateTimeOffset(originalDate.Year, originalDate.Month, originalDate.Day, hour, minute, originalDate.Second, originalDate.Millisecond, originalDate.Offset);
        }

        /// <summary>
        /// Set time
        /// </summary>
        /// <param name="originalDate"></param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static DateTimeOffset SetTime(this DateTimeOffset originalDate, int hour, int minute, int second)
        {
            return new DateTimeOffset(originalDate.Year, originalDate.Month, originalDate.Day, hour, minute, second, originalDate.Millisecond, originalDate.Offset);
        }

        /// <summary>
        /// Set time
        /// </summary>
        /// <param name="originalDate"></param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <param name="second"></param>
        /// <param name="millisecond"></param>
        /// <returns></returns>
        public static DateTimeOffset SetTime(this DateTimeOffset originalDate, int hour, int minute, int second, int millisecond)
        {
            return new DateTimeOffset(originalDate.Year, originalDate.Month, originalDate.Day, hour, minute, second, millisecond, originalDate.Offset);
        }

        /// <summary>
        /// Set hour
        /// </summary>
        /// <param name="originalDate"></param>
        /// <param name="hour"></param>
        /// <returns></returns>
        public static DateTimeOffset SetHour(this DateTimeOffset originalDate, int hour)
        {
            return new DateTimeOffset(originalDate.Year, originalDate.Month, originalDate.Day, hour, originalDate.Minute, originalDate.Second, originalDate.Millisecond,
                originalDate.Offset);
        }

        /// <summary>
        /// Set minute
        /// </summary>
        /// <param name="originalDate"></param>
        /// <param name="minute"></param>
        /// <returns></returns>
        public static DateTimeOffset SetMinute(this DateTimeOffset originalDate, int minute)
        {
            return new DateTimeOffset(originalDate.Year, originalDate.Month, originalDate.Day, originalDate.Hour, minute, originalDate.Second, originalDate.Millisecond,
                originalDate.Offset);
        }

        /// <summary>
        /// Set second
        /// </summary>
        /// <param name="originalDate"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static DateTimeOffset SetSecond(this DateTimeOffset originalDate, int second)
        {
            return new DateTimeOffset(originalDate.Year, originalDate.Month, originalDate.Day, originalDate.Hour, originalDate.Minute, second, originalDate.Millisecond,
                originalDate.Offset);
        }

        /// <summary>
        /// Set millisecond
        /// </summary>
        /// <param name="originalDate"></param>
        /// <param name="millisecond"></param>
        /// <returns></returns>
        public static DateTimeOffset SetMillisecond(this DateTimeOffset originalDate, int millisecond)
        {
            return new DateTimeOffset(originalDate.Year, originalDate.Month, originalDate.Day, originalDate.Hour, originalDate.Minute, originalDate.Second, millisecond,
                originalDate.Offset);
        }

        /// <summary>
        /// Set date
        /// </summary>
        /// <param name="value"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTimeOffset SetDate(this DateTimeOffset value, int year)
        {
            return new DateTimeOffset(year, value.Month, value.Day, value.Hour, value.Minute, value.Second, value.Millisecond, value.Offset);
        }

        /// <summary>
        /// Set date
        /// </summary>
        /// <param name="value"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public static DateTimeOffset SetDate(this DateTimeOffset value, int year, int month)
        {
            return new DateTimeOffset(year, month, value.Day, value.Hour, value.Minute, value.Second, value.Millisecond, value.Offset);
        }

        /// <summary>
        /// Set date
        /// </summary>
        /// <param name="value"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public static DateTimeOffset SetDate(this DateTimeOffset value, int year, int month, int day)
        {
            return new DateTimeOffset(year, month, day, value.Hour, value.Minute, value.Second, value.Millisecond, value.Offset);
        }

        /// <summary>
        /// Set year
        /// </summary>
        /// <param name="value"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTimeOffset SetYear(this DateTimeOffset value, int year)
        {
            return new DateTimeOffset(year, value.Month, value.Day, value.Hour, value.Minute, value.Second, value.Millisecond, value.Offset);
        }

        /// <summary>
        /// Set month
        /// </summary>
        /// <param name="value"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public static DateTimeOffset SetMonth(this DateTimeOffset value, int month)
        {
            return new DateTimeOffset(value.Year, month, value.Day, value.Hour, value.Minute, value.Second, value.Millisecond, value.Offset);
        }

        /// <summary>
        /// Set day
        /// </summary>
        /// <param name="value"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public static DateTimeOffset SetDay(this DateTimeOffset value, int day)
        {
            return new DateTimeOffset(value.Year, value.Month, day, value.Hour, value.Minute, value.Second, value.Millisecond, value.Offset);
        }

        #endregion

        #region Zone

        /// <summary>
        /// Replace offset from DateTimeZone leniently
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="dateTimeZone"></param>
        /// <returns></returns>
        public static DateTimeOffset ReplaceOffsetFromDateTimeZoneLeniently(this DateTimeOffset dto, DateTimeZone dateTimeZone)
            => dto.DateTime.ApplyDateTimeZoneLeniently(dateTimeZone);

        /// <summary>
        /// Replace offset from DateTimeZone strictly
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="dateTimeZone"></param>
        /// <returns></returns>
        public static DateTimeOffset ReplaceOffsetFromDateTimeZoneStrictly(this DateTimeOffset dto, DateTimeZone dateTimeZone)
            => dto.DateTime.ApplyDateTimeZoneStrictly(dateTimeZone);

        #endregion
    }
}