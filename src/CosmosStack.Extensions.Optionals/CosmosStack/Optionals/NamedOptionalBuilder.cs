using CosmosStack.Optionals.Internals;
using CosmosStack.Optionals.NamedOptionals;

namespace CosmosStack.Optionals
{
    /// <summary>
    /// Named optional builder <br />
    /// 具名 MayBe 组件构建器
    /// </summary>
    public class NamedOptionalBuilder : INamedOptionalBuilder
    {
        private NamedOptionalBuilder() { }

        /// <summary>
        /// Create the named optional builder <br />
        /// 创建一个具名 MayBe 组件构建器
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

            public INamedOptionalBuilder<T1, T2, T3, T4, T5, T6, T7, T8> May<T8>(T8 value)
            {
                return new NamedOptionalLevel8Builder<T1, T2, T3, T4, T5, T6, T7, T8>(_hold1, _hold2, _hold3, _hold4, _hold5, _hold6, _hold7, value, NamedMaybeConstants.KEY8);
            }

            public INamedOptionalBuilder<T1, T2, T3, T4, T5, T6, T7, T8> May<T8>(T8 value, string key)
            {
                return new NamedOptionalLevel8Builder<T1, T2, T3, T4, T5, T6, T7, T8>(_hold1, _hold2, _hold3, _hold4, _hold5, _hold6, _hold7, value, key);
            }

            public Maybe<T1, T2, T3, T4, T5, T6, T7> Build()
            {
                return new Maybe<T1, T2, T3, T4, T5, T6, T7>(_hold1, _hold2, _hold3, _hold4, _hold5, _hold6, _hold7);
            }
        }

        internal class NamedOptionalLevel8Builder<T1, T2, T3, T4, T5, T6, T7, T8> : INamedOptionalBuilder<T1, T2, T3, T4, T5, T6, T7, T8>
        {
            private readonly OptionalHold<T1> _hold1;
            private readonly OptionalHold<T2> _hold2;
            private readonly OptionalHold<T3> _hold3;
            private readonly OptionalHold<T4> _hold4;
            private readonly OptionalHold<T5> _hold5;
            private readonly OptionalHold<T6> _hold6;
            private readonly OptionalHold<T7> _hold7;
            private readonly OptionalHold<T8> _hold8;

            public NamedOptionalLevel8Builder(OptionalHold<T1> hold1, OptionalHold<T2> hold2, OptionalHold<T3> hold3, OptionalHold<T4> hold4, OptionalHold<T5> hold5,
                OptionalHold<T6> hold6, OptionalHold<T7> hold7, T8 value,
                string key)
            {
                _hold1 = hold1;
                _hold2 = hold2;
                _hold3 = hold3;
                _hold4 = hold4;
                _hold5 = hold5;
                _hold6 = hold6;
                _hold7 = hold7;
                _hold8 = new OptionalHold<T8>(value, key);
            }

            public INamedOptionalBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9> May<T9>(T9 value)
            {
                return new NamedOptionalLevel9Builder<T1, T2, T3, T4, T5, T6, T7, T8, T9>(_hold1, _hold2, _hold3, _hold4, _hold5, _hold6, _hold7, _hold8, value, NamedMaybeConstants.KEY9);
            }

            public INamedOptionalBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9> May<T9>(T9 value, string key)
            {
                return new NamedOptionalLevel9Builder<T1, T2, T3, T4, T5, T6, T7, T8, T9>(_hold1, _hold2, _hold3, _hold4, _hold5, _hold6, _hold7, _hold8, value, key);
            }

            public Maybe<T1, T2, T3, T4, T5, T6, T7, T8> Build()
            {
                return new Maybe<T1, T2, T3, T4, T5, T6, T7, T8>(_hold1, _hold2, _hold3, _hold4, _hold5, _hold6, _hold7, _hold8);
            }
        }

        internal class NamedOptionalLevel9Builder<T1, T2, T3, T4, T5, T6, T7, T8, T9> : INamedOptionalBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9>
        {
            private readonly OptionalHold<T1> _hold1;
            private readonly OptionalHold<T2> _hold2;
            private readonly OptionalHold<T3> _hold3;
            private readonly OptionalHold<T4> _hold4;
            private readonly OptionalHold<T5> _hold5;
            private readonly OptionalHold<T6> _hold6;
            private readonly OptionalHold<T7> _hold7;
            private readonly OptionalHold<T8> _hold8;
            private readonly OptionalHold<T9> _hold9;

            public NamedOptionalLevel9Builder(OptionalHold<T1> hold1, OptionalHold<T2> hold2, OptionalHold<T3> hold3, OptionalHold<T4> hold4, OptionalHold<T5> hold5,
                OptionalHold<T6> hold6, OptionalHold<T7> hold7, OptionalHold<T8> hold8, T9 value,
                string key)
            {
                _hold1 = hold1;
                _hold2 = hold2;
                _hold3 = hold3;
                _hold4 = hold4;
                _hold5 = hold5;
                _hold6 = hold6;
                _hold7 = hold7;
                _hold8 = hold8;
                _hold9 = new OptionalHold<T9>(value, key);
            }

            public INamedOptionalBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> May<T10>(T10 value)
            {
                return new NamedOptionalLevel10Builder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(_hold1, _hold2, _hold3, _hold4, _hold5, _hold6, _hold7, _hold8, _hold9, value, NamedMaybeConstants.KEY10);
            }

            public INamedOptionalBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> May<T10>(T10 value, string key)
            {
                return new NamedOptionalLevel10Builder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(_hold1, _hold2, _hold3, _hold4, _hold5, _hold6, _hold7, _hold8, _hold9, value, key);
            }

            public Maybe<T1, T2, T3, T4, T5, T6, T7, T8, T9> Build()
            {
                return new Maybe<T1, T2, T3, T4, T5, T6, T7, T8, T9>(_hold1, _hold2, _hold3, _hold4, _hold5, _hold6, _hold7, _hold8, _hold9);
            }
        }

        internal class NamedOptionalLevel10Builder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> : INamedOptionalBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>
        {
            private readonly OptionalHold<T1> _hold1;
            private readonly OptionalHold<T2> _hold2;
            private readonly OptionalHold<T3> _hold3;
            private readonly OptionalHold<T4> _hold4;
            private readonly OptionalHold<T5> _hold5;
            private readonly OptionalHold<T6> _hold6;
            private readonly OptionalHold<T7> _hold7;
            private readonly OptionalHold<T8> _hold8;
            private readonly OptionalHold<T9> _hold9;
            private readonly OptionalHold<T10> _hold10;

            public NamedOptionalLevel10Builder(OptionalHold<T1> hold1, OptionalHold<T2> hold2, OptionalHold<T3> hold3, OptionalHold<T4> hold4, OptionalHold<T5> hold5,
                OptionalHold<T6> hold6, OptionalHold<T7> hold7, OptionalHold<T8> hold8, OptionalHold<T9> hold9, T10 value,
                string key)
            {
                _hold1 = hold1;
                _hold2 = hold2;
                _hold3 = hold3;
                _hold4 = hold4;
                _hold5 = hold5;
                _hold6 = hold6;
                _hold7 = hold7;
                _hold8 = hold8;
                _hold9 = hold9;
                _hold10 = new OptionalHold<T10>(value, key);
            }

            public INamedOptionalBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> May<T11>(T11 value)
            {
                return new NamedOptionalLevel11Builder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(_hold1, _hold2, _hold3, _hold4, _hold5, _hold6, _hold7, _hold8, _hold9, _hold10, value, NamedMaybeConstants.KEY11);
            }

            public INamedOptionalBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> May<T11>(T11 value, string key)
            {
                return new NamedOptionalLevel11Builder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(_hold1, _hold2, _hold3, _hold4, _hold5, _hold6, _hold7, _hold8, _hold9, _hold10, value, key);
            }

            public Maybe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Build()
            {
                return new Maybe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(_hold1, _hold2, _hold3, _hold4, _hold5, _hold6, _hold7, _hold8, _hold9, _hold10);
            }
        }

        internal class NamedOptionalLevel11Builder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> : INamedOptionalBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>
        {
            private readonly OptionalHold<T1> _hold1;
            private readonly OptionalHold<T2> _hold2;
            private readonly OptionalHold<T3> _hold3;
            private readonly OptionalHold<T4> _hold4;
            private readonly OptionalHold<T5> _hold5;
            private readonly OptionalHold<T6> _hold6;
            private readonly OptionalHold<T7> _hold7;
            private readonly OptionalHold<T8> _hold8;
            private readonly OptionalHold<T9> _hold9;
            private readonly OptionalHold<T10> _hold10;
            private readonly OptionalHold<T11> _hold11;

            public NamedOptionalLevel11Builder(OptionalHold<T1> hold1, OptionalHold<T2> hold2, OptionalHold<T3> hold3, OptionalHold<T4> hold4, OptionalHold<T5> hold5,
                OptionalHold<T6> hold6, OptionalHold<T7> hold7, OptionalHold<T8> hold8, OptionalHold<T9> hold9, OptionalHold<T10> hold10, T11 value,
                string key)
            {
                _hold1 = hold1;
                _hold2 = hold2;
                _hold3 = hold3;
                _hold4 = hold4;
                _hold5 = hold5;
                _hold6 = hold6;
                _hold7 = hold7;
                _hold8 = hold8;
                _hold9 = hold9;
                _hold10 = hold10;
                _hold11 = new OptionalHold<T11>(value, key);
            }

            public INamedOptionalBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> May<T12>(T12 value)
            {
                return new NamedOptionalLevel12Builder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(_hold1, _hold2, _hold3, _hold4, _hold5, _hold6, _hold7, _hold8, _hold9, _hold10, _hold11, value, NamedMaybeConstants.KEY12);
            }

            public INamedOptionalBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> May<T12>(T12 value, string key)
            {
                return new NamedOptionalLevel12Builder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(_hold1, _hold2, _hold3, _hold4, _hold5, _hold6, _hold7, _hold8, _hold9, _hold10, _hold11, value, key);
            }

            public Maybe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Build()
            {
                return new Maybe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(_hold1, _hold2, _hold3, _hold4, _hold5, _hold6, _hold7, _hold8, _hold9, _hold10, _hold11);
            }
        }

        internal class NamedOptionalLevel12Builder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> : INamedOptionalBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>
        {
            private readonly OptionalHold<T1> _hold1;
            private readonly OptionalHold<T2> _hold2;
            private readonly OptionalHold<T3> _hold3;
            private readonly OptionalHold<T4> _hold4;
            private readonly OptionalHold<T5> _hold5;
            private readonly OptionalHold<T6> _hold6;
            private readonly OptionalHold<T7> _hold7;
            private readonly OptionalHold<T8> _hold8;
            private readonly OptionalHold<T9> _hold9;
            private readonly OptionalHold<T10> _hold10;
            private readonly OptionalHold<T11> _hold11;
            private readonly OptionalHold<T12> _hold12;

            public NamedOptionalLevel12Builder(OptionalHold<T1> hold1, OptionalHold<T2> hold2, OptionalHold<T3> hold3, OptionalHold<T4> hold4, OptionalHold<T5> hold5,
                OptionalHold<T6> hold6, OptionalHold<T7> hold7, OptionalHold<T8> hold8, OptionalHold<T9> hold9, OptionalHold<T10> hold10, OptionalHold<T11> hold11, T12 value,
                string key)
            {
                _hold1 = hold1;
                _hold2 = hold2;
                _hold3 = hold3;
                _hold4 = hold4;
                _hold5 = hold5;
                _hold6 = hold6;
                _hold7 = hold7;
                _hold8 = hold8;
                _hold9 = hold9;
                _hold10 = hold10;
                _hold11 = hold11;
                _hold12 = new OptionalHold<T12>(value, key);
            }

            public INamedOptionalBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> May<T13>(T13 value)
            {
                return new NamedOptionalLevel13Builder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(_hold1, _hold2, _hold3, _hold4, _hold5, _hold6, _hold7, _hold8, _hold9, _hold10, _hold11, _hold12, value, NamedMaybeConstants.KEY13);
            }

            public INamedOptionalBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> May<T13>(T13 value, string key)
            {
                return new NamedOptionalLevel13Builder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(_hold1, _hold2, _hold3, _hold4, _hold5, _hold6, _hold7, _hold8, _hold9, _hold10, _hold11, _hold12, value, key);
            }

            public Maybe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Build()
            {
                return new Maybe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(_hold1, _hold2, _hold3, _hold4, _hold5, _hold6, _hold7, _hold8, _hold9, _hold10, _hold11, _hold12);
            }
        }

        internal class NamedOptionalLevel13Builder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> : INamedOptionalBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>
        {
            private readonly OptionalHold<T1> _hold1;
            private readonly OptionalHold<T2> _hold2;
            private readonly OptionalHold<T3> _hold3;
            private readonly OptionalHold<T4> _hold4;
            private readonly OptionalHold<T5> _hold5;
            private readonly OptionalHold<T6> _hold6;
            private readonly OptionalHold<T7> _hold7;
            private readonly OptionalHold<T8> _hold8;
            private readonly OptionalHold<T9> _hold9;
            private readonly OptionalHold<T10> _hold10;
            private readonly OptionalHold<T11> _hold11;
            private readonly OptionalHold<T12> _hold12;
            private readonly OptionalHold<T13> _hold13;

            public NamedOptionalLevel13Builder(OptionalHold<T1> hold1, OptionalHold<T2> hold2, OptionalHold<T3> hold3, OptionalHold<T4> hold4, OptionalHold<T5> hold5,
                OptionalHold<T6> hold6, OptionalHold<T7> hold7, OptionalHold<T8> hold8, OptionalHold<T9> hold9, OptionalHold<T10> hold10, OptionalHold<T11> hold11,
                OptionalHold<T12> hold12, T13 value,
                string key)
            {
                _hold1 = hold1;
                _hold2 = hold2;
                _hold3 = hold3;
                _hold4 = hold4;
                _hold5 = hold5;
                _hold6 = hold6;
                _hold7 = hold7;
                _hold8 = hold8;
                _hold9 = hold9;
                _hold10 = hold10;
                _hold11 = hold11;
                _hold12 = hold12;
                _hold13 = new OptionalHold<T13>(value, key);
            }

            public INamedOptionalBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> May<T14>(T14 value)
            {
                return new NamedOptionalLevel14Builder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
                    _hold1, _hold2, _hold3, _hold4, _hold5, _hold6, _hold7, _hold8, _hold9, _hold10, _hold11, _hold12, _hold13, value,
                    NamedMaybeConstants.KEY14);
            }

            public INamedOptionalBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> May<T14>(T14 value, string key)
            {
                return new NamedOptionalLevel14Builder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
                    _hold1, _hold2, _hold3, _hold4, _hold5, _hold6, _hold7, _hold8, _hold9, _hold10, _hold11, _hold12, _hold13, value, key);
            }

            public Maybe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Build()
            {
                return new Maybe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
                    _hold1, _hold2, _hold3, _hold4, _hold5, _hold6, _hold7, _hold8, _hold9, _hold10, _hold11, _hold12, _hold13);
            }
        }

        internal class NamedOptionalLevel14Builder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> : INamedOptionalBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>
        {
            private readonly OptionalHold<T1> _hold1;
            private readonly OptionalHold<T2> _hold2;
            private readonly OptionalHold<T3> _hold3;
            private readonly OptionalHold<T4> _hold4;
            private readonly OptionalHold<T5> _hold5;
            private readonly OptionalHold<T6> _hold6;
            private readonly OptionalHold<T7> _hold7;
            private readonly OptionalHold<T8> _hold8;
            private readonly OptionalHold<T9> _hold9;
            private readonly OptionalHold<T10> _hold10;
            private readonly OptionalHold<T11> _hold11;
            private readonly OptionalHold<T12> _hold12;
            private readonly OptionalHold<T13> _hold13;
            private readonly OptionalHold<T14> _hold14;

            public NamedOptionalLevel14Builder(OptionalHold<T1> hold1, OptionalHold<T2> hold2, OptionalHold<T3> hold3, OptionalHold<T4> hold4, OptionalHold<T5> hold5,
                OptionalHold<T6> hold6, OptionalHold<T7> hold7, OptionalHold<T8> hold8, OptionalHold<T9> hold9, OptionalHold<T10> hold10, OptionalHold<T11> hold11,
                OptionalHold<T12> hold12, OptionalHold<T13> hold13, T14 value,
                string key)
            {
                _hold1 = hold1;
                _hold2 = hold2;
                _hold3 = hold3;
                _hold4 = hold4;
                _hold5 = hold5;
                _hold6 = hold6;
                _hold7 = hold7;
                _hold8 = hold8;
                _hold9 = hold9;
                _hold10 = hold10;
                _hold11 = hold11;
                _hold12 = hold12;
                _hold13 = hold13;
                _hold14 = new OptionalHold<T14>(value, key);
            }

            public INamedOptionalBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> May<T15>(T15 value)
            {
                return new NamedOptionalLevel15Builder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(
                    _hold1, _hold2, _hold3, _hold4, _hold5, _hold6, _hold7, _hold8, _hold9, _hold10, _hold11, _hold12, _hold13, _hold14, value,
                    NamedMaybeConstants.KEY15);
            }

            public INamedOptionalBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> May<T15>(T15 value, string key)
            {
                return new NamedOptionalLevel15Builder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(
                    _hold1, _hold2, _hold3, _hold4, _hold5, _hold6, _hold7, _hold8, _hold9, _hold10, _hold11, _hold12, _hold13, _hold14, value, key);
            }

            public Maybe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Build()
            {
                return new Maybe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
                    _hold1, _hold2, _hold3, _hold4, _hold5, _hold6, _hold7, _hold8, _hold9, _hold10, _hold11, _hold12, _hold13, _hold14);
            }
        }

        internal class NamedOptionalLevel15Builder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> : INamedOptionalBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>
        {
            private readonly OptionalHold<T1> _hold1;
            private readonly OptionalHold<T2> _hold2;
            private readonly OptionalHold<T3> _hold3;
            private readonly OptionalHold<T4> _hold4;
            private readonly OptionalHold<T5> _hold5;
            private readonly OptionalHold<T6> _hold6;
            private readonly OptionalHold<T7> _hold7;
            private readonly OptionalHold<T8> _hold8;
            private readonly OptionalHold<T9> _hold9;
            private readonly OptionalHold<T10> _hold10;
            private readonly OptionalHold<T11> _hold11;
            private readonly OptionalHold<T12> _hold12;
            private readonly OptionalHold<T13> _hold13;
            private readonly OptionalHold<T14> _hold14;
            private readonly OptionalHold<T15> _hold15;

            public NamedOptionalLevel15Builder(OptionalHold<T1> hold1, OptionalHold<T2> hold2, OptionalHold<T3> hold3, OptionalHold<T4> hold4, OptionalHold<T5> hold5,
                OptionalHold<T6> hold6, OptionalHold<T7> hold7, OptionalHold<T8> hold8, OptionalHold<T9> hold9, OptionalHold<T10> hold10, OptionalHold<T11> hold11,
                OptionalHold<T12> hold12, OptionalHold<T13> hold13, OptionalHold<T14> hold14, T15 value,
                string key)
            {
                _hold1 = hold1;
                _hold2 = hold2;
                _hold3 = hold3;
                _hold4 = hold4;
                _hold5 = hold5;
                _hold6 = hold6;
                _hold7 = hold7;
                _hold8 = hold8;
                _hold9 = hold9;
                _hold10 = hold10;
                _hold11 = hold11;
                _hold12 = hold12;
                _hold13 = hold13;
                _hold14 = hold14;
                _hold15 = new OptionalHold<T15>(value, key);
            }

            public INamedOptionalBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> May<T16>(T16 value)
            {
                return new NamedOptionalLevel16Builder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
                    _hold1, _hold2, _hold3, _hold4, _hold5, _hold6, _hold7, _hold8, _hold9, _hold10, _hold11, _hold12, _hold13, _hold14, _hold15, value,
                    NamedMaybeConstants.KEY15);
            }

            public INamedOptionalBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> May<T16>(T16 value, string key)
            {
                return new NamedOptionalLevel16Builder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
                    _hold1, _hold2, _hold3, _hold4, _hold5, _hold6, _hold7, _hold8, _hold9, _hold10, _hold11, _hold12, _hold13, _hold14, _hold15, value, key);
            }

            public Maybe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Build()
            {
                return new Maybe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(
                    _hold1, _hold2, _hold3, _hold4, _hold5, _hold6, _hold7, _hold8, _hold9, _hold10, _hold11, _hold12, _hold13, _hold14, _hold15);
            }
        }

        internal class NamedOptionalLevel16Builder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> : INamedOptionalBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>
        {
            private readonly OptionalHold<T1> _hold1;
            private readonly OptionalHold<T2> _hold2;
            private readonly OptionalHold<T3> _hold3;
            private readonly OptionalHold<T4> _hold4;
            private readonly OptionalHold<T5> _hold5;
            private readonly OptionalHold<T6> _hold6;
            private readonly OptionalHold<T7> _hold7;
            private readonly OptionalHold<T8> _hold8;
            private readonly OptionalHold<T9> _hold9;
            private readonly OptionalHold<T10> _hold10;
            private readonly OptionalHold<T11> _hold11;
            private readonly OptionalHold<T12> _hold12;
            private readonly OptionalHold<T13> _hold13;
            private readonly OptionalHold<T14> _hold14;
            private readonly OptionalHold<T15> _hold15;
            private readonly OptionalHold<T16> _hold16;

            public NamedOptionalLevel16Builder(OptionalHold<T1> hold1, OptionalHold<T2> hold2, OptionalHold<T3> hold3, OptionalHold<T4> hold4, OptionalHold<T5> hold5,
                OptionalHold<T6> hold6, OptionalHold<T7> hold7, OptionalHold<T8> hold8, OptionalHold<T9> hold9, OptionalHold<T10> hold10, OptionalHold<T11> hold11,
                OptionalHold<T12> hold12, OptionalHold<T13> hold13, OptionalHold<T14> hold14, OptionalHold<T15> hold15, T16 value,
                string key)
            {
                _hold1 = hold1;
                _hold2 = hold2;
                _hold3 = hold3;
                _hold4 = hold4;
                _hold5 = hold5;
                _hold6 = hold6;
                _hold7 = hold7;
                _hold8 = hold8;
                _hold9 = hold9;
                _hold10 = hold10;
                _hold11 = hold11;
                _hold12 = hold12;
                _hold13 = hold13;
                _hold14 = hold14;
                _hold15 = hold15;
                _hold16 = new OptionalHold<T16>(value, key);
            }

            public INamedOptionalBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> May<T17>(T17 value)
            {
                return new NamedOptionalLevel17Builder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(
                    _hold1, _hold2, _hold3, _hold4, _hold5, _hold6, _hold7, _hold8, _hold9, _hold10, _hold11, _hold12, _hold13, _hold14, _hold15, _hold16, value,
                    NamedMaybeConstants.KEY15);
            }

            public INamedOptionalBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> May<T17>(T17 value, string key)
            {
                return new NamedOptionalLevel17Builder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(
                    _hold1, _hold2, _hold3, _hold4, _hold5, _hold6, _hold7, _hold8, _hold9, _hold10, _hold11, _hold12, _hold13, _hold14, _hold15, _hold16, value, key);
            }

            public Maybe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Build()
            {
                return new Maybe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
                    _hold1, _hold2, _hold3, _hold4, _hold5, _hold6, _hold7, _hold8, _hold9, _hold10, _hold11, _hold12, _hold13, _hold14, _hold15, _hold16);
            }
        }

        internal class NamedOptionalLevel17Builder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> : INamedOptionalBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>
        {
            private readonly OptionalHold<T1> _hold1;
            private readonly OptionalHold<T2> _hold2;
            private readonly OptionalHold<T3> _hold3;
            private readonly OptionalHold<T4> _hold4;
            private readonly OptionalHold<T5> _hold5;
            private readonly OptionalHold<T6> _hold6;
            private readonly OptionalHold<T7> _hold7;
            private readonly OptionalHold<T8> _hold8;
            private readonly OptionalHold<T9> _hold9;
            private readonly OptionalHold<T10> _hold10;
            private readonly OptionalHold<T11> _hold11;
            private readonly OptionalHold<T12> _hold12;
            private readonly OptionalHold<T13> _hold13;
            private readonly OptionalHold<T14> _hold14;
            private readonly OptionalHold<T15> _hold15;
            private readonly OptionalHold<T16> _hold16;
            private readonly OptionalHold<T17> _hold17;

            public NamedOptionalLevel17Builder(OptionalHold<T1> hold1, OptionalHold<T2> hold2, OptionalHold<T3> hold3, OptionalHold<T4> hold4, OptionalHold<T5> hold5,
                OptionalHold<T6> hold6, OptionalHold<T7> hold7, OptionalHold<T8> hold8, OptionalHold<T9> hold9, OptionalHold<T10> hold10, OptionalHold<T11> hold11,
                OptionalHold<T12> hold12, OptionalHold<T13> hold13, OptionalHold<T14> hold14, OptionalHold<T15> hold15, OptionalHold<T16> hold16, T17 value,
                string key)
            {
                _hold1 = hold1;
                _hold2 = hold2;
                _hold3 = hold3;
                _hold4 = hold4;
                _hold5 = hold5;
                _hold6 = hold6;
                _hold7 = hold7;
                _hold8 = hold8;
                _hold9 = hold9;
                _hold10 = hold10;
                _hold11 = hold11;
                _hold12 = hold12;
                _hold13 = hold13;
                _hold14 = hold14;
                _hold15 = hold15;
                _hold16 = hold16;
                _hold17 = new OptionalHold<T17>(value, key);
            }

            public INamedOptionalBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18> May<T18>(T18 value)
            {
                return new NamedOptionalLevel18Builder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(
                    _hold1, _hold2, _hold3, _hold4, _hold5, _hold6, _hold7, _hold8, _hold9, _hold10, _hold11, _hold12, _hold13, _hold14, _hold15, _hold16, _hold17, value,
                    NamedMaybeConstants.KEY15);
            }

            public INamedOptionalBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18> May<T18>(T18 value, string key)
            {
                return new NamedOptionalLevel18Builder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(
                    _hold1, _hold2, _hold3, _hold4, _hold5, _hold6, _hold7, _hold8, _hold9, _hold10, _hold11, _hold12, _hold13, _hold14, _hold15, _hold16, _hold17, value, key);
            }

            public Maybe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> Build()
            {
                return new Maybe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(
                    _hold1, _hold2, _hold3, _hold4, _hold5, _hold6, _hold7, _hold8, _hold9, _hold10, _hold11, _hold12, _hold13, _hold14, _hold15, _hold16, _hold17);
            }
        }

        internal class NamedOptionalLevel18Builder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18> : INamedOptionalBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>
        {
            private readonly OptionalHold<T1> _hold1;
            private readonly OptionalHold<T2> _hold2;
            private readonly OptionalHold<T3> _hold3;
            private readonly OptionalHold<T4> _hold4;
            private readonly OptionalHold<T5> _hold5;
            private readonly OptionalHold<T6> _hold6;
            private readonly OptionalHold<T7> _hold7;
            private readonly OptionalHold<T8> _hold8;
            private readonly OptionalHold<T9> _hold9;
            private readonly OptionalHold<T10> _hold10;
            private readonly OptionalHold<T11> _hold11;
            private readonly OptionalHold<T12> _hold12;
            private readonly OptionalHold<T13> _hold13;
            private readonly OptionalHold<T14> _hold14;
            private readonly OptionalHold<T15> _hold15;
            private readonly OptionalHold<T16> _hold16;
            private readonly OptionalHold<T17> _hold17;
            private readonly OptionalHold<T18> _hold18;

            public NamedOptionalLevel18Builder(OptionalHold<T1> hold1, OptionalHold<T2> hold2, OptionalHold<T3> hold3, OptionalHold<T4> hold4, OptionalHold<T5> hold5,
                OptionalHold<T6> hold6, OptionalHold<T7> hold7, OptionalHold<T8> hold8, OptionalHold<T9> hold9, OptionalHold<T10> hold10, OptionalHold<T11> hold11,
                OptionalHold<T12> hold12, OptionalHold<T13> hold13, OptionalHold<T14> hold14, OptionalHold<T15> hold15, OptionalHold<T16> hold16,
                OptionalHold<T17> hold17, T18 value,
                string key)
            {
                _hold1 = hold1;
                _hold2 = hold2;
                _hold3 = hold3;
                _hold4 = hold4;
                _hold5 = hold5;
                _hold6 = hold6;
                _hold7 = hold7;
                _hold8 = hold8;
                _hold9 = hold9;
                _hold10 = hold10;
                _hold11 = hold11;
                _hold12 = hold12;
                _hold13 = hold13;
                _hold14 = hold14;
                _hold15 = hold15;
                _hold16 = hold16;
                _hold17 = hold17;
                _hold18 = new OptionalHold<T18>(value, key);
            }

            public INamedOptionalBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19> May<T19>(T19 value)
            {
                return new NamedOptionalLevel19Builder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(
                    _hold1, _hold2, _hold3, _hold4, _hold5, _hold6, _hold7, _hold8, _hold9, _hold10, _hold11, _hold12, _hold13, _hold14, _hold15, _hold16, _hold17, _hold18, value,
                    NamedMaybeConstants.KEY15);
            }

            public INamedOptionalBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19> May<T19>(T19 value, string key)
            {
                return new NamedOptionalLevel19Builder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(
                    _hold1, _hold2, _hold3, _hold4, _hold5, _hold6, _hold7, _hold8, _hold9, _hold10, _hold11, _hold12, _hold13, _hold14, _hold15, _hold16, _hold17, _hold18, value, key);
            }

            public Maybe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18> Build()
            {
                return new Maybe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(
                    _hold1, _hold2, _hold3, _hold4, _hold5, _hold6, _hold7, _hold8, _hold9, _hold10, _hold11, _hold12, _hold13, _hold14, _hold15, _hold16, _hold17, _hold18);
            }
        }

        internal class NamedOptionalLevel19Builder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19> : INamedOptionalBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>
        {
            private readonly OptionalHold<T1> _hold1;
            private readonly OptionalHold<T2> _hold2;
            private readonly OptionalHold<T3> _hold3;
            private readonly OptionalHold<T4> _hold4;
            private readonly OptionalHold<T5> _hold5;
            private readonly OptionalHold<T6> _hold6;
            private readonly OptionalHold<T7> _hold7;
            private readonly OptionalHold<T8> _hold8;
            private readonly OptionalHold<T9> _hold9;
            private readonly OptionalHold<T10> _hold10;
            private readonly OptionalHold<T11> _hold11;
            private readonly OptionalHold<T12> _hold12;
            private readonly OptionalHold<T13> _hold13;
            private readonly OptionalHold<T14> _hold14;
            private readonly OptionalHold<T15> _hold15;
            private readonly OptionalHold<T16> _hold16;
            private readonly OptionalHold<T17> _hold17;
            private readonly OptionalHold<T18> _hold18;
            private readonly OptionalHold<T19> _hold19;

            public NamedOptionalLevel19Builder(OptionalHold<T1> hold1, OptionalHold<T2> hold2, OptionalHold<T3> hold3, OptionalHold<T4> hold4, OptionalHold<T5> hold5,
                OptionalHold<T6> hold6, OptionalHold<T7> hold7, OptionalHold<T8> hold8, OptionalHold<T9> hold9, OptionalHold<T10> hold10, OptionalHold<T11> hold11,
                OptionalHold<T12> hold12, OptionalHold<T13> hold13, OptionalHold<T14> hold14, OptionalHold<T15> hold15, OptionalHold<T16> hold16,
                OptionalHold<T17> hold17, OptionalHold<T18> hold18, T19 value,
                string key)
            {
                _hold1 = hold1;
                _hold2 = hold2;
                _hold3 = hold3;
                _hold4 = hold4;
                _hold5 = hold5;
                _hold6 = hold6;
                _hold7 = hold7;
                _hold8 = hold8;
                _hold9 = hold9;
                _hold10 = hold10;
                _hold11 = hold11;
                _hold12 = hold12;
                _hold13 = hold13;
                _hold14 = hold14;
                _hold15 = hold15;
                _hold16 = hold16;
                _hold17 = hold17;
                _hold18 = hold18;
                _hold19 = new OptionalHold<T19>(value, key);
            }

            public Maybe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19> Build()
            {
                return new Maybe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(
                    _hold1, _hold2, _hold3, _hold4, _hold5, _hold6, _hold7, _hold8, _hold9, _hold10, _hold11, _hold12, _hold13, _hold14, _hold15, _hold16, _hold17, _hold18, _hold19);
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