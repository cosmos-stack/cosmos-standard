using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using DeepCopy;

namespace Cosmos.Reflection
{
    /// <summary>
    /// Cosmos object copy extensions
    /// </summary>
    public static class ObjectRefCopyExtensions
    {
        #region DeepCopy

        /// <summary>
        /// Deep copy<br />
        /// 深度复制
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="originalObj"></param>
        /// <returns></returns>
        public static T DeepCopy<T>(this T originalObj) => DeepCopier.Copy(originalObj);

        #endregion

        #region ExpressionCopy

        /// <summary>
        /// Expression copy<br />
        /// 表达式复制
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="originalObj"></param>
        /// <returns></returns>
        public static T ExpressionCopy<T>(this T originalObj) => ExpressionCopyHelper.Copier<T>.Copy(originalObj);

        /*
         * Reference to:
         *  ldqk/Masuit.Tools
         *      Author: LDQK/Masuit
         *      URL: https://github.com/ldqk/Masuit.Tools
         *      Blog: https://masuit.com
         *      MIT
         */

        private static class ExpressionCopyHelper
        {

            public static class Copier<T>
            {
                // ReSharper disable once InconsistentNaming
                private static readonly ParameterExpression _parameterExpression = Expression.Parameter(typeof(T), "p");

                // ReSharper disable once InconsistentNaming
                // ReSharper disable once CollectionNeverUpdated.Local
                // ReSharper disable once StaticMemberInGenericType
                private static readonly Dictionary<string, Expression> _check = new Dictionary<string, Expression>();
                private static Func<T, T> _func;

                /// <summary>
                /// Deep copy by expression
                /// </summary>
                /// <param name="source"></param>
                /// <returns></returns>
                public static T Copy(T source)
                {
                    if (_func is null)
                    {
                        var memberBindings = new List<MemberBinding>();

                        foreach (var item in GetAllPropertiesOrFields())
                        {
                            if (_check.ContainsKey(item.Name))
                            {
                                var memberBinding = Expression.Bind(item, _check[item.Name]);
                                memberBindings.Add(memberBinding);
                            }
                            else
                            {
                                if (typeof(T).GetProperty(item.Name) != null || typeof(T).GetField(item.Name) != null)
                                {
                                    var memberBinding = Expression.Bind(
                                        item,
                                        Expression.PropertyOrField(_parameterExpression, item.Name));
                                    memberBindings.Add(memberBinding);
                                }
                            }
                        }

                        var memberInitExpression = Expression.MemberInit(Expression.New(typeof(T)), memberBindings.ToArray());
                        var lambda = Expression.Lambda<Func<T, T>>(memberInitExpression, _parameterExpression);
                        _func = lambda.Compile();
                    }

                    return _func.Invoke(source);
                }

                private static IEnumerable<MemberInfo> GetAllPropertiesOrFields()
                {
                    foreach (var item in typeof(T).GetProperties())
                        yield return item;
                    foreach (var item in typeof(T).GetFields())
                        yield return item;
                }
            }

        }

        #endregion
    }
}
