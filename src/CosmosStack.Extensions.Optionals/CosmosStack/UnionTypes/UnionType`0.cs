using System;
using CosmosStack.Optionals;
using CosmosStack.UnionTypes.Internals;
// ReSharper disable RedundantExtendsListEntry

namespace CosmosStack.UnionTypes
{
    public struct UnionType<T0> : IUnionType, IUnionType<T0>
    {
        readonly T0 _v0;
        readonly int _ix;

        UnionType(int ix, T0 v0 = default)
        {
            _ix = ix;
            _v0 = v0;
        }

        /// <inheritdoc />
        public object Value
        {
            get
            {
                return _ix switch
                {
                    0 => _v0,
                    _ => throw new InvalidOperationException("No valid index in such UnionType instance.")
                };
            }
        }

        /// <inheritdoc />
        public int Index => _ix;

        /// <inheritdoc />
        public bool IsT0() => _ix == 0;

        /// <inheritdoc />
        public T0 AsT0()
        {
            if (_ix == 0)
                return _v0;
            throw new InvalidOperationException($"Cannot return as T0 as result is T{_ix}");
        }

        /// <inheritdoc />
        public Type TypeOfT0 => typeof(T0);

#if NETFRAMEWORK
        public int Count() => 1;
#endif

        public static implicit operator UnionType<T0>(T0 t) => new(0, v0: t);

        public void Switch(Action<T0> f0)
        {
            if (_ix is 0 && f0 is not null)
            {
                f0(_v0);
                return;
            }

            throw new InvalidOperationException("No valid index in such UnionType instance.");
        }

        public TResult Match<TResult>(Func<T0, TResult> f0)
        {
            if (_ix is 0 && f0 is not null)
            {
                return f0(_v0);
            }

            throw new InvalidOperationException("No valid index in such UnionType instance.");
        }
        
        internal static UnionType<T0> FromNull() => new(0);

        public static UnionType<T0> FromT0(T0 input) => input;

        public UnionType<TResult> MapT0<TResult>(Func<T0, TResult> mapFunc)
        {
            if (mapFunc is null)
                throw new ArgumentNullException(nameof(mapFunc));
            return _ix switch
            {
                0 => mapFunc(AsT0()),
                _ => throw new InvalidOperationException()
            };
        }

        public Maybe<T0> AsOptionals()
        {
            return new(AsT0(), true);
        }

        bool Equals(UnionType<T0> other)
        {
            return _ix == other._ix
                && _ix switch
                   {
                       0 => Equals(_v0, other._v0),
                       _ => false
                   };
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            return obj is UnionType<T0> o && Equals(o);
        }

        public override string ToString()
        {
            return _ix switch
            {
                0 => FormatHelper.FormatValue(_v0),
                _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the OneOf codegen.")
            };
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = _ix switch
                {
                    0 => _v0?.GetHashCode(),
                    _ => 0
                } ?? 0;
                return (hashCode * 397) ^ _ix;
            }
        }
    }
}