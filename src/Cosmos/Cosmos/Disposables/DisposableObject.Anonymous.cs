using System;

/*
 * Reference to:
 *    Nito.Disposables
 *      Author: Stephen Cleary
 *      URL: https://github.com/StephenCleary/Disposables
 *      MIT
 */

namespace Cosmos.Disposables
{
    public sealed class AnonymousDisposableObject : SingleDisposableObject<Action>
    {

        public AnonymousDisposableObject(Action dispose) : base(dispose) { }

        public AnonymousDisposableObject(DisposableAction disposableAction) : base(disposableAction?.InternalAction) { }

        protected override void Dispose(Action context) => context?.Invoke();

        public void Add(Action dispose)
        {
            if (dispose == null)
                return;
            if (!TryUpdateContext(x => x + dispose))
                dispose();
        }

        public void Add(DisposableAction disposableAction)
        {
            Add(disposableAction?.InternalAction);
        }

        /// <summary>
        /// Create a new disposable that executes dispose when disposed.
        /// </summary>
        /// <param name="dispose"></param>
        /// <returns></returns>
        public static AnonymousDisposableObject Create(Action dispose) => new AnonymousDisposableObject(dispose);

        /// <summary>
        /// Create a new disposable that executes dispose when disposed.
        /// </summary>
        /// <param name="disposableAction"></param>
        /// <returns></returns>
        public static AnonymousDisposableObject Create(DisposableAction disposableAction) => new AnonymousDisposableObject(disposableAction);
    }
}
