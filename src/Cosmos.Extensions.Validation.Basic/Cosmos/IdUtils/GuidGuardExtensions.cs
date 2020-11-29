using System;

namespace Cosmos.IdUtils
{
    public static class GuidGuardExtensions
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
        public static void CheckNull(this Guid argument, string argumentName, string message = null)
        {
            GuidGuard.ValidGuid(argument, argumentName, message);
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
        public static void CheckNull(this Guid? argument, string argumentName, string message = null)
        {
            GuidGuard.ValidGuid(argument, argumentName, message);
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
        public static void Require(this Guid argument, string argumentName, string message = null)
        {
            CheckNull(argument, argumentName, message);
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
        public static void Require(this Guid? argument, string argumentName, string message = null)
        {
            CheckNull(argument, argumentName, message);
        }
    }
}