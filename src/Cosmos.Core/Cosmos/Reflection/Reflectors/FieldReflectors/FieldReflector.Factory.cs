namespace Cosmos.Reflection.Reflectors;

public partial class FieldReflector
{
    internal static FieldReflector Create(FieldInfo reflectionInfo)
    {
        ArgumentNullException.ThrowIfNull(reflectionInfo);

        return TypeReflections.ReflectorCacheUtils<FieldInfo, FieldReflector>.GetOrAdd(reflectionInfo, CreateInternal);

        FieldReflector CreateInternal(FieldInfo field)
        {
            if (field.DeclaringType!.GetTypeInfo().ContainsGenericParameters)
                return new OpenGenericFieldReflector(field);

            if (field.DeclaringType!.IsEnum)
                return new EnumFieldReflector(field);

            if (field.IsStatic)
                return new StaticFieldReflector(field);

            return new FieldReflector(field);
        }
    }
}