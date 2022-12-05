namespace Cosmos.Text;

/// <summary>
/// String Guard <br />
/// 字符串守护
/// </summary>
public static class StringGuard
{
    /// <summary>
    /// Check if the string is null, empty or blank. <br />
    /// If the string is null, empty or blank, an exception is thrown. <br />
    /// 检查字符串是否为空或空白。 <br />
    /// 如果字符串为空或空白，则抛出异常。
    /// </summary>
    /// <param name="argument"></param>
    /// <param name="argumentName"></param>
    /// <param name="message"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void NotNull(string argument, [CallerArgumentExpression(nameof(argument))] string argumentName = null, string message = null)
    {
        ValidationExceptionHelper.WrapAndRaise<ArgumentNullException>(
            !string.IsNullOrWhiteSpace(argument),
            argumentName, message ?? $"{nameof(argument)} can not be null or white space.");
    }

    /// <summary>
    /// Check if the string is empty or blank. <br />
    /// If the string is empty or blank, an exception is thrown. <br />
    /// 检查字符串是否为空或空白。 <br />
    /// 如果字符串为空或空白，则抛出异常。
    /// </summary>
    /// <param name="argument"></param>
    /// <param name="argumentName"></param>
    /// <param name="message"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void NotEmpty(string argument, [CallerArgumentExpression(nameof(argument))] string argumentName = null, string message = null)
    {
        ValidationExceptionHelper.WrapAndRaise<ArgumentNullException>(
            !string.IsNullOrEmpty((argument ?? string.Empty).Trim()),
            argumentName, message ?? $"{nameof(argument)} can not be blank.");
    }

    /// <summary>
    /// Check if the string is empty or blank. <br />
    /// If the string is empty or blank, an exception is thrown. <br />
    /// 检查字符串是否为空或空白。 <br />
    /// 如果字符串为空或空白，则抛出异常。
    /// </summary>
    /// <param name="argument"></param>
    /// <param name="argumentName"></param>
    /// <param name="message"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void NotBlank(string argument, [CallerArgumentExpression(nameof(argument))] string argumentName = null, string message = null)
    {
        NotEmpty(argument, argumentName, message);
    }

    /// <summary>
    /// Check whether the string exceeds the specified length.
    /// If the string exceeds the specified length, an exception is thrown.
    /// 检查字符串是否超过指定长度。
    /// 如果字符串超过指定长度，则抛出异常。
    /// </summary>
    /// <param name="argument"></param>
    /// <param name="length"></param>
    /// <param name="argumentName"></param>
    /// <param name="message"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void NotOutOfLength(string argument, int length, [CallerArgumentExpression(nameof(argument))] string argumentName = null, string message = null)
    {
        ValidationExceptionHelper.WrapAndRaise<ArgumentOutOfRangeException>(
            argument.Trim().Length <= length,
            argumentName, argument.Trim().Length, message ?? $"{nameof(argument)}'s length can not be greater than {length}.");
    }
}