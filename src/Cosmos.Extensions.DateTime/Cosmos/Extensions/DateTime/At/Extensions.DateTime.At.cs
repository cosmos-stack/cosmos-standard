using System;

// ReSharper disable once CheckNamespace
namespace Cosmos {
    /// <summary>
    /// DateTime Extensions<br />
    /// DateTime 扩展方法
    /// </summary>
    public static partial class DateTimeExtensions {
        /// <summary>
        /// At
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static DateTime At(this DateTime dt, int hour, int minute, int second) => dt.SetTime(hour, minute, second);

        /// <summary>
        /// At
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <param name="second"></param>
        /// <param name="milliseconds"></param>
        /// <returns></returns>
        public static DateTime At(this DateTime dt, int hour, int minute, int second, int milliseconds) => dt.SetTime(hour, minute, second, milliseconds);
    }
}