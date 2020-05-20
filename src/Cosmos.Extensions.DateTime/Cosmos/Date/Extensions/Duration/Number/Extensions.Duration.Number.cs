using NodaTime;

// ReSharper disable once CheckNamespace
namespace Cosmos.Date
{
    /// <summary>
    /// Duration extensions
    /// </summary>
    public static partial class DurationExtensions
    {
        /// <summary>
        /// From milliseconds
        /// </summary>
        /// <param name="milliseconds"></param>
        /// <returns></returns>
        public static Duration DurationMilliseconds(this long milliseconds) => Duration.FromMilliseconds(milliseconds);

        /// <summary>
        /// From milliseconds
        /// </summary>
        /// <param name="milliseconds"></param>
        /// <returns></returns>
        public static Duration DurationMilliseconds(this double milliseconds) => Duration.FromMilliseconds(milliseconds);

        /// <summary>
        /// From seconds
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static Duration DurationSeconds(this long seconds) => Duration.FromSeconds(seconds);

        /// <summary>
        /// From seconds
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static Duration DurationSeconds(this double seconds) => Duration.FromSeconds(seconds);

        /// <summary>
        /// From minutes
        /// </summary>
        /// <param name="minutes"></param>
        /// <returns></returns>
        public static Duration DurationMinutes(this long minutes) => Duration.FromMinutes(minutes);

        /// <summary>
        /// From minutes
        /// </summary>
        /// <param name="minutes"></param>
        /// <returns></returns>
        public static Duration DurationMinutes(this double minutes) => Duration.FromMinutes(minutes);

        /// <summary>
        /// From minutes
        /// </summary>
        /// <param name="hours"></param>
        /// <returns></returns>
        public static Duration DurationHours(this int hours) => Duration.FromHours(hours);

        /// <summary>
        /// From minutes
        /// </summary>
        /// <param name="hours"></param>
        /// <returns></returns>
        public static Duration DurationHours(this double hours) => Duration.FromHours(hours);

        /// <summary>
        /// From days
        /// </summary>
        /// <param name="days"></param>
        /// <returns></returns>
        public static Duration DurationDays(this int days) => Duration.FromDays(days);

        /// <summary>
        /// From days
        /// </summary>
        /// <param name="days"></param>
        /// <returns></returns>
        public static Duration DurationDays(this double days) => Duration.FromDays(days);

        /// <summary>
        /// From weeks
        /// </summary>
        /// <param name="weeks"></param>
        /// <returns></returns>
        public static Duration DurationWeeks(this int weeks) => Duration.FromDays(weeks * 7);
    }
}