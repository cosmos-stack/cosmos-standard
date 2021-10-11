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
    /// Disposable Action Field <br />
    /// 可释放操作
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class DisposableActionField<T>
    {
        private DisposableAction<T> _field;

        /// <summary>
        /// Create a new <see cref="DisposableActionField{T}"/> instance.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="context"></param>
        public DisposableActionField(Action<T> action, T context)
        {
            _field = new DisposableAction<T>(action, context);
        }

        /// <summary>
        /// To flag this field is empty or not. <br />
        /// 标记字段是否为空
        /// </summary>
        public bool IsEmpty => Interlocked.CompareExchange(ref _field, null, null) is null;

        /// <summary>
        /// Atomically retrieves this disposable action from the field, and sets such field to <c>null</c>. May return <c>null</c>. <br />
        /// 以原子方式从字段中检索此一次性操作，并将此类字段设置为 <c>null</c>。 可能返回 <c>null</c>。
        /// </summary>
        /// <returns></returns>
        public IDisposableAction TryGetAndUnset() => Interlocked.Exchange(ref _field, null);

        /// <summary>
        /// Attempts to update context of disposable action stored in this field, Return <c>false</c> if the field is <c>null</c>.  <br />
        /// 尝试更新存储在此字段中的一次性操作的上下文，如果该字段为 <c>null</c>，则返回 <c>false</c>。
        /// </summary>
        /// <param name="contextUpdater"></param>
        /// <returns></returns>
        public bool TryUpdateContext(Func<T, T> contextUpdater)
        {
            while (true)
            {
                var origin = Interlocked.CompareExchange(ref _field, _field, _field);
                if (origin is null) return false;
                var updatedContext = new DisposableAction<T>(origin, contextUpdater);
                var ret = Interlocked.CompareExchange(ref _field, updatedContext, origin);
                if (ReferenceEquals(origin, ret)) return true;
            }
        }
    }
}