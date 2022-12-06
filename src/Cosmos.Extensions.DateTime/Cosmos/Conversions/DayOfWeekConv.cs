namespace Cosmos.Conversions;

/// <summary>
/// DayOfWeek Convertor <br />
/// 周转换器
/// </summary>
public static class DayOfWeekConv
{
    /// <summary>
    /// Convert <see cref="DayOfWeek"/> to <see cref="int"/><br />
    /// 将 <see cref="DayOfWeek"/> 转换为 <see cref="int"/>。
    /// </summary>
    /// <param name="week"></param>
    /// <returns></returns>
    public static int ToInt32(DayOfWeek week)
    {
        return ToInt32(week, 1);
    }

    /// <summary>
    /// Convert <see cref="DayOfWeek"/> to <see cref="int"/><br />
    /// 将 <see cref="DayOfWeek"/> 转换为 <see cref="int"/>。
    /// </summary>
    /// <param name="week"></param>
    /// <param name="offset"></param>
    /// <returns></returns>
    public static int ToInt32(DayOfWeek week, int offset)
    {
        return offset + week switch
        {
            DayOfWeek.Sunday => 0,
            DayOfWeek.Monday => 1,
            DayOfWeek.Tuesday => 2,
            DayOfWeek.Wednesday => 3,
            DayOfWeek.Thursday => 4,
            DayOfWeek.Friday => 5,
            DayOfWeek.Saturday => 6,
            _ => 0
        };
    }
}

/// <summary>
/// Cosmos.Core <see cref="DayOfWeek"/> extensions.<br />
/// 周转换器扩展
/// </summary>
public static class DayOfWeekConvExtensions
{
    /// <summary>
    /// Convert <see cref="DayOfWeek"/> to <see cref="int"/><br />
    /// 将 <see cref="DayOfWeek"/> 转换为 <see cref="int"/>。
    /// </summary>
    /// <param name="week"></param>
    /// <returns></returns>
    public static int CastToInt32(this DayOfWeek week) => DayOfWeekConv.ToInt32(week);

    /// <summary>
    /// Convert <see cref="DayOfWeek"/> to <see cref="int"/><br />
    /// 将 <see cref="DayOfWeek"/> 转换为 <see cref="int"/>。
    /// </summary>
    /// <param name="week"></param>
    /// <param name="offset"></param>
    /// <returns></returns>
    public static int CastToInt32(this DayOfWeek week, int offset) => DayOfWeekConv.ToInt32(week, offset);
}