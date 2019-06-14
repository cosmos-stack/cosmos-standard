using System;
using System.Collections.Generic;
using System.Text;

namespace Cosmos.Date
{
    /// <summary>
    /// DateTime Factory<br />
    /// 时间工厂
    /// </summary>
    public static class DateTimeFactory
    {
        /// <summary>
        /// Now<br />
        /// 此刻
        /// </summary>
        /// <returns></returns>
        public static DateTime Now() => DateTime.Now;

        /// <summary>
        /// Now<br />
        /// 此刻
        /// </summary>
        /// <returns></returns>
        public static DateTime UtcNow() => DateTime.UtcNow;

        /// <summary>
        /// Create <see cref="DateTime"/> by special date.<br />
        /// 根据指定的日期创建 <see cref="DateTime"/>
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public static DateTime Create(int year, int month, int day) => new DateTime(year, month, day);

        /// <summary>
        /// Create <see cref="DateTime"/> by special date.<br />
        /// 根据指定的日期创建 <see cref="DateTime"/>
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static DateTime Create(int year, int month, int day, int hour, int minute, int second) => new DateTime(year, month, day, hour, minute, second);

        /// <summary>
        /// Create <see cref="DateTime"/> by special date.<br />
        /// 根据指定的日期创建 <see cref="DateTime"/>
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <param name="second"></param>
        /// <param name="millisecond"></param>
        /// <returns></returns>
        public static DateTime Create(int year, int month, int day, int hour, int minute, int second, int millisecond) => new DateTime(year, month, day, hour, minute, second, millisecond);

        /// <summary>
        /// Create <see cref="DateTime"/> by special year, month and offset info.<br />
        /// 根据指定的年月和偏移信息创建 <see cref="DateTime"/>
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="weekAtMonth"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateTime OffsetByWeek(int year, int month, int weekAtMonth, int dayOfWeek)
        {
            var fd = new DateTime(year, month, 1);
            var fDayOfWeek = fd.DayOfWeek.ToInt();
            var restDayOfFdInWeek = 7 - fDayOfWeek + 1; //计算第一周剩余天数

            var targetDay = fDayOfWeek > dayOfWeek
                ? (weekAtMonth - 1) * 7 + dayOfWeek + restDayOfFdInWeek
                : (weekAtMonth - 2) * 7 + dayOfWeek + restDayOfFdInWeek;
            return Create(year, month, targetDay);
        }

        /// <summary>
        /// Create <see cref="DateTime"/> by special year, month and offset info.<br />
        /// 根据指定的年月和偏移信息创建 <see cref="DateTime"/>
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="weekAtMonth"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateTime OffsetByWeek(int year, int month, int weekAtMonth, DayOfWeek dayOfWeek) => OffsetByWeek(year, month, weekAtMonth, dayOfWeek.ToInt());
    }
}
