using System;
using System.Threading;

/*
 * Reference to:
 *    Nito.Disposables
 *      Author: Stephen Cleary
 *      URL: https://github.com/StephenCleary/Disposables
 *      MIT
 */

namespace CosmosStack.Disposables
{
    /// <summary>
    /// Single Disposable Object <br />
    /// 可释放对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class SingleDisposableObject<T> : DisposableBase
    {
        private readonly DisposableActionField<T> _context;

        private readonly ManualResetEventSlim _slim = new();

        /// <summary>
        /// Create a single disposable object for such context
        /// </summary>
        /// <param name="context"></param>
        protected SingleDisposableObject(T context)
        {
            _context = new DisposableActionField<T>(Dispose, context);
        }

        /// <summary>
        /// To flag this instance is currently disposing or has been disposed. <br />
        /// 标记此实例当前正在处置或已处置。
        /// </summary>
        public bool IsDisposeStarted => _context.IsEmpty;

        /// <summary>
        /// To flag this instance is disposed, which means finished disposing. <br />
        /// 标记此实例已处置，即处置完毕。
        /// </summary>
        public bool IsDisposed => _slim.IsSet;

        /// <summary>
        /// To flag this instance is currently disposing, but not finished yet. <br />
        /// 标记此实例当前正在处理，但尚未完成。
        /// </summary>
        public bool IsDisposing => IsDisposeStarted && !IsDisposed;

        /// <summary>
        /// The actual disposal method, call only once from Dispose.
        /// </summary>
        /// <param name="context"></param>
        protected abstract void Dispose(T context);

        /// <summary>
        /// On Dispose
        /// </summary>
        protected override void OnDispose()
        {
            var context = _context.TryGetAndUnset();
            if (context is null)
            {
                _slim.Wait();
                return;
            }

            try
            {
                context.Invoke();
            }
            finally
            {
                _slim.Set();
            }
        }

        /// <summary>
        /// Attempts to update the stored context. <br />
        /// This method returns false if this instance has already been disposed or is being disposed. <br />
        /// 尝试更新存储的上下文。 如果此实例已被释放或正在被释放，则此方法返回 false。
        /// </summary>
        /// <param name="contextUpdater"></param>
        /// <returns></returns>
        protected bool TryUpdateContext(Func<T, T> contextUpdater) => _context.TryUpdateContext(contextUpdater);
    }
}