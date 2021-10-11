using System;
using System.Reflection;
using System.Reflection.Emit;

namespace TinyMapper.Core
{
    internal static class Helpers
    {
        internal static bool IsValueType(Type type)
        {
            return type.GetTypeInfo().IsValueType;
        }

        internal static bool IsPrimitive(Type type)
        {
            return type.GetTypeInfo().IsPrimitive;
        }

        internal static bool IsEnum(Type type)
        {
            return type.GetTypeInfo().IsEnum;
        }

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
}