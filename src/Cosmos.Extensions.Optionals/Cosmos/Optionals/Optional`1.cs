using System;

namespace Cosmos.Optionals {
    /// <summary>
    /// Base optional for Some and None.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TImpl"></typeparam>
    public abstract class Optional<T, TImpl> : IOptionalImpl<T, TImpl> {

        /// <summary>
        /// Internal Maybe instance
        /// </summary>
        protected readonly Maybe<T> Maybe;

        /// <summary>
        /// Create a new instance of <see cref="Optional{T, TImpl}"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="hasValue"></param>
        protected Optional(T value, bool hasValue) {
            Maybe = new Maybe<T>(value, hasValue);
        }

        /// <summary>
        /// Create a new instance of <see cref="Optional{T, TImpl}"/>.
        /// </summary>
        /// <param name="maybe"></param>
        protected Optional(Maybe<T> maybe) {
            Maybe = maybe;
        }

        /// <inheritdoc />
        public virtual bool HasValue => Maybe.HasValue;

        /// <inheritdoc />
        public virtual T Value => Maybe.Value;

        /// <inheritdoc />
        public bool Contains(T value) => Maybe.Contains(value);

        /// <inheritdoc />
        public bool Exists(Func<T, bool> predicate) => Maybe.Exists(predicate);

        /// <inheritdoc />
        public T ValueOr(T alternative) => Maybe.ValueOr(alternative);

        /// <inheritdoc />
        public T ValueOr(Func<T> alternativeFactory) => Maybe.ValueOr(alternativeFactory);

        /// <inheritdoc />
        public abstract bool Equals(TImpl other);

        /// <inheritdoc />
        public abstract int CompareTo(TImpl other);

        /// <inheritdoc />
        public abstract TImpl Or(T alternative);

        /// <inheritdoc />
        public abstract TImpl Or(Func<T> alternativeFactory);

        /// <inheritdoc />
        public abstract TImpl Else(TImpl alternativeMaybe);

        /// <inheritdoc />
        public abstract TImpl Else(Func<TImpl> alternativeMaybeFactory);

        /// <inheritdoc />
        public Either<T, TException> WithException<TException>(TException exception) => Maybe.WithException(exception);

        /// <inheritdoc />
        public Either<T, TException> WithException<TException>(Func<TException> exceptionFactory) => Maybe.WithException(exceptionFactory);

        /// <inheritdoc />
        public TResult Match<TResult>(Func<T, TResult> someFactory, Func<TResult> noneFactory) => Maybe.Match(someFactory, noneFactory);

        /// <inheritdoc />
        public void Match(Action<T> someAct, Action noneAct) => Maybe.Match(someAct, noneAct);

        /// <inheritdoc />
        public void MatchMaybe(Action<T> maybeAct) => Maybe.MatchMaybe(maybeAct);

        /// <inheritdoc />
        public void MatchNone(Action noneAct) => Maybe.MatchNone(noneAct);

        /// <inheritdoc />
        public Maybe<TResult> Map<TResult>(Func<T, TResult> mapping) => Maybe.Map(mapping);

        /// <inheritdoc />
        public Maybe<TResult> FlatMap<TResult>(Func<T, Maybe<TResult>> mapping) => Maybe.FlatMap(mapping);

        /// <inheritdoc />
        public Maybe<TResult> FlatMap<TResult, TException>(Func<T, Either<TResult, TException>> mapping) => Maybe.FlatMap(mapping);

        /// <inheritdoc />
        public abstract TImpl Filter(bool condition);

        /// <inheritdoc />
        public abstract TImpl Filter(Func<T, bool> predicate);

        /// <inheritdoc />
        public abstract TImpl NotNull();

        /// <summary>
        /// Nothing.
        /// </summary>
        public static None<T> Nothing => Optional.Wrapped.None<T>();
    }
}