using System;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    /// <summary>
    /// TimeSpan extensions
    /// </summary>
    public static partial class TimeSpanExtensions
    {
        /// <summary>
        /// Before
        /// </summary>
        /// <param name="ts"></param>
        /// <param name="originalValue"></param>
        /// <returns></returns>
        public static DateTime Before(this TimeSpan ts, DateTime originalValue)
        {
            return originalValue - ts;
        }
        
        /// <summary>
        /// DateTimeOffset Before
        /// </summary>
        /// <param name="ts"></param>
        /// <param name="originalValue"></param>
        /// <returns></returns>
        public static DateTimeOffset Before(this TimeSpan ts, DateTimeOffset originalValue)
        {
            return originalValue - ts;
        }
    }
}