namespace Cosmos.Exceptions;

/// <summary>
/// Creating builder for Try Component <br />
/// 创建 Try 组件的构建器
/// </summary>
/// <typeparam name="TEndingBuilder"></typeparam>
public abstract class TryCreatingBuilderBase<TEndingBuilder> where TEndingBuilder : TryCreatingBuilderBase<TEndingBuilder>
{
    public string Cause { get; private set; }

    public TEndingBuilder WithCause(string cause)
    {
        Cause = cause;
        return (TEndingBuilder)this;
    }
}

/// <summary>
/// Creating builder for Future Try Component <br />
/// 预备创建 Try 组件的构建器
/// </summary>
/// <typeparam name="T"></typeparam>
public sealed class FutureCreatingBuilder<T> : TryCreatingBuilderBase<FutureCreatingBuilder<T>>
{
    private readonly Func<T> _invokeFunc;

    internal FutureCreatingBuilder(Func<T> invokeFunc)
    {
        _invokeFunc = invokeFunc;
    }

    public Try<T> Invoke()
    {
        return Try.Create(_invokeFunc, Cause);
    }
}

/// <summary>
/// Creating builder for Future Try Component <br />
/// 预备创建 Try 组件的构建器
/// </summary>
/// <typeparam name="T"></typeparam>
/// <typeparam name="TResult"></typeparam>
public sealed class FutureCreatingBuilder<T, TResult> : TryCreatingBuilderBase<FutureCreatingBuilder<T, TResult>>
{
    private readonly Func<T, TResult> _invokeFunc;

    internal FutureCreatingBuilder(Func<T, TResult> invokeFunc)
    {
        _invokeFunc = invokeFunc;
    }

    public Try<TResult> Invoke(T arg)
    {
        return Try.Create(_invokeFunc, arg, Cause);
    }
}

/// <summary>
/// Creating builder for Future Try Component <br />
/// 预备创建 Try 组件的构建器
/// </summary>
/// <typeparam name="T1"></typeparam>
/// <typeparam name="T2"></typeparam>
/// <typeparam name="TResult"></typeparam>
public sealed class FutureCreatingBuilder<T1, T2, TResult>
    : TryCreatingBuilderBase<FutureCreatingBuilder<T1, T2, TResult>>
{
    private readonly Func<T1, T2, TResult> _invokeFunc;

    internal FutureCreatingBuilder(Func<T1, T2, TResult> invokeFunc)
    {
        _invokeFunc = invokeFunc;
    }

    public Try<TResult> Invoke(T1 arg1, T2 arg2)
    {
        return Try.Create(_invokeFunc, arg1, arg2, Cause);
    }
}

/// <summary>
/// Creating builder for Future Try Component <br />
/// 预备创建 Try 组件的构建器
/// </summary>
/// <typeparam name="T1"></typeparam>
/// <typeparam name="T2"></typeparam>
/// <typeparam name="T3"></typeparam>
/// <typeparam name="TResult"></typeparam>
public sealed class FutureCreatingBuilder<T1, T2, T3, TResult>
    : TryCreatingBuilderBase<FutureCreatingBuilder<T1, T2, T3, TResult>>
{
    private readonly Func<T1, T2, T3, TResult> _invokeFunc;

    internal FutureCreatingBuilder(Func<T1, T2, T3, TResult> invokeFunc)
    {
        _invokeFunc = invokeFunc;
    }

    public Try<TResult> Invoke(T1 arg1, T2 arg2, T3 arg3)
    {
        return Try.Create(_invokeFunc, arg1, arg2, arg3, Cause);
    }
}

/// <summary>
/// Creating builder for Future Try Component <br />
/// 预备创建 Try 组件的构建器
/// </summary>
/// <typeparam name="T1"></typeparam>
/// <typeparam name="T2"></typeparam>
/// <typeparam name="T3"></typeparam>
/// <typeparam name="T4"></typeparam>
/// <typeparam name="TResult"></typeparam>
public sealed class FutureCreatingBuilder<T1, T2, T3, T4, TResult>
    : TryCreatingBuilderBase<FutureCreatingBuilder<T1, T2, T3, T4, TResult>>
{
    private readonly Func<T1, T2, T3, T4, TResult> _invokeFunc;

    internal FutureCreatingBuilder(Func<T1, T2, T3, T4, TResult> invokeFunc)
    {
        _invokeFunc = invokeFunc;
    }

    public Try<TResult> Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4)
    {
        return Try.Create(_invokeFunc, arg1, arg2, arg3, arg4, Cause);
    }
}

/// <summary>
/// Creating builder for Future Try Component <br />
/// 预备创建 Try 组件的构建器
/// </summary>
/// <typeparam name="T1"></typeparam>
/// <typeparam name="T2"></typeparam>
/// <typeparam name="T3"></typeparam>
/// <typeparam name="T4"></typeparam>
/// <typeparam name="T5"></typeparam>
/// <typeparam name="TResult"></typeparam>
public sealed class FutureCreatingBuilder<T1, T2, T3, T4, T5, TResult>
    : TryCreatingBuilderBase<FutureCreatingBuilder<T1, T2, T3, T4, T5, TResult>>
{
    private readonly Func<T1, T2, T3, T4, T5, TResult> _invokeFunc;

    internal FutureCreatingBuilder(Func<T1, T2, T3, T4, T5, TResult> invokeFunc)
    {
        _invokeFunc = invokeFunc;
    }

    public Try<TResult> Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
    {
        return Try.Create(_invokeFunc, arg1, arg2, arg3, arg4, arg5, Cause);
    }
}

/// <summary>
/// Creating builder for Future Try Component <br />
/// 预备创建 Try 组件的构建器
/// </summary>
/// <typeparam name="T1"></typeparam>
/// <typeparam name="T2"></typeparam>
/// <typeparam name="T3"></typeparam>
/// <typeparam name="T4"></typeparam>
/// <typeparam name="T5"></typeparam>
/// <typeparam name="T6"></typeparam>
/// <typeparam name="TResult"></typeparam>
public sealed class FutureCreatingBuilder<T1, T2, T3, T4, T5, T6, TResult>
    : TryCreatingBuilderBase<FutureCreatingBuilder<T1, T2, T3, T4, T5, T6, TResult>>
{
    private readonly Func<T1, T2, T3, T4, T5, T6, TResult> _invokeFunc;

    internal FutureCreatingBuilder(Func<T1, T2, T3, T4, T5, T6, TResult> invokeFunc)
    {
        _invokeFunc = invokeFunc;
    }

    public Try<TResult> Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
    {
        return Try.Create(_invokeFunc, arg1, arg2, arg3, arg4, arg5, arg6, Cause);
    }
}

/// <summary>
/// Creating builder for Future Try Component <br />
/// 预备创建 Try 组件的构建器
/// </summary>
/// <typeparam name="T1"></typeparam>
/// <typeparam name="T2"></typeparam>
/// <typeparam name="T3"></typeparam>
/// <typeparam name="T4"></typeparam>
/// <typeparam name="T5"></typeparam>
/// <typeparam name="T6"></typeparam>
/// <typeparam name="T7"></typeparam>
/// <typeparam name="TResult"></typeparam>
public sealed class FutureCreatingBuilder<T1, T2, T3, T4, T5, T6, T7, TResult>
    : TryCreatingBuilderBase<FutureCreatingBuilder<T1, T2, T3, T4, T5, T6, T7, TResult>>
{
    private readonly Func<T1, T2, T3, T4, T5, T6, T7, TResult> _invokeFunc;

    internal FutureCreatingBuilder(Func<T1, T2, T3, T4, T5, T6, T7, TResult> invokeFunc)
    {
        _invokeFunc = invokeFunc;
    }

    public Try<TResult> Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
    {
        return Try.Create(_invokeFunc, arg1, arg2, arg3, arg4, arg5, arg6, arg7, Cause);
    }
}

/// <summary>
/// Creating builder for Future Try Component <br />
/// 预备创建 Try 组件的构建器
/// </summary>
/// <typeparam name="T1"></typeparam>
/// <typeparam name="T2"></typeparam>
/// <typeparam name="T3"></typeparam>
/// <typeparam name="T4"></typeparam>
/// <typeparam name="T5"></typeparam>
/// <typeparam name="T6"></typeparam>
/// <typeparam name="T7"></typeparam>
/// <typeparam name="T8"></typeparam>
/// <typeparam name="TResult"></typeparam>
public sealed class FutureCreatingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, TResult>
    : TryCreatingBuilderBase<FutureCreatingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, TResult>>
{
    private readonly Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> _invokeFunc;

    internal FutureCreatingBuilder(Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> invokeFunc)
    {
        _invokeFunc = invokeFunc;
    }

    public Try<TResult> Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
    {
        return Try.Create(_invokeFunc, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, Cause);
    }
}

/// <summary>
/// Creating builder for Future Try Component <br />
/// 预备创建 Try 组件的构建器
/// </summary>
/// <typeparam name="T1"></typeparam>
/// <typeparam name="T2"></typeparam>
/// <typeparam name="T3"></typeparam>
/// <typeparam name="T4"></typeparam>
/// <typeparam name="T5"></typeparam>
/// <typeparam name="T6"></typeparam>
/// <typeparam name="T7"></typeparam>
/// <typeparam name="T8"></typeparam>
/// <typeparam name="T9"></typeparam>
/// <typeparam name="TResult"></typeparam>
public sealed class FutureCreatingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>
    : TryCreatingBuilderBase<FutureCreatingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>>
{
    private readonly Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> _invokeFunc;

    internal FutureCreatingBuilder(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> invokeFunc)
    {
        _invokeFunc = invokeFunc;
    }

    public Try<TResult> Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
    {
        return Try.Create(_invokeFunc, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, Cause);
    }
}

/// <summary>
/// Creating builder for Future Try Component <br />
/// 预备创建 Try 组件的构建器
/// </summary>
/// <typeparam name="T1"></typeparam>
/// <typeparam name="T2"></typeparam>
/// <typeparam name="T3"></typeparam>
/// <typeparam name="T4"></typeparam>
/// <typeparam name="T5"></typeparam>
/// <typeparam name="T6"></typeparam>
/// <typeparam name="T7"></typeparam>
/// <typeparam name="T8"></typeparam>
/// <typeparam name="T9"></typeparam>
/// <typeparam name="T10"></typeparam>
/// <typeparam name="TResult"></typeparam>
public sealed class FutureCreatingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>
    : TryCreatingBuilderBase<FutureCreatingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>>
{
    private readonly Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> _invokeFunc;

    internal FutureCreatingBuilder(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> invokeFunc)
    {
        _invokeFunc = invokeFunc;
    }

    public Try<TResult> Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
    {
        return Try.Create(_invokeFunc, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, Cause);
    }
}

/// <summary>
/// Creating builder for Future Try Component <br />
/// 预备创建 Try 组件的构建器
/// </summary>
/// <typeparam name="T1"></typeparam>
/// <typeparam name="T2"></typeparam>
/// <typeparam name="T3"></typeparam>
/// <typeparam name="T4"></typeparam>
/// <typeparam name="T5"></typeparam>
/// <typeparam name="T6"></typeparam>
/// <typeparam name="T7"></typeparam>
/// <typeparam name="T8"></typeparam>
/// <typeparam name="T9"></typeparam>
/// <typeparam name="T10"></typeparam>
/// <typeparam name="T11"></typeparam>
/// <typeparam name="TResult"></typeparam>
public sealed class FutureCreatingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>
    : TryCreatingBuilderBase<FutureCreatingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>>
{
    private readonly Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> _invokeFunc;

    internal FutureCreatingBuilder(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> invokeFunc)
    {
        _invokeFunc = invokeFunc;
    }

    public Try<TResult> Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
    {
        return Try.Create(_invokeFunc, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, Cause);
    }
}

/// <summary>
/// Creating builder for Future Try Component <br />
/// 预备创建 Try 组件的构建器
/// </summary>
/// <typeparam name="T1"></typeparam>
/// <typeparam name="T2"></typeparam>
/// <typeparam name="T3"></typeparam>
/// <typeparam name="T4"></typeparam>
/// <typeparam name="T5"></typeparam>
/// <typeparam name="T6"></typeparam>
/// <typeparam name="T7"></typeparam>
/// <typeparam name="T8"></typeparam>
/// <typeparam name="T9"></typeparam>
/// <typeparam name="T10"></typeparam>
/// <typeparam name="T11"></typeparam>
/// <typeparam name="T12"></typeparam>
/// <typeparam name="TResult"></typeparam>
public sealed class FutureCreatingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>
    : TryCreatingBuilderBase<FutureCreatingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>>
{
    private readonly Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> _invokeFunc;

    internal FutureCreatingBuilder(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> invokeFunc)
    {
        _invokeFunc = invokeFunc;
    }

    public Try<TResult> Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
    {
        return Try.Create(_invokeFunc, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, Cause);
    }
}

/// <summary>
/// Creating builder for Future Try Component <br />
/// 预备创建 Try 组件的构建器
/// </summary>
/// <typeparam name="T1"></typeparam>
/// <typeparam name="T2"></typeparam>
/// <typeparam name="T3"></typeparam>
/// <typeparam name="T4"></typeparam>
/// <typeparam name="T5"></typeparam>
/// <typeparam name="T6"></typeparam>
/// <typeparam name="T7"></typeparam>
/// <typeparam name="T8"></typeparam>
/// <typeparam name="T9"></typeparam>
/// <typeparam name="T10"></typeparam>
/// <typeparam name="T11"></typeparam>
/// <typeparam name="T12"></typeparam>
/// <typeparam name="T13"></typeparam>
/// <typeparam name="TResult"></typeparam>
public sealed class FutureCreatingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>
    : TryCreatingBuilderBase<FutureCreatingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>>
{
    private readonly Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> _invokeFunc;

    internal FutureCreatingBuilder(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> invokeFunc)
    {
        _invokeFunc = invokeFunc;
    }

    public Try<TResult> Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
    {
        return Try.Create(_invokeFunc, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, Cause);
    }
}

/// <summary>
/// Creating builder for Future Try Component <br />
/// 预备创建 Try 组件的构建器
/// </summary>
/// <typeparam name="T1"></typeparam>
/// <typeparam name="T2"></typeparam>
/// <typeparam name="T3"></typeparam>
/// <typeparam name="T4"></typeparam>
/// <typeparam name="T5"></typeparam>
/// <typeparam name="T6"></typeparam>
/// <typeparam name="T7"></typeparam>
/// <typeparam name="T8"></typeparam>
/// <typeparam name="T9"></typeparam>
/// <typeparam name="T10"></typeparam>
/// <typeparam name="T11"></typeparam>
/// <typeparam name="T12"></typeparam>
/// <typeparam name="T13"></typeparam>
/// <typeparam name="T14"></typeparam>
/// <typeparam name="TResult"></typeparam>
public sealed class FutureCreatingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>
    : TryCreatingBuilderBase<FutureCreatingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>>
{
    private readonly Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> _invokeFunc;

    internal FutureCreatingBuilder(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> invokeFunc)
    {
        _invokeFunc = invokeFunc;
    }

    public Try<TResult> Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
    {
        return Try.Create(_invokeFunc, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, Cause);
    }
}

/// <summary>
/// Creating builder for Future Try Component <br />
/// 预备创建 Try 组件的构建器
/// </summary>
/// <typeparam name="T1"></typeparam>
/// <typeparam name="T2"></typeparam>
/// <typeparam name="T3"></typeparam>
/// <typeparam name="T4"></typeparam>
/// <typeparam name="T5"></typeparam>
/// <typeparam name="T6"></typeparam>
/// <typeparam name="T7"></typeparam>
/// <typeparam name="T8"></typeparam>
/// <typeparam name="T9"></typeparam>
/// <typeparam name="T10"></typeparam>
/// <typeparam name="T11"></typeparam>
/// <typeparam name="T12"></typeparam>
/// <typeparam name="T13"></typeparam>
/// <typeparam name="T14"></typeparam>
/// <typeparam name="T15"></typeparam>
/// <typeparam name="TResult"></typeparam>
public sealed class FutureCreatingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>
    : TryCreatingBuilderBase<FutureCreatingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>>
{
    private readonly Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> _invokeFunc;

    internal FutureCreatingBuilder(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> invokeFunc)
    {
        _invokeFunc = invokeFunc;
    }

    public Try<TResult> Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15)
    {
        return Try.Create(_invokeFunc, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, Cause);
    }
}

/// <summary>
/// Creating builder for Future Try Component <br />
/// 预备创建 Try 组件的构建器
/// </summary>
/// <typeparam name="T1"></typeparam>
/// <typeparam name="T2"></typeparam>
/// <typeparam name="T3"></typeparam>
/// <typeparam name="T4"></typeparam>
/// <typeparam name="T5"></typeparam>
/// <typeparam name="T6"></typeparam>
/// <typeparam name="T7"></typeparam>
/// <typeparam name="T8"></typeparam>
/// <typeparam name="T9"></typeparam>
/// <typeparam name="T10"></typeparam>
/// <typeparam name="T11"></typeparam>
/// <typeparam name="T12"></typeparam>
/// <typeparam name="T13"></typeparam>
/// <typeparam name="T14"></typeparam>
/// <typeparam name="T15"></typeparam>
/// <typeparam name="T16"></typeparam>
/// <typeparam name="TResult"></typeparam>
public sealed class FutureCreatingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>
    : TryCreatingBuilderBase<FutureCreatingBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>>
{
    private readonly Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> _invokeFunc;

    internal FutureCreatingBuilder(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> invokeFunc)
    {
        _invokeFunc = invokeFunc;
    }

    public Try<TResult> Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16)
    {
        return Try.Create(_invokeFunc, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16, Cause);
    }
}