using System;
using Cosmos.Date;

// ReSharper disable once CheckNamespace
namespace Cosmos
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
    }
}