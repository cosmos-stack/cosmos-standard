using System;
using NodaTime;

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
    }
}