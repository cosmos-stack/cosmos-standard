using Cosmos.UnionTypes.Internals;

// ReSharper disable RedundantExtendsListEntry

namespace Cosmos.UnionTypes;

public struct UnionType<T0, T1, T2, T3> : IUnionType, IUnionType<T0, T1, T2, T3>
{
    readonly T0 _v0;
    readonly T1 _v1;
    readonly T2 _v2;
    readonly T3 _v3;
    readonly int _ix;

    UnionType(int ix, T0 v0 = default, T1 v1 = default, T2 v2 = default, T3 v3 = default)
    {
        _ix = ix;
        _v0 = v0;
        _v1 = v1;
        _v2 = v2;
        _v3 = v3;
    }

    /// <inheritdoc />
    public object Value
    {
        get
        {
            return _ix switch
            {
                0 => _v0,
                1 => _v1,
                2 => _v2,
                3 => _v3,
                _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
            };
        }
    }

    /// <inheritdoc />
    public int Index => _ix;

    /// <inheritdoc />
    public bool IsT0() => _ix == 0;

    /// <inheritdoc />
    public bool IsT1() => _ix == 1;

    /// <inheritdoc />
    public bool IsT2() => _ix == 2;

    /// <inheritdoc />
    public bool IsT3() => _ix == 3;

    /// <inheritdoc />
    public T0 AsT0()
    {
        if (_ix == 0)
            return _v0;
        throw new InvalidOperationException($"Cannot return as T0 as result is T{_ix}");
    }

    /// <inheritdoc />
    public T1 AsT1()
    {
        if (_ix == 1)
            return _v1;
        throw new InvalidOperationException($"Cannot return as T1 as result is T{_ix}");
    }

    /// <inheritdoc />
    public T2 AsT2()
    {
        if (_ix == 2)
            return _v2;
        throw new InvalidOperationException($"Cannot return as T2 as result is T{_ix}");
    }

    /// <inheritdoc />
    public T3 AsT3()
    {
        if (_ix == 3)
            return _v3;
        throw new InvalidOperationException($"Cannot return as T3 as result is T{_ix}");
    }

    public static implicit operator UnionType<T0, T1, T2, T3>(T0 t) => new(0, v0: t);

    public static implicit operator UnionType<T0, T1, T2, T3>(T1 t) => new(0, v1: t);

    public static implicit operator UnionType<T0, T1, T2, T3>(T2 t) => new(0, v2: t);

    public static implicit operator UnionType<T0, T1, T2, T3>(T3 t) => new(0, v3: t);

    public void Switch(Action<T0> f0, Action<T1> f1, Action<T2> f2, Action<T3> f3)
    {
        if (_ix is 0 && f0 is not null)
        {
            f0(_v0);
            return;
        }

        if (_ix is 1 && f1 is not null)
        {
            f1(_v1);
            return;
        }

        if (_ix is 2 && f2 is not null)
        {
            f2(_v2);
            return;
        }

        if (_ix is 3 && f3 is not null)
        {
            f3(_v3);
            return;
        }

        throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.");
    }

    public TResult Match<TResult>(Func<T0, TResult> f0, Func<T1, TResult> f1, Func<T2, TResult> f2, Func<T3, TResult> f3)
    {
        if (_ix is 0 && f0 is not null)
        {
            return f0(_v0);
        }

        if (_ix is 1 && f1 is not null)
        {
            return f1(_v1);
        }

        if (_ix is 2 && f2 is not null)
        {
            return f2(_v2);
        }

        if (_ix is 3 && f3 is not null)
        {
            return f3(_v3);
        }

        throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.");
    }

    internal static UnionType<T0, T1, T2, T3> FromNull() => new(0);

    public static UnionType<T0, T1, T2, T3> FromT0(T0 input) => input;

    public static UnionType<T0, T1, T2, T3> FromT1(T1 input) => input;

    public static UnionType<T0, T1, T2, T3> FromT2(T2 input) => input;

    public static UnionType<T0, T1, T2, T3> FromT3(T3 input) => input;

    public UnionType<TResult, T1, T2, T3> MapT0<TResult>(Func<T0, TResult> mapFunc)
    {
        if (mapFunc is null)
            throw new ArgumentNullException(nameof(mapFunc));
        return _ix switch
        {
            0 => mapFunc(AsT0()),
            1 => AsT1(),
            2 => AsT2(),
            3 => AsT3(),
            _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
        };
    }

    public UnionType<T0, TResult, T2, T3> MapT1<TResult>(Func<T1, TResult> mapFunc)
    {
        if (mapFunc is null)
            throw new ArgumentNullException(nameof(mapFunc));
        return _ix switch
        {
            0 => AsT0(),
            1 => mapFunc(AsT1()),
            2 => AsT2(),
            3 => AsT3(),
            _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
        };
    }

    public UnionType<T0, T1, TResult, T3> MapT2<TResult>(Func<T2, TResult> mapFunc)
    {
        if (mapFunc is null)
            throw new ArgumentNullException(nameof(mapFunc));
        return _ix switch
        {
            0 => AsT0(),
            1 => AsT1(),
            2 => mapFunc(AsT2()),
            3 => AsT3(),
            _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
        };
    }

    public UnionType<T0, T1, T2, TResult> MapT3<TResult>(Func<T3, TResult> mapFunc)
    {
        if (mapFunc is null)
            throw new ArgumentNullException(nameof(mapFunc));
        return _ix switch
        {
            0 => AsT0(),
            1 => AsT1(),
            2 => AsT2(),
            3 => mapFunc(AsT3()),
            _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
        };
    }

    public bool TryPickT0(out T0 value, out UnionType<T1, T2, T3> remainder)
    {
        value = IsT0() ? AsT0() : default;
        remainder = _ix switch
        {
            0 => default,
            1 => AsT1(),
            2 => AsT2(),
            3 => AsT3(),
            _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
        };
        return IsT0();
    }

    public bool TryPickT1(out T1 value, out UnionType<T0, T2, T3> remainder)
    {
        value = IsT1() ? AsT1() : default;
        remainder = _ix switch
        {
            0 => AsT0(),
            1 => default,
            2 => AsT2(),
            3 => AsT3(),
            _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
        };
        return IsT1();
    }

    public bool TryPickT2(out T2 value, out UnionType<T0, T1, T3> remainder)
    {
        value = IsT2() ? AsT2() : default;
        remainder = _ix switch
        {
            0 => AsT0(),
            1 => AsT1(),
            2 => default,
            3 => AsT3(),
            _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
        };
        return IsT2();
    }

    public bool TryPickT3(out T3 value, out UnionType<T0, T1, T2> remainder)
    {
        value = IsT3() ? AsT3() : default;
        remainder = _ix switch
        {
            0 => AsT0(),
            1 => AsT1(),
            2 => AsT2(),
            3 => default,
            _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
        };
        return IsT3();
    }

    public Maybe<T0, T1, T2, T3> AsOptionals()
    {
        return Optional.From(_v0, _v1, _v2, _v3);
    }

    bool Equals(UnionType<T0, T1, T2, T3> other)
    {
        return _ix == other._ix
            && _ix switch
               {
                   0 => Equals(_v0, other._v0),
                   1 => Equals(_v1, other._v1),
                   2 => Equals(_v2, other._v2),
                   3 => Equals(_v3, other._v3),
                   _ => false
               };
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj))
            return false;
        return obj is UnionType<T0, T1, T2, T3> o && Equals(o);
    }

    public override string ToString()
    {
        return _ix switch
        {
            0 => FormatHelper.FormatValue(_v0),
            1 => FormatHelper.FormatValue(_v1),
            2 => FormatHelper.FormatValue(_v2),
            3 => FormatHelper.FormatValue(_v3),
            _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
        };
    }

    public override int GetHashCode()
    {
        unchecked
        {
            var hashCode = _ix switch
            {
                0 => _v0?.GetHashCode(),
                1 => _v1?.GetHashCode(),
                2 => _v2?.GetHashCode(),
                3 => _v3?.GetHashCode(),
                _ => 0
            } ?? 0;
            return (hashCode * 397) ^ _ix;
        }
    }
}