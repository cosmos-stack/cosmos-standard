using System;

namespace Cosmos.Date
{
    public static class TimeSpanGuardExtensions
    {
        /// <summary>
        /// Check whether the time span is positive. <br />
        /// If the time span is negative or zero, an exception is thrown. <br />
        /// 检查时间跨度是否为正的。 <br />
        /// 如果时间跨度为负或为零，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void RequirePositive(this TimeSpan argument, string argumentName, string message = null)
        {
            TimeSpanGuard.Positive(argument, argumentName, message);
        }

        /// <summary>
        /// Check whether the time span is positive. <br />
        /// If the time span is negative or zero, an exception is thrown. <br />
        /// 检查时间跨度是否为正的。 <br />
        /// 如果时间跨度为负或为零，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void RequirePositive(this TimeSpan? argument, string argumentName, string message = null)
        {
            TimeSpanGuard.Positive(argument, argumentName, message);
        }
        
        /// <summary>
        /// Check whether the time span is positive or zero. <br />
        /// If the time span is negative, an exception is thrown. <br />
        /// 检查时间跨度是否为正或为零。 <br />
        /// 如果时间跨度为负，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void RequirePositiveOrZero(this TimeSpan argument, string argumentName, string message = null)
        {
            TimeSpanGuard.PositiveOrZero(argument, argumentName, message);
        }

        /// <summary>
        /// Check whether the time span is positive or zero. <br />
        /// If the time span is negative, an exception is thrown. <br />
        /// 检查时间跨度是否为正或为零。 <br />
        /// 如果时间跨度为负，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void RequirePositiveOrZero(this TimeSpan? argument, string argumentName, string message = null)
        {
            TimeSpanGuard.PositiveOrZero(argument, argumentName, message);
        }
        
        /// <summary>
        /// Check whether the time span is negative. <br />
        /// If the time span is positive or zero, an exception is thrown. <br />
        /// 检查时间跨度是否为负。 <br />
        /// 如果时间跨度为正或为零，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void RequireNegative(this TimeSpan argument, string argumentName, string message = null)
        {
            TimeSpanGuard.Negative(argument, argumentName, message);
        }

        /// <summary>
        /// Check whether the time span is negative. <br />
        /// If the time span is positive or zero, an exception is thrown. <br />
        /// 检查时间跨度是否为负。 <br />
        /// 如果时间跨度为正或为零，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void RequireNegative(this TimeSpan? argument, string argumentName, string message = null)
        {
            TimeSpanGuard.Negative(argument, argumentName, message);
        }

        /// <summary>
        /// Check whether the time span is negative or zero. <br />
        /// If the time span is positive, an exception is thrown. <br />
        /// 检查时间跨度是否为负或为零。 <br />
        /// 如果时间跨度为正，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void RequireNegativeOrZero(this TimeSpan argument, string argumentName, string message = null)
        {
            TimeSpanGuard.NegativeOrZero(argument, argumentName, message);
        }

        /// <summary>
        /// Check whether the time span is negative or zero. <br />
        /// If the time span is positive, an exception is thrown. <br />
        /// 检查时间跨度是否为负或为零。 <br />
        /// 如果时间跨度为正，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void RequireNegativeOrZero(this TimeSpan? argument, string argumentName, string message = null)
        {
            TimeSpanGuard.NegativeOrZero(argument, argumentName, message);
        }
    }
}