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
        /// Set time
        /// </summary>
        /// <param name="lt"></param>
        /// <param name="hour"></param>
        /// <returns></returns>
        public static LocalTime SetTime(this LocalTime lt, int hour) =>
            new LocalTime(hour, lt.Minute, lt.Second, lt.Millisecond);

        /// <summary>
        /// Set time
        /// </summary>
        /// <param name="lt"></param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <returns></returns>
        public static LocalTime SetTime(this LocalTime lt, int hour, int minute) =>
            new LocalTime(hour, minute, lt.Second, lt.Millisecond);

        /// <summary>
        /// Set time
        /// </summary>
        /// <param name="lt"></param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static LocalTime SetTime(this LocalTime lt, int hour, int minute, int second) =>
            new LocalTime(hour, minute, second, lt.Millisecond);

        /// <summary>
        /// Set time
        /// </summary>
        /// <param name="lt"></param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <param name="second"></param>
        /// <param name="millisecond"></param>
        /// <returns></returns>
        public static LocalTime SetTime(this LocalTime lt, int hour, int minute, int second, int millisecond) =>
            new LocalTime(hour, minute, second, millisecond);

        /// <summary>
        /// Set time
        /// </summary>
        /// <param name="lt"></param>
        /// <param name="hour"></param>
        /// <returns></returns>
        public static LocalTime SetHour(this LocalTime lt, int hour) =>
            new LocalTime(hour, lt.Minute, lt.Second, lt.Millisecond);

        /// <summary>
        /// Set time
        /// </summary>
        /// <param name="lt"></param>
        /// <param name="minute"></param>
        /// <returns></returns>
        public static LocalTime SetMinute(this LocalTime lt, int minute) =>
            new LocalTime(lt.Hour, minute, lt.Second, lt.Millisecond);

        /// <summary>
        /// Set time
        /// </summary>
        /// <param name="lt"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static LocalTime SetSecond(this LocalTime lt, int second) =>
            new LocalTime(lt.Hour, lt.Minute, second, lt.Millisecond);

        /// <summary>
        /// Set time
        /// </summary>
        /// <param name="lt"></param>
        /// <param name="millisecond"></param>
        /// <returns></returns>
        public static LocalTime SetMillisecond(this LocalTime lt, int millisecond) =>
            new LocalTime(lt.Hour, lt.Minute, lt.Second, millisecond);
    }
}