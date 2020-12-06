using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Cosmos.Reflection
{
    /// <summary>
    /// Type visit, an advanced TypeReflections utility.
    /// </summary>
    public static partial class TypeVisit { }

    /// <summary>
    /// Type metadata visit, a meta information access entry for TypeReflections and TypeVisit.
    /// </summary>
    public static partial class TypeMetaVisitExtensions
    {
        public static bool IsDescriptionDefined(this MemberInfo member, ReflectionOptions options = ReflectionOptions.Default)
        {
            return TypeReflections.IsDescriptionDefined(member, options);
        }

        public static string GetDescription(this MemberInfo member, ReflectionOptions options = ReflectionOptions.Default)
        {
            return TypeReflections.GetDescription(member, options);
        }

        public static string GetDescription<T>(this T x, Expression<Func<T, object>> expression, ReflectionOptions options = ReflectionOptions.Default)
        {
            return x is null ? string.Empty : TypeReflections.GetDescription(expression, options);
        }

        public static string GetDescriptionOr(this MemberInfo member, string defaultVal, ReflectionOptions options = ReflectionOptions.Default)
        {
            return TypeReflections.GetDescriptionOr(member, defaultVal, options);
        }

        public static string GetDescriptionOr<T>(this T x, Expression<Func<T, object>> expression, string defaultVal, ReflectionOptions options = ReflectionOptions.Default)
        {
            return x is null ? defaultVal : TypeReflections.GetDescriptionOr(expression, defaultVal, options);
        }
    }
}