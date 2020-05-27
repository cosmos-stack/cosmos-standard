using System;

namespace Cosmos.Optionals
{
    /// <summary>
    /// Some
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TException"></typeparam>
    public sealed class Some<T, TException> : Optional<T, TException, Some<T, TException>>,
                                              IEquatable<Some<T, TException>>,
                                              IComparable<Some<T, TException>>
    {
        internal Some(T value) : base(value, default, true) { }

        internal Some(Either<T, TException> either) : base(either) { }

        #region Equals

        /// <inheritdoc />
        public override bool Equals(T other)
        {
            if (other is null)
                return false;
            return Either.Equals(other);
        }

        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public override bool Equals(Some<T, TException> other)
        {
            if (other is null)
                return false;
            return Either.Equals(other.Either);
        }

        /// <inheritdoc />
        public override bool Equals(object other)
        {
            if (other is null)
                return false;
            if (other is Some<T, TException> some)
                return Equals(some);
            return InternalPointer.Equals(other);
        }

        #endregion

        #region CompareTo

        /// <inheritdoc />
        public override int CompareTo(T other)
        {
            if (other is null)
                return 1;
            return Either.CompareTo(other);
        }

        /// <summary>
        /// Compare to
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public override int CompareTo(Some<T, TException> other)
        {
            if (other is null)
                return 1;
            return Either.CompareTo(other.Either);
        }

        #endregion

        #region GetHashCode

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return InternalPointer.GetHashCode();
        }

        #endregion

        #region ==/!=

        /// <summary>
        /// ==
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Some<T, TException> left, Some<T, TException> right)
        {
            if (left is null && right is null)
                return true;
            if (left is null || right is null)
                return false;
            return left.InternalPointer.Equals(right.InternalPointer);
        }

        /// <summary>
        /// ==
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Some<T, TException> left, None<T, TException> right)
        {
            if (left is null && right is null)
                return true;
            if (left is null || right is null)
                return false;
            return left.InternalPointer.Equals(right.InternalPointer);
        }

        /// <summary>
        /// ==
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(None<T, TException> left, Some<T, TException> right)
        {
            if (left is null && right is null)
                return true;
            if (left is null || right is null)
                return false;
            return left.InternalPointer.Equals(right.InternalPointer);
        }

        /// <summary>
        /// !=
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Some<T, TException> left, Some<T, TException> right)
        {
            return !(left == right);
        }

        /// <summary>
        /// !=
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Some<T, TException> left, None<T, TException> right)
        {
            return !(left == right);
        }

        /// <summary>
        /// !=
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(None<T, TException> left, Some<T, TException> right)
        {
            return !(left == right);
        }

        #endregion

        #region Implicit operator

        /// <summary>
        /// implicit operator
        /// </summary>
        /// <param name="some"></param>
        /// <returns></returns>
        public static implicit operator Maybe<T>(Some<T, TException> some)
        {
            return some.WithoutException();
        }

        /// <summary>
        /// implicit operator
        /// </summary>
        /// <param name="some"></param>
        /// <returns></returns>
        public static implicit operator Some<T>(Some<T, TException> some)
        {
            return some.WithoutException().ToWrappedSome();
        }

        #endregion

        #region Or / Else

        /// <inheritdoc />
        public override Some<T, TException> Or(T alternative)
        {
            return Either.Or(alternative).ToWrappedSome();
        }

        /// <inheritdoc />
        public override Some<T, TException> Or(Func<T> alternativeFactory)
        {
            if (alternativeFactory is null)
                throw new ArgumentNullException(nameof(alternativeFactory));
            return Either.Or(alternativeFactory).ToWrappedSome();
        }

        /// <inheritdoc />
        public override Some<T, TException> Or(Func<TException, T> alternativeFactory)
        {
            if (alternativeFactory is null)
                throw new ArgumentNullException(nameof(alternativeFactory));
            return Either.Or(alternativeFactory).ToWrappedSome();
        }

        /// <inheritdoc />
        public override Some<T, TException> Else(Some<T, TException> alternativeOption)
        {
            if (alternativeOption is null)
                throw new ArgumentNullException(nameof(alternativeOption));
            return HasValue ? this : alternativeOption;
        }

        /// <inheritdoc />
        public override Some<T, TException> Else(Func<Some<T, TException>> alternativeOptionFactory)
        {
            if (alternativeOptionFactory is null)
                throw new ArgumentNullException(nameof(alternativeOptionFactory));
            return HasValue ? this : alternativeOptionFactory();
        }

        /// <inheritdoc />
        public override Some<T, TException> Else(Func<TException, Some<T, TException>> alternativeOptionFactory)
        {
            if (alternativeOptionFactory is null)
                throw new ArgumentNullException(nameof(alternativeOptionFactory));
            return HasValue ? this : alternativeOptionFactory(Exception);
        }

        #endregion

        #region Filter

        /// <inheritdoc />
        public override Some<T, TException> Filter(bool condition, TException exception)
        {
            return HasValue && !condition ? Optional.Wrapped.NoneSlim<T, TException>(exception) : this;
        }

        /// <inheritdoc />
        public override Some<T, TException> Filter(bool condition, Func<TException> exceptionFactory)
        {
            if (exceptionFactory is null)
                throw new ArgumentNullException(nameof(exceptionFactory));
            return HasValue && !condition ? Optional.Wrapped.NoneSlim<T, TException>(exceptionFactory()) : this;
        }

        /// <inheritdoc />
        public override Some<T, TException> Filter(Func<T, bool> predicate, TException exception)
        {
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            return HasValue && !predicate(Value) ? Optional.Wrapped.NoneSlim<T, TException>(exception) : this;
        }

        /// <inheritdoc />
        public override Some<T, TException> Filter(Func<T, bool> predicate, Func<TException> exceptionFactory)
        {
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            if (exceptionFactory is null)
                throw new ArgumentNullException(nameof(exceptionFactory));
            return HasValue && !predicate(Value) ? Optional.Wrapped.NoneSlim<T, TException>(exceptionFactory()) : this;
        }

        #endregion

        #region Not null

        /// <inheritdoc />
        public override Some<T, TException> NotNull(TException exception)
        {
            return HasValue && Value is null ? Optional.Wrapped.NoneSlim<T, TException>(exception) : this;
        }

        /// <inheritdoc />
        public override Some<T, TException> NotNull(Func<TException> exceptionFactory)
        {
            if (exceptionFactory is null)
                throw new ArgumentNullException(nameof(exceptionFactory));
            return HasValue && Value is null ? Optional.Wrapped.NoneSlim<T, TException>(exceptionFactory()) : this;
        }

        #endregion
    }
}