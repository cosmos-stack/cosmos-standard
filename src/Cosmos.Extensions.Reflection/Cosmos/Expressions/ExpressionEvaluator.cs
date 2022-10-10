using System.Linq.Expressions;

namespace Cosmos.Expressions;

/*
 * Reference: https://github.com/liyanjie8712/BuildingBlocks
 *      Author: liyanjie8712
 *      License: MIT
 */

public static class ExpressionEvaluator
{
    static readonly ParameterExpression _parameterExpression = Expression.Parameter(typeof(object));
    
    /// <summary>
    /// 评估
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static object Evaluate(string input)
    {
        var parser = new ExpressionParser(_parameterExpression, null);
        var expression = parser.Parse(input);
        var function = Expression.Lambda(expression).Compile();
        var result = function.DynamicInvoke();
        return result;
    }

    /// <summary>
    /// 评估
    /// </summary>
    /// <param name="input">表达式字符串</param>
    /// <param name="variables">变量字典</param>
    /// <returns></returns>
    public static object Evaluate(string input, ref IDictionary<string, object> variables)
    {
        var parser = new ExpressionParser(_parameterExpression, variables);
        var expression = parser.Parse(input);
        var function = Expression.Lambda(expression).Compile();
        var result = function.DynamicInvoke();
        variables = parser.Variables;
        return result;
    }
}