using System;
using Cosmos.Optionals;
using Cosmos.Validation.Internals;

namespace Cosmos.Date
{
    public static class DateGuard
    {
        /// <summary>
        /// Check if the date is valid. <br />
        /// If the date is invalid, an exception is thrown. <br />
        /// 检查日期是否有效。 <br />
        /// 如果日期是无效的，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void ValidDate(DateTime argument, string argumentName, string message = null)
        {
            ValidationExceptionHelper.WrapAndRaise<ArgumentInvalidException>(
                IsValid(argument),
                message ?? $"{nameof(argument)} is invalid datetime value.", argumentName);

            static bool IsValid(DateTime dt)
            {
                var min = new DateTime(1900, 1, 1);
                var max = new DateTime(9999, 12, 31, 23, 59, 59, 999);
                return dt >= min && dt <= max;
            }
        }

        /// <summary>
        /// Check if the date is valid. <br />
        /// If the date is invalid, an exception is thrown. <br />
        /// 检查日期是否有效。 <br />
        /// 如果日期是无效的，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void ValidDate(DateTime? argument, string argumentName, string message = null)
        {
            ValidDate(argument.SafeValue(), argumentName, message);
        }

        /// <summary>
        /// Check if the date is in the past. <br />
        /// If the date is not in the past, an exception is thrown. <br />
        /// 检查日期是否为过去的时间。 <br />
        /// 如果日期不是过去的时间，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void InThePast(DateTime argument, string argumentName, string message = null)
        {
            ValidationExceptionHelper.WrapAndRaise<ArgumentOutOfRangeException>(
                argument <= DateTime.UtcNow,
                argumentName, argument, message ?? $"{nameof(argument)} can not be in past.");
        }

        /// <summary>
        /// Check if the date is in the past. <br />
        /// If the date is not in the past, an exception is thrown. <br />
        /// 检查日期是否为过去的时间。 <br />
        /// 如果日期不是过去的时间，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void InThePast(DateTime? argument, string argumentName, string message = null)
        {
            InThePast(argument.SafeValue(), argumentName, message);
        }

        /// <summary>
        /// Check if the date is in the future. <br />
        /// If the date is not in the future, an exception is thrown. <br />
        /// 检查日期是否为将来的时间。 <br />
        /// 如果日期不是将来的时间，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void InTheFuture(DateTime argument, string argumentName, string message = null)
        {
            ValidationExceptionHelper.WrapAndRaise<ArgumentOutOfRangeException>(
                argument >= DateTime.UtcNow,
                argumentName, argument, message ?? $"{nameof(argument)} can not be in future.");
        }

        /// <summary>
        /// Check if the date is in the future. <br />
        /// If the date is not in the future, an exception is thrown. <br />
        /// 检查日期是否为将来的时间。 <br />
        /// 如果日期不是将来的时间，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void InTheFuture(DateTime? argument, string argumentName, string message = null)
        {
            InTheFuture(argument.SafeValue(), argumentName, message);
        }
    }
}