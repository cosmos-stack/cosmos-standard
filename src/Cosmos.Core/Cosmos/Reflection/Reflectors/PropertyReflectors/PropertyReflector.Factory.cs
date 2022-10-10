namespace Cosmos.Reflection.Reflectors;

public partial class PropertyReflector
{
    internal static PropertyReflector Create(PropertyInfo reflectionInfo, CallOptions callOption)
    {
        if (reflectionInfo is null)
            throw new ArgumentNullException(nameof(reflectionInfo));
        return TypeReflections.ReflectorCacheUtils<PairOf<PropertyInfo, CallOptions>, PropertyReflector>.GetOrAdd(new PairOf<PropertyInfo, CallOptions>(reflectionInfo, callOption), CreateInternal);

        PropertyReflector CreateInternal(PairOf<PropertyInfo, CallOptions> item)
        {
            var property = item.Item1;
            if (property.DeclaringType.GetTypeInfo().ContainsGenericParameters)
                return new OpenGenericPropertyReflector(property);

            if ((property.CanRead && property.GetMethod.IsStatic) || (property.CanWrite && property.SetMethod.IsStatic))
                return new StaticPropertyReflector(property);

            if (property.DeclaringType.GetTypeInfo().IsValueType || item.Item2 == CallOptions.Call)
                return new CallPropertyReflector(property);

            return new PropertyReflector(property);
        }
    }
}