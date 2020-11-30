using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Cosmos.Reflection
{
    /// <summary>
    /// Type conversion Utilities
    /// </summary>
    public static class TypeConv
    {
        /// <summary>
        /// Convert nullable type to underlying type. <br />
        /// 将可为空的类型转换为基础类型。
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Type GetNonNullableType(Type type)
        {
            if (type is null)
                return null;

            if (type.IsArray)
                return GetNonNullableType(type.GetElementType())?.MakeArrayType();

            var typeInfo = type.GetTypeInfo();

            if (typeInfo.IsGenericType)
            {
                var genericTypeDefinition = typeInfo.GetGenericTypeDefinition();

                if (genericTypeDefinition == typeof(Nullable<>))
                    return typeInfo.GetGenericArguments()[0];

                if (genericTypeDefinition == typeof(KeyValuePair<,>))
                {
                    var baseType = typeof(KeyValuePair<,>);
                    var args = typeInfo.GetGenericArguments();
                    return baseType.MakeGenericType(args[0], GetNonNullableType(args[1]));
                }

                if (IsCollectionImplementation(typeInfo, out var argumentType, out var dictionaryType))
                {
                    var baseType = typeInfo.GetGenericTypeDefinition();
                    return baseType.MakeGenericType(argumentType);
                }

                if (dictionaryType)
                {
                    var args = typeInfo.GetGenericArguments();
                    var baseType = typeInfo.GetGenericTypeDefinition();
                    return baseType.MakeGenericType(args[0], GetNonNullableType(args[1]));
                }
            }

            return type;

            bool IsCollectionImplementation(TypeInfo ti, out Type at, out bool dt)
            {
                at = null;
                dt = false;
                var argumentTypes = ti.GetGenericArguments();

                var ret = false;

                switch (argumentTypes.Length)
                {
                    case 1:
                    {
                        // List<T>, IList<T>
                        var allInterfaces = ti.GetInterfaces();
                        if (allInterfaces.Any(x => x == typeof(ICollection) || x == typeof(IEnumerable)))
                        {
                            at = GetNonNullableType(argumentTypes[0]);
                            dt = false;
                            ret = true;
                        }
                        else
                        {
                            at = null;
                            dt = false;
                        }

                        break;
                    }

                    case 2:
                    {
                        // Dictionary<TKey, TValue>, IDictionary<TKey, TValue>
                        var allInterfaces = ti.GetInterfaces();
                        if (allInterfaces.Contains(typeof(IDictionary)))
                        {
                            // Dictionary<TKey, TValue>
                            at = null;
                            dt = true;
                        }
                        else
                        {
                            //ICollection<KeyValuePair<TKey, TValue>>
                            var pairType = typeof(KeyValuePair<,>).MakeGenericType(argumentTypes[0], argumentTypes[1]);
                            var collType = typeof(ICollection<>).MakeGenericType(pairType);
                            if (allInterfaces.Contains(collType))
                            {
                                at = null;
                                dt = true;
                            }
                        }

                        break;
                    }
                }

                return ret;
            }
        }

        /// <summary>
        /// Convert nullable type to underlying type. <br />
        /// 将可为空的类型转换为基础类型。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Type GetNonNullableType<T>()
        {
            return GetNonNullableType(typeof(T));
        }
    }
}