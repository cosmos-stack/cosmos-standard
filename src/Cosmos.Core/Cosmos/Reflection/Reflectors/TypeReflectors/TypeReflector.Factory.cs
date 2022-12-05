namespace Cosmos.Reflection.Reflectors;

public partial class TypeReflector
{
    internal static TypeReflector Create(TypeInfo typeInfo)
    {
        ArgumentNullException.ThrowIfNull(typeInfo);
        return TypeReflections.ReflectorCacheUtils<TypeInfo, TypeReflector>.GetOrAdd(typeInfo, info => new TypeReflector(info));
    }
}