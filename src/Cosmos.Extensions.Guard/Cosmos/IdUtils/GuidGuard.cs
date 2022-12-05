namespace Cosmos.IdUtils;

/// <summary>
/// Guid Guard <br />
/// GUID 守护
/// </summary>
public static class GuidGuard
{
    /// <summary>
    /// Check if Guid is empty or null. <br />
    /// If it is empty or null, an exception is thrown. <br />
    /// 检查 Guid 是否为空。 <br />
    /// 如果为空，则抛出异常。
    /// </summary>
    /// <param name="argument"></param>
    /// <param name="argumentName"></param>
    /// <param name="message"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ShouldBeValid(Guid argument, [CallerArgumentExpression(nameof(argument))] string argumentName = null, string message = null)
    {
        ValidationExceptionHelper.WrapAndRaise<ArgumentNullException>(
            !argument.IsNullOrEmpty(),
            argumentName, message ?? $"{nameof(argument)} can not be null or empty.");
    }

    /// <summary>
    /// Check if Guid is empty or null. <br />
    /// If it is empty or null, an exception is thrown. <br />
    /// 检查 Guid 是否为空。 <br />
    /// 如果为空，则抛出异常。
    /// </summary>
    /// <param name="argument"></param>
    /// <param name="argumentName"></param>
    /// <param name="message"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ShouldBeValid(Guid? argument, [CallerArgumentExpression(nameof(argument))] string argumentName = null, string message = null)
    {
        ShouldBeValid(argument.SafeValue(), argumentName, message);
    }
}