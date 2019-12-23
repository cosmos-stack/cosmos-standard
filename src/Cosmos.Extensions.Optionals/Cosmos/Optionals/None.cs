using System;

namespace Cosmos.Optionals {
    /// <summary>
    /// None
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class None<T> : Optional<T, None<T>> {
        internal None() : base(default, false) { }

        /// <inheritdoc />
        public override bool Equals(None<T> other) {
            if (other is null)
                return false;
            return Maybe.Equals(other.Maybe);
        }

        /// <inheritdoc />
        public override int CompareTo(None<T> other) {
            if (other is null)
                return 1;
            return Maybe.CompareTo(other.Maybe);
        }

        /// <inheritdoc />
        public override None<T> Or(T alternative) => default;

        /// <inheritdoc />
        public override None<T> Or(Func<T> alternativeFactory) => this;

        /// <inheritdoc />
        public override None<T> Else(None<T> alternativeMaybe) => alternativeMaybe;

        /// <inheritdoc />
        public override None<T> Else(Func<None<T>> alternativeMaybeFactory) => this;

        /// <inheritdoc />
        public override None<T> Filter(bool condition) => this;

        /// <inheritdoc />
        public override None<T> Filter(Func<T, bool> predicate) => this;

        /// <inheritdoc />
        public override None<T> NotNull() => default;
    }
}