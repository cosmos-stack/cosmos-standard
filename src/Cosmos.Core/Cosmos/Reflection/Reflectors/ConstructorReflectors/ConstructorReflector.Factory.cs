namespace Cosmos.Reflection.Reflectors;

public partial class ConstructorReflector
{
    internal static ConstructorReflector Create(ConstructorInfo constructorInfo)
    {
        ArgumentNullException.ThrowIfNull(constructorInfo);

        return TypeReflections.ReflectorCacheUtils<ConstructorInfo, ConstructorReflector>.GetOrAdd(constructorInfo, info =>
        {
            if (info.DeclaringType!.GetTypeInfo().ContainsGenericParameters)
                return new OpenGenericConstructorReflector(info);
            return new ConstructorReflector(info);
        });
    }
}