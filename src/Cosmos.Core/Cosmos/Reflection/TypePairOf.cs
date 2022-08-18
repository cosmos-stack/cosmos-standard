namespace Cosmos.Reflection;

public partial struct TypePairOf : IEquatable<TypePairOf>
{
    public TypePairOf(Type source, Type target) : this()
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
                var nullablePair = new TypePairOf(Nullable.GetUnderlyingType(Source), Nullable.GetUnderlyingType(Target));
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

    public static TypePairOf Create(Type source, Type target)
    {
        return new TypePairOf(source, target);
    }

    public static TypePairOf Create<TSource, TTarget>()
    {
        return new TypePairOf(typeof(TSource), typeof(TTarget));
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj))
        {
            return false;
        }

        return obj is TypePairOf && Equals((TypePairOf)obj);
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

    public bool Equals(TypePairOf other)
    {
        return Source == other.Source && Target == other.Target;
    }
}