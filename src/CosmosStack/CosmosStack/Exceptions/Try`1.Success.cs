using System;
using System.Collections.Generic;

namespace CosmosStack.Exceptions
{
    /// <summary>
    /// Success <br />
    /// 成功的 Try 组件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Success<T> : Try<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Success{T}"/> class.
        /// </summary>
        /// <param name="value"></param>
        internal Success(T value)
        {
            Value = value;
        }

        /// <inheritdoc />
        public override bool IsFailure => false;

        /// <inheritdoc />
        public override bool IsSuccess => true;

        /// <inheritdoc />
        public override TryCreatingValueException Exception => default;

        /// <inheritdoc />
        public override T Value { get; }

        /// <inheritdoc />
        public override string ToString() => $"Success<{Value}>";

        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Success<T> other) => !(other is null) && EqualityComparer<T>.Default.Equals(Value, other.Value);

        /// <inheritdoc />
        public override bool Equals(object obj) => obj is Success<T> success && Equals(success);

        /// <inheritdoc />
        public override int GetHashCode() => EqualityComparer<T>.Default.GetHashCode(Value);

        /// <inheritdoc />
        public override void Deconstruct(out T value, out Exception exception)
        {
            value = Value;
            exception = default;
        }

        public override void Deconstruct(out T value, out bool tryResult, out Exception exception)
        {
            value = Value;
            tryResult = IsSuccess;
            exception = default;
        }

        /// <inheritdoc />
        public override Try<T> Recover(Func<TryCreatingValueException, T> recoverFunction) => this;

        /// <inheritdoc />
        public override Try<T> Recover(Func<Exception, string, T> recoverFunction) => this;

        /// <inheritdoc />
        public override Try<T> RecoverWith(Func<TryCreatingValueException, Try<T>> recoverFunction) => this;

        /// <inheritdoc />
        public override Try<T> RecoverWith(Func<Exception, string, Try<T>> recoverFunction) => this;

        /// <inheritdoc />
        public override TResult Match<TResult>(Func<T, TResult> whenValue, Func<TryCreatingValueException, TResult> whenException)
        {
            if (whenValue is null)
                throw new ArgumentNullException(nameof(whenValue));
            return whenValue(Value);
        }

        /// <inheritdoc />
        public override TResult Match<TResult>(Func<T, TResult> whenValue, Func<Exception, string, TResult> whenException)
        {
            if (whenValue is null)
                throw new ArgumentNullException(nameof(whenValue));
            return whenValue(Value);
        }

        /// <inheritdoc />
        public override Try<T> Tap(Action<T> successFunction = null, Action<TryCreatingValueException> failureFunction = null)
        {
            successFunction?.Invoke(Value);
            return this;
        }

        /// <inheritdoc />
        public override Try<T> Tap(Action<T> successFunction = null, Action<Exception, string> failureFunction = null)
        {
            successFunction?.Invoke(Value);
            return this;
        }

        internal override Try<TResult> Bind<TResult>(Func<T, Try<TResult>> bind)
        {
            if (bind is null)
                throw new ArgumentNullException(nameof(bind));
            return bind(Value);
        }
    }
}