using System;
using Cosmos.Date;

// ReSharper disable once CheckNamespace
namespace Cosmos {
    /// <summary>
    /// DateInfo Extensions<br />
    /// DateInfo 扩展方法
    /// </summary>
    public static partial class DateInfoExtensions {
        /// <summary>
        /// Add one day<br />
        /// 加一天
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateInfo AddDay(this DateInfo d) => d.AddDays(1);

        /// <summary>
        /// Add weeks
        /// </summary>
        /// <param name="d"></param>
        /// <param name="weeks"></param>
        /// <returns></returns>
        public static DateInfo AddWeeks(this DateInfo d, int weeks) => d.AddDays(weeks * 7);

        /// <summary>
        /// Add one month<br />
        /// 加一个月
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateInfo AddMonth(this DateInfo d) => d.AddMonths(1);

        /// <summary>
        /// Add quarters
        /// </summary>
        /// <param name="d"></param>
        /// <param name="quarters"></param>
        /// <returns></returns>
        public static DateInfo AddQuarters(this DateInfo d, int quarters) => d.AddMonths(quarters * 3);

        /// <summary>
        /// Add one year<br />
        /// 加一年
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateInfo AddYear(this DateInfo d) => d.AddYears(1);

        /// <summary>
        /// Is the nextDay the day after current date.<br />
        /// 判断是否为第二天
        /// </summary>
        /// <param name="d"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public static bool IsNextMatched(this DateInfo d, DateInfo next) {
            if (d == null || next == null)
                return false;

            var tomorrow = d.AddDay();
            return tomorrow.Equals(next);
        }

        /// <summary>
        /// Get tomorrow<br />
        /// 第二天
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateInfo Tomorrow(this DateInfo d) => AddDay(d);

        /// <summary>
        /// Get yesterday<br />
        /// 前一天
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateInfo Yesterday(this DateInfo d) => d.AddDays(-1);

        /// <summary>
        /// Add business days<br />
        /// 添加指定个数量的工作日
        /// </summary>
        /// <param name="d"></param>
        /// <param name="days"></param>
        /// <returns></returns>
        public static DateInfo AddBusinessDays(this DateInfo d, int days) {
            var sign = Math.Sign(days);
            var unsignedDays = Math.Abs(days);
            for (var i = 0; i < unsignedDays; i++) {
                do {
                    d = d.AddDays(sign);
                } while (d.DayOfWeek == DayOfWeek.Saturday ||
                         d.DayOfWeek == DayOfWeek.Sunday);
            }

            return d;
        }

        /// <summary>
        /// Subtract business days<br />
        /// 减去指定个数量的工作日
        /// </summary>
        /// <param name="d"></param>
        /// <param name="days"></param>
        /// <returns></returns>
        public static DateInfo SubtractBusinessDays(this DateInfo d, int days) => AddBusinessDays(d, -days);
    }
}