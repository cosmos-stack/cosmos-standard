using System;
using System.Runtime.ExceptionServices;

namespace Cosmos {
    /// <summary>
    /// Failure
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Failure<T> : Try<T> {
        /// <summary>
        /// Initializes a new instance of the <see cref="Failure{T}"/> class.
        /// </summary>
        /// <param name="exception">The exception to wrapp.</param>
        internal Failure(Exception exception) {
            Exception = exception ?? throw new ArgumentNullException(nameof(exception));
        }

        /// <inheritdoc />
        public override bool IsFailure => true;

        /// <inheritdoc />
        public override bool IsSuccess => false;

        /// <inheritdoc />
        public override Exception Exception { get; }

        /// <inheritdoc />
        public override T Value => throw Rethrow();

        /// <inheritdoc />
        public override string ToString() => $"Failure<{Exception}>";

        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Failure<T> other) {
            return !(other is null) && ReferenceEquals(Exception, other.Exception);
        }

        /// <inheritdoc/>
        public override bool Equals(object obj) {
            return obj is Failure<T> failure && Equals(failure);
        }

        /// <inheritdoc/>
        public override int GetHashCode() => Exception.GetHashCode();

        /// <inheritdoc />
        public override void Deconstruct(out T value, out Exception exception) {
            value = default;
            exception = Exception;
        }

        /// <inheritdoc />
        public override Try<T> Recover(Func<Exception, T> recoverFunction) {
            return RecoverWith(ex => Try.LiftValue(recoverFunction(ex)));
        }

        /// <inheritdoc />
        public override Try<T> RecoverWith(Func<Exception, Try<T>> recoverFunction) {
            try {
                return recoverFunction(Exception);
            } catch (Exception ex) {
                return new Failure<T>(ex);
            }
        }

        /// <inheritdoc />
        public override TResult Match<TResult>(Func<T, TResult> whenValue, Func<Exception, TResult> whenException) {
            if (whenException is null)
                throw new ArgumentNullException(nameof(whenException));
            return whenException(Exception);
        }

        /// <inheritdoc />
        public override Try<T> Tap(Action<T> successFunction = null, Action<Exception> failureFunction = null) {
            failureFunction?.Invoke(Exception);
            return this;
        }

        internal override Try<TResult> Bind<TResult>(Func<T, Try<TResult>> bind) {
            return Try.LiftException<TResult>(Exception);
        }

        private Exception Rethrow() => ExceptionDispatchInfo.Capture(Exception).SourceException;
    }
}