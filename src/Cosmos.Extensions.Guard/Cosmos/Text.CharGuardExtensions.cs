using Cosmos.Text;

namespace Cosmos;

/// <summary>
/// Char Guard Extensions <br />
/// 字符守护扩展
/// </summary>
public static class CharGuardExtensions
{
    /// <summary>
    /// Check whether the value is within the range.
    /// If the value is out of range, an exception is thrown.
    /// 检查 Char 值是否在范围内。
    /// 如果 Char 值超出范围，则抛出异常。
    /// </summary>
    /// <param name="argument"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <param name="argumentName"></param>
    /// <param name="message"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void RequireWithinRange(this char argument, char min, char max, [CallerArgumentExpression("argument")] string argumentName = null, string message = null)
    {
        CharGuard.ShouldBeWithinRange(argument, min, max, argumentName, message);
    }

    /// <summary>
    /// Check whether the value is within the range.
    /// If the value is out of range, an exception is thrown.
    /// 检查 Char 值是否在范围内。
    /// 如果 Char 值超出范围，则抛出异常。
    /// </summary>
    /// <param name="argument"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <param name="argumentName"></param>
    /// <param name="message"></param>
    /// <param name="options"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void RequireWithinRange(this char? argument, char min, char max, [CallerArgumentExpression("argument")] string argumentName = null, string message = null, CharMayOptions options = CharMayOptions.Default)
    {
        CharGuard.ShouldBeWithinRange(argument, min, max, argumentName, message, options);
    }
}