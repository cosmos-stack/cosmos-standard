using System;

// ReSharper disable once CheckNamespace
namespace Cosmos.Date
{
    /// <summary>
    /// DateTimeOffset Extensions<br />
    /// DateTimeOffset 扩展方法
    /// </summary>
    public static partial class DateTimeOffsetExtensions
    {
        /// <summary>
        /// Round
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="rt"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static DateTimeOffset Round(this DateTimeOffset dateTime, RoundTo rt)
        {
            DateTimeOffset rounded;

            switch (rt)
            {
                case RoundTo.Second:
                {
                    rounded = new DateTimeOffset(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second, dateTime.Offset);
                    if (dateTime.Millisecond >= 500)
                    {
                        rounded = rounded.AddSeconds(1);
                    }

                    break;
                }
                case RoundTo.Minute:
                {
                    rounded = new DateTimeOffset(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, 0, dateTime.Offset);
                    if (dateTime.Second >= 30)
                    {
                        rounded = rounded.AddMinutes(1);
                    }

                    break;
                }
                case RoundTo.Hour:
                {
                    rounded = new DateTimeOffset(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, 0, 0, dateTime.Offset);
                    if (dateTime.Minute >= 30)
                    {
                        rounded = rounded.AddHours(1);
                    }

                    break;
                }
                case RoundTo.Day:
                {
                    rounded = new DateTimeOffset(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0, dateTime.Offset);
                    if (dateTime.Hour >= 12)
                    {
                        rounded = rounded.AddDays(1);
                    }

                    break;
                }
                default:
                {
                    throw new ArgumentOutOfRangeException("rt");
                }
            }

            return rounded;
        }
    }
}