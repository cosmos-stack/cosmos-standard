namespace Cosmos.Disposables;

/// <summary>
/// Generic Disable Action. <br />
/// When the derived class of this class is disposed, the specified <see cref="Action{T}"/> will be executed. <br />
/// 泛型释放操作。当派生类释放时，特定的 <see cref="Action{T}"/> 将被执行。
/// </summary>
/// <typeparam name="T"></typeparam>
public sealed class DisposableAction<T> : DisposeHandler<T>, IDisposableAction
{
    // private readonly Action<T> _action;
    // private readonly T _context;

    /// <summary>
    /// Create a new <see cref="DisposableAction{T}"/> instance.
    /// </summary>
    /// <param name="action"></param>
    /// <param name="context"></param>
    public DisposableAction(Action<T> action, T context) : base(action, context) { }

    /// <summary>
    /// Create a new <see cref="DisposableAction{T}"/> instance.
    /// </summary>
    /// <param name="originalDisposableAction"></param>
    /// <param name="contextUpdater"></param>
    public DisposableAction(DisposableAction<T> originalDisposableAction, Func<T, T> contextUpdater)
        : base(originalDisposableAction.Action, originalDisposableAction.Context, contextUpdater) { }

    /// <summary>
    /// Invoke the disposable action with context <br />
    /// 调用带上下文的释放操作
    /// </summary>
    public void Invoke() => OnDispose();

    /// <summary>
    /// Get a cached instance of <see cref="NoopDisposableAction"/>. <br />
    /// 获取一个缓存了的 <see cref="NoopDisposableAction"/> 实例。
    /// </summary>
    public static IDisposable Noop => NoopDisposableAction.Instance;
}