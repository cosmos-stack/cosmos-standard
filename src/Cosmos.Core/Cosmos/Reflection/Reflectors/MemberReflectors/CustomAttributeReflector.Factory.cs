namespace Cosmos.Reflection.Reflectors;

public partial class CustomAttributeReflector
{
    internal static CustomAttributeReflector Create(CustomAttributeData customAttributeData)
    {
        return TypeReflections.ReflectorCacheUtils<CustomAttributeData, CustomAttributeReflector>.GetOrAdd(customAttributeData, data => new CustomAttributeReflector(data));
    }
}