namespace Cosmos.Exceptions;

/*
 * Try / to lift a value or exception and return a new wrapper instance for that.
 */

/// <summary>
/// Try <br />
/// Try 组件
/// </summary>
public static partial class Try
{
    /// <summary>
    /// Lifts a value. <br />
    /// 直接使用一个值生成 <see cref="Try{T}"/> 实例
    /// </summary>
    /// <param name="value"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static Try<T> LiftValue<T>(T value) => new Success<T>(value);

    /// <summary>
    /// Lifts <br />
    /// 直接使用一个异常生成 <see cref="Try{T}"/> 实例
    /// </summary>
    /// <param name="ex"></param>
    /// <param name="cause"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static Try<T> LiftException<T>(Exception ex, string cause = null) => new Failure<T>(ex, cause);

    private static void NotNull<T>(T t, string nameOfParams)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(t, nameOfParams);
#else
        if (t is null)
            throw new ArgumentNullException(nameOfParams);
#endif
    }

    private static void TaskGuard(Task task, string nameOfParams)
    {
        if (task is null)
            throw new InvalidOperationException($"The task factory {nameOfParams} failed to run.");
    }
}