using System;
using CosmosStack.UnionTypes.Internals;
// ReSharper disable RedundantExtendsListEntry

namespace CosmosStack.UnionTypes
{
    /// <summary>
    /// Union Of <br />
    /// 联合类型
    /// </summary>
    /// <typeparam name="T0"></typeparam>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    public class UnionOf<T0, T1, T2> : IUnionType, IUnionType<T0, T1, T2>
    {
        readonly T0 _v0;
        readonly T1 _v1;
        readonly T2 _v2;
        readonly int _ix;

        protected UnionOf(UnionType<T0, T1, T2> input)
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
        public Type TypeOfT0 => typeof(T0);

        /// <inheritdoc />
        public Type TypeOfT1 => typeof(T1);

        /// <inheritdoc />
        public Type TypeOfT2 => typeof(T2);

#if NETFRAMEWORK
        public int Count() => 3;
#endif

        public void Switch(Action<T0> f0, Action<T1> f1, Action<T2> f2)
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

            throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionOf codegen.");
        }

        public TResult Match<TResult>(Func<T0, TResult> f0, Func<T1, TResult> f1, Func<T2, TResult> f2)
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
        public bool TryPickT0(out T0 value, out UnionType<T1, T2> remainder)
        {
            value = IsT0() ? AsT0() : default;
            remainder = _ix switch
            {
                0 => default,
                1 => AsT1(),
                2 => AsT2(),
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
        public bool TryPickT1(out T1 value, out UnionType<T0, T2> remainder)
        {
            value = IsT1() ? AsT1() : default;
            remainder = _ix switch
            {
                0 => AsT0(),
                1 => default,
                2 => AsT2(),
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
        public bool TryPickT2(out T2 value, out UnionType<T0, T1> remainder)
        {
            value = IsT2() ? AsT2() : default;
            remainder = _ix switch
            {
                0 => AsT0(),
                1 => AsT1(),
                2 => default,
                _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionOf codegen.")
            };
            return IsT2();
        }

        bool Equals(UnionOf<T0, T1, T2> other)
        {
            return _ix == other._ix
                && _ix switch
                   {
                       0 => Equals(_v0, other._v0),
                       1 => Equals(_v1, other._v1),
                       2 => Equals(_v2, other._v2),
                       _ => false
                   };
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            return obj is UnionOf<T0, T1, T2> o && Equals(o);
        }

        public override string ToString()
        {
            return _ix switch
            {
                0 => FormatHelper.FormatValue(_v0),
                1 => FormatHelper.FormatValue(_v1),
                2 => FormatHelper.FormatValue(_v2),
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
                    _ => 0
                } ?? 0;
                return (hashCode * 397) ^ _ix;
            }
        }
    }
}