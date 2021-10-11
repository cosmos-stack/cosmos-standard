using System;

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
    /// Single Nonblocking Disposable Object <br />
    /// 非阻塞可释放对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class SingleNonblockingDisposableObject<T> : DisposableBase
    {
        private readonly DisposableActionField<T> _context;

        /// <summary>
        /// Create a single nonblocking disposable object for such context
        /// </summary>
        /// <param name="context"></param>
        protected SingleNonblockingDisposableObject(T context)
        {
            _context = new DisposableActionField<T>(Dispose, context);
        }

        /// <summary>
        /// To flag this instance is currently disposing or has been disposed. <br />
        /// 标记此实例当前正在处置或已处置。
        /// </summary>
        public bool IsDisposeStarted => _context.IsEmpty;

        /// <summary>
        /// The actual disposal method, call only once from <see cref="Dispose"/>
        /// </summary>
        /// <param name="context"></param>
        protected abstract void Dispose(T context);

        /// <summary>
        /// On Dispose
        /// </summary>
        protected override void OnDispose() => _context.TryGetAndUnset()?.Invoke();

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