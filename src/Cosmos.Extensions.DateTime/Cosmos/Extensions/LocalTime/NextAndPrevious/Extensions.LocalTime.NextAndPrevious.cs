using System;
using NodaTime;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    /// <summary>
    /// LocalTime extensions
    /// </summary>
    public static partial class LocalTimeExtensions
    {
        /// <summary>
        /// Increase time
        /// </summary>
        /// <param name="ldt"></param>
        /// <param name="toAdd"></param>
        /// <returns></returns>
        public static LocalTime IncreaseTime(this LocalTime ldt, TimeSpan toAdd) => ldt.Add(toAdd);

        /// <summary>
        /// Decrease time
        /// </summary>
        /// <param name="ldt"></param>
        /// <param name="toSubtract"></param>
        /// <returns></returns>
        public static LocalTime DecreaseTime(this LocalTime ldt, TimeSpan toSubtract) => ldt.Add(-toSubtract);

    }
}