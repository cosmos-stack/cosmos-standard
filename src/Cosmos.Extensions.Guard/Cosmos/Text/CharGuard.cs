﻿namespace Cosmos.Text;

internal static class CharGuardHelper
{
    public static T? C<T>(T? x, CharMayOptions options, string argumentName, string message = null) where T : struct
    {
        if (options is CharMayOptions.Default)
            ValidationExceptionHelper.WrapAndRaise<ArgumentNullException>(
                x is not null,
                argumentName, message ?? $"The given nullable char should not be null.");
        return x;
    }
}

/// <summary>
/// Char Guard <br />
/// 字符守护
/// </summary>
public static class CharGuard
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
    public static void ShouldBeWithinRange(char argument, char min, char max, [CallerArgumentExpression(nameof(argument))] string argumentName = null, string message = null)
    {
        ValidationExceptionHelper.WrapAndRaise<ArgumentOutOfRangeException>(
            CharJudge.IsBetween(argument, min, max),
            argumentName, argument, message ?? $"The given number ({nameof(argument)} = {argument}) should be between [{min}, {max}].");
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
    public static void ShouldBeWithinRange(char? argument, char min, char max, [CallerArgumentExpression(nameof(argument))] string argumentName = null, string message = null, CharMayOptions options = CharMayOptions.Default)
    {
        ShouldBeWithinRange(CharGuardHelper.C(argument, options, argumentName, message).SafeValue(), min, max, argumentName, message);
    }
}