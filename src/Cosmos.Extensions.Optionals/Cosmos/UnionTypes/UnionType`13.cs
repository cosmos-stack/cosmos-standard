﻿using Cosmos.UnionTypes.Internals;

// ReSharper disable RedundantExtendsListEntry

namespace Cosmos.UnionTypes;

public struct UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> : IUnionType, IUnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>
{
    readonly T0 _v0;
    readonly T1 _v1;
    readonly T2 _v2;
    readonly T3 _v3;
    readonly T4 _v4;
    readonly T5 _v5;
    readonly T6 _v6;
    readonly T7 _v7;
    readonly T8 _v8;
    readonly T9 _v9;
    readonly T10 _v10;
    readonly T11 _v11;
    readonly T12 _v12;
    readonly T13 _v13;
    readonly int _ix;

    UnionType(int ix, T0 v0 = default, T1 v1 = default, T2 v2 = default, T3 v3 = default, T4 v4 = default, T5 v5 = default, T6 v6 = default, T7 v7 = default, T8 v8 = default, T9 v9 = default, T10 v10 = default,
        T11 v11 = default, T12 v12 = default, T13 v13 = default)
    {
        _ix = ix;
        _v0 = v0;
        _v1 = v1;
        _v2 = v2;
        _v3 = v3;
        _v4 = v4;
        _v5 = v5;
        _v6 = v6;
        _v7 = v7;
        _v8 = v8;
        _v9 = v9;
        _v10 = v10;
        _v11 = v11;
        _v12 = v12;
        _v13 = v13;
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
                8 => _v8,
                9 => _v9,
                10 => _v10,
                11 => _v11,
                12 => _v12,
                13 => _v13,
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
    public bool IsT6() => _ix == 6;

    /// <inheritdoc />
    public bool IsT7() => _ix == 7;

    /// <inheritdoc />
    public bool IsT8() => _ix == 8;

    /// <inheritdoc />
    public bool IsT9() => _ix == 9;

    /// <inheritdoc />
    public bool IsT10() => _ix == 10;

    /// <inheritdoc />
    public bool IsT11() => _ix == 11;

    /// <inheritdoc />
    public bool IsT12() => _ix == 12;

    /// <inheritdoc />
    public bool IsT13() => _ix == 13;

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

    /// <inheritdoc />
    public T6 AsT6()
    {
        if (_ix == 6)
            return _v6;
        throw new InvalidOperationException($"Cannot return as T6 as result is T{_ix}");
    }

    /// <inheritdoc />
    public T7 AsT7()
    {
        if (_ix == 7)
            return _v7;
        throw new InvalidOperationException($"Cannot return as T7 as result is T{_ix}");
    }

    /// <inheritdoc />
    public T8 AsT8()
    {
        if (_ix == 8)
            return _v8;
        throw new InvalidOperationException($"Cannot return as T8 as result is T{_ix}");
    }

    /// <inheritdoc />
    public T9 AsT9()
    {
        if (_ix == 9)
            return _v9;
        throw new InvalidOperationException($"Cannot return as T9 as result is T{_ix}");
    }

    /// <inheritdoc />
    public T10 AsT10()
    {
        if (_ix == 10)
            return _v10;
        throw new InvalidOperationException($"Cannot return as T10 as result is T{_ix}");
    }

    /// <inheritdoc />
    public T11 AsT11()
    {
        if (_ix == 11)
            return _v11;
        throw new InvalidOperationException($"Cannot return as T11 as result is T{_ix}");
    }

    /// <inheritdoc />
    public T12 AsT12()
    {
        if (_ix == 12)
            return _v12;
        throw new InvalidOperationException($"Cannot return as T12 as result is T{_ix}");
    }

    /// <inheritdoc />
    public T13 AsT13()
    {
        if (_ix == 13)
            return _v13;
        throw new InvalidOperationException($"Cannot return as T13 as result is T{_ix}");
    }

    public static implicit operator UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T0 t) => new(0, v0: t);

    public static implicit operator UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T1 t) => new(0, v1: t);

    public static implicit operator UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T2 t) => new(0, v2: t);

    public static implicit operator UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T3 t) => new(0, v3: t);

    public static implicit operator UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T4 t) => new(0, v4: t);

    public static implicit operator UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T5 t) => new(0, v5: t);

    public static implicit operator UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T6 t) => new(0, v6: t);

    public static implicit operator UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T7 t) => new(0, v7: t);

    public static implicit operator UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T8 t) => new(0, v8: t);

    public static implicit operator UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T9 t) => new(0, v9: t);

    public static implicit operator UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T10 t) => new(0, v10: t);

    public static implicit operator UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T11 t) => new(0, v11: t);

    public static implicit operator UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T12 t) => new(0, v12: t);

    public static implicit operator UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T13 t) => new(0, v13: t);

    public void Switch(Action<T0> f0, Action<T1> f1, Action<T2> f2, Action<T3> f3, Action<T4> f4, Action<T5> f5, Action<T6> f6, Action<T7> f7, Action<T8> f8, Action<T9> f9,
        Action<T10> f10, Action<T11> f11, Action<T12> f12, Action<T13> f13)
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
            case 8:
                f8(_v8);
                return;
            case 9:
                f9(_v9);
                return;
            case 10:
                f10(_v10);
                return;
            case 11:
                f11(_v11);
                return;
            case 12:
                f12(_v12);
                return;
            case 13:
                f13(_v13);
                return;
            default:
                throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.");
        }
    }

    public TResult Match<TResult>(Func<T0, TResult> f0, Func<T1, TResult> f1, Func<T2, TResult> f2, Func<T3, TResult> f3, Func<T4, TResult> f4, Func<T5, TResult> f5, Func<T6, TResult> f6, Func<T7, TResult> f7, Func<T8, TResult> f8,
        Func<T9, TResult> f9, Func<T10, TResult> f10, Func<T11, TResult> f11, Func<T12, TResult> f12, Func<T13, TResult> f13)
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
            8 => f8(_v8),
            9 => f9(_v9),
            10 => f10(_v10),
            11 => f11(_v11),
            12 => f12(_v12),
            13 => f13(_v13),
            _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
        };
    }

    internal static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> FromNull() => new(0);

    public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> FromT0(T0 input) => input;

    public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> FromT1(T1 input) => input;

    public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> FromT2(T2 input) => input;

    public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> FromT3(T3 input) => input;

    public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> FromT4(T4 input) => input;

    public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> FromT5(T5 input) => input;

    public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> FromT6(T6 input) => input;

    public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> FromT7(T7 input) => input;

    public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> FromT8(T8 input) => input;

    public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> FromT9(T9 input) => input;

    public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> FromT10(T10 input) => input;

    public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> FromT11(T11 input) => input;

    public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> FromT12(T12 input) => input;

    public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> FromT13(T13 input) => input;

    public UnionType<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> MapT0<TResult>(Func<T0, TResult> mapFunc)
    {
        ArgumentNullException.ThrowIfNull(mapFunc);
        return _ix switch
        {
            0 => mapFunc(AsT0()),
            1 => AsT1(),
            2 => AsT2(),
            3 => AsT3(),
            4 => AsT4(),
            5 => AsT5(),
            6 => AsT6(),
            7 => AsT7(),
            8 => AsT8(),
            9 => AsT9(),
            10 => AsT10(),
            11 => AsT11(),
            12 => AsT12(),
            13 => AsT13(),
            _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
        };
    }

    public UnionType<T0, TResult, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> MapT1<TResult>(Func<T1, TResult> mapFunc)
    {
        ArgumentNullException.ThrowIfNull(mapFunc);
        return _ix switch
        {
            0 => AsT0(),
            1 => mapFunc(AsT1()),
            2 => AsT2(),
            3 => AsT3(),
            4 => AsT4(),
            5 => AsT5(),
            6 => AsT6(),
            7 => AsT7(),
            8 => AsT8(),
            9 => AsT9(),
            10 => AsT10(),
            11 => AsT11(),
            12 => AsT12(),
            13 => AsT13(),
            _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
        };
    }

    public UnionType<T0, T1, TResult, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> MapT2<TResult>(Func<T2, TResult> mapFunc)
    {
        ArgumentNullException.ThrowIfNull(mapFunc);
        return _ix switch
        {
            0 => AsT0(),
            1 => AsT1(),
            2 => mapFunc(AsT2()),
            3 => AsT3(),
            4 => AsT4(),
            5 => AsT5(),
            6 => AsT6(),
            7 => AsT7(),
            8 => AsT8(),
            9 => AsT9(),
            10 => AsT10(),
            11 => AsT11(),
            12 => AsT12(),
            13 => AsT13(),
            _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
        };
    }

    public UnionType<T0, T1, T2, TResult, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> MapT3<TResult>(Func<T3, TResult> mapFunc)
    {
        ArgumentNullException.ThrowIfNull(mapFunc);
        return _ix switch
        {
            0 => AsT0(),
            1 => AsT1(),
            2 => AsT2(),
            3 => mapFunc(AsT3()),
            4 => AsT4(),
            5 => AsT5(),
            6 => AsT6(),
            7 => AsT7(),
            8 => AsT8(),
            9 => AsT9(),
            10 => AsT10(),
            11 => AsT11(),
            12 => AsT12(),
            13 => AsT13(),
            _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
        };
    }

    public UnionType<T0, T1, T2, T3, TResult, T5, T6, T7, T8, T9, T10, T11, T12, T13> MapT4<TResult>(Func<T4, TResult> mapFunc)
    {
        ArgumentNullException.ThrowIfNull(mapFunc);
        return _ix switch
        {
            0 => AsT0(),
            1 => AsT1(),
            2 => AsT2(),
            3 => AsT3(),
            4 => mapFunc(AsT4()),
            5 => AsT5(),
            6 => AsT6(),
            7 => AsT7(),
            8 => AsT8(),
            9 => AsT9(),
            10 => AsT10(),
            11 => AsT11(),
            12 => AsT12(),
            13 => AsT13(),
            _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
        };
    }

    public UnionType<T0, T1, T2, T3, T4, TResult, T6, T7, T8, T9, T10, T11, T12, T13> MapT5<TResult>(Func<T5, TResult> mapFunc)
    {
        ArgumentNullException.ThrowIfNull(mapFunc);
        return _ix switch
        {
            0 => AsT0(),
            1 => AsT1(),
            2 => AsT2(),
            3 => AsT3(),
            4 => AsT4(),
            5 => mapFunc(AsT5()),
            6 => AsT6(),
            7 => AsT7(),
            8 => AsT8(),
            9 => AsT9(),
            10 => AsT10(),
            11 => AsT11(),
            12 => AsT12(),
            13 => AsT13(),
            _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
        };
    }

    public UnionType<T0, T1, T2, T3, T4, T5, TResult, T7, T8, T9, T10, T11, T12, T13> MapT6<TResult>(Func<T6, TResult> mapFunc)
    {
        ArgumentNullException.ThrowIfNull(mapFunc);
        return _ix switch
        {
            0 => AsT0(),
            1 => AsT1(),
            2 => AsT2(),
            3 => AsT3(),
            4 => AsT4(),
            5 => AsT5(),
            6 => mapFunc(AsT6()),
            7 => AsT7(),
            8 => AsT8(),
            9 => AsT9(),
            10 => AsT10(),
            11 => AsT11(),
            12 => AsT12(),
            13 => AsT13(),
            _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
        };
    }

    public UnionType<T0, T1, T2, T3, T4, T5, T6, TResult, T8, T9, T10, T11, T12, T13> MapT7<TResult>(Func<T7, TResult> mapFunc)
    {
        ArgumentNullException.ThrowIfNull(mapFunc);
        return _ix switch
        {
            0 => AsT0(),
            1 => AsT1(),
            2 => AsT2(),
            3 => AsT3(),
            4 => AsT4(),
            5 => AsT5(),
            6 => AsT6(),
            7 => mapFunc(AsT7()),
            8 => AsT8(),
            9 => AsT9(),
            10 => AsT10(),
            11 => AsT11(),
            12 => AsT12(),
            13 => AsT13(),
            _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
        };
    }

    public UnionType<T0, T1, T2, T3, T4, T5, T6, T7, TResult, T9, T10, T11, T12, T13> MapT8<TResult>(Func<T8, TResult> mapFunc)
    {
        ArgumentNullException.ThrowIfNull(mapFunc);
        return _ix switch
        {
            0 => AsT0(),
            1 => AsT1(),
            2 => AsT2(),
            3 => AsT3(),
            4 => AsT4(),
            5 => AsT5(),
            6 => AsT6(),
            7 => AsT7(),
            8 => mapFunc(AsT8()),
            9 => AsT9(),
            10 => AsT10(),
            11 => AsT11(),
            12 => AsT12(),
            13 => AsT13(),
            _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
        };
    }

    public UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, TResult, T10, T11, T12, T13> MapT9<TResult>(Func<T9, TResult> mapFunc)
    {
        ArgumentNullException.ThrowIfNull(mapFunc);
        return _ix switch
        {
            0 => AsT0(),
            1 => AsT1(),
            2 => AsT2(),
            3 => AsT3(),
            4 => AsT4(),
            5 => AsT5(),
            6 => AsT6(),
            7 => AsT7(),
            8 => AsT8(),
            9 => mapFunc(AsT9()),
            10 => AsT10(),
            11 => AsT11(),
            12 => AsT12(),
            13 => AsT13(),
            _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
        };
    }

    public UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult, T11, T12, T13> MapT10<TResult>(Func<T10, TResult> mapFunc)
    {
        ArgumentNullException.ThrowIfNull(mapFunc);
        return _ix switch
        {
            0 => AsT0(),
            1 => AsT1(),
            2 => AsT2(),
            3 => AsT3(),
            4 => AsT4(),
            5 => AsT5(),
            6 => AsT6(),
            7 => AsT7(),
            8 => AsT8(),
            9 => AsT9(),
            10 => mapFunc(AsT10()),
            11 => AsT11(),
            12 => AsT12(),
            13 => AsT13(),
            _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
        };
    }

    public UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult, T12, T13> MapT11<TResult>(Func<T11, TResult> mapFunc)
    {
        ArgumentNullException.ThrowIfNull(mapFunc);
        return _ix switch
        {
            0 => AsT0(),
            1 => AsT1(),
            2 => AsT2(),
            3 => AsT3(),
            4 => AsT4(),
            5 => AsT5(),
            6 => AsT6(),
            7 => AsT7(),
            8 => AsT8(),
            9 => AsT9(),
            10 => AsT10(),
            11 => mapFunc(AsT11()),
            12 => AsT12(),
            13 => AsT13(),
            _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
        };
    }

    public UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult, T13> MapT12<TResult>(Func<T12, TResult> mapFunc)
    {
        ArgumentNullException.ThrowIfNull(mapFunc);
        return _ix switch
        {
            0 => AsT0(),
            1 => AsT1(),
            2 => AsT2(),
            3 => AsT3(),
            4 => AsT4(),
            5 => AsT5(),
            6 => AsT6(),
            7 => AsT7(),
            8 => AsT8(),
            9 => AsT9(),
            10 => AsT10(),
            11 => AsT11(),
            12 => mapFunc(AsT12()),
            13 => AsT13(),
            _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
        };
    }

    public UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> MapT13<TResult>(Func<T13, TResult> mapFunc)
    {
        ArgumentNullException.ThrowIfNull(mapFunc);
        return _ix switch
        {
            0 => AsT0(),
            1 => AsT1(),
            2 => AsT2(),
            3 => AsT3(),
            4 => AsT4(),
            5 => AsT5(),
            6 => AsT6(),
            7 => AsT7(),
            8 => AsT8(),
            9 => AsT9(),
            10 => AsT10(),
            11 => AsT11(),
            12 => AsT12(),
            13 => mapFunc(AsT13()),
            _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
        };
    }

    public bool TryPickT0(out T0 value, out UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> remainder)
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
            8 => AsT8(),
            9 => AsT9(),
            10 => AsT10(),
            11 => AsT11(),
            12 => AsT12(),
            13 => AsT13(),
            _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
        };
        return IsT0();
    }

    public bool TryPickT1(out T1 value, out UnionType<T0, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> remainder)
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
            8 => AsT8(),
            9 => AsT9(),
            10 => AsT10(),
            11 => AsT11(),
            12 => AsT12(),
            13 => AsT13(),
            _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
        };
        return IsT1();
    }

    public bool TryPickT2(out T2 value, out UnionType<T0, T1, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> remainder)
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
            8 => AsT8(),
            9 => AsT9(),
            10 => AsT10(),
            11 => AsT11(),
            12 => AsT12(),
            13 => AsT13(),
            _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
        };
        return IsT2();
    }

    public bool TryPickT3(out T3 value, out UnionType<T0, T1, T2, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> remainder)
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
            8 => AsT8(),
            9 => AsT9(),
            10 => AsT10(),
            11 => AsT11(),
            12 => AsT12(),
            13 => AsT13(),
            _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
        };
        return IsT3();
    }

    public bool TryPickT4(out T4 value, out UnionType<T0, T1, T2, T3, T5, T6, T7, T8, T9, T10, T11, T12, T13> remainder)
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
            8 => AsT8(),
            9 => AsT9(),
            10 => AsT10(),
            11 => AsT11(),
            12 => AsT12(),
            13 => AsT13(),
            _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
        };
        return IsT4();
    }

    public bool TryPickT5(out T5 value, out UnionType<T0, T1, T2, T3, T4, T6, T7, T8, T9, T10, T11, T12, T13> remainder)
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
            8 => AsT8(),
            9 => AsT9(),
            10 => AsT10(),
            11 => AsT11(),
            12 => AsT12(),
            13 => AsT13(),
            _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
        };
        return IsT5();
    }

    public bool TryPickT6(out T6 value, out UnionType<T0, T1, T2, T3, T4, T5, T7, T8, T9, T10, T11, T12, T13> remainder)
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
            8 => AsT8(),
            9 => AsT9(),
            10 => AsT10(),
            11 => AsT11(),
            12 => AsT12(),
            13 => AsT13(),
            _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
        };
        return IsT6();
    }

    public bool TryPickT7(out T7 value, out UnionType<T0, T1, T2, T3, T4, T5, T6, T8, T9, T10, T11, T12, T13> remainder)
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
            8 => AsT8(),
            9 => AsT9(),
            10 => AsT10(),
            11 => AsT11(),
            12 => AsT12(),
            13 => AsT13(),
            _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
        };
        return IsT7();
    }

    public bool TryPickT8(out T8 value, out UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T9, T10, T11, T12, T13> remainder)
    {
        value = IsT8() ? AsT8() : default;
        remainder = _ix switch
        {
            0 => AsT0(),
            1 => AsT1(),
            2 => AsT2(),
            3 => AsT3(),
            4 => AsT4(),
            5 => AsT5(),
            6 => AsT6(),
            7 => AsT7(),
            8 => default,
            9 => AsT9(),
            10 => AsT10(),
            11 => AsT11(),
            12 => AsT12(),
            13 => AsT13(),
            _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
        };
        return IsT8();
    }

    public bool TryPickT9(out T9 value, out UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T10, T11, T12, T13> remainder)
    {
        value = IsT9() ? AsT9() : default;
        remainder = _ix switch
        {
            0 => AsT0(),
            1 => AsT1(),
            2 => AsT2(),
            3 => AsT3(),
            4 => AsT4(),
            5 => AsT5(),
            6 => AsT6(),
            7 => AsT7(),
            8 => AsT8(),
            9 => default,
            10 => AsT10(),
            11 => AsT11(),
            12 => AsT12(),
            13 => AsT13(),
            _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
        };
        return IsT9();
    }

    public bool TryPickT10(out T10 value, out UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T11, T12, T13> remainder)
    {
        value = IsT10() ? AsT10() : default;
        remainder = _ix switch
        {
            0 => AsT0(),
            1 => AsT1(),
            2 => AsT2(),
            3 => AsT3(),
            4 => AsT4(),
            5 => AsT5(),
            6 => AsT6(),
            7 => AsT7(),
            8 => AsT8(),
            9 => AsT9(),
            10 => default,
            11 => AsT11(),
            12 => AsT12(),
            13 => AsT13(),
            _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
        };
        return IsT10();
    }

    public bool TryPickT11(out T11 value, out UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T12, T13> remainder)
    {
        value = IsT11() ? AsT11() : default;
        remainder = _ix switch
        {
            0 => AsT0(),
            1 => AsT1(),
            2 => AsT2(),
            3 => AsT3(),
            4 => AsT4(),
            5 => AsT5(),
            6 => AsT6(),
            7 => AsT7(),
            8 => AsT8(),
            9 => AsT9(),
            10 => AsT10(),
            11 => default,
            12 => AsT12(),
            13 => AsT13(),
            _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
        };
        return IsT11();
    }

    public bool TryPickT12(out T12 value, out UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T13> remainder)
    {
        value = IsT12() ? AsT12() : default;
        remainder = _ix switch
        {
            0 => AsT0(),
            1 => AsT1(),
            2 => AsT2(),
            3 => AsT3(),
            4 => AsT4(),
            5 => AsT5(),
            6 => AsT6(),
            7 => AsT7(),
            8 => AsT8(),
            9 => AsT9(),
            10 => AsT10(),
            11 => AsT11(),
            12 => default,
            13 => AsT13(),
            _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
        };
        return IsT12();
    }

    public bool TryPickT13(out T13 value, out UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> remainder)
    {
        value = IsT13() ? AsT13() : default;
        remainder = _ix switch
        {
            0 => AsT0(),
            1 => AsT1(),
            2 => AsT2(),
            3 => AsT3(),
            4 => AsT4(),
            5 => AsT5(),
            6 => AsT6(),
            7 => AsT7(),
            8 => AsT8(),
            9 => AsT9(),
            10 => AsT10(),
            11 => AsT11(),
            12 => AsT12(),
            13 => default,
            _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
        };
        return IsT13();
    }

    public Maybe<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> AsOptionals()
    {
        return Optional.From(_v0, _v1, _v2, _v3, _v4, _v5, _v6, _v7, _v8, _v9, _v10, _v11, _v12, _v13);
    }

    bool Equals(UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> other)
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
                   8 => Equals(_v8, other._v8),
                   9 => Equals(_v9, other._v9),
                   10 => Equals(_v10, other._v10),
                   11 => Equals(_v11, other._v11),
                   12 => Equals(_v12, other._v12),
                   13 => Equals(_v13, other._v13),
                   _ => false
               };
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj))
            return false;
        return obj is UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> o && Equals(o);
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
            8 => FormatHelper.FormatValue(_v8),
            9 => FormatHelper.FormatValue(_v9),
            10 => FormatHelper.FormatValue(_v10),
            11 => FormatHelper.FormatValue(_v11),
            12 => FormatHelper.FormatValue(_v12),
            13 => FormatHelper.FormatValue(_v13),
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
                6 => _v6?.GetHashCode(),
                7 => _v7?.GetHashCode(),
                8 => _v8?.GetHashCode(),
                9 => _v9?.GetHashCode(),
                10 => _v10?.GetHashCode(),
                11 => _v11?.GetHashCode(),
                12 => _v12?.GetHashCode(),
                13 => _v13?.GetHashCode(),
                _ => 0
            } ?? 0;
            return (hashCode * 397) ^ _ix;
        }
    }
}