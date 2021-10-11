using System;

namespace CosmosStack.Conversions
{
    /// <summary>
    /// DayOfWeek Convertor <br />
    /// 周转换器
    /// </summary>
    public static class DayOfWeekConv
    {
        /// <summary>
        /// Convert <see cref="DayOfWeek"/> to <see cref="int"/><br />
        /// 将 <see cref="DayOfWeek"/> 转换为 <see cref="int"/>。
        /// </summary>
        /// <param name="week"></param>
        /// <returns></returns>
        public static int ToInt(DayOfWeek week)
        {
            return ToInt(week, 1);
        }

        /// <summary>
        /// Convert <see cref="DayOfWeek"/> to <see cref="int"/><br />
        /// 将 <see cref="DayOfWeek"/> 转换为 <see cref="int"/>。
        /// </summary>
        /// <param name="week"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static int ToInt(DayOfWeek week, int offset)
        {
            return offset + week switch
            {
                DayOfWeek.Sunday => 0,
                DayOfWeek.Monday => 1,
                DayOfWeek.Tuesday => 2,
                DayOfWeek.Wednesday => 3,
                DayOfWeek.Thursday => 4,
                DayOfWeek.Friday => 5,
                DayOfWeek.Saturday => 6,
                _ => 0
            };
        }
    }

    /// <summary>
    /// CosmosStack <see cref="DayOfWeek"/> extensions.<br />
    /// 周转换器扩展
    /// </summary>
    public static class DayOfWeekConvExtensions
    {
        /// <summary>
        /// Convert <see cref="DayOfWeek"/> to <see cref="int"/><br />
        /// 将 <see cref="DayOfWeek"/> 转换为 <see cref="int"/>。
        /// </summary>
        /// <param name="week"></param>
        /// <returns></returns>
        public static int CastToInt(this DayOfWeek week)
        {
            return DayOfWeekConv.ToInt(week);
        }

        /// <summary>
        /// Convert <see cref="DayOfWeek"/> to <see cref="int"/><br />
        /// 将 <see cref="DayOfWeek"/> 转换为 <see cref="int"/>。
        /// </summary>
        /// <param name="week"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static int CastToInt(this DayOfWeek week, int offset)
        {
            return DayOfWeekConv.ToInt(week, offset);
        }
    }
}