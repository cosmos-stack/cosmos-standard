using System;
using System.Threading.Tasks;
using CosmosStack.Asynchronous;

namespace CosmosStack.Disposables
{
    /// <summary>
    /// Asynchronous Anonymous Disposable Object <br />
    /// 异步匿名可释放对象
    /// </summary>
    public sealed class AsynchronousAnonymousDisposableObject : AsynchronousSingleDisposableObject<Func<ValueTask>>
    {
        /// <summary>
        /// Create a new <see cref="AsynchronousAnonymousDisposableObject"/> instance.
        /// </summary>
        public AsynchronousAnonymousDisposableObject() : this(() => new ValueTask(Tasks.CompletedTask())) { }

        /// <summary>
        /// Create a new <see cref="AsynchronousAnonymousDisposableObject"/> instance.
        /// </summary>
        /// <param name="dispose"></param>
        public AsynchronousAnonymousDisposableObject(Func<ValueTask> dispose) : base(dispose) { }

        /// <summary>
        /// Create a new <see cref="AsynchronousAnonymousDisposableObject"/> instance.
        /// </summary>
        /// <param name="disposableAction"></param>
        public AsynchronousAnonymousDisposableObject(AsynchronousDisposableAction disposableAction) : base(disposableAction?.InternalAction) { }

        /// <summary>
        /// Dispose.
        /// </summary>
        /// <param name="context"></param>
        protected override ValueTask DisposeAsync(Func<ValueTask> context) => context.Invoke();

        /// <summary>
        /// Add dispose <see cref="Action"/>.
        /// </summary>
        /// <param name="dispose"></param>
        public void Add(Func<ValueTask> dispose)
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
        public void Add(AsynchronousDisposableAction disposableAction)
        {
            Add(disposableAction?.InternalAction);
        }

        /// <summary>
        /// Create a new disposable that executes dispose when disposed.
        /// </summary>
        /// <param name="dispose"></param>
        /// <returns></returns>
        public static AsynchronousAnonymousDisposableObject Create(Func<ValueTask> dispose) => new AsynchronousAnonymousDisposableObject(dispose);

        /// <summary>
        /// Create a new disposable that executes dispose when disposed.
        /// </summary>
        /// <param name="disposableAction"></param>
        /// <returns></returns>
        public static AsynchronousAnonymousDisposableObject Create(AsynchronousDisposableAction disposableAction) => new AsynchronousAnonymousDisposableObject(disposableAction);
    }
}