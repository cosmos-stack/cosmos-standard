using System;

namespace Cosmos.Disposables {
    /// <summary>
    /// AsAnonymous Disposable Object
    /// </summary>
    public sealed class AsynchronousAnonymousDisposableObject : AsynchronousSingleDisposableObject<Action> {
        /// <summary>
        /// Create a new <see cref="AsynchronousAnonymousDisposableObject"/> instance.
        /// </summary>
        public AsynchronousAnonymousDisposableObject() : this(() => { }) { }

        /// <summary>
        /// Create a new <see cref="AsynchronousAnonymousDisposableObject"/> instance.
        /// </summary>
        /// <param name="dispose"></param>
        public AsynchronousAnonymousDisposableObject(Action dispose) : base(dispose) { }

        /// <summary>
        /// Create a new <see cref="AsynchronousAnonymousDisposableObject"/> instance.
        /// </summary>
        /// <param name="disposableAction"></param>
        public AsynchronousAnonymousDisposableObject(AsynchronousDisposableAction disposableAction) : base(disposableAction?.InternalAction) { }

        /// <summary>
        /// Dispose.
        /// </summary>
        /// <param name="context"></param>
        protected override void Dispose(Action context) => context?.Invoke();

        /// <summary>
        /// Add dispose <see cref="Action"/>.
        /// </summary>
        /// <param name="dispose"></param>
        public void Add(Action dispose) {
            if (dispose == null)
                return;
            if (!TryUpdateContext(x => x + dispose))
                dispose();
        }

        /// <summary>
        /// Add dispose <see cref="Action"/>.
        /// </summary>
        /// <param name="disposableAction"></param>
        public void Add(AsynchronousDisposableAction disposableAction) {
            Add(disposableAction?.InternalAction);
        }

        /// <summary>
        /// Create a new disposable that executes dispose when disposed.
        /// </summary>
        /// <param name="dispose"></param>
        /// <returns></returns>
        public static AsynchronousAnonymousDisposableObject Create(Action dispose) => new AsynchronousAnonymousDisposableObject(dispose);

        /// <summary>
        /// Create a new disposable that executes dispose when disposed.
        /// </summary>
        /// <param name="disposableAction"></param>
        /// <returns></returns>
        public static AsynchronousAnonymousDisposableObject Create(AsynchronousDisposableAction disposableAction) => new AsynchronousAnonymousDisposableObject(disposableAction);

    }
}