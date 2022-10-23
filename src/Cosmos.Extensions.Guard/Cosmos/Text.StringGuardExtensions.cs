using Cosmos.Text;

namespace Cosmos;

/// <summary>
/// String Guard Extensions <br />
/// 字符串守护扩展
/// </summary>
public static class StringGuardExtensions
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
#if NETFRAMEWORK
    public static void Require(this string argument, string argumentName, string message = null)
#else
    public static void Require(this string argument, [CallerArgumentExpression("argument")] string argumentName = null, string message = null)
#endif
    {
        StringGuard.NotNull(argument, argumentName, message);
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
#if NETFRAMEWORK
    public static void RequireNotBlank(this string argument, string argumentName, string message = null)
#else
    public static void RequireNotBlank(this string argument, [CallerArgumentExpression("argument")] string argumentName = null, string message = null)
#endif
    {
        StringGuard.NotEmpty(argument, argumentName, message);
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
#if NETFRAMEWORK
    public static void RequireNotEmpty(this string argument, string argumentName, string message = null)
#else
    public static void RequireNotEmpty(this string argument, [CallerArgumentExpression("argument")] string argumentName = null, string message = null)
#endif
    {
        StringGuard.NotEmpty(argument, argumentName, message);
    }

    ///  <summary>
    /// Check whether the string exceeds the specified length.
    /// If the string exceeds the specified length, an exception is thrown.
    /// 检查字符串是否超过指定长度。
    /// 如果字符串超过指定长度，则抛出异常。
    ///  </summary>
    ///  <param name="argument"></param>
    ///  <param name="length"></param>
    ///  <param name="argumentName"></param>
    ///  <param name="message"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NETFRAMEWORK
    public static void RequireMaxLength(this string argument, int length, string argumentName, string message = null)
#else
    public static void RequireMaxLength(this string argument, int length, [CallerArgumentExpression("argument")] string argumentName = null, string message = null)
#endif
    {
        StringGuard.NotOutOfLength(argument, length, argumentName, message);
    }
}