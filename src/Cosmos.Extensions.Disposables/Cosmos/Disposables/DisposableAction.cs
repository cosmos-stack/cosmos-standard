namespace Cosmos.Disposables;

/// <summary>
/// Disable Action. <br />
/// When the derived class of this class is disposed, the specified <see cref="Action"/> will be executed. <br />
/// 释放操作。当派生类释放时，指定的操作 <see cref="Action"/> 将被执行。
/// </summary>
public sealed class DisposableAction : DisposeHandler, IDisposableAction
{
    /// <summary>
    /// Create a new <see cref="DisposableAction"/> instance.
    /// </summary>
    /// <param name="action"></param>
    public DisposableAction(Action action) : base(action) { }

    /// <inheritdoc />
    public void Invoke() => OnDispose();

    /// <summary>
    /// Get a cached instance of <see cref="NoopDisposableAction"/>. <br />
    /// 获取一个缓存了的 <see cref="NoopDisposableAction"/> 实例。
    /// </summary>
    public static IDisposable Noop => NoopDisposableAction.Instance;
}