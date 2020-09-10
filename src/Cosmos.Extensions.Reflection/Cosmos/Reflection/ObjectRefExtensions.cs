using System;
using System.Collections.Generic;
using System.Linq;
using FastMember;

namespace Cosmos.Reflection
{
    /// <summary>
    /// Cosmos <see cref="object"/> extensions.
    /// </summary>
    public static class ObjectRefExtensions
    {
        #region CreateTypeAccessor

        internal static T GetAttribute<T>(object[] attributes) where T : Attribute
        {
            if (!attributes.Any())
                return null;

            var attribute = (T) attributes.First();

            return attribute;
        }

        /// <summary>
        /// Create TypeAccessor
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static TypeAccessor CreateTypeAccessor(this Type type)
        {
            return TypeAccessorCache.Touch(type);
        }

        /// <summary>
        /// Create TypeAccessor
        /// </summary>
        /// <param name="type"></param>
        /// <param name="allowNonPublicAccessors"></param>
        /// <returns></returns>
        public static TypeAccessor CreateTypeAccessor(this Type type, bool allowNonPublicAccessors)
        {
            return TypeAccessorCache.Touch(type, allowNonPublicAccessors);
        }

        #endregion

        #region GetHashCode

        /// <summary>
        /// Get hashcode
        /// </summary>
        /// <param name="x"></param>
        /// <param name="hashFieldValuesFunc"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static int GetHashCode<T>(this T x, Func<T, IEnumerable<object>> hashFieldValuesFunc)
            => HashCodeUtil.InternalCalculator.GetHashCodeImpl(hashFieldValuesFunc(x));

        #endregion
    }
}