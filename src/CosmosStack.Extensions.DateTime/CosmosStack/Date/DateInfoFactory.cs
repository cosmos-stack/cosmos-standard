using System;
using System.Runtime.CompilerServices;
using CosmosStack.Conversions;
using CosmosStack.Date.DateUtils;

namespace CosmosStack.Date
{
    /// <summary>
    /// DateInfo Factory <br />
    /// 日期工厂
    /// </summary>
    public static class DateInfoFactory
    {
        #region Today

        /// <summary>
        /// Today<br />
        /// 今天
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateInfo Today() => DateInfo.Today;

        /// <summary>
        /// Today<br />
        /// Tomorrow
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateInfo Tomorrow() => DateInfo.Today.Tomorrow();

        /// <summary>
        /// Today<br />
        /// Yesterday
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateInfo Yesterday() => DateInfo.Today.Yesterday();

        #endregion

        #region Create

        /// <summary>
        /// Create <see cref="DateInfo"/> by special date.<br />
        /// 根据指定的日期创建 <see cref="DateInfo"/>
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public static DateInfo Create(int year, int month, int day)
        {
            try
            {
                return new(year, month, day);
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

        #endregion

        #region Create Last Day of Month

        /// <summary>
        /// To get the latest weekday for example Monday in a month.<br />
        /// 寻找一个月中的最后一个日期
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateInfo CreateLastDayOfMonth(int year, int month) => Create(year, month, DateInfo.DaysInMonth(year, month));

        /// <summary>
        /// To get the latest weekday for example Monday in a month.<br />
        /// 寻找一个月中的最后一个工作日（如周一）
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateInfo CreateLastDayOfMonth(int year, int month, DayOfWeek dayOfWeek)
        {
            return DateInfoCalc.TryOffsetByWeek(year, month, 5, dayOfWeek, out var resultedDay)
                ? resultedDay
                : DateInfoCalc.OffsetByWeek(year, month, 4, dayOfWeek);
        }

        /// <summary>
        /// To get the latest weekday for example Monday in a month.<br />
        /// 寻找一个月中的最后一个工作日（如周一）
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateInfo CreateLastDayOfMonth(int year, int month, int dayOfWeek)
        {
            return DateInfoCalc.TryOffsetByWeek(year, month, 5, dayOfWeek, out var resultedDay)
                ? resultedDay
                : DateInfoCalc.OffsetByWeek(year, month, 4, dayOfWeek);
        }

        #endregion

        #region Create First Day of Month

        /// <summary>
        /// To get the first weekday for example Monday in a month.<br />
        /// 寻找一个月中的最后一个日期
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateInfo CreateFirstDayOfMonth(int year, int month) => Create(year, month, 1);

        /// <summary>
        /// To get the first weekday for example Monday in a month.<br />
        /// 寻找一个月中的最后一个日期
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateInfo CreateFirstDayOfMonth(int year, int month, DayOfWeek dayOfWeek) 
            => DateInfoCalc.OffsetByWeek(year, month, 1, dayOfWeek);

        /// <summary>
        /// To get the first weekday for example Monday in a month.<br />
        /// 寻找一个月中的最后一个日期
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateInfo CreateFirstDayOfMonth(int year, int month, int dayOfWeek) 
            => DateInfoCalc.OffsetByWeek(year, month, 1, dayOfWeek);

        #endregion

        #region Create Next Day by Week

        /// <summary>
        /// Find the next weekday for example Monday from a special date.<br />
        /// 根据指定的日期，获得下一个工作日（如周一）
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateInfo CreateNextDayByWeek(int year, int month, int day, DayOfWeek dayOfWeek)
            => DateInfoCalc.OffsetByWeekAfter(Create(year, month, day), dayOfWeek);

        /// <summary>
        /// Find the next weekday for example Monday from a special date.<br />
        /// 根据指定的日期，获得下一个工作日（如周一）
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateInfo CreateNextDayByWeek(DateInfo dt, DayOfWeek dayOfWeek) 
            => DateInfoCalc.OffsetByWeekAfter(dt, dayOfWeek);

        #endregion

        #region Create Previous Day by Week

        /// <summary>
        /// Find the next weekday for example Monday before a special date.<br />
        /// 根据指定的日期，获得上一个工作日（如周一）
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateInfo CreatePreviousDayByWeek(int year, int month, int day, DayOfWeek dayOfWeek) 
            => DateInfoCalc.OffsetByWeekBefore(Create(year, month, day), dayOfWeek);

        /// <summary>
        /// Find the next weekday for example Monday before a special date.<br />
        /// 根据指定的日期，获得上一个工作日（如周一）
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateInfo CreatePreviousDayByWeek(DateInfo dt, DayOfWeek dayOfWeek)
            => DateInfoCalc.OffsetByWeekBefore(dt, dayOfWeek);

        #endregion

        #region Create Day by Week

        /// <summary>
        /// Find for example the 3th Monday in a month.<br />
        /// 寻找指定的日期（如一个月的第三个周一）
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="dayOfWeek"></param>
        /// <param name="occurrence"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateInfo CreateByWeek(int year, int month, DayOfWeek dayOfWeek, int occurrence) 
            => DateInfoCalc.OffsetByWeek(year, month, occurrence, dayOfWeek.CastToInt(0));

        #endregion
    }
}