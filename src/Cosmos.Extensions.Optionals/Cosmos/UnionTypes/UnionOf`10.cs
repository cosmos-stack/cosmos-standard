using System;

namespace Cosmos.UnionTypes
{
    public class UnionOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> : IUnionType, IUnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>
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
        readonly int _ix;

        protected UnionOf(UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> input)
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
                case 8:
                    _v8 = input.AsT8();
                    break;
                case 9:
                    _v9 = input.AsT9();
                    break;
                case 10:
                    _v10 = input.AsT10();
                    break;
                default:
                    throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionOf codegen.");
            }
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
                    _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionOf codegen.")
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

        public T0 AsT0()
        {
            return _ix == 0
                ? _v0
                : throw new InvalidOperationException($"Cannot return as T0 as result is T{_ix}");
        }

        public T1 AsT1()
        {
            return _ix == 1
                ? _v1
                : throw new InvalidOperationException($"Cannot return as T1 as result is T{_ix}");
        }

        public T2 AsT2()
        {
            return _ix == 2
                ? _v2
                : throw new InvalidOperationException($"Cannot return as T2 as result is T{_ix}");
        }

        public T3 AsT3()
        {
            return _ix == 3
                ? _v3
                : throw new InvalidOperationException($"Cannot return as T3 as result is T{_ix}");
        }

        public T4 AsT4()
        {
            return _ix == 4
                ? _v4
                : throw new InvalidOperationException($"Cannot return as T4 as result is T{_ix}");
        }

        public T5 AsT5()
        {
            return _ix == 5
                ? _v5
                : throw new InvalidOperationException($"Cannot return as T5 as result is T{_ix}");
        }

        public T6 AsT6()
        {
            return _ix == 6
                ? _v6
                : throw new InvalidOperationException($"Cannot return as T6 as result is T{_ix}");
        }

        public T7 AsT7()
        {
            return _ix == 7
                ? _v7
                : throw new InvalidOperationException($"Cannot return as T7 as result is T{_ix}");
        }

        public T8 AsT8()
        {
            return _ix == 8
                ? _v8
                : throw new InvalidOperationException($"Cannot return as T8 as result is T{_ix}");
        }

        public T9 AsT9()
        {
            return _ix == 9
                ? _v9
                : throw new InvalidOperationException($"Cannot return as T9 as result is T{_ix}");
        }

        public T10 AsT10()
        {
            return _ix == 10
                ? _v10
                : throw new InvalidOperationException($"Cannot return as T10 as result is T{_ix}");
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

#if NETFRAMEWORK
        public int Count() => 11;
#endif

        public void Switch(Action<T0> f0, Action<T1> f1, Action<T2> f2, Action<T3> f3, Action<T4> f4, Action<T5> f5, Action<T6> f6, Action<T7> f7, Action<T8> f8, Action<T9> f9,
            Action<T10> f10)
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

            throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionOf codegen.");
        }

        public TResult Match<TResult>(Func<T0, TResult> f0, Func<T1, TResult> f1, Func<T2, TResult> f2, Func<T3, TResult> f3, Func<T4, TResult> f4, Func<T5, TResult> f5, Func<T6, TResult> f6, Func<T7, TResult> f7, Func<T8, TResult> f8,
            Func<T9, TResult> f9, Func<T10, TResult> f10)
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

            throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionOf codegen.");
        }

        public bool TryPickT0(out T0 value, out UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> remainder)
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
                _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionOf codegen.")
            };
            return IsT0();
        }

        public bool TryPickT1(out T1 value, out UnionType<T0, T2, T3, T4, T5, T6, T7, T8, T9, T10> remainder)
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
                _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionOf codegen.")
            };
            return IsT1();
        }

        public bool TryPickT2(out T2 value, out UnionType<T0, T1, T3, T4, T5, T6, T7, T8, T9, T10> remainder)
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
                _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionOf codegen.")
            };
            return IsT2();
        }

        public bool TryPickT3(out T3 value, out UnionType<T0, T1, T2, T4, T5, T6, T7, T8, T9, T10> remainder)
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
                _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionOf codegen.")
            };
            return IsT3();
        }

        public bool TryPickT4(out T4 value, out UnionType<T0, T1, T2, T3, T5, T6, T7, T8, T9, T10> remainder)
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
                _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionOf codegen.")
            };
            return IsT4();
        }

        public bool TryPickT5(out T5 value, out UnionType<T0, T1, T2, T3, T4, T6, T7, T8, T9, T10> remainder)
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
                _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionOf codegen.")
            };
            return IsT5();
        }

        public bool TryPickT6(out T6 value, out UnionType<T0, T1, T2, T3, T4, T5, T7, T8, T9, T10> remainder)
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
                _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionOf codegen.")
            };
            return IsT6();
        }

        public bool TryPickT7(out T7 value, out UnionType<T0, T1, T2, T3, T4, T5, T6, T8, T9, T10> remainder)
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
                _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionOf codegen.")
            };
            return IsT7();
        }

        public bool TryPickT8(out T8 value, out UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T9, T10> remainder)
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
                _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionOf codegen.")
            };
            return IsT8();
        }

        public bool TryPickT9(out T9 value, out UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T10> remainder)
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
                _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionOf codegen.")
            };
            return IsT9();
        }

        public bool TryPickT10(out T10 value, out UnionType<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> remainder)
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
                _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionOf codegen.")
            };
            return IsT10();
        }

        bool Equals(UnionOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> other)
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
                       _ => false
                   };
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            return obj is UnionOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> o && Equals(o);
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
                    8 => _v8?.GetHashCode(),
                    9 => _v9?.GetHashCode(),
                    10 => _v10?.GetHashCode(),
                    _ => 0
                } ?? 0;
                return (hashCode * 397) ^ _ix;
            }
        }
    }
}