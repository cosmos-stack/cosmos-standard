﻿using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Cosmos.Reflection
{
    public static class TypeJudge
    {
        #region IsEnumType

        /// <summary>
        /// Is enum type
        /// </summary>
        /// <param name="type"></param>
        /// <param name="isOptions"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsEnumType(Type type, TypeIsOptions isOptions = TypeIsOptions.Default) => Types.IsEnumType(type, isOptions);

        /// <summary>
        /// Is enum type
        /// </summary>
        /// <param name="isOptions"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsEnumType<T>(TypeIsOptions isOptions = TypeIsOptions.Default) => Types.IsEnumType<T>(isOptions);

        /// <summary>
        /// Is enum type
        /// </summary>
        /// <param name="value"></param>
        /// <param name="isOptions"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsEnumType<T>(T value, TypeIsOptions isOptions = TypeIsOptions.Default) => Types.IsEnumType(value, isOptions);

        #endregion

        #region IsNumericType

        /// <summary>
        /// Determine whether the given type is a numeric type.<br />
        /// 判断给定的类型是否为数字类型。
        /// </summary>
        /// <param name="type"></param>
        /// <param name="isOptions"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNumericType(Type type, TypeIsOptions isOptions = TypeIsOptions.Default) => Types.IsNumericType(type, isOptions);

        /// <summary>
        /// Determine whether the given type is a numeric type.<br />
        /// 判断给定的类型是否为数字类型。
        /// </summary>
        /// <param name="isOptions"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNumericType<T>(TypeIsOptions isOptions = TypeIsOptions.Default) => Types.IsNumericType<T>(isOptions);

        /// <summary>
        /// Determine whether the given object is a numeric type.<br />
        /// 判断给定的对象是否为数字类型。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="isOptions"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNumericType<T>(T value, TypeIsOptions isOptions = TypeIsOptions.Default) => Types.IsNumericType(value, isOptions);

        #endregion

        #region IsNullableType

        /// <summary>
        /// Determine whether the given type is a nullable type. <br />
        /// 判断给定的类型是否为可空类型。
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNullableType(Type type) => Types.IsNullableType(type);

        /// <summary>
        /// Determine whether the given type is a nullable type. <br />
        /// 判断给定的类型是否为可空类型。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNullableType<T>() => Types.IsNullableType<T>();

        /// <summary>
        /// Determine whether the given object is a nullable type. <br />
        /// 判断给定的对象是否为可空类型。
        /// </summary>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNullableType<T>(T value) => Types.IsNullableType(value);

        #endregion

        #region IsCollectionType

        /// <summary>
        /// Determine whether the given type is a collection or array type.<br />
        /// 判断给定的类型是否为集合或数组类型。
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsCollectionType(Type type) => Types.IsCollectionType(type);

        /// <summary>
        /// Determine whether the given type is a collection or array type.<br />
        /// 判断给定的类型是否为集合或数组类型。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsCollectionType<T>() => Types.IsCollectionType<T>();

        /// <summary>
        /// Determine whether the given object is a collection or array type.<br />
        /// 判断给定的对象是否为集合或数组类型。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="isOptions"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsCollectionType<T>(T value, TypeIsOptions isOptions = TypeIsOptions.Default) => Types.IsCollectionType(value, isOptions);

        #endregion

        #region IsAnonymousType

        /// <summary>
        /// Determine whether the given type is an anonymous type.<br />
        /// 判断给定的类型是否为匿名类型。
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsAnonymousType(Type type) => Types.IsAnonymousType(type);

        /// <summary>
        /// Determine whether the given type is an anonymous type.<br />
        /// 判断给定的类型是否为匿名类型。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsAnonymousType<T>() => Types.IsAnonymousType(typeof(T));

        #endregion

        #region IsObjectDerivedFrom

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsObjectDerivedFrom<TSource>(TSource value, Type parentType, TypeIsOptions isOptions = TypeIsOptions.Default, TypeDerivedOptions derivedOptions = TypeDerivedOptions.Default) =>
            TypeReflections.IsObjectDerivedFrom(value, parentType, isOptions, derivedOptions);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsObjectDerivedFrom<TSource, TParent>(TSource value, TypeIsOptions isOptions = TypeIsOptions.Default) =>
            TypeReflections.IsObjectDerivedFrom<TSource, TParent>(value, isOptions);

        #endregion

        #region IsTypeDerivedFrom

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsTypeDerivedFrom(Type sourceType, Type parentType, TypeDerivedOptions derivedOptions = TypeDerivedOptions.Default) =>
            TypeReflections.IsTypeDerivedFrom(sourceType, parentType, derivedOptions);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsTypeDerivedFrom<TSource, TParent>(TypeDerivedOptions derivedOptions = TypeDerivedOptions.Default) =>
            TypeReflections.IsTypeDerivedFrom<TSource, TParent>(derivedOptions);

        #endregion

        #region IsTypeBasedOn

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsTypeBasedOn(Type sourceType, Type parentType) => TypeReflections.IsTypeBasedOn(sourceType, parentType);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsTypeBasedOn<TSource, TParent>() => TypeReflections.IsTypeBasedOn<TSource, TParent>();

        #endregion

        #region IsGenericImplementation

        /// <summary>
        /// Determine whether the given type can be assigned to the specified generic type.<br />
        /// 判断给定的类型是否可赋值给指定的泛型类型。
        /// </summary>
        /// <param name="sourceType">The given type</param>
        /// <param name="parentGenericType">The generic type</param>
        /// <param name="genericType"></param>
        /// <param name="genericArguments"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsImplementationOfGenericType(Type sourceType, Type parentGenericType, out Type genericType, out Type[] genericArguments) =>
            TypeReflections.IsImplementationOfGenericType(sourceType, parentGenericType, out genericType, out genericArguments);

        /// <summary>
        /// Determine whether the given type can be assigned to the specified generic type.<br />
        /// 判断给定的类型是否可赋值给指定的泛型类型。
        /// </summary>
        /// <param name="sourceType">The given type</param>
        /// <param name="parentGenericType">The generic type</param>
        /// <param name="genericArguments"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsImplementationOfGenericType(Type sourceType, Type parentGenericType, out Type[] genericArguments) =>
            TypeReflections.IsImplementationOfGenericType(sourceType, parentGenericType, out genericArguments);

        /// <summary>
        /// Determine whether the given type can be assigned to the specified generic type.<br />
        /// 判断给定的类型是否可赋值给指定的泛型类型。
        /// </summary>
        /// <param name="genericArguments"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TGenericParent"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsImplementationOfGenericType<TSource, TGenericParent>(out Type[] genericArguments) =>
            TypeReflections.IsImplementationOfGenericType<TSource, TGenericParent>(out genericArguments);

        #endregion

        #region IsInterfaceDefined

        /// <summary>
        /// To determine whether the given Interface is defined.<br />
        /// 判断给定的接口是否定义。
        /// </summary>
        /// <param name="type"></param>
        /// <param name="interfaceType"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsInterfaceDefined(Type type, Type interfaceType, InterfaceOptions options = InterfaceOptions.Default) =>
            TypeReflections.IsInterfaceDefined(type, interfaceType, options);

        /// <summary>
        /// To determine whether the given Interface is defined.<br />
        /// 判断给定的接口是否定义。
        /// </summary>
        /// <param name="type"></param>
        /// <param name="options"></param>
        /// <typeparam name="TInterface"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsInterfaceDefined<TInterface>(Type type, InterfaceOptions options = InterfaceOptions.Default) =>
            TypeReflections.IsInterfaceDefined<TInterface>(type, options);

        #endregion

        #region IsDescriptionDefined

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsDescriptionDefined(MemberInfo member, ReflectionOptions refOptions = ReflectionOptions.Default) =>
            TypeReflections.IsDescriptionDefined(member, refOptions);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsDescriptionDefined(ParameterInfo parameter, ReflectionOptions refOptions = ReflectionOptions.Default) =>
            TypeReflections.IsDescriptionDefined(parameter, refOptions);

        #endregion

        #region IsAttributeDefined

        /// <summary>
        /// To determine whether the given Attribute is defined.<br />
        /// 判断给定的特性是否定义。
        /// </summary>
        /// <param name="member"></param>
        /// <typeparam name="TAttribute"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsAttributeDefined<TAttribute>(MemberInfo member) where TAttribute : Attribute =>
            TypeReflections.IsAttributeDefined<TAttribute>(member);

        /// <summary>
        /// To determine whether the given Attribute is defined.<br />
        /// 判断给定的特性是否定义。
        /// </summary>
        /// <param name="member"></param>
        /// <param name="options"></param>
        /// <typeparam name="TAttribute"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsAttributeDefined<TAttribute>(MemberInfo member, ReflectionOptions options) where TAttribute : Attribute =>
            TypeReflections.IsAttributeDefined<TAttribute>(member, options);

        /// <summary>
        /// To determine whether the given Attribute is defined.<br />
        /// 判断给定的特性是否定义。
        /// </summary>
        /// <param name="parameter"></param>
        /// <typeparam name="TAttribute"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsAttributeDefined<TAttribute>(ParameterInfo parameter) where TAttribute : Attribute =>
            TypeReflections.IsAttributeDefined<TAttribute>(parameter);

        /// <summary>
        /// To determine whether the given Attribute is defined.<br />
        /// 判断给定的特性是否定义。
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="options"></param>
        /// <typeparam name="TAttribute"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsAttributeDefined<TAttribute>(ParameterInfo parameter, ReflectionOptions options) where TAttribute : Attribute =>
            TypeReflections.IsAttributeDefined<TAttribute>(parameter, options);

        /// <summary>
        /// To determine whether the given Attribute is defined.<br />
        /// 判断给定的特性是否定义。
        /// </summary>
        /// <param name="member"></param>
        /// <param name="attributeType"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsAttributeDefined(MemberInfo member, Type attributeType) =>
            TypeReflections.IsAttributeDefined(member, attributeType);

        /// <summary>
        /// To determine whether the given Attribute is defined.<br />
        /// 判断给定的特性是否定义。
        /// </summary>
        /// <param name="member"></param>
        /// <param name="attributeType"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsAttributeDefined(MemberInfo member, Type attributeType, ReflectionOptions options) =>
            TypeReflections.IsAttributeDefined(member, attributeType, options);

        /// <summary>
        /// To determine whether the given Attribute is defined.<br />
        /// 判断给定的特性是否定义。
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="attributeType"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsAttributeDefined(ParameterInfo parameter, Type attributeType) =>
            TypeReflections.IsAttributeDefined(parameter, attributeType);

        /// <summary>
        /// To determine whether the given Attribute is defined.<br />
        /// 判断给定的特性是否定义。
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="attributeType"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsAttributeDefined(ParameterInfo parameter, Type attributeType, ReflectionOptions options) =>
            TypeReflections.IsAttributeDefined(parameter, attributeType, options);

        #endregion
    }
}