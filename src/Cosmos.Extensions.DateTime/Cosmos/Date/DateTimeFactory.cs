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
        public static DateTime Create(int year, int month, int day)
        {
            try
            {
                return new DateTime(year, month, day);
            }
            catch (ArgumentOutOfRangeException exception)
            {
                throw new DateTimeOutOfRangeException($"Date '{year}-{month}-{day}' out of range.", exception);
            }
            catch (Exception exception)
            {
                throw new InvalidDateTimeException($"Date '{year}-{month}-{day}' is invalid.", exception);
            }
        }

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
        public static DateTime Create(int year, int month, int day, int hour, int minute, int second)
        {
            try
            {
                return new DateTime(year, month, day, hour, minute, second);
            }
            catch (ArgumentOutOfRangeException exception)
            {
                throw new DateTimeOutOfRangeException($"Date '{year}-{month}-{day} {hour}:{minute}:{second}' out of range.", exception);
            }
            catch (Exception exception)
            {
                throw new InvalidDateTimeException($"Date '{year}-{month}-{day} {hour}:{minute}:{second}' is invalid.", exception);
            }
        }

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
        public static DateTime Create(int year, int month, int day, int hour, int minute, int second, int millisecond)
        {
            try
            {
                return new DateTime(year, month, day, hour, minute, second, millisecond);
            }
            catch (ArgumentOutOfRangeException exception)
            {
                throw new DateTimeOutOfRangeException($"Date '{year}-{month}-{day} {hour}:{minute}:{second}.{millisecond}' out of range.", exception);
            }
            catch (Exception exception)
            {
                throw new InvalidDateTimeException($"Date '{year}-{month}-{day} {hour}:{minute}:{second}.{millisecond}' is invalid.", exception);
            }
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
        public static DateTime OffsetByWeek(int year, int month, int weekAtMonth, int dayOfWeek)
        {
            var fd = Create(year, month, 1);
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

        /// <summary>
        /// Find the latest weekday for example Monday in a month.<br />
        /// 寻找一个月中的最后一个工作日（如周一）
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateTime FindLastDay(int year, int month, DayOfWeek dayOfWeek)
        {
            var resultedDay = FindDay(year, month, dayOfWeek, 5);
            if (resultedDay == DateTime.MinValue)
                resultedDay = FindDay(year, month, dayOfWeek, 4);
            return resultedDay;
        }

        /// <summary>
        /// Find the next weekday for example Monday from a special date.<br />
        /// 根据指定的日期，获得下一个工作日（如周一）
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateTime FindNextDay(int year, int month, int day, DayOfWeek dayOfWeek)
        {
            var calculationDay = Create(year, month, day);
            return FindNextDay(calculationDay, dayOfWeek);
        }

        /// <summary>
        /// Find the next weekday for example Monday from a special date.<br />
        /// 根据指定的日期，获得下一个工作日（如周一）
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateTime FindNextDay(DateTime dt, DayOfWeek dayOfWeek)
        {
            var daysNeeded = (int)dayOfWeek - (int)dt.DayOfWeek;
            return (int)dayOfWeek >= (int)dt.DayOfWeek
                ? dt.AddDays(daysNeeded)
                : dt.AddDays(daysNeeded + 7);
        }

        /// <summary>
        /// Find the next weekday for example Monday before a special date.<br />
        /// 根据指定的日期，获得上一个工作日（如周一）
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateTime FindDayBefore(int year, int month, int day, DayOfWeek dayOfWeek)
        {
            var calculationDay = Create(year, month, day);
            return FindDayBefore(calculationDay, dayOfWeek);
        }

        /// <summary>
        /// Find the next weekday for example Monday before a special date.<br />
        /// 根据指定的日期，获得上一个工作日（如周一）
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateTime FindDayBefore(DateTime dt, DayOfWeek dayOfWeek)
        {
            var daysSubtract = (int)dayOfWeek - (int)dt.DayOfWeek;

            return (int)dayOfWeek < (int)dt.DayOfWeek
                ? dt.AddDays(daysSubtract)
                : dt.AddDays(daysSubtract - 7);
        }

        /// <summary>
        /// Find for example the 3th Monday in a month.<br />
        /// 寻找指定的日期（如一个月的第三个周一）
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="dayOfWeek"></param>
        /// <param name="occurrence"></param>
        /// <returns></returns>
        public static DateTime FindDay(int year, int month, DayOfWeek dayOfWeek, int occurrence)
        {
            //todo：判断与 OffsetByWeek 的异同

            if (occurrence == 0 || occurrence > 5)
                throw new ArgumentException("Occurrence is invalid.", nameof(occurrence));

            var firstDayOfMonth = Create(year, month, 1);

            var daysNeeded = (int)dayOfWeek - (int)firstDayOfMonth.DayOfWeek;

            if (daysNeeded < 0)
            {
                daysNeeded += 7;
            }

            //DayOfWeek 索引从 0 开始
            var resultedDay = (daysNeeded + 1) + (7 * (occurrence - 1));

            if (resultedDay > DateTime.DaysInMonth(year, month))
                return DateTime.MinValue;

            return Create(year, month, resultedDay);
        }
    }
}
