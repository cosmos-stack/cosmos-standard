using Cosmos.UnionTypes.Internals;

// ReSharper disable RedundantExtendsListEntry

namespace Cosmos.UnionTypes;

/// <summary>
/// Union Of <br />
/// 联合类型
/// </summary>
/// <typeparam name="T0"></typeparam>
/// <typeparam name="T1"></typeparam>
public class UnionOf<T0, T1> : IUnionType, IUnionType<T0, T1>
{
    readonly T0 _v0;
    readonly T1 _v1;
    readonly int _ix;

    protected UnionOf(UnionType<T0, T1> input)
    {
        _ix = input.Index;
        switch (_ix)
        {
            case 0:
                _v0 = input.AsT0();
                break;
            case 1:
                _v1 = input.AsT1();
                break;
            default:
                throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionOf codegen.");
        }
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
                _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionOf codegen.")
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
        return _ix == 0
            ? _v0
            : throw new InvalidOperationException($"Cannot return as T0 as result is T{_ix}");
    }

    /// <inheritdoc />
    public T1 AsT1()
    {
        return _ix == 1
            ? _v1
            : throw new InvalidOperationException($"Cannot return as T1 as result is T{_ix}");
    }

#if NETFRAMEWORK
    /// <inheritdoc />
    public Type TypeOfT0 => typeof(T0);

    /// <inheritdoc />
    public Type TypeOfT1 => typeof(T1);

    public int Count() => 2;
#endif

    public void Switch(Action<T0> f0, Action<T1> f1)
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

        throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionOf codegen.");
    }

    public TResult Match<TResult>(Func<T0, TResult> f0, Func<T1, TResult> f1)
    {
        if (_ix is 0 && f0 is not null)
        {
            return f0(_v0);
        }

        if (_ix is 1 && f1 is not null)
        {
            return f1(_v1);
        }

        throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionOf codegen.");
    }

    /// <summary>
    /// Try to get the value of the first type <br />
    /// 尝试获取第 1 个类型的值
    /// </summary>
    /// <param name="value"></param>
    /// <param name="remainder"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public bool TryPickT0(out T0 value, out T1 remainder)
    {
        value = IsT0() ? AsT0() : default;
        remainder = _ix switch
        {
            0 => default,
            1 => AsT1(),
            _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionOf codegen.")
        };
        return IsT0();
    }

    /// <summary>
    /// Try to get the value of the second type <br />
    /// 尝试获取第 2 个类型的值
    /// </summary>
    /// <param name="value"></param>
    /// <param name="remainder"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public bool TryPickT1(out T1 value, out T0 remainder)
    {
        value = IsT1() ? AsT1() : default;
        remainder = _ix switch
        {
            0 => AsT0(),
            1 => default,
            _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionOf codegen.")
        };
        return IsT1();
    }

    bool Equals(UnionOf<T0, T1> other)
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

        if (ReferenceEquals(this, obj))
            return true;

        return obj is UnionOf<T0, T1> o && Equals(o);
    }

    public override string ToString()
    {
        return _ix switch
        {
            0 => FormatHelper.FormatValue(_v0),
            1 => FormatHelper.FormatValue(_v1),
            _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionOf codegen.")
        };
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = _ix switch
            {
                0 => _v0?.GetHashCode(),
                1 => _v1?.GetHashCode(),
                _ => 0
            } ?? 0;
            return (hashCode * 397) ^ _ix;
        }
    }
}