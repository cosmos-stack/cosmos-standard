using System;
using System.Runtime.CompilerServices;

namespace CosmosStack.Date
{
    /// <summary>
    /// Time Span Extensions <br />
    /// Time Span 扩展
    /// </summary>
    public static class TimeSpanExtensions
    {
        #region Ago

        /// <summary>
        /// Ago <br />
        /// 在……之前
        /// </summary>
        /// <param name="ts"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTime Ago(this TimeSpan ts) => ts.Before(DateTime.Now);

        /// <summary>
        /// Ago <br />
        /// 在……之前
        /// </summary>
        /// <param name="ts"></param>
        /// <param name="originalValue"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTime Ago(this TimeSpan ts, DateTime originalValue) => ts.Before(originalValue);

        /// <summary>
        /// DateTimeOffset Ago <br />
        /// 在……之前
        /// </summary>
        /// <param name="ts"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTimeOffset OffsetAgo(this TimeSpan ts) => ts.Before(DateTimeOffset.Now);

        /// <summary>
        /// DateTimeOffset Ago <br />
        /// 在……之前
        /// </summary>
        /// <param name="ts"></param>
        /// <param name="originalValue"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTimeOffset Ago(this TimeSpan ts, DateTimeOffset originalValue) => ts.Before(originalValue);

        #endregion

        #region Before

        /// <summary>
        /// Before <br />
        /// 在……之前
        /// </summary>
        /// <param name="ts"></param>
        /// <param name="originalValue"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTime Before(this TimeSpan ts, DateTime originalValue) => originalValue - ts;

        /// <summary>
        /// DateTimeOffset Before
        /// </summary> <br />
        /// 在……之前
        /// <param name="ts"></param>
        /// <param name="originalValue"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTimeOffset Before(this TimeSpan ts, DateTimeOffset originalValue) => originalValue - ts;

        #endregion

        #region Fluent TimeSpan

        /// <summary>
        /// Adds the given <see cref="DateTimeSpan"/> from a <see cref="TimeSpan"/> and returns resulting <see cref="DateTimeSpan"/>.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTimeSpan AddFluentTimeSpan(this TimeSpan ts, DateTimeSpan fluentTimeSpan) => fluentTimeSpan.Add(ts);

        /// <summary>
        /// Subtracts the given <see cref="DateTimeSpan"/> from a <see cref="TimeSpan"/> and returns resulting <see cref="DateTimeSpan"/>.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTimeSpan SubtractFluentTimeSpan(this TimeSpan ts, DateTimeSpan fluentTimeSpan) => DateTimeSpan.SubtractInternal(ts, fluentTimeSpan);

        #endregion

        #region From

        /// <summary>
        /// From now <br />
        /// 根据当前时间和 TimeSpan 计算出一个新的 DateTime
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
        public static DateTime FromNow(this TimeSpan from) => @from.From(DateTime.Now);

        /// <summary>
        /// From <br />
        /// 根据给定时间和 TimeSpan 计算出一个新的 DateTime
        /// </summary>
        /// <param name="ts"></param>
        /// <param name="originalValue"></param>
        /// <returns></returns>
        public static DateTime From(this TimeSpan ts, DateTime originalValue) => originalValue + ts;

        /// <summary>
        /// DateTimeOffset from now <br />
        /// 根据当前时间和 TimeSpan 计算出一个新的 DateTimeOffset
        /// </summary>
        /// <param name="ts"></param>
        /// <returns></returns>
        public static DateTimeOffset OffsetFromNow(this TimeSpan ts) => ts.From(DateTimeOffset.Now);

        /// <summary>
        /// DateTimeOffset from <br />
        /// 根据给定时间和 TimeSpan 计算出一个新的 DateTimeOffset
        /// </summary>
        /// <param name="ts"></param>
        /// <param name="originalValue"></param>
        /// <returns></returns>
        public static DateTimeOffset From(this TimeSpan ts, DateTimeOffset originalValue) => originalValue + ts;

        #endregion

        #region Round

        /// <summary>
        /// Round <br />
        /// 舍入
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

        #endregion

        #region Since

        /// <summary>
        /// Since <br />
        /// 自……开始
        /// </summary>
        /// <param name="ts"></param>
        /// <param name="originalValue"></param>
        /// <returns></returns>
        public static DateTime Since(this TimeSpan ts, DateTime originalValue) => From(ts, originalValue);

        /// <summary>
        /// DateTimeOffset since <br />
        /// 自……开始
        /// </summary>
        /// <param name="ts"></param>
        /// <param name="originalValue"></param>
        /// <returns></returns>
        public static DateTimeOffset Since(this TimeSpan ts, DateTimeOffset originalValue) => From(ts, originalValue);

        #endregion

        #region To

        /// <summary>
        /// To display string <br />
        /// 显示
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
        /// To datetime <br />
        /// 转换为 DateTime
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static DateTime ToDateTime(this TimeSpan time)
        {
            var ticks = time.Ticks;
            if (ticks < 0 || ticks > 3155378975999999999)
                throw new ArgumentOutOfRangeException(nameof(time));
            return new(ticks);
        }

        #endregion
    }
}