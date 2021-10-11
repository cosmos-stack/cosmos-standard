using System;

namespace CosmosStack.Optionals
{
    /// <summary>
    /// None <br />
    /// 无
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TException"></typeparam>
    public sealed class None<T, TException> : Optional<T, TException, None<T, TException>>,
                                              IEquatable<None<T, TException>>,
                                              IComparable<None<T, TException>>
    {
        internal None(TException exception) : base(default, exception, false) { }

        #region Equals

        /// <inheritdoc />
        public override bool Equals(T other)
        {
            if (other is null)
                return true;
            return Either.Equals(other);
        }

        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public override bool Equals(None<T, TException> other)
        {
            if (other is null)
                return false;
            return Either.Equals(other.Either);
        }

        #endregion

        #region CompareTo

        /// <inheritdoc />
        public override int CompareTo(T other)
        {
            if (other is null)
                return 0;
            return Either.CompareTo(other);
        }

        /// <summary>
        /// Compare to
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public override int CompareTo(None<T, TException> other)
        {
            if (other is null)
                return 1;
            return Either.CompareTo(other.Either);
        }

        #endregion

        #region Implicit operator

        /// <summary>
        /// implicit operator
        /// </summary>
        /// <param name="some"></param>
        /// <returns></returns>
        public static implicit operator Maybe<T>(None<T, TException> some)
        {
            return some.WithoutException();
        }

        /// <summary>
        /// implicit operator
        /// </summary>
        /// <param name="some"></param>
        /// <returns></returns>
        public static implicit operator None<T>(None<T, TException> some)
        {
            return some.WithoutException().ToWrappedNone();
        }

        #endregion

        #region Or / Else

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

        #endregion

        #region Filter

        /// <inheritdoc />
        public override None<T, TException> Filter(bool condition, TException exception) => this;

        /// <inheritdoc />
        public override None<T, TException> Filter(bool condition, Func<TException> exceptionFactory) => this;

        /// <inheritdoc />
        public override None<T, TException> Filter(Func<T, bool> predicate, TException exception) => this;

        /// <inheritdoc />
        public override None<T, TException> Filter(Func<T, bool> predicate, Func<TException> exceptionFactory) => this;

        #endregion

        #region Not null

        /// <inheritdoc />
        public override None<T, TException> NotNull(TException exception) => default;

        /// <inheritdoc />
        public override None<T, TException> NotNull(Func<TException> exceptionFactory) => default;

        #endregion
    }
}