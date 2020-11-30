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
        /// Determine whether the specified type is a numeric type.<br />
        /// 判断指定类型是否为数值类型
        /// </summary>
        /// <param name="type">要检查的类型</param>
        /// <returns>是否是数值类型</returns>
        public static bool IsNumeric(this Type type) => Types.IsNumericType(type);

        /// <summary>
        /// Determine whether the specified type is a numeric type.<br />
        /// 判断指定类型是否为数值类型
        /// </summary>
        /// <param name="typeInfo">要检查的类型</param>
        /// <returns>是否是数值类型</returns>
        public static bool IsNumeric(this TypeInfo typeInfo) => Types.IsNumericType(typeInfo);

        #endregion

        #region IsNullableType

        /// <summary>
        /// 指示类型是否为可空类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsNullableType(this Type type) => Types.IsNullableType(type);

        #endregion

        #region IsEnumerable

        /// <summary>
        /// Determine whether the specified type is a collection type. <br />
        /// 判断指定的类型是否为集合类型。
        /// </summary>
        /// <param name="that"></param>
        /// <returns></returns>
        public static bool IsEnumerable(this Type that)
        {
            if (that == TypeClass.StringClazz)
                return false;
            return typeof(IEnumerable).IsAssignableFrom(that);
        }

        #endregion

        #region IsTupleType

        /// <summary>
        /// Determine whether the given type is a tuple type.<br />
        /// 判断给定的类型是否为元组类型
        /// </summary>
        /// <param name="type"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static bool IsTupleType(this Type type, TypeOfOptions options = TypeOfOptions.Owner) => Types.IsTupleType(type, options);

        #endregion

        #region IsDefined

        /// <summary>
        /// Determine whether the specified type defines the specified Attribute.<br />
        /// 判断指定类型是否定义了指定的特性。
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsDefined<TAttribute>(this Type type) where TAttribute : Attribute
            => type.GetReflector().IsDefined<TAttribute>();

        /// <summary>
        /// Determine whether the specified type defines the specified Attribute.<br />
        /// 判断指定类型是否定义了指定的特性。
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <param name="type"></param>
        /// <param name="inherit"></param>
        /// <returns></returns>
        public static bool IsDefined<TAttribute>(this Type type, bool inherit) where TAttribute : Attribute
            => inherit
                ? type.GetCustomAttributes(typeof(TAttribute), true).Any(t => t is TAttribute)
                : type.IsDefined<TAttribute>();

        /// <summary>
        /// Determine whether the specified type defines the specified Attribute.<br />
        /// 判断指定类型是否定义了指定的特性。
        /// </summary>
        /// <param name="type"></param>
        /// <param name="attributeType"></param>
        /// <returns></returns>
        public static bool IsDefined(this Type type, Type attributeType)
            => type.GetReflector().IsDefined(attributeType);

        /// <summary>
        /// Determine whether the specified type defines the specified Attribute.<br />
        /// 判断指定类型是否定义了指定的特性。
        /// </summary>
        /// <param name="type"></param>
        /// <param name="attributeType"></param>
        /// <param name="inherit"></param>
        /// <returns></returns>
        public static bool IsDefined(this Type type, Type attributeType, bool inherit)
            => inherit
                ? type.GetCustomAttributes(attributeType, true).Any(t => t.GetType() == attributeType)
                : type.GetReflector().IsDefined(attributeType);

        /// <summary>
        /// Determine whether the specified type does NOT define the specified Attribute.<br />
        /// 判断指定类型是否未定义指定特性。
        /// </summary>
        /// <param name="type"></param>
        /// <typeparam name="TAttribute"></typeparam>
        /// <returns></returns>
        public static bool IsNotDefined<TAttribute>(this Type type) where TAttribute : Attribute
            => !type.IsDefined<TAttribute>();

        /// <summary>
        /// Determine whether the specified type does NOT define the specified Attribute.<br />
        /// 判断指定类型是否未定义指定特性。
        /// </summary>
        /// <param name="type"></param>
        /// <param name="attributeType"></param>
        /// <returns></returns>
        public static bool IsNotDefined(this Type type, Type attributeType)
            => !type.IsDefined(attributeType);

        #endregion

        #region HasAttribute

        /// <summary>
        /// Determine whether the specified type defines the specified Attribute.<br />
        /// 判断指定类型是否定义了指定的特性。
        /// </summary>
        /// <param name="type"></param>
        /// <typeparam name="TAttribute"></typeparam>
        /// <returns></returns>
        public static bool HasAttribute<TAttribute>(this Type type) where TAttribute : Attribute
            => type.IsDefined<TAttribute>();

        /// <summary>
        /// Determine whether the specified type defines the specified Attribute.<br />
        /// 判断指定类型是否定义了指定的特性。
        /// </summary>
        /// <param name="type"></param>
        /// <param name="inherit"></param>
        /// <typeparam name="TAttribute"></typeparam>
        /// <returns></returns>
        public static bool HasAttribute<TAttribute>(this Type type, bool inherit) where TAttribute : Attribute
            => type.IsDefined<TAttribute>(inherit);

        /// <summary>
        /// Determine whether the specified type defines the specified Attribute.<br />
        /// 判断指定类型是否定义了指定的特性。
        /// </summary>
        /// <param name="type"></param>
        /// <param name="attributeType"></param>
        /// <returns></returns>
        public static bool HasAttribute(this Type type, Type attributeType)
            => type.IsDefined(attributeType);

        /// <summary>
        /// Determine whether the specified type defines the specified Attribute.<br />
        /// 判断指定类型是否定义了指定的特性。
        /// </summary>
        /// <param name="type"></param>
        /// <param name="attributeType"></param>
        /// <param name="inherit"></param>
        /// <returns></returns>
        public static bool HasAttribute(this Type type, Type attributeType, bool inherit)
            => type.IsDefined(attributeType, inherit);

        /// <summary>
        /// Determine whether the specified type does NOT define the specified Attribute.<br />
        /// 判断指定类型是否未定义指定特性。
        /// </summary>
        /// <param name="type"></param>
        /// <typeparam name="TAttribute"></typeparam>
        /// <returns></returns>
        public static bool HasNotAttribute<TAttribute>(this Type type) where TAttribute : Attribute
            => !type.IsDefined<TAttribute>();

        /// <summary>
        /// Determine whether the specified type does NOT define the specified Attribute.<br />
        /// 判断指定类型是否未定义指定特性。
        /// </summary>
        /// <param name="type"></param>
        /// <param name="attributeType"></param>
        /// <returns></returns>
        public static bool HasNotAttribute(this Type type, Type attributeType)
            => !type.IsDefined(attributeType);

        #endregion

        #region HasInterface

        /// <summary>
        /// Determine whether the specified type defines the specified interface.<br />
        /// 判断指定类型是否定义了指定接口。
        /// </summary>
        /// <param name="type"></param>
        /// <typeparam name="TInterface"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static bool HasInterface<TInterface>(this Type type)
        {
            if (type is null)
                throw new ArgumentNullException(nameof(type));

            var interfaceType = typeof(TInterface);

            if (!interfaceType.IsInterface)
                throw new ArgumentException($"Type '{interfaceType.FullName}' is not an interface type.");

            return type.GetInterfaces().Any(x => x == interfaceType);
        }

        /// <summary>
        /// Determine whether the specified type defines the specified interface.<br />
        /// 判断指定类型是否定义了指定接口。
        /// </summary>
        /// <param name="type"></param>
        /// <param name="interfaceType"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static bool HasInterface(this Type type, Type interfaceType)
        {
            if (type is null)
                throw new ArgumentNullException(nameof(type));

            if (!interfaceType.IsInterface)
                throw new ArgumentException($"Type '{interfaceType.FullName}' is not an interface type.");

            return type.GetInterfaces().Any(x => x == interfaceType);
        }

        /// <summary>
        /// Determine whether the specified type does NOT define the specified interface.<br />
        /// 判断指定类型是否未定义指定接口
        /// </summary>
        /// <param name="type"></param>
        /// <typeparam name="TInterface"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static bool HasNotInterface<TInterface>(this Type type) =>
            !type.HasInterface<TInterface>();

        /// <summary>
        /// Determine whether the specified type does NOT define the specified interface.<br />
        /// 判断指定类型是否未定义指定接口
        /// </summary>
        /// <param name="type"></param>
        /// <param name="interfaceType"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static bool HasNotInterface(this Type type, Type interfaceType)
            => !type.HasInterface(interfaceType);

        #endregion
    }
}