using System;
using System.Text;

// ReSharper disable once CheckNamespace
namespace Cosmos {
    /// <summary>
    /// Exception extensions<br />
    /// 异常扩展
    /// </summary>
    public static class ExceptionExtensions {
        /// <summary>
        /// Unwrap<br />
        /// 解包
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static Exception Unwrap(this Exception ex) {
            if (ex is null) {
                throw new ArgumentNullException(nameof(ex));
            }

            while (ex.InnerException != null) {
                ex = ex.InnerException;
            }

            return ex;
        }

        /// <summary>
        /// Unwrap<br />
        /// 解包
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="untilType"></param>
        /// <param name="canbeSubClass"></param>
        /// <returns></returns>
        public static Exception Unwrap(this Exception ex, Type untilType, bool canbeSubClass = true) {
            if (ex is null)
                throw new ArgumentNullException(nameof(ex));
            if (untilType is null)
                throw new ArgumentNullException(nameof(untilType));
            if (!untilType.IsSubclassOf(typeof(Exception)))
                throw new ArgumentException($"Type '{untilType}' does not devide from {typeof(Exception)}", nameof(untilType));
            if (ex.InnerException is null)
                return null;

            var exception = ex.Unwrap();
            return exception.GetType() == untilType || canbeSubClass && exception.GetType().IsSubclassOf(untilType)
                ? exception
                : Unwrap(exception, untilType);
        }

        /// <summary>
        /// Unwrap<br />
        /// 解包
        /// </summary>
        /// <typeparam name="TException"></typeparam>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static Exception Unwrap<TException>(this Exception ex)
            where TException : Exception {
            return ex.Unwrap(Types.Of<TException>());
        }

        /// <summary>
        /// Unwrap and gets message<br />
        /// 解包并返回消息
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static string ToUnwrappedString(this Exception ex) {
            return ex.Unwrap().Message;
        }

        /// <summary>
        /// Unwrap and gets full message<br />
        /// 解包，尝试返回完整信息
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static string ToFullUnwrappedString(this Exception ex) {
            var sb = new StringBuilder();
            if (ex is CosmosException cosmosException) {
                sb.AppendLine(cosmosException.GetFullMessage());
                if (ex.InnerException != null) {
                    sb.Append(ex.InnerException.ToUnwrappedString());
                }
            } else {
                sb.Append(ex.ToUnwrappedString());
            }

            return sb.ToString();
        }
    }
}