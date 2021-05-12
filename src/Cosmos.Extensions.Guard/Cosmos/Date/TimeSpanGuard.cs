using System;
using Cosmos.Optionals;
using Cosmos.Validation;

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
        public static void ShouldBePositive(TimeSpan argument, string argumentName, string message = null)
        {
            ValidationExceptionHelper.WrapAndRaise<ArgumentOutOfRangeException>(
                argument > TimeSpan.Zero,
                argumentName, argument, message ?? $"The given TimeSpan ({nameof(argument)}) should be positive.");
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
        public static void ShouldBePositive(TimeSpan? argument, string argumentName, string message = null)
        {
            ShouldBePositive(argument.SafeValue(), argumentName, message);
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
        public static void ShouldBePositiveOrZero(TimeSpan argument, string argumentName, string message = null)
        {
            ValidationExceptionHelper.WrapAndRaise<ArgumentOutOfRangeException>(
                argument >= TimeSpan.Zero,
                argumentName, argument, message ?? $"The given TimeSpan ({nameof(argument)}) should be positive or zero.");
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
        public static void ShouldBePositiveOrZero(TimeSpan? argument, string argumentName, string message = null)
        {
            ShouldBePositiveOrZero(argument.SafeValue(), argumentName, message);
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
        public static void ShouldBeNegative(TimeSpan argument, string argumentName, string message = null)
        {
            ValidationExceptionHelper.WrapAndRaise<ArgumentOutOfRangeException>(
                argument < TimeSpan.Zero,
                argumentName, argument, message ?? $"The given TimeSpan ({nameof(argument)}) should be negative.");
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
        public static void ShouldBeNegative(TimeSpan? argument, string argumentName, string message = null)
        {
            ShouldBeNegative(argument.SafeValue(), argumentName, message);
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
        public static void ShouldBeNegativeOrZero(TimeSpan argument, string argumentName, string message = null)
        {
            ValidationExceptionHelper.WrapAndRaise<ArgumentOutOfRangeException>(
                argument <= TimeSpan.Zero,
                argumentName, argument, message ?? $"The given TimeSpan ({nameof(argument)}) should be negative or zero.");
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
        public static void ShouldBeNegativeOrZero(TimeSpan? argument, string argumentName, string message = null)
        {
            ShouldBeNegativeOrZero(argument.SafeValue(), argumentName, message);
        }
    }

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
            TimeSpanGuard.ShouldBePositive(argument, argumentName, message);
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
            TimeSpanGuard.ShouldBePositive(argument, argumentName, message);
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
            TimeSpanGuard.ShouldBePositiveOrZero(argument, argumentName, message);
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
            TimeSpanGuard.ShouldBePositiveOrZero(argument, argumentName, message);
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
            TimeSpanGuard.ShouldBeNegative(argument, argumentName, message);
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
            TimeSpanGuard.ShouldBeNegative(argument, argumentName, message);
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
            TimeSpanGuard.ShouldBeNegativeOrZero(argument, argumentName, message);
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
            TimeSpanGuard.ShouldBeNegativeOrZero(argument, argumentName, message);
        }
    }
}