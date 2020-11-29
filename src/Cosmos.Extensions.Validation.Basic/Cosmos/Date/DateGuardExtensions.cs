using System;

namespace Cosmos.Date
{
    public static class DateGuardExtensions
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
        public static void CheckInvalidDate(this DateTime argument, string argumentName, string message = null)
        {
            DateGuard.ValidDate(argument, argumentName, message);
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
        public static void CheckInvalidDate(this DateTime? argument, string argumentName, string message = null)
        {
            DateGuard.ValidDate(argument, argumentName, message);
        }
    }
}