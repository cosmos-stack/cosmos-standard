using System;

namespace Cosmos.Optionals
{
    /// <summary>
    /// Base optional for Some and None.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TImpl"></typeparam>
    public abstract class Optional<T, TImpl> : IOptionalImpl<T, TImpl>
    {
        /// <summary>
        /// Internal Maybe instance
        /// </summary>
        protected readonly Maybe<T> Internal;

        internal Maybe<T> InternalPointer => Internal;

        /// <summary>
        /// Create a new instance of <see cref="Optional{T, TImpl}"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="hasValue"></param>
        protected Optional(T value, bool hasValue)
        {
            Internal = new Maybe<T>(value, hasValue);
        }

        /// <summary>
        /// Create a new instance of <see cref="Optional{T, TImpl}"/>.
        /// </summary>
        /// <param name="internal"></param>
        protected Optional(Maybe<T> @internal)
        {
            Internal = @internal;
        }

        /// <inheritdoc />
        public virtual bool HasValue => Internal.HasValue;

        /// <inheritdoc />
        public virtual T Value => Internal.Value;

        /// <inheritdoc />
        public string Key => Internal.Key;

        /// <inheritdoc />
        public virtual Type UnderlyingType => Internal.UnderlyingType;

        /// <inheritdoc />
        public bool Contains(T value) => Internal.Contains(value);

        /// <inheritdoc />
        public bool Exists(Func<T, bool> predicate) => Internal.Exists(predicate);

        /// <inheritdoc />
        public T ValueOr(T alternative) => Internal.ValueOr(alternative);

        /// <inheritdoc />
        public T ValueOr(Func<T> alternativeFactory) => Internal.ValueOr(alternativeFactory);

        /// <inheritdoc />
        public abstract bool Equals(T other);

        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public abstract bool Equals(TImpl other);

        /// <inheritdoc />
        public abstract int CompareTo(T other);

        /// <summary>
        /// Compare to
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
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
        public Either<T, TException> WithException<TException>(TException exception) => Internal.WithException(exception);

        /// <inheritdoc />
        public Either<T, TException> WithException<TException>(Func<TException> exceptionFactory) => Internal.WithException(exceptionFactory);

        /// <inheritdoc />
        public TResult Match<TResult>(Func<T, TResult> someFactory, Func<TResult> noneFactory) => Internal.Match(someFactory, noneFactory);

        /// <inheritdoc />
        public void Match(Action<T> someAct, Action noneAct) => Internal.Match(someAct, noneAct);

        /// <inheritdoc />
        public void MatchMaybe(Action<T> maybeAct) => Internal.MatchMaybe(maybeAct);

        /// <inheritdoc />
        public void MatchNone(Action noneAct) => Internal.MatchNone(noneAct);

        /// <inheritdoc />
        public Maybe<TResult> Map<TResult>(Func<T, TResult> mapping) => Internal.Map(mapping);

        /// <inheritdoc />
        public Maybe<TResult> FlatMap<TResult>(Func<T, Maybe<TResult>> mapping) => Internal.FlatMap(mapping);

        /// <inheritdoc />
        public Maybe<TResult> FlatMap<TResult, TException>(Func<T, Either<TResult, TException>> mapping) => Internal.FlatMap(mapping);

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