﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Cosmos.Reflection
{
    public enum TypeIsOptions
    {
        Default = 0,
        IgnoreNullable = 1
    }

    internal static partial class TypeExtensions
    {
        public static Type GetUnboxedType<T>(this T value) => typeof(T);
    }

    /// <summary>
    /// Type Utilities
    /// </summary>
    public static partial class Types
    {
        #region Tuple

        /// <summary>
        /// Determine whether the given type is a tuple type.<br />
        /// 判断给定的类型是否为元组类型
        /// </summary>
        /// <param name="type"></param>
        /// <param name="ofOptions"></param>
        /// <param name="isOptions"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool IsTupleType(Type type, TypeOfOptions ofOptions = TypeOfOptions.Owner, TypeIsOptions isOptions = TypeIsOptions.Default)
        {
            if (type is null)
                return false;

            if (isOptions == TypeIsOptions.IgnoreNullable)
                type = TypeConv.GetNonNullableType(type);

            if (type == typeof(Tuple) || type == typeof(ValueTuple))
                return true;

            while (type != null)
            {
                if (type.IsGenericType)
                {
                    var genType = type.GetGenericTypeDefinition();

                    if (genType == typeof(Tuple<>)
                     || genType == typeof(Tuple<,>)
                     || genType == typeof(Tuple<,,>)
                     || genType == typeof(Tuple<,,,>)
                     || genType == typeof(Tuple<,,,,>)
                     || genType == typeof(Tuple<,,,,,>)
                     || genType == typeof(Tuple<,,,,,,>)
                     || genType == typeof(Tuple<,,,,,,,>)
                     || genType == typeof(Tuple<,,,,,,,>))
                        return true;

                    if (genType == typeof(ValueTuple<>)
                     || genType == typeof(ValueTuple<,>)
                     || genType == typeof(ValueTuple<,,>)
                     || genType == typeof(ValueTuple<,,,>)
                     || genType == typeof(ValueTuple<,,,,>)
                     || genType == typeof(ValueTuple<,,,,,>)
                     || genType == typeof(ValueTuple<,,,,,,>)
                     || genType == typeof(ValueTuple<,,,,,,,>)
                     || genType == typeof(ValueTuple<,,,,,,,>))
                        return true;
                }

                if (ofOptions == TypeOfOptions.Owner)
                    break;

                type = type.BaseType;
            }

            return false;
        }

        /// <summary>
        /// Determine whether the given type is a tuple type.<br />
        /// 判断给定的类型是否为元组类型
        /// </summary>
        /// <param name="ofOptions"></param>
        /// <param name="isOptions"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool IsTupleType<T>(TypeOfOptions ofOptions = TypeOfOptions.Owner, TypeIsOptions isOptions = TypeIsOptions.Default)
        {
            return IsTupleType(typeof(T), ofOptions, isOptions);
        }

        /// <summary>
        /// Determine whether the given object is a tuple type.<br />
        /// 判断给定的对象是否为元组类型
        /// </summary>
        /// <param name="value"></param>
        /// <param name="ofOptions"></param>
        /// <param name="isOptions"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool IsTupleType<T>(T value, TypeOfOptions ofOptions = TypeOfOptions.Owner, TypeIsOptions isOptions = TypeIsOptions.Default)
        {
            var type = value?.GetUnboxedType();
            return type is not null && IsTupleType(type, ofOptions, isOptions);
        }

        #endregion

        #region Numeric

        /// <summary>
        /// Determine whether the given type is a numeric type.<br />
        /// 判断给定的类型是否为数字类型。
        /// </summary>
        /// <param name="type"></param>
        /// <param name="isOptions"></param>
        /// <returns></returns>
        public static bool IsNumericType(Type type, TypeIsOptions isOptions = TypeIsOptions.Default)
        {
            if (type is null)
                return false;

            if (isOptions == TypeIsOptions.IgnoreNullable)
                type = TypeConv.GetNonNullableType(type);

            return type == TypeClass.ByteClazz
                || type == TypeClass.SByteClazz
                || type == TypeClass.Int16Clazz
                || type == TypeClass.Int32Clazz
                || type == TypeClass.Int64Clazz
                || type == TypeClass.UInt16Clazz
                || type == TypeClass.UInt32Clazz
                || type == TypeClass.UInt64Clazz
                || type == TypeClass.DecimalClazz
                || type == TypeClass.DoubleClazz
                || type == TypeClass.FloatClazz;
        }

        /// <summary>
        /// Determine whether the given type is a numeric type.<br />
        /// 判断给定的类型是否为数字类型。
        /// </summary>
        /// <param name="isOptions"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool IsNumericType<T>(TypeIsOptions isOptions = TypeIsOptions.Default)
        {
            return IsNumericType(typeof(T), isOptions);
        }

        /// <summary>
        /// Determine whether the given object is a numeric type.<br />
        /// 判断给定的对象是否为数字类型。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="isOptions"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool IsNumericType<T>(T value, TypeIsOptions isOptions = TypeIsOptions.Default)
        {
            return IsNumericType(value.GetUnboxedType(), isOptions);
        }

        #endregion

        #region Nullable

        /// <summary>
        /// Determine whether the given type is a nullable type. <br />
        /// 判断给定的类型是否为可空类型。
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsNullableType(Type type)
        {
            return type is not null
                && type.IsGenericType
                && type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }

        /// <summary>
        /// Determine whether the given type is a nullable type. <br />
        /// 判断给定的类型是否为可空类型。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool IsNullableType<T>()
        {
            return IsNullableType(typeof(T));
        }

        /// <summary>
        /// Determine whether the given object is a nullable type. <br />
        /// 判断给定的对象是否为可空类型。
        /// </summary>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool IsNullableType<T>(T value)
        {
            return IsNullableType(value.GetUnboxedType());
        }

        #endregion

        #region Enum

        /// <summary>
        /// Is enum type
        /// </summary>
        /// <param name="type"></param>
        /// <param name="isOptions"></param>
        /// <returns></returns>
        public static bool IsEnumType(Type type, TypeIsOptions isOptions = TypeIsOptions.Default)
        {
            return type is not null
                && isOptions switch
                   {
                       TypeIsOptions.Default => type.IsEnum,
                       TypeIsOptions.IgnoreNullable => TypeConv.GetNonNullableType(type).IsEnum,
                       _ => type.IsEnum
                   };
        }

        /// <summary>
        /// Is enum type
        /// </summary>
        /// <param name="isOptions"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool IsEnumType<T>(TypeIsOptions isOptions = TypeIsOptions.Default)
        {
            return IsEnumType(typeof(T), isOptions);
        }

        /// <summary>
        /// Is enum type
        /// </summary>
        /// <param name="value"></param>
        /// <param name="isOptions"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool IsEnumType<T>(T value, TypeIsOptions isOptions = TypeIsOptions.Default)
        {
            return value is not null && IsEnumType(typeof(T), isOptions) && typeof(T).IsEnumDefined(value);
        }

        #endregion

        #region Array/Collection

        /// <summary>
        /// Determine whether the given type is a collection or array type.<br />
        /// 判断给定的类型是否为集合或数组类型。
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsCollectionType(Type type)
        {
            return type is not null && (type.IsArray || type.GetInterfaces().Any(InterfacePredicate));

            bool InterfacePredicate(Type typeOfInterface)
            {
                if (typeOfInterface.IsGenericType)
                    typeOfInterface = typeOfInterface.GetGenericTypeDefinition();

                return typeOfInterface == typeof(IEnumerable<>)
                    || typeOfInterface == typeof(ICollection<>)
                    || typeOfInterface == typeof(IEnumerable)
                    || typeOfInterface == typeof(ICollection);
            }
        }

        /// <summary>
        /// Determine whether the given type is a collection or array type.<br />
        /// 判断给定的类型是否为集合或数组类型。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool IsCollectionType<T>()
        {
            return IsCollectionType(typeof(T));
        }

        /// <summary>
        /// Determine whether the given object is a collection or array type.<br />
        /// 判断给定的对象是否为集合或数组类型。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="isOptions"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool IsCollectionType<T>(T value, TypeIsOptions isOptions = TypeIsOptions.Default)
        {
            return isOptions switch
            {
                TypeIsOptions.Default => value is not null && IsCollectionType(typeof(T)),
                TypeIsOptions.IgnoreNullable => IsCollectionType(typeof(T)),
                _ => value is not null && IsCollectionType(typeof(T))
            };
        }

        #endregion

        #region Attribute Defined

        /// <summary>
        /// To determine whether the given Attribute is defined.<br />
        /// 判断给定的特性是否定义。
        /// </summary>
        /// <param name="type"></param>
        /// <param name="attributeType"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static bool IsAttributeDefined(Type type, Type attributeType, ReflectionOptions options = ReflectionOptions.Default)
        {
            return TypeReflections.IsAttributeDefined(type, attributeType, options);
        }

        /// <summary>
        /// To determine whether the given Attribute is defined.<br />
        /// 判断给定的特性是否定义。
        /// </summary>
        /// <param name="type"></param>
        /// <param name="options"></param>
        /// <typeparam name="TAttribute"></typeparam>
        /// <returns></returns>
        public static bool IsAttributeDefined<TAttribute>(Type type, ReflectionOptions options = ReflectionOptions.Default)
            where TAttribute : Attribute
        {
            return TypeReflections.IsAttributeDefined<TAttribute>(type, options);
        }

        /// <summary>
        /// To determine whether the given Attribute is defined.<br />
        /// 判断给定的特性是否定义。
        /// </summary>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TAttribute"></typeparam>
        /// <returns></returns>
        public static bool IsAttributeDefined<T, TAttribute>(ReflectionOptions options = ReflectionOptions.Default)
            where TAttribute : Attribute
        {
            return TypeReflections.IsAttributeDefined<TAttribute>(typeof(T), options);
        }
        
        /// <summary>
        /// To determine whether the given Attribute is defined.<br />
        /// 判断给定的特性是否定义。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="options"></param>
        /// <param name="isOptions"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TAttribute"></typeparam>
        /// <returns></returns>
        public static bool IsAttributeDefined<T, TAttribute>(T value, ReflectionOptions options = ReflectionOptions.Default, TypeIsOptions isOptions = TypeIsOptions.Default)
            where TAttribute : Attribute
        {
            return isOptions switch
            {
                TypeIsOptions.Default => value is not null && LocalFunc(),
                TypeIsOptions.IgnoreNullable => LocalFunc(),
                _ => value is not null && LocalFunc()
            };
            
            bool LocalFunc() => TypeReflections.IsAttributeDefined<TAttribute>(typeof(T), options);
        }

        #endregion

        #region Interface Defined

        public static bool IsInterfaceDefined(Type type, Type interfaceType, InterfaceOptions options = InterfaceOptions.Default)
        {
            return TypeReflections.IsInterfaceDefined(type, interfaceType, options);
        }

        public static bool IsInterfaceDefined<TInterface>(Type type, InterfaceOptions options = InterfaceOptions.Default)
        {
            return TypeReflections.IsInterfaceDefined<TInterface>(type, options);
        }
        
        public static bool IsInterfaceDefined<T,TInterface>( InterfaceOptions options = InterfaceOptions.Default)
        {
            return TypeReflections.IsInterfaceDefined<TInterface>(typeof(T), options);
        }
        
        public static bool IsInterfaceDefined<T,TInterface>(T value,  InterfaceOptions options = InterfaceOptions.Default, TypeIsOptions isOptions = TypeIsOptions.Default)
        {
            return isOptions switch
            {
                TypeIsOptions.Default => value is not null && LocalFunc(),
                TypeIsOptions.IgnoreNullable => LocalFunc(),
                _ => value is not null && LocalFunc()
            };
            
            bool LocalFunc() => TypeReflections.IsInterfaceDefined<TInterface>(typeof(T), options);
        }

        #endregion
    }
}