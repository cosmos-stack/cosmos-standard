using Cosmos.IdUtils;

namespace Cosmos;

/// <summary>
/// Guid Guard Extensions <br />
/// GUID 守护扩展
/// </summary>
public static class GuidGuardExtensions
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
    public static void Require(this Guid argument, [CallerArgumentExpression("argument")] string argumentName = null, string message = null)
    {
        GuidGuard.ShouldBeValid(argument, argumentName, message);
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
    public static void Require(this Guid? argument, [CallerArgumentExpression("argument")] string argumentName = null, string message = null)
    {
        GuidGuard.ShouldBeValid(argument, argumentName, message);
    }
}