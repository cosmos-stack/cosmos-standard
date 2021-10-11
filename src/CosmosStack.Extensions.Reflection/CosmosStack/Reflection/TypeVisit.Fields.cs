using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace CosmosStack.Reflection
{
    /// <summary>
    /// Type visit, an advanced TypeReflections utility. <br />
    /// 类型访问器，一个高级的 TypeReflections 工具。
    /// </summary>
    public static partial class TypeVisit
    {
        /// <summary>
        /// Get fields <br />
        /// 获取字段
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<FieldInfo> GetFields(Type type)
        {
            if (type is null)
                throw new ArgumentNullException(nameof(type));
            return type.GetFields();
        }
        
        /// <summary>
        /// Get fields <br />
        /// 获取字段
        /// </summary>
        /// <param name="fieldSelectors"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<FieldInfo> GetFields<T>(params Expression<Func<T, object>>[] fieldSelectors)
        {
            return GetFields((IEnumerable<Expression<Func<T, object>>>) fieldSelectors);
        }
        
        /// <summary>
        /// Get fields <br />
        /// 获取字段
        /// </summary>
        /// <param name="fieldSelectors"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<FieldInfo> GetFields<T>(IEnumerable<Expression<Func<T, object>>> fieldSelectors)
        {
            if (fieldSelectors is null)
                throw new ArgumentNullException(nameof(fieldSelectors));
            return fieldSelectors.Select(GetField);
        }

        /// <summary>
        /// Get field <br />
        /// 获取字段
        /// </summary>
        /// <param name="fieldSelector"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TField"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static FieldInfo GetField<T, TField>(Expression<Func<T, TField>> fieldSelector)
        {
            if (fieldSelector is null)
                throw new ArgumentNullException(nameof(fieldSelector));

            var member = fieldSelector.Body as MemberExpression;

            ArgumentException CreateExpressionNotFieldException() => new($"The expression parameter ({nameof(fieldSelector)}) is not a field expression.");

            if (member is null
             && fieldSelector.Body.NodeType == ExpressionType.Convert
             && fieldSelector.Body is UnaryExpression unary)
                member = unary.Operand as MemberExpression;

            if (member?.Member is not FieldInfo fieldInfo)
                throw CreateExpressionNotFieldException();

            return fieldInfo;
        }
    }
}