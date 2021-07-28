using System;
using System.Runtime.CompilerServices;

namespace Cosmos.Date
{
    public static partial class DateTimeExtensions
    {
        #region At

        /// <summary>
        /// At, to set hour, minute and second.<br />
        /// 时间，修改它的时分秒。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTime At(this DateTime dt, int hour, int minute, int second) => 
            dt.SetTime(hour, minute, second);

        /// <summary>
        /// At, to set hour, minute, second and milliseconds.<br />
        /// 时间，修改它的时分秒，以及毫秒。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <param name="second"></param>
        /// <param name="milliseconds"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTime At(this DateTime dt, int hour, int minute, int second, int milliseconds) => 
            dt.SetTime(hour, minute, second, milliseconds);

        #endregion

        #region On

        /// <summary>
        /// On, to set year, month and day.<br />
        /// 日期，修改它的年月日。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTime On(this DateTime dt, int year, int month, int day) =>
            dt.SetDate(year, month, day);

        #endregion
        
        #region Set

        /// <summary>
        /// Set the hour for the given time. <br />
        /// 对给定的时间设置小时。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="hour"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTime SetTime(this DateTime dt, int hour) =>
            DateTimeFactory.Create(dt.Year, dt.Month, dt.Day, hour, dt.Minute, dt.Second, dt.Millisecond, dt.Kind);

        /// <summary>
        /// Set the hour and minute for the given time. <br />
        /// 对给定的时间设置时分。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTime SetTime(this DateTime dt, int hour, int minute) =>
            DateTimeFactory.Create(dt.Year, dt.Month, dt.Day, hour, minute, dt.Second, dt.Millisecond, dt.Kind);

        /// <summary>
        /// Set the hour, minute and second for the given time. <br />
        /// 对给定的时间设置时分秒。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTime SetTime(this DateTime dt, int hour, int minute, int second) =>
            DateTimeFactory.Create(dt.Year, dt.Month, dt.Day, hour, minute, second, dt.Millisecond, dt.Kind);

        /// <summary>
        /// Set the hour, minute, second and millisecond for the given time. <br />
        /// 对给定的时间设置时分秒和毫秒。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <param name="second"></param>
        /// <param name="millisecond"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTime SetTime(this DateTime dt, int hour, int minute, int second, int millisecond) =>
            DateTimeFactory.Create(dt.Year, dt.Month, dt.Day, hour, minute, second, millisecond, dt.Kind);

        /// <summary>
        /// Set the hour for the given time. <br />
        /// 对给定的时间设置小时。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="hour"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTime SetHour(this DateTime dt, int hour) =>
            DateTimeFactory.Create(dt.Year, dt.Month, dt.Day, hour, dt.Minute, dt.Second, dt.Millisecond, dt.Kind);

        /// <summary>
        /// Set the minute for the given time. <br />
        /// 对给定的时间设置分钟。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="minute"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTime SetMinute(this DateTime dt, int minute) =>
            DateTimeFactory.Create(dt.Year, dt.Month, dt.Day, dt.Hour, minute, dt.Second, dt.Millisecond, dt.Kind);

        /// <summary>
        /// Set the second for the given time. <br />
        /// 对给定的时间设置秒。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTime SetSecond(this DateTime dt, int second) =>
            DateTimeFactory.Create(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, second, dt.Millisecond, dt.Kind);

        /// <summary>
        /// Set the millisecond for the given time. <br />
        /// 对给定的时间设置毫秒。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="millisecond"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTime SetMillisecond(this DateTime dt, int millisecond) =>
            DateTimeFactory.Create(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, millisecond, dt.Kind);

        /// <summary>
        /// Set the given time to midnight. <br />
        /// 将给定的时间设置为午夜。
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTime Midnight(this DateTime dt) => dt.BeginningOfDay();

        /// <summary>
        /// Set the given time to noon. <br />
        /// 将给定的时间设置为正午。
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTime Noon(this DateTime dt) => dt.SetTime(12, 0, 0, 0);

        /// <summary>
        /// Set the year for the given time. <br />
        /// 对给定的时间设置年份。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTime SetDate(this DateTime dt, int year) =>
            DateTimeFactory.Create(year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond, dt.Kind);

        /// <summary>
        /// Set the year and month for the given time. <br />
        /// 对给定的时间设置年份和月份。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTime SetDate(this DateTime dt, int year, int month) =>
            DateTimeFactory.Create(year, month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond, dt.Kind);

        /// <summary>
        /// Set the year, month and day for the given time. <br />
        /// 对给定的时间设置年月日。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTime SetDate(this DateTime dt, int year, int month, int day) =>
            DateTimeFactory.Create(year, month, day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond, dt.Kind);

        /// <summary>
        /// Set the year for the given time. <br />
        /// 对给定的时间设置年份。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTime SetYear(this DateTime dt, int year) =>
            DateTimeFactory.Create(year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond, dt.Kind);

        /// <summary>
        /// Set the month for the given time. <br />
        /// 对给定的时间设置月份。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTime SetMonth(this DateTime dt, int month) =>
            DateTimeFactory.Create(dt.Year, month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond, dt.Kind);

        /// <summary>
        /// Set the day for the given time. <br />
        /// 对给定的时间设置日。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTime SetDay(this DateTime dt, int day) =>
            DateTimeFactory.Create(dt.Year, dt.Month, day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond, dt.Kind);

        /// <summary>
        /// Set kind
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="kind"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTime SetKind(this DateTime dt, DateTimeKind kind) =>
            DateTimeFactory.Create(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond, kind);

        #endregion
    }
}