using System;

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
        /// End of day
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static DateTimeOffset EndOfDay(this DateTimeOffset dto)
        {
            return new DateTimeOffset(dto.Year, dto.Month, dto.Day, 23, 59, 59, 999, dto.Offset);
        }
    }
}