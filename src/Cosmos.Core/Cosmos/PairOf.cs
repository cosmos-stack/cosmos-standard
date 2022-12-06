using Cosmos.Reflection;

namespace Cosmos;

/*
 * Modify from ZKWeb
 * Source: <see cref="https://github.com/zkweb-framework/ZKWeb/blob/master/ZKWeb/ZKWebStandard/Collections/Pair.cs"/>
 */

public struct PairOf<T1, T2> : IEquatable<PairOf<T1, T2>>
{
    public T1 Item1 { get; private set; }

    public T2 Item2 { get; private set; }

    public PairOf(T1 item1, T2 item2)
    {
        Item1 = item1;
        Item2 = item2;
    }

    public bool Equals(PairOf<T1, T2> obj)
    {
        if (Item1 is null && Item2 is null && obj.Item1 is null && obj.Item2 is null)
            return true;
        if (Item1 is null || Item2 is null)
            return false;
        return Item1.Equals(obj.Item1) && Item2.Equals(obj.Item2);
    }

    public override bool Equals(object obj) => obj is PairOf<T1, T2> of && Equals(of);

    public override int GetHashCode()
    {
        // same with Tuple.CombineHashCodes
        var hash1 = Item1?.GetHashCode() ?? 0;
        var hash2 = Item2?.GetHashCode() ?? 0;
        return (hash1 << 5) + hash1 ^ hash2;
    }

    public override string ToString() => $"({Item1?.ToString() ?? "null"}, {Item2?.ToString() ?? "null"})";

    public void Deconstruct(out T1 item1, out T2 item2)
    {
        item1 = Item1;
        item2 = Item2;
    }

    public static PairOf<T1, T2> New(T1 item1, T2 item2) => new(item1, item2);
}

public static class PairOf
{
    public static PairOf<T1, T2> New<T1, T2>(T1 item1, T2 item2) => PairOf<T1, T2>.New(item1, item2);

    public static TypePairOf New(Type source, Type target) => TypePairOf.Create(source, target);

    public static TypePairOf New<TSource, TTarget>() => TypePairOf.Create<TSource, TTarget>();
}