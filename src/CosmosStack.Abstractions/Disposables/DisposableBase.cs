namespace Cosmos.Disposables;

/// <summary>
/// A base class for properly implementing the synchronous dispose pattern. <br />
/// Implement OnDispose to handle disposal. <br />
/// 同步释放模式的基类，通过实现 OnDispose 来处理。
/// </summary>
public abstract class DisposableBase : DisposableStateBase, IDisposable
{
    /// <inheritdoc />
    public void Dispose()
    {
        if (!StartDispose())
        {
            return;
        }

        try
        {
            OnDispose();
        }
        finally
        {
            Disposed();
        }
    }

    /// <summary>
    /// When implemented will be called (only once) when being disposed. <br />
    /// 当释放时调用此方法（且仅一次）。
    /// </summary>
    protected abstract void OnDispose();
}