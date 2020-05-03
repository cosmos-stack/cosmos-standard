using System;

namespace Cosmos.Exceptions {
    /// <summary>
    /// Try
    /// </summary>
    public static class Try {
        /// <summary>
        /// Create a new instance of <see cref="Try{T}"/>.
        /// </summary>
        /// <param name="createFunction"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Try<T> Create<T>(Func<T> createFunction) {
            try {
                return LiftValue(createFunction());
            } catch (Exception ex) {
                return LiftException<T>(ex);
            }
        }

        /// <summary>
        /// Lifts a value.
        /// </summary>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Try<T> LiftValue<T>(T value) => new Success<T>(value);

        /// <summary>
        /// Lifts
        /// </summary>
        /// <param name="ex"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Try<T> LiftException<T>(Exception ex) => new Failure<T>(ex);
    }
}