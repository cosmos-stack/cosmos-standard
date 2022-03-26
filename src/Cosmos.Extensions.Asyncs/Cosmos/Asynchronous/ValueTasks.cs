namespace Cosmos.Asynchronous;

/// <summary>
/// ValueTask utilities <br />
/// ValueTask 工具
/// </summary>
public static class ValueTasks
{
    /// <summary>
    /// Create a new ValueTask instance from given result. <br />
    /// 根据给定的值，创建一个 ValueTask 包装
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="result"></param>
    /// <returns></returns>
    public static ValueTask<T> Create<T>(T result) => ValueTaskFactory.FromResult(result);
}

public static class ValueTaskExtensions
{
    /// <summary>
    /// Run in AsyncContext
    /// </summary>
    /// <param name="task"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T RunInContext<T>(this in ValueTask<T> task) => task.AsTask().RunInContext();
}