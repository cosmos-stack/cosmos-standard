using System;

namespace Cosmos.Exceptions
{
    public abstract class FutureInvokingBuilderBase<TEndingBuilder> where TEndingBuilder : FutureInvokingBuilderBase<TEndingBuilder>
    {
        public string Cause { get; private set; }

        public TEndingBuilder WithCause(string cause)
        {
            Cause = cause;
            return (TEndingBuilder) this;
        }
    }

    public sealed class FutureInvokingBuilder : FutureInvokingBuilderBase<FutureInvokingBuilder>
    {
        private readonly Action _invokeAction;

        internal FutureInvokingBuilder(Action invokeAction)
        {
            _invokeAction = invokeAction;
        }

        public TryAction Invoke()
        {
            return Try.Invoke(_invokeAction, Cause);
        }
    }

    public sealed class FutureInvokingBuilder<T> : FutureInvokingBuilderBase<FutureInvokingBuilder<T>>
    {
        private readonly Action<T> _invokeAction;

        internal FutureInvokingBuilder(Action<T> invokeAction)
        {
            _invokeAction = invokeAction;
        }

        public TryAction Invoke(T obj)
        {
            return Try.Invoke(_invokeAction, obj, Cause);
        }
    }

    public sealed class FutureInvokingBuilder<T1, T2> : FutureInvokingBuilderBase<FutureInvokingBuilder<T1, T2>>
    {
        private readonly Action<T1, T2> _invokeAction;

        internal FutureInvokingBuilder(Action<T1, T2> invokeAction)
        {
            _invokeAction = invokeAction;
        }

        public TryAction Invoke(T1 arg1, T2 arg2)
        {
            return Try.Invoke(_invokeAction, arg1, arg2, Cause);
        }
    }

    public sealed class FutureInvokingBuilder<T1, T2, T3> : FutureInvokingBuilderBase<FutureInvokingBuilder<T1, T2, T3>>
    {
        private readonly Action<T1, T2, T3> _invokeAction;

        internal FutureInvokingBuilder(Action<T1, T2, T3> invokeAction)
        {
            _invokeAction = invokeAction;
        }

        public TryAction Invoke(T1 arg1, T2 arg2, T3 arg3)
        {
            return Try.Invoke(_invokeAction, arg1, arg2, arg3, Cause);
        }
    }

    public sealed class FutureInvokingBuilder<T1, T2, T3, T4> : FutureInvokingBuilderBase<FutureInvokingBuilder<T1, T2, T3, T4>>
    {
        private readonly Action<T1, T2, T3, T4> _invokeAction;

        internal FutureInvokingBuilder(Action<T1, T2, T3, T4> invokeAction)
        {
            _invokeAction = invokeAction;
        }

        public TryAction Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            return Try.Invoke(_invokeAction, arg1, arg2, arg3, arg4, Cause);
        }
    }

    public sealed class FutureInvokingBuilder<T1, T2, T3, T4, T5> : FutureInvokingBuilderBase<FutureInvokingBuilder<T1, T2, T3, T4, T5>>
    {
        private readonly Action<T1, T2, T3, T4, T5> _invokeAction;

        internal FutureInvokingBuilder(Action<T1, T2, T3, T4, T5> invokeAction)
        {
            _invokeAction = invokeAction;
        }

        public TryAction Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            return Try.Invoke(_invokeAction, arg1, arg2, arg3, arg4, arg5, Cause);
        }
    }

    public sealed class FutureInvokingBuilder<T1, T2, T3, T4, T5, T6> : FutureInvokingBuilderBase<FutureInvokingBuilder<T1, T2, T3, T4, T5, T6>>
    {
        private readonly Action<T1, T2, T3, T4, T5, T6> _invokeAction;

        internal FutureInvokingBuilder(Action<T1, T2, T3, T4, T5, T6> invokeAction)
        {
            _invokeAction = invokeAction;
        }

        public TryAction Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
        {
            return Try.Invoke(_invokeAction, arg1, arg2, arg3, arg4, arg5, arg6, Cause);
        }
    }

    public sealed class FutureInvokingBuilder<T1, T2, T3, T4, T5, T6, T7> : FutureInvokingBuilderBase<FutureInvokingBuilder<T1, T2, T3, T4, T5, T6, T7>>
    {
        private readonly Action<T1, T2, T3, T4, T5, T6, T7> _invokeAction;

        internal FutureInvokingBuilder(Action<T1, T2, T3, T4, T5, T6, T7> invokeAction)
        {
            _invokeAction = invokeAction;
        }

        public TryAction Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
        {
            return Try.Invoke(_invokeAction, arg1, arg2, arg3, arg4, arg5, arg6, arg7, Cause);
        }
    }

    public sealed class FutureInvokingBuilder<T1, T2, T3, T4, T5, T6, T7, T8> : FutureInvokingBuilderBase<FutureInvokingBuilder<T1, T2, T3, T4, T5, T6, T7, T8>>
    {
        private readonly Action<T1, T2, T3, T4, T5, T6, T7, T8> _invokeAction;

        internal FutureInvokingBuilder(Action<T1, T2, T3, T4, T5, T6, T7, T8> invokeAction)
        {
            _invokeAction = invokeAction;
        }

        public TryAction Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
        {
            return Try.Invoke(_invokeAction, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, Cause);
        }
    }

    public sealed class FutureInvokingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9> : FutureInvokingBuilderBase<FutureInvokingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9>>
    {
        private readonly Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> _invokeAction;

        internal FutureInvokingBuilder(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> invokeAction)
        {
            _invokeAction = invokeAction;
        }

        public TryAction Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
        {
            return Try.Invoke(_invokeAction, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, Cause);
        }
    }

    public sealed class FutureInvokingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> : FutureInvokingBuilderBase<FutureInvokingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>
    {
        private readonly Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> _invokeAction;

        internal FutureInvokingBuilder(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> invokeAction)
        {
            _invokeAction = invokeAction;
        }

        public TryAction Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
        {
            return Try.Invoke(_invokeAction, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, Cause);
        }
    }

    public sealed class FutureInvokingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> : FutureInvokingBuilderBase<FutureInvokingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>>
    {
        private readonly Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> _invokeAction;

        internal FutureInvokingBuilder(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> invokeAction)
        {
            _invokeAction = invokeAction;
        }

        public TryAction Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
        {
            return Try.Invoke(_invokeAction, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, Cause);
        }
    }

    public sealed class FutureInvokingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> : FutureInvokingBuilderBase<FutureInvokingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>>
    {
        private readonly Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> _invokeAction;

        internal FutureInvokingBuilder(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> invokeAction)
        {
            _invokeAction = invokeAction;
        }

        public TryAction Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
        {
            return Try.Invoke(_invokeAction, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, Cause);
        }
    }

    public sealed class FutureInvokingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> : FutureInvokingBuilderBase<FutureInvokingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>>
    {
        private readonly Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> _invokeAction;

        internal FutureInvokingBuilder(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> invokeAction)
        {
            _invokeAction = invokeAction;
        }

        public TryAction Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
        {
            return Try.Invoke(_invokeAction, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, Cause);
        }
    }

    public sealed class FutureInvokingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> : FutureInvokingBuilderBase<FutureInvokingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>>
    {
        private readonly Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> _invokeAction;

        internal FutureInvokingBuilder(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> invokeAction)
        {
            _invokeAction = invokeAction;
        }

        public TryAction Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
        {
            return Try.Invoke(_invokeAction, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, Cause);
        }
    }

    public sealed class FutureInvokingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> : FutureInvokingBuilderBase<FutureInvokingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>>
    {
        private readonly Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> _invokeAction;

        internal FutureInvokingBuilder(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> invokeAction)
        {
            _invokeAction = invokeAction;
        }

        public TryAction Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15)
        {
            return Try.Invoke(_invokeAction, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, Cause);
        }
    }

    public sealed class FutureInvokingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> : FutureInvokingBuilderBase<FutureInvokingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>>
    {
        private readonly Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> _invokeAction;

        internal FutureInvokingBuilder(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> invokeAction)
        {
            _invokeAction = invokeAction;
        }

        public TryAction Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16)
        {
            return Try.Invoke(_invokeAction, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16, Cause);
        }
    }
}