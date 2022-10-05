// ReSharper disable InconsistentNaming

using Cosmos.Disposables;

namespace Cosmos.Asynchronous;

/// <summary>
/// Action runner <br />
/// 委托执行器
/// </summary>
public class ActionRunner : DisposableBase, ICancellable
{
    /// <summary>
    /// Create a new instance of <see cref="ActionRunner"/>
    /// </summary>
    /// <param name="action"></param>
    /// <param name="scheduler"></param>
    public ActionRunner(Action action, TaskScheduler scheduler = null)
    {
        _action = action;
        _scheduler = scheduler; // No need to hold a reference to the default, just keep it null.
        LastStart = DateTime.MaxValue;
        LastComplete = DateTime.MaxValue;
    }

    /// <summary>
    /// Create <br />
    /// 创建
    /// </summary>
    /// <param name="action"></param>
    /// <param name="scheduler"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ActionRunner Create(Action action, TaskScheduler scheduler = null)
    {
        return new ActionRunner(action, scheduler);
    }

    /// <summary>
    /// Create <br />
    /// 创建
    /// </summary>
    /// <param name="action"></param>
    /// <param name="scheduler"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ActionRunner Create<T>(Func<T> action, TaskScheduler scheduler = null)
    {
        return new ActionRunner(() => { action(); }, scheduler);
    }

    Action _action;

    // ReSharper disable once NotAccessedField.Global
    /// <summary>
    /// Task scheduler
    /// </summary>
    protected TaskScheduler _scheduler;

    /// <summary>
    /// Count
    /// </summary>
    protected int _count;

    /// <summary>
    /// Gets counrt
    /// </summary>
    public int Count => _count;

    /// <summary>
    /// The time last start
    /// </summary>
    public DateTime LastStart { get; protected set; }

    /// <summary>
    /// Has been run
    /// </summary>
    public bool HasBeenRun => LastStart < DateTime.Now;

    /// <summary>
    /// The time last complete
    /// </summary>
    public DateTime LastComplete { get; protected set; }

    /// <summary>
    /// Has completed
    /// </summary>
    public bool HasCompleted => LastComplete < DateTime.Now;

    /// <summary>
    /// Cancel
    /// </summary>
    /// <param name="onlyIfNotRunning"></param>
    /// <returns></returns>
    public bool Cancel(bool onlyIfNotRunning)
    {
        var t = _task;
        return t != null
            && t == Interlocked.CompareExchange(ref _task, null, t)
            && t.Cancel(onlyIfNotRunning);
    }

    /// <inheritdoc />
    public bool Cancel()
    {
        return Cancel(false);
    }
    
    protected override void OnDispose()
    {
        Cancel();
        _action = null;
        _scheduler = null;
    }

    Action GetAction()
    {
        var a = _action;
        if (a is null)
            throw new ObjectDisposedException(typeof(ActionRunner).ToString());
        return a;
    }

    /// <summary>
    /// Is scheduled
    /// </summary>
    public bool IsScheduled => _task?.IsActive() ?? false;

    /// <summary>
    /// Indiscriminately invokes the action.
    /// </summary>
    public void RunSynchronously()
    {
        GetAction().Invoke();
    }

    // ReSharper disable once UnusedMember.Local
    readonly object _taskLock = new();
    CancellableTask _task;

    CancellableTask Prepare()
    {
        LastStart = DateTime.Now;
        var task = CancellableTask.Init(GetAction());
        task
            .OnFaulted(_ => { })
            .OnFullfilled(() =>
            {
                LastComplete = DateTime.Now;
                Interlocked.Increment(ref _count);
            })
            .ContinueWith(_ => { Interlocked.CompareExchange(ref _task, null, task); });
        return task;
    }

    /// <summary>
    /// Run
    /// </summary>
    /// <returns></returns>
    public CancellableTask Run()
    {
        return Defer(TimeSpan.Zero);
    }

    /// <summary>
    /// Defer
    /// </summary>
    /// <param name="delay"></param>
    /// <param name="clearSchedule"></param>
    /// <returns></returns>
    public CancellableTask Defer(TimeSpan delay, bool clearSchedule = true)
    {
        if (clearSchedule)
        {
            Cancel(true); // Don't cancel defered if already running.
        }

        CancellableTask task;
        if ((task = _task) != null) return task;
        task = Prepare();
        if (null == Interlocked.CompareExchange(ref _task, task, null))
        {
            task.Start(delay);
        }

        return task;
    }

    /// <summary>
    /// Defer
    /// </summary>
    /// <param name="millisecondsDelay"></param>
    /// <param name="clearSchedule"></param>
    /// <returns></returns>
    public CancellableTask Defer(int millisecondsDelay, bool clearSchedule = true)
    {
        return Defer(TimeSpan.FromMilliseconds(millisecondsDelay), clearSchedule);
    }
}