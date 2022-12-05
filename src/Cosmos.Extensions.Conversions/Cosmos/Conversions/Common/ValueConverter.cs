using Cosmos.Conversions.Common.Core;

// ReSharper disable InconsistentNaming

namespace Cosmos.Conversions.Common;

/// <summary>
/// Helper
/// </summary>
// ReSharper disable once InconsistentNaming
internal static class ValueConverter
{
    public static Action<X> ConvertAct<X>(Action<object> action) /*where X : struct*/ =>
        action is null ? default! : new Action<X>(o => action(o));

    public static Action<object> ConvertAct<X>(Action<X> action) /*where X : struct*/ =>
        action is null ? default! : new Action<object>(o => action.Invoke((X)o));

    /// <summary>
    /// To xxx
    /// </summary>
    /// <param name="from"></param>
    /// <param name="firstImpl"></param>
    /// <param name="impls"></param>
    /// <typeparam name="O"></typeparam>
    /// <typeparam name="X"></typeparam>
    /// <returns></returns>
    // ReSharper disable once InconsistentNaming
    public static X ToXxx<O, X>(
        O from,
        Func<O, Action<X>, bool> firstImpl,
        IEnumerable<IConversionImpl<O, X>> impls)
    {
        X result = default;
        if (firstImpl(from, to => result = to))
            return result;
        if (impls is null)
            return result;
        if (impls.Any(impl => impl.TryTo(from, out result)))
            return result;
        return result;
    }

    public static X ToXxxAgain<X>(string str, X defaultVal)
    {
        return XConvHelper.T(() => Convert.ChangeType(str, typeof(X)).AsOr(defaultVal), defaultVal);
    }
}