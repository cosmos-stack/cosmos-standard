using System;
using System.Text;

namespace Cosmos.Exceptions
{
    /// <summary>
    /// Cosmos <see cref="Exception"/> extensions.
    /// </summary>
    public static class ExceptionExtensions
    {
        /// <summary>
        /// Unwrap<br />
        /// 解包
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static Exception Unwrap(this Exception ex)
        {
            if (ex is null)
                throw new ArgumentNullException(nameof(ex));
            while (ex.InnerException != null)
                ex = ex.InnerException;
            return ex;
        }

        /// <summary>
        /// Unwrap<br />
        /// 解包
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="untilType"></param>
        /// <param name="mayDerivedClass"></param>
        /// <returns></returns>
        public static Exception Unwrap(this Exception ex, Type untilType, bool mayDerivedClass = true)
        {
            if (ex is null)
                throw new ArgumentNullException(nameof(ex));
            if (untilType is null)
                throw new ArgumentNullException(nameof(untilType));
            if (!untilType.IsSubclassOf(typeof(Exception)))
                throw new ArgumentException($"Type '{untilType}' does not devide from {typeof(Exception)}", nameof(untilType));

            var exception = ex;
            return exception.GetType() == untilType || mayDerivedClass && exception.GetType().IsSubclassOf(untilType)
                ? exception
                : exception.InnerException is null
                    ? null
                    : Unwrap(exception.InnerException, untilType, mayDerivedClass);
        }

        /// <summary>
        /// Unwrap<br />
        /// 解包
        /// </summary>
        /// <typeparam name="TException"></typeparam>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static Exception Unwrap<TException>(this Exception ex)
            where TException : Exception
        {
            return ex.Unwrap(Reflection.Types.Of<TException>());
        }

        /// <summary>
        /// Unwrap and gets message<br />
        /// 解包并返回消息
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static string ToUnwrappedString(this Exception ex)
        {
            return ex.Unwrap().Message;
        }

        /// <summary>
        /// Unwrap and gets full message<br />
        /// 解包，尝试返回完整信息
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static string ToFullUnwrappedString(this Exception ex)
        {
            var sb = new StringBuilder();
            if (ex is CosmosException cosmosException)
            {
                sb.AppendLine(cosmosException.GetFullMessage());
                if (ex.InnerException != null)
                {
                    sb.Append(ex.InnerException.ToUnwrappedString());
                }
            }
            else
            {
                sb.Append(ex.ToUnwrappedString());
            }

            return sb.ToString();
        }
    }
}