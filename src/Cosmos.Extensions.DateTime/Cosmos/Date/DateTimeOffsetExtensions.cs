using System;
using NodaTime;

namespace Cosmos.Date
{
    public static partial class DateTimeOffsetExtensions
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