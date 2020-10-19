using System;

#if !NET451 && !NET452
using System.Collections.Generic;
using System.Linq;

#endif

namespace Cosmos.Reflection
{
    /// <summary>
    /// Advanced Types utilities
    /// </summary>
    public static partial class NTypes
    {
        #region Create Instance

        /// <summary>
        /// Create instance
        /// </summary>
        /// <typeparam name="TInstance">Special type you need to return.</typeparam>
        /// <param name="args">Arguments for such type's constructor</param>
        /// <returns>Instance of special type</returns>
        public static TInstance CreateInstance<TInstance>(params object[] args) => Types.CreateInstance<TInstance>(args);

        /// <summary>
        /// Create instance
        /// </summary>
        /// <typeparam name="TInstance">Special type you need to return.</typeparam>
        /// <param name="type">Special type</param>
        /// <param name="args">Arguments for such type's constructor</param>
        /// <returns>Instance of special type</returns>
        public static TInstance CreateInstance<TInstance>(Type type, params object[] args) => Types.CreateInstance<TInstance>(type, args);

        /// <summary>
        /// Create instance
        /// </summary>
        /// <param name="type">Special type</param>
        /// <param name="args">Arguments for such type's constructor</param>
        /// <returns>Instance of special type</returns>
        public static object CreateInstance(Type type, params object[] args) => Types.CreateInstance(type, args);

        /// <summary>
        /// Create instance with no param
        /// </summary>
        /// <typeparam name="TInstance"></typeparam>
        /// <returns></returns>
        public static TInstance CreateInstanceWithoutParam<TInstance>() => Types.CreateInstanceWithoutParam<TInstance>();

        #endregion

#if !NET451 && !NET452

        #region Create Instance with CtorArgDescriptor

        /// <summary>
        /// Create instance
        /// </summary>
        /// <param name="ctorArgDescriptors"></param>
        /// <typeparam name="TInstance"></typeparam>
        /// <returns></returns>
        public static TInstance CreateInstance<TInstance>(IEnumerable<CtorArgDescriptor> ctorArgDescriptors)
        {
            if (ctorArgDescriptors is null)
                return Types.CreateInstance<TInstance>();
            var descriptors = ctorArgDescriptors.ToList();
            return !descriptors.Any()
                ? Types.CreateInstance<TInstance>()
                : CreateInstanceCore<TInstance>(descriptors);
        }

        /// <summary>
        /// Create instance
        /// </summary>
        /// <param name="type"></param>
        /// <param name="ctorArgDescriptors"></param>
        /// <typeparam name="TInstance"></typeparam>
        /// <returns></returns>
        public static TInstance CreateInstance<TInstance>(Type type, IEnumerable<CtorArgDescriptor> ctorArgDescriptors)
        {
            if (ctorArgDescriptors is null)
                return Types.CreateInstance<TInstance>();
            var descriptors = ctorArgDescriptors.ToList();
            var instance = !descriptors.Any()
                ? Types.CreateInstance(type)
                : CreateInstanceCore(type, descriptors);

            return instance is TInstance ret ? ret : default;
        }

        /// <summary>
        /// Create instance
        /// </summary>
        /// <param name="type"></param>
        /// <param name="ctorArgDescriptors"></param>
        /// <returns></returns>
        public static object CreateInstance(Type type, IEnumerable<CtorArgDescriptor> ctorArgDescriptors)
        {
            if (ctorArgDescriptors is null)
                return Types.CreateInstance(type);
            var descriptors = ctorArgDescriptors.ToList();
            if (!descriptors.Any())
                return Types.CreateInstance(type);
            return CreateInstanceCore(type, descriptors);
        }

        private static TInstance CreateInstanceCore<TInstance>(IEnumerable<CtorArgDescriptor> ctorArgDescriptors)
            => CreateInstanceCore(typeof(TInstance), ctorArgDescriptors) is TInstance ret ? ret : default;

        private static object CreateInstanceCore(Type type, IEnumerable<CtorArgDescriptor> ctorArgDescriptors)
        {
            /*
             * Author: LanX
             * 2020.01.03
             */

            var template = CtorTemplate.Create(type);
            return template.GetCtor(ctorArgDescriptors);
        }

        #endregion

#endif
    }
}