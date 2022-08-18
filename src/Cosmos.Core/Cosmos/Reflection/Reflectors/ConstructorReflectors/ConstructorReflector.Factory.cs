namespace Cosmos.Reflection.Reflectors;

public partial class ConstructorReflector
{
    internal static ConstructorReflector Create(ConstructorInfo constructorInfo)
    {
        if (constructorInfo is null)
            throw new ArgumentNullException(nameof(constructorInfo));

        return TypeReflections.ReflectorCacheUtils<ConstructorInfo, ConstructorReflector>.GetOrAdd(constructorInfo, info =>
        {
            if (info.DeclaringType.GetTypeInfo().ContainsGenericParameters)
                return new OpenGenericConstructorReflector(info);
            return new ConstructorReflector(info);
        });
    }
}