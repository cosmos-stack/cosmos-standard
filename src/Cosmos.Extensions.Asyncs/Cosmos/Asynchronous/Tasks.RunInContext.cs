using Nito.AsyncEx;

namespace Cosmos.Asynchronous;

/// <summary>
/// Task utilities <br />
/// 任务工具
/// </summary>
public static partial class Tasks
{
    #region Run in Context

    /// <summary>
    /// Run in AsyncContext
    /// </summary>
    /// <param name="task"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public static void RunInContext(Task task)
    {
        ArgumentNullException.ThrowIfNull(task);
        AsyncContext.Run(() => task);
    }

    /// <summary>
    /// Run in AsyncContext
    /// </summary>
    /// <param name="task"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static T RunInContext<T>(Task<T> task)
    {
        ArgumentNullException.ThrowIfNull(task);
        return AsyncContext.Run(() => task);
    }

    #endregion
}

/// <summary>
/// Task extensions
/// </summary>
public static partial class TaskExtensions
{
    /// <summary>
    /// Run in AsyncContext
    /// </summary>
    /// <param name="task"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public static void RunInContext(this Task task) => Tasks.RunInContext(task);

    /// <summary>
    /// Run in AsyncContext
    /// </summary>
    /// <param name="task"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static T RunInContext<T>(this Task<T> task) => Tasks.RunInContext(task);
}