using System;
using System.Collections.Generic;
using Cosmos.Optionals.Internals;
using Cosmos.UnionTypes;

namespace Cosmos.Optionals
{
    /// <summary>
    /// Maybe
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    [Serializable]
    public readonly struct Maybe<T1, T2, T3, T4> : IOptionalImpl<(T1, T2, T3, T4), Maybe<T1, T2, T3, T4>>,
        IEquatable<Maybe<T1, T2, T3, T4>>,
        IComparable<Maybe<T1, T2, T3, T4>>
    {
        private readonly Maybe<T1> _o1;
        private readonly Maybe<T2> _o2;
        private readonly Maybe<T3> _o3;
        private readonly Maybe<T4> _o4;
        private readonly bool _hasValue;
        private readonly IReadOnlyDictionary<string, int> _optionalIndexCache;

        internal Maybe(T1 value1, T2 value2, T3 value3, T4 value4, bool hasValue)
        {
            _o1 = Optional.From(value1);
            _o2 = Optional.From(value2);
            _o3 = Optional.From(value3);
            _o4 = Optional.From(value4);
            _hasValue = hasValue;
            _optionalIndexCache = NamedMaybeHelper.CreateIndexCache(4);
        }

        internal Maybe(T1 value1, string key1, T2 value2, string key2, T3 value3, string key3, T4 value4, string key4, bool hasValue)
        {
            _o1 = Optional.From(value1);
            _o2 = Optional.From(value2);
            _o3 = Optional.From(value3);
            _o4 = Optional.From(value4);
            _hasValue = hasValue;
            _optionalIndexCache = NamedMaybeHelper.CreateIndexCache(4, key1, key2, key3, key4);
        }

        internal Maybe(Maybe<T1> maybe1, Maybe<T2> maybe2, Maybe<T3> maybe3, Maybe<T4> maybe4)
        {
            _o1 = maybe1;
            _o2 = maybe2;
            _o3 = maybe3;
            _o4 = maybe4;
            _hasValue = _o1.HasValue && _o2.HasValue && _o3.HasValue && _o4.HasValue;
            _optionalIndexCache = NamedMaybeHelper.CreateIndexCache(4, maybe1.Key, maybe2.Key, maybe3.Key, maybe4.Key);
        }

        /// <summary>
        /// Gets value of he first item
        /// </summary>
        public T1 Item1 => _o1.Value;

        /// <summary>
        /// Gets value of he second item
        /// </summary>
        public T2 Item2 => _o2.Value;

        /// <summary>
        /// Gets value of he third item
        /// </summary>
        public T3 Item3 => _o3.Value;

        /// <summary>
        /// Gets value of he forth item
        /// </summary>
        public T4 Item4 => _o4.Value;

        /// <inheritdoc />
        public (T1, T2, T3, T4) Value => (Item1, Item2, Item3, Item4);

        /// <inheritdoc />
        public bool HasValue => _hasValue && _o1.HasValue && _o2.HasValue && _o3.HasValue && _o4.HasValue;

        /// <inheritdoc />
        public string Key => _o4.Key;

        /// <summary>
        /// Gets UnderlyingType of the first item
        /// </summary>
        public Type UnderlyingType1 => _o1.UnderlyingType;

        /// <summary>
        /// Gets UnderlyingType of the second item
        /// </summary>
        public Type UnderlyingType2 => _o2.UnderlyingType;

        /// <summary>
        /// Gets UnderlyingType of the third item
        /// </summary>
        public Type UnderlyingType3 => _o3.UnderlyingType;

        /// <summary>
        /// Gets UnderlyingType of the forth item
        /// </summary>
        public Type UnderlyingType4 => _o4.UnderlyingType;

        /// <inheritdoc />
        public Type UnderlyingType => _o4.UnderlyingType;

        /// <summary>
        /// Gets all underlying type for this <see cref="Maybe{T1,T2,T3,T4}"/>.
        /// </summary>
        public (Type, Type, Type, Type) UnderlyingTypes => (UnderlyingType1, UnderlyingType2, UnderlyingType3, UnderlyingType4);

        #region Index

        /// <summary>
        /// Index
        /// </summary>
        /// <param name="index"></param>
        public object this[int index]
        {
            get
            {
                return index switch
                {
                    0 => _o1.Value,
                    1 => _o2.Value,
                    2 => _o3.Value,
                    3 => _o4.Value,
                    _ => throw new IndexOutOfRangeException($"Index value '{index}' must between [0, 4).")
                };
            }
        }

        /// <summary>
        /// Index
        /// </summary>
        /// <param name="key"></param>
        public object this[string key]
            => _optionalIndexCache.TryGetValue(key, out var index)
                ? this[index]
                : default;

        #endregion

        #region Deconstruct

        /// <summary>
        /// Deconstruct
        /// </summary>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        /// <param name="item3"></param>
        /// <param name="item4"></param>
        public void Deconstruct(out T1 item1, out T2 item2, out T3 item3, out T4 item4)
        {
            item1 = _o1.Value;
            item2 = _o2.Value;
            item3 = _o3.Value;
            item4 = _o4.Value;
        }

        /// <summary>
        /// Deconstruct
        /// </summary>
        /// <param name="maybe1"></param>
        /// <param name="maybe2"></param>
        /// <param name="maybe3"></param>
        /// <param name="maybe4"></param>
        public void Deconstruct(out Maybe<T1> maybe1, out Maybe<T2> maybe2, out Maybe<T3> maybe3, out Maybe<T4> maybe4)
        {
            maybe1 = _o1;
            maybe2 = _o2;
            maybe3 = _o3;
            maybe4 = _o4;
        }

        #endregion

        #region Equals

        /// <inheritdoc />
        public bool Equals((T1, T2, T3, T4) other)
        {
            return Item1.Equals(other.Item1) &&
                   Item2.Equals(other.Item2) &&
                   Item3.Equals(other.Item3) &&
                   Item4.Equals(other.Item4);
        }

        /// <inheritdoc />
        public bool Equals(Maybe<T1, T2, T3, T4> other)
        {
            if (!HasValue && !other.HasValue)
                return true;
            if (HasValue && other.HasValue)
                return EqualityComparer<T1>.Default.Equals(Item1, other.Item1) &&
                       EqualityComparer<T2>.Default.Equals(Item2, other.Item2) &&
                       EqualityComparer<T3>.Default.Equals(Item3, other.Item3) &&
                       EqualityComparer<T4>.Default.Equals(Item4, other.Item4);
            return false;
        }

        /// <inheritdoc />
        public override bool Equals(object obj) => obj is Maybe<T1, T2, T3, T4> maybe && Equals(maybe);

        #endregion

        #region Compare to

        /// <inheritdoc />
        public int CompareTo((T1, T2, T3, T4) other)
        {
            if (!HasValue) return -1;
            var v = new[]
            {
                CompareHelper.Compare(Item1, other.Item1, 4),
                CompareHelper.Compare(Item2, other.Item2, 3),
                CompareHelper.Compare(Item3, other.Item3, 2),
                CompareHelper.Compare(Item4, other.Item4, 1)
            };
            return CompareHelper.Calc(v);
        }

        /// <inheritdoc />
        public int CompareTo(Maybe<T1, T2, T3, T4> other)
        {
            if (HasValue && !other.HasValue) return 1;
            if (!HasValue && other.HasValue) return -1;
            var v = new[]
            {
                CompareHelper.Compare(Item1, other.Item1, 4),
                CompareHelper.Compare(Item2, other.Item2, 3),
                CompareHelper.Compare(Item3, other.Item3, 2),
                CompareHelper.Compare(Item4, other.Item4, 1)
            };
            return CompareHelper.Calc(v);
        }

        #endregion

        #region ==/!=

        /// <summary>
        /// ==
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Maybe<T1, T2, T3, T4> left, Maybe<T1, T2, T3, T4> right) => left.Equals(right);

        /// <summary>
        /// !=
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Maybe<T1, T2, T3, T4> left, Maybe<T1, T2, T3, T4> right) => !left.Equals(right);

        #endregion

        #region < <= > >=

        /// <summary>
        /// Determines if an optional is less than another optional.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <(Maybe<T1, T2, T3, T4> left, Maybe<T1, T2, T3, T4> right) => left.CompareTo(right) < 0;

        /// <summary>
        /// Determines if an optional is less than or equal to another optional.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <=(Maybe<T1, T2, T3, T4> left, Maybe<T1, T2, T3, T4> right) => left.CompareTo(right) <= 0;

        /// <summary>
        /// Determines if an optional is greater than another optional.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >(Maybe<T1, T2, T3, T4> left, Maybe<T1, T2, T3, T4> right) => left.CompareTo(right) > 0;

        /// <summary>
        /// Determines if an optional is greater than or equal to another optional.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >=(Maybe<T1, T2, T3, T4> left, Maybe<T1, T2, T3, T4> right) => left.CompareTo(right) >= 0;

        #endregion

        #region Operator

        /// <summary>
        /// Convert maybe to tuple
        /// </summary>
        /// <param name="maybe"></param>
        /// <returns></returns>
        public static implicit operator (T1, T2, T3, T4)(Maybe<T1, T2, T3, T4> maybe)
        {
            return maybe.Value;
        }

        /// <summary>
        /// Convert maybe from tuple
        /// </summary>
        /// <param name="tuple"></param>
        /// <returns></returns>
        public static explicit operator Maybe<T1, T2, T3, T4>((T1, T2, T3, T4) tuple)
        {
            return Optional.From(tuple);
        }

        #endregion

        #region ToString

        /// <inheritdoc />
        public override string ToString()
        {
            return HasValue
                ? $"Some(Item1:{Item1},Item2:{Item2},Item3:{Item3},Item4:{Item4})"
                : "None";
        }

        #endregion

        #region GetHashCode

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return HasValue
                ? Value.GetHashCode()
                : 0;
        }

        #endregion

        #region Contains / Exists

        /// <inheritdoc />
        public bool Contains((T1, T2, T3, T4) value)
        {
            return _o1.Contains(value.Item1) &&
                   _o2.Contains(value.Item2) &&
                   _o3.Contains(value.Item3) &&
                   _o4.Contains(value.Item4);
        }

        /// <inheritdoc />
        public bool Exists(Func<(T1, T2, T3, T4), bool> predicate)
        {
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            return HasValue && predicate(Value);
        }

        #endregion

        #region Value or

        /// <inheritdoc />
        public (T1, T2, T3, T4) ValueOr((T1, T2, T3, T4) alternative)
        {
            return HasValue ? Value : alternative;
        }

        /// <inheritdoc />
        public (T1, T2, T3, T4) ValueOr(Func<(T1, T2, T3, T4)> alternativeFactory)
        {
            if (alternativeFactory is null)
                throw new ArgumentNullException(nameof(alternativeFactory));
            return HasValue ? Value : alternativeFactory();
        }

        #endregion

        #region Or / Else

        /// <inheritdoc />
        public Maybe<T1, T2, T3, T4> Or((T1, T2, T3, T4) alternative)
        {
            return HasValue ? this : Optional.From(alternative);
        }

        /// <inheritdoc />
        public Maybe<T1, T2, T3, T4> Or(Func<(T1, T2, T3, T4)> alternativeFactory)
        {
            if (alternativeFactory is null)
                throw new ArgumentNullException(nameof(alternativeFactory));
            return HasValue ? this : Optional.From(alternativeFactory());
        }

        /// <inheritdoc />
        public Maybe<T1, T2, T3, T4> Else(Maybe<T1, T2, T3, T4> alternativeMaybe)
        {
            return HasValue ? this : alternativeMaybe;
        }

        /// <inheritdoc />
        public Maybe<T1, T2, T3, T4> Else(Func<Maybe<T1, T2, T3, T4>> alternativeMaybeFactory)
        {
            if (alternativeMaybeFactory is null)
                throw new ArgumentNullException(nameof(alternativeMaybeFactory));
            return HasValue ? this : alternativeMaybeFactory();
        }

        #endregion

        #region With exception

        /// <inheritdoc />
        public Either<(T1, T2, T3, T4), TException> WithException<TException>(TException exception)
        {
            return Match(
                someFactory: Optional.Some<(T1, T2, T3, T4), TException>,
                noneFactory: () => Optional.None<(T1, T2, T3, T4), TException>(exception));
        }

        /// <inheritdoc />
        public Either<(T1, T2, T3, T4), TException> WithException<TException>(Func<TException> exceptionFactory)
        {
            if (exceptionFactory is null)
                throw new ArgumentNullException(nameof(exceptionFactory));
            return Match(
                someFactory: Optional.Some<(T1, T2, T3, T4), TException>,
                noneFactory: () => Optional.None<(T1, T2, T3, T4), TException>(exceptionFactory()));
        }

        #endregion

        #region Match

        /// <inheritdoc />
        public TResult Match<TResult>(Func<(T1, T2, T3, T4), TResult> someFactory, Func<TResult> noneFactory)
        {
            if (someFactory is null)
                throw new ArgumentNullException(nameof(someFactory));
            if (noneFactory is null)
                throw new ArgumentNullException(nameof(noneFactory));
            return HasValue ? someFactory(Value) : noneFactory();
        }

        /// <inheritdoc />
        public void Match(Action<(T1, T2, T3, T4)> someAct, Action noneAct)
        {
            if (someAct is null)
                throw new ArgumentNullException(nameof(someAct));
            if (noneAct is null)
                throw new ArgumentNullException(nameof(noneAct));
            if (HasValue)
                someAct(Value);
            else
                noneAct();
        }

        /// <inheritdoc />
        public void MatchMaybe(Action<(T1, T2, T3, T4)> maybeAct)
        {
            if (maybeAct is null)
                throw new ArgumentNullException(nameof(maybeAct));
            if (HasValue)
                maybeAct(Value);
        }

        /// <inheritdoc />
        public void MatchNone(Action noneAct)
        {
            if (noneAct is null)
                throw new ArgumentNullException(nameof(noneAct));
            if (!HasValue)
                noneAct();
        }

        #endregion

        #region Map

        /// <inheritdoc />
        public Maybe<TResult> Map<TResult>(Func<(T1, T2, T3, T4), TResult> mapping)
        {
            if (mapping is null)
                throw new ArgumentNullException(nameof(mapping));
            return Match(
                someFactory: val => Optional.Some(mapping(val)),
                noneFactory: Optional.None<TResult>);
        }

        /// <inheritdoc />
        public Maybe<TResult> FlatMap<TResult>(Func<(T1, T2, T3, T4), Maybe<TResult>> mapping)
        {
            if (mapping is null)
                throw new ArgumentNullException(nameof(mapping));
            return Match(
                someFactory: mapping,
                noneFactory: Optional.None<TResult>);
        }

        /// <inheritdoc />
        public Maybe<TResult> FlatMap<TResult, TException>(Func<(T1, T2, T3, T4), Either<TResult, TException>> mapping)
        {
            if (mapping is null)
                throw new ArgumentNullException(nameof(mapping));
            return FlatMap(val => mapping(val).WithoutException());
        }

        #endregion

        #region Filter

        /// <inheritdoc />
        public Maybe<T1, T2, T3, T4> Filter(bool condition)
        {
            return HasValue && !condition ? Nothing : this;
        }

        /// <inheritdoc />
        public Maybe<T1, T2, T3, T4> Filter(Func<(T1, T2, T3, T4), bool> predicate)
        {
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            return HasValue && !predicate(Value) ? Nothing : this;
        }

        #endregion

        #region Not null

        /// <inheritdoc />
        public Maybe<T1, T2, T3, T4> NotNull()
        {
            return HasValue &&
                   _o1.Value is null &&
                   _o2.Value is null &&
                   _o3.Value is null &&
                   _o4.Value is null
                ? Nothing
                : this;
        }

        #endregion

        #region To wrapped object

        /// <summary>
        /// To wrapped optional some
        /// </summary>
        /// <returns></returns>
        public Some<(T1, T2, T3, T4)> ToWrappedSome() => new(Value);

        /// <summary>
        /// To wrapped optional none
        /// </summary>
        /// <returns></returns>
        public None<(T1, T2, T3, T4)> ToWrappedNone() => new();

        #endregion

        #region ToUnionType

        public UnionType<T1, T2, T3, T4> ToUnionType()
        {
            if (_o1.HasValue)
                return UnionType.Of<T1, T2, T3, T4>(_o1.ValueOr(default(T1)));
            if (_o2.HasValue)
                return UnionType.Of<T1, T2, T3, T4>(_o2.ValueOr(default(T2)));
            if (_o3.HasValue)
                return UnionType.Of<T1, T2, T3, T4>(_o3.ValueOr(default(T3)));
            if (_o4.HasValue)
                return UnionType.Of<T1, T2, T3, T4>(_o4.ValueOr(default(T4)));
            return UnionType<T1, T2, T3, T4>.FromNull();
        }

        #endregion

        #region Join

        /// <summary>
        /// Join
        /// </summary>
        /// <param name="valueToJoin"></param>
        /// <typeparam name="T5"></typeparam>
        /// <returns></returns>
        public Maybe<T1, T2, T3, T4, T5> Join<T5>(T5 valueToJoin)
            => new(_o1, _o2, _o3, _o4, Optional.From(valueToJoin));

        /// <summary>
        /// Join
        /// </summary>
        /// <param name="valueToJoin"></param>
        /// <param name="condition"></param>
        /// <typeparam name="T5"></typeparam>
        /// <returns></returns>
        public Maybe<T1, T2, T3, T4, T5> Join<T5>(T5 valueToJoin, Func<T5, bool> condition)
            => new(_o1, _o2, _o3, _o4, Optional.From(valueToJoin, condition));

        /// <summary>
        /// Join
        /// </summary>
        /// <param name="optionalToJoin"></param>
        /// <typeparam name="T5"></typeparam>
        /// <returns></returns>
        public Maybe<T1, T2, T3, T4, T5> Join<T5>(Maybe<T5> optionalToJoin)
            => new(_o1, _o2, _o3, _o4, optionalToJoin);

        #endregion

        /// <summary>
        /// Nothing
        /// </summary>
        public static Maybe<T1, T2, T3, T4> Nothing => Optional.None<T1, T2, T3, T4>();
    }
}