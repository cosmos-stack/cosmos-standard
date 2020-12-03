using System.Reflection;

namespace Cosmos.Reflection
{
    /// <summary>
    /// Type metadata visit, a meta information access entry for TypeReflections and TypeVisit.
    /// </summary>
    public static partial class TypeMetaVisitExtensions
    {
        /// <summary>
        /// Determine whether the specified method is an asynchronous method.<br />
        /// 判断指定的方法是否为异步方法。
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        public static bool IsAsyncMethod(this MethodInfo method)
        {
            return method.ReturnType == TypeClass.TaskClazz
                || method.ReturnType == TypeClass.ValueTaskClazz
                || method.ReturnType.IsGenericType && method.ReturnType.GetGenericTypeDefinition() == TypeClass.GenericTaskClazz
                || method.ReturnType.IsGenericType && method.ReturnType.GetGenericTypeDefinition() == TypeClass.GenericValueTaskClazz;
        }

        /// <summary>
        /// Determine whether the specified method is an overriding method.<br />
        /// 判断指定方法是否是重写方法
        /// </summary>
        /// <param name="method">要判断的方法信息</param>
        /// <returns>是否是重写方法</returns>
        public static bool IsOverridden(this MethodInfo method)
        {
            return method.GetBaseDefinition().DeclaringType != method.DeclaringType;
        }
    }
}