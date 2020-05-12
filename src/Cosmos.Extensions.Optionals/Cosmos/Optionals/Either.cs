using System;
using System.Collections.Generic;
using Cosmos.Reflection;

namespace Cosmos.Optionals {
    /// <summary>
    /// Either
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TException"></typeparam>
    [Serializable]
    public readonly struct Either<T, TException> : IOptionalImpl<T, TException, Either<T, TException>>,
                                                   IEquatable<Either<T, TException>>,
                                                   IComparable<Either<T, TException>> {
        private readonly bool _hasValue;
        private readonly T _value;
        private readonly TException _exception;
        private readonly Type _underlyingType;
        private readonly Type _underlyingExceptionType;

        internal Either(T value, TException exception, bool hasValue) {
            _hasValue = hasValue;
            _value = value;
            _exception = exception;
            _underlyingType = Types.Of<T>();
            _underlyingExceptionType = Types.Of<TException>();
        }

        /// <inheritdoc />
        public bool HasValue => _hasValue;

        /// <inheritdoc />
        public T Value => _value;

        /// <inheritdoc />
        public TException Exception => _exception;

        /// <inheritdoc />
        public string Key => "EitherKey";

        /// <inheritdoc />
        public Type UnderlyingType => _underlyingType;

        /// <inheritdoc />
        public Type UnderlyingExceptionType => _underlyingExceptionType;

        #region Equals

        /// <inheritdoc />
        public bool Equals(Either<T, TException> other) {
            if (!_hasValue && !other._hasValue) {
                return true;
            }

            if (_hasValue && other._hasValue) {
                return EqualityComparer<T>.Default.Equals(_value, other._value);
            }

            return false;
        }

        /// <inheritdoc />
        public bool Equals(T other) {
            if (other is null)
                return false;
            return _hasValue && EqualityComparer<T>.Default.Equals(_value, other);
        }

        /// <inheritdoc />
        public override bool Equals(object obj) => obj is Maybe<T> maybe && Equals(maybe);

        #endregion

        #region CompareTo

        /// <inheritdoc />
        public int CompareTo(T other) {
            return !_hasValue ? -1 : Comparer<T>.Default.Compare(_value, other);
        }

        /// <inheritdoc />
        public int CompareTo(Either<T, TException> other) {
            if (_hasValue && !other._hasValue) return 1;
            if (!_hasValue && other._hasValue) return -1;

            return _hasValue
                ? Comparer<T>.Default.Compare(_value, other._value)
                : Comparer<TException>.Default.Compare(_exception, other._exception);
        }

        #endregion

        #region ==/!=

        /// <summary>
        /// ==
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Either<T, TException> left, Either<T, TException> right) => left.Equals(right);

        /// <summary>
        /// !=
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Either<T, TException> left, Either<T, TException> right) => !left.Equals(right);

        #endregion

        #region < <= > >=

        /// <summary>
        /// Determines if an optional is less than another optional.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <(Either<T, TException> left, Either<T, TException> right) => left.CompareTo(right) < 0;

        /// <summary>
        /// Determines if an optional is less than or equal to another optional.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <=(Either<T, TException> left, Either<T, TException> right) => left.CompareTo(right) <= 0;

        /// <summary>
        /// Determines if an optional is greater than another optional.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >(Either<T, TException> left, Either<T, TException> right) => left.CompareTo(right) > 0;

        /// <summary>
        /// Determines if an optional is greater than or equal to another optional.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >=(Either<T, TException> left, Either<T, TException> right) => left.CompareTo(right) >= 0;

        #endregion

        #region ToString

        /// <inheritdoc />
        public override string ToString() {
            return _hasValue
                ? _value == null
                    ? "Some(null)"
                    : $"Some({_value})"
                : _exception == null
                    ? "None(null)"
                    : $"None({_exception})";
        }

        #endregion

        #region GetHashCode

        /// <inheritdoc />
        public override int GetHashCode() {
            return _hasValue
                ? _value == null ? 1 : _value.GetHashCode()
                : _exception == null
                    ? 0
                    : _exception.GetHashCode();
        }

        #endregion

        #region Enumerable

        /// <summary>
        /// To enumerable
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> ToEnumerable() {
            if (_hasValue)
                yield return _value;
        }

        /// <summary>
        /// Get enumerator
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator() {
            if (_hasValue)
                yield return _value;
        }

        #endregion

        #region Contains and Exists

        /// <summary>
        /// Contains
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(T value) {
            if (_hasValue) {
                if (_value == null)
                    return value == null;
                return _value.Equals(value);
            }

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

        #endregion

        #region Value or

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
        /// Value or
        /// </summary>
        /// <param name="alternativeFactory"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public T ValueOr(Func<TException, T> alternativeFactory) {
            if (alternativeFactory is null)
                throw new ArgumentNullException(nameof(alternativeFactory));
            return _hasValue ? _value : alternativeFactory(_exception);
        }

        #endregion

        #region Or / Else

        /// <summary>
        /// Or
        /// </summary>
        /// <param name="alternative"></param>
        /// <returns></returns>
        public Either<T, TException> Or(T alternative) {
            return _hasValue ? this : Optional.Some<T, TException>(alternative);
        }

        /// <summary>
        /// Or
        /// </summary>
        /// <param name="alternativeFactory"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Either<T, TException> Or(Func<T> alternativeFactory) {
            if (alternativeFactory is null)
                throw new ArgumentNullException(nameof(alternativeFactory));
            return _hasValue ? this : Optional.Some<T, TException>(alternativeFactory());
        }

        /// <summary>
        /// Or
        /// </summary>
        /// <param name="alternativeFactory"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Either<T, TException> Or(Func<TException, T> alternativeFactory) {
            if (alternativeFactory is null)
                throw new ArgumentNullException(nameof(alternativeFactory));
            return _hasValue ? this : Optional.Some<T, TException>(alternativeFactory(_exception));
        }

        /// <summary>
        /// Else
        /// </summary>
        /// <param name="alternativeOption"></param>
        /// <returns></returns>
        public Either<T, TException> Else(Either<T, TException> alternativeOption) {
            return _hasValue ? this : alternativeOption;
        }

        /// <summary>
        /// Else
        /// </summary>
        /// <param name="alternativeOptionFactory"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Either<T, TException> Else(Func<Either<T, TException>> alternativeOptionFactory) {
            if (alternativeOptionFactory is null)
                throw new ArgumentNullException(nameof(alternativeOptionFactory));
            return _hasValue ? this : alternativeOptionFactory();
        }

        /// <summary>
        /// Else
        /// </summary>
        /// <param name="alternativeOptionFactory"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Either<T, TException> Else(Func<TException, Either<T, TException>> alternativeOptionFactory) {
            if (alternativeOptionFactory is null)
                throw new ArgumentNullException(nameof(alternativeOptionFactory));
            return _hasValue ? this : alternativeOptionFactory(_exception);
        }

        #endregion

        #region Without exception

        /// <summary>
        /// Without exception
        /// </summary>
        /// <returns></returns>
        public Maybe<T> WithoutException() {
            return Match(
                someFactory: Optional.Some,
                noneFactory: _ => Optional.None<T>()
            );
        }

        #endregion

        #region Match

        /// <summary>
        /// Match
        /// </summary>
        /// <param name="someFactory"></param>
        /// <param name="noneFactory"></param>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public TResult Match<TResult>(Func<T, TResult> someFactory, Func<TException, TResult> noneFactory) {
            if (someFactory is null)
                throw new ArgumentNullException(nameof(someFactory));
            if (noneFactory is null)
                throw new ArgumentNullException(nameof(noneFactory));
            return _hasValue ? someFactory(_value) : noneFactory(_exception);
        }

        /// <summary>
        /// Match
        /// </summary>
        /// <param name="someAct"></param>
        /// <param name="noneAct"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Match(Action<T> someAct, Action<TException> noneAct) {
            if (someAct is null)
                throw new ArgumentNullException(nameof(someAct));
            if (noneAct is null)
                throw new ArgumentNullException(nameof(noneAct));
            if (_hasValue)
                someAct(_value);
            else
                noneAct(_exception);
        }

        /// <summary>
        /// Match some
        /// </summary>
        /// <param name="someAct"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void MatchSome(Action<T> someAct) {
            if (someAct is null)
                throw new ArgumentNullException(nameof(someAct));
            if (_hasValue)
                someAct(_value);
        }

        /// <summary>
        /// Match none
        /// </summary>
        /// <param name="noneAct"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void MatchNone(Action<TException> noneAct) {
            if (noneAct is null)
                throw new ArgumentNullException(nameof(noneAct));
            if (!_hasValue)
                noneAct(_exception);
        }

        #endregion

        #region Map

        /// <summary>
        /// Map
        /// </summary>
        /// <param name="mapping"></param>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Either<TResult, TException> Map<TResult>(Func<T, TResult> mapping) {
            if (mapping is null)
                throw new ArgumentNullException(nameof(mapping));
            return Match(
                someFactory: value => Optional.Some<TResult, TException>(mapping(value)),
                noneFactory: Optional.None<TResult, TException>
            );
        }

        /// <summary>
        /// Map exception
        /// </summary>
        /// <param name="mapping"></param>
        /// <typeparam name="TExceptionResult"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Either<T, TExceptionResult> MapException<TExceptionResult>(Func<TException, TExceptionResult> mapping) {
            if (mapping is null)
                throw new ArgumentNullException(nameof(mapping));
            return Match(
                someFactory: Optional.Some<T, TExceptionResult>,
                noneFactory: exception => Optional.None<T, TExceptionResult>(mapping(exception))
            );
        }

        /// <summary>
        /// Flat map
        /// </summary>
        /// <param name="mapping"></param>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Either<TResult, TException> FlatMap<TResult>(Func<T, Either<TResult, TException>> mapping) {
            if (mapping is null)
                throw new ArgumentNullException(nameof(mapping));
            return Match(
                someFactory: mapping,
                noneFactory: Optional.None<TResult, TException>
            );
        }

        /// <summary>
        /// Flat map
        /// </summary>
        /// <param name="mapping"></param>
        /// <param name="exception"></param>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Either<TResult, TException> FlatMap<TResult>(Func<T, Maybe<TResult>> mapping, TException exception) {
            if (mapping is null)
                throw new ArgumentNullException(nameof(mapping));
            return FlatMap(value => mapping(value).WithException(exception));
        }

        /// <summary>
        /// Flat map
        /// </summary>
        /// <param name="mapping"></param>
        /// <param name="exceptionFactory"></param>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Either<TResult, TException> FlatMap<TResult>(Func<T, Maybe<TResult>> mapping, Func<TException> exceptionFactory) {
            if (mapping is null)
                throw new ArgumentNullException(nameof(mapping));
            if (exceptionFactory is null)
                throw new ArgumentNullException(nameof(exceptionFactory));
            return FlatMap(value => mapping(value).WithException(exceptionFactory));
        }

        #endregion

        #region Filter

        /// <summary>
        /// Filter
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public Either<T, TException> Filter(bool condition, TException exception) {
            return _hasValue && !condition ? Optional.None<T, TException>(exception) : this;
        }

        /// <summary>
        /// Filter
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="exceptionFactory"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Either<T, TException> Filter(bool condition, Func<TException> exceptionFactory) {
            if (exceptionFactory is null)
                throw new ArgumentNullException(nameof(exceptionFactory));
            return _hasValue && !condition ? Optional.None<T, TException>(exceptionFactory()) : this;
        }

        /// <summary>
        /// Filter
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Either<T, TException> Filter(Func<T, bool> predicate, TException exception) {
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            return _hasValue && !predicate(_value) ? Optional.None<T, TException>(exception) : this;
        }

        /// <summary>
        /// Filter
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="exceptionFactory"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Either<T, TException> Filter(Func<T, bool> predicate, Func<TException> exceptionFactory) {
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            if (exceptionFactory is null)
                throw new ArgumentNullException(nameof(exceptionFactory));
            return _hasValue && !predicate(_value) ? Optional.None<T, TException>(exceptionFactory()) : this;
        }

        #endregion

        #region Not null

        /// <summary>
        /// Not null
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public Either<T, TException> NotNull(TException exception) {
            return _hasValue && _value is null ? Optional.None<T, TException>(exception) : this;
        }

        /// <summary>
        /// Not null
        /// </summary>
        /// <param name="exceptionFactory"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Either<T, TException> NotNull(Func<TException> exceptionFactory) {
            if (exceptionFactory is null)
                throw new ArgumentNullException(nameof(exceptionFactory));
            return _hasValue && _value is null ? Optional.None<T, TException>(exceptionFactory()) : this;
        }

        #endregion

        #region To wrapped object

        /// <summary>
        /// To wrapped optional some
        /// </summary>
        /// <returns></returns>
        public Some<T, TException> ToWrappedSome() => new Some<T, TException>(this);

        /// <summary>
        /// To wrapped optional none
        /// </summary>
        /// <returns></returns>
        public None<T, TException> ToWrappedNone() => new None<T, TException>(_exception);

        #endregion

    }
}