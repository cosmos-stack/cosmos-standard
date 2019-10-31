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
        /// Set time
        /// </summary>
        /// <param name="originalDate"></param>
        /// <param name="hour"></param>
        /// <returns></returns>
        public static DateTimeOffset SetTime(this DateTimeOffset originalDate, int hour)
        {
            return new DateTimeOffset(originalDate.Year, originalDate.Month, originalDate.Day, hour, originalDate.Minute, originalDate.Second, originalDate.Millisecond, originalDate.Offset);
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
            return new DateTimeOffset(originalDate.Year, originalDate.Month, originalDate.Day, hour, originalDate.Minute, originalDate.Second, originalDate.Millisecond, originalDate.Offset);
        }
        
        /// <summary>
        /// Set minute
        /// </summary>
        /// <param name="originalDate"></param>
        /// <param name="minute"></param>
        /// <returns></returns>
        public static DateTimeOffset SetMinute(this DateTimeOffset originalDate, int minute)
        {
            return new DateTimeOffset(originalDate.Year, originalDate.Month, originalDate.Day, originalDate.Hour, minute, originalDate.Second, originalDate.Millisecond, originalDate.Offset);
        }
        
        /// <summary>
        /// Set second
        /// </summary>
        /// <param name="originalDate"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static DateTimeOffset SetSecond(this DateTimeOffset originalDate, int second)
        {
            return new DateTimeOffset(originalDate.Year, originalDate.Month, originalDate.Day, originalDate.Hour, originalDate.Minute, second, originalDate.Millisecond, originalDate.Offset);
        }

        /// <summary>
        /// Set millisecond
        /// </summary>
        /// <param name="originalDate"></param>
        /// <param name="millisecond"></param>
        /// <returns></returns>
        public static DateTimeOffset SetMillisecond(this DateTimeOffset originalDate, int millisecond)
        {
            return new DateTimeOffset(originalDate.Year, originalDate.Month, originalDate.Day, originalDate.Hour, originalDate.Minute, originalDate.Second, millisecond, originalDate.Offset);
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
    }
}