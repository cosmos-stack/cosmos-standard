#if !NET451

using System;

namespace Cosmos.Exceptions {
    /// <summary>
    /// Exception builder
    /// </summary>
    public static class ExceptionBuilder {
        /// <summary>
        /// Create a new instance of <see cref="ExceptionBuilder{TException}"/>.
        /// </summary>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        public static IFluentExceptionBuilder<TException> Create<TException>() where TException : Exception {
            return new ExceptionBuilder<TException>();
        }
    }
}

#endif