using Cosmos.Reflection;

namespace Cosmos;

public static class Pair
{
    public static PairOf<T1, T2> Of<T1, T2>(T1 item1, T2 item2) => PairOf<T1, T2>.New(item1, item2);

    public static TypePairOf OfType(Type source, Type target) => TypePairOf.Create(source, target);

    public static TypePairOf OfType<TSource, TTarget>() => TypePairOf.Create<TSource, TTarget>();
}