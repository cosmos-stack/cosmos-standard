using System;

namespace Cosmos.Optionals {
    /// <summary>
    /// Some
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TException"></typeparam>
    public sealed class Some<T, TException> : Optional<T, TException, Some<T, TException>> {
        internal Some(T value) : base(value, default, true) { }

        internal Some(Either<T, TException> either) : base(either) { }

        /// <inheritdoc />
        public override bool Equals(Some<T, TException> other) {
            if (other is null)
                return false;
            return Either.Equals(other.Either);
        }

        /// <inheritdoc />
        public override int CompareTo(Some<T, TException> other) {
            if (other is null)
                return 1;
            return Either.CompareTo(other.Either);
        }

        /// <inheritdoc />
        public override Some<T, TException> Or(T alternative) {
            return Either.Or(alternative).ToWrappedSome();
        }

        /// <inheritdoc />
        public override Some<T, TException> Or(Func<T> alternativeFactory) {
            if (alternativeFactory is null)
                throw new ArgumentNullException(nameof(alternativeFactory));
            return Either.Or(alternativeFactory).ToWrappedSome();
        }

        /// <inheritdoc />
        public override Some<T, TException> Or(Func<TException, T> alternativeFactory) {
            if (alternativeFactory is null)
                throw new ArgumentNullException(nameof(alternativeFactory));
            return Either.Or(alternativeFactory).ToWrappedSome();
        }

        /// <inheritdoc />
        public override Some<T, TException> Else(Some<T, TException> alternativeOption) {
            if (alternativeOption is null)
                throw new ArgumentNullException(nameof(alternativeOption));
            return HasValue ? this : alternativeOption;
        }

        /// <inheritdoc />
        public override Some<T, TException> Else(Func<Some<T, TException>> alternativeOptionFactory) {
            if (alternativeOptionFactory is null)
                throw new ArgumentNullException(nameof(alternativeOptionFactory));
            return HasValue ? this : alternativeOptionFactory();
        }

        /// <inheritdoc />
        public override Some<T, TException> Else(Func<TException, Some<T, TException>> alternativeOptionFactory) {
            if (alternativeOptionFactory is null)
                throw new ArgumentNullException(nameof(alternativeOptionFactory));
            return HasValue ? this : alternativeOptionFactory(Exception);
        }

        /// <inheritdoc />
        public override Some<T, TException> Filter(bool condition, TException exception) {
            return HasValue && !condition ? Optional.Wrapped.NoneSlim<T, TException>(exception) : this;
        }

        /// <inheritdoc />
        public override Some<T, TException> Filter(bool condition, Func<TException> exceptionFactory) {
            if (exceptionFactory is null)
                throw new ArgumentNullException(nameof(exceptionFactory));
            return HasValue && !condition ? Optional.Wrapped.NoneSlim<T, TException>(exceptionFactory()) : this;
        }

        /// <inheritdoc />
        public override Some<T, TException> Filter(Func<T, bool> predicate, TException exception) {
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            return HasValue && !predicate(Value) ? Optional.Wrapped.NoneSlim<T, TException>(exception) : this;
        }

        /// <inheritdoc />
        public override Some<T, TException> Filter(Func<T, bool> predicate, Func<TException> exceptionFactory) {
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            if (exceptionFactory is null)
                throw new ArgumentNullException(nameof(exceptionFactory));
            return HasValue && !predicate(Value) ? Optional.Wrapped.NoneSlim<T, TException>(exceptionFactory()) : this;
        }

        /// <inheritdoc />
        public override Some<T, TException> NotNull(TException exception) {
            return HasValue && Value is null ? Optional.Wrapped.NoneSlim<T, TException>(exception) : this;
        }

        /// <inheritdoc />
        public override Some<T, TException> NotNull(Func<TException> exceptionFactory) {
            if (exceptionFactory is null)
                throw new ArgumentNullException(nameof(exceptionFactory));
            return HasValue && Value is null ? Optional.Wrapped.NoneSlim<T, TException>(exceptionFactory()) : this;
        }
    }
}