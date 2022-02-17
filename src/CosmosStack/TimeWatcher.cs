using System.Diagnostics;

namespace Cosmos;

/// <summary>
/// Time watcher  <br />
/// 计时器
/// </summary>
public class TimeWatcher
{
    static TimeWatcher()
    {
        WatchObj = new Stopwatch();
        WatchObj.Start();
    }

    protected static readonly Stopwatch WatchObj;

    /// <summary>
    /// Get total milliseconds  <br />
    /// 获取总毫秒数
    /// </summary>
    /// <returns></returns>
    public static double GetTotalMilliseconds() => WatchObj.Elapsed.TotalMilliseconds;

    /// <summary>
    /// Get elapsed milliseconds <br />
    /// 获取经过的毫秒数
    /// </summary>
    /// <returns></returns>
    public static long GetElapsedMilliseconds() => WatchObj.ElapsedMilliseconds;

    /// <summary>
    /// Get total seconds <br />
    /// 获取总秒数
    /// </summary>
    /// <returns></returns>
    public static double GetTotalSeconds() => WatchObj.Elapsed.TotalSeconds;

    /// <summary>
    /// Get total minutes <br />
    /// 获取总分钟数
    /// </summary>
    /// <returns></returns>
    public static double GetTotalMinutes() => WatchObj.Elapsed.TotalMinutes;

    /// <summary>
    /// Get total hours <br />
    /// 获取总小时数
    /// </summary>
    /// <returns></returns>
    public static double GetTotalHours() => WatchObj.Elapsed.TotalHours;

    /// <summary>
    /// Get total days <br />
    /// 获取总天数
    /// </summary>
    /// <returns></returns>
    public static double GetTotalDays() => WatchObj.Elapsed.TotalDays;

    /// <summary>
    /// Get a new instance of <see cref="TimeWatcher"/> <br />
    /// 获取一个新的 <see cref="TimeWatcher"/> 实例。
    /// </summary>
    /// <returns></returns>
    public static TimeWatcher Get() => new();
}