﻿using System.Linq.Expressions;

namespace Cosmos.Expressions;
//A copy of https://github.com/dotnetcore/Util/blob/HEAD/src/Util/Expressions/ParameterRebinder.cs
//Author: 何镇汐

/// <summary>
/// 参数重绑定操作
/// </summary>
public class ParameterRebinder : ExpressionVisitor
{
    /// <summary>
    /// 参数字典
    /// </summary>
    private readonly Dictionary<ParameterExpression, ParameterExpression> _map;

    /// <summary>
    /// 初始化参数重绑定操作
    /// </summary>
    /// <param name="map">参数字典</param>
    public ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> map)
    {
        _map = map ?? new();
    }

    /// <summary>
    /// 替换参数
    /// </summary>
    /// <param name="map">参数字典</param>
    /// <param name="exp">表达式</param>
    public static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> map, Expression exp)
    {
        return new ParameterRebinder(map).Visit(exp);
    }

    /// <summary>
    /// 访问参数
    /// </summary>
    /// <param name="parameterExpression">参数</param>
    protected override Expression VisitParameter(ParameterExpression parameterExpression)
    {
        if (_map.TryGetValue(parameterExpression, out var replacement))
            parameterExpression = replacement;
        return base.VisitParameter(parameterExpression);
    }
}