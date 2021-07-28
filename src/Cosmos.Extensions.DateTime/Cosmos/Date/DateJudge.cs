using System;
using System.Runtime.CompilerServices;

namespace Cosmos.Date
{
    public static class DateJudge
    {
        #region IsToday

        /// <summary>
        /// To judge whether the day is today.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsToday(DateTime dt) => dt.IsToday();

        /// <summary>
        /// To judge whether the day is today.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsToday(DateTime? dt) => dt.IsToday();

        /// <summary>
        /// To judge whether the day is today.
        /// </summary>
        /// <param name="dtOffset"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsToday(DateTimeOffset dtOffset) => dtOffset.IsToday();

        /// <summary>
        /// To judge whether the day is today.
        /// </summary>
        /// <param name="dtOffset"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsToday(DateTimeOffset? dtOffset) => dtOffset.IsToday();

        #endregion

        #region IsWeekend

        /// <summary>
        /// To judge whether the day is weekend.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsWeekend(DateTime dt) => dt.IsWeekend();

        /// <summary>
        /// To judge whether the day is weekend.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsWeekend(DateTime? dt) => dt.IsWeekend();

        #endregion

        #region IsWeekday

        /// <summary>
        /// To judge whether the day is weekday.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsWeekday(DateTime dt) => dt.IsWeekday();

        /// <summary>
        /// To judge whether the day is weekday.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsWeekday(DateTime? dt) => dt.IsWeekday();

        #endregion
    }
}