using System;
using System.Reflection;

namespace Cosmos.Reflection
{
    /// <summary>
    /// Advanced Types utilities
    /// </summary>
    public static partial class NTypes
    {
        #region GenericImplementation and raw type

        /// <summary>
        /// Determine whether the given type can be assigned to the specified generic type.<br />
        /// 判断给定的类型是否可赋值给指定的泛型类型。
        /// </summary>
        /// <param name="type">The given type</param>
        /// <param name="genericType">The generic type</param>
        /// <returns></returns>
        public static bool IsGenericImplementation(Type type, Type genericType) => Types.IsGenericImplementation(type, genericType);

        /// <summary>
        /// Determine whether the given type can be assigned to the specified generic type.<br />
        /// 判断给定的类型是否可赋值给指定的泛型类型。
        /// </summary>
        /// <typeparam name="TGot">The given type TGot</typeparam>
        /// <typeparam name="TGeneric">The generic type TGeneric</typeparam>
        /// <returns></returns>
        public static bool IsGenericImplementation<TGot, TGeneric>() => Types.IsGenericImplementation<TGot, TGeneric>();

        /// <summary>
        /// Determine whether the given type can be assigned to the specified generic type.<br />
        /// 判断给定的类型是否可赋值给指定的泛型类型。
        /// </summary>
        /// <param name="type">The given type</param>
        /// <param name="genericType">The generic type</param>
        /// <param name="genericArguments"></param>
        /// <returns></returns>
        public static bool IsGenericImplementation(Type type, Type genericType, out Type[] genericArguments) => Types.IsGenericImplementation(type, genericType, out genericArguments);

        /// <summary>
        /// Determine whether the given type can be assigned to the specified generic type.<br />
        /// 判断给定的类型是否可赋值给指定的泛型类型。
        /// </summary>
        /// <typeparam name="TGot">The given type TGot</typeparam>
        /// <typeparam name="TGeneric">The generic type TGeneric</typeparam>
        /// <param name="genericArguments"></param>
        /// <returns></returns>
        public static bool IsGenericImplementation<TGot, TGeneric>(out Type[] genericArguments) => Types.IsGenericImplementation<TGot, TGeneric>(out genericArguments);
        
        /// <summary>
        /// Get the original type. <br />
        /// When type inherits from genericType, gets the first type parameter in the genericType corresponding to the type.
        /// </summary>
        /// <param name="type">The given type</param>
        /// <param name="genericType">The generic type</param>
        /// <returns></returns>
        public static Type GetRawTypeFromGenericClass(Type type, Type genericType) => Types.GetRawTypeFromGenericClass(type, genericType);

        /// <summary>
        /// Get the original type. <br />
        /// When type inherits from genericType, gets the first type parameter in the genericType corresponding to the type.
        /// </summary>
        /// <typeparam name="TGot">The given type TGot</typeparam>
        /// <typeparam name="TGeneric">The generic type TGeneric</typeparam>
        /// <returns></returns>
        public static Type GetRawTypeFromGenericClass<TGot, TGeneric>() => Types.GetRawTypeFromGenericClass<TGot, TGeneric>();

        #endregion

        #region Enum Type

        /// <summary>
        /// Is enum type
        /// </summary>
        /// <param name="mayNullable"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool IsEnumType<T>(bool mayNullable = false) => Types.IsEnumType<T>(mayNullable);

        /// <summary>
        /// Is enum type
        /// </summary>
        /// <param name="type"></param>
        /// <param name="mayNullable"></param>
        /// <returns></returns>
        public static bool IsEnumType(Type type, bool mayNullable = false) => Types.IsEnumType(type, mayNullable);

        /// <summary>
        /// Is enum type
        /// </summary>
        /// <param name="typeInfo"></param>
        /// <param name="mayNullable"></param>
        /// <returns></returns>
        public static bool IsEnumType(TypeInfo typeInfo, bool mayNullable = false) => Types.IsEnumType(typeInfo, mayNullable);

        #endregion

        #region Numeric Type

        /// <summary>
        /// Is numeric type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool IsNumericType<T>() => Types.IsNumericType<T>();

        /// <summary>
        /// Is numeric type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsNumericType(Type type) => Types.IsNumericType(type);

        /// <summary>
        /// Is numeric type
        /// </summary>
        /// <param name="typeInfo"></param>
        /// <returns></returns>
        public static bool IsNumericType(TypeInfo typeInfo) => Types.IsNumericType(typeInfo);

        #endregion

        #region Nullable Type

        /// <summary>
        /// Is nullable type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool IsNullableType<T>() => Types.IsNullableType<T>();

        /// <summary>
        /// Is nullable type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsNullableType(Type type) => Types.IsNullableType(type);

        /// <summary>
        /// Is nullable type
        /// </summary>
        /// <param name="typeInfo"></param>
        /// <returns></returns>
        public static bool IsNullableType(TypeInfo typeInfo) => Types.IsNullableType(typeInfo);

        #endregion

        #region Tuple Type

        /// <summary>
        /// Is tuple type
        /// </summary>
        /// <param name="type"></param>
        /// <param name="checkBaseTypes"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool IsTupleType(Type type, bool checkBaseTypes = false) => Types.IsTupleType(type, checkBaseTypes);

        #endregion
    }
}