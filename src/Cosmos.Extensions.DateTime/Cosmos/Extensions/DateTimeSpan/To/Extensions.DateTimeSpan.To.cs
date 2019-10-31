using System;
using Cosmos.Date;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    /// <summary>
    /// DateTimeSpan Extensions<br />
    /// DateTimeSpan 扩展方法
    /// </summary>
    public static partial class DateTimeSpanExtensions
    {
        /// <summary>
        /// To display string
        /// </summary>
        /// <param name="ts"></param>
        /// <returns></returns>
        public static string ToDisplayString(this DateTimeSpan ts)
        {
            return ((TimeSpan) ts).ToDisplayString();
        }
    }
}