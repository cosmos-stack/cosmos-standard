using System.Collections.Concurrent;
using System.ComponentModel.Design;
using System.Reflection;

namespace Cosmos.Reflection;

/// <summary>
/// Reflection Utilities.
/// </summary>
public static partial class TypeReflections
{
    /// <summary>
    /// Type caching manager <br />
    /// 类型缓存管理器
    /// </summary>
    public static class TypeCacheManager
    {
        /// <summary>
        /// TypePropertyCache
        /// </summary>
        private static readonly ConcurrentDictionary<Type, PropertyInfo[]> TypePropertyCache = new();

        /// <summary>
        /// Get all properties' info by the given type <br />
        /// 根据给定的类型，反射获得其属性列表
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static PropertyInfo[] GetTypeProperties(Type type)
        {
            if (type is null)
                throw new ArgumentNullException(nameof(type));
            return TypePropertyCache.GetOrAdd(type, t => t.GetProperties());
        }

        /// <summary>
        /// Get all fields' info by the given type <br />
        /// 根据给定的类型，反射获得其字段列表
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static FieldInfo[] GetTypeFields(Type type)
        {
            if (type is null)
                throw new ArgumentNullException(nameof(type));
            return TypeFieldCache.GetOrAdd(type, t => t.GetFields());
        }

        private static readonly ConcurrentDictionary<Type, FieldInfo[]> TypeFieldCache = new();

        internal static readonly ConcurrentDictionary<Type, MethodInfo[]> TypeMethodCache = new();

        internal static readonly ConcurrentDictionary<Type, Func<ServiceContainer, object>> TypeNewFuncCache = new();

        internal static readonly ConcurrentDictionary<Type, ConstructorInfo> TypeConstructorCache = new();

        internal static readonly ConcurrentDictionary<Type, Func<object>> TypeEmptyConstructorFuncCache = new();

        internal static readonly ConcurrentDictionary<Type, Func<object[], object>> TypeConstructorFuncCache = new();

        internal static readonly ConcurrentDictionary<PropertyInfo, Func<object, object>> PropertyValueGetters = new();

        internal static readonly ConcurrentDictionary<PropertyInfo, Action<object, object>> PropertyValueSetters = new();
    }
}