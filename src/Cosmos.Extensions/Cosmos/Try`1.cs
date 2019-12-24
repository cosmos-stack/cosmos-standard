using System;

namespace Cosmos {
    public abstract class Try<T> {
        /// <summary>
        /// Is failure
        /// </summary>
        public abstract bool IsFailure { get; }

        /// <summary>
        /// Is success
        /// </summary>
        public abstract bool IsSuccess { get; }

        /// <summary>
        /// Exception
        /// </summary>
        public abstract Exception Exception { get; }

        /// <summary>
        /// Value
        /// </summary>
        public abstract T Value { get; }

        /// <summary>
        /// ==
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Try<T> left, Try<T> right) {
            if (left is null && right is null)
                return true;
            if (left is null || right is null)
                return false;
            return left.Equals(right);
        }

        /// <summary>
        /// !=
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Try<T> left, Try<T> right) {
            return !(left == right);
        }

        /// <inheritdoc/>
        public abstract override string ToString();

        /// <inheritdoc/>
        public abstract override bool Equals(object obj);

        /// <inheritdoc/>
        public abstract override int GetHashCode();

        /// <summary>
        /// Deconstruct
        /// </summary>
        /// <param name="value"></param>
        /// <param name="exception"></param>
        public abstract void Deconstruct(out T value, out Exception exception);

        /// <summary>
        /// Exception as
        /// </summary>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        public TException ExceptionAs<TException>() where TException : Exception => Exception as TException;

        /// <summary>
        /// Recover
        /// </summary>
        /// <param name="recoverFunction"></param>
        /// <returns></returns>
        public abstract Try<T> Recover(Func<Exception, T> recoverFunction);

        /// <summary>
        /// Recover with
        /// </summary>
        /// <param name="recoverFunction"></param>
        /// <returns></returns>
        public abstract Try<T> RecoverWith(Func<Exception, Try<T>> recoverFunction);

        /// <summary>
        /// Match
        /// </summary>
        /// <param name="whenValue"></param>
        /// <param name="whenException"></param>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public abstract TResult Match<TResult>(Func<T, TResult> whenValue, Func<Exception, TResult> whenException);

        /// <summary>
        /// Map
        /// </summary>
        /// <param name="map"></param>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public Try<TResult> Map<TResult>(Func<T, TResult> map) {
            if (map is null)
                throw new ArgumentNullException(nameof(map));
            return Bind(value => Try.Create(() => map(value)));
        }

        /// <summary>
        /// Tap
        /// </summary>
        /// <param name="successFunction"></param>
        /// <param name="failureFunction"></param>
        /// <returns></returns>
        public abstract Try<T> Tap(Action<T> successFunction = null, Action<Exception> failureFunction = null);

        /// <summary>
        /// Bind
        /// </summary>
        /// <param name="bind"></param>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        internal abstract Try<TResult> Bind<TResult>(Func<T, Try<TResult>> bind);
    }
}