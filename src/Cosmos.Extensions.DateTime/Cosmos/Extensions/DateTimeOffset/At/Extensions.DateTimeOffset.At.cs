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
    }
}