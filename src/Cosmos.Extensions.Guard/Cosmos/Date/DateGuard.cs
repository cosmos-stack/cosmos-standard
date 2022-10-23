namespace Cosmos.Date;

/// <summary>
/// Date Guard <br />
/// 日期守护
/// </summary>
public static class DateGuard
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
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static void ShouldBeValid(DateTime argument, string argumentName, string message = null)
    {
        ValidationExceptionHelper.WrapAndRaise<ArgumentInvalidException>(
            IsValid(argument),
            message ?? $"{nameof(argument)} is invalid datetime value.", argumentName);

        static bool IsValid(DateTime dt)
        {
            var min = new DateTime(1900, 1, 1);
            var max = new DateTime(9999, 12, 31, 23, 59, 59, 999);
            return dt >= min && dt <= max;
        }
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
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ShouldBeValid(DateTime? argument, string argumentName, string message = null)
    {
        ShouldBeValid(argument.SafeValue(), argumentName, message);
    }

    /// <summary>
    /// Check if the date is in the past. <br />
    /// If the date is not in the past, an exception is thrown. <br />
    /// 检查日期是否为过去的时间。 <br />
    /// 如果日期不是过去的时间，则抛出异常。
    /// </summary>
    /// <param name="argument"></param>
    /// <param name="argumentName"></param>
    /// <param name="message"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ShouldBeInThePast(DateTime argument, string argumentName, string message = null)
    {
        ValidationExceptionHelper.WrapAndRaise<ArgumentOutOfRangeException>(
            argument <= DateTime.UtcNow,
            argumentName, argument, message ?? $"The given time ({nameof(argument)}) should happen in the past.");
    }

    /// <summary>
    /// Check if the date is in the past. <br />
    /// If the date is not in the past, an exception is thrown. <br />
    /// 检查日期是否为过去的时间。 <br />
    /// 如果日期不是过去的时间，则抛出异常。
    /// </summary>
    /// <param name="argument"></param>
    /// <param name="argumentName"></param>
    /// <param name="message"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ShouldBeInThePast(DateTime? argument, string argumentName, string message = null)
    {
        ShouldBeInThePast(argument.SafeValue(), argumentName, message);
    }

    /// <summary>
    /// Check if the date is in the future. <br />
    /// If the date is not in the future, an exception is thrown. <br />
    /// 检查日期是否为将来的时间。 <br />
    /// 如果日期不是将来的时间，则抛出异常。
    /// </summary>
    /// <param name="argument"></param>
    /// <param name="argumentName"></param>
    /// <param name="message"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ShouldBeInTheFuture(DateTime argument, string argumentName, string message = null)
    {
        ValidationExceptionHelper.WrapAndRaise<ArgumentOutOfRangeException>(
            argument >= DateTime.UtcNow,
            argumentName, argument, message ?? $"The given time ({nameof(argument)}) should happen in the future.");
    }

    /// <summary>
    /// Check if the date is in the future. <br />
    /// If the date is not in the future, an exception is thrown. <br />
    /// 检查日期是否为将来的时间。 <br />
    /// 如果日期不是将来的时间，则抛出异常。
    /// </summary>
    /// <param name="argument"></param>
    /// <param name="argumentName"></param>
    /// <param name="message"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ShouldBeInTheFuture(DateTime? argument, string argumentName, string message = null)
    {
        ShouldBeInTheFuture(argument.SafeValue(), argumentName, message);
    }
}