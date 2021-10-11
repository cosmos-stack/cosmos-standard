using System;
using System.Runtime.CompilerServices;

namespace CosmosStack.Date
{
    /// <summary>
    /// Date Judgement <br />
    /// 日期判断
    /// </summary>
    public static class DateJudge
    {
        #region IsToday

        /// <summary>
        /// To judge whether the day is today.  <br />
        /// 判断日期是否为今天
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsToday(DateTime dt) => dt.IsToday();

        /// <summary>
        /// To judge whether the day is today. <br />
        /// 判断日期是否为今天
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsToday(DateTime? dt) => dt.IsToday();

        /// <summary>
        /// To judge whether the day is today. <br />
        /// 判断日期是否为今天
        /// </summary>
        /// <param name="dtOffset"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsToday(DateTimeOffset dtOffset) => dtOffset.IsToday();

        /// <summary>
        /// To judge whether the day is today. <br />
        /// 判断日期是否为今天
        /// </summary>
        /// <param name="dtOffset"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsToday(DateTimeOffset? dtOffset) => dtOffset.IsToday();

        #endregion

        #region IsWeekend

        /// <summary>
        /// To judge whether the day is weekend. <br />
        /// 判断日期是否为周末
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsWeekend(DateTime dt) => dt.IsWeekend();

        /// <summary>
        /// To judge whether the day is weekend. <br />
        /// 判断日期是否为周末
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsWeekend(DateTime? dt) => dt.IsWeekend();

        #endregion

        #region IsWeekday

        /// <summary>
        /// To judge whether the day is weekday. <br />
        /// 判断日期是否为工作日
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsWeekday(DateTime dt) => dt.IsWeekday();

        /// <summary>
        /// To judge whether the day is weekday. <br />
        /// 判断日期是否为工作日
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsWeekday(DateTime? dt) => dt.IsWeekday();

        #endregion
    }
}