using System;
using System.Collections.Generic;
using System.Reflection;

namespace Cosmos.Reflection
{
    /// <summary>
    /// Reflection Utilities.
    /// </summary>
    public static partial class TypeReflections
    {
        private static bool X(MemberInfo member, Func<Type, Type> typeClear, Func<Type, bool> typeInfer)
        {
            return member switch
            {
                null => false,
                Type type => typeInfer(typeClear(type)),
                PropertyInfo propertyInfo => typeInfer(typeClear(propertyInfo.PropertyType)),
                FieldInfo fieldInfo => typeInfer(typeClear(fieldInfo.FieldType)),
                _ => false
            };
        }

        private static Type N(Type type, TypeIsOptions isOptions = TypeIsOptions.Default)
        {
            return isOptions switch
            {
                TypeIsOptions.Default => type,
                TypeIsOptions.IgnoreNullable => TypeConv.GetNonNullableType(type),
                _ => type
            };
        }

        /// <summary>
        /// Determine whether the given MemberInfo is a Boolean type.<br />
        /// 判断给定的 MemberInfo 元信息是否为布尔类型。
        /// </summary>
        /// <param name="isOptions"></param>
        /// <param name="member">成员</param>
        public static bool IsBoolean(MemberInfo member, TypeIsOptions isOptions = TypeIsOptions.Default)
        {
            return X(member, type => N(type, isOptions), type => type == TypeClass.BooleanClazz);
        }

        /// <summary>
        /// Determine whether the given MemberInfo is a datetime.<br />
        /// 判断给定的 MemberInfo 元信息是否为 DateTime 类型。
        /// </summary>
        /// <param name="isOptions"></param>
        /// <param name="member">成员</param>
        public static bool IsDateTime(MemberInfo member, TypeIsOptions isOptions = TypeIsOptions.Default)
        {
            return X(member, type => N(type, isOptions), type => type == TypeClass.DateTimeClazz);
        }

        /// <summary>
        /// Determine whether the given MemberInfo is a numeric type.<br />
        /// 判断给定的 MemberInfo 元信息是否为数字类型。
        /// </summary>
        /// <param name="member">成员</param>
        /// <param name="isOptions"></param>
        public static bool IsNumeric(MemberInfo member, TypeIsOptions isOptions = TypeIsOptions.Default)
        {
            return X(member, type => type, type => Types.IsNumericType(type, isOptions));
        }

        /// <summary>
        /// Determine whether the given MemberInfo is an enum type.<br />
        /// 判断给定的 MemberInfo 元信息是否为枚举类型。
        /// </summary>
        /// <param name="member"></param>
        /// <param name="isOptions"></param>
        /// <returns></returns>
        public static bool IsEnum(MemberInfo member, TypeIsOptions isOptions = TypeIsOptions.Default)
        {
            return X(member, type => type, type => Types.IsEnumType(type, isOptions));
        }
        
        /// <summary>
        /// 是否集合
        /// </summary>
        /// <param name="type">类型</param>
        public static bool IsCollection(Type type)
        {
            if (type.IsArray)
                return true;
            return IsGenericCollection(type);
        }

        /// <summary>
        /// 是否泛型集合
        /// </summary>
        /// <param name="type">类型</param>
        public static bool IsGenericCollection(Type type)
        {
            if (!type.IsGenericType)
                return false;
            var typeDefinition = type.GetGenericTypeDefinition();
            return typeDefinition == typeof(IEnumerable<>)
                || typeDefinition == typeof(IReadOnlyCollection<>)
                || typeDefinition == typeof(IReadOnlyList<>)
                || typeDefinition == typeof(ICollection<>)
                || typeDefinition == typeof(IList<>)
                || typeDefinition == typeof(List<>);
        }
    }
}