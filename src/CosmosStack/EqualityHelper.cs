using System.Runtime.CompilerServices;

/*
 * Reference to:
 *      zlzforever/MSFramework
 *      Author: Zlzforever
 *      URL: https://github.com/zlzforever/MSFramework
 *      MIT
 */

namespace Cosmos;

/// <summary>
/// 相等比较，用于快速创建<see cref="IEqualityComparer{T}"/>的实例
/// </summary>
/// <example>
/// var equalityComparer1 = EqualityHelper[Person].CreateComparer(p => p.ID);
/// var equalityComparer2 = EqualityHelper[Person].CreateComparer(p => p.Name);
/// var equalityComparer3 = EqualityHelper[Person].CreateComparer(p => p.Birthday.Year);
/// </example>
public static class EqualityHelper<T>
{
    /// <summary>
    /// Create comparer <br />
    /// 创建比较器
    /// </summary>
    /// <typeparam name="TV"></typeparam>
    /// <param name="keySelector"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEqualityComparer<T> CreateComparer<TV>(Func<T?, TV?> keySelector)
        => new CommonEqualityComparer<TV>(keySelector);

    /// <summary>
    /// Create comparer <br />
    /// 创建比较器
    /// </summary>
    /// <typeparam name="TV"></typeparam>
    /// <param name="keySelector"></param>
    /// <param name="comparer"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEqualityComparer<T> CreateComparer<TV>(Func<T?, TV?> keySelector, IEqualityComparer<TV> comparer)
        => new CommonEqualityComparer<TV>(keySelector, comparer);

    private class CommonEqualityComparer<TV> : IEqualityComparer<T>
    {
        private readonly IEqualityComparer<TV> _comparer;
        private readonly Func<T?, TV?> _keySelector;

        public CommonEqualityComparer(Func<T?, TV?> keySelector, IEqualityComparer<TV> comparer)
        {
            _keySelector = keySelector;
            _comparer = comparer;
        }

        public CommonEqualityComparer(Func<T?, TV?> keySelector) : this(keySelector, EqualityComparer<TV>.Default) { }

        public bool Equals(T? x, T? y) => _comparer.Equals(_keySelector(x), _keySelector(y));

        public int GetHashCode(T? obj) => _comparer.GetHashCode(_keySelector(obj)!);
    }
}