using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Cosmos.Disposables
{
    /// <summary>
    /// Deferred cleanup base
    /// </summary>
    public abstract class DeferredCleanupBase : DisposableBase
    {
        // So far 50 ms seems optimal...
        private int _cleanupDelay = 50;

        /// <summary>
        /// Gets or sets cleanup delay
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public int CleanupDelay
        {
            get => _cleanupDelay;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), value, "Cannot be a negative value.");
                _cleanupDelay = value;
            }
        }

        /// <summary>
        /// Time of last cleanup
        /// </summary>
        public DateTime LastCleanup { get; private set; }

        /// <summary>
        /// Is cleanup past due
        /// </summary>
        public bool IsCleanupPastDue
            => DateTime.Now.Ticks - (_cleanupDelay + 100) * TimeSpan.TicksPerMillisecond > LastCleanup.Ticks;

        /// <summary>
        /// Is running
        /// </summary>
        public bool IsRunning { get; private set; }

        private readonly object _timerSync = new object();
        private Timer _cleanupTimer;

        /// <summary>
        /// Reset timer
        /// </summary>
        protected void ResetTimer()
        {
            Timer ct2;
            lock (_timerSync)
            {
                ct2 = Interlocked.Exchange(ref _cleanupTimer, null);
            }

            ct2?.Dispose();
        }

        /// <summary>
        /// Set cleanup
        /// </summary>
        /// <param name="mode"></param>
        public void SetCleanup(CleanupMode mode = CleanupMode.Deferred)
        {
            if (WasDisposed)
                return;

            switch (mode)
            {
                case CleanupMode.ImmediateSynchronousIfPastDue:
                    if (!IsRunning)
                        goto case CleanupMode.Deferred;

                    if (IsCleanupPastDue)
                        goto case CleanupMode.ImmediateSynchronous;

                    break;

                case CleanupMode.ImmediateSynchronous:
                    Cleanup();
                    break;

                case CleanupMode.ImmediateDeferredIfPastDue:
                    if (!IsRunning)
                        goto case CleanupMode.Deferred;

                    if (IsCleanupPastDue)
                        goto case CleanupMode.ImmediateDeferred;

                    break;

                case CleanupMode.ImmediateDeferred:
                    lock (_timerSync)
                    {
                        if (!WasDisposed && LastCleanup != DateTime.MaxValue)
                        {
                            // No past due action in order to prevent another thread from firing...
                            LastCleanup = DateTime.MaxValue;
                            DeferCleanup();
                            Task.Factory.StartNew(() => Cleanup());
                        }
                    }

                    break;

                case CleanupMode.Deferred:
                    DeferCleanup();
                    break;
            }
        }

        /// <summary>
        /// Defer cleanup
        /// </summary>
        public void DeferCleanup()
        {
            if (WasDisposed) return;
            lock (_timerSync)
            {
                if (WasDisposed) return;
                IsRunning = true;

                if (_cleanupTimer is null)
                    _cleanupTimer = new Timer(Cleanup, null, _cleanupDelay, Timeout.Infinite);
                else
                    _cleanupTimer.Change(_cleanupDelay, Timeout.Infinite);
            }
        }

        /// <summary>
        /// Clear cleanup
        /// </summary>
        public void ClearCleanup()
        {
            lock (_timerSync)
            {
                IsRunning = false;
                LastCleanup = DateTime.MaxValue;
                //if(_cleanupTimer!=null)
                //   _cleanupTimer.Change(Timeout.Infinite, Timeout.Infinite);
                ResetTimer();
            }
        }

        private void Cleanup(object state = null)
        {
            if (WasDisposed)
                return; // If another thread enters here after disposal don't allow.

            try
            {
                OnCleanup();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            lock (_timerSync)
            {
                LastCleanup = DateTime.Now;
            }
        }

        /// <summary>
        /// On cleanup
        /// </summary>
        protected abstract void OnCleanup();

        /// <inheritdoc />
        protected override void OnDispose()
        {
            ResetTimer();
        }

        /// <summary>
        /// Release DeferredCleanupBase
        /// </summary>
        ~DeferredCleanupBase()
        {
            ResetTimer();
        }

        /// <summary>
        /// Cleanup mode
        /// </summary>
        public enum CleanupMode
        {
            /// <summary>
            /// Cleanup immediately within the current thread.
            /// </summary>
            ImmediateSynchronous,

            /// <summary>
            /// Cleanup immediately if time is past due.
            /// </summary>
            ImmediateSynchronousIfPastDue,

            /// <summary>
            /// Cleanup immediately within another thread.
            /// </summary>
            ImmediateDeferred,

            /// <summary>
            /// Cleanup immedidately in another thread if time is past due.
            /// </summary>
            ImmediateDeferredIfPastDue,

            /// <summary>
            /// Extend the timer.
            /// </summary>
            Deferred
        }
    }
}