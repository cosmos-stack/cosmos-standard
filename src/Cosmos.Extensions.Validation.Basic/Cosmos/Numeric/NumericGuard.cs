using System;
using Cosmos.Optionals;
using Cosmos.Validation.Internals;

namespace Cosmos.Numeric
{
    public static class NumericGuard
    {
        /// <summary>
        /// Check whether the number is positive. <br />
        /// If the number is negative or zero, an exception is thrown. <br />
        /// 检查数值是否为正的。 <br />
        /// 如果数值为负或为零，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void Positive(int argument, string argumentName, string message = null)
        {
            ValidationExceptionHelper.WrapAndRaise<ArgumentOutOfRangeException>(
                argument > 0,
                argumentName, argument, message ?? $"{nameof(argument)} can not be negative or zero.");
        }

        /// <summary>
        /// Check whether the number is positive. <br />
        /// If the number is negative or zero, an exception is thrown. <br />
        /// 检查数值是否为正的。 <br />
        /// 如果数值为负或为零，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void Positive(int? argument, string argumentName, string message = null)
        {
            Positive(argument.SafeValue(), argumentName, message);
        }

        /// <summary>
        /// Check whether the number is positive or zero. <br />
        /// If the number is negative, an exception is thrown. <br />
        /// 检查数值是否为正或为零。 <br />
        /// 如果数值为负，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void PositiveOrZero(int argument, string argumentName, string message = null)
        {
            ValidationExceptionHelper.WrapAndRaise<ArgumentOutOfRangeException>(
                argument >= 0,
                argumentName, argument, message ?? $"{nameof(argument)} can not be negative.");
        }

        /// <summary>
        /// Check whether the number is positive or zero. <br />
        /// If the number is negative, an exception is thrown. <br />
        /// 检查数值是否为正或为零。 <br />
        /// 如果数值为负，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void PositiveOrZero(int? argument, string argumentName, string message = null)
        {
            PositiveOrZero(argument.SafeValue(), argumentName, message);
        }

        /// <summary>
        /// Check whether the number is negative. <br />
        /// If the number is positive or zero, an exception is thrown. <br />
        /// 检查数值是否为负的。 <br />
        /// 如果数值为正或为零，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void Negative(int argument, string argumentName, string message = null)
        {
            ValidationExceptionHelper.WrapAndRaise<ArgumentOutOfRangeException>(
                argument < 0,
                argumentName, argument, message ?? $"{nameof(argument)} can not be positive or zero.");
        }

        /// <summary>
        /// Check whether the number is negative. <br />
        /// If the number is positive or zero, an exception is thrown. <br />
        /// 检查数值是否为负的。 <br />
        /// 如果数值为正或为零，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void Negative(int? argument, string argumentName, string message = null)
        {
            Negative(argument.SafeValue(), argumentName, message);
        }

        /// <summary>
        /// Check whether the number is negative or zero. <br />
        /// If the number is positive, an exception is thrown. <br />
        /// 检查数值是否为负或为零。 <br />
        /// 如果数值为正，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void NegativeOrZero(int argument, string argumentName, string message = null)
        {
            ValidationExceptionHelper.WrapAndRaise<ArgumentOutOfRangeException>(
                argument <= 0,
                argumentName, argument, message ?? $"{nameof(argument)} can not be positive.");
        }

        /// <summary>
        /// Check whether the number is negative or zero. <br />
        /// If the number is positive, an exception is thrown. <br />
        /// 检查数值是否为负或为零。 <br />
        /// 如果数值为正，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void NegativeOrZero(int? argument, string argumentName, string message = null)
        {
            NegativeOrZero(argument.SafeValue(), argumentName, message);
        }

        /// <summary>
        /// Check whether the value is within the range.
        /// If the value is out of range, an exception is thrown.
        /// 检查数值是否在范围内。
        /// 如果数值超出范围，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void WithinRange(int argument, int min, int max, string argumentName, string message = null)
        {
            ValidationExceptionHelper.WrapAndRaise<ArgumentOutOfRangeException>(
                NumericJudge.IsBetween(argument, min, max),
                argumentName, argument, message ?? $"{nameof(argument)} is not between {min} and {max}.");
        }

        /// <summary>
        /// Check whether the value is within the range.
        /// If the value is out of range, an exception is thrown.
        /// 检查数值是否在范围内。
        /// 如果数值超出范围，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void WithinRange(int? argument, int min, int max, string argumentName, string message = null)
        {
            WithinRange(argument.SafeValue(), min, max, argumentName, message);
        }

        /// <summary>
        /// Check whether the number is positive. <br />
        /// If the number is negative or zero, an exception is thrown. <br />
        /// 检查数值是否为正的。 <br />
        /// 如果数值为负或为零，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void Positive(long argument, string argumentName, string message = null)
        {
            ValidationExceptionHelper.WrapAndRaise<ArgumentOutOfRangeException>(
                argument > 0,
                argumentName, argument, message ?? $"{nameof(argument)} can not be negative or zero.");
        }

        /// <summary>
        /// Check whether the number is positive. <br />
        /// If the number is negative or zero, an exception is thrown. <br />
        /// 检查数值是否为正的。 <br />
        /// 如果数值为负或为零，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void Positive(long? argument, string argumentName, string message = null)
        {
            Positive(argument.SafeValue(), argumentName, message);
        }

        /// <summary>
        /// Check whether the number is positive or zero. <br />
        /// If the number is negative, an exception is thrown. <br />
        /// 检查数值是否为正或为零。 <br />
        /// 如果数值为负，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void PositiveOrZero(long argument, string argumentName, string message = null)
        {
            ValidationExceptionHelper.WrapAndRaise<ArgumentOutOfRangeException>(
                argument >= 0,
                argumentName, argument, message ?? $"{nameof(argument)} can not be negative or zero.");
        }

        /// <summary>
        /// Check whether the number is positive or zero. <br />
        /// If the number is negative, an exception is thrown. <br />
        /// 检查数值是否为正或为零。 <br />
        /// 如果数值为负，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void PositiveOrZero(long? argument, string argumentName, string message = null)
        {
            PositiveOrZero(argument.SafeValue(), argumentName, message);
        }

        /// <summary>
        /// Check whether the number is negative. <br />
        /// If the number is positive or zero, an exception is thrown. <br />
        /// 检查数值是否为负的。 <br />
        /// 如果数值为正或为零，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void Negative(long argument, string argumentName, string message = null)
        {
            ValidationExceptionHelper.WrapAndRaise<ArgumentOutOfRangeException>(
                argument < 0,
                argumentName, argument, message ?? $"{nameof(argument)} can not be positive or zero.");
        }

        /// <summary>
        /// Check whether the number is negative. <br />
        /// If the number is positive or zero, an exception is thrown. <br />
        /// 检查数值是否为负的。 <br />
        /// 如果数值为正或为零，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void Negative(long? argument, string argumentName, string message = null)
        {
            Negative(argument.SafeValue(), argumentName, message);
        }

        /// <summary>
        /// Check whether the number is negative or zero. <br />
        /// If the number is positive, an exception is thrown. <br />
        /// 检查数值是否为负或为零。 <br />
        /// 如果数值为正，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void NegativeOrZero(long argument, string argumentName, string message = null)
        {
            ValidationExceptionHelper.WrapAndRaise<ArgumentOutOfRangeException>(
                argument <= 0,
                argumentName, argument, message ?? $"{nameof(argument)} can not be positive.");
        }

        /// <summary>
        /// Check whether the number is negative or zero. <br />
        /// If the number is positive, an exception is thrown. <br />
        /// 检查数值是否为负或为零。 <br />
        /// 如果数值为正，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void NegativeOrZero(long? argument, string argumentName, string message = null)
        {
            NegativeOrZero(argument.SafeValue(), argumentName, message);
        }

        /// <summary>
        /// Check whether the value is within the range.
        /// If the value is out of range, an exception is thrown.
        /// 检查数值是否在范围内。
        /// 如果数值超出范围，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void WithinRange(long argument, long min, long max, string argumentName, string message = null)
        {
            ValidationExceptionHelper.WrapAndRaise<ArgumentOutOfRangeException>(
                NumericJudge.IsBetween(argument, min, max),
                argumentName, argument, message ?? $"{nameof(argument)} is not between {min} and {max}.");
        }

        /// <summary>
        /// Check whether the value is within the range.
        /// If the value is out of range, an exception is thrown.
        /// 检查数值是否在范围内。
        /// 如果数值超出范围，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void WithinRange(long? argument, long min, long max, string argumentName, string message = null)
        {
            WithinRange(argument.SafeValue(), min, max, argumentName, message);
        }

        /// <summary>
        /// Check whether the number is positive. <br />
        /// If the number is negative or zero, an exception is thrown. <br />
        /// 检查数值是否为正的。 <br />
        /// 如果数值为负或为零，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void Positive(float argument, string argumentName, string message = null)
        {
            ValidationExceptionHelper.WrapAndRaise<ArgumentOutOfRangeException>(
                argument > 0,
                argumentName, argument, message ?? $"{nameof(argument)} can not be negative or zero.");
        }

        /// <summary>
        /// Check whether the number is positive. <br />
        /// If the number is negative or zero, an exception is thrown. <br />
        /// 检查数值是否为正的。 <br />
        /// 如果数值为负或为零，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void Positive(float? argument, string argumentName, string message = null)
        {
            Positive(argument.SafeValue(), argumentName, message);
        }

        /// <summary>
        /// Check whether the number is positive or zero. <br />
        /// If the number is negative, an exception is thrown. <br />
        /// 检查数值是否为正或为零。 <br />
        /// 如果数值为负，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void PositiveOrZero(float argument, string argumentName, string message = null)
        {
            ValidationExceptionHelper.WrapAndRaise<ArgumentOutOfRangeException>(
                argument >= 0,
                argumentName, argument, message ?? $"{nameof(argument)} can not be negative.");
        }

        /// <summary>
        /// Check whether the number is positive or zero. <br />
        /// If the number is negative, an exception is thrown. <br />
        /// 检查数值是否为正或为零。 <br />
        /// 如果数值为负，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void PositiveOrZero(float? argument, string argumentName, string message = null)
        {
            PositiveOrZero(argument.SafeValue(), argumentName, message);
        }

        /// <summary>
        /// Check whether the number is negative. <br />
        /// If the number is positive or zero, an exception is thrown. <br />
        /// 检查数值是否为负的。 <br />
        /// 如果数值为正或为零，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void Negative(float argument, string argumentName, string message = null)
        {
            ValidationExceptionHelper.WrapAndRaise<ArgumentOutOfRangeException>(
                argument < 0,
                argumentName, argument, message ?? $"{nameof(argument)} can not be positive or zero.");
        }

        /// <summary>
        /// Check whether the number is negative. <br />
        /// If the number is positive or zero, an exception is thrown. <br />
        /// 检查数值是否为负的。 <br />
        /// 如果数值为正或为零，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void Negative(float? argument, string argumentName, string message = null)
        {
            Negative(argument.SafeValue(), argumentName, message);
        }

        /// <summary>
        /// Check whether the number is negative or zero. <br />
        /// If the number is positive, an exception is thrown. <br />
        /// 检查数值是否为负或为零。 <br />
        /// 如果数值为正，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void NegativeOrZero(float argument, string argumentName, string message = null)
        {
            ValidationExceptionHelper.WrapAndRaise<ArgumentOutOfRangeException>(
                argument <= 0,
                argumentName, argument, message ?? $"{nameof(argument)} can not be positive.");
        }

        /// <summary>
        /// Check whether the number is negative or zero. <br />
        /// If the number is positive, an exception is thrown. <br />
        /// 检查数值是否为负或为零。 <br />
        /// 如果数值为正，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void NegativeOrZero(float? argument, string argumentName, string message = null)
        {
            NegativeOrZero(argument.SafeValue(), argumentName, message);
        }

        /// <summary>
        /// Check whether the value is within the range.
        /// If the value is out of range, an exception is thrown.
        /// 检查数值是否在范围内。
        /// 如果数值超出范围，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void WithinRange(float argument, float min, float max, string argumentName, string message = null)
        {
            ValidationExceptionHelper.WrapAndRaise<ArgumentOutOfRangeException>(
                NumericJudge.IsBetween(argument, min, max),
                argumentName, argument, message ?? $"{nameof(argument)} is not between {min} and {max}.");
        }

        /// <summary>
        /// Check whether the value is within the range.
        /// If the value is out of range, an exception is thrown.
        /// 检查数值是否在范围内。
        /// 如果数值超出范围，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void WithinRange(float? argument, float min, float max, string argumentName, string message = null)
        {
            WithinRange(argument.SafeValue(), min, max, argumentName, message);
        }

        /// <summary>
        /// Check whether the number is positive. <br />
        /// If the number is negative or zero, an exception is thrown. <br />
        /// 检查数值是否为正的。 <br />
        /// 如果数值为负或为零，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void Positive(double argument, string argumentName, string message = null)
        {
            ValidationExceptionHelper.WrapAndRaise<ArgumentOutOfRangeException>(
                argument > 0,
                argumentName, argument, message ?? $"{nameof(argument)} can not be negative or zero.");
        }

        /// <summary>
        /// Check whether the number is positive. <br />
        /// If the number is negative or zero, an exception is thrown. <br />
        /// 检查数值是否为正的。 <br />
        /// 如果数值为负或为零，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void Positive(double? argument, string argumentName, string message = null)
        {
            Positive(argument.SafeValue(), argumentName, message);
        }

        /// <summary>
        /// Check whether the number is positive or zero. <br />
        /// If the number is negative, an exception is thrown. <br />
        /// 检查数值是否为正或为零。 <br />
        /// 如果数值为负，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void PositiveOrZero(double argument, string argumentName, string message = null)
        {
            ValidationExceptionHelper.WrapAndRaise<ArgumentOutOfRangeException>(
                argument >= 0,
                argumentName, argument, message ?? $"{nameof(argument)} can not be negative.");
        }

        /// <summary>
        /// Check whether the number is positive or zero. <br />
        /// If the number is negative, an exception is thrown. <br />
        /// 检查数值是否为正或为零。 <br />
        /// 如果数值为负，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void PositiveOrZero(double? argument, string argumentName, string message = null)
        {
            PositiveOrZero(argument.SafeValue(), argumentName, message);
        }

        /// <summary>
        /// Check whether the number is negative. <br />
        /// If the number is positive or zero, an exception is thrown. <br />
        /// 检查数值是否为负的。 <br />
        /// 如果数值为正或为零，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void Negative(double argument, string argumentName, string message = null)
        {
            ValidationExceptionHelper.WrapAndRaise<ArgumentOutOfRangeException>(
                argument < 0,
                argumentName, argument, message ?? $"{nameof(argument)} can not be positive or zero.");
        }

        /// <summary>
        /// Check whether the number is negative. <br />
        /// If the number is positive or zero, an exception is thrown. <br />
        /// 检查数值是否为负的。 <br />
        /// 如果数值为正或为零，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void Negative(double? argument, string argumentName, string message = null)
        {
            Negative(argument.SafeValue(), argumentName, message);
        }

        /// <summary>
        /// Check whether the number is negative or zero. <br />
        /// If the number is positive, an exception is thrown. <br />
        /// 检查数值是否为负或为零。 <br />
        /// 如果数值为正，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void NegativeOrZero(double argument, string argumentName, string message = null)
        {
            ValidationExceptionHelper.WrapAndRaise<ArgumentOutOfRangeException>(
                argument <= 0,
                argumentName, argument, message ?? $"{nameof(argument)} can not be positive.");
        }

        /// <summary>
        /// Check whether the number is negative or zero. <br />
        /// If the number is positive, an exception is thrown. <br />
        /// 检查数值是否为负或为零。 <br />
        /// 如果数值为正，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void NegativeOrZero(double? argument, string argumentName, string message = null)
        {
            NegativeOrZero(argument.SafeValue(), argumentName, message);
        }

        /// <summary>
        /// Check whether the value is within the range.
        /// If the value is out of range, an exception is thrown.
        /// 检查数值是否在范围内。
        /// 如果数值超出范围，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void WithinRange(double argument, double min, double max, string argumentName, string message = null)
        {
            ValidationExceptionHelper.WrapAndRaise<ArgumentOutOfRangeException>(
                NumericJudge.IsBetween(argument, min, max),
                argumentName, argument, message ?? $"{nameof(argument)} is not between {min} and {max}.");
        }

        /// <summary>
        /// Check whether the value is within the range.
        /// If the value is out of range, an exception is thrown.
        /// 检查数值是否在范围内。
        /// 如果数值超出范围，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void WithinRange(double? argument, double min, double max, string argumentName, string message = null)
        {
            WithinRange(argument.SafeValue(), min, max, argumentName, message);
        }

        /// <summary>
        /// Check whether the number is positive. <br />
        /// If the number is negative or zero, an exception is thrown. <br />
        /// 检查数值是否为正的。 <br />
        /// 如果数值为负或为零，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void Positive(decimal argument, string argumentName, string message = null)
        {
            ValidationExceptionHelper.WrapAndRaise<ArgumentOutOfRangeException>(
                argument > 0, argumentName, argument, message ?? $"{nameof(argument)} can not be negative or zero.");
        }

        /// <summary>
        /// Check whether the number is positive. <br />
        /// If the number is negative or zero, an exception is thrown. <br />
        /// 检查数值是否为正的。 <br />
        /// 如果数值为负或为零，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void Positive(decimal? argument, string argumentName, string message = null)
        {
            Positive(argument.SafeValue(), argumentName, message);
        }

        /// <summary>
        /// Check whether the number is positive or zero. <br />
        /// If the number is negative, an exception is thrown. <br />
        /// 检查数值是否为正或为零。 <br />
        /// 如果数值为负，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void PositiveOrZero(decimal argument, string argumentName, string message = null)
        {
            ValidationExceptionHelper.WrapAndRaise<ArgumentOutOfRangeException>(
                argument >= 0,
                argumentName, argument, message ?? $"{nameof(argument)} can not be negative.");
        }

        /// <summary>
        /// Check whether the number is positive or zero. <br />
        /// If the number is negative, an exception is thrown. <br />
        /// 检查数值是否为正或为零。 <br />
        /// 如果数值为负，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void PositiveOrZero(decimal? argument, string argumentName, string message = null)
        {
            PositiveOrZero(argument.SafeValue(), argumentName, message);
        }

        /// <summary>
        /// Check whether the number is negative. <br />
        /// If the number is positive or zero, an exception is thrown. <br />
        /// 检查数值是否为负的。 <br />
        /// 如果数值为正或为零，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void Negative(decimal argument, string argumentName, string message = null)
        {
            ValidationExceptionHelper.WrapAndRaise<ArgumentOutOfRangeException>(
                argument < 0,
                argumentName, argument, message ?? $"{nameof(argument)} can not be positive or zero.");
        }

        /// <summary>
        /// Check whether the number is negative. <br />
        /// If the number is positive or zero, an exception is thrown. <br />
        /// 检查数值是否为负的。 <br />
        /// 如果数值为正或为零，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void Negative(decimal? argument, string argumentName, string message = null)
        {
            Negative(argument.SafeValue(), argumentName, message);
        }

        /// <summary>
        /// Check whether the number is negative or zero. <br />
        /// If the number is positive, an exception is thrown. <br />
        /// 检查数值是否为负或为零。 <br />
        /// 如果数值为正，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void NegativeOrZero(decimal argument, string argumentName, string message = null)
        {
            ValidationExceptionHelper.WrapAndRaise<ArgumentOutOfRangeException>(
                argument <= 0,
                argumentName, argument, message ?? $"{nameof(argument)} can not be positive.");
        }

        /// <summary>
        /// Check whether the number is negative or zero. <br />
        /// If the number is positive, an exception is thrown. <br />
        /// 检查数值是否为负或为零。 <br />
        /// 如果数值为正，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void NegativeOrZero(decimal? argument, string argumentName, string message = null)
        {
            NegativeOrZero(argument.SafeValue(), argumentName, message);
        }

        /// <summary>
        /// Check whether the value is within the range.
        /// If the value is out of range, an exception is thrown.
        /// 检查数值是否在范围内。
        /// 如果数值超出范围，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void WithinRange(decimal argument, decimal min, decimal max, string argumentName, string message = null)
        {
            ValidationExceptionHelper.WrapAndRaise<ArgumentOutOfRangeException>(
                NumericJudge.IsBetween(argument, min, max),
                argumentName, argument, message ?? $"{nameof(argument)} is not between {min} and {max}.");
        }

        /// <summary>
        /// Check whether the value is within the range.
        /// If the value is out of range, an exception is thrown.
        /// 检查数值是否在范围内。
        /// 如果数值超出范围，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void WithinRange(decimal? argument, decimal min, decimal max, string argumentName, string message = null)
        {
            WithinRange(argument.SafeValue(), min, max, argumentName, message);
        }
    }
}