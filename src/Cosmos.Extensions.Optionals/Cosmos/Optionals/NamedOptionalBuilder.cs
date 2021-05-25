using Cosmos.Optionals.Internals;
using Cosmos.Optionals.NamedOptionals;

namespace Cosmos.Optionals
{
    /// <summary>
    /// Named optional builder
    /// </summary>
    public class NamedOptionalBuilder : INamedOptionalBuilder
    {
        private NamedOptionalBuilder() { }

        /// <summary>
        /// Create the named optional builder
        /// </summary>
        /// <returns></returns>
        public static NamedOptionalBuilder Create() => new();

        /// <inheritdoc />
        public INamedOptionalBuilder<T> May<T>(T value)
        {
            return new NamedOptionalLevel1Builder<T>(value, NamedMaybeConstants.KEY);
        }

        /// <inheritdoc />
        public INamedOptionalBuilder<T> May<T>(T value, string key)
        {
            return new NamedOptionalLevel1Builder<T>(value, key);
        }

        internal class NamedOptionalLevel1Builder<T> : INamedOptionalBuilder<T>
        {
            private readonly OptionalHold<T> _hold1;

            public NamedOptionalLevel1Builder(T value, string key)
            {
                _hold1 = new OptionalHold<T>(value, key);
            }

            public INamedOptionalBuilder<T, T2> May<T2>(T2 value)
            {
                return new NamedOptionalLevel2Builder<T, T2>(_hold1, value, NamedMaybeConstants.KEY2);
            }

            public INamedOptionalBuilder<T, T2> May<T2>(T2 value, string key)
            {
                return new NamedOptionalLevel2Builder<T, T2>(_hold1, value, key);
            }

            public Maybe<T> Build()
            {
                return new Maybe<T>(_hold1.Value, _hold1.Key, true);
            }
        }

        internal class NamedOptionalLevel2Builder<T1, T2> : INamedOptionalBuilder<T1, T2>
        {
            private readonly OptionalHold<T1> _hold1;
            private readonly OptionalHold<T2> _hold2;

            public NamedOptionalLevel2Builder(OptionalHold<T1> hold1, T2 value, string key)
            {
                _hold1 = hold1;
                _hold2 = new OptionalHold<T2>(value, key);
            }

            public INamedOptionalBuilder<T1, T2, T3> May<T3>(T3 value)
            {
                return new NamedOptionalLevel3Builder<T1, T2, T3>(_hold1, _hold2, value, NamedMaybeConstants.KEY3);
            }

            public INamedOptionalBuilder<T1, T2, T3> May<T3>(T3 value, string key)
            {
                return new NamedOptionalLevel3Builder<T1, T2, T3>(_hold1, _hold2, value, key);
            }

            public Maybe<T1, T2> Build()
            {
                return new Maybe<T1, T2>(_hold1, _hold2);
            }
        }

        internal class NamedOptionalLevel3Builder<T1, T2, T3> : INamedOptionalBuilder<T1, T2, T3>
        {
            private readonly OptionalHold<T1> _hold1;
            private readonly OptionalHold<T2> _hold2;
            private readonly OptionalHold<T3> _hold3;

            public NamedOptionalLevel3Builder(OptionalHold<T1> hold1, OptionalHold<T2> hold2, T3 value, string key)
            {
                _hold1 = hold1;
                _hold2 = hold2;
                _hold3 = new OptionalHold<T3>(value, key);
            }

            public INamedOptionalBuilder<T1, T2, T3, T4> May<T4>(T4 value)
            {
                return new NamedOptionalLevel4Builder<T1, T2, T3, T4>(_hold1, _hold2, _hold3, value, NamedMaybeConstants.KEY4);
            }

            public INamedOptionalBuilder<T1, T2, T3, T4> May<T4>(T4 value, string key)
            {
                return new NamedOptionalLevel4Builder<T1, T2, T3, T4>(_hold1, _hold2, _hold3, value, key);
            }

            public Maybe<T1, T2, T3> Build()
            {
                return new Maybe<T1, T2, T3>(_hold1, _hold2, _hold3);
            }
        }

        internal class NamedOptionalLevel4Builder<T1, T2, T3, T4> : INamedOptionalBuilder<T1, T2, T3, T4>
        {
            private readonly OptionalHold<T1> _hold1;
            private readonly OptionalHold<T2> _hold2;
            private readonly OptionalHold<T3> _hold3;
            private readonly OptionalHold<T4> _hold4;

            public NamedOptionalLevel4Builder(OptionalHold<T1> hold1, OptionalHold<T2> hold2, OptionalHold<T3> hold3, T4 value, string key)
            {
                _hold1 = hold1;
                _hold2 = hold2;
                _hold3 = hold3;
                _hold4 = new OptionalHold<T4>(value, key);
            }

            public INamedOptionalBuilder<T1, T2, T3, T4, T5> May<T5>(T5 value)
            {
                return new NamedOptionalLevel5Builder<T1, T2, T3, T4, T5>(_hold1, _hold2, _hold3, _hold4, value, NamedMaybeConstants.KEY5);
            }

            public INamedOptionalBuilder<T1, T2, T3, T4, T5> May<T5>(T5 value, string key)
            {
                return new NamedOptionalLevel5Builder<T1, T2, T3, T4, T5>(_hold1, _hold2, _hold3, _hold4, value, key);
            }

            public Maybe<T1, T2, T3, T4> Build()
            {
                return new Maybe<T1, T2, T3, T4>(_hold1, _hold2, _hold3, _hold4);
            }
        }

        internal class NamedOptionalLevel5Builder<T1, T2, T3, T4, T5> : INamedOptionalBuilder<T1, T2, T3, T4, T5>
        {
            private readonly OptionalHold<T1> _hold1;
            private readonly OptionalHold<T2> _hold2;
            private readonly OptionalHold<T3> _hold3;
            private readonly OptionalHold<T4> _hold4;
            private readonly OptionalHold<T5> _hold5;

            public NamedOptionalLevel5Builder(OptionalHold<T1> hold1, OptionalHold<T2> hold2, OptionalHold<T3> hold3, OptionalHold<T4> hold4, T5 value, string key)
            {
                _hold1 = hold1;
                _hold2 = hold2;
                _hold3 = hold3;
                _hold4 = hold4;
                _hold5 = new OptionalHold<T5>(value, key);
            }

            public INamedOptionalBuilder<T1, T2, T3, T4, T5, T6> May<T6>(T6 value)
            {
                return new NamedOptionalLevel6Builder<T1, T2, T3, T4, T5, T6>(_hold1, _hold2, _hold3, _hold4, _hold5, value, NamedMaybeConstants.KEY6);
            }

            public INamedOptionalBuilder<T1, T2, T3, T4, T5, T6> May<T6>(T6 value, string key)
            {
                return new NamedOptionalLevel6Builder<T1, T2, T3, T4, T5, T6>(_hold1, _hold2, _hold3, _hold4, _hold5, value, key);
            }

            public Maybe<T1, T2, T3, T4, T5> Build()
            {
                return new Maybe<T1, T2, T3, T4, T5>(_hold1, _hold2, _hold3, _hold4, _hold5);
            }
        }

        internal class NamedOptionalLevel6Builder<T1, T2, T3, T4, T5, T6> : INamedOptionalBuilder<T1, T2, T3, T4, T5, T6>
        {
            private readonly OptionalHold<T1> _hold1;
            private readonly OptionalHold<T2> _hold2;
            private readonly OptionalHold<T3> _hold3;
            private readonly OptionalHold<T4> _hold4;
            private readonly OptionalHold<T5> _hold5;
            private readonly OptionalHold<T6> _hold6;

            public NamedOptionalLevel6Builder(OptionalHold<T1> hold1, OptionalHold<T2> hold2, OptionalHold<T3> hold3, OptionalHold<T4> hold4, OptionalHold<T5> hold5, T6 value,
                string key)
            {
                _hold1 = hold1;
                _hold2 = hold2;
                _hold3 = hold3;
                _hold4 = hold4;
                _hold5 = hold5;
                _hold6 = new OptionalHold<T6>(value, key);
            }

            public INamedOptionalBuilder<T1, T2, T3, T4, T5, T6, T7> May<T7>(T7 value)
            {
                return new NamedOptionalLevel7Builder<T1, T2, T3, T4, T5, T6, T7>(_hold1, _hold2, _hold3, _hold4, _hold5, _hold6, value, NamedMaybeConstants.KEY7);
            }

            public INamedOptionalBuilder<T1, T2, T3, T4, T5, T6, T7> May<T7>(T7 value, string key)
            {
                return new NamedOptionalLevel7Builder<T1, T2, T3, T4, T5, T6, T7>(_hold1, _hold2, _hold3, _hold4, _hold5, _hold6, value, key);
            }

            public Maybe<T1, T2, T3, T4, T5, T6> Build()
            {
                return new Maybe<T1, T2, T3, T4, T5, T6>(_hold1, _hold2, _hold3, _hold4, _hold5, _hold6);
            }
        }

        internal class NamedOptionalLevel7Builder<T1, T2, T3, T4, T5, T6, T7> : INamedOptionalBuilder<T1, T2, T3, T4, T5, T6, T7>
        {
            private readonly OptionalHold<T1> _hold1;
            private readonly OptionalHold<T2> _hold2;
            private readonly OptionalHold<T3> _hold3;
            private readonly OptionalHold<T4> _hold4;
            private readonly OptionalHold<T5> _hold5;
            private readonly OptionalHold<T6> _hold6;
            private readonly OptionalHold<T7> _hold7;

            public NamedOptionalLevel7Builder(OptionalHold<T1> hold1, OptionalHold<T2> hold2, OptionalHold<T3> hold3, OptionalHold<T4> hold4, OptionalHold<T5> hold5,
                OptionalHold<T6> hold6, T7 value,
                string key)
            {
                _hold1 = hold1;
                _hold2 = hold2;
                _hold3 = hold3;
                _hold4 = hold4;
                _hold5 = hold5;
                _hold6 = hold6;
                _hold7 = new OptionalHold<T7>(value, key);
            }

            public Maybe<T1, T2, T3, T4, T5, T6, T7> Build()
            {
                return new Maybe<T1, T2, T3, T4, T5, T6, T7>(_hold1, _hold2, _hold3, _hold4, _hold5, _hold6, _hold7);
            }
        }

        internal class OptionalHold<T>
        {
            public OptionalHold(T holdValue, string holdKey)
            {
                Value = holdValue;
                Key = holdKey;
            }

            public T Value { get; }
            public string Key { get; }

            private Maybe<T> ToMaybe() => new Maybe<T>(Value, Key, true);

            public static implicit operator Maybe<T>(OptionalHold<T> hold)
            {
                return hold.ToMaybe();
            }
        }
    }
}