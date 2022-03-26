namespace Cosmos.Disposables;

/// <summary>
/// A disposable action implement which does nothing when disposed. <br />
/// 当释放时什么都不做
/// </summary>
public class NoopDisposableAction : IDisposableAction, IDisposable
{
    /// <summary>
    /// Gets a <see cref="NoopDisposableAction"/> cache.
    /// </summary>
    public static NoopDisposableAction Instance { get; } = new();

    private NoopDisposableAction() { }

    /// <inheritdoc />
    public void Invoke() { }

    /// <inheritdoc />
    public void Dispose() { }
}