using System;
using Cosmos.Optionals;

namespace Cosmos.UnionTypes
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

        public int Index => _ix;

        public bool IsT0() => _ix == 0;

        public T0 AsT0()
        {
            if (_ix == 0)
                return _v0;
            throw new InvalidOperationException($"Cannot return as T0 as result is T{_ix}");
        }

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

        public Maybe<T0> ToMaybeValue()
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
                0 => Internals.FormatHelper.FormatValue(_v0),
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