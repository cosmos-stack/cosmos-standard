using System;
using System.Threading;
// ReSharper disable InconsistentNaming

namespace Cosmos.Disposables
{
    /// <summary>
    /// Disposable state base
    /// </summary>
    public abstract class DisposableStateBase : IDisposalState
    {
        // Since all write operations are done through Interlocked, no need for volatile.
        private int _disposeState = ALIVE;

        /// <summary>
        /// Disposal state
        /// </summary>
        protected int DisposalState => _disposeState;

        /// <summary>
        /// Was disposed
        /// </summary>
        // Expected majority use will be 'alive'.
        public bool WasDisposed => _disposeState != ALIVE && _disposeState != DISPOSE_CALLED;

        /// <summary>
        /// Will throw if the object is disposed or has started disposal.
        /// </summary>
        /// <param name="strict">When true, will also throw if between alive and disposing states.</param>
        /// <returns>True if still alive.</returns>
        protected bool AssertIsAlive(bool strict = false)
        {
            if (strict ? _disposeState != ALIVE : WasDisposed)
                throw new ObjectDisposedException(GetType().ToString());

            return true;
        }

        /* This is important because some classes might react to disposal
         * and still need access to the live class before it's disposed.
         * In addition, no events should exist during or after disposal. */

        #region Before Disposal

        /// <summary>
        /// On before dispose
        /// </summary>
        protected virtual void OnBeforeDispose() { }

        private event EventHandler BeforeDisposeInternal;

        /// <summary>
        /// BeforeDispose will be triggered once right before disposal commences.
        /// </summary>
        public event EventHandler BeforeDispose
        {
            add
            {
                /*
                 * Cover the easy majority case:
                 * Prevent adding events when already disposed.
                 */
                AssertIsAlive();
                if (_disposeState != ALIVE) // Should not be adding events while event is firing...
                    throw new InvalidOperationException("Adding an event listener while disposing is not supported.");

                /*
                 * Ignore the edge case: (Ultimately not worth coding for.)
                 * There is a miniscule possibility that another thread could add an event listener here while disposing:
                 * Resulting in:
                 * a) Event listener is still invoked and possible subsequent errors.
                 * b) Event listener is missed.
                 */

                BeforeDisposeInternal += value;
            }

            remove => BeforeDisposeInternal -= value;
        }

        private void FireBeforeDispose()
        {
            // Events should only fire if there are listeners...
            if (BeforeDisposeInternal != null)
            {
                BeforeDisposeInternal(this, EventArgs.Empty);
                BeforeDisposeInternal = null;
            }
        }

        #endregion

        /// <summary>
        /// Start dispose
        /// </summary>
        /// <returns></returns>
        protected bool StartDispose()
        {
            // This check will guarantee that disposal only happens once, and only one thread is responsible for disposal.
            if (_disposeState != ALIVE
             || Interlocked.CompareExchange(ref _disposeState, DISPOSE_CALLED, ALIVE) != ALIVE)
                return false;

            try
            {
                OnBeforeDispose();
                FireBeforeDispose();
            }
            finally
            {
                // Need to assure that 'disposing' was set even though there was an error in the try.
                // If by chance something internally called 'Disposed()' then don't regress backwards.
                if (_disposeState == DISPOSE_CALLED)
                    Interlocked.CompareExchange(ref _disposeState, DISPOSING, DISPOSE_CALLED);
            }

            return true;
        }

        /// <summary>
        /// Disposed
        /// </summary>
        protected void Disposed() => Interlocked.Exchange(ref _disposeState, DISPOSED); // State.Disposed

        /// <summary>
        /// Nullify
        /// </summary>
        /// <param name="x"></param>
        /// <typeparam name="TNullable"></typeparam>
        /// <returns></returns>
        protected static TNullable Nullify<TNullable>(ref TNullable x)
            where TNullable : class
        {
            var y = x;
            x = null;
            return y;
        }

        /// <summary>
        /// Dispose of
        /// </summary>
        /// <param name="x"></param>
        /// <typeparam name="T"></typeparam>
        protected static void DisposeOf<T>(ref T x)
            where T : class, IDisposable
        {
            var y = x;
            x = null;
            y?.Dispose();
        }
        
        /// <summary>
        /// Disposal State: Currently living and available.
        /// </summary>
        protected const int ALIVE = 0;

        /// <summary>
        /// Disposal State: Special case where still accessible, but on it's way to being disposed.
        /// </summary>
        protected const int DISPOSE_CALLED = 1;

        /// <summary>
        /// Is currently in the process of being disposed.
        /// </summary>
        protected const int DISPOSING = 2;

        /// <summary>
        /// Has completed disposal.
        /// </summary>
        protected const int DISPOSED = 3;
    }
}