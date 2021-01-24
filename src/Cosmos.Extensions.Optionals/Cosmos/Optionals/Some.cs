using System;

namespace Cosmos.Optionals
{
    /// <summary>
    /// Some
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class Some<T> : Optional<T, Some<T>>, IEquatable<Some<T>>, IComparable<Some<T>>
    {
        internal Some(T value) : base(value, true) { }

        internal Some(Maybe<T> @internal) : base(@internal) { }

        #region Equals

        /// <inheritdoc />
        public override bool Equals(T other)
        {
            if (other is null)
                return false;
            return Internal.Equals(other);
        }

        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public override bool Equals(Some<T> other)
        {
            if (other is null)
                return false;
            return Internal.Equals(other.Internal);
        }

        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(None<T> other)
        {
            if (other is null)
                return false;
            return Internal.Equals(other.InternalPointer);
        }

        /// <inheritdoc />
        public override bool Equals(object other)
        {
            if (other is null)
                return false;
            if (other is Some<T> some)
                return Equals(some);
            if (other is None<T> none)
                return Equals(none);
            return Internal.Equals(other);
        }

        #endregion

        #region CompareTo

        /// <inheritdoc />
        public override int CompareTo(T other)
        {
            if (other is null)
                return 1;
            return Internal.CompareTo(other);
        }

        /// <summary>
        /// Compare to
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public override int CompareTo(Some<T> other)
        {
            if (other is null)
                return 1;
            return Internal.CompareTo(other.Internal);
        }

        #endregion

        #region GetHashCode

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return Internal.GetHashCode();
        }

        #endregion

        #region ==/!=

        /// <summary>
        /// ==
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Some<T> left, Some<T> right)
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
        public static bool operator ==(Some<T> left, None<T> right)
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
        public static bool operator ==(None<T> left, Some<T> right)
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
        public static bool operator !=(Some<T> left, Some<T> right)
        {
            return !(left == right);
        }

        /// <summary>
        /// !=
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Some<T> left, None<T> right)
        {
            return !(left == right);
        }

        /// <summary>
        /// !=
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(None<T> left, Some<T> right)
        {
            return !(left == right);
        }

        #endregion

        #region explicit operator

        /// <summary>
        /// Convert none to some
        /// </summary>
        /// <param name="none"></param>
        /// <returns></returns>
        public static explicit operator Some<T>(None<T> none)
        {
            return Optional.Wrapped.NoneSlim<T>();
        }

        /// <summary>
        /// Convert maybe to some
        /// </summary>
        /// <param name="maybe"></param>
        /// <returns></returns>
        public static explicit operator Some<T>(Maybe<T> maybe)
        {
            return maybe.ToWrappedSome();
        }

        #endregion

        #region Or / Else

        /// <inheritdoc />
        public override Some<T> Or(T alternative)
        {
            return Internal.Or(alternative).ToWrappedSome();
        }

        /// <inheritdoc />
        public override Some<T> Or(Func<T> alternativeFactory)
        {
            if (alternativeFactory is null)
                throw new ArgumentNullException(nameof(alternativeFactory));
            return Internal.Or(alternativeFactory).ToWrappedSome();
        }

        /// <inheritdoc />
        public override Some<T> Else(Some<T> alternativeMaybe)
        {
            if (alternativeMaybe is null)
                throw new ArgumentNullException(nameof(alternativeMaybe));
            return HasValue ? this : alternativeMaybe;
        }

        /// <inheritdoc />
        public override Some<T> Else(Func<Some<T>> alternativeMaybeFactory)
        {
            if (alternativeMaybeFactory is null)
                throw new ArgumentNullException(nameof(alternativeMaybeFactory));
            return HasValue ? this : alternativeMaybeFactory();
        }

        #endregion

        #region Filter

        /// <inheritdoc />
        public override Some<T> Filter(bool condition)
        {
            return HasValue && !condition ? Optional.Wrapped.NoneSlim<T>() : this;
        }

        /// <inheritdoc />
        public override Some<T> Filter(Func<T, bool> predicate)
        {
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            return HasValue && !predicate(Value) ? Optional.Wrapped.NoneSlim<T>() : this;
        }

        #endregion

        #region Not null

        /// <inheritdoc />
        public override Some<T> NotNull()
        {
            return HasValue && Value is null ? Optional.Wrapped.NoneSlim<T>() : this;
        }

        #endregion
    }
}