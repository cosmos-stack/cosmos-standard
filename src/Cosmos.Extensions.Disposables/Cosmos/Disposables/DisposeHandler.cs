namespace Cosmos.Disposables;

/// <summary>
/// Dispose handler <br />
/// 释放处理器
/// </summary>
public class DisposeHandler : DisposableBase
{
    /// <summary>
    /// Internal protected dispose handler
    /// </summary>
    protected internal DisposeHandler() { }

    /// <summary>
    /// Create a new instance of <see cref="DisposeHandler"/>
    /// </summary>
    /// <param name="action"></param>
    public DisposeHandler(Action action)
    {
        _action = action ?? throw new ArgumentNullException(nameof(action));
    }

    Action _action;

    /// <summary>
    /// Internal protected dispose action update
    /// </summary>
    /// <param name="action"></param>
    protected void ActionUpdate(Action action)
    {
        _action = action ?? throw new ArgumentNullException(nameof(action));
    }

    /// <summary>
    /// Internal protected action
    /// </summary>
    /// <returns></returns>
    protected internal virtual Action InternalAction => _action;

    /// <summary>
    /// On Dispose
    /// </summary>
    protected override void OnDispose() => Nullify(ref _action).Invoke();
}