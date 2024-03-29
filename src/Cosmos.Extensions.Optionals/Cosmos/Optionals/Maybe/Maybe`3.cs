using Cosmos.Optionals.Internals;

namespace Cosmos.Optionals;

/// <summary>
/// Maybe <br />
/// MayBe 组件
/// </summary>
/// <typeparam name="T1"></typeparam>
/// <typeparam name="T2"></typeparam>
/// <typeparam name="T3"></typeparam>
[Serializable]
public readonly struct Maybe<T1, T2, T3> : IOptionalImpl<(T1, T2, T3), Maybe<T1, T2, T3>>,
    IEquatable<Maybe<T1, T2, T3>>,
    IComparable<Maybe<T1, T2, T3>>
{
    internal readonly Maybe<T1> _o1;
    internal readonly Maybe<T2> _o2;
    internal readonly Maybe<T3> _o3;
    private readonly bool _hasValue;
    private readonly IReadOnlyDictionary<string, int> _optionalIndexCache;

    internal Maybe(T1 value1, T2 value2, T3 value3, bool hasValue)
    {
        _o1 = Optional.From(value1);
        _o2 = Optional.From(value2);
        _o3 = Optional.From(value3);
        _hasValue = hasValue;
        _optionalIndexCache = NamedMaybeHelper.CreateIndexCache(3);
    }

    internal Maybe(T1 value1, string key1, T2 value2, string key2, T3 value3, string key3, bool hasValue)
    {
        _o1 = Optional.From(value1);
        _o2 = Optional.From(value2);
        _o3 = Optional.From(value3);
        _hasValue = hasValue;
        _optionalIndexCache = NamedMaybeHelper.CreateIndexCache(3, key1, key2, key3);
    }

    internal Maybe(Maybe<T1> maybe1, Maybe<T2> maybe2, Maybe<T3> maybe3)
    {
        _o1 = maybe1;
        _o2 = maybe2;
        _o3 = maybe3;
        _hasValue = _o1.HasValue && _o2.HasValue && _o3.HasValue;
        _optionalIndexCache = NamedMaybeHelper.CreateIndexCache(3, maybe1.Key, maybe2.Key, maybe3.Key);
    }

    #region Items

    /// <summary>
    /// Gets value of he first item <br />
    /// 获取第一个成员
    /// </summary>
    public T1 Item1 => _o1.Value;

    /// <summary>
    /// Gets value of he second item <br />
    /// 获取第二个成员
    /// </summary>
    public T2 Item2 => _o2.Value;

    /// <summary>
    /// Gets value of he third item <br />
    /// 获取第三个成员
    /// </summary>
    public T3 Item3 => _o3.Value;

    #endregion

    #region K/V

    /// <inheritdoc />
    public (T1, T2, T3) Value => (Item1, Item2, Item3);

    /// <inheritdoc />
    public bool HasValue => _hasValue && _o1.HasValue && _o2.HasValue && _o3.HasValue;

    /// <inheritdoc />
    public bool HasNoValue => !HasValue;

    /// <inheritdoc />
    public string Key => _o3.Key;

    #endregion

    #region UnderlyingType

    /// <summary>
    /// Gets UnderlyingType of the first item <br />
    /// 获取第一个成员的底层类型
    /// </summary>
    public Type UnderlyingType1 => _o1.UnderlyingType;

    /// <summary>
    /// Gets UnderlyingType of the second item <br />
    /// 获取第二个成员的底层类型
    /// </summary>
    public Type UnderlyingType2 => _o2.UnderlyingType;

    /// <summary>
    /// Gets UnderlyingType of the third item <br />
    /// 获取第三个成员的底层类型
    /// </summary>
    public Type UnderlyingType3 => _o3.UnderlyingType;

    /// <inheritdoc />
    public Type UnderlyingType => _o3.UnderlyingType;

    /// <summary>
    /// Gets all underlying type for this <see cref="Maybe{T1,T2,T3}"/>.
    /// </summary>
    public (Type, Type, Type) UnderlyingTypes => (UnderlyingType1, UnderlyingType2, UnderlyingType3);

    #endregion

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
                _ => throw new IndexOutOfRangeException($"Index value '{index}' must between [0, 3).")
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
    public void Deconstruct(out T1 item1, out T2 item2, out T3 item3)
    {
        item1 = _o1.Value;
        item2 = _o2.Value;
        item3 = _o3.Value;
    }

    /// <summary>
    /// Deconstruct
    /// </summary>
    /// <param name="maybe1"></param>
    /// <param name="maybe2"></param>
    /// <param name="maybe3"></param>
    public void Deconstruct(out Maybe<T1> maybe1, out Maybe<T2> maybe2, out Maybe<T3> maybe3)
    {
        maybe1 = _o1;
        maybe2 = _o2;
        maybe3 = _o3;
    }

    #endregion

    #region Equals

    /// <inheritdoc />
    public bool Equals((T1, T2, T3) other)
    {
        return Item1 != null && Item1.Equals(other.Item1) &&
               Item2 != null && Item2.Equals(other.Item2) &&
               Item3 != null && Item3.Equals(other.Item3);
    }

    /// <inheritdoc />
    public bool Equals(Maybe<T1, T2, T3> other)
    {
        if (!HasValue && !other.HasValue)
            return true;
        if (HasValue && other.HasValue)
            return EqualityComparer<T1>.Default.Equals(Item1, other.Item1) &&
                   EqualityComparer<T2>.Default.Equals(Item2, other.Item2) &&
                   EqualityComparer<T3>.Default.Equals(Item3, other.Item3);
        return false;
    }

    /// <inheritdoc />
    public override bool Equals(object obj) => obj is Maybe<T1, T2, T3> maybe && Equals(maybe);

    #endregion

    #region Compare to

    /// <inheritdoc />
    public int CompareTo((T1, T2, T3) other)
    {
        if (!HasValue) return -1;
        var v = new[]
        {
            CompareHelper.Compare(Item1, other.Item1, 3),
            CompareHelper.Compare(Item2, other.Item2, 2),
            CompareHelper.Compare(Item3, other.Item3, 1)
        };
        return CompareHelper.Calc(v);
    }

    /// <inheritdoc />
    public int CompareTo(Maybe<T1, T2, T3> other)
    {
        if (HasValue && !other.HasValue) return 1;
        if (!HasValue && other.HasValue) return -1;
        var v = new[]
        {
            CompareHelper.Compare(Item1, other.Item1, 3),
            CompareHelper.Compare(Item2, other.Item2, 2),
            CompareHelper.Compare(Item3, other.Item3, 1)
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
    public static bool operator ==(Maybe<T1, T2, T3> left, Maybe<T1, T2, T3> right) => left.Equals(right);

    /// <summary>
    /// !=
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(Maybe<T1, T2, T3> left, Maybe<T1, T2, T3> right) => !left.Equals(right);

    #endregion

    #region < <= > >=

    /// <summary>
    /// Determines if an optional is less than another optional.
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator <(Maybe<T1, T2, T3> left, Maybe<T1, T2, T3> right) => left.CompareTo(right) < 0;

    /// <summary>
    /// Determines if an optional is less than or equal to another optional.
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator <=(Maybe<T1, T2, T3> left, Maybe<T1, T2, T3> right) => left.CompareTo(right) <= 0;

    /// <summary>
    /// Determines if an optional is greater than another optional.
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator >(Maybe<T1, T2, T3> left, Maybe<T1, T2, T3> right) => left.CompareTo(right) > 0;

    /// <summary>
    /// Determines if an optional is greater than or equal to another optional.
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator >=(Maybe<T1, T2, T3> left, Maybe<T1, T2, T3> right) => left.CompareTo(right) >= 0;

    #endregion

    #region Operator

    /// <summary>
    /// Convert maybe to tuple
    /// </summary>
    /// <param name="maybe"></param>
    /// <returns></returns>
    public static implicit operator (T1, T2, T3)(Maybe<T1, T2, T3> maybe)
    {
        return maybe.Value;
    }

    /// <summary>
    /// Convert maybe from tuple
    /// </summary>
    /// <param name="tuple"></param>
    /// <returns></returns>
    public static explicit operator Maybe<T1, T2, T3>((T1, T2, T3) tuple)
    {
        return Optional.From(tuple);
    }

    #endregion

    #region ToString

    /// <inheritdoc />
    public override string ToString()
    {
        return HasValue
            ? $"Some(Item1:{Item1},Item2:{Item2},Item3:{Item3})"
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
    public bool Contains((T1, T2, T3) value)
    {
        return _o1.Contains(value.Item1) &&
               _o2.Contains(value.Item2) &&
               _o3.Contains(value.Item3);
    }

    /// <inheritdoc />
    public bool Exists(Func<(T1, T2, T3), bool> predicate)
    {
        if (predicate is null)
            throw new ArgumentNullException(nameof(predicate));
        return HasValue && predicate(Value);
    }

    #endregion

    #region Value or

    /// <inheritdoc />
    public (T1, T2, T3) ValueOr((T1, T2, T3) alternative)
    {
        return HasValue ? Value : alternative;
    }

    /// <inheritdoc />
    public (T1, T2, T3) ValueOr(Func<(T1, T2, T3)> alternativeFactory)
    {
        if (alternativeFactory is null)
            throw new ArgumentNullException(nameof(alternativeFactory));
        return HasValue ? Value : alternativeFactory();
    }

    #endregion

    #region Or / Else

    /// <inheritdoc />
    public Maybe<T1, T2, T3> Or((T1, T2, T3) alternative)
    {
        return HasValue ? this : Optional.From(alternative);
    }

    /// <inheritdoc />
    public Maybe<T1, T2, T3> Or(Func<(T1, T2, T3)> alternativeFactory)
    {
        if (alternativeFactory is null)
            throw new ArgumentNullException(nameof(alternativeFactory));
        return HasValue ? this : Optional.From(alternativeFactory());
    }

    /// <inheritdoc />
    public Maybe<T1, T2, T3> Else(Maybe<T1, T2, T3> alternativeMaybe)
    {
        return HasValue ? this : alternativeMaybe;
    }

    /// <inheritdoc />
    public Maybe<T1, T2, T3> Else(Func<Maybe<T1, T2, T3>> alternativeMaybeFactory)
    {
        if (alternativeMaybeFactory is null)
            throw new ArgumentNullException(nameof(alternativeMaybeFactory));
        return HasValue ? this : alternativeMaybeFactory();
    }

    #endregion

    #region With exception

    /// <inheritdoc />
    public Either<(T1, T2, T3), TException> WithException<TException>(TException exception)
    {
        return Match(
            someFactory: Optional.Some<(T1, T2, T3), TException>,
            noneFactory: () => Optional.None<(T1, T2, T3), TException>(exception));
    }

    /// <inheritdoc />
    public object WithException<TException>(Func<TException> exceptionFactory)
    {
        if (exceptionFactory is null)
            throw new ArgumentNullException(nameof(exceptionFactory));
        return Match(
            someFactory: Optional.Some<(T1, T2, T3), TException>,
            noneFactory: () => Optional.None<(T1, T2, T3), TException>(exceptionFactory()));
    }

    #endregion

    #region Match

    /// <inheritdoc />
    public TResult Match<TResult>(Func<(T1, T2, T3), TResult> someFactory, Func<TResult> noneFactory)
    {
        if (someFactory is null)
            throw new ArgumentNullException(nameof(someFactory));
        if (noneFactory is null)
            throw new ArgumentNullException(nameof(noneFactory));
        return HasValue ? someFactory(Value) : noneFactory();
    }

    /// <inheritdoc />
    public void Match(Action<(T1, T2, T3)> someAct, Action noneAct)
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
    public void MatchMaybe(Action<(T1, T2, T3)> maybeAct)
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
    public Maybe<TResult> Map<TResult>(Func<(T1, T2, T3), TResult> mapping)
    {
        if (mapping is null)
            throw new ArgumentNullException(nameof(mapping));
        return Match(
            someFactory: val => Optional.Some(mapping(val)),
            noneFactory: Optional.None<TResult>);
    }

    /// <inheritdoc />
    public Maybe<TResult> FlatMap<TResult>(Func<(T1, T2, T3), Maybe<TResult>> mapping)
    {
        if (mapping is null)
            throw new ArgumentNullException(nameof(mapping));
        return Match(
            someFactory: mapping,
            noneFactory: Optional.None<TResult>);
    }

    /// <inheritdoc />
    public Maybe<TResult> FlatMap<TResult, TException>(Func<(T1, T2, T3), Either<TResult, TException>> mapping)
    {
        if (mapping is null)
            throw new ArgumentNullException(nameof(mapping));
        return FlatMap(val => mapping(val).WithoutException());
    }

    #endregion

    #region Filter

    /// <inheritdoc />
    public Maybe<T1, T2, T3> Filter(bool condition)
    {
        return HasValue && !condition ? Nothing : this;
    }

    /// <inheritdoc />
    public Maybe<T1, T2, T3> Filter(Func<(T1, T2, T3), bool> predicate)
    {
        if (predicate is null)
            throw new ArgumentNullException(nameof(predicate));
        return HasValue && !predicate(Value) ? Nothing : this;
    }

    #endregion

    #region Not null

    /// <inheritdoc />
    public Maybe<T1, T2, T3> NotNull()
    {
        return HasValue && _o1.Value is null && _o2.Value is null && _o3.Value is null ? Nothing : this;
    }

    #endregion

    #region To wrapped object

    /// <summary>
    /// To wrapped optional some <br />
    /// 封装为 MayBe 组件 Some
    /// </summary>
    /// <returns></returns>
    public Some<(T1, T2, T3)> ToWrappedSome() => new(Value);

    /// <summary>
    /// To wrapped optional none <br />
    /// 封装为 MayBe 组件 None
    /// </summary>
    /// <returns></returns>
    public None<(T1, T2, T3)> ToWrappedNone() => new();

    #endregion

    #region Join

    /// <summary>
    /// Join <br />
    /// 联合
    /// </summary>
    /// <param name="valueToJoin"></param>
    /// <typeparam name="T4"></typeparam>
    /// <returns></returns>
    public Maybe<T1, T2, T3, T4> Join<T4>(T4 valueToJoin)
        => new(_o1, _o2, _o3, Optional.From(valueToJoin));

    /// <summary>
    /// Join <br />
    /// 联合
    /// </summary>
    /// <param name="valueToJoin"></param>
    /// <param name="condition"></param>
    /// <typeparam name="T4"></typeparam>
    /// <returns></returns>
    public Maybe<T1, T2, T3, T4> Join<T4>(T4 valueToJoin, Func<T4, bool> condition)
        => new(_o1, _o2, _o3, Optional.From(valueToJoin, condition));

    /// <summary>
    /// Join <br />
    /// 联合
    /// </summary>
    /// <param name="optionalToJoin"></param>
    /// <typeparam name="T4"></typeparam>
    /// <returns></returns>
    public Maybe<T1, T2, T3, T4> Join<T4>(Maybe<T4> optionalToJoin)
        => new(_o1, _o2, _o3, optionalToJoin);

    #endregion

    #region Nothing

    /// <summary>
    /// Nothing <br />
    /// 获取一个 MayBe 组件 Nothing 实例
    /// </summary>
    public static Maybe<T1, T2, T3> Nothing => Optional.None<T1, T2, T3>();

    /// <summary>
    /// Empty <br />
    /// 获取一个 MayBe 组件 Nothing 实例
    /// </summary>
    public static Maybe<T1, T2, T3> Empty => Nothing;

    #endregion
}