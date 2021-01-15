#if !NET451 && !NET452
using System;
using Cosmos.Reflection;

namespace Cosmos.Exceptions
{
    /// <summary>
    /// Exception builder
    /// </summary>
    public static class ExceptionBuilder
    {
        /// <summary>
        /// Create a new builder for of <typeparamref name="TException"/> <see cref="ExceptionBuilder{TException}"/>.<br />
        /// 创建一个用于构建 <typeparamref name="TException"/> <see cref="ExceptionBuilder{TException}"/> 的 builder。
        /// </summary>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        public static IFluentExceptionBuilder<TException> Create<TException>() where TException : Exception
            => new ExceptionBuilder<TException>();

        /// <summary>
        /// Create an exception and raise.
        /// </summary>
        /// <typeparam name="TException">Special type T.</typeparam>
        /// <param name="assertion">Predicate.</param>
        /// <param name="message">Error message.</param>
        public static void Raise<TException>(bool assertion, string message) where TException : Exception
        {
            if (assertion)
                return;

            Exception exception;

            if (string.IsNullOrEmpty(message))
            {
                exception = new ArgumentNullException(nameof(message));
            }
            else
            {
                exception = Create<TException>().Message(message).Build();
            }

            ExceptionHelper.PrepareForRethrow(exception);
        }

        /// <summary>
        /// Create an exception and raise.
        /// </summary>
        /// <typeparam name="TException">Special type T.</typeparam>
        /// <param name="assertion">Predicate.</param>
        /// <param name="message">Error message.</param>
        /// <param name="innerException"></param>
        public static void Raise<TException>(bool assertion, string message,Exception innerException) where TException : Exception
        {
            if (assertion)
                return;

            Exception exception;

            if (string.IsNullOrEmpty(message))
            {
                exception = new ArgumentNullException(nameof(message));
            }
            else
            {
                exception = Create<TException>().Message(message).InnerException(innerException).Build();
            }

            ExceptionHelper.PrepareForRethrow(exception);
        }

        /// <summary>
        /// Create an exception and raise.
        /// </summary>
        /// <typeparam name="TException">Special type TException.</typeparam>
        /// <param name="assertion">Predicate.</param>
        /// <param name="exceptionParams">Parameters for exception.</param>
        public static void Raise<TException>(bool assertion, params object[] exceptionParams) where TException : Exception
        {
            if (assertion)
                return;

            var exception = TypeVisit.CreateInstance<TException>(exceptionParams);

            ExceptionHelper.PrepareForRethrow(exception);
        }

        /// <summary>
        /// Create an exception and raise.
        /// </summary>
        /// <typeparam name="TException">Special type TException.</typeparam>
        /// <param name="assertion">Predicate.</param>
        /// <param name="options">Cosmos exception options.</param>
        public static void Raise<TException>(bool assertion, ExceptionOptions options) where TException : CosmosException
        {
            if (assertion)
                return;

            Exception exception;

            if (options is null)
            {
                exception = new ArgumentNullException(nameof(options));
            }
            else
            {
                exception = TypeVisit.CreateInstance<TException>(options);
            }

            ExceptionHelper.PrepareForRethrow(exception);
        }
    }
}

#endif