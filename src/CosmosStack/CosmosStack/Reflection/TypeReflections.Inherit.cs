using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CosmosStack.Reflection
{
    /// <summary>
    /// Type derivation options <br />
    /// 类型派生选项
    /// </summary>
    public enum TypeDerivedOptions
    {
        /// <summary>
        /// Default <br />
        /// 默认
        /// </summary>
        Default = 0,
        
        /// <summary>
        /// Allow recognition of abstract classes <br />
        /// 允许识别抽象类
        /// </summary>
        CanAbstract = 1
    }

    /// <summary>
    /// Reflection Utilities. <br />
    /// 反射工具
    /// </summary>
    public static partial class TypeReflections
    {
        #region IsObjectDerivedFrom

        /// <summary>
        /// Determine whether the object is derived from a given type. <br />
        /// 判断对象是否派生自给定的类型。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="parentType"></param>
        /// <param name="isOptions"></param>
        /// <param name="derivedOptions"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool IsObjectDerivedFrom<TSource>(TSource value, Type parentType, TypeIsOptions isOptions = TypeIsOptions.Default, TypeDerivedOptions derivedOptions = TypeDerivedOptions.Default)
        {
            if (parentType is null) throw new ArgumentNullException(nameof(parentType));
            return isOptions switch
            {
                TypeIsOptions.Default => value is not null && IsTypeDerivedFrom(typeof(TSource), parentType, derivedOptions),
                TypeIsOptions.IgnoreNullable => IsTypeDerivedFrom(typeof(TSource), parentType, derivedOptions),
                _ => value is not null && IsTypeDerivedFrom(typeof(TSource), parentType, derivedOptions)
            };
        }

        /// <summary>
        /// Determine whether the object is derived from a given type. <br />
        /// 判断对象是否派生自给定的类型。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="isOptions"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TParent"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsObjectDerivedFrom<TSource, TParent>(TSource value, TypeIsOptions isOptions = TypeIsOptions.Default)
        {
            return IsObjectDerivedFrom(value, typeof(TParent), isOptions);
        }

        #endregion

        #region IsTypeDerivedFrom

        /// <summary>
        /// Determine whether the type is derived from the given type. <br />
        /// 判断类型是否派生自给定的类型。
        /// </summary>
        /// <param name="sourceType"></param>
        /// <param name="parentType"></param>
        /// <param name="derivedOptions"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool IsTypeDerivedFrom(Type sourceType, Type parentType, TypeDerivedOptions derivedOptions = TypeDerivedOptions.Default)
        {
            if (sourceType is null) throw new ArgumentNullException(nameof(sourceType));
            if (parentType is null) throw new ArgumentNullException(nameof(parentType));

            return sourceType.IsClass
                && AbstractPredicate()
                && IsTypeBasedOn(sourceType, parentType);

            bool AbstractPredicate()
            {
                return derivedOptions switch
                {
                    TypeDerivedOptions.Default => !sourceType.IsAbstract,
                    TypeDerivedOptions.CanAbstract => true,
                    _ => !sourceType.IsAbstract
                };
            }
        }

        /// <summary>
        /// Determine whether the type is derived from the given type. <br />
        /// 判断类型是否派生自给定的类型。
        /// </summary>
        /// <param name="derivedOptions"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TParent"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsTypeDerivedFrom<TSource, TParent>(TypeDerivedOptions derivedOptions = TypeDerivedOptions.Default)
        {
            return IsTypeDerivedFrom(typeof(TSource), typeof(TParent), derivedOptions);
        }

        #endregion

        #region IsTypeBasedOn

        /// <summary>
        /// Determine whether the given left type is derived from the right type. <br />
        /// 判断给定的左侧类型是否派生自右侧类型。
        /// </summary>
        /// <param name="sourceType"></param>
        /// <param name="parentType"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool IsTypeBasedOn(Type sourceType, Type parentType)
        {
            if (sourceType is null) throw new ArgumentNullException(nameof(sourceType));
            if (parentType is null) throw new ArgumentNullException(nameof(parentType));

            if (parentType.IsGenericTypeDefinition)
                return IsImplementationOfGenericType(sourceType, parentType, out _);
            return parentType.IsAssignableFrom(sourceType);
        }

        /// <summary>
        /// Determine whether the given left type is derived from the right type. <br />
        /// 判断给定的左侧类型是否派生自右侧类型。
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TParent"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsTypeBasedOn<TSource, TParent>()
        {
            return IsTypeBasedOn(typeof(TSource), typeof(TParent));
        }

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
        public static bool IsImplementationOfGenericType(Type sourceType, Type parentGenericType, out Type genericType, out Type[] genericArguments)
        {
            if (sourceType is null)
                throw new ArgumentNullException(nameof(sourceType));

            if (parentGenericType is null)
                throw new ArgumentNullException(nameof(parentGenericType));

            genericArguments = null;
            genericType = null;
            Type currentType = null;

            if (parentGenericType.IsGenericType is false)
                return false;

            //Testing interface
            if (parentGenericType.IsInterface)
            {
                if (sourceType.GetInterfaces().Any(_checkRawGenericType))
                {
                    genericType = currentType;
                    genericArguments = currentType.GetGenericArguments();
                    return true;
                }
            }

            //Testing class
            while (sourceType != null && sourceType != typeof(object))
            {
                if (_checkRawGenericType(sourceType))
                {
                    genericType = currentType;
                    genericArguments = currentType.GetGenericArguments();
                    return true;
                }

                sourceType = sourceType.BaseType;
            }

            //no matched for any classed or interfaces
            return false;

            // To check such type equals to specific type of class or interface
            // 检查给定的这个 test 类型是否等于指定类 Class 或接口 Interface 的类型 Type，通过 currentType 返回当前类型
            // ReSharper disable once InconsistentNaming
            bool _checkRawGenericType(Type test)
            {
                currentType = null;
                if (test.IsGenericType is false)
                    return false;
                if (parentGenericType.IsGenericTypeDefinition)
                    return parentGenericType == test.GetGenericTypeDefinition() && (currentType = test) == currentType;
                return parentGenericType == test && (currentType = test) == currentType;
            }
        }

        /// <summary>
        /// Determine whether the given type can be assigned to the specified generic type.<br />
        /// 判断给定的类型是否可赋值给指定的泛型类型。
        /// </summary>
        /// <param name="sourceType">The given type</param>
        /// <param name="parentGenericType">The generic type</param>
        /// <param name="genericArguments"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsImplementationOfGenericType(Type sourceType, Type parentGenericType, out Type[] genericArguments)
        {
            return IsImplementationOfGenericType(sourceType, parentGenericType, out _, out genericArguments);
        }

        /// <summary>
        /// Determine whether the given type can be assigned to the specified generic type.<br />
        /// 判断给定的类型是否可赋值给指定的泛型类型。
        /// </summary>
        /// <param name="genericArguments"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TGenericParent"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsImplementationOfGenericType<TSource, TGenericParent>(out Type[] genericArguments)
        {
            return IsImplementationOfGenericType(typeof(TSource), typeof(TGenericParent), out genericArguments);
        }

        #endregion

        #region GetRawTypeFromGenericType

        /// <summary>
        /// Get the original <see cref="sourceType"/>. <br />
        /// When type inherits from genericType, returns that type.
        /// <para>
        /// 获取原始<see cref="sourceType"/>。 <br />
        /// 当类型从 genericType 继承时，返回该类型。
        /// </para>
        /// </summary>
        /// <param name="sourceType"></param>
        /// <param name="parentGenericType"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Type GetRawTypeFromGenericType(Type sourceType, Type parentGenericType)
        {
            return IsImplementationOfGenericType(sourceType, parentGenericType, out var genericType, out _)
                ? genericType
                : default;
        }

        /// <summary>
        /// Get the original <see cref="TSource"/>. <br />
        /// When type inherits from genericType, returns that type.
        /// <para>
        /// 获取原始<see cref="TSource"/>。 <br />
        /// 当类型继承自 genericType 时，返回该类型。
        /// </para>
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TGenericParent"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Type GetRawTypeFromGenericType<TSource, TGenericParent>()
        {
            return GetRawTypeFromGenericType(typeof(TSource), typeof(TGenericParent));
        }

        #endregion

        #region GetRawTypeArgsFromGenericType

        /// <summary>
        /// Get the original <see cref="sourceType"/>. <br />
        /// When type inherits from genericType, gets all generic arguments in the <see cref="parentGenericType"/> corresponding to the <see cref="sourceType"/>.
        /// <para>
        /// 获取原始<see cref="sourceType"/>。 <br />
        /// 当type继承自genericType时，获取<see cref="sourceType"/>对应的<see cref="parentGenericType"/>中的所有泛型参数。
        ///</para>
        /// </summary>
        /// <param name="sourceType"></param>
        /// <param name="parentGenericType"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TypesVal GetRawTypeArgsFromGenericType(Type sourceType, Type parentGenericType)
        {
            return IsImplementationOfGenericType(sourceType, parentGenericType, out _, out var genericArguments)
                ? TypesVal.Create(genericArguments)
                : TypesVal.Empty;
        }

        /// <summary>
        /// Get the original <see cref="TSource"/>. <br />
        /// When type inherits from genericType, gets all generic arguments in the <see cref="TGenericParent"/> corresponding to the <see cref="TSource"/>.
        /// <para>
        /// 获取原始<see cref="TSource"/>。 <br />
        /// 当type继承自genericType时，获取<see cref="TGenericParent"/>对应的<see cref="TSource"/>中的所有泛型参数。
        ///</para>
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TGenericParent"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TypesVal GetRawTypeArgsFromGenericType<TSource, TGenericParent>()
        {
            return GetRawTypeArgsFromGenericType(typeof(TSource), typeof(TGenericParent));
        }

        #endregion

        #region GetEnumUnderlyingType

        /// <summary>
        /// Get the underlying type of the enum <br />
        /// 获取枚举的底层类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Type GetEnumUnderlyingType(Type type)
        {
            if (type is null)
                return null;

            if (!type.IsEnum)
                return null;

            return type.GetEnumUnderlyingType();
        }

        /// <summary>
        /// Get the underlying type of the enum <br />
        /// 获取枚举的底层类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Type GetEnumUnderlyingType<T>()
        {
            return GetEnumUnderlyingType(typeof(T));
        }

        #endregion
    }

    /// <summary>
    /// Type-Inherit reflection extensions <br />
    /// 类型继承反射扩展
    /// </summary>
    public static class TypeInheritReflectionExtensions
    {
        #region IsDerivedFrom

        /// <summary>
        /// Determine whether the type is derived from the specified type. <br />
        /// 判断类型是否派生自指定类型。
        /// </summary>
        /// <param name="sourceType"></param>
        /// <param name="parentType"></param>
        /// <param name="derivedOptions"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsDerivedFrom(this Type sourceType, Type parentType, TypeDerivedOptions derivedOptions = TypeDerivedOptions.Default)
        {
            return TypeReflections.IsTypeDerivedFrom(sourceType, parentType, derivedOptions);
        }
        
        /// <summary>
        /// Determine whether the type is derived from the specified type. <br />
        /// 判断类型是否派生自指定类型。
        /// </summary>
        /// <param name="sourceType"></param>
        /// <param name="derivedOptions"></param>
        /// <typeparam name="TParent"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsDerivedFrom<TParent>(this Type sourceType, TypeDerivedOptions derivedOptions = TypeDerivedOptions.Default)
        {
            return TypeReflections.IsTypeDerivedFrom(sourceType, typeof(TParent), derivedOptions);
        }

        #endregion
        
        #region IsBasedOn

        /// <summary>
        /// Determine whether the given left type is derived from the right type. <br />
        /// 判断给定的左侧类型是否派生自右侧类型。
        /// </summary>
        /// <param name="sourceType"></param>
        /// <param name="parentType"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsBasedOn(this Type sourceType, Type parentType)
        {
            return TypeReflections.IsTypeBasedOn(sourceType, parentType);
        }
        
        /// <summary>
        /// Determine whether the given left type is derived from the right type. <br />
        /// 判断给定的左侧类型是否派生自右侧类型。
        /// </summary>
        /// <param name="sourceType"></param>
        /// <typeparam name="TParent"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsBasedOn<TParent>(this Type sourceType)
        {
            return TypeReflections.IsTypeBasedOn(sourceType, typeof(TParent));
        }

        #endregion
        
        #region IsGenericAssignableFrom

        /// <summary>
        /// Determine whether the current <see cref="sourceType"/> is derived from the generic class <see cref="parentType"/>
        /// or is an implementation of the generic interface <see cref="parentType"/>. <br />
        /// 判断当前类型 <see cref="sourceType"/> 是否派生自泛型类 <see cref="parentType"/>，或为泛型接口 <see cref="parentType"/> 的实现。
        /// </summary>
        /// <param name="parentType"></param>
        /// <param name="sourceType"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsGenericAssignableFrom(this Type parentType, Type sourceType)
        {
            return TypeReflections.IsImplementationOfGenericType(sourceType, parentType, out _);
        }

        /// <summary>
        /// Determine whether the current <see cref="TSource"/> is derived from the generic class <see cref="parentType"/>
        /// or is an implementation of the generic interface <see cref="parentType"/>. <br />
        /// 判断当前类型 <see cref="TSource"/> 是否派生自泛型类 <see cref="parentType"/>，或为泛型接口 <see cref="parentType"/> 的实现。
        /// </summary>
        /// <param name="parentType"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsGenericAssignableFrom<TSource>(this Type parentType)
        {
            return TypeReflections.IsImplementationOfGenericType(typeof(TSource), parentType, out _);
        }

        #endregion

        #region IsImplementationOfGenericType

        /// <summary>
        /// Determine whether the current <see cref="sourceType"/> is derived from the generic class <see cref="parentType"/>
        /// or is an implementation of the generic interface <see cref="parentType"/>. <br />
        /// 判断当前类型 <see cref="sourceType"/> 是否派生自泛型类 <see cref="parentType"/>，或为泛型接口 <see cref="parentType"/> 的实现。
        /// </summary>
        /// <param name="sourceType">给定类型</param>
        /// <param name="parentType">泛型类型</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsImplementationOfGenericType(this Type sourceType, Type parentType)
        {
            return TypeReflections.IsImplementationOfGenericType(sourceType, parentType, out _);
        }

        /// <summary>
        /// Determine whether the current <see cref="sourceType"/> is derived from the generic class <see cref="TParent"/>
        /// or is an implementation of the generic interface <see cref="TParent"/>. <br />
        /// 判断当前类型 <see cref="sourceType"/> 是否派生自泛型类 <see cref="TParent"/>，或为泛型接口 <see cref="TParent"/> 的实现。
        /// </summary>
        /// <param name="sourceType"></param>
        /// <typeparam name="TParent"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsImplementationOfGenericType<TParent>(this Type sourceType)
        {
            return TypeReflections.IsImplementationOfGenericType(sourceType, typeof(TParent), out _);
        }

        #endregion
    }
}