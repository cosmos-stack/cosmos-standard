using System;
using System.Runtime.CompilerServices;

namespace CosmosStack.Date
{
    /// <summary>
    /// DateTimeOffset Extensions <br />
    /// DateTimeOffset 扩展
    /// </summary>
    public static partial class DateTimeOffsetExtensions
    {
        #region At

        /// <summary>
        /// At <br />
        /// 在某时
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTimeOffset At(this DateTimeOffset dto, int hour, int minute) => dto.SetTime(hour, minute);

        /// <summary>
        /// At <br />
        /// 在某时
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTimeOffset At(this DateTimeOffset dto, int hour, int minute, int second) => dto.SetTime(hour, minute, second);

        /// <summary>
        /// At <br />
        /// 在某时
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <param name="second"></param>
        /// <param name="milliseconds"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTimeOffset At(this DateTimeOffset dto, int hour, int minute, int second, int milliseconds) 
            => dto.SetTime(hour, minute, second, milliseconds);

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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTimeOffset On(this DateTimeOffset dto, int year, int month, int day) =>
            dto.SetDate(year, month, day);

        #endregion

        #region Set

        /// <summary>
        /// Set time <br />
        /// 修改时间
        /// </summary>
        /// <param name="originalDate"></param>
        /// <param name="hour"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTimeOffset SetTime(this DateTimeOffset originalDate, int hour) 
            => new(originalDate.Year, originalDate.Month, originalDate.Day, hour, originalDate.Minute, originalDate.Second, originalDate.Millisecond, originalDate.Offset);

        /// <summary>
        /// Set time <br />
        /// 修改时间
        /// </summary>
        /// <param name="originalDate"></param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <returns></returns>
        public static DateTimeOffset SetTime(this DateTimeOffset originalDate, int hour, int minute) 
            => new(originalDate.Year, originalDate.Month, originalDate.Day, hour, minute, originalDate.Second, originalDate.Millisecond, originalDate.Offset);

        /// <summary>
        /// Set time <br />
        /// 修改时间
        /// </summary>
        /// <param name="originalDate"></param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static DateTimeOffset SetTime(this DateTimeOffset originalDate, int hour, int minute, int second) 
            => new(originalDate.Year, originalDate.Month, originalDate.Day, hour, minute, second, originalDate.Millisecond, originalDate.Offset);

        /// <summary>
        /// Set time <br />
        /// 修改时间
        /// </summary>
        /// <param name="originalDate"></param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <param name="second"></param>
        /// <param name="millisecond"></param>
        /// <returns></returns>
        public static DateTimeOffset SetTime(this DateTimeOffset originalDate, int hour, int minute, int second, int millisecond) 
            => new(originalDate.Year, originalDate.Month, originalDate.Day, hour, minute, second, millisecond, originalDate.Offset);

        /// <summary>
        /// Set hour <br />
        /// 设置小时
        /// </summary>
        /// <param name="originalDate"></param>
        /// <param name="hour"></param>
        /// <returns></returns>
        public static DateTimeOffset SetHour(this DateTimeOffset originalDate, int hour) 
            => new(originalDate.Year, originalDate.Month, originalDate.Day, hour, originalDate.Minute, originalDate.Second, originalDate.Millisecond, originalDate.Offset);

        /// <summary>
        /// Set minute <br />
        /// 设置分钟
        /// </summary>
        /// <param name="originalDate"></param>
        /// <param name="minute"></param>
        /// <returns></returns>
        public static DateTimeOffset SetMinute(this DateTimeOffset originalDate, int minute) 
            => new(originalDate.Year, originalDate.Month, originalDate.Day, originalDate.Hour, minute, originalDate.Second, originalDate.Millisecond, originalDate.Offset);

        /// <summary>
        /// Set second <br />
        /// 设置秒
        /// </summary>
        /// <param name="originalDate"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static DateTimeOffset SetSecond(this DateTimeOffset originalDate, int second)
            => new(originalDate.Year, originalDate.Month, originalDate.Day, originalDate.Hour, originalDate.Minute, second, originalDate.Millisecond, originalDate.Offset);

        /// <summary>
        /// Set millisecond <br />
        /// 设置毫秒
        /// </summary>
        /// <param name="originalDate"></param>
        /// <param name="millisecond"></param>
        /// <returns></returns>
        public static DateTimeOffset SetMillisecond(this DateTimeOffset originalDate, int millisecond)
            => new(originalDate.Year, originalDate.Month, originalDate.Day, originalDate.Hour, originalDate.Minute, originalDate.Second, millisecond, originalDate.Offset);

        /// <summary>
        /// Set date <br />
        /// 设置日期
        /// </summary>
        /// <param name="value"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTimeOffset SetDate(this DateTimeOffset value, int year)
            => new(year, value.Month, value.Day, value.Hour, value.Minute, value.Second, value.Millisecond, value.Offset);

        /// <summary>
        /// Set date <br />
        /// 设置日期
        /// </summary>
        /// <param name="value"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public static DateTimeOffset SetDate(this DateTimeOffset value, int year, int month) 
            => new(year, month, value.Day, value.Hour, value.Minute, value.Second, value.Millisecond, value.Offset);

        /// <summary>
        /// Set date <br />
        /// 设置日期
        /// </summary>
        /// <param name="value"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public static DateTimeOffset SetDate(this DateTimeOffset value, int year, int month, int day) 
            => new(year, month, day, value.Hour, value.Minute, value.Second, value.Millisecond, value.Offset);

        /// <summary>
        /// Set year <br />
        /// 设置年
        /// </summary>
        /// <param name="value"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTimeOffset SetYear(this DateTimeOffset value, int year)
            => new(year, value.Month, value.Day, value.Hour, value.Minute, value.Second, value.Millisecond, value.Offset);

        /// <summary>
        /// Set month <br />
        /// 设置月
        /// </summary>
        /// <param name="value"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public static DateTimeOffset SetMonth(this DateTimeOffset value, int month)
            => new(value.Year, month, value.Day, value.Hour, value.Minute, value.Second, value.Millisecond, value.Offset);

        /// <summary>
        /// Set day <br />
        /// 设置日
        /// </summary>
        /// <param name="value"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public static DateTimeOffset SetDay(this DateTimeOffset value, int day)
            => new(value.Year, value.Month, day, value.Hour, value.Minute, value.Second, value.Millisecond, value.Offset);

        #endregion
    }
}