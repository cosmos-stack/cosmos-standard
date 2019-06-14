using System;
using FluentDateTime;
using NodaTime;

namespace Cosmos.Date
{
    /// <summary>
    /// DateInfo
    /// </summary>
    public class DateInfo
    {
        // ReSharper disable once InconsistentNaming
        private DateTime _internalDateTime { get; set; }

        internal DateInfo() { }

        /// <summary>
        /// Create a new instance of <see cref="DateInfo"/>.<br />
        /// 创建一个新的 <see cref="DateInfo"/> 实例。
        /// </summary>
        /// <param name="dt"></param>
        public DateInfo(DateTime dt)
        {
            _internalDateTime = dt.SetTime(0, 0, 0, 0);
        }

        /// <summary>
        /// Create a new instance of <see cref="DateInfo"/>.<br />
        /// 创建一个新的 <see cref="DateInfo"/> 实例。
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        public DateInfo(int year, int month, int day)
        {
            _internalDateTime = new DateTime(year, month, day, 0, 0, 0, 0);
        }

        /// <summary>
        /// Year<br />
        /// 年
        /// </summary>
        public virtual int Year {
            get => _internalDateTime.Year;
            set => _internalDateTime = _internalDateTime.SetYear(value);
        }

        /// <summary>
        /// Month<br />
        /// 月份
        /// </summary>
        public virtual int Month {
            get => _internalDateTime.Month;
            set => _internalDateTime = _internalDateTime.SetMonth(DateChecker.CheckMonth(value));
        }

        /// <summary>
        /// Day<br />
        /// 日
        /// </summary>
        public virtual int Day {
            get => _internalDateTime.Day;
            set => _internalDateTime = _internalDateTime.SetDay(value);
        }

        /// <summary>
        /// Convert to <see cref="DateTime"/><br />
        /// 转换为 <see cref="DateTime"/>
        /// </summary>
        /// <returns></returns>
        public virtual DateTime ToDateTime() => _internalDateTime.Clone();

        internal DateTime DateTimeRef => _internalDateTime;

        private static class DateChecker
        {
            public static int CheckMonth(int monthValue)
            {
                if (monthValue < 0 || monthValue > 12)
                    throw new ArgumentOutOfRangeException(nameof(monthValue), monthValue, "Month should be from 1 to 12.");
                return monthValue;
            }
        }

        /// <summary>
        /// Add days<br />
        /// 添加天数
        /// </summary>
        /// <param name="days"></param>
        /// <returns></returns>
        public DateInfo AddDays(int days)
        {
            _internalDateTime = _internalDateTime.AddDays(days);
            return this;
        }

        /// <summary>
        /// Add months<br />
        /// 添加月份
        /// </summary>
        /// <param name="months"></param>
        /// <returns></returns>
        public DateInfo AddMonths(int months)
        {
            _internalDateTime = _internalDateTime.AddMonths(months);
            return this;
        }

        /// <summary>
        /// Add years<br />
        /// 添加年份
        /// </summary>
        /// <param name="years"></param>
        /// <returns></returns>
        public DateInfo AddYears(int years)
        {
            _internalDateTime = _internalDateTime.AddYears(years);
            return this;
        }

        /// <summary>
        /// Add duration<br />
        /// 添加一段时间段
        /// </summary>
        /// <param name="duration"></param>
        /// <returns></returns>
        public DateInfo AddDuration(Duration duration)
        {
            _internalDateTime = _internalDateTime.AddDuration(duration);
            return this;
        }

        /// <summary>
        /// Convert <see cref="DateTime"/> to <see cref="DateInfo"/><br />
        /// 将 <see cref="DateTime"/> 转换为 <see cref="DateInfo"/>。
        /// </summary>
        /// <param name="di"></param>
        public static implicit operator DateTime(DateInfo di)
        {
            return di.ToDateTime();
        }

        /// <summary>
        /// Convert <see cref="DateInfo"/> to <see cref="DateTime"/><br />
        /// 将 <see cref="DateInfo"/> 转换为 <see cref="DateTime"/>。
        /// </summary>
        /// <param name="dt"></param>
        public static implicit operator DateInfo(DateTime dt)
        {
            return new DateInfo(dt);
        }

        /// <summary>
        /// Equals<br />
        /// 相等
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj is DateInfo date)
            {
                return _internalDateTime.Equals(date._internalDateTime);
            }

            return false;
        }

        /// <summary>
        /// Get hashcode<br />
        /// 获取哈希值
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return $"year={Year}&month={Month}&day={Day}".GetHashCode();
        }
    }
}
