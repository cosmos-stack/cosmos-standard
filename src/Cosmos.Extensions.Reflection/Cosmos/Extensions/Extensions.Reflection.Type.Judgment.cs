using System;
using System.Reflection;
using Cosmos.Judgments;

// ReSharper disable once CheckNamespace
namespace Cosmos {
    public static partial class ReflectionExtensions {
        /// <summary>
        /// 判断指定类型是否为数值类型
        /// </summary>
        /// <param name="type">要检查的类型</param>
        /// <returns>是否是数值类型</returns>
        public static bool IsNumeric(this Type type) => TypeJudgment.IsNumericType(type);

        /// <summary>
        /// 判断指定类型是否为数值类型
        /// </summary>
        /// <param name="typeInfo">要检查的类型</param>
        /// <returns>是否是数值类型</returns>
        public static bool IsNumeric(this TypeInfo typeInfo) => TypeJudgment.IsNumericType(typeInfo);

        /// <summary>
        /// 指示类型是否为可空类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsNullableType(this Type type) => TypeJudgment.IsNullableType(type);

    }
}