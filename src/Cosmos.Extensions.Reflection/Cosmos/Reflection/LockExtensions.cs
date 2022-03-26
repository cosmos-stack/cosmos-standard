namespace Cosmos.Reflection;

/// <summary>
/// Cosmos.Core Lock extensions <br />
/// 锁扩展
/// </summary>
public static class LockExtensions
{
    /// <summary>
    /// Lock the specified resource, and then execute the delegation.<br />
    /// 对指定的资源进行加锁，然后执行委托。
    /// </summary>
    public static void LockAndRun(this object source, Action action)
    {
        lock (source)
        {
            action();
        }
    }

    /// <summary>
    /// Lock the specified resource, and then execute the delegation.<br />
    /// 对指定的资源进行加锁，然后执行委托。
    /// </summary>
    public static void LockAndRun<T>(this T source, Action<T> action)
    {
        lock (source)
        {
            action(source);
        }
    }

    /// <summary>
    /// Lock the specified resource, execute the commission and return the result.<br />
    /// 对指定的资源进行加锁，执行委托并返回结果。
    /// </summary>
    public static TResult LockAndReturn<TResult>(this object source, Func<TResult> func)
    {
        lock (source)
        {
            return func();
        }
    }

    /// <summary>
    /// Lock the specified resource, execute the commission and return the result.<br />
    /// 对指定的资源进行加锁，执行委托并返回结果。
    /// </summary>
    public static TResult LockAndReturn<TSource, TResult>(this TSource source, Func<TSource, TResult> func)
    {
        lock (source)
        {
            return func(source);
        }
    }
}