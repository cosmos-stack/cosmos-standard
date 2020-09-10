using System;
using Cosmos.Date;

namespace NodaTime
{
    /// <summary>
    /// Cosmos <see cref="Duration"/> extensions
    /// </summary>
    public static class NodaDurationExtensions
    {
        #region As duration

        /// <summary>
        /// Convert <see cref="TimeSpan"/> to <see cref="Duration"/>.<br />
        /// 将 TimeSpan 转换为 Duration。
        /// </summary>
        /// <param name="ts"></param>
        /// <returns></returns>
        public static Duration AsDuration(this TimeSpan ts) => Duration.FromTimeSpan(ts);

        /// <summary>
        /// Convert <see cref="DateTimeSpan"/> to <see cref="Duration"/>.<br />
        /// 将 DateTimeSpan 转换为 Duration。
        /// </summary>
        /// <param name="ts"></param>
        /// <returns></returns>
        public static Duration AsDuration(this DateTimeSpan ts) => Duration.FromTimeSpan(ts);

        #endregion

        #region As duration Of Number

        /// <summary>
        /// From milliseconds
        /// </summary>
        /// <param name="milliseconds"></param>
        /// <returns></returns>
        public static Duration AsDurationOfMilliseconds(this long milliseconds) => Duration.FromMilliseconds(milliseconds);

        /// <summary>
        /// From milliseconds
        /// </summary>
        /// <param name="milliseconds"></param>
        /// <returns></returns>
        public static Duration AsDurationOfMilliseconds(this double milliseconds) => Duration.FromMilliseconds(milliseconds);

        /// <summary>
        /// From seconds
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static Duration AsDurationOfSeconds(this long seconds) => Duration.FromSeconds(seconds);

        /// <summary>
        /// From seconds
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static Duration AsDurationOfSeconds(this double seconds) => Duration.FromSeconds(seconds);

        /// <summary>
        /// From minutes
        /// </summary>
        /// <param name="minutes"></param>
        /// <returns></returns>
        public static Duration AsDurationOfMinutes(this long minutes) => Duration.FromMinutes(minutes);

        /// <summary>
        /// From minutes
        /// </summary>
        /// <param name="minutes"></param>
        /// <returns></returns>
        public static Duration AsDurationOfMinutes(this double minutes) => Duration.FromMinutes(minutes);

        /// <summary>
        /// From minutes
        /// </summary>
        /// <param name="hours"></param>
        /// <returns></returns>
        public static Duration AsDurationOfHours(this int hours) => Duration.FromHours(hours);

        /// <summary>
        /// From minutes
        /// </summary>
        /// <param name="hours"></param>
        /// <returns></returns>
        public static Duration AsDurationOfHours(this double hours) => Duration.FromHours(hours);

        /// <summary>
        /// From days
        /// </summary>
        /// <param name="days"></param>
        /// <returns></returns>
        public static Duration AsDurationOfDays(this int days) => Duration.FromDays(days);

        /// <summary>
        /// From days
        /// </summary>
        /// <param name="days"></param>
        /// <returns></returns>
        public static Duration AsDurationOfDays(this double days) => Duration.FromDays(days);

        /// <summary>
        /// From weeks
        /// </summary>
        /// <param name="weeks"></param>
        /// <returns></returns>
        public static Duration AsDurationOfWeeks(this int weeks) => Duration.FromDays(weeks * 7);

        #endregion
    }
}
