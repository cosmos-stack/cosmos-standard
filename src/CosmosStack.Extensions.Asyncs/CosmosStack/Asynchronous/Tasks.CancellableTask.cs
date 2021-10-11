using System;
using System.Threading;
using System.Threading.Tasks;

namespace CosmosStack.Asynchronous
{
    /// <summary>
    /// Cancelable Task <br />
    /// 可取消的任务
    /// </summary>
    public class CancellableTask : Task, ICancellable
    {
        /// <summary>
        /// Token source
        /// </summary>
        protected CancellationTokenSource TokenSource;

        /// <summary>
        /// Cancel
        /// </summary>
        /// <param name="onlyIfNotRunning"></param>
        /// <returns></returns>
        public bool Cancel(bool onlyIfNotRunning)
        {
            // Cancel can only be called once.
            var ts = Interlocked.Exchange(ref TokenSource, null);

            if (ts is null || ts.IsCancellationRequested || IsCanceled || IsFaulted || IsCompleted)
                return false;

            var isRunning = Status == TaskStatus.Running;
            if (!onlyIfNotRunning || !isRunning)
                ts.Cancel();

            return !isRunning;
        }

        /// <inheritdoc />
        public bool Cancel()
        {
            return Cancel(false);
        }

        /// <summary>
        /// Blank
        /// </summary>
        protected static void Blank() { }

        /// <inheritdoc />
        protected override void Dispose(bool disposing)
        {
            Cancel();
            base.Dispose(disposing);
        }

        /// <inheritdoc />
        protected CancellableTask(Action action, CancellationToken token) : base(action ?? Blank, token) { }

        /// <inheritdoc />
        protected CancellableTask(Action action) : base(action ?? Blank) { }

        /// <inheritdoc />
        protected CancellableTask(CancellationToken token) : this(Blank, token) { }

        /// <inheritdoc />
        protected CancellableTask() : this(Blank) { }

        /// <summary>
        /// Only allow for static initialization because this owns the TokenSource.
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public static CancellableTask Init(Action action = null)
        {
            var ts = new CancellationTokenSource();
            var token = ts.Token;
            return new CancellableTask(action, token)
            {
                // Could potentially call cancel before run actually happens.
                TokenSource = ts
            };
        }

        /// <summary>
        /// Start
        /// </summary>
        /// <param name="delay"></param>
        /// <param name="scheduler"></param>
        public void Start(TimeSpan delay, TaskScheduler scheduler = null)
        {
            if (delay < TimeSpan.Zero)
            {
                RunSynchronously();
            }
            else if (delay == TimeSpan.Zero)
            {
                if (scheduler is null)
                    Start();
                else
                    Start(scheduler);
            }
            else
            {
                var runState = 0;

                ContinueWith(t =>
                {
                    // If this is arbitrarily run before the delay, then cancel the delay.
                    if (Interlocked.Increment(ref runState) < 2)
                        Cancel();
                });

                Delay(delay, TokenSource.Token)
                   .OnFullfilled(() =>
                    {
                        Interlocked.Increment(ref runState);
                        this.EnsureStarted(scheduler);
                    });
            }
        }

        /// <summary>
        /// Start
        /// </summary>
        /// <param name="millisecondsDelay"></param>
        /// <param name="scheduler"></param>
        public void Start(int millisecondsDelay, TaskScheduler scheduler = null)
        {
            Start(TimeSpan.FromMilliseconds(millisecondsDelay), scheduler);
        }

        /// <summary>
        /// Start new
        /// </summary>
        /// <param name="delay"></param>
        /// <param name="action"></param>
        /// <param name="scheduler"></param>
        /// <returns></returns>
        public static CancellableTask StartNew(TimeSpan delay, Action action = null, TaskScheduler scheduler = null)
        {
            var task = new CancellableTask(action);
            task.Start(delay, scheduler);
            return task;
        }

        /// <summary>
        /// Start new
        /// </summary>
        /// <param name="millisecondsDelay"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static CancellableTask StartNew(int millisecondsDelay, Action action = null)
        {
            return StartNew(TimeSpan.FromMilliseconds(millisecondsDelay), action);
        }

        /// <summary>
        /// Start new
        /// </summary>
        /// <param name="action"></param>
        /// <param name="delay"></param>
        /// <param name="scheduler"></param>
        /// <returns></returns>
        public static CancellableTask StartNew(Action action, TimeSpan? delay = null, TaskScheduler scheduler = null)
        {
            return StartNew(delay ?? TimeSpan.Zero, action, scheduler);
        }

        /// <summary>
        /// Start new
        /// </summary>
        /// <param name="action"></param>
        /// <param name="delay"></param>
        /// <param name="scheduler"></param>
        /// <returns></returns>
        public static CancellableTask StartNew(Action<CancellationToken> action, TimeSpan? delay = null, TaskScheduler scheduler = null)
        {
            var ts = new CancellationTokenSource();
            var token = ts.Token;
            var task = new CancellableTask(() => action(token), token)
            {
                TokenSource = ts
            };
            task.Start(delay ?? TimeSpan.Zero, scheduler);
            return task;
        }
    }
}