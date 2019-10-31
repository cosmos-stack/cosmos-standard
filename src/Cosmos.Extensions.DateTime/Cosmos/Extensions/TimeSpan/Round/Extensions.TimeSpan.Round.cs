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
        /// Round
        /// </summary>
        /// <param name="ts"></param>
        /// <param name="rt"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static TimeSpan Round(this TimeSpan ts, RoundTo rt)
        {
            TimeSpan rounded;

            switch (rt)
            {
                case RoundTo.Second:
                {
                    rounded = new TimeSpan(ts.Days, ts.Hours, ts.Minutes, ts.Seconds);
                    if (ts.Milliseconds >= 500)
                    {
                        rounded = rounded + 1.Seconds();
                    }

                    break;
                }
                case RoundTo.Minute:
                {
                    rounded = new TimeSpan(ts.Days, ts.Hours, ts.Minutes, 0);
                    if (ts.Seconds >= 30)
                    {
                        rounded = rounded + 1.Minutes();
                    }

                    break;
                }
                case RoundTo.Hour:
                {
                    rounded = new TimeSpan(ts.Days, ts.Hours, 0, 0);
                    if (ts.Minutes >= 30)
                    {
                        rounded = rounded + 1.Hours();
                    }

                    break;
                }
                case RoundTo.Day:
                {
                    rounded = new TimeSpan(ts.Days, 0, 0, 0);
                    if (ts.Hours >= 12)
                    {
                        rounded = rounded + 1.Days();
                    }

                    break;
                }
                default:
                {
                    throw new NotImplementedException();
                }
            }

            return rounded;
        }
    }
}