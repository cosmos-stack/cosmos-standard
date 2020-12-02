using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Cosmos.Reflection
{
    /// <summary>
    /// Type visit, an advanced TypeReflections utility.
    /// </summary>
    public static partial class TypeVisit
    {
        public static IEnumerable<FieldInfo> GetFields(Type type)
        {
            if (type is null)
                throw new ArgumentNullException(nameof(type));
            return type.GetFields();
        }
        
        public static IEnumerable<FieldInfo> GetFields<T>(params Expression<Func<T, object>>[] fieldSelectors)
        {
            return GetFields((IEnumerable<Expression<Func<T, object>>>) fieldSelectors);
        }
        
        public static IEnumerable<FieldInfo> GetFields<T>(IEnumerable<Expression<Func<T, object>>> fieldSelectors)
        {
            if (fieldSelectors is null)
                throw new ArgumentNullException(nameof(fieldSelectors));
            return fieldSelectors.Select(GetField);
        }

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