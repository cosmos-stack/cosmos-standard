using System;

// ReSharper disable once CheckNamespace
namespace Cosmos.Date
{
    /// <summary>
    /// DateTime Extensions<br />
    /// DateTime 扩展方法
    /// </summary>
    public static partial class DateTimeExtensions
    {
        /// <summary>
        /// Rounds <paramref name="dt"/> to the nearest <see cref="RoundTo"/>.
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="rt"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static DateTime Round(this DateTime dt, RoundTo rt)
        {
            DateTime rounded;

            switch (rt)
            {
                case RoundTo.Second:
                {
                    rounded = new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Kind);
                    if (dt.Millisecond >= 500)
                    {
                        rounded = rounded.AddSeconds(1);
                    }

                    break;
                }
                case RoundTo.Minute:
                {
                    rounded = new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, 0, dt.Kind);
                    if (dt.Second >= 30)
                    {
                        rounded = rounded.AddMinutes(1);
                    }

                    break;
                }
                case RoundTo.Hour:
                {
                    rounded = new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, 0, 0, dt.Kind);
                    if (dt.Minute >= 30)
                    {
                        rounded = rounded.AddHours(1);
                    }

                    break;
                }
                case RoundTo.Day:
                {
                    rounded = new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0, dt.Kind);
                    if (dt.Hour >= 12)
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