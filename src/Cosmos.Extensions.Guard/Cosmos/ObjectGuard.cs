﻿namespace Cosmos;

/// <summary>
/// Object Guard <br />
/// 对象守护
/// </summary>
public static class ObjectGuard
{
    /// <summary>
    /// Check if the object is empty.
    /// If the object is empty, an exception is thrown.
    /// 检查对象是否为空。
    /// 如果对象为空，则抛出异常。
    /// </summary>
    /// <param name="argument"></param>
    /// <param name="argumentName"></param>
    /// <param name="message"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void NotNull(object argument, string argumentName, string message = null)
    {
        ValidationExceptionHelper.WrapAndRaise<ArgumentNullException>(
            argument is not null,
            argumentName, message ?? $"{nameof(argument)} can not be null.");
    }
}