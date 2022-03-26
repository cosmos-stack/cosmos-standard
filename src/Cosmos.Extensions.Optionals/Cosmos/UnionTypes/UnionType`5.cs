using Cosmos.UnionTypes.Internals;

// ReSharper disable RedundantExtendsListEntry

namespace Cosmos.UnionTypes;

public struct UnionType<T0, T1, T2, T3, T4, T5> : IUnionType, IUnionType<T0, T1, T2, T3, T4, T5>
{
    readonly T0 _v0;
    readonly T1 _v1;
    readonly T2 _v2;
    readonly T3 _v3;
    readonly T4 _v4;
    readonly T5 _v5;
    readonly int _ix;

    UnionType(int ix, T0 v0 = default, T1 v1 = default, T2 v2 = default, T3 v3 = default, T4 v4 = default, T5 v5 = default)
    {
        _ix = ix;
        _v0 = v0;
        _v1 = v1;
        _v2 = v2;
        _v3 = v3;
        _v4 = v4;
        _v5 = v5;
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
                4 => _v4,
                5 => _v5,
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
    public bool IsT4() => _ix == 4;

    /// <inheritdoc />
    public bool IsT5() => _ix == 5;

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

    /// <inheritdoc />
    public T4 AsT4()
    {
        if (_ix == 4)
            return _v4;
        throw new InvalidOperationException($"Cannot return as T4 as result is T{_ix}");
    }

    /// <inheritdoc />
    public T5 AsT5()
    {
        if (_ix == 5)
            return _v5;
        throw new InvalidOperationException($"Cannot return as T5 as result is T{_ix}");
    }

    public static implicit operator UnionType<T0, T1, T2, T3, T4, T5>(T0 t) => new(0, v0: t);

    public static implicit operator UnionType<T0, T1, T2, T3, T4, T5>(T1 t) => new(0, v1: t);

    public static implicit operator UnionType<T0, T1, T2, T3, T4, T5>(T2 t) => new(0, v2: t);

    public static implicit operator UnionType<T0, T1, T2, T3, T4, T5>(T3 t) => new(0, v3: t);

    public static implicit operator UnionType<T0, T1, T2, T3, T4, T5>(T4 t) => new(0, v4: t);

    public static implicit operator UnionType<T0, T1, T2, T3, T4, T5>(T5 t) => new(0, v5: t);

    public void Switch(Action<T0> f0, Action<T1> f1, Action<T2> f2, Action<T3> f3, Action<T4> f4, Action<T5> f5)
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

        if (_ix is 4 && f4 is not null)
        {
            f4(_v4);
            return;
        }

        if (_ix is 5 && f5 is not null)
        {
            f5(_v5);
            return;
        }

        throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.");
    }

    public TResult Match<TResult>(Func<T0, TResult> f0, Func<T1, TResult> f1, Func<T2, TResult> f2, Func<T3, TResult> f3, Func<T4, TResult> f4, Func<T5, TResult> f5)
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

        if (_ix is 4 && f4 is not null)
        {
            return f4(_v4);
        }

        if (_ix is 5 && f5 is not null)
        {
            return f5(_v5);
        }

        throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.");
    }

    internal static UnionType<T0, T1, T2, T3, T4, T5> FromNull() => new(0);

    public static UnionType<T0, T1, T2, T3, T4, T5> FromT0(T0 input) => input;

    public static UnionType<T0, T1, T2, T3, T4, T5> FromT1(T1 input) => input;

    public static UnionType<T0, T1, T2, T3, T4, T5> FromT2(T2 input) => input;

    public static UnionType<T0, T1, T2, T3, T4, T5> FromT3(T3 input) => input;

    public static UnionType<T0, T1, T2, T3, T4, T5> FromT4(T4 input) => input;

    public static UnionType<T0, T1, T2, T3, T4, T5> FromT5(T5 input) => input;

    public UnionType<TResult, T1, T2, T3, T4, T5> MapT0<TResult>(Func<T0, TResult> mapFunc)
    {
        if (mapFunc is null)
            throw new ArgumentNullException(nameof(mapFunc));
        return _ix switch
        {
            0 => mapFunc(AsT0()),
            1 => AsT1(),
            2 => AsT2(),
            3 => AsT3(),
            4 => AsT4(),
            5 => AsT5(),
            _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
        };
    }

    public UnionType<T0, TResult, T2, T3, T4, T5> MapT1<TResult>(Func<T1, TResult> mapFunc)
    {
        if (mapFunc is null)
            throw new ArgumentNullException(nameof(mapFunc));
        return _ix switch
        {
            0 => AsT0(),
            1 => mapFunc(AsT1()),
            2 => AsT2(),
            3 => AsT3(),
            4 => AsT4(),
            5 => AsT5(),
            _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
        };
    }

    public UnionType<T0, T1, TResult, T3, T4, T5> MapT2<TResult>(Func<T2, TResult> mapFunc)
    {
        if (mapFunc is null)
            throw new ArgumentNullException(nameof(mapFunc));
        return _ix switch
        {
            0 => AsT0(),
            1 => AsT1(),
            2 => mapFunc(AsT2()),
            3 => AsT3(),
            4 => AsT4(),
            5 => AsT5(),
            _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
        };
    }

    public UnionType<T0, T1, T2, TResult, T4, T5> MapT3<TResult>(Func<T3, TResult> mapFunc)
    {
        if (mapFunc is null)
            throw new ArgumentNullException(nameof(mapFunc));
        return _ix switch
        {
            0 => AsT0(),
            1 => AsT1(),
            2 => AsT2(),
            3 => mapFunc(AsT3()),
            4 => AsT4(),
            5 => AsT5(),
            _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
        };
    }

    public UnionType<T0, T1, T2, T3, TResult, T5> MapT4<TResult>(Func<T4, TResult> mapFunc)
    {
        if (mapFunc is null)
            throw new ArgumentNullException(nameof(mapFunc));
        return _ix switch
        {
            0 => AsT0(),
            1 => AsT1(),
            2 => AsT2(),
            3 => AsT3(),
            4 => mapFunc(AsT4()),
            5 => AsT5(),
            _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
        };
    }

    public UnionType<T0, T1, T2, T3, T4, TResult> MapT5<TResult>(Func<T5, TResult> mapFunc)
    {
        if (mapFunc is null)
            throw new ArgumentNullException(nameof(mapFunc));
        return _ix switch
        {
            0 => AsT0(),
            1 => AsT1(),
            2 => AsT2(),
            3 => AsT3(),
            4 => AsT4(),
            5 => mapFunc(AsT5()),
            _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
        };
    }

    public bool TryPickT0(out T0 value, out UnionType<T1, T2, T3, T4, T5> remainder)
    {
        value = IsT0() ? AsT0() : default;
        remainder = _ix switch
        {
            0 => default,
            1 => AsT1(),
            2 => AsT2(),
            3 => AsT3(),
            4 => AsT4(),
            5 => AsT5(),
            _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
        };
        return IsT0();
    }

    public bool TryPickT1(out T1 value, out UnionType<T0, T2, T3, T4, T5> remainder)
    {
        value = IsT1() ? AsT1() : default;
        remainder = _ix switch
        {
            0 => AsT0(),
            1 => default,
            2 => AsT2(),
            3 => AsT3(),
            4 => AsT4(),
            5 => AsT5(),
            _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
        };
        return IsT1();
    }

    public bool TryPickT2(out T2 value, out UnionType<T0, T1, T3, T4, T5> remainder)
    {
        value = IsT2() ? AsT2() : default;
        remainder = _ix switch
        {
            0 => AsT0(),
            1 => AsT1(),
            2 => default,
            3 => AsT3(),
            4 => AsT4(),
            5 => AsT5(),
            _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
        };
        return IsT2();
    }

    public bool TryPickT3(out T3 value, out UnionType<T0, T1, T2, T4, T5> remainder)
    {
        value = IsT3() ? AsT3() : default;
        remainder = _ix switch
        {
            0 => AsT0(),
            1 => AsT1(),
            2 => AsT2(),
            3 => default,
            4 => AsT4(),
            5 => AsT5(),
            _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
        };
        return IsT3();
    }

    public bool TryPickT4(out T4 value, out UnionType<T0, T1, T2, T3, T5> remainder)
    {
        value = IsT4() ? AsT4() : default;
        remainder = _ix switch
        {
            0 => AsT0(),
            1 => AsT1(),
            2 => AsT2(),
            3 => AsT3(),
            4 => default,
            5 => AsT5(),
            _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
        };
        return IsT4();
    }

    public bool TryPickT5(out T5 value, out UnionType<T0, T1, T2, T3, T4> remainder)
    {
        value = IsT5() ? AsT5() : default;
        remainder = _ix switch
        {
            0 => AsT0(),
            1 => AsT1(),
            2 => AsT2(),
            3 => AsT3(),
            4 => AsT4(),
            5 => default,
            _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
        };
        return IsT5();
    }

    public Maybe<T0, T1, T2, T3, T4, T5> AsOptionals()
    {
        return Optional.From(_v0, _v1, _v2, _v3, _v4, _v5);
    }

    bool Equals(UnionType<T0, T1, T2, T3, T4, T5> other)
    {
        return _ix == other._ix
            && _ix switch
               {
                   0 => Equals(_v0, other._v0),
                   1 => Equals(_v1, other._v1),
                   2 => Equals(_v2, other._v2),
                   3 => Equals(_v3, other._v3),
                   4 => Equals(_v4, other._v4),
                   5 => Equals(_v5, other._v5),
                   _ => false
               };
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj))
            return false;
        return obj is UnionType<T0, T1, T2, T3, T4, T5> o && Equals(o);
    }

    public override string ToString()
    {
        return _ix switch
        {
            0 => FormatHelper.FormatValue(_v0),
            1 => FormatHelper.FormatValue(_v1),
            2 => FormatHelper.FormatValue(_v2),
            3 => FormatHelper.FormatValue(_v3),
            4 => FormatHelper.FormatValue(_v4),
            5 => FormatHelper.FormatValue(_v5),
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
                4 => _v4?.GetHashCode(),
                5 => _v5?.GetHashCode(),
                _ => 0
            } ?? 0;
            return (hashCode * 397) ^ _ix;
        }
    }
}