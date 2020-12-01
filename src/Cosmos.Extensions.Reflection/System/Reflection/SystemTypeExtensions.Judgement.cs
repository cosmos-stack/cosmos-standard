using System.Collections;
using System.Linq;
using AspectCore.Extensions.Reflection;
using Cosmos.Reflection;

namespace System.Reflection
{
    /// <summary>
    /// Cosmos <see cref="Type"/> extensions
    /// </summary>
    public static partial class SystemTypeExtensions
    {
        #region IsObjectDeriveFrom

        /// <summary>
        /// Determine whether the current Type (HereGivenType) is derived from the given class ThereType,
        /// or is an implementation of the interface ThereType.<br />
        /// 判断当前 Type 是否派生自给定的类 ThereType，或为接口 ThereType 的实现。
        /// </summary>
        /// <typeparam name="TThereBaseClazz"></typeparam>
        /// <param name="hereGivenObj"></param>
        /// <returns></returns>
        public static bool IsObjectDeriveFrom<TThereBaseClazz>(this object hereGivenObj)
            => hereGivenObj.GetType().IsDeriveClassFrom(typeof(TThereBaseClazz));

        /// <summary>
        /// Determine whether the current Type (HereGivenType) is derived from the given class ThereType,
        /// or is an implementation of the interface ThereType.<br />
        /// 判断当前 Type 是否派生自给定的类 ThereType，或为接口 ThereType 的实现。
        /// </summary>
        /// <param name="hereGivenObj"></param>
        /// <param name="thereBaseType"></param>
        /// <returns></returns>
        public static bool IsObjectDeriveFrom(this object hereGivenObj, Type thereBaseType)
            => hereGivenObj.GetType().IsDeriveClassFrom(thereBaseType);

        #endregion

        #region IsDeriveClassFrom

        /// <summary>
        /// Determine whether the current Type (HereGivenType) is derived from the given class ThereBaseType,
        /// or is an implementation of the interface ThereType.<br />
        /// 判断当前 Type 是否派生自给定的类 ThereType，或为接口 ThereType 的实现。
        /// </summary>
        /// <param name="hereGivenType"></param>
        /// <param name="thereBaseType"></param>
        /// <param name="canAbstract"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool IsDeriveClassFrom(this Type hereGivenType, Type thereBaseType, bool canAbstract = false)
        {
            if (thereBaseType is null) throw new ArgumentNullException(nameof(thereBaseType));
            if (hereGivenType is null) throw new ArgumentNullException(nameof(hereGivenType));

            return hereGivenType.IsClass
                && (canAbstract || !hereGivenType.IsAbstract)
                && hereGivenType.IsBaseOn(thereBaseType);
        }

        /// <summary>
        /// Determine whether the current Type (HereGivenType) is derived from the given class ThereBaseType,
        /// or is an implementation of the interface ThereType.<br />
        /// 判断当前 Type 是否派生自给定的类 ThereType，或为接口 ThereType 的实现。
        /// </summary>
        /// <param name="hereGivenType"></param>
        /// <param name="canAbstract"></param>
        /// <typeparam name="TBaseType"></typeparam>
        /// <returns></returns>
        public static bool IsDeriveClassFrom<TBaseType>(this Type hereGivenType, bool canAbstract = false)
        {
            return IsDeriveClassFrom(hereGivenType, typeof(TBaseType), canAbstract);
        }

        #endregion

        #region IsGenericAssignableFrom

        /// <summary>
        /// Determine whether the current HereGivenType is derived from the generic class thereGenericType
        /// or is an implementation of the generic interface thereGenericType. <br />
        /// 判断当前类型 HereGivenType 是否派生自泛型类 thereGenericType，或为泛型接口 thereGenericType 的实现。
        /// </summary>
        /// <param name="genericBaseType"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsGenericAssignableFrom(this Type genericBaseType, Type type)
            => type.IsGenericImplementationFor(genericBaseType);

        #endregion

        #region IsGenericImplementationFor

        /// <summary>
        /// Determine whether the current HereGivenType is derived from the generic class thereGenericType
        /// or is an implementation of the generic interface thereGenericType. <br />
        /// 判断当前类型 HereGivenType 是否派生自泛型类 thereGenericType，或为泛型接口 thereGenericType 的实现。
        /// </summary>
        /// <param name="hereGivenType">给定类型</param>
        /// <param name="thereGenericType">泛型类型</param>
        /// <returns></returns>
        public static bool IsGenericImplementationFor(this Type hereGivenType, Type thereGenericType)
            => Types.IsGenericImplementation(hereGivenType, thereGenericType);

        /// <summary>
        /// Determine whether the current HereGivenType is derived from the generic class thereGenericType
        /// or is an implementation of the generic interface thereGenericType. <br />
        /// 判断当前类型 HereGivenType 是否派生自泛型类 thereGenericType，或为泛型接口 thereGenericType 的实现。
        /// </summary>
        /// <param name="hereGivenType">给定类型</param>
        /// <param name="thereGenericType">泛型类型</param>
        /// <returns></returns>
        public static bool IsGenericImplementationFor(this TypeInfo hereGivenType, TypeInfo thereGenericType)
            => Types.IsGenericImplementation(hereGivenType, thereGenericType);

        /// <summary>
        /// Determine whether the current HereGivenType is derived from the generic class thereGenericType
        /// or is an implementation of the generic interface thereGenericType. <br />
        /// 判断当前类型 HereGivenType 是否派生自泛型类 thereGenericType，或为泛型接口 thereGenericType 的实现。
        /// </summary>
        /// <typeparam name="TGeneric">泛型类型</typeparam>
        /// <param name="hereGivenType">给定类型</param>
        /// <returns></returns>
        public static bool IsGenericImplementationFor<TGeneric>(this Type hereGivenType)
            => Types.IsGenericImplementation(hereGivenType, typeof(TGeneric));

        /// <summary>
        /// Determine whether the current HereGivenType is derived from the generic class thereGenericType
        /// or is an implementation of the generic interface thereGenericType. <br />
        /// 判断当前类型 HereGivenType 是否派生自泛型类 thereGenericType，或为泛型接口 thereGenericType 的实现。
        /// </summary>
        /// <typeparam name="TThereGenericClazz">泛型类型</typeparam>
        /// <param name="hereGivenType">给定类型</param>
        /// <returns></returns>
        public static bool IsGenericImplementationFor<TThereGenericClazz>(this TypeInfo hereGivenType)
            => Types.IsGenericImplementation(hereGivenType, typeof(TThereGenericClazz));

        #endregion

        #region IsBaseOn

        /// <summary>
        /// Determine whether the specified type is a derived class of the given base class.<br />
        /// 判断制定类型是否是给定基类的派生类。
        /// </summary>
        /// <param name="type"></param>
        /// <param name="baseType"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool IsBaseOn(this Type type, Type baseType)
        {
            if (type is null) throw new ArgumentNullException(nameof(type));
            if (baseType is null) throw new ArgumentNullException(nameof(baseType));

            if (baseType.IsGenericTypeDefinition)
            {
                return baseType.IsGenericAssignableFrom(type);
            }

            return baseType.IsAssignableFrom(type);
        }

        /// <summary>
        /// Determine whether the specified type is a derived class of the given base class.<br />
        /// 判断制定类型是否是给定基类的派生类。
        /// </summary>
        /// <param name="type"></param>
        /// <typeparam name="TBaseType"></typeparam>
        /// <returns></returns>
        public static bool IsBaseOn<TBaseType>(this Type type)
        {
            return type.IsBaseOn(typeof(TBaseType));
        }

        #endregion

        #region IsNumeric

        /// <summary>
        /// Determine whether the given type is a numeric type.<br />
        /// 判断给定的类型是否为数字类型。
        /// </summary>
        /// <param name="type">要检查的类型</param>
        /// <param name="options"></param>
        /// <returns>是否是数值类型</returns>
        public static bool IsNumeric(this Type type, TypeIsOptions options = TypeIsOptions.Default) => Types.IsNumericType(type, options);

        #endregion

        #region IsTupleType

        /// <summary>
        /// Determine whether the given type is a tuple type.<br />
        /// 判断给定的类型是否为元组类型
        /// </summary>
        /// <param name="type"></param>
        /// <param name="ofOptions"></param>
        /// <param name="isOptions"></param>
        /// <returns></returns>
        public static bool IsTupleType(this Type type, TypeOfOptions ofOptions = TypeOfOptions.Owner, TypeIsOptions isOptions = TypeIsOptions.Default)
            => Types.IsTupleType(type, ofOptions, isOptions);

        #endregion
    }
}