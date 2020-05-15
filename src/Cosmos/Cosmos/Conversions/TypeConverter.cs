using System;
using System.Reflection;
using Cosmos.Judgments;
using Cosmos.Reflection;

namespace Cosmos.Conversions {
    /// <summary>
    /// Type conversion Utilities
    /// </summary>
    public static class TypeConverter {
        /// <summary>
        /// Convert nullable type to underlying type.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Type ToNonNullableType(Type type) =>
            Nullable.GetUnderlyingType(type);

        /// <summary>
        /// Convert nullable typeInfo to underlying typeInfo。
        /// </summary>
        /// <param name="typeInfo"></param>
        /// <returns></returns>
        public static TypeInfo ToNonNullableTypeInfo(TypeInfo typeInfo) =>
            Nullable.GetUnderlyingType(typeInfo.AsType()).GetTypeInfo();

        /// <summary>
        /// Convert nullable type to underlying type safety.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Type ToSafeNonNullableType(Type type) =>
            TypeJudgment.IsNullableType(type) ? ToNonNullableType(type) : type;

        /// <summary>
        /// Convert nullable typeInfo to underlying typeInfo safety.
        /// </summary>
        /// <param name="typeInfo"></param>
        /// <returns></returns>
        public static TypeInfo ToSafeNonNullableTypeInfo(TypeInfo typeInfo) =>
            TypeJudgment.IsNullableType(typeInfo) ? ToNonNullableTypeInfo(typeInfo) : typeInfo;
    }
}