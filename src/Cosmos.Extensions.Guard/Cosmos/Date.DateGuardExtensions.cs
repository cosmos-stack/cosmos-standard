using Cosmos.Date;

namespace Cosmos;

/// <summary>
/// Date Guard Extensions <br />
/// 日期守护扩展
/// </summary>
public static class DateGuardExtensions
{
    /// <summary>
    /// Check if the date is valid. <br />
    /// If the date is invalid, an exception is thrown. <br />
    /// 检查日期是否有效。 <br />
    /// 如果日期是无效的，则抛出异常。
    /// </summary>
    /// <param name="argument"></param>
    /// <param name="argumentName"></param>
    /// <param name="message"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void RequireValidDate(this DateTime argument, [CallerArgumentExpression("argument")] string argumentName = null, string message = null)
    {
        DateGuard.ShouldBeValid(argument, argumentName, message);
    }

    /// <summary>
    /// Check if the date is valid. <br />
    /// If the date is invalid, an exception is thrown. <br />
    /// 检查日期是否有效。 <br />
    /// 如果日期是无效的，则抛出异常。
    /// </summary>
    /// <param name="argument"></param>
    /// <param name="argumentName"></param>
    /// <param name="message"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void RequireValidDate(this DateTime? argument, [CallerArgumentExpression("argument")] string argumentName = null, string message = null)
    {
        DateGuard.ShouldBeValid(argument, argumentName, message);
    }
}