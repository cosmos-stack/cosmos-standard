using System;
using Cosmos.Date;

namespace NodaTime
{
    /// <summary>
    /// Cosmos <see cref="LocalTime"/> extensions.
    /// </summary>
    public static class NodaLocalTimeExtensions
    {
        #region Add

        /// <summary>
        /// Add nanoseconds
        /// </summary>
        /// <param name="lt"></param>
        /// <param name="nanoseconds"></param>
        /// <returns></returns>
        public static LocalTime AddNanoseconds(this LocalTime lt, long nanoseconds) => lt.PlusNanoseconds(nanoseconds);

        /// <summary>
        /// Add milliseconds
        /// </summary>
        /// <param name="lt"></param>
        /// <param name="milliseconds"></param>
        /// <returns></returns>
        public static LocalTime AddMilliseconds(this LocalTime lt, long milliseconds) => lt.PlusMilliseconds(milliseconds);

        /// <summary>
        /// Add seconds
        /// </summary>
        /// <param name="lt"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static LocalTime AddSeconds(this LocalTime lt, long seconds) => lt.PlusSeconds(seconds);

        /// <summary>
        /// Add minutes
        /// </summary>
        /// <param name="lt"></param>
        /// <param name="minutes"></param>
        /// <returns></returns>
        public static LocalTime AddMinutes(this LocalTime lt, long minutes) => lt.PlusMinutes(minutes);

        /// <summary>
        /// Add hours
        /// </summary>
        /// <param name="lt"></param>
        /// <param name="hours"></param>
        /// <returns></returns>
        public static LocalTime AddHours(this LocalTime lt, long hours) => lt.PlusHours(hours);

        /// <summary>
        /// Add TimeSpan
        /// </summary>
        /// <param name="lt"></param>
        /// <param name="ts"></param>
        /// <returns></returns>
        public static LocalTime Add(this LocalTime lt, TimeSpan ts) => lt.PlusTicks(ts.Ticks);

        /// <summary>
        /// Add DateTimeSpan
        /// </summary>
        /// <param name="lt"></param>
        /// <param name="ts"></param>
        /// <returns></returns>
        public static LocalTime Add(this LocalTime lt, DateTimeSpan ts) => lt.PlusTicks(ts.Ticks);

        /// <summary>
        /// Add period
        /// </summary>
        /// <param name="ts"></param>
        /// <param name="period"></param>
        /// <returns></returns>
        public static LocalTime Add(this LocalTime ts, Period period) => ts.Plus(period);

        #endregion

        #region At

        /// <summary>
        /// At
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static LocalTime At(this LocalTime dt, int hour, int minute, int second) => dt.SetTime(hour, minute, second);

        /// <summary>
        /// At
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <param name="second"></param>
        /// <param name="milliseconds"></param>
        /// <returns></returns>
        public static LocalTime At(this LocalTime dt, int hour, int minute, int second, int milliseconds) => dt.SetTime(hour, minute, second, milliseconds);

        #endregion

        #region Set

        /// <summary>
        /// Set time
        /// </summary>
        /// <param name="lt"></param>
        /// <param name="hour"></param>
        /// <returns></returns>
        public static LocalTime SetTime(this LocalTime lt, int hour) =>
            new LocalTime(hour, lt.Minute, lt.Second, lt.Millisecond);

        /// <summary>
        /// Set time
        /// </summary>
        /// <param name="lt"></param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <returns></returns>
        public static LocalTime SetTime(this LocalTime lt, int hour, int minute) =>
            new LocalTime(hour, minute, lt.Second, lt.Millisecond);

        /// <summary>
        /// Set time
        /// </summary>
        /// <param name="lt"></param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static LocalTime SetTime(this LocalTime lt, int hour, int minute, int second) =>
            new LocalTime(hour, minute, second, lt.Millisecond);

        /// <summary>
        /// Set time
        /// </summary>
        /// <param name="lt"></param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <param name="second"></param>
        /// <param name="millisecond"></param>
        /// <returns></returns>
        public static LocalTime SetTime(this LocalTime lt, int hour, int minute, int second, int millisecond) =>
            new LocalTime(hour, minute, second, millisecond);

        /// <summary>
        /// Set time
        /// </summary>
        /// <param name="lt"></param>
        /// <param name="hour"></param>
        /// <returns></returns>
        public static LocalTime SetHour(this LocalTime lt, int hour) =>
            new LocalTime(hour, lt.Minute, lt.Second, lt.Millisecond);

        /// <summary>
        /// Set time
        /// </summary>
        /// <param name="lt"></param>
        /// <param name="minute"></param>
        /// <returns></returns>
        public static LocalTime SetMinute(this LocalTime lt, int minute) =>
            new LocalTime(lt.Hour, minute, lt.Second, lt.Millisecond);

        /// <summary>
        /// Set time
        /// </summary>
        /// <param name="lt"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static LocalTime SetSecond(this LocalTime lt, int second) =>
            new LocalTime(lt.Hour, lt.Minute, second, lt.Millisecond);

        /// <summary>
        /// Set time
        /// </summary>
        /// <param name="lt"></param>
        /// <param name="millisecond"></param>
        /// <returns></returns>
        public static LocalTime SetMillisecond(this LocalTime lt, int millisecond) =>
            new LocalTime(lt.Hour, lt.Minute, lt.Second, millisecond);

        #endregion

        #region Previous and Next

        /// <summary>
        /// Increase time
        /// </summary>
        /// <param name="ldt"></param>
        /// <param name="toAdd"></param>
        /// <returns></returns>
        public static LocalTime IncreaseTime(this LocalTime ldt, TimeSpan toAdd) => ldt.Add(toAdd);

        /// <summary>
        /// Decrease time
        /// </summary>
        /// <param name="ldt"></param>
        /// <param name="toSubtract"></param>
        /// <returns></returns>
        public static LocalTime DecreaseTime(this LocalTime ldt, TimeSpan toSubtract) => ldt.Add(-toSubtract);

        #endregion

        #region To

        /// <summary>
        /// To DateTime
        /// </summary>
        /// <param name="lt"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this LocalTime lt) =>
            DateTime.Today.SetTime(lt.Hour, lt.Minute, lt.Second, lt.Millisecond);

        /// <summary>
        /// To Datetime
        /// </summary>
        /// <param name="lt"></param>
        /// <param name="kind"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this LocalTime lt, DateTimeKind kind) =>
            DateTime.Today.SetTime(lt.Hour, lt.Minute, lt.Second, lt.Millisecond).SetKind(kind);

        /// <summary>
        /// To DateTime
        /// </summary>
        /// <param name="lt"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this LocalTime lt, int year, int month, int day) =>
            DateTimeFactory.Create(year, month, day, lt.Hour, lt.Minute, lt.Second, lt.Millisecond);

        /// <summary>
        /// To Datetime
        /// </summary>
        /// <param name="lt"></param>
        /// <param name="day"></param>
        /// <param name="kind"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this LocalTime lt, int year, int month, int day, DateTimeKind kind) =>
            DateTimeFactory.Create(year, month, day, lt.Hour, lt.Minute, lt.Second, lt.Millisecond, kind);

        /// <summary>
        /// To LocalDateTime
        /// </summary>
        /// <param name="lt"></param>
        /// <returns></returns>
        public static LocalDateTime ToLocalDateTime(this LocalTime lt) =>
            LocalDateTime.FromDateTime(DateTime.Today).SetTime(lt);

        /// <summary>
        /// To LocalDateTime
        /// </summary>
        /// <param name="lt"></param>
        /// <param name="calendar"></param>
        /// <returns></returns>
        public static LocalDateTime ToLocalDateTime(this LocalTime lt, CalendarSystem calendar) =>
            LocalDateTime.FromDateTime(DateTime.Today, calendar).SetTime(lt);

        /// <summary>
        /// To LocalDateTime
        /// </summary>
        /// <param name="lt"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public static LocalDateTime ToLocalDateTime(this LocalTime lt, int year, int month, int day) =>
            new LocalDateTime(year, month, day, lt.Hour, lt.Minute, lt.Second, lt.Millisecond);

        /// <summary>
        /// To LocalDateTime
        /// </summary>
        /// <param name="lt"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <param name="calendar"></param>
        /// <returns></returns>
        public static LocalDateTime ToLocalDateTime(this LocalTime lt, int year, int month, int day, CalendarSystem calendar) =>
            new LocalDateTime(year, month, day, lt.Hour, lt.Minute, lt.Second, lt.Millisecond, calendar);

        #endregion
    }
}