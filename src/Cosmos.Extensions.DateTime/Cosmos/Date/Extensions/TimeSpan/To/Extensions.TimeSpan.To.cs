using System;

// ReSharper disable once CheckNamespace
namespace Cosmos.Date
{
    /// <summary>
    /// TimeSpan extensions
    /// </summary>
    public static partial class TimeSpanExtensions
    {
        /// <summary>
        /// To display string
        /// </summary>
        /// <param name="ts"></param>
        /// <returns></returns>
        public static string ToDisplayString(this TimeSpan ts)
        {
            if (ts.TotalDays > 1)
            {
                var round = ts.Round(RoundTo.Hour);
                return $"{round.Days} days and {round.Hours} hours";
            }

            if (ts.TotalHours > 1)
            {
                var round = ts.Round(RoundTo.Minute);
                return $"{round.Hours} hours and {round.Minutes} minutes";
            }

            if (ts.TotalMinutes > 1)
            {
                var round = ts.Round(RoundTo.Second);
                return $"{round.Minutes} minutes and {round.Seconds} seconds";
            }

            if (ts.TotalSeconds > 1)
            {
                return $"{ts.TotalSeconds} seconds";
            }

            return $"{ts.Milliseconds} milliseconds";
        }

        /// <summary>
        /// To datetime
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static DateTime ToDateTime(this TimeSpan time)
        {
            var ticks = time.Ticks;
            if (ticks < 0 || ticks > 3155378975999999999)
                throw new ArgumentOutOfRangeException(nameof(time));

            return new DateTime(ticks);
        }
    }
}