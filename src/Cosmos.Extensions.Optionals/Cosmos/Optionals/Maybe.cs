using System;
using System.Collections.Generic;

namespace Cosmos.Optionals {
    /// <summary>
    /// Maybe
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public readonly struct Maybe<T> : IOptionalImpl<T, Maybe<T>> {
        private readonly bool _hasValue;
        private readonly T _value;

        internal Maybe(T value, bool hasValue) {
            _hasValue = hasValue;
            _value = value;
        }

        /// <inheritdoc />
        public bool HasValue => _hasValue;

        /// <inheritdoc />
        public T Value => _value;

        /// <inheritdoc />
        public bool Equals(Maybe<T> other) {
            if (!_hasValue && !other._hasValue) {
                return true;
            }

            if (_hasValue && other._hasValue) {
                return EqualityComparer<T>.Default.Equals(_value, other._value);
            }

            return false;
        }

        /// <inheritdoc />
        public override bool Equals(object obj) => obj is Maybe<T> maybe && Equals(maybe);

        /// <summary>
        /// ==
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Maybe<T> left, Maybe<T> right) => left.Equals(right);

        /// <summary>
        /// !=
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Maybe<T> left, Maybe<T> right) => !left.Equals(right);

        /// <inheritdoc />
        public override int GetHashCode() {
            return _hasValue
                ? _value == null
                    ? 1
                    : _value.GetHashCode()
                : 0;
        }

        /// <inheritdoc />
        public int CompareTo(Maybe<T> other) {
            if (_hasValue && !other._hasValue) return 1;
            if (!_hasValue && other._hasValue) return -1;
            return Comparer<T>.Default.Compare(_value, other._value);
        }

        /// <summary>
        /// Determines if an optional is less than another optional.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <(Maybe<T> left, Maybe<T> right) => left.CompareTo(right) < 0;

        /// <summary>
        /// Determines if an optional is less than or equal to another optional.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <=(Maybe<T> left, Maybe<T> right) => left.CompareTo(right) <= 0;

        /// <summary>
        /// Determines if an optional is greater than another optional.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >(Maybe<T> left, Maybe<T> right) => left.CompareTo(right) > 0;

        /// <summary>
        /// Determines if an optional is greater than or equal to another optional.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >=(Maybe<T> left, Maybe<T> right) => left.CompareTo(right) >= 0;

        /// <inheritdoc />
        public override string ToString() {
            return _hasValue
                ? _value == null
                    ? "Some(null)"
                    : $"Some({_value})"
                : "None";
        }

        /// <summary>
        /// To enumerable
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> ToEnumerable() {
            if (_hasValue)
                yield return _value;
        }

        /// <summary>
        /// Get enumrtator
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator() {
            if (_hasValue)
                yield return _value;
        }

        /// <summary>
        /// Contains
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(T value) {
            if (_hasValue)
                if (_value == null)
                    return value == null;
                else
                    return _value.Equals(value);
            return false;
        }

        /// <summary>
        /// Exists
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public bool Exists(Func<T, bool> predicate) {
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            return _hasValue && predicate(_value);
        }

        /// <summary>
        /// Value or
        /// </summary>
        /// <param name="alternative"></param>
        /// <returns></returns>
        public T ValueOr(T alternative) {
            return _hasValue ? _value : alternative;
        }

        /// <summary>
        /// Value or
        /// </summary>
        /// <param name="alternativeFactory"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public T ValueOr(Func<T> alternativeFactory) {
            if (alternativeFactory is null)
                throw new ArgumentNullException(nameof(alternativeFactory));
            return _hasValue ? _value : alternativeFactory();
        }

        /// <summary>
        /// Or
        /// </summary>
        /// <param name="alternative"></param>
        /// <returns></returns>
        public Maybe<T> Or(T alternative) {
            return _hasValue ? this : Optional.Some(alternative);
        }

        /// <summary>
        /// Or
        /// </summary>
        /// <param name="alternativeFactory"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Maybe<T> Or(Func<T> alternativeFactory) {
            if (alternativeFactory is null)
                throw new ArgumentNullException(nameof(alternativeFactory));
            return _hasValue ? this : Optional.Some(alternativeFactory());
        }

        /// <summary>
        /// Else
        /// </summary>
        /// <param name="alternativeMaybe"></param>
        /// <returns></returns>
        public Maybe<T> Else(Maybe<T> alternativeMaybe) {
            return _hasValue ? this : alternativeMaybe;
        }

        /// <summary>
        /// Else
        /// </summary>
        /// <param name="alternativeMaybeFactory"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Maybe<T> Else(Func<Maybe<T>> alternativeMaybeFactory) {
            if (alternativeMaybeFactory is null)
                throw new ArgumentNullException(nameof(alternativeMaybeFactory));
            return _hasValue ? this : alternativeMaybeFactory();
        }

        /// <summary>
        /// With exception
        /// </summary>
        /// <param name="exception"></param>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        public Either<T, TException> WithException<TException>(TException exception) {
            return Match(
                someFactory: Optional.Some<T, TException>,
                noneFactory: () => Optional.None<T, TException>(exception));
        }

        /// <summary>
        /// With exception
        /// </summary>
        /// <param name="exceptionFactory"></param>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Either<T, TException> WithException<TException>(Func<TException> exceptionFactory) {
            if (exceptionFactory is null)
                throw new ArgumentNullException(nameof(exceptionFactory));
            return Match(
                someFactory: Optional.Some<T, TException>,
                noneFactory: () => Optional.None<T, TException>(exceptionFactory()));
        }

        /// <summary>
        /// Match
        /// </summary>
        /// <param name="someFactory"></param>
        /// <param name="noneFactory"></param>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public TResult Match<TResult>(Func<T, TResult> someFactory, Func<TResult> noneFactory) {
            if (someFactory is null)
                throw new ArgumentNullException(nameof(someFactory));
            if (noneFactory is null)
                throw new ArgumentNullException(nameof(noneFactory));
            return _hasValue ? someFactory(_value) : noneFactory();
        }

        /// <summary>
        /// Match
        /// </summary>
        /// <param name="someAct"></param>
        /// <param name="noneAct"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Match(Action<T> someAct, Action noneAct) {
            if (someAct is null)
                throw new ArgumentNullException(nameof(someAct));
            if (noneAct is null)
                throw new ArgumentNullException(nameof(noneAct));
            if (_hasValue)
                someAct(_value);
            else
                noneAct();
        }

        /// <summary>
        /// Match maybe
        /// </summary>
        /// <param name="maybeAct"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void MatchMaybe(Action<T> maybeAct) {
            if (maybeAct is null)
                throw new ArgumentNullException(nameof(maybeAct));
            if (_hasValue)
                maybeAct(_value);
        }

        /// <summary>
        /// Match none
        /// </summary>
        /// <param name="noneAct"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void MatchNone(Action noneAct) {
            if (noneAct is null)
                throw new ArgumentNullException(nameof(noneAct));
            if (!_hasValue)
                noneAct();
        }

        /// <summary>
        /// Map
        /// </summary>
        /// <param name="mapping"></param>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Maybe<TResult> Map<TResult>(Func<T, TResult> mapping) {
            if (mapping is null)
                throw new ArgumentNullException(nameof(mapping));
            return Match(
                someFactory: val => Optional.Some(mapping(val)),
                noneFactory: Optional.None<TResult>);
        }

        /// <summary>
        /// Flat map
        /// </summary>
        /// <param name="mapping"></param>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Maybe<TResult> FlatMap<TResult>(Func<T, Maybe<TResult>> mapping) {
            if (mapping is null)
                throw new ArgumentNullException(nameof(mapping));
            return Match(
                someFactory: mapping,
                noneFactory: Optional.None<TResult>);
        }

        /// <summary>
        /// Flat map
        /// </summary>
        /// <param name="mapping"></param>
        /// <typeparam name="TResult"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Maybe<TResult> FlatMap<TResult, TException>(Func<T, Either<TResult, TException>> mapping) {
            if (mapping is null)
                throw new ArgumentNullException(nameof(mapping));
            return FlatMap(val => mapping(val).WithoutException());
        }

        /// <summary>
        /// Filter
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public Maybe<T> Filter(bool condition) {
            return _hasValue && !condition ? Nothing : this;
        }

        /// <summary>
        /// Filter
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Maybe<T> Filter(Func<T, bool> predicate) {
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            return _hasValue && !predicate(_value) ? Nothing : this;
        }

        /// <summary>
        /// Not null
        /// </summary>
        /// <returns></returns>
        public Maybe<T> NotNull() {
            return _hasValue && _value == null ? Nothing : this;
        }

        /// <summary>
        /// To wrapped optional some
        /// </summary>
        /// <returns></returns>
        public Some<T> ToWrappedSome() => new Some<T>(this);

        /// <summary>
        /// To wrapped optional none
        /// </summary>
        /// <returns></returns>
        public None<T> ToWrappedNone() => new None<T>();

        /// <summary>
        /// Nothing
        /// </summary>
        public static Maybe<T> Nothing => Optional.None<T>();
    }
}