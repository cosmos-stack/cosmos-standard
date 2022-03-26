namespace Cosmos.Reflection;

public struct TypePairInfo : IEquatable<TypePairInfo>
{
    public TypePairInfo(Type source, Type target) : this()
    {
        Target = target;
        Source = source;
    }

    public bool IsDeepCloneable
    {
        get
        {
            if (IsEqualTypes == false)
            {
                return false;
            }

            if (IsValueTypes && IsPrimitiveTypes)
            {
                return true;
            }

            if (Source == typeof(string) || Source == typeof(decimal) ||
                Source == typeof(DateTime) || Source == typeof(DateTimeOffset) ||
                Source == typeof(TimeSpan) || Source == typeof(Guid))
            {
                return true;
            }

            if (IsNullableTypes)
            {
                var nullablePair = new TypePairInfo(Nullable.GetUnderlyingType(Source), Nullable.GetUnderlyingType(Target));
                return nullablePair.IsDeepCloneable;
            }

            return false;
        }
    }

    public bool IsEnumTypes => Types.IsEnumType(Source) && Types.IsEnumType(Target);

    public bool IsEnumerableTypes => Types.IsCollectionType(Source) && Types.IsCollectionType(Target);

    public bool IsNullableToNotNullable => Types.IsNullableType(Source) && Types.IsNullableType(Target) == false;

    public Type Source { get; }
    public Type Target { get; }

    private bool IsEqualTypes => Source == Target;

    private bool IsNullableTypes => Types.IsNullableType(Source) && Types.IsNullableType(Target);

    private bool IsPrimitiveTypes => Types.IsPrimitiveType(Source) && Types.IsPrimitiveType(Target);

    private bool IsValueTypes => Types.IsValueType(Source) && Types.IsValueType(Target);

    public static TypePairInfo Create(Type source, Type target)
    {
        return new TypePairInfo(source, target);
    }

    public static TypePairInfo Create<TSource, TTarget>()
    {
        return new TypePairInfo(typeof(TSource), typeof(TTarget));
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj))
        {
            return false;
        }

        return obj is TypePairInfo && Equals((TypePairInfo)obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((Source != null ? Source.GetHashCode() : 0) * 397) ^ (Target != null ? Target.GetHashCode() : 0);
        }
    }

    public bool HasTypeConverter()
    {
        return TypeConvertersManager.HasTypeConverter(this);
    }

    public bool Equals(TypePairInfo other)
    {
        return Source == other.Source && Target == other.Target;
    }
}