namespace Cosmos.Reflection;

public static partial class Types
{
    public static object GetDefaultValue(TypeInfo typeInfo)
    {
        if (typeInfo is null)
            throw new ArgumentNullException(nameof(typeInfo));

        if (typeInfo.AsType() == typeof(void))
            return null;

        switch (Type.GetTypeCode(typeInfo.AsType()))
        {
            case TypeCode.Object:
            case TypeCode.DateTime:
                return typeInfo.IsValueType ? Activator.CreateInstance(typeInfo.AsType()) : null;

            case TypeCode.Empty:
            case TypeCode.String:
                return null;

            case TypeCode.Boolean:
            case TypeCode.Char:
            case TypeCode.SByte:
            case TypeCode.Byte:
            case TypeCode.Int16:
            case TypeCode.UInt16:
            case TypeCode.Int32:
            case TypeCode.UInt32:
                return 0;

            case TypeCode.Int64:
            case TypeCode.UInt64:
                return 0;

            case TypeCode.Single:
                return default(Single);

            case TypeCode.Double:
                return default(Double);

            case TypeCode.Decimal:
                return new Decimal(0);

            default:
                throw new InvalidOperationException("Code supposed to be unreachable.");
        }
    }

    public static object GetDefaultValue(Type type)
    {
        var typeInfo = type?.GetTypeInfo();
        return typeInfo is null ? null : GetDefaultValue(typeInfo);
    }
}

public static partial class TypeExtensions
{
    public static object GetDefaultValue(this TypeInfo typeInfo) => Types.GetDefaultValue(typeInfo);

    public static object GetDefaultValue(this Type type) => Types.GetDefaultValue(type);
}