using System;

namespace Cosmos.Optionals {
    /// <summary>
    /// Interface for optional
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TException"></typeparam>
    public interface IOptional<T, out TException> : IOptional<T> {
        /// <summary>
        /// Exception
        /// </summary>
        TException Exception { get; }
        
        /// <summary>
        /// Gets UnderlyingType for exception
        /// </summary>
        Type UnderlyingExceptionType { get; }

        /// <summary>
        /// Value or
        /// </summary>
        /// <param name="alternativeFactory"></param>
        /// <returns></returns>
        T ValueOr(Func<TException, T> alternativeFactory);
    }
}