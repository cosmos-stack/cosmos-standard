using System;
using System.Threading.Tasks;

namespace Cosmos.Disposables
{
    /// <summary>
    /// Asynchronous dispose handler
    /// </summary>
    public class AsynchronousDisposeHandler<T> : AsynchronousDisposeHandler
    {
        /// <summary>
        /// Create a new instance of <see cref="AsynchronousDisposeHandler{T}"/>
        /// </summary>
        /// <param name="context"></param>
        /// <param name="action"></param>
        public AsynchronousDisposeHandler(Func<T, ValueTask> action, T context)
        {
            Action = action;
            ActionUpdate(() => action.Invoke(context));
            Context = context;
        }

        /// <summary>
        /// Create a new instance of <see cref="AsynchronousDisposeHandler{T}"/>
        /// </summary>
        /// <param name="action"></param>
        /// <param name="originalContext"></param>
        /// <param name="contextUpdater"></param>
        public AsynchronousDisposeHandler(Func<T, ValueTask> action, T originalContext, Func<T, T> contextUpdater)
        {
            Action = action;
            var updatedContext = contextUpdater.Invoke(originalContext);
            ActionUpdate(() => action.Invoke(updatedContext));
            Context = updatedContext;
        }

        /// <summary>
        /// Gets context
        /// </summary>
        public T Context { get; private set; }

        /// <summary>
        /// Action
        /// </summary>
        protected internal Func<T, ValueTask> Action;

        /// <summary>
        /// On dispose async
        /// </summary>
        /// <returns></returns>
        protected override ValueTask OnDisposeAsync()
        {
            Context = default;
            return base.OnDisposeAsync();
        }
    }
}