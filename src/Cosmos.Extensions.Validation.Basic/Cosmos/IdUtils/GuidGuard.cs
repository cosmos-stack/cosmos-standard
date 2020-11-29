using System;
using Cosmos.Optionals;
using Cosmos.Validation.Internals;

namespace Cosmos.IdUtils
{
    public static class GuidGuard
    {
        /// <summary>
        /// Check if Guid is empty or null. <br />
        /// If it is empty or null, an exception is thrown. <br />
        /// 检查 Guid 是否为空。 <br />
        /// 如果为空，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void ValidGuid(Guid argument, string argumentName, string message = null)
        {
            ValidationExceptionHelper.WrapAndRaise<ArgumentNullException>(
                !argument.IsNullOrEmpty(),
                argumentName, message ?? $"{nameof(argument)} can not be null or empty.");
        }

        /// <summary>
        /// Check if Guid is empty or null. <br />
        /// If it is empty or null, an exception is thrown. <br />
        /// 检查 Guid 是否为空。 <br />
        /// 如果为空，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void ValidGuid(Guid? argument, string argumentName, string message = null)
        {
            ValidGuid(argument.SafeValue(), argumentName, message);
        }

    }
}