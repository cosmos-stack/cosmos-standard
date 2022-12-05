using System.Reflection;
using System.Reflection.Emit;

namespace Cosmos.Conversions.Common.Core.FallbackMappings.Core;

internal static class Helpers
{
    internal static bool IsGenericType(Type type)
    {
        return type.GetTypeInfo().IsGenericType;
    }

    internal static Type CreateType(TypeBuilder typeBuilder)
    {
        return typeBuilder.CreateTypeInfo().AsType();
    }

    internal static Type BaseType(Type type)
    {
        return type.GetTypeInfo().BaseType;
    }
}