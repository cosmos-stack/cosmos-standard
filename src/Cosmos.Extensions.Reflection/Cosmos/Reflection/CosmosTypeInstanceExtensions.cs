using System;

namespace Cosmos.Reflection
{
    /// <summary>
    /// Cosmos type instance extensions
    /// </summary>
    public static class CosmosTypeInstanceExtensions
    {
        /// <summary>
        /// Create an instance of the specified type.<br />
        /// 创建指定类型的实例。
        /// </summary>
        /// <typeparam name="TTypeInstance"></typeparam>
        /// <param name="type"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static TTypeInstance CreateInstance<TTypeInstance>(this Type type, params object[] args)
            => Types.CreateInstance<TTypeInstance>(type, args);
    }
}
