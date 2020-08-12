using System;
using System.Linq;
using FastMember;

namespace Cosmos.Reflection
{
    /// <summary>
    /// Cosmos <see cref="object"/> extensions.
    /// </summary>
    public static class CosmosObjectExtensions
    {
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
    }
}