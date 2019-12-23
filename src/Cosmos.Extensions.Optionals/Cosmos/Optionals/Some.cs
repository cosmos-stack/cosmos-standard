using System;

namespace Cosmos.Optionals {
    /// <summary>
    /// Some
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class Some<T> : Optional<T, Some<T>> {
        internal Some(T value) : base(value, true) { }

        internal Some(Maybe<T> maybe) : base(maybe) { }

        /// <inheritdoc />
        public override bool Equals(Some<T> other) {
            if (other is null)
                return false;
            return Maybe.Equals(other.Maybe);
        }

        /// <inheritdoc />
        public override int CompareTo(Some<T> other) {
            if (other is null)
                return 1;
            return Maybe.CompareTo(other.Maybe);
        }

        /// <inheritdoc />
        public override Some<T> Or(T alternative) {
            return Maybe.Or(alternative).ToWrappedSome();
        }

        /// <inheritdoc />
        public override Some<T> Or(Func<T> alternativeFactory) {
            if (alternativeFactory is null)
                throw new ArgumentNullException(nameof(alternativeFactory));
            return Maybe.Or(alternativeFactory).ToWrappedSome();
        }

        /// <inheritdoc />
        public override Some<T> Else(Some<T> alternativeMaybe) {
            if (alternativeMaybe is null)
                throw new ArgumentNullException(nameof(alternativeMaybe));
            return HasValue ? this : alternativeMaybe;
        }

        /// <inheritdoc />
        public override Some<T> Else(Func<Some<T>> alternativeMaybeFactory) {
            if (alternativeMaybeFactory is null)
                throw new ArgumentNullException(nameof(alternativeMaybeFactory));
            return HasValue ? this : alternativeMaybeFactory();
        }

        /// <inheritdoc />
        public override Some<T> Filter(bool condition) {
            return HasValue && !condition ? Optional.Wrapped.NoneSlim<T>() : this;
        }

        /// <inheritdoc />
        public override Some<T> Filter(Func<T, bool> predicate) {
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            return HasValue && !predicate(Value) ? Optional.Wrapped.NoneSlim<T>() : this;
        }

        /// <inheritdoc />
        public override Some<T> NotNull() {
            return HasValue && Value == null ? Optional.Wrapped.NoneSlim<T>() : this;
        }
    }
}