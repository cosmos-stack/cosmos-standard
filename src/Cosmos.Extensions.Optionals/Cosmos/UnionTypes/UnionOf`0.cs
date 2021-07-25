using System;

namespace Cosmos.UnionTypes
{
    public class UnionOf<T0> : IUnionType, IUnionType<T0>
    {
        readonly T0 _v0;
        readonly int _ix;

        protected UnionOf(UnionType<T0> input)
        {
            _ix = input.Index;
            _v0 = _ix switch
            {
                0 => input.AsT0(),
                _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionOf codegen.")
            };
        }

        public object Value
        {
            get
            {
                return _ix switch
                {
                    0 => _v0,
                    _ => throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionOf codegen.")
                };
            }
        }

        public int Index => _ix;

        public bool IsT0() => _ix == 0;

        public T0 AsT0()
        {
            return _ix == 0
                ? _v0
                : throw new InvalidOperationException($"Cannot return as T0 as result is T{_ix}");
        }

        public Type TypeOfT0 => typeof(T0);

#if NETFRAMEWORK
        public int Count() => 1;
#endif

        public void Switch(Action<T0> f0)
        {
            if (_ix is 0 && f0 is not null)
            {
                f0(_v0);
                return;
            }

            throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionOf codegen.");
        }

        public TResult Match<TResult>(Func<T0, TResult> f0)
        {
            if (_ix is 0 && f0 is not null)
            {
                return f0(_v0);
            }

            throw new InvalidOperationException("Unexpected index, which indicates a problem in the UnionOf codegen.");
        }

        bool Equals(UnionOf<T0> other)
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

            if (ReferenceEquals(this, obj))
                return true;

            return obj is UnionOf<T0> o && Equals(o);
        }

        public override string ToString()
        {
            return _ix switch
            {
                0 => Internals.FormatHelper.FormatValue(_v0),
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
                    _ => 0
                } ?? 0;
                return (hashCode * 397) ^ _ix;
            }
        }
    }
}