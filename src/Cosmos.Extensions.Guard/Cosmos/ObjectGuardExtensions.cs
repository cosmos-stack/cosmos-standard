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
    public static void CheckNull(this object argument, string argumentName, string message = null)
    {
        ObjectGuard.NotNull(argument, argumentName, message);
    }
}