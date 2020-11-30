using System;

namespace Cosmos.Reflection
{
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
        /// <param name="options"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool IsTupleType(Type type, TypeOfOptions options = TypeOfOptions.Owner)
        {
            if (type is null)
                throw new ArgumentNullException(nameof(type));

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

                if (options == TypeOfOptions.Owner)
                    break;

                type = type.BaseType;
            }

            return false;
        }

        /// <summary>
        /// Determine whether the given type is a tuple type.<br />
        /// 判断给定的类型是否为元组类型
        /// </summary>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool IsTupleType<T>(TypeOfOptions options = TypeOfOptions.Owner)
        {
            return IsTupleType(typeof(T), options);
        }
        
        #endregion
    }
}