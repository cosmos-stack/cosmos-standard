namespace Cosmos;

public static class ObjectGuardExtensions
{
    /// <summary>
    /// Check if the object is empty.
    /// If the object is empty, an exception is thrown.
    /// 检查对象是否为空。
    /// 如果对象为空，则抛出异常。
    /// </summary>
    /// <param name="argument">对象</param>
    /// <param name="argumentName">参数名</param>
    /// <param name="message">消息</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NETFRAMEWORK
    public static void Require(this object argument, string argumentName, string message = null)
#else
    public static void Require(this object argument, [CallerArgumentExpression("argument")] string argumentName = null, string message = null)
#endif
    {
        ObjectGuard.NotNull(argument, argumentName, message);
    }
}