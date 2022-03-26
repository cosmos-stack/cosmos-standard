// ReSharper disable MemberHidesStaticFromOuterClass

namespace Cosmos.Asynchronous;

/// <summary>
/// Async returns <br />
/// 异步返回器
/// </summary>
public static partial class AsyncReturns
{
    /// <summary>
    /// Returns for value task <br />
    /// ValueTask 返回器
    /// </summary>
    public static class ForValueTask
    {
        /// <summary>
        /// Returns exception <br />
        /// 返回一个异常
        /// </summary>
        /// <param name="exception"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<T> Exception<T>(Exception exception) => ValueTaskFactory.FromException<T>(exception);

        /// <summary>
        /// Returns default <br />
        /// 返回一个默认值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<T> Default<T>() => ValueTasks.Create(default(T));

        /// <summary>
        /// Returns value task <br />
        /// 返回一个给定的值
        /// </summary>
        /// <param name="result"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<T> Value<T>(T result) => ValueTasks.Create(result);
    }
}