namespace Cosmos.Disposables;

/// <summary>
/// Asynchronous Disposable Action. <br />
/// When the derived class of this class is disposed, the specified <see cref="Action"/> will be executed async. <br />
/// 异步释放操作。 当这个类的派生类被释放时，指定的 <see cref="Action"/> 将被异步执行。
/// </summary>
public sealed class AsynchronousDisposableAction : AsynchronousDisposeHandler, IAsynchronousDisposableAction
{
    /// <summary>
    /// Create a new <see cref="AsynchronousDisposableAction"/> instance.
    /// </summary>
    /// <param name="action"></param>
    public AsynchronousDisposableAction(Func<ValueTask> action) : base(action) { }

    /// <inheritdoc />
    public ValueTask InvokeAsync() => OnDisposeAsync();
}