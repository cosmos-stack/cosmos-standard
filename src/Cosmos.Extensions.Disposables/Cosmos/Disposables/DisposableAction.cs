using System;

namespace Cosmos.Disposables
{
    /// <summary>
    /// Disable Action. <br />
    /// When the derived class of this class is disposed, the specified <see cref="Action"/> will be executed.
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
        /// Get a cached instance of <see cref="NoopDisposableAction"/>.
        /// </summary>
        public static IDisposable Noop => NoopDisposableAction.Instance;
    }
}