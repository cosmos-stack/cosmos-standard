using System;
using System.Linq;
using System.Reflection;

namespace Cosmos.Judgments
{
    /// <summary>
    /// Type Judgment Utilities
    /// </summary>
    public static class TypeJudgment
    {
        #region IsEnumType

        /// <summary>
        /// Is enum type
        /// </summary>
        /// <param name="mayNullable"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool IsEnumType<T>(bool mayNullable = false) =>
            mayNullable
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

        #region IsNumericType

        /// <summary>
        /// To judge whether the type is number type or not.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool IsNumericType<T>() => IsNumericType(typeof(T));

        /// <summary>
        /// To judge whether the type is number type or not.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsNumericType(Type type) =>
            type == typeof(byte)
         || type == typeof(short)
         || type == typeof(int)
         || type == typeof(long)
         || type == typeof(sbyte)
         || type == typeof(ushort)
         || type == typeof(uint)
         || type == typeof(ulong)
         || type == typeof(decimal)
         || type == typeof(double)
         || type == typeof(float);

        /// <summary>
        /// To judge whether the type is number type or not.
        /// </summary>
        /// <param name="typeInfo"></param>
        /// <returns></returns>
        public static bool IsNumericType(TypeInfo typeInfo) => IsNumericType(typeInfo.AsType());

        #endregion

        #region IsNullableType

        /// <summary>
        /// To judge whether the type is nullable type or not.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool IsNullableType<T>() => IsNullableType(typeof(T));

        /// <summary>
        /// To judge whether the type is nullable type or not.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsNullableType(Type type) =>
            type != null
         && type.GetTypeInfo().IsGenericType
         && type.GetGenericTypeDefinition() == typeof(Nullable<>);

        /// <summary>
        /// To judge whether the type is nullable type or not.
        /// </summary>
        /// <param name="typeInfo"></param>
        /// <returns></returns>
        public static bool IsNullableType(TypeInfo typeInfo) => IsNullableType(typeInfo.AsType());

        #endregion

        #region IsGenericImplementation

        /// <summary>
        /// To judge the given type is assignable to the generic type or not.
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

            bool testFlag;

            //Testing interface
            testFlag = type.GetInterfaces().Any(_checkRawGenericType);
            if (testFlag) return true;

            //Testing class
            while (type != null && type != TypeClass.ObjectClass)
            {
                testFlag = _checkRawGenericType(type);
                if (testFlag) return true;
                type = type.BaseType;
            }

            //no matched for any classed or interfaces
            return false;

            // To check such type equals to specific type of class or interface
            // ReSharper disable once InconsistentNaming
            bool _checkRawGenericType(Type test)
                => genericType == (test.IsGenericType ? test.GetGenericTypeDefinition() : test);
        }

        /// <summary>
        /// To judge the given type is assignable to the generic type or not.
        /// </summary>
        /// <typeparam name="TGot">The given type TGot</typeparam>
        /// <typeparam name="TGeneric">The generic type TGeneric</typeparam>
        /// <returns></returns>
        public static bool IsGenericImplementation<TGot, TGeneric>() => IsGenericImplementation(typeof(TGot), typeof(TGeneric));

        #endregion
    }
}