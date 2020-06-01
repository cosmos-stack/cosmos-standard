using System;

namespace Cosmos.Disposables
{
    /// <summary>
    /// Generic Disable Action. <br />
    /// When the derived class of this class is disposed, the specified <see cref="Action{T}"/> will be executed.
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
        /// Invoke the disposable action with context
        /// </summary>
        public void Invoke() => OnDispose();

        /// <summary>
        /// Get a cached instance of <see cref="NoopDisposableAction"/>.
        /// </summary>
        public static IDisposable Noop => NoopDisposableAction.Instance;
    }
}