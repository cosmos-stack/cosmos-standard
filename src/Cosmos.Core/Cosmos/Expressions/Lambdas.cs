﻿using System.Linq.Expressions;
using System.Reflection;
using Cosmos.Queries;

namespace Cosmos.Expressions;
//A copy of https://github.com/dotnetcore/Util/blob/master/src/Util/Helpers/Lambda.cs
//Author: 何镇汐

/// <summary>
/// Lambda Utils<br />
/// Lambda 工具集
/// </summary>
public static class Lambdas
{
    #region GetMember(获取成员)

    /// <summary>
    /// 获取成员
    /// </summary>
    /// <param name="expression">表达式,范例：t => t.Name</param>
    public static MemberInfo GetMember(Expression expression) => GetMemberExpression(expression)?.Member;

    /// <summary>
    /// 获取成员表达式
    /// </summary>
    /// <param name="expression">表达式</param>
    public static MemberExpression GetMemberExpression(Expression expression)
    {
        if (expression is null)
            return null;
        return expression.NodeType switch
        {
            ExpressionType.Lambda => GetMemberExpression(((LambdaExpression)expression).Body),
            ExpressionType.Convert => GetMemberExpression(((UnaryExpression)expression).Operand),
            ExpressionType.MemberAccess => (MemberExpression)expression,
            _ => null
        };
    }

    #endregion

    #region GetName(获取成员名称)

    /// <summary>
    /// 获取成员名称，范例：t => t.Name,返回 Name
    /// </summary>
    /// <param name="expression">表达式,范例：t => t.Name</param>
    public static string GetName(Expression expression) => GetMemberName(GetMemberExpression(expression));

    /// <summary>
    /// 获取成员名称
    /// </summary>
    private static string GetMemberName(MemberExpression memberExpression)
    {
        if (memberExpression is null)
            return string.Empty;
        var result = memberExpression.ToString();
        return result.Substring(result.IndexOf(".", StringComparison.Ordinal) + 1);
    }

    #endregion

    #region GetNames(获取名称列表)

    /// <summary>
    /// 获取名称列表
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    /// <param name="expression">属性集合表达式,范例：t => new object[]{t.A,t.B}</param>
    public static List<string> GetNames<T>(Expression<Func<T, object[]>> expression)
    {
        var result = new List<string>();
        if (expression is null)
            return result;
        if (!(expression.Body is NewArrayExpression arrayExpression))
            return result;
        foreach (var each in arrayExpression.Expressions)
            AddName(result, each);
        return result;
    }

    /// <summary>
    /// 添加名称
    /// </summary>
    private static void AddName(List<string> result, Expression expression)
    {
        var name = GetName(expression);
        if (string.IsNullOrWhiteSpace(name))
            return;
        result.Add(name);
    }

    #endregion

    #region GetValue(获取值)

    /// <summary>
    /// 获取值,范例：t => t.Name == "A",返回 A
    /// </summary>
    /// <param name="expression">表达式,范例：t => t.Name == "A"</param>
    public static object GetValue(Expression expression)
    {
        if (expression is null)
            return null;
        switch (expression.NodeType)
        {
            case ExpressionType.Lambda:
                return GetValue(((LambdaExpression)expression).Body);
            case ExpressionType.Convert:
                return GetValue(((UnaryExpression)expression).Operand);
            case ExpressionType.Equal:
            case ExpressionType.NotEqual:
            case ExpressionType.GreaterThan:
            case ExpressionType.LessThan:
            case ExpressionType.GreaterThanOrEqual:
            case ExpressionType.LessThanOrEqual:
                return GetValue(((BinaryExpression)expression).Right);
            case ExpressionType.Call:
                return GetMethodCallExpressionValue(expression);
            case ExpressionType.MemberAccess:
                return GetMemberValue((MemberExpression)expression);
            case ExpressionType.Constant:
                return GetConstantExpressionValue(expression);
        }

        return null;
    }

    /// <summary>
    /// 获取方法调用表达式的值
    /// </summary>
    private static object GetMethodCallExpressionValue(Expression expression)
    {
        var methodCallExpression = (MethodCallExpression)expression;
        var value = GetValue(methodCallExpression.Arguments.FirstOrDefault());
        return value ?? GetValue(methodCallExpression.Object);
    }

    /// <summary>
    /// 获取属性表达式的值
    /// </summary>
    private static object GetMemberValue(MemberExpression expression)
    {
        if (expression is null)
            return null;
        var field = expression.Member as FieldInfo;
        if (field != null)
        {
            var constValue = GetConstantExpressionValue(expression.Expression);
            return field.GetValue(constValue);
        }

        var property = expression.Member as PropertyInfo;
        if (property is null)
            return null;
        if (expression.Expression is null)
            return property.GetValue(null);
        var value = GetMemberValue(expression.Expression as MemberExpression);
        return value is null ? null : property.GetValue(value);
    }

    /// <summary>
    /// 获取常量表达式的值
    /// </summary>
    private static object GetConstantExpressionValue(Expression expression)
    {
        var constantExpression = (ConstantExpression)expression;
        return constantExpression.Value;
    }

    #endregion

    #region GetParameter(获取参数)

    /// <summary>
    /// 获取参数，范例：t.Name,返回 t
    /// </summary>
    /// <param name="expression">表达式，范例：t.Name</param>
    public static ParameterExpression GetParameter(Expression expression)
    {
        if (expression is null)
            return null;
        switch (expression.NodeType)
        {
            case ExpressionType.Lambda:
                return GetParameter(((LambdaExpression)expression).Body);
            case ExpressionType.Convert:
                return GetParameter(((UnaryExpression)expression).Operand);
            case ExpressionType.Equal:
            case ExpressionType.NotEqual:
            case ExpressionType.GreaterThan:
            case ExpressionType.LessThan:
            case ExpressionType.GreaterThanOrEqual:
            case ExpressionType.LessThanOrEqual:
                return GetParameter(((BinaryExpression)expression).Left);
            case ExpressionType.MemberAccess:
                return GetParameter(((MemberExpression)expression).Expression);
            case ExpressionType.Call:
                return GetParameter(((MethodCallExpression)expression).Object);
            case ExpressionType.Parameter:
                return (ParameterExpression)expression;
        }

        return null;
    }

    #endregion

    #region GetConditionCount(获取查询条件个数)

    /// <summary>
    /// 获取查询条件个数
    /// </summary>
    /// <param name="expression">谓词表达式,范例1：t => t.Name == "A" ，结果1。
    /// 范例2：t => t.Name == "A" &amp;&amp; t.Age =1 ，结果2。</param>
    public static int GetConditionCount(LambdaExpression expression)
    {
        if (expression is null)
            return 0;
        var result = expression.ToString().Replace("AndAlso", "|").Replace("OrElse", "|");
        return result.Split('|').Count();
    }

    #endregion

    #region GetAttribute(获取特性)

    /// <summary>
    /// 获取特性
    /// </summary>
    /// <typeparam name="TAttribute">特性类型</typeparam>
    /// <param name="expression">属性表达式</param>
    public static TAttribute GetAttribute<TAttribute>(Expression expression) where TAttribute : Attribute
    {
        return GetMember(expression)?.GetCustomAttribute<TAttribute>();
    }

    /// <summary>
    /// 获取特性
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TProperty">属性类型</typeparam>
    /// <typeparam name="TAttribute">特性类型</typeparam>
    /// <param name="propertyExpression">属性表达式</param>
    public static TAttribute GetAttribute<TEntity, TProperty, TAttribute>(Expression<Func<TEntity, TProperty>> propertyExpression)
        where TAttribute : Attribute
    {
        return GetAttribute<TAttribute>(propertyExpression);
    }

    /// <summary>
    /// 获取特性
    /// </summary>
    /// <typeparam name="TProperty">属性类型</typeparam>
    /// <typeparam name="TAttribute">特性类型</typeparam>
    /// <param name="propertyExpression">属性表达式</param>
    public static TAttribute GetAttribute<TProperty, TAttribute>(Expression<Func<TProperty>> propertyExpression)
        where TAttribute : Attribute
    {
        return GetAttribute<TAttribute>(propertyExpression);
    }

    #endregion

    #region GetAttributes(获取特性列表)

    /// <summary>
    /// 获取特性列表
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TProperty">属性类型</typeparam>
    /// <typeparam name="TAttribute">特性类型</typeparam>
    /// <param name="propertyExpression">属性表达式</param>
    public static IEnumerable<TAttribute> GetAttributes<TEntity, TProperty, TAttribute>(
        Expression<Func<TEntity, TProperty>> propertyExpression)
        where TAttribute : Attribute
    {
        return GetMember(propertyExpression)?.GetCustomAttributes<TAttribute>();
    }

    #endregion

    #region Constant(获取常量)

    /// <summary>
    /// 获取常量表达式
    /// </summary>
    /// <param name="expression">表达式</param>
    /// <param name="value">值</param>
    public static ConstantExpression Constant(Expression expression, object value)
    {
        if (!(expression is MemberExpression memberExpression))
            return Expression.Constant(value);
        return Expression.Constant(value, memberExpression.Type);
    }

    #endregion

    #region Equal(等于表达式)

    /// <summary>
    /// 创建等于运算lambda表达式
    /// </summary>
    /// <typeparam name="T">对象类型</typeparam>
    /// <param name="propertyName">属性名</param>
    /// <param name="value">值</param>
    public static Expression<Func<T, bool>> Equal<T>(string propertyName, object value)
    {
        var parameter = CreateParameter<T>();
        return parameter.Property(propertyName)?.Equal(value).ToLambda<Func<T, bool>>(parameter);
    }

    /// <summary>
    /// 创建参数
    /// </summary>
    private static ParameterExpression CreateParameter<T>() => Expression.Parameter(typeof(T), "t");

    #endregion

    #region NotEqual(不等于表达式)

    /// <summary>
    /// 创建不等于运算lambda表达式
    /// </summary>
    /// <typeparam name="T">对象类型</typeparam>
    /// <param name="propertyName">属性名</param>
    /// <param name="value">值</param>
    public static Expression<Func<T, bool>> NotEqual<T>(string propertyName, object value)
    {
        var parameter = CreateParameter<T>();
        return parameter.Property(propertyName)?.NotEqual(value).ToLambda<Func<T, bool>>(parameter);
    }

    #endregion

    #region Greater(大于表达式)

    /// <summary>
    /// 创建大于运算lambda表达式
    /// </summary>
    /// <typeparam name="T">对象类型</typeparam>
    /// <param name="propertyName">属性名</param>
    /// <param name="value">值</param>
    public static Expression<Func<T, bool>> Greater<T>(string propertyName, object value)
    {
        var parameter = CreateParameter<T>();
        return parameter.Property(propertyName)?.Greater(value).ToLambda<Func<T, bool>>(parameter);
    }

    #endregion

    #region GreaterEqual(大于等于表达式)

    /// <summary>
    /// 创建大于等于运算lambda表达式
    /// </summary>
    /// <typeparam name="T">对象类型</typeparam>
    /// <param name="propertyName">属性名</param>
    /// <param name="value">值</param>
    public static Expression<Func<T, bool>> GreaterEqual<T>(string propertyName, object value)
    {
        var parameter = CreateParameter<T>();
        return parameter.Property(propertyName)?.GreaterEqual(value).ToLambda<Func<T, bool>>(parameter);
    }

    #endregion

    #region Less(小于表达式)

    /// <summary>
    /// 创建小于运算lambda表达式
    /// </summary>
    /// <typeparam name="T">对象类型</typeparam>
    /// <param name="propertyName">属性名</param>
    /// <param name="value">值</param>
    public static Expression<Func<T, bool>> Less<T>(string propertyName, object value)
    {
        var parameter = CreateParameter<T>();
        return parameter.Property(propertyName)?.Less(value).ToLambda<Func<T, bool>>(parameter);
    }

    #endregion

    #region LessEqual(小于等于表达式)

    /// <summary>
    /// 创建小于等于运算lambda表达式
    /// </summary>
    /// <typeparam name="T">对象类型</typeparam>
    /// <param name="propertyName">属性名</param>
    /// <param name="value">值</param>
    public static Expression<Func<T, bool>> LessEqual<T>(string propertyName, object value)
    {
        var parameter = CreateParameter<T>();
        return parameter.Property(propertyName)?.LessEqual(value).ToLambda<Func<T, bool>>(parameter);
    }

    #endregion

    #region Starts(调用StartsWith方法)

    /// <summary>
    /// 调用StartsWith方法
    /// </summary>
    /// <typeparam name="T">对象类型</typeparam>
    /// <param name="propertyName">属性名</param>
    /// <param name="value">值</param>
    public static Expression<Func<T, bool>> Starts<T>(string propertyName, string value)
    {
        var parameter = CreateParameter<T>();
        return parameter.Property(propertyName)?.StartsWith(value).ToLambda<Func<T, bool>>(parameter);
    }

    #endregion

    #region Ends(调用EndsWith方法)

    /// <summary>
    /// 调用EndsWith方法
    /// </summary>
    /// <typeparam name="T">对象类型</typeparam>
    /// <param name="propertyName">属性名</param>
    /// <param name="value">值</param>
    public static Expression<Func<T, bool>> Ends<T>(string propertyName, string value)
    {
        var parameter = CreateParameter<T>();
        return parameter.Property(propertyName)?.EndsWith(value).ToLambda<Func<T, bool>>(parameter);
    }

    #endregion

    #region Contains(调用Contains方法)

    /// <summary>
    /// 调用Contains方法
    /// </summary>
    /// <typeparam name="T">对象类型</typeparam>
    /// <param name="propertyName">属性名</param>
    /// <param name="value">值</param>
    public static Expression<Func<T, bool>> Contains<T>(string propertyName, object value)
    {
        var parameter = CreateParameter<T>();
        return parameter.Property(propertyName)?.Contains(value).ToLambda<Func<T, bool>>(parameter);
    }

    #endregion

    #region ParsePredicate(解析为谓词表达式)

    /// <summary>
    /// 解析为谓词表达式
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    /// <param name="propertyName">属性名</param>
    /// <param name="value">值</param>
    /// <param name="operator">运算符</param>
    public static Expression<Func<T, bool>> ParsePredicate<T>(string propertyName, object value, Operator @operator)
    {
        var parameter = Expression.Parameter(typeof(T), "t");
        return parameter.Property(propertyName)?.Operation(@operator, value).ToLambda<Func<T, bool>>(parameter);
    }

    #endregion
}