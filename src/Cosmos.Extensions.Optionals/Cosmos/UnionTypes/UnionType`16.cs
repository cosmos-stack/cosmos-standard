using System;
using Cosmos.Optionals;

namespace Cosmos.UnionTypes
{
    public struct UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> : IUnionType, IUnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>
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
        readonly T14 _v14;
        readonly T15 _v15;
        readonly T16 _v16;
        readonly int _ix;

        UnionType(int ix, T0 v0 = default, T1 v1 = default, T2 v2 = default, T3 v3 = default, T4 v4 = default, T5 v5 = default, T6 v6 = default, T7 v7 = default, T8 v8 = default, T9 v9 = default, T10 v10 = default,
            T11 v11 = default, T12 v12 = default, T13 v13 = default, T14 v14 = default, T15 v15 = default,  T16 v16 = default)
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
            _v14 = v14;
            _v15 = v15;
            _v16 = v16;
        }

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
                    14 => _v14,
                    15 => _v15,
                    16 => _v16,
                    _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
                };
            }
        }

        public int Index => _ix;

        public bool IsT0() => _ix == 0;

        public bool IsT1() => _ix == 1;

        public bool IsT2() => _ix == 2;

        public bool IsT3() => _ix == 3;

        public bool IsT4() => _ix == 4;

        public bool IsT5() => _ix == 5;

        public bool IsT6() => _ix == 6;

        public bool IsT7() => _ix == 7;

        public bool IsT8() => _ix == 8;

        public bool IsT9() => _ix == 9;

        public bool IsT10() => _ix == 10;

        public bool IsT11() => _ix == 11;

        public bool IsT12() => _ix == 12;

        public bool IsT13() => _ix == 13;

        public bool IsT14() => _ix == 14;

        public bool IsT15() => _ix == 15;

        public bool IsT16() => _ix == 16;

        public T0 AsT0()
        {
            if (_ix == 0)
                return _v0;
            throw new InvalidOperationException($"Cannot return as T0 as result is T{_ix}");
        }

        public T1 AsT1()
        {
            if (_ix == 1)
                return _v1;
            throw new InvalidOperationException($"Cannot return as T1 as result is T{_ix}");
        }

        public T2 AsT2()
        {
            if (_ix == 2)
                return _v2;
            throw new InvalidOperationException($"Cannot return as T2 as result is T{_ix}");
        }

        public T3 AsT3()
        {
            if (_ix == 3)
                return _v3;
            throw new InvalidOperationException($"Cannot return as T3 as result is T{_ix}");
        }

        public T4 AsT4()
        {
            if (_ix == 4)
                return _v4;
            throw new InvalidOperationException($"Cannot return as T4 as result is T{_ix}");
        }

        public T5 AsT5()
        {
            if (_ix == 5)
                return _v5;
            throw new InvalidOperationException($"Cannot return as T5 as result is T{_ix}");
        }

        public T6 AsT6()
        {
            if (_ix == 6)
                return _v6;
            throw new InvalidOperationException($"Cannot return as T6 as result is T{_ix}");
        }

        public T7 AsT7()
        {
            if (_ix == 7)
                return _v7;
            throw new InvalidOperationException($"Cannot return as T7 as result is T{_ix}");
        }

        public T8 AsT8()
        {
            if (_ix == 8)
                return _v8;
            throw new InvalidOperationException($"Cannot return as T8 as result is T{_ix}");
        }

        public T9 AsT9()
        {
            if (_ix == 9)
                return _v9;
            throw new InvalidOperationException($"Cannot return as T9 as result is T{_ix}");
        }

        public T10 AsT10()
        {
            if (_ix == 10)
                return _v10;
            throw new InvalidOperationException($"Cannot return as T10 as result is T{_ix}");
        }

        public T11 AsT11()
        {
            if (_ix == 11)
                return _v11;
            throw new InvalidOperationException($"Cannot return as T11 as result is T{_ix}");
        }

        public T12 AsT12()
        {
            if (_ix == 12)
                return _v12;
            throw new InvalidOperationException($"Cannot return as T12 as result is T{_ix}");
        }

        public T13 AsT13()
        {
            if (_ix == 13)
                return _v13;
            throw new InvalidOperationException($"Cannot return as T13 as result is T{_ix}");
        }

        public T14 AsT14()
        {
            if (_ix == 14)
                return _v14;
            throw new InvalidOperationException($"Cannot return as T14 as result is T{_ix}");
        }

        public T15 AsT15()
        {
            if (_ix == 15)
                return _v15;
            throw new InvalidOperationException($"Cannot return as T15 as result is T{_ix}");
        }

        public T16 AsT16()
        {
            if (_ix == 16)
                return _v16;
            throw new InvalidOperationException($"Cannot return as T16 as result is T{_ix}");
        }

        public Type TypeOfT0 => typeof(T0);

        public Type TypeOfT1 => typeof(T1);

        public Type TypeOfT2 => typeof(T2);

        public Type TypeOfT3 => typeof(T3);

        public Type TypeOfT4 => typeof(T4);

        public Type TypeOfT5 => typeof(T5);

        public Type TypeOfT6 => typeof(T6);

        public Type TypeOfT7 => typeof(T7);

        public Type TypeOfT8 => typeof(T8);

        public Type TypeOfT9 => typeof(T9);

        public Type TypeOfT10 => typeof(T10);

        public Type TypeOfT11 => typeof(T11);

        public Type TypeOfT12 => typeof(T12);

        public Type TypeOfT13 => typeof(T13);

        public Type TypeOfT14 => typeof(T14);

        public Type TypeOfT15 => typeof(T15);

        public Type TypeOfT16 => typeof(T16);

#if NETFRAMEWORK
        public int Count() => 17;
#endif

        public static implicit operator UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T0 t) => new(0, v0: t);

        public static implicit operator UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T1 t) => new(0, v1: t);

        public static implicit operator UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T2 t) => new(0, v2: t);

        public static implicit operator UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T3 t) => new(0, v3: t);

        public static implicit operator UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T4 t) => new(0, v4: t);

        public static implicit operator UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T5 t) => new(0, v5: t);

        public static implicit operator UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T6 t) => new(0, v6: t);

        public static implicit operator UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T7 t) => new(0, v7: t);

        public static implicit operator UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T8 t) => new(0, v8: t);

        public static implicit operator UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T9 t) => new(0, v9: t);

        public static implicit operator UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T10 t) => new(0, v10: t);

        public static implicit operator UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T11 t) => new(0, v11: t);

        public static implicit operator UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T12 t) => new(0, v12: t);

        public static implicit operator UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T13 t) => new(0, v13: t);

        public static implicit operator UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T14 t) => new(0, v14: t);

        public static implicit operator UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T15 t) => new(0, v15: t);

        public static implicit operator UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T16 t) => new(0, v16: t);

        public void Switch(Action<T0> f0, Action<T1> f1, Action<T2> f2, Action<T3> f3, Action<T4> f4, Action<T5> f5, Action<T6> f6, Action<T7> f7, Action<T8> f8, Action<T9> f9,
            Action<T10> f10, Action<T11> f11, Action<T12> f12, Action<T13> f13, Action<T14> f14, Action<T15> f15, Action<T16> f16)
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

            if (_ix is 6 && f6 is not null)
            {
                f6(_v6);
                return;
            }

            if (_ix is 7 && f7 is not null)
            {
                f7(_v7);
                return;
            }

            if (_ix is 8 && f8 is not null)
            {
                f8(_v8);
                return;
            }

            if (_ix is 9 && f9 is not null)
            {
                f9(_v9);
                return;
            }

            if (_ix is 10 && f10 is not null)
            {
                f10(_v10);
                return;
            }

            if (_ix is 11 && f11 is not null)
            {
                f11(_v11);
                return;
            }

            if (_ix is 12 && f12 is not null)
            {
                f12(_v12);
                return;
            }

            if (_ix is 13 && f13 is not null)
            {
                f13(_v13);
                return;
            }

            if (_ix is 14 && f14 is not null)
            {
                f14(_v14);
                return;
            }

            if (_ix is 15 && f15 is not null)
            {
                f15(_v15);
                return;
            }

            if (_ix is 16 && f16 is not null)
            {
                f16(_v16);
                return;
            }

            throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.");
        }

        public TResult Match<TResult>(Func<T0, TResult> f0, Func<T1, TResult> f1, Func<T2, TResult> f2, Func<T3, TResult> f3, Func<T4, TResult> f4, Func<T5, TResult> f5, Func<T6, TResult> f6, Func<T7, TResult> f7, Func<T8, TResult> f8,
            Func<T9, TResult> f9, Func<T10, TResult> f10, Func<T11, TResult> f11, Func<T12, TResult> f12, Func<T13, TResult> f13, Func<T14, TResult> f14, Func<T15, TResult> f15, Func<T16, TResult> f16)
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

            if (_ix is 6 && f6 is not null)
            {
                return f6(_v6);
            }

            if (_ix is 7 && f7 is not null)
            {
                return f7(_v7);
            }

            if (_ix is 8 && f8 is not null)
            {
                return f8(_v8);
            }

            if (_ix is 9 && f9 is not null)
            {
                return f9(_v9);
            }

            if (_ix is 10 && f10 is not null)
            {
                return f10(_v10);
            }

            if (_ix is 11 && f11 is not null)
            {
                return f11(_v11);
            }

            if (_ix is 12 && f12 is not null)
            {
                return f12(_v12);
            }

            if (_ix is 13 && f13 is not null)
            {
                return f13(_v13);
            }

            if (_ix is 14 && f14 is not null)
            {
                return f14(_v14);
            }

            if (_ix is 15 && f15 is not null)
            {
                return f15(_v15);
            }

            if (_ix is 16 && f16 is not null)
            {
                return f16(_v16);
            }

            throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.");
        }

        internal static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> FromNull() => new(0);

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> FromT0(T0 input) => input;

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> FromT1(T1 input) => input;

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> FromT2(T2 input) => input;

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> FromT3(T3 input) => input;

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> FromT4(T4 input) => input;

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> FromT5(T5 input) => input;

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> FromT6(T6 input) => input;

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> FromT7(T7 input) => input;

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> FromT8(T8 input) => input;

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> FromT9(T9 input) => input;

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> FromT10(T10 input) => input;

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> FromT11(T11 input) => input;

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> FromT12(T12 input) => input;

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> FromT13(T13 input) => input;

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> FromT14(T14 input) => input;

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> FromT15(T15 input) => input;

        public static UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> FromT16(T16 input) => input;

        public UnionType<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> MapT0<TResult>(Func<T0, TResult> mapFunc)
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
                6 => AsT6(),
                7 => AsT7(),
                8 => AsT8(),
                9 => AsT9(),
                10 => AsT10(),
                11 => AsT11(),
                12 => AsT12(),
                13 => AsT13(),
                14 => AsT14(),
                15 => AsT15(),
                16 => AsT16(),
                _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
            };
        }

        public UnionType<T0, TResult, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> MapT1<TResult>(Func<T1, TResult> mapFunc)
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
                6 => AsT6(),
                7 => AsT7(),
                8 => AsT8(),
                9 => AsT9(),
                10 => AsT10(),
                11 => AsT11(),
                12 => AsT12(),
                13 => AsT13(),
                14 => AsT14(),
                15 => AsT15(),
                16 => AsT16(),
                _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
            };
        }

        public UnionType<T0, T1, TResult, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> MapT2<TResult>(Func<T2, TResult> mapFunc)
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
                6 => AsT6(),
                7 => AsT7(),
                8 => AsT8(),
                9 => AsT9(),
                10 => AsT10(),
                11 => AsT11(),
                12 => AsT12(),
                13 => AsT13(),
                14 => AsT14(),
                15 => AsT15(),
                16 => AsT16(),
                _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
            };
        }

        public UnionType<T0, T1, T2, TResult, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> MapT3<TResult>(Func<T3, TResult> mapFunc)
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
                6 => AsT6(),
                7 => AsT7(),
                8 => AsT8(),
                9 => AsT9(),
                10 => AsT10(),
                11 => AsT11(),
                12 => AsT12(),
                13 => AsT13(),
                14 => AsT14(),
                15 => AsT15(),
                16 => AsT16(),
                _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
            };
        }

        public UnionType<T0, T1, T2, T3, TResult, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> MapT4<TResult>(Func<T4, TResult> mapFunc)
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
                6 => AsT6(),
                7 => AsT7(),
                8 => AsT8(),
                9 => AsT9(),
                10 => AsT10(),
                11 => AsT11(),
                12 => AsT12(),
                13 => AsT13(),
                14 => AsT14(),
                15 => AsT15(),
                16 => AsT16(),
                _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
            };
        }

        public UnionType<T0, T1, T2, T3, T4, TResult, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> MapT5<TResult>(Func<T5, TResult> mapFunc)
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
                6 => AsT6(),
                7 => AsT7(),
                8 => AsT8(),
                9 => AsT9(),
                10 => AsT10(),
                11 => AsT11(),
                12 => AsT12(),
                13 => AsT13(),
                14 => AsT14(),
                15 => AsT15(),
                16 => AsT16(),
                _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
            };
        }

        public UnionType<T0, T1, T2, T3, T4, T5, TResult, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> MapT6<TResult>(Func<T6, TResult> mapFunc)
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
                5 => AsT5(),
                6 => mapFunc(AsT6()),
                7 => AsT7(),
                8 => AsT8(),
                9 => AsT9(),
                10 => AsT10(),
                11 => AsT11(),
                12 => AsT12(),
                13 => AsT13(),
                14 => AsT14(),
                15 => AsT15(),
                16 => AsT16(),
                _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
            };
        }

        public UnionType<T0, T1, T2, T3, T4, T5, T6, TResult, T8, T9, T10, T11, T12, T13, T14, T15, T16> MapT7<TResult>(Func<T7, TResult> mapFunc)
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
                5 => AsT5(),
                6 => AsT6(),
                7 => mapFunc(AsT7()),
                8 => AsT8(),
                9 => AsT9(),
                10 => AsT10(),
                11 => AsT11(),
                12 => AsT12(),
                13 => AsT13(),
                14 => AsT14(),
                15 => AsT15(),
                16 => AsT16(),
                _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
            };
        }

        public UnionType<T0, T1, T2, T3, T4, T5, T6, T7, TResult, T9, T10, T11, T12, T13, T14, T15, T16> MapT8<TResult>(Func<T8, TResult> mapFunc)
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
                5 => AsT5(),
                6 => AsT6(),
                7 => AsT7(),
                8 => mapFunc(AsT8()),
                9 => AsT9(),
                10 => AsT10(),
                11 => AsT11(),
                12 => AsT12(),
                13 => AsT13(),
                14 => AsT14(),
                15 => AsT15(),
                16 => AsT16(),
                _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
            };
        }

        public UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, TResult, T10, T11, T12, T13, T14, T15, T16> MapT9<TResult>(Func<T9, TResult> mapFunc)
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
                5 => AsT5(),
                6 => AsT6(),
                7 => AsT7(),
                8 => AsT8(),
                9 => mapFunc(AsT9()),
                10 => AsT10(),
                11 => AsT11(),
                12 => AsT12(),
                13 => AsT13(),
                14 => AsT14(),
                15 => AsT15(),
                16 => AsT16(),
                _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
            };
        }

        public UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult, T11, T12, T13, T14, T15, T16> MapT10<TResult>(Func<T10, TResult> mapFunc)
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
                5 => AsT5(),
                6 => AsT6(),
                7 => AsT7(),
                8 => AsT8(),
                9 => AsT9(),
                10 => mapFunc(AsT10()),
                11 => AsT11(),
                12 => AsT12(),
                13 => AsT13(),
                14 => AsT14(),
                15 => AsT15(),
                16 => AsT16(),
                _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
            };
        }

        public UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult, T12, T13, T14, T15, T16> MapT11<TResult>(Func<T11, TResult> mapFunc)
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
                5 => AsT5(),
                6 => AsT6(),
                7 => AsT7(),
                8 => AsT8(),
                9 => AsT9(),
                10 => AsT10(),
                11 => mapFunc(AsT11()),
                12 => AsT12(),
                13 => AsT13(),
                14 => AsT14(),
                15 => AsT15(),
                16 => AsT16(),
                _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
            };
        }

        public UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult, T13, T14, T15, T16> MapT12<TResult>(Func<T12, TResult> mapFunc)
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
                5 => AsT5(),
                6 => AsT6(),
                7 => AsT7(),
                8 => AsT8(),
                9 => AsT9(),
                10 => AsT10(),
                11 => AsT11(),
                12 => mapFunc(AsT12()),
                13 => AsT13(),
                14 => AsT14(),
                15 => AsT15(),
                16 => AsT16(),
                _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
            };
        }

        public UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult, T14, T15, T16> MapT13<TResult>(Func<T13, TResult> mapFunc)
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
                5 => AsT5(),
                6 => AsT6(),
                7 => AsT7(),
                8 => AsT8(),
                9 => AsT9(),
                10 => AsT10(),
                11 => AsT11(),
                12 => AsT12(),
                13 => mapFunc(AsT13()),
                14 => AsT14(),
                15 => AsT15(),
                16 => AsT16(),
                _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
            };
        }

        public UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult, T15, T16> MapT14<TResult>(Func<T14, TResult> mapFunc)
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
                5 => AsT5(),
                6 => AsT6(),
                7 => AsT7(),
                8 => AsT8(),
                9 => AsT9(),
                10 => AsT10(),
                11 => AsT11(),
                12 => AsT12(),
                13 => AsT13(),
                14 => mapFunc(AsT14()),
                15 => AsT15(),
                16 => AsT16(),
                _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
            };
        }

        public UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult, T16> MapT15<TResult>(Func<T15, TResult> mapFunc)
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
                5 => AsT5(),
                6 => AsT6(),
                7 => AsT7(),
                8 => AsT8(),
                9 => AsT9(),
                10 => AsT10(),
                11 => AsT11(),
                12 => AsT12(),
                13 => AsT13(),
                14 => AsT14(),
                15 => mapFunc(AsT15()),
                16 => AsT16(),
                _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
            };
        }
        
        public UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> MapT16<TResult>(Func<T16, TResult> mapFunc)
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
                5 => AsT5(),
                6 => AsT6(),
                7 => AsT7(),
                8 => AsT8(),
                9 => AsT9(),
                10 => AsT10(),
                11 => AsT11(),
                12 => AsT12(),
                13 => AsT13(),
                14 => AsT14(),
                15 => AsT15(),
                16 => mapFunc(AsT16()),
                _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
            };
        }

        public bool TryPickT0(out T0 value, out UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> remainder)
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
                14 => AsT14(),
                15 => AsT15(),
                16 => AsT16(),
                _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
            };
            return IsT0();
        }

        public bool TryPickT1(out T1 value, out UnionType<T0, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> remainder)
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
                14 => AsT14(),
                15 => AsT15(),
                16 => AsT16(),
                _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
            };
            return IsT1();
        }

        public bool TryPickT2(out T2 value, out UnionType<T0, T1, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> remainder)
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
                14 => AsT14(),
                15 => AsT15(),
                16 => AsT16(),
                _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
            };
            return IsT2();
        }

        public bool TryPickT3(out T3 value, out UnionType<T0, T1, T2, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> remainder)
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
                14 => AsT14(),
                15 => AsT15(),
                16 => AsT16(),
                _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
            };
            return IsT3();
        }

        public bool TryPickT4(out T4 value, out UnionType<T0, T1, T2, T3, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> remainder)
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
                14 => AsT14(),
                15 => AsT15(),
                16 => AsT16(),
                _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
            };
            return IsT4();
        }

        public bool TryPickT5(out T5 value, out UnionType<T0, T1, T2, T3, T4, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> remainder)
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
                14 => AsT14(),
                15 => AsT15(),
                16 => AsT16(),
                _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
            };
            return IsT5();
        }

        public bool TryPickT6(out T6 value, out UnionType<T0, T1, T2, T3, T4, T5, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> remainder)
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
                14 => AsT14(),
                15 => AsT15(),
                16 => AsT16(),
                _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
            };
            return IsT6();
        }

        public bool TryPickT7(out T7 value, out UnionType<T0, T1, T2, T3, T4, T5, T6, T8, T9, T10, T11, T12, T13, T14, T15, T16> remainder)
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
                14 => AsT14(),
                15 => AsT15(),
                16 => AsT16(),
                _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
            };
            return IsT7();
        }

        public bool TryPickT8(out T8 value, out UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T9, T10, T11, T12, T13, T14, T15, T16> remainder)
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
                14 => AsT14(),
                15 => AsT15(),
                16 => AsT16(),
                _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
            };
            return IsT8();
        }

        public bool TryPickT9(out T9 value, out UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T10, T11, T12, T13, T14, T15, T16> remainder)
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
                14 => AsT14(),
                15 => AsT15(),
                16 => AsT16(),
                _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
            };
            return IsT9();
        }

        public bool TryPickT10(out T10 value, out UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T11, T12, T13, T14, T15, T16> remainder)
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
                14 => AsT14(),
                15 => AsT15(),
                16 => AsT16(),
                _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
            };
            return IsT10();
        }

        public bool TryPickT11(out T11 value, out UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T12, T13, T14, T15, T16> remainder)
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
                14 => AsT14(),
                15 => AsT15(),
                16 => AsT16(),
                _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
            };
            return IsT11();
        }

        public bool TryPickT12(out T12 value, out UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T13, T14, T15, T16> remainder)
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
                14 => AsT14(),
                15 => AsT15(),
                16 => AsT16(),
                _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
            };
            return IsT12();
        }

        public bool TryPickT13(out T13 value, out UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T14, T15, T16> remainder)
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
                14 => AsT14(),
                15 => AsT15(),
                16 => AsT16(),
                _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
            };
            return IsT13();
        }
        
        public bool TryPickT14(out T14 value, out UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T15, T16> remainder)
        {
            value = IsT14() ? AsT14() : default;
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
                13 => AsT13(),
                14 => default,
                15 => AsT15(),
                16 => AsT16(),
                _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
            };
            return IsT14();
        }
        
        public bool TryPickT15(out T15 value, out UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T16> remainder)
        {
            value = IsT15() ? AsT15() : default;
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
                13 => AsT13(),
                14 => AsT14(),
                15 => default,
                16 => AsT16(),
                _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
            };
            return IsT15();
        }
        
        public bool TryPickT16(out T16 value, out UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> remainder)
        {
            value = IsT16() ? AsT16() : default;
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
                13 => AsT13(),
                14 => AsT14(),
                15 => AsT15(),
                16 => default,
                _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionType codegen.")
            };
            return IsT16();
        }

        public Maybe<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> AsOptionals()
        {
            return Optional.From(_v0, _v1, _v2, _v3, _v4, _v5, _v6, _v7, _v8, _v9, _v10, _v11, _v12, _v13, _v14, _v15, _v16);
        }

        bool Equals(UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> other)
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
                       14 => Equals(_v14, other._v14),
                       15 => Equals(_v15, other._v15),
                       16 => Equals(_v16, other._v16),
                       _ => false
                   };
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            return obj is UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> o && Equals(o);
        }

        public override string ToString()
        {
            return _ix switch
            {
                0 => Internals.FormatHelper.FormatValue(_v0),
                1 => Internals.FormatHelper.FormatValue(_v1),
                2 => Internals.FormatHelper.FormatValue(_v2),
                3 => Internals.FormatHelper.FormatValue(_v3),
                4 => Internals.FormatHelper.FormatValue(_v4),
                5 => Internals.FormatHelper.FormatValue(_v5),
                6 => Internals.FormatHelper.FormatValue(_v6),
                7 => Internals.FormatHelper.FormatValue(_v7),
                8 => Internals.FormatHelper.FormatValue(_v8),
                9 => Internals.FormatHelper.FormatValue(_v9),
                10 => Internals.FormatHelper.FormatValue(_v10),
                11 => Internals.FormatHelper.FormatValue(_v11),
                12 => Internals.FormatHelper.FormatValue(_v12),
                13 => Internals.FormatHelper.FormatValue(_v13),
                14 => Internals.FormatHelper.FormatValue(_v14),
                15 => Internals.FormatHelper.FormatValue(_v15),
                16 => Internals.FormatHelper.FormatValue(_v16),
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
                    14 => _v14?.GetHashCode(),
                    15 => _v15?.GetHashCode(),
                    16 => _v16?.GetHashCode(),
                    _ => 0
                } ?? 0;
                return (hashCode * 397) ^ _ix;
            }
        }
    }
}