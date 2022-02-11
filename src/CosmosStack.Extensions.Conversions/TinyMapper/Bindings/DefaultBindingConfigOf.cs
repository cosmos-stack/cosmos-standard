using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CosmosStack.ObjectMapping;

namespace TinyMapper.Bindings
{
    internal sealed class DefaultBindingConfigOf<TSource, TTarget> : BindingConfig, IDefaultBindingConfig<TSource, TTarget>
    {
        public void Bind(Expression<Func<TSource, object>> source, Expression<Func<TTarget, object>> target)
        {
            var sourcePath = GetMemberInfoPath(source);
            var targetPath = GetMemberInfoPath(target);

            if (sourcePath.Count == 1 && targetPath.Count == 1 &&
                string.Equals(sourcePath[0], targetPath[0], StringComparison.Ordinal))
            {
                return;
            }

            BindFields(sourcePath, targetPath);
        }

        public void Bind(Expression<Func<TTarget, object>> target, Type targetType)
        {
            var targetName = GetMemberInfo(target);
            BindType(targetName, targetType);
        }

        public void Ignore(Expression<Func<TSource, object>> expression)
        {
            var memberName = GetMemberInfo(expression);
            IgnoreSourceField(memberName);
        }

        private static string GetMemberInfo<T, TField>(Expression<Func<T, TField>> expression)
        {
            var member = expression.Body as MemberExpression;
            if (member is null)
            {
                if (expression.Body is UnaryExpression unaryExpression)
                {
                    member = unaryExpression.Operand as MemberExpression;
                }

                if (member is null)
                {
                    throw new ArgumentException("Expression is not a MemberExpression", "expression");
                }
            }

            return member.Member.Name;
        }

        private static List<string> GetMemberInfoPath<T, TField>(Expression<Func<T, TField>> expression)
        {
            var member = expression.Body as MemberExpression;
            if (member is null)
            {
                if (expression.Body is UnaryExpression unaryExpression)
                {
                    member = unaryExpression.Operand as MemberExpression;
                }

                if (member is null)
                {
                    throw new ArgumentException("Expression is not a MemberExpression", nameof(expression));
                }
            }

            var result = new List<string>();
            do
            {
                var resultMember = member.Member;
                result.Add(resultMember.Name);
                member = member.Expression as MemberExpression;
            }
            while (member != null);

            result.Reverse();
            return result;
        }
    }
}