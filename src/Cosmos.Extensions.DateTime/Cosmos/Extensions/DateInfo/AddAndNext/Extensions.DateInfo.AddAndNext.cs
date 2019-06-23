using Cosmos.Date;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    /// <summary>
    /// DateInfo Extensions<br />
    /// DateInfo 扩展方法
    /// </summary>
    public static partial class DateInfoExtensions
    {
        /// <summary>
        /// Add one day<br />
        /// 加一天
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateInfo AddDay(this DateInfo date) => date.AddDays(1);

        /// <summary>
        /// Add one month<br />
        /// 加一个月
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateInfo AddMonth(this DateInfo date) => date.AddMonths(1);

        /// <summary>
        /// Add one year<br />
        /// 加一年
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateInfo AddYear(this DateInfo date) => date.AddYears(1);

        /// <summary>
        /// Is the nextDay the day after current date.<br />
        /// 判断是否为第二天
        /// </summary>
        /// <param name="date"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public static bool IsNextMatched(this DateInfo date, DateInfo next)
        {
            if (date == null || next == null)
                return false;

            var tomorrow = date.AddDay();
            return tomorrow.Equals(next);
        }

        /// <summary>
        /// Get tomorrow<br />
        /// 第二天
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateInfo Tomorrow(this DateInfo date) => AddDay(date);

        /// <summary>
        /// Get yesterday<br />
        /// 前一天
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateInfo Yesterday(this DateInfo date) => date.AddDays(-1);
    }
}
