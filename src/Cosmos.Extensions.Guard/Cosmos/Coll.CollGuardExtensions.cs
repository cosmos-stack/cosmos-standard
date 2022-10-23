using System.Collections;
using Cosmos.Collections;

namespace Cosmos;

/// <summary>
/// Collection Guard Extensions <br />
/// 集合守护扩展
/// </summary>
public static class CollGuardExtensions
{
    /// <summary>
    /// Check if the collection is empty or null. <br />
    /// If the collection is empty or null, an exception is thrown. <br />
    /// 检查集合是否为空。 <br />
    /// 如果集合为空，则抛出异常。
    /// </summary>
    /// <param name="argument"></param>
    /// <param name="argumentName"></param>
    /// <param name="message"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NETFRAMEWORK
    public static void Require(this IEnumerable argument, string argumentName, string message = null)
#else
    public static void Require(this IEnumerable argument, [CallerArgumentExpression("argument")] string argumentName = null, string message = null)
#endif
    {
        CollGuard.ShouldBeNotNull(argument, argumentName, message);
    }

    /// <summary>
    /// Check if the key/value pair is empty or null. <br />
    /// If the key/value pair is empty or null, an exception is thrown. <br />
    /// 检查键值对是否为空。 <br />
    /// 如果键值对为空，则抛出异常。
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <param name="argument"></param>
    /// <param name="argumentName"></param>
    /// <param name="message"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NETFRAMEWORK
    public static void Require<TKey, TValue>(this KeyValuePair<TKey, TValue> argument, string argumentName, string message = null)
#else
    public static void Require<TKey, TValue>(this KeyValuePair<TKey, TValue> argument, [CallerArgumentExpression("argument")] string argumentName = null, string message = null)
#endif
    {
        CollGuard.ShouldBeNotNull(argument, argumentName, message);
    }

    /// <summary>
    /// Check whether the set contains at least the specified number of elements. <br />
    /// If the set is less than the specified number of elements, an exception is thrown. <br />
    /// 检查集合是否包含至少指定个数的元素。 <br />
    /// 如果集合少于指定数目的元素，则抛出异常。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="argument"></param>
    /// <param name="argumentName"></param>
    /// <param name="number"></param>
    /// <param name="message"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NETFRAMEWORK
    public static void RequireAtLeast<T>(this ICollection<T> argument, int number, string argumentName, string message = null)
#else
    public static void RequireAtLeast<T>(this ICollection<T> argument, int number, [CallerArgumentExpression("argument")] string argumentName = null, string message = null)
#endif
    {
        CollGuard.ShouldContainAtLeast(argument, number, argumentName, message);
    }
}