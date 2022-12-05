using Cosmos.UnionTypes.Internals;

// ReSharper disable RedundantExtendsListEntry

namespace Cosmos.UnionTypes;

/// <summary>
/// Union Of <br />
/// 联合类型
/// </summary>
/// <typeparam name="T0"></typeparam>
/// <typeparam name="T1"></typeparam>
/// <typeparam name="T2"></typeparam>
/// <typeparam name="T3"></typeparam>
public class UnionOf<T0, T1, T2, T3> : IUnionType, IUnionType<T0, T1, T2, T3>
{
    readonly T0 _v0;
    readonly T1 _v1;
    readonly T2 _v2;
    readonly T3 _v3;
    readonly int _ix;

    protected UnionOf(UnionType<T0, T1, T2, T3> input)
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
            case 2:
                _v2 = input.AsT2();
                break;
            case 3:
                _v3 = input.AsT3();
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
                2 => _v2,
                3 => _v3,
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
    public bool IsT2() => _ix == 2;

    /// <inheritdoc />
    public bool IsT3() => _ix == 3;

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

    /// <inheritdoc />
    public T2 AsT2()
    {
        return _ix == 2
            ? _v2
            : throw new InvalidOperationException($"Cannot return as T2 as result is T{_ix}");
    }

    /// <inheritdoc />
    public T3 AsT3()
    {
        return _ix == 3
            ? _v3
            : throw new InvalidOperationException($"Cannot return as T3 as result is T{_ix}");
    }

    public void Switch(Action<T0> f0, Action<T1> f1, Action<T2> f2, Action<T3> f3)
    {
        switch (_ix)
        {
            case 0:
                f0(_v0);
                return;
            case 1:
                f1(_v1);
                return;
            case 2:
                f2(_v2);
                return;
            case 3:
                f3(_v3);
                return;
            default:
                throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionOf codegen.");
        }
    }

    public TResult Match<TResult>(Func<T0, TResult> f0, Func<T1, TResult> f1, Func<T2, TResult> f2, Func<T3, TResult> f3)
    {
        return _ix switch
        {
            0 => f0(_v0),
            1 => f1(_v1),
            2 => f2(_v2),
            3 => f3(_v3),
            _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionOf codegen.")
        };
    }

    /// <summary>
    /// Try to get the value of the first type <br />
    /// 尝试获取第 1 个类型的值
    /// </summary>
    /// <param name="value"></param>
    /// <param name="remainder"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public bool TryPickT0(out T0 value, out UnionType<T1, T2, T3> remainder)
    {
        value = IsT0() ? AsT0() : default;
        remainder = _ix switch
        {
            0 => default,
            1 => AsT1(),
            2 => AsT2(),
            3 => AsT3(),
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
    public bool TryPickT1(out T1 value, out UnionType<T0, T2, T3> remainder)
    {
        value = IsT1() ? AsT1() : default;
        remainder = _ix switch
        {
            0 => AsT0(),
            1 => default,
            2 => AsT2(),
            3 => AsT3(),
            _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionOf codegen.")
        };
        return IsT1();
    }

    /// <summary>
    /// Try to get the value of the third type <br />
    /// 尝试获取第 3 个类型的值
    /// </summary>
    /// <param name="value"></param>
    /// <param name="remainder"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public bool TryPickT2(out T2 value, out UnionType<T0, T1, T3> remainder)
    {
        value = IsT2() ? AsT2() : default;
        remainder = _ix switch
        {
            0 => AsT0(),
            1 => AsT1(),
            2 => default,
            3 => AsT3(),
            _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionOf codegen.")
        };
        return IsT2();
    }

    /// <summary>
    /// Try to get the value of the forth type <br />
    /// 尝试获取第 4 个类型的值
    /// </summary>
    /// <param name="value"></param>
    /// <param name="remainder"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public bool TryPickT3(out T3 value, out UnionType<T0, T1, T2> remainder)
    {
        value = IsT3() ? AsT3() : default;
        remainder = _ix switch
        {
            0 => AsT0(),
            1 => AsT1(),
            2 => AsT2(),
            3 => default,
            _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionOf codegen.")
        };
        return IsT3();
    }

    bool Equals(UnionOf<T0, T1, T2, T3> other)
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

        if (ReferenceEquals(this, obj))
            return true;

        return obj is UnionOf<T0, T1, T2, T3> o && Equals(o);
    }

    public override string ToString()
    {
        return _ix switch
        {
            0 => FormatHelper.FormatValue(_v0),
            1 => FormatHelper.FormatValue(_v1),
            2 => FormatHelper.FormatValue(_v2),
            3 => FormatHelper.FormatValue(_v3),
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
                2 => _v2?.GetHashCode(),
                3 => _v3?.GetHashCode(),
                _ => 0
            } ?? 0;
            return (hashCode * 397) ^ _ix;
        }
    }
}