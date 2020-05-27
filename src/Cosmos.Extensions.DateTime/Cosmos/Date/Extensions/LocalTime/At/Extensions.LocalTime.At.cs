using NodaTime;

// ReSharper disable once CheckNamespace
namespace Cosmos.Date
{
    /// <summary>
    /// LocalTime extensions
    /// </summary>
    public static partial class LocalTimeExtensions
    {
        /// <summary>
        /// At
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static LocalTime At(this LocalTime dt, int hour, int minute, int second) => dt.SetTime(hour, minute, second);

        /// <summary>
        /// At
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <param name="second"></param>
        /// <param name="milliseconds"></param>
        /// <returns></returns>
        public static LocalTime At(this LocalTime dt, int hour, int minute, int second, int milliseconds) => dt.SetTime(hour, minute, second, milliseconds);
    }
}