using NodaTime;

namespace Cosmos.Date;

/// <summary>
/// Period Date Builder<br />
/// 时间段构造器
/// </summary>
public class PeriodDateBuilder
{
    /// <summary>
    /// Create a new <see cref="PeriodDateBuilder"/> instance.<br />
    /// 构建一个新的 <see cref="PeriodDateBuilder"/> 实例。
    /// </summary>
    public PeriodDateBuilder() { }

    /// <summary>
    /// Create a new <see cref="PeriodDateBuilder"/> instance.<br />
    /// 构建一个新的 <see cref="PeriodDateBuilder"/> 实例。
    /// </summary>
    /// <param name="from"></param>
    public PeriodDateBuilder(DateTime from) : this(from.ToDateInfo(), InfiniteFutureInfo.Instance) { }

    /// <summary>
    /// Create a new <see cref="PeriodDateBuilder"/> instance.<br />
    /// 构建一个新的 <see cref="PeriodDateBuilder"/> 实例。
    /// </summary>
    /// <param name="from"></param>
    /// <param name="to"></param>
    public PeriodDateBuilder(DateTime from, DateTime to) : this(from.ToDateInfo(), to.ToDateInfo()) { }

    /// <summary>
    /// Create a new <see cref="PeriodDateBuilder"/> instance.<br />
    /// 构建一个新的 <see cref="PeriodDateBuilder"/> 实例。
    /// </summary>
    /// <param name="from"></param>
    public PeriodDateBuilder(DateInfo from) : this(from, InfiniteFutureInfo.Instance) { }

    /// <summary>
    /// Create a new <see cref="PeriodDateBuilder"/> instance.<br />
    /// 构建一个新的 <see cref="PeriodDateBuilder"/> 实例。
    /// </summary>
    /// <param name="from"></param>
    /// <param name="to"></param>
    public PeriodDateBuilder(DateInfo from, DateInfo to)
    {
        _diFrom = from ?? throw new ArgumentNullException(nameof(from));
        _diTo = to ?? throw new ArgumentNullException(nameof(to));
    }

    private DateInfo _diFrom;
    private DateInfo _diTo;

    /// <summary>
    /// From<br />
    /// 时间起始于...
    /// </summary>
    /// <param name="from"></param>
    /// <returns></returns>
    public PeriodDateBuilder From(DateInfo from)
    {
        _diFrom = from;
        return this;
    }

    /// <summary>
    /// To<br />
    /// 事件截止于...
    /// </summary>
    /// <param name="to"></param>
    /// <returns></returns>
    public PeriodDateBuilder To(DateInfo to)
    {
        _diTo = to;
        return this;
    }

    /// <summary>
    /// From<br />
    /// 时间起始于...
    /// </summary>
    /// <param name="from"></param>
    /// <returns></returns>
    public PeriodDateBuilder From(DateTime from) => From(from.ToDateInfo());

    /// <summary>
    /// From<br />
    /// 时间起始于...
    /// </summary>
    /// <param name="year"></param>
    /// <param name="month"></param>
    /// <param name="day"></param>
    /// <returns></returns>
    public PeriodDateBuilder From(int year, int month, int day) => From(new DateInfo(year, month, day));

    /// <summary>
    /// To<br />
    /// 事件截止于...
    /// </summary>
    /// <param name="to"></param>
    /// <returns></returns>
    public PeriodDateBuilder To(DateTime to) => To(to.ToDateInfo());

    /// <summary>
    /// To<br />
    /// 事件截止于...
    /// </summary>
    /// <param name="year"></param>
    /// <param name="month"></param>
    /// <param name="day"></param>
    /// <returns></returns>
    public PeriodDateBuilder To(int year, int month, int day) => To(new DateInfo(year, month, day));

    /// <summary>
    /// To<br />
    /// 事件截止于...
    /// </summary>
    /// <param name="days"></param>
    /// <returns></returns>
    public PeriodDateBuilder To(int days) => To(Duration.FromDays(days));

    /// <summary>
    /// To<br />
    /// 事件截止于...
    /// </summary>
    /// <param name="duration"></param>
    /// <returns></returns>
    public PeriodDateBuilder To(Duration duration) => To(_diFrom.DateTimeRef + duration.ToTimeSpan());

    /// <summary>
    /// Build<br />
    /// 构建
    /// </summary>
    /// <returns></returns>
    public PeriodDateInfo Build()
    {
        var instance = new PeriodDateInfo(_diFrom, _diTo);

        return instance;
    }
}