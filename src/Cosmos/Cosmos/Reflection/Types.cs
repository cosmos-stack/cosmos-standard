using System;
using System.Linq;
using System.Reflection;
using AspectCore.Extensions.Reflection;

namespace Cosmos.Reflection
{
    /// <summary>
    /// Type Utilities
    /// </summary>
    public static partial class Types
    {
        #region Of

        /// <summary>
        /// Get type
        /// </summary>
        /// <typeparam name="T">Special type T</typeparam>
        public static Type Of<T>() => TypeReflections.GetUnderlyingType<T>();

        /// <summary>
        /// Get types
        /// </summary>
        /// <param name="objColl">Object array</param>
        /// <returns></returns>
        public static Type[] Of(object[] objColl)
        {
            if (objColl is null)
                return null;
            if (!objColl.Contains(null))
                return Type.GetTypeArray(objColl);
            var types = new Type[objColl.Length];
            for (var i = 0; i < objColl.Length; i++)
                types[i] = objColl[i].GetType();
            return types;
        }

        #endregion

        #region DefaultValue

        /// <summary>
        /// Get default value of special type T.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T DefaultValue<T>() => TypeDefault.Of<T>();

        #endregion

        #region GenericImplementation and raw type

        /// <summary>
        /// Determine whether the given type can be assigned to the specified generic type.<br />
        /// 判断给定的类型是否可赋值给指定的泛型类型。
        /// </summary>
        /// <param name="type">The given type</param>
        /// <param name="genericType">The generic type</param>
        /// <returns></returns>
        public static bool IsGenericImplementation(Type type, Type genericType)
        {
            if (type is null)
                throw new ArgumentNullException(nameof(type));

            if (genericType is null)
                throw new ArgumentNullException(nameof(genericType));

            if (!genericType.IsGenericType)
                return false;

            // ReSharper disable once JoinDeclarationAndInitializer
            bool testFlag;

            //Testing interface
            testFlag = type.GetInterfaces().Any(_checkRawGenericType);
            if (testFlag) return true;

            //Testing class
            while (type != null && type != TypeClass.ObjectClazz)
            {
                testFlag = _checkRawGenericType(type);
                if (testFlag) return true;
                type = type.BaseType;
            }

            //no matched for any classed or interfaces
            return false;

            // To check such type equals to specific type of class or interface
            // 检查给定的这个 test 类型是否等于指定类 Class 或接口 Interface 的类型 Type
            // ReSharper disable once InconsistentNaming
            bool _checkRawGenericType(Type test)
                => genericType == (test.IsGenericType ? test.GetGenericTypeDefinition() : test);
        }

        /// <summary>
        /// Determine whether the given type can be assigned to the specified generic type.<br />
        /// 判断给定的类型是否可赋值给指定的泛型类型。
        /// </summary>
        /// <typeparam name="TGot">The given type TGot</typeparam>
        /// <typeparam name="TGeneric">The generic type TGeneric</typeparam>
        /// <returns></returns>
        public static bool IsGenericImplementation<TGot, TGeneric>() =>  IsGenericImplementation(typeof(TGot), typeof(TGeneric));

        /// <summary>
        /// Get the original type. <br />
        /// When type inherits from genericType, gets the first type parameter in the genericType corresponding to the type.
        /// </summary>
        /// <param name="type">The given type</param>
        /// <param name="genericType">The generic type</param>
        /// <returns></returns>
        public static Type GetRawTypeFromGenericClass(Type type, Type genericType) => TypeReflections.GetRawTypeFromGenericClass(type, genericType);

        /// <summary>
        /// Get the original type. <br />
        /// When type inherits from genericType, gets the first type parameter in the genericType corresponding to the type.
        /// </summary>
        /// <typeparam name="TGot">The given type TGot</typeparam>
        /// <typeparam name="TGeneric">The generic type TGeneric</typeparam>
        /// <returns></returns>
        public static Type GetRawTypeFromGenericClass<TGot, TGeneric>() => TypeReflections.GetRawTypeFromGenericClass<TGot, TGeneric>();

        #endregion

        #region Enum Type

        /// <summary>
        /// Is enum type
        /// </summary>
        /// <param name="mayNullable"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool IsEnumType<T>(bool mayNullable = false) => mayNullable
            ? (Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T)).IsEnum
            : typeof(T).IsEnum;

        /// <summary>
        /// Is enum type
        /// </summary>
        /// <param name="type"></param>
        /// <param name="mayNullable"></param>
        /// <returns></returns>
        public static bool IsEnumType(Type type, bool mayNullable = false) =>
            mayNullable
                ? (Nullable.GetUnderlyingType(type) ?? type).IsEnum
                : type.IsEnum;

        /// <summary>
        /// Is enum type
        /// </summary>
        /// <param name="typeInfo"></param>
        /// <param name="mayNullable"></param>
        /// <returns></returns>
        public static bool IsEnumType(TypeInfo typeInfo, bool mayNullable = false) =>
            mayNullable
                ? (Nullable.GetUnderlyingType(typeInfo) ?? typeInfo).IsEnum
                : typeInfo.IsEnum;

        #endregion

        #region Numeric Type

        /// <summary>
        /// Is numeric type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool IsNumericType<T>() => IsNumericType(typeof(T));

        /// <summary>
        /// Is numeric type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsNumericType(Type type)
        {
            return type == TypeClass.ByteClazz
                || type == TypeClass.Int16Clazz
                || type == TypeClass.Int32Clazz
                || type == TypeClass.Int64Clazz
                || type == TypeClass.SByteClazz
                || type == TypeClass.UInt16Clazz
                || type == TypeClass.UInt32Clazz
                || type == TypeClass.UInt64Clazz
                || type == TypeClass.DecimalClazz
                || type == TypeClass.DoubleClazz
                || type == TypeClass.FloatClazz;
        }

        /// <summary>
        /// Is numeric type
        /// </summary>
        /// <param name="typeInfo"></param>
        /// <returns></returns>
        public static bool IsNumericType(TypeInfo typeInfo) => IsNumericType(typeInfo.AsType());

        #endregion

        #region Nullable Type

        /// <summary>
        /// Is nullable type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool IsNullableType<T>() => IsNullableType(typeof(T));

        /// <summary>
        /// Is nullable type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsNullableType(Type type) =>
            type != null
         && type.IsGenericType
         && type.GetGenericTypeDefinition() == typeof(Nullable<>);

        /// <summary>
        /// Is nullable type
        /// </summary>
        /// <param name="typeInfo"></param>
        /// <returns></returns>
        public static bool IsNullableType(TypeInfo typeInfo) => IsNullableType(typeInfo.AsType());

        #endregion

        #region Tuple Type

        /// <summary>
        /// Is tuple type
        /// </summary>
        /// <param name="type"></param>
        /// <param name="checkBaseTypes"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool IsTupleType(Type type, bool checkBaseTypes = false)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            if (type == typeof(Tuple))
                return true;
            if (type == typeof(ValueTuple))
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

                if (!checkBaseTypes)
                    break;

                type = type.BaseType;
            }

            return false;
        }

        #endregion

        #region CreateInstance

        /// <summary>
        /// Create instance
        /// </summary>
        /// <typeparam name="TInstance">Special type you need to return.</typeparam>
        /// <param name="args">Arguments for such type's constructor</param>
        /// <returns>Instance of special type</returns>
        public static TInstance CreateInstance<TInstance>(params object[] args)
        {
            return CreateInstanceCore<TInstance>(args);
        }

        /// <summary>
        /// Create instance
        /// </summary>
        /// <typeparam name="TInstance">Special type you need to return.</typeparam>
        /// <param name="type">Special type</param>
        /// <param name="args">Arguments for such type's constructor</param>
        /// <returns>Instance of special type</returns>
        public static TInstance CreateInstance<TInstance>(Type type, params object[] args)
        {
            return CreateInstance(type, args) is TInstance ret ? ret : TypeDefault.Of<TInstance>();
        }

        /// <summary>
        /// Create instance
        /// </summary>
        /// <param name="type">Special type</param>
        /// <param name="args">Arguments for such type's constructor</param>
        /// <returns>Instance of special type</returns>
        public static object CreateInstance(Type type, params object[] args)
        {
            return CreateInstanceCore(type, args);
        }

        private static TInstance CreateInstanceCore<TInstance>() =>
            CreateInstanceCore(typeof(TInstance)) is TInstance ret ? ret : TypeDefault.Of<TInstance>();

        private static TInstance CreateInstanceCore<TInstance>(object[] args) =>
            CreateInstanceCore(typeof(TInstance), args) is TInstance ret ? ret : TypeDefault.Of<TInstance>();

        private static object CreateInstanceCore(Type type, params object[] args) =>
            args is null || args.Length == 0
                ? type.GetConstructors().FirstOrDefault(x => !x.GetParameters().Any())?.GetReflector().Invoke()
                : type.GetConstructor(Of(args))?.GetReflector().Invoke(args);

        #endregion
    }
}