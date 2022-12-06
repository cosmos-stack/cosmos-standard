namespace Cosmos.Conversions;

public static class TimeSpanConv
{
    /// <summary>
    /// To datetime <br />
    /// 转换为 DateTime
    /// </summary>
    /// <param name="time"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static DateTime ToDateTime(TimeSpan time)
    {
        var ticks = time.Ticks;
        if (ticks is < 0 or > 3155378975999999999)
            throw new ArgumentOutOfRangeException(nameof(time));
        return new(ticks);
    }
}

public static class TimeSpanConvExtensions
{
    /// <summary>
    /// To datetime <br />
    /// 转换为 DateTime
    /// </summary>
    /// <param name="time"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static DateTime CastToDateTime(this TimeSpan time) => TimeSpanConv.ToDateTime(time);
}