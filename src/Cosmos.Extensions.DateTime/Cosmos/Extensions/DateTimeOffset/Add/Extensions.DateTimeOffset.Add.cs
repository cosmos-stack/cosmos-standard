using System;
using Cosmos.Date;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    /// <summary>
    /// DateTimeOffset Extensions<br />
    /// DateTimeOffset 扩展方法
    /// </summary>
    public static partial class DateTimeOffsetExtensions
    {
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
    }
}