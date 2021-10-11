using System;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Text;
using CosmosStack.Reflection;

namespace CosmosStack.Exceptions
{
    /// <summary>
    /// Exception helper <br />
    /// 异常工具
    /// </summary>
    public static class ExceptionHelper
    {
        /// <summary>
        /// Prepare for rethrow <br />
        /// 重新抛出异常
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Exception PrepareForRethrow(Exception exception)
        {
            ExceptionDispatchInfo.Capture(exception).Throw();

            // The code cannot ever get here. We just return a value to work around a badly-designed API (ExceptionDispatchInfo.Throw):
            //  https://connect.microsoft.com/VisualStudio/feedback/details/689516/exceptiondispatchinfo-api-modifications (http://www.webcitation.org/6XQ7RoJmO)
            return exception;
        }

        /// <summary>
        /// Unwrap<br />
        /// 解包
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static Exception Unwrap(Exception ex)
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
        public static Exception Unwrap(Exception ex, Type untilType, bool mayDerivedClass = true)
        {
            if (ex is null)
                throw new ArgumentNullException(nameof(ex));
            if (untilType is null)
                throw new ArgumentNullException(nameof(untilType));
            if (!untilType.IsSubclassOf(typeof(Exception)))
                throw new ArgumentException($"Type '{untilType}' does not be divided from {typeof(Exception)}", nameof(untilType));

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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Exception Unwrap<TException>(Exception ex)
            where TException : Exception
        {
            return ex.Unwrap(Types.Of<TException>());
        }
    }

    /// <summary>
    /// CosmosStack <see cref="Exception"/> extensions. <br />
    /// 异常工具扩展
    /// </summary>
    public static class ExceptionHelperExtensions
    {
        /// <summary>
        /// Unwrap<br />
        /// 解包
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static Exception Unwrap(this Exception ex)
            => ExceptionHelper.Unwrap(ex);

        /// <summary>
        /// Unwrap<br />
        /// 解包
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="untilType"></param>
        /// <param name="mayDerivedClass"></param>
        /// <returns></returns>
        public static Exception Unwrap(this Exception ex, Type untilType, bool mayDerivedClass = true)
            => ExceptionHelper.Unwrap(ex, untilType, mayDerivedClass);

        /// <summary>
        /// Unwrap<br />
        /// 解包
        /// </summary>
        /// <typeparam name="TException"></typeparam>
        /// <param name="ex"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Exception Unwrap<TException>(this Exception ex)
            where TException : Exception
            => ExceptionHelper.Unwrap<TException>(ex);

        /// <summary>
        /// Unwrap and gets message<br />
        /// 解包并返回消息
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToUnwrappedString(this Exception ex) => ex.Unwrap().Message;

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