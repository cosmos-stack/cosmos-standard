using System;

namespace Cosmos.Optionals {
    /// <summary>
    /// None
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TException"></typeparam>
    public sealed class None<T, TException> : Optional<T, TException, None<T, TException>> {
        internal None(TException exception) : base(default, exception, false) { }

        /// <inheritdoc />
        public override bool Equals(None<T, TException> other) {
            if (other is null)
                return false;
            return Either.Equals(other.Either);
        }

        /// <inheritdoc />
        public override int CompareTo(None<T, TException> other) {
            if (other is null)
                return 1;
            return Either.CompareTo(other.Either);
        }

        /// <inheritdoc />
        public override None<T, TException> Or(T alternative) => default;

        /// <inheritdoc />
        public override None<T, TException> Or(Func<T> alternativeFactory) => this;

        /// <inheritdoc />
        public override None<T, TException> Or(Func<TException, T> alternativeFactory) => this;

        /// <inheritdoc />
        public override None<T, TException> Else(None<T, TException> alternativeOption) => alternativeOption;

        /// <inheritdoc />
        public override None<T, TException> Else(Func<None<T, TException>> alternativeOptionFactory) => this;

        /// <inheritdoc />
        public override None<T, TException> Else(Func<TException, None<T, TException>> alternativeOptionFactory) => this;

        /// <inheritdoc />
        public override None<T, TException> Filter(bool condition, TException exception) => this;

        /// <inheritdoc />
        public override None<T, TException> Filter(bool condition, Func<TException> exceptionFactory) => this;

        /// <inheritdoc />
        public override None<T, TException> Filter(Func<T, bool> predicate, TException exception) => this;

        /// <inheritdoc />
        public override None<T, TException> Filter(Func<T, bool> predicate, Func<TException> exceptionFactory) => this;

        /// <inheritdoc />
        public override None<T, TException> NotNull(TException exception) => default;

        /// <inheritdoc />
        public override None<T, TException> NotNull(Func<TException> exceptionFactory) => default;
    }
}