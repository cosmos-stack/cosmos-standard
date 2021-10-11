using System;
using System.Collections.Generic;
using CosmosStack.Optionals.Internals;
using CosmosStack.Reflection;
using CosmosStack.UnionTypes;

namespace CosmosStack.Optionals
{
    /// <summary>
    /// Maybe <br />
    /// MayBe 组件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public readonly struct Maybe<T> : IOptionalImpl<T, Maybe<T>>,
        IEquatable<Maybe<T>>,
        IComparable<Maybe<T>>
    {
        private readonly string _key;
        private readonly bool _hasValue;
        private readonly T _value;
        private readonly Type _underlyingType;

        internal Maybe(T value, bool hasValue)
        {
            _hasValue = hasValue;
            _value = value;
            _key = NamedMaybeConstants.KEY;
            _underlyingType = Types.Of<T>();
        }

        internal Maybe(T value, string key, bool hasValue)
        {
            _hasValue = hasValue;
            _value = value;
            _key = string.IsNullOrWhiteSpace(key) ? NamedMaybeConstants.KEY : key;
            _underlyingType = Types.Of<T>();
        }

        #region K/V

        /// <inheritdoc />
        public bool HasValue => _hasValue;

        /// <inheritdoc />
        public T Value => _value;

        /// <inheritdoc />
        public string Key => _key;

        #endregion

        #region UnderlyingType

        /// <inheritdoc />
        public Type UnderlyingType => _underlyingType;

        #endregion

        #region Equals

        /// <inheritdoc />
        public bool Equals(Maybe<T> other)
        {
            if (!_hasValue && !other._hasValue)
            {
                return true;
            }

            if (_hasValue && other._hasValue)
            {
                return EqualityComparer<T>.Default.Equals(_value, other._value);
            }

            return false;
        }

        /// <inheritdoc />
        public bool Equals(T other)
        {
            if (other is null)
                return false;
            return _hasValue && EqualityComparer<T>.Default.Equals(_value, other);
        }

        /// <inheritdoc />
        public override bool Equals(object obj) => obj is Maybe<T> maybe && Equals(maybe);

        #endregion

        #region CompareTo

        /// <inheritdoc />
        public int CompareTo(T other)
        {
            return !_hasValue ? -1 : Comparer<T>.Default.Compare(_value, other);
        }

        /// <inheritdoc />
        public int CompareTo(Maybe<T> other)
        {
            if (_hasValue && !other._hasValue) return 1;
            if (!_hasValue && other._hasValue) return -1;
            return Comparer<T>.Default.Compare(_value, other._value);
        }

        #endregion

        #region ==/!=

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

        #endregion

        #region < <= > >=

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

        #endregion

        #region ToString

        /// <inheritdoc />
        public override string ToString()
        {
            return _hasValue
                ? _value is null
                    ? "Some(null)"
                    : $"Some({_value})"
                : "None";
        }

        #endregion

        #region GetHashCode

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return _hasValue
                ? _value is null
                    ? 1
                    : _value.GetHashCode()
                : 0;
        }

        #endregion

        #region Enumerable

        /// <summary>
        /// To enumerable
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> ToEnumerable()
        {
            if (_hasValue)
                yield return _value;
        }

        /// <summary>
        /// Get enumrtator
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            if (_hasValue)
                yield return _value;
        }

        #endregion

        #region Contains / Exists

        /// <summary>
        /// Contains <br />
        /// 包含
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(T value)
        {
            if (_hasValue)
                if (_value is null)
                    return value is null;
                else
                    return _value.Equals(value);
            return false;
        }

        /// <summary>
        /// Exists <br />
        /// 存在
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public bool Exists(Func<T, bool> predicate)
        {
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            return _hasValue && predicate(_value);
        }

        #endregion

        #region Value or

        /// <summary>
        /// Value or <br />
        /// 尝试获取值，或返回默认值
        /// </summary>
        /// <param name="alternative"></param>
        /// <returns></returns>
        public T ValueOr(T alternative)
        {
            return _hasValue ? _value : alternative;
        }

        /// <summary>
        /// Value or <br />
        /// 尝试获取值，或返回默认值
        /// </summary>
        /// <param name="alternativeFactory"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public T ValueOr(Func<T> alternativeFactory)
        {
            if (alternativeFactory is null)
                throw new ArgumentNullException(nameof(alternativeFactory));
            return _hasValue ? _value : alternativeFactory();
        }

        #endregion

        #region Or / Else

        /// <summary>
        /// Or <br />
        /// 如果当前 MayBe 组件为 False，则使用给定的替换值，并返回新的 MayBe 组件
        /// </summary>
        /// <param name="alternative"></param>
        /// <returns></returns>
        public Maybe<T> Or(T alternative)
        {
            return _hasValue ? this : Optional.Some(alternative);
        }

        /// <summary>
        /// Or <br />
        /// 如果当前 MayBe 组件为 False，则使用给定的替换值，并返回新的 MayBe 组件
        /// </summary>
        /// <param name="alternativeFactory"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Maybe<T> Or(Func<T> alternativeFactory)
        {
            if (alternativeFactory is null)
                throw new ArgumentNullException(nameof(alternativeFactory));
            return _hasValue ? this : Optional.Some(alternativeFactory());
        }

        /// <summary>
        /// Else <br />
        /// 如果当前 MayBe 组件为 False，则使用给定的替换的 MayBe 组件
        /// </summary>
        /// <param name="alternativeMaybe"></param>
        /// <returns></returns>
        public Maybe<T> Else(Maybe<T> alternativeMaybe)
        {
            return _hasValue ? this : alternativeMaybe;
        }

        /// <summary>
        /// Else <br />
        /// 如果当前 MayBe 组件为 False，则使用给定的替换的 MayBe 组件
        /// </summary>
        /// <param name="alternativeMaybeFactory"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Maybe<T> Else(Func<Maybe<T>> alternativeMaybeFactory)
        {
            if (alternativeMaybeFactory is null)
                throw new ArgumentNullException(nameof(alternativeMaybeFactory));
            return _hasValue ? this : alternativeMaybeFactory();
        }

        #endregion

        #region With Exception

        /// <summary>
        /// With exception <br />
        /// 置入一个异常
        /// </summary>
        /// <param name="exception"></param>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        public Either<T, TException> WithException<TException>(TException exception)
        {
            return Match(
                someFactory: Optional.Some<T, TException>,
                noneFactory: () => Optional.None<T, TException>(exception));
        }

        /// <summary>
        /// With exception <br />
        /// 置入一个异常
        /// </summary>
        /// <param name="exceptionFactory"></param>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Either<T, TException> WithException<TException>(Func<TException> exceptionFactory)
        {
            if (exceptionFactory is null)
                throw new ArgumentNullException(nameof(exceptionFactory));
            return Match(
                someFactory: Optional.Some<T, TException>,
                noneFactory: () => Optional.None<T, TException>(exceptionFactory()));
        }

        #endregion

        #region Match

        /// <summary>
        /// Match <br />
        /// 命中，若 MayBe 组件为 True 则调用 <see cref="someFactory"/>，不然则调用 <see cref="noneFactory"/>.
        /// </summary>
        /// <param name="someFactory"></param>
        /// <param name="noneFactory"></param>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public TResult Match<TResult>(Func<T, TResult> someFactory, Func<TResult> noneFactory)
        {
            if (someFactory is null)
                throw new ArgumentNullException(nameof(someFactory));
            if (noneFactory is null)
                throw new ArgumentNullException(nameof(noneFactory));
            return _hasValue ? someFactory(_value) : noneFactory();
        }

        /// <summary>
        /// Match <br />
        /// 命中，若 MayBe 组件为 True 则调用 <see cref="someAct"/>，不然则调用 <see cref="noneAct"/>.
        /// </summary>
        /// <param name="someAct"></param>
        /// <param name="noneAct"></param>
        public void Match(Action<T> someAct, Action noneAct)
        {
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
        /// Match maybe <br />
        /// 命中，若 MayBe 组件为 True 则调用
        /// </summary>
        /// <param name="maybeAct"></param>
        public void MatchMaybe(Action<T> maybeAct)
        {
            if (maybeAct is null)
                throw new ArgumentNullException(nameof(maybeAct));
            if (_hasValue)
                maybeAct(_value);
        }

        /// <summary>
        /// Match none <br />
        /// 命中，若 MayBe 组件为 False 则调用
        /// </summary>
        /// <param name="noneAct"></param>
        public void MatchNone(Action noneAct)
        {
            if (noneAct is null)
                throw new ArgumentNullException(nameof(noneAct));
            if (!_hasValue)
                noneAct();
        }

        #endregion

        #region Map

        /// <summary>
        /// Map <br />
        /// 映射
        /// </summary>
        /// <param name="mapping"></param>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Maybe<TResult> Map<TResult>(Func<T, TResult> mapping)
        {
            if (mapping is null)
                throw new ArgumentNullException(nameof(mapping));
            return Match(
                someFactory: val => Optional.Some(mapping(val)),
                noneFactory: Optional.None<TResult>);
        }

        /// <summary>
        /// Flat map <br />
        /// 映射
        /// </summary>
        /// <param name="mapping"></param>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Maybe<TResult> FlatMap<TResult>(Func<T, Maybe<TResult>> mapping)
        {
            if (mapping is null)
                throw new ArgumentNullException(nameof(mapping));
            return Match(
                someFactory: mapping,
                noneFactory: Optional.None<TResult>);
        }

        /// <summary>
        /// Flat map <br />
        /// 映射
        /// </summary>
        /// <param name="mapping"></param>
        /// <typeparam name="TResult"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Maybe<TResult> FlatMap<TResult, TException>(Func<T, Either<TResult, TException>> mapping)
        {
            if (mapping is null)
                throw new ArgumentNullException(nameof(mapping));
            return FlatMap(val => mapping(val).WithoutException());
        }

        #endregion

        #region Filter

        /// <summary>
        /// Filter <br />
        /// 过滤
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public Maybe<T> Filter(bool condition)
        {
            return _hasValue && !condition ? Nothing : this;
        }

        /// <summary>
        /// Filter <br />
        /// 过滤
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Maybe<T> Filter(Func<T, bool> predicate)
        {
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            return _hasValue && !predicate(_value) ? Nothing : this;
        }

        #endregion

        #region Not Null

        /// <summary>
        /// Not null <br />
        /// 不为空
        /// </summary>
        /// <returns></returns>
        public Maybe<T> NotNull()
        {
            return _hasValue && _value == null ? Nothing : this;
        }

        #endregion

        #region To Wrapped Optional

        /// <summary>
        /// To wrapped optional some <br />
        /// 封装为 MayBe 组件 Some
        /// </summary>
        /// <returns></returns>
        public Some<T> ToWrappedSome() => new(this);

        /// <summary>
        /// To wrapped optional none <br />
        /// 封装为 MayBe 组件 None
        /// </summary>
        /// <returns></returns>
        public None<T> ToWrappedNone() => new();

        #endregion

        #region ToUnionType

        /// <summary>
        /// To Union Type <br />
        /// 转换为联合类型
        /// </summary>
        /// <returns></returns>
        public UnionType<T> ToUnionType()
        {
            if (HasValue)
                return UnionType.Of(ValueOr(default(T)));
            return UnionType<T>.FromNull();
        }

        #endregion

        #region Join

        /// <summary>
        /// Join <br />
        /// 联合
        /// </summary>
        /// <param name="valueToJoin"></param>
        /// <typeparam name="T2"></typeparam>
        /// <returns></returns>
        public Maybe<T, T2> Join<T2>(T2 valueToJoin)
            => new(this, Optional.From(valueToJoin));

        /// <summary>
        /// Join <br />
        /// 联合
        /// </summary>
        /// <param name="valueToJoin"></param>
        /// <param name="condition"></param>
        /// <typeparam name="T2"></typeparam>
        /// <returns></returns>
        public Maybe<T, T2> Join<T2>(T2 valueToJoin, Func<T2, bool> condition)
            => new(this, Optional.From(valueToJoin, condition));

        /// <summary>
        /// Join <br />
        /// 联合
        /// </summary>
        /// <param name="optionalToJoin"></param>
        /// <typeparam name="T2"></typeparam>
        /// <returns></returns>
        public Maybe<T, T2> Join<T2>(Maybe<T2> optionalToJoin)
            => new(this, optionalToJoin);

        #endregion

        #region implicit operator

        /// <summary>
        /// Convert T to Maybe{T}
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static implicit operator Maybe<T>(T value)
        {
            return Optional.From(value);
        }

        /// <summary>
        /// Convert T from Maybe{T}
        /// </summary>
        /// <param name="maybe"></param>
        /// <returns></returns>
        public static implicit operator T(Maybe<T> maybe)
        {
            return maybe.ValueOrDefault();
        }

        #endregion

        #region Nothing

        /// <summary>
        /// Nothing <br />
        /// 获取一个 MayBe 组件 Nothing 实例
        /// </summary>
        public static Maybe<T> Nothing => Optional.None<T>();

        #endregion
    }
}