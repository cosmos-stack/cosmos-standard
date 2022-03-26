namespace Cosmos.Disposables;

/// <summary>
/// Dispose handler <br />
/// 释放处理器
/// </summary>
/// <typeparam name="T"></typeparam>
public class DisposeHandler<T> : DisposeHandler
{
    /// <summary>
    /// Create a new instance of <see cref="DisposeHandler{T}"/>
    /// </summary>
    /// <param name="context"></param>
    /// <param name="action"></param>
    public DisposeHandler(Action<T> action, T context)
    {
        Action = action;
        ActionUpdate(() => action?.Invoke(context));
        Context = context;
    }

    /// <summary>
    /// Create a new instance of <see cref="DisposeHandler{T}"/>
    /// </summary>
    /// <param name="action"></param>
    /// <param name="originalContext"></param>
    /// <param name="contextUpdater"></param>
    public DisposeHandler(Action<T> action, T originalContext, Func<T, T> contextUpdater)
    {
        Action = action;
        var updatedContext = contextUpdater.Invoke(originalContext);
        ActionUpdate(() => action?.Invoke(updatedContext));
        Context = updatedContext;
    }

    /// <summary>
    /// Gets context <br />
    /// 获取上下文
    /// </summary>
    public T Context { get; private set; }

    /// <summary>
    /// Action
    /// </summary>
    protected internal Action<T> Action;

    /// <summary>
    /// On dispose
    /// </summary>
    protected override void OnDispose()
    {
        Context = default;
        base.OnDispose();
    }
}