namespace Cosmos.Reflection.Reflectors;

public partial class TypeReflector
{
    internal static TypeReflector Create(TypeInfo typeInfo)
    {
        if (typeInfo is null)
            throw new ArgumentNullException(nameof(typeInfo));
        return TypeReflections.ReflectorCacheUtils<TypeInfo, TypeReflector>.GetOrAdd(typeInfo, info => new TypeReflector(info));
    }
}