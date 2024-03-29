﻿using Cosmos.UnionTypes.Internals;

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
/// <typeparam name="T4"></typeparam>
/// <typeparam name="T5"></typeparam>
/// <typeparam name="T6"></typeparam>
/// <typeparam name="T7"></typeparam>
public class UnionOf<T0, T1, T2, T3, T4, T5, T6, T7> : IUnionType, IUnionType<T0, T1, T2, T3, T4, T5, T6, T7>
{
    readonly T0 _v0;
    readonly T1 _v1;
    readonly T2 _v2;
    readonly T3 _v3;
    readonly T4 _v4;
    readonly T5 _v5;
    readonly T6 _v6;
    readonly T7 _v7;
    readonly int _ix;

    protected UnionOf(UnionType<T0, T1, T2, T3, T4, T5, T6, T7> input)
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
            case 4:
                _v4 = input.AsT4();
                break;
            case 5:
                _v5 = input.AsT5();
                break;
            case 6:
                _v6 = input.AsT6();
                break;
            case 7:
                _v7 = input.AsT7();
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
                4 => _v4,
                5 => _v5,
                6 => _v6,
                7 => _v7,
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
    public bool IsT4() => _ix == 4;

    /// <inheritdoc />
    public bool IsT5() => _ix == 5;

    /// <inheritdoc />
    public bool IsT6() => _ix == 6;

    /// <inheritdoc />
    public bool IsT7() => _ix == 7;

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

    /// <inheritdoc />
    public T4 AsT4()
    {
        return _ix == 4
            ? _v4
            : throw new InvalidOperationException($"Cannot return as T4 as result is T{_ix}");
    }

    /// <inheritdoc />
    public T5 AsT5()
    {
        return _ix == 5
            ? _v5
            : throw new InvalidOperationException($"Cannot return as T5 as result is T{_ix}");
    }

    /// <inheritdoc />
    public T6 AsT6()
    {
        return _ix == 6
            ? _v6
            : throw new InvalidOperationException($"Cannot return as T6 as result is T{_ix}");
    }

    /// <inheritdoc />
    public T7 AsT7()
    {
        return _ix == 7
            ? _v7
            : throw new InvalidOperationException($"Cannot return as T7 as result is T{_ix}");
    }

    public void Switch(Action<T0> f0, Action<T1> f1, Action<T2> f2, Action<T3> f3, Action<T4> f4, Action<T5> f5, Action<T6> f6, Action<T7> f7)
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
            case 4:
                f4(_v4);
                return;
            case 5:
                f5(_v5);
                return;
            case 6:
                f6(_v6);
                return;
            case 7:
                f7(_v7);
                return;
            default:
                throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionOf codegen.");
        }
    }

    public TResult Match<TResult>(Func<T0, TResult> f0, Func<T1, TResult> f1, Func<T2, TResult> f2, Func<T3, TResult> f3, Func<T4, TResult> f4, Func<T5, TResult> f5, Func<T6, TResult> f6, Func<T7, TResult> f7)
    {
        return _ix switch
        {
            0 => f0(_v0),
            1 => f1(_v1),
            2 => f2(_v2),
            3 => f3(_v3),
            4 => f4(_v4),
            5 => f5(_v5),
            6 => f6(_v6),
            7 => f7(_v7),
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
    public bool TryPickT0(out T0 value, out UnionType<T1, T2, T3, T4, T5, T6, T7> remainder)
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
            6 => AsT6(),
            7 => AsT7(),
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
    public bool TryPickT1(out T1 value, out UnionType<T0, T2, T3, T4, T5, T6, T7> remainder)
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
            6 => AsT6(),
            7 => AsT7(),
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
    public bool TryPickT2(out T2 value, out UnionType<T0, T1, T3, T4, T5, T6, T7> remainder)
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
            6 => AsT6(),
            7 => AsT7(),
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
    public bool TryPickT3(out T3 value, out UnionType<T0, T1, T2, T4, T5, T6, T7> remainder)
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
            6 => AsT6(),
            7 => AsT7(),
            _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionOf codegen.")
        };
        return IsT3();
    }

    /// <summary>
    /// Try to get the value of the fifth type <br />
    /// 尝试获取第 5 个类型的值
    /// </summary>
    /// <param name="value"></param>
    /// <param name="remainder"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public bool TryPickT4(out T4 value, out UnionType<T0, T1, T2, T3, T5, T6, T7> remainder)
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
            6 => AsT6(),
            7 => AsT7(),
            _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionOf codegen.")
        };
        return IsT4();
    }

    /// <summary>
    /// Try to get the value of the sixth type <br />
    /// 尝试获取第 6 个类型的值
    /// </summary>
    /// <param name="value"></param>
    /// <param name="remainder"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public bool TryPickT5(out T5 value, out UnionType<T0, T1, T2, T3, T4, T6, T7> remainder)
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
            6 => AsT6(),
            7 => AsT7(),
            _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionOf codegen.")
        };
        return IsT5();
    }

    /// <summary>
    /// Try to get the value of the seventh type <br />
    /// 尝试获取第 7 个类型的值
    /// </summary>
    /// <param name="value"></param>
    /// <param name="remainder"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public bool TryPickT6(out T6 value, out UnionType<T0, T1, T2, T3, T4, T5, T7> remainder)
    {
        value = IsT6() ? AsT6() : default;
        remainder = _ix switch
        {
            0 => AsT0(),
            1 => AsT1(),
            2 => AsT2(),
            3 => AsT3(),
            4 => AsT4(),
            5 => AsT5(),
            6 => default,
            7 => AsT7(),
            _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionOf codegen.")
        };
        return IsT6();
    }

    /// <summary>
    /// Try to get the value of the eighth type <br />
    /// 尝试获取第 8 个类型的值
    /// </summary>
    /// <param name="value"></param>
    /// <param name="remainder"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public bool TryPickT7(out T7 value, out UnionType<T0, T1, T2, T3, T4, T5, T6> remainder)
    {
        value = IsT7() ? AsT7() : default;
        remainder = _ix switch
        {
            0 => AsT0(),
            1 => AsT1(),
            2 => AsT2(),
            3 => AsT3(),
            4 => AsT4(),
            5 => AsT5(),
            6 => AsT6(),
            7 => default,
            _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionOf codegen.")
        };
        return IsT7();
    }

    bool Equals(UnionOf<T0, T1, T2, T3, T4, T5, T6, T7> other)
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
                   6 => Equals(_v6, other._v6),
                   7 => Equals(_v7, other._v7),
                   _ => false
               };
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj))
            return false;

        if (ReferenceEquals(this, obj))
            return true;

        return obj is UnionOf<T0, T1, T2, T3, T4, T5, T6, T7> o && Equals(o);
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
            6 => FormatHelper.FormatValue(_v6),
            7 => FormatHelper.FormatValue(_v7),
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
                4 => _v4?.GetHashCode(),
                5 => _v5?.GetHashCode(),
                6 => _v6?.GetHashCode(),
                7 => _v7?.GetHashCode(),
                _ => 0
            } ?? 0;
            return (hashCode * 397) ^ _ix;
        }
    }
}