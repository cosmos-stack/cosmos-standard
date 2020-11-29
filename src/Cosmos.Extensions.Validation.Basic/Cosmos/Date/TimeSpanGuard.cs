using System;
using Cosmos.Optionals;
using Cosmos.Validation.Internals;

namespace Cosmos.Date
{
    public static class TimeSpanGuard
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
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void Positive(TimeSpan argument, string argumentName, string message = null)
        {
            ValidationExceptionHelper.WrapAndRaise<ArgumentOutOfRangeException>(
                argument > TimeSpan.Zero,
                argumentName, argument, message ?? $"{nameof(argument)} can not be negative.");
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
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void Positive(TimeSpan? argument, string argumentName, string message = null)
        {
            Positive(argument.SafeValue(), argumentName, message);
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
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void PositiveOrZero(TimeSpan argument, string argumentName, string message = null)
        {
            ValidationExceptionHelper.WrapAndRaise<ArgumentOutOfRangeException>(
                argument >= TimeSpan.Zero,
                argumentName, argument, message ?? $"{nameof(argument)} can not be negative or zero.");
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
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void PositiveOrZero(TimeSpan? argument, string argumentName, string message = null)
        {
            PositiveOrZero(argument.SafeValue(), argumentName, message);
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
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void Negative(TimeSpan argument, string argumentName, string message = null)
        {
            ValidationExceptionHelper.WrapAndRaise<ArgumentOutOfRangeException>(
                argument < TimeSpan.Zero,
                argumentName, argument, message ?? $"{nameof(argument)} can not be negative.");
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
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void Negative(TimeSpan? argument, string argumentName, string message = null)
        {
            Positive(argument.SafeValue(), argumentName, message);
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
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void NegativeOrZero(TimeSpan argument, string argumentName, string message = null)
        {
            ValidationExceptionHelper.WrapAndRaise<ArgumentOutOfRangeException>(
                argument <= TimeSpan.Zero,
                argumentName, argument, message ?? $"{nameof(argument)} can not be negative or zero.");
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
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void NegativeOrZero(TimeSpan? argument, string argumentName, string message = null)
        {
            NegativeOrZero(argument.SafeValue(), argumentName, message);
        }
    }
}