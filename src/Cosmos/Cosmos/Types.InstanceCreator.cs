using System;
using System.Linq;
using AspectCore.Extensions.Reflection;

namespace Cosmos {
    /// <summary>
    /// Type Utilities
    /// </summary>
    public static partial class Types {

        #region CreateInstance

        /// <summary>
        /// Create instance
        /// </summary>
        /// <typeparam name="TInstance">Special type you need to return.</typeparam>
        /// <param name="args">Arguments for such type's constructor</param>
        /// <returns>Instance of special type</returns>
        public static TInstance CreateInstance<TInstance>(params object[] args) {
            if (args is null || args.Length == 0)
                return CreateInstanceCore<TInstance>();
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
            => CreateInstance(type, args) is TInstance ret ? ret : default;

        /// <summary>
        /// Create instance
        /// </summary>
        /// <param name="type">Special type</param>
        /// <param name="args">Arguments for such type's constructor</param>
        /// <returns>Instance of special type</returns>
        public static object CreateInstance(Type type, params object[] args) {
            if (args is null || args.Length == 0)
                return CreateInstanceCore(type);
            return CreateInstanceCore(type, args);
        }

        private static TInstance CreateInstanceCore<TInstance>()
            => CreateInstanceCore(typeof(TInstance)) is TInstance ret ? ret : default;

        private static TInstance CreateInstanceCore<TInstance>(object[] args)
            => CreateInstanceCore(typeof(TInstance), args) is TInstance ret ? ret : default;

        private static object CreateInstanceCore(Type type)
            => type.GetConstructors().FirstOrDefault(x => !x.GetParameters().Any())?.GetReflector().Invoke();

        private static object CreateInstanceCore(Type type, object[] args)
            => type.GetConstructor(Of(args))?.GetReflector().Invoke(args);

        #endregion

    }
}