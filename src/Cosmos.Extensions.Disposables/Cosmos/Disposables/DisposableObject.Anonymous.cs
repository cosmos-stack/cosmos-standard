/*
 * Reference to:
 *    Nito.Disposables
 *      Author: Stephen Cleary
 *      URL: https://github.com/StephenCleary/Disposables
 *      MIT
 */

namespace Cosmos.Disposables;

/// <summary>
/// Anonymous Disposable Object <br />
/// 匿名可释放对象
/// </summary>
public sealed class AnonymousDisposableObject : SingleDisposableObject<Action>
{
    /// <summary>
    /// Create a new <see cref="AnonymousDisposableObject"/> instance.
    /// </summary>
    public AnonymousDisposableObject() : this(() => { }) { }

    /// <summary>
    /// Create a new <see cref="AnonymousDisposableObject"/> instance.
    /// </summary>
    /// <param name="dispose"></param>
    public AnonymousDisposableObject(Action dispose) : base(dispose) { }

    /// <summary>
    /// Create a new <see cref="AnonymousDisposableObject"/> instance.
    /// </summary>
    /// <param name="disposableAction"></param>
    public AnonymousDisposableObject(DisposableAction disposableAction) : base(disposableAction?.InternalAction) { }

    /// <summary>
    /// Dispose.
    /// </summary>
    /// <param name="context"></param>
    protected override void Dispose(Action context) => context?.Invoke();

    /// <summary>
    /// Add dispose <see cref="Action"/>.
    /// </summary>
    /// <param name="dispose"></param>
    public void Add(Action dispose)
    {
        if (dispose is null)
            return;
        if (!TryUpdateContext(x => x + dispose))
            dispose();
    }

    /// <summary>
    /// Add dispose <see cref="Action"/>.
    /// </summary>
    /// <param name="disposableAction"></param>
    public void Add(DisposableAction disposableAction)
    {
        Add(disposableAction?.InternalAction);
    }

    /// <summary>
    /// Create a new disposable that executes dispose when disposed.
    /// </summary>
    /// <param name="dispose"></param>
    /// <returns></returns>
    public static AnonymousDisposableObject Create(Action dispose) => new(dispose);

    /// <summary>
    /// Create a new disposable that executes dispose when disposed.
    /// </summary>
    /// <param name="disposableAction"></param>
    /// <returns></returns>
    public static AnonymousDisposableObject Create(DisposableAction disposableAction) => new(disposableAction);
}