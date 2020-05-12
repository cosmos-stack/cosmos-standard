using System;
using System.Reflection;

// ReSharper disable once CheckNamespace
namespace Cosmos.Optionals {
    /// <summary>
    /// Optionals extensions
    /// </summary>
    public static partial class OptionalsExtensions {
        /// <summary>
        /// Return a non-nullable type version for the given <see cref="Type"/>.<br />
        /// 获取所给定的可空类型的不可空类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Type ToNonNullableType(this Type type) => Nullable.GetUnderlyingType(type);

        /// <summary>
        /// Return a non-nullable type version for the given <see cref="TypeInfo"/>.<br />
        /// 获取所给定的可空类型的不可空类型
        /// </summary>
        /// <param name="typeInfo"></param>
        /// <returns></returns>
        public static TypeInfo ToNonNullableTypeInfo(this TypeInfo typeInfo) =>
            Nullable.GetUnderlyingType(typeInfo.AsType()).GetTypeInfo();
    }
}