﻿using System.Linq.Expressions;
using Cosmos.Queries;

namespace Cosmos.Expressions;

/// <summary>
/// 谓词表达式生成器
/// </summary>
public class PredicateExpressionBuilder<TEntity>
{
    /// <summary>
    /// 初始化谓词表达式生成器
    /// </summary>
    public PredicateExpressionBuilder()
    {
        _parameter = Expression.Parameter(typeof(TEntity), "t");
        _result = null;
    }

    /// <summary>
    /// 参数
    /// </summary>
    private readonly ParameterExpression _parameter;

    /// <summary>
    /// 结果表达式
    /// </summary>
    private Expression _result;

    /// <summary>
    /// 获取参数
    /// </summary>
    public ParameterExpression GetParameter()
    {
        return _parameter;
    }

    /// <summary>
    /// 添加表达式
    /// </summary>
    /// <param name="property">属性表达式</param>
    /// <param name="operator">运算符</param>
    /// <param name="value">值</param>
    public void Append<TProperty>(Expression<Func<TEntity, TProperty>> property, Operator @operator, object value)
    {
        _result = _result.And(_parameter.Property(Lambdas.GetMember(property)!).Operation(@operator, value));
    }

    /// <summary>
    /// 添加表达式
    /// </summary>
    /// <param name="property">属性名</param>
    /// <param name="operator">运算符</param>
    /// <param name="value">值</param>
    public void Append(string property, Operator @operator, object value)
    {
        _result = _result.And(_parameter.Property(property)?.Operation(@operator, value));
    }

    /// <summary>
    /// 转换为Lambda表达式
    /// </summary>
    public Expression<Func<TEntity, bool>> ToLambda()
    {
        return _result.ToLambda<Func<TEntity, bool>>(_parameter);
    }
}