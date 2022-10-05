namespace Cosmos.Collections;

/// <summary>
/// Collections Utilities <br />
/// 集合工具
/// </summary>
public static partial class Colls
{
    public static void InvokeForEach<T, TState>(IEnumerable<T> sourceColl, Action<T, TState> loopAct, TState state)
    {
        if (state is null)
            throw new ArgumentNullException(nameof(state));
        if (loopAct is null)
            throw new ArgumentNullException(nameof(loopAct));
        foreach (var source in sourceColl)
        {
            loopAct.Invoke(source, state);
        }
    }

    public static void InvokeForEach<T, TState>(IEnumerable<T> sourceColl, Action<T, int, TState> loopAct, TState state)
    {
        if (state is null)
            throw new ArgumentNullException(nameof(state));
        if (loopAct is null)
            throw new ArgumentNullException(nameof(loopAct));
        var index = 0;
        foreach (var source in sourceColl)
        {
            loopAct.Invoke(source, index++, state);
        }
    }

    public static TState InvokeForEach<T, TState>(IEnumerable<T> sourceColl, Func<T, TState, TState> loopFunc, TState state)
    {
        if (state is null)
            throw new ArgumentNullException(nameof(state));
        if (loopFunc is null)
            throw new ArgumentNullException(nameof(loopFunc));

        return sourceColl.Aggregate(state, (current, source) => loopFunc.Invoke(source, current));
    }

    public static TState InvokeForEach<T, TState>(IEnumerable<T> sourceColl, Func<T, int, TState, TState> loopFunc, TState state)
    {
        if (state is null)
            throw new ArgumentNullException(nameof(state));
        if (loopFunc is null)
            throw new ArgumentNullException(nameof(loopFunc));
        var index = 0;

        return sourceColl.Aggregate(state, (current, source) => loopFunc.Invoke(source, index++, current));
    }
}

/// <summary>
/// Collection Utilities Extensions <br />
/// 集合工具扩展
/// </summary>
public static partial class CollsExtensions
{
    public static void InvokeForEach<T, TState>(this IEnumerable<T> sourceColl, Action<T, TState> loopAct, TState state)
    {
        Colls.InvokeForEach(sourceColl, loopAct, state);
    }

    public static void InvokeForEach<T, TState>(this IEnumerable<T> sourceColl, Action<T, int, TState> loopAct, TState state)
    {
        Colls.InvokeForEach(sourceColl, loopAct, state);
    }

    public static TState InvokeForEach<T, TState>(this IEnumerable<T> sourceColl, Func<T, TState, TState> loopFunc, TState state)
    {
        return Colls.InvokeForEach(sourceColl, loopFunc, state);
    }

    public static TState InvokeForEach<T, TState>(this IEnumerable<T> sourceColl, Func<T, int, TState, TState> loopFunc, TState state)
    {
        return Colls.InvokeForEach(sourceColl, loopFunc, state);
    }
}