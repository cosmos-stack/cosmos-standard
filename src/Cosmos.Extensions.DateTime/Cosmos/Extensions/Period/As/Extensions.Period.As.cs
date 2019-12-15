using System;
using Cosmos.Date;
using NodaTime;

// ReSharper disable once CheckNamespace
namespace Cosmos {
    /// <summary>
    /// Period extensions
    /// </summary>
    public static partial class PeriodExtensions {
        /// <summary>
        /// From TimeSpan
        /// </summary>
        /// <param name="ts"></param>
        /// <returns></returns>
        public static Period AsPeriod(this TimeSpan ts) => Period.FromTicks(ts.Ticks);

        /// <summary>
        /// From DateTimeSpan
        /// </summary>
        /// <param name="ts"></param>
        /// <returns></returns>
        public static Period AsPeriod(this DateTimeSpan ts) => ts;

        /// <summary>
        /// From duration
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static Period AsPeriod(this Duration d) => Period.FromTicks(d.ToTimeSpan().Ticks);

        /// <summary>
        /// To TimeSpan
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static TimeSpan AsTimeSpan(this Period p) => TimeSpan.FromTicks(p.Ticks);

        /// <summary>
        /// To DateTimeSpan
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static DateTimeSpan AsDateTimeSpan(this Period p) => p;

        /// <summary>
        /// TO Duration
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Duration AsDuration(this Period p) => Duration.FromTicks(p.Ticks);
    }
}