using System;
using System.Globalization;
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
        /// Is current date between <see cref="from"/> and <see cref="to"/>.<br />
        /// 判断当前日期是否在 from 和 to 之间
        /// </summary>
        /// <param name="date"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="includeBoundary"></param>
        /// <returns></returns>
        public static bool IsBetween(this DateInfo date, DateInfo from, DateInfo to, bool includeBoundary = true)
        {
            var dtRef = date.DateTimeRef;
            var fromRef = from.DateTimeRef;
            var toRef = to.DateTimeRef;
            return dtRef.IsBetween(fromRef, toRef, includeBoundary);
        }

        /// <summary>
        /// Is current date between <see cref="min"/> and <see cref="max"/> with boundary.<br />
        /// 判断当前日期是否在 min 和 max 之间，闭包区间。
        /// </summary>
        /// <param name="date"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static bool IsDateBetweenWithBoundary(this DateInfo date, DateInfo min, DateInfo max)
        {
            var dtRef = date.DateTimeRef;
            var minRef = min.DateTimeRef;
            var maxRef = max.DateTimeRef;
            return dtRef.IsDateBetweenWithBoundary(minRef, maxRef);
        }

        /// <summary>
        /// Is current date between <see cref="min"/> and <see cref="max"/> without boundary.<br />
        /// 判断当前日期是否在 min 和 max 之间，开区间。
        /// </summary>
        /// <param name="date"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static bool IsDateBetweenWithoutBoundary(this DateInfo date, DateInfo min, DateInfo max)
        {
            var dtRef = date.DateTimeRef;
            var minRef = min.DateTimeRef;
            var maxRef = max.DateTimeRef;
            return dtRef.IsDateBetweenWithoutBoundary(minRef, maxRef);
        }
    }
}
