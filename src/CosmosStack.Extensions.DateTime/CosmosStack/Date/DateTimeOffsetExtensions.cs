using System;
using System.Runtime.CompilerServices;
using NodaTime;

namespace CosmosStack.Date
{
    /// <summary>
    /// DateTimeOffset Extensions <br />
    /// DateTimeOffset 扩展
    /// </summary>
    public static partial class DateTimeOffsetExtensions
    {
        #region Add

        /// <summary>
        /// Add DateTmeSpan <br />
        /// 加一个 DateTimeSpan
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="timeSpan"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTimeOffset AddDateTimeSpan(this DateTimeOffset dto, DateTimeSpan timeSpan)
        {
            return dto.AddMonths(timeSpan.Months)
                      .AddYears(timeSpan.Years)
                      .Add(timeSpan.TimeSpan);
        }

        /// <summary>
        /// Subtract DateTmeSpan <br />
        /// 减一个 DateTimeSpan
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="timeSpan"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTimeOffset SubtractDateTimeSpan(this DateTimeOffset dto, DateTimeSpan timeSpan)
        {
            return dto.AddMonths(-timeSpan.Months)
                      .AddYears(-timeSpan.Years)
                      .Subtract(timeSpan.TimeSpan);
        }

        /// <summary>
        /// Add business day <br />
        /// 加一个工作日
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
        /// Subtract business day <br />
        /// 减一个工作日
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="days"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTimeOffset SubtractBusinessDays(this DateTimeOffset dto, int days) => AddBusinessDays(dto, -days);

        #endregion
        
        #region Is

        /// <summary>
        /// Is  <br />
        /// 判断指定
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsToday(this DateTimeOffset dto) => dto.Date == DateTime.Today;

        /// <summary>
        /// Is today <br />
        /// 判断是否为今天
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsToday(this DateTimeOffset? dto) => dto.GetValueOrDefault().Date == DateTime.Today;

        /// <summary>
        /// Is before <br />
        /// 判断是否为过去
        /// </summary>
        /// <param name="current"></param>
        /// <param name="toCompareWith"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsBefore(this DateTimeOffset current, DateTimeOffset toCompareWith) => current < toCompareWith;

        /// <summary>
        /// Is after <br />
        /// 判断是否为未来
        /// </summary>
        /// <param name="current"></param>
        /// <param name="toCompareWith"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsAfter(this DateTimeOffset current, DateTimeOffset toCompareWith) => current > toCompareWith;

        /// <summary>
        /// Is in future <br />
        /// 判断是否为未来
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsInFuture(this DateTimeOffset dateTime) => dateTime > DateTimeOffset.Now;

        /// <summary>
        /// Is in past <br />
        /// 判断是否为过去
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsInPast(this DateTimeOffset dateTime) => dateTime < DateTimeOffset.Now;

        /// <summary>
        /// Is same day <br />
        /// 判断是否为同一天
        /// </summary>
        /// <param name="current"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsSameDay(this DateTimeOffset current, DateTimeOffset date) => current.Date == date.Date;

        /// <summary>
        /// Is same month <br />
        /// 判断是否为同一个月
        /// </summary>
        /// <param name="current"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsSameMonth(this DateTimeOffset current, DateTimeOffset date) => current.Month == date.Month && current.Year == date.Year;

        /// <summary>
        /// Is same year <br />
        /// 判断是否为同一年
        /// </summary>
        /// <param name="current"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsSameYear(this DateTimeOffset current, DateTimeOffset date) => current.Year == date.Year;

        #endregion

        #region Round

        /// <summary>
        /// Round <br />
        /// 舍入
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
        /// Replace offset from DateTimeZone leniently <br />
        /// 轻松替换 DateTimeZone 的偏移量
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="dateTimeZone"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTimeOffset ReplaceOffsetFromDateTimeZoneLeniently(this DateTimeOffset dto, DateTimeZone dateTimeZone)
            => dto.DateTime.ApplyDateTimeZoneLeniently(dateTimeZone);

        /// <summary>
        /// Replace offset from DateTimeZone strictly <br />
        /// 严格替换 DateTimeZone 的偏移量
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="dateTimeZone"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTimeOffset ReplaceOffsetFromDateTimeZoneStrictly(this DateTimeOffset dto, DateTimeZone dateTimeZone)
            => dto.DateTime.ApplyDateTimeZoneStrictly(dateTimeZone);

        #endregion
    }
}