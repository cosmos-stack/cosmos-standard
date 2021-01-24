using System;

namespace Cosmos.Date
{
    public static partial class DateTimeOffsetExtensions
    {
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

        #region On

        /// <summary>
        /// On, to set year, month and day.<br />
        /// 日期，修改它的年月日。
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public static DateTimeOffset On(this DateTimeOffset dto, int year, int month, int day) =>
            dto.SetDate(year, month, day);

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
            return new(originalDate.Year, originalDate.Month, originalDate.Day, hour, originalDate.Minute, originalDate.Second, originalDate.Millisecond, originalDate.Offset);
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
            return new(originalDate.Year, originalDate.Month, originalDate.Day, hour, minute, originalDate.Second, originalDate.Millisecond, originalDate.Offset);
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
            return new(originalDate.Year, originalDate.Month, originalDate.Day, hour, minute, second, originalDate.Millisecond, originalDate.Offset);
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
            return new(originalDate.Year, originalDate.Month, originalDate.Day, hour, minute, second, millisecond, originalDate.Offset);
        }

        /// <summary>
        /// Set hour
        /// </summary>
        /// <param name="originalDate"></param>
        /// <param name="hour"></param>
        /// <returns></returns>
        public static DateTimeOffset SetHour(this DateTimeOffset originalDate, int hour)
        {
            return new(originalDate.Year, originalDate.Month, originalDate.Day, hour, originalDate.Minute, originalDate.Second, originalDate.Millisecond, originalDate.Offset);
        }

        /// <summary>
        /// Set minute
        /// </summary>
        /// <param name="originalDate"></param>
        /// <param name="minute"></param>
        /// <returns></returns>
        public static DateTimeOffset SetMinute(this DateTimeOffset originalDate, int minute)
        {
            return new(originalDate.Year, originalDate.Month, originalDate.Day, originalDate.Hour, minute, originalDate.Second, originalDate.Millisecond, originalDate.Offset);
        }

        /// <summary>
        /// Set second
        /// </summary>
        /// <param name="originalDate"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static DateTimeOffset SetSecond(this DateTimeOffset originalDate, int second)
        {
            return new(originalDate.Year, originalDate.Month, originalDate.Day, originalDate.Hour, originalDate.Minute, second, originalDate.Millisecond, originalDate.Offset);
        }

        /// <summary>
        /// Set millisecond
        /// </summary>
        /// <param name="originalDate"></param>
        /// <param name="millisecond"></param>
        /// <returns></returns>
        public static DateTimeOffset SetMillisecond(this DateTimeOffset originalDate, int millisecond)
        {
            return new(originalDate.Year, originalDate.Month, originalDate.Day, originalDate.Hour, originalDate.Minute, originalDate.Second, millisecond, originalDate.Offset);
        }

        /// <summary>
        /// Set date
        /// </summary>
        /// <param name="value"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTimeOffset SetDate(this DateTimeOffset value, int year)
        {
            return new(year, value.Month, value.Day, value.Hour, value.Minute, value.Second, value.Millisecond, value.Offset);
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
            return new(year, month, value.Day, value.Hour, value.Minute, value.Second, value.Millisecond, value.Offset);
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
            return new(year, month, day, value.Hour, value.Minute, value.Second, value.Millisecond, value.Offset);
        }

        /// <summary>
        /// Set year
        /// </summary>
        /// <param name="value"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTimeOffset SetYear(this DateTimeOffset value, int year)
        {
            return new(year, value.Month, value.Day, value.Hour, value.Minute, value.Second, value.Millisecond, value.Offset);
        }

        /// <summary>
        /// Set month
        /// </summary>
        /// <param name="value"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public static DateTimeOffset SetMonth(this DateTimeOffset value, int month)
        {
            return new(value.Year, month, value.Day, value.Hour, value.Minute, value.Second, value.Millisecond, value.Offset);
        }

        /// <summary>
        /// Set day
        /// </summary>
        /// <param name="value"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public static DateTimeOffset SetDay(this DateTimeOffset value, int day)
        {
            return new(value.Year, value.Month, day, value.Hour, value.Minute, value.Second, value.Millisecond, value.Offset);
        }

        #endregion
    }
}