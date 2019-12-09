using NodaTime;

// ReSharper disable once CheckNamespace
namespace Cosmos {
    /// <summary>
    /// LocalDateTime extensions
    /// </summary>
    public static partial class LocalDateTimeExtensions {
        /// <summary>
        /// At
        /// </summary>
        /// <param name="ldt"></param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static LocalDateTime At(this LocalDateTime ldt, int hour, int minute, int second) => ldt.SetTime(hour, minute, second);

        /// <summary>
        /// At
        /// </summary>
        /// <param name="ldt"></param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <param name="second"></param>
        /// <param name="milliseconds"></param>
        /// <returns></returns>
        public static LocalDateTime At(this LocalDateTime ldt, int hour, int minute, int second, int milliseconds) => ldt.SetTime(hour, minute, second, milliseconds);
    }
}