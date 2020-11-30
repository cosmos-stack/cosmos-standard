using System;

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
                throw new ArgumentNullException(nameof(type));

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
            return type != null
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
    }
}