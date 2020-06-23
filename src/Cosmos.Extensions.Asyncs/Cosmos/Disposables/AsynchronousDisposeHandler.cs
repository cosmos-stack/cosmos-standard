using System;
using System.Threading.Tasks;

namespace Cosmos.Disposables
{
    /// <summary>
    /// Asynchronous dispose handler
    /// </summary>
    public class AsynchronousDisposeHandler : AsynchronousDisposableBase
    {
        /// <summary>
        /// Internal protected dispose handler
        /// </summary>
        protected internal AsynchronousDisposeHandler() { }

        /// <summary>
        /// Create a new instance of <see cref="AsynchronousDisposeHandler"/>.
        /// </summary>
        /// <param name="action"></param>
        public AsynchronousDisposeHandler(Func<ValueTask> action)
        {
            _action = action ?? throw new ArgumentNullException(nameof(action));
        }

        Func<ValueTask> _action;

        /// <summary>
        /// Internal protected dispose action update
        /// </summary>
        /// <param name="action"></param>
        protected void ActionUpdate(Func<ValueTask> action)
        {
            _action = action ?? throw new ArgumentNullException(nameof(action));
        }

        /// <summary>
        /// Internal protected action
        /// </summary>
        /// <returns></returns>
        protected internal virtual Func<ValueTask> InternalAction => _action;

        /// <summary>
        /// On dispose async
        /// </summary>
        /// <returns></returns>
        protected override ValueTask OnDisposeAsync() => Nullify(ref _action).Invoke();
    }
}