using Cosmos.UnionTypes.Internals;

// ReSharper disable RedundantExtendsListEntry

namespace Cosmos.UnionTypes;

public struct UnionType<T0, T1> : IUnionType, IUnionType<T0, T1>
{
    readonly T0 _v0;
    readonly T1 _v1;
    readonly int _ix;

    UnionType(int ix, T0 v0 = default, T1 v1 = default)
    {
        _ix = ix;
        _v0 = v0;
        _v1 = v1;
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

    public static implicit operator UnionType<T0, T1>(T0 t) => new(0, v0: t);

    public static implicit operator UnionType<T0, T1>(T1 t) => new(0, v1: t);

    public void Switch(Action<T0> f0, Action<T1> f1)
    {
        switch (_ix)
        {
            case 0:
                f0(_v0);
                return;
            case 1:
                f1(_v1);
                return;
            default:
                throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.");
        }
    }

    public TResult Match<TResult>(Func<T0, TResult> f0, Func<T1, TResult> f1)
    {
        return _ix switch
        {
            0 => f0(_v0),
            1 => f1(_v1),
            _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
        };
    }

    internal static UnionType<T0, T1> FromNull() => new(0);

    public static UnionType<T0, T1> FromT0(T0 input) => input;

    public static UnionType<T0, T1> FromT1(T1 input) => input;

    public UnionType<TResult, T1> MapT0<TResult>(Func<T0, TResult> mapFunc)
    {
        ArgumentNullException.ThrowIfNull(mapFunc);
        return _ix switch
        {
            0 => mapFunc(AsT0()),
            1 => AsT1(),
            _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
        };
    }

    public UnionType<T0, TResult> MapT1<TResult>(Func<T1, TResult> mapFunc)
    {
        ArgumentNullException.ThrowIfNull(mapFunc);
        return _ix switch
        {
            0 => AsT0(),
            1 => mapFunc(AsT1()),
            _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
        };
    }

    public bool TryPickT0(out T0 value, out T1 remainder)
    {
        value = IsT0() ? AsT0() : default;
        remainder = _ix switch
        {
            0 => default,
            1 => AsT1(),
            _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
        };
        return IsT0();
    }

    public bool TryPickT1(out T1 value, out T0 remainder)
    {
        value = IsT1() ? AsT1() : default;
        remainder = _ix switch
        {
            0 => AsT0(),
            1 => default,
            _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
        };
        return IsT1();
    }

    public Maybe<T0, T1> AsOptionals()
    {
        return Optional.From(_v0, _v1);
    }

    bool Equals(UnionType<T0, T1> other)
    {
        return _ix == other._ix
            && _ix switch
               {
                   0 => Equals(_v0, other._v0),
                   1 => Equals(_v1, other._v1),
                   _ => false
               };
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj))
            return false;
        return obj is UnionType<T0, T1> o && Equals(o);
    }

    public override string ToString()
    {
        return _ix switch
        {
            0 => FormatHelper.FormatValue(_v0),
            1 => FormatHelper.FormatValue(_v1),
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
                _ => 0
            } ?? 0;
            return (hashCode * 397) ^ _ix;
        }
    }
}