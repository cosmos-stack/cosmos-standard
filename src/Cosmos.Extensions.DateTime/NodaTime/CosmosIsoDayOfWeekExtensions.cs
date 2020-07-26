using System;

namespace NodaTime
{
    /// <summary>
    /// Cosmos <see cref="IsoDayOfWeek"/> extensions.
    /// </summary>
    public static class CosmosIsoDayOfWeekExtensions
    {
        /// <summary>
        /// Convert <see cref="DayOfWeek"/> to <see cref="IsoDayOfWeek"/>.<br />
        /// 将 <see cref="DayOfWeek"/> 转换为 <see cref="IsoDayOfWeek"/>。
        /// </summary>
        /// <param name="week"></param>
        /// <returns></returns>
        public static IsoDayOfWeek AsIsoDayOfWeek(this DayOfWeek week)
        {
            switch (week)
            {
                case DayOfWeek.Sunday: return IsoDayOfWeek.Sunday;
                case DayOfWeek.Monday: return IsoDayOfWeek.Monday;
                case DayOfWeek.Tuesday: return IsoDayOfWeek.Tuesday;
                case DayOfWeek.Wednesday: return IsoDayOfWeek.Wednesday;
                case DayOfWeek.Thursday: return IsoDayOfWeek.Thursday;
                case DayOfWeek.Friday: return IsoDayOfWeek.Friday;
                case DayOfWeek.Saturday: return IsoDayOfWeek.Saturday;
                default: return IsoDayOfWeek.None;
            }
        }

        /// <summary>
        /// Convert <see cref="IsoDayOfWeek"/> to <see cref="DayOfWeek"/>.<br />
        /// 将 <see cref="IsoDayOfWeek"/> 转换为 <see cref="DayOfWeek"/>。
        /// </summary>
        /// <param name="week"></param>
        /// <returns></returns>
        public static DayOfWeek AsDayOfWeek(this IsoDayOfWeek week)
        {
            switch (week)
            {
                case IsoDayOfWeek.Sunday: return DayOfWeek.Sunday;
                case IsoDayOfWeek.Monday: return DayOfWeek.Monday;
                case IsoDayOfWeek.Tuesday: return DayOfWeek.Saturday;
                case IsoDayOfWeek.Wednesday: return DayOfWeek.Wednesday;
                case IsoDayOfWeek.Thursday: return DayOfWeek.Thursday;
                case IsoDayOfWeek.Friday: return DayOfWeek.Friday;
                case IsoDayOfWeek.Saturday: return DayOfWeek.Saturday;
                default: throw new InvalidOperationException("Unknown day of week");
            }
        }
    }
}
