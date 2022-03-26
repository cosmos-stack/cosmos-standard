// ReSharper disable ParameterOnlyUsedForPreconditionCheck.Local

namespace Cosmos.Date;

/// <summary>
/// Period DateInfo<br />
/// 时间段日期信息
/// </summary>
/// <typeparam name="TDateInfo"></typeparam>
public abstract class PeriodDateInfo<TDateInfo> where TDateInfo : DateInfo
{
    /// <summary>
    /// From
    /// </summary>
    // ReSharper disable once InconsistentNaming
    protected readonly TDateInfo _from;

    /// <summary>
    /// To
    /// </summary>
    // ReSharper disable once InconsistentNaming
    protected readonly TDateInfo _to;

    /// <summary>
    /// Is infinite future
    /// </summary>
    // ReSharper disable once InconsistentNaming
    protected readonly bool _isInfiniteFuture;

    /// <summary>
    /// Cache
    /// </summary>
    // ReSharper disable once InconsistentNaming
    protected readonly DateInfoCache<TDateInfo> _cache;

    /// <summary>
    /// Create a new <see cref="PeriodDateInfo{TDateInfo}"/> instance.<br />
    /// 创建一个新的 <see cref="PeriodDateInfo{TDateInfo}"/> 实例。
    /// </summary>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <param name="itemCreateFunc"></param>
    protected PeriodDateInfo(TDateInfo from, TDateInfo to, Func<TDateInfo, TDateInfo> itemCreateFunc)
    {
        PeriodChecker.CheckFromAndTo(from, to);
        _from = from;
        _to = to;
        _isInfiniteFuture = to is InfiniteFutureInfo;
        _cache = new DateInfoCache<TDateInfo>(itemCreateFunc);
    }

    /// <summary>
    /// Length of period date.<br />
    /// 时间段的长度
    /// </summary>
    public int Length => _isInfiniteFuture ? int.MaxValue : (_from.DateTimeRef - _to.DateTimeRef).Days + 1;

    /// <summary>
    /// From date<br />
    /// 时间起始于...
    /// </summary>
    public abstract TDateInfo From { get; }

    /// <summary>
    /// To date<br />
    /// 时间截止于...
    /// </summary>
    public abstract TDateInfo To { get; }

    private static class PeriodChecker
    {
        public static void CheckFromAndTo(TDateInfo from, TDateInfo to)
        {
            if (from is null) throw new ArgumentNullException(nameof(from));
            if (to is null) throw new ArgumentNullException(nameof(to));
            if (from.DateTimeRef > to.DateTimeRef)
                throw new ArgumentException("FromDateInfo cannot be greater than ToDateInfo.");
        }
    }

    /// <summary>
    /// Get all dates<br />
    /// 获取所有日期
    /// </summary>
    /// <returns></returns>
    public IEnumerable<TDateInfo> GetAllDates()
    {
        Initialize();
        foreach (var item in _cache)
            yield return item;
    }

    /// <summary>
    /// Initialize<br />
    /// 初始化
    /// </summary>
    protected virtual void Initialize() { }

    /// <summary>
    /// Indexer<br />
    /// 索引器
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public virtual TDateInfo this[int index]
    {
        get
        {
            Initialize();
            if (index >= _cache.Count())
                throw new ArgumentOutOfRangeException(nameof(index), index, "Index out of range.");
            return _cache.Get(index);
        }
    }
}