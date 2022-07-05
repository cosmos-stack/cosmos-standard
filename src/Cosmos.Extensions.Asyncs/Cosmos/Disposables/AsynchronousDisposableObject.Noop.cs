using Cosmos.Asynchronous;

namespace Cosmos.Disposables;

/// <summary>
/// An asynchronous disposable implement which does nothing when disposed. <br />
/// 一个异步的一次性工具，在处理时什么也不做。
/// </summary>
public class AsynchronousNoopDisposableObject : IDisposable
#if !NET452
, IAsyncDisposable
#endif
{
    /// <summary>
    /// Gets a <see cref="AsynchronousNoopDisposableObject"/> cache.
    /// </summary>
    public static AsynchronousNoopDisposableObject Instance { get; } = new();

    private AsynchronousNoopDisposableObject() { }

    /// <inheritdoc />
    public void Dispose() { }

    /// <summary>
    /// Dispose async
    /// </summary>
    /// <returns></returns>
    public ValueTask DisposeAsync() => new(Tasks.CompletedTask());
}