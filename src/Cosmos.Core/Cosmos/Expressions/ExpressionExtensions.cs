using System.Linq.Expressions;

namespace Cosmos.Expressions;

/// <summary>
/// public <see cref="Expression"/> extensions.
/// </summary>
public static class ExpressionExtensions
{
    #region Create an expression to get property info

    private static ParameterExpression CreateParameterExpression(this Type type)
    {
        ArgumentNullException.ThrowIfNull(type);
        return Expression.Parameter(type, "o");
    }

    /// <summary>
    /// Create get property expression
    /// </summary>
    /// <param name="propertyInfo"></param>
    /// <returns></returns>
    public static MemberExpression CreateGetPropertyExpression(this PropertyInfo propertyInfo)
    {
        ArgumentNullException.ThrowIfNull(propertyInfo);
        ArgumentNullException.ThrowIfNull(propertyInfo.DeclaringType);
        return propertyInfo.CreateGetPropertyExpression(propertyInfo.DeclaringType.CreateParameterExpression());
    }

    /// <summary>
    /// Create get property expression
    /// </summary>
    /// <param name="propertyInfo"></param>
    /// <param name="parameterExpression"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    public static MemberExpression CreateGetPropertyExpression(this PropertyInfo propertyInfo, ParameterExpression parameterExpression)
    {
        ArgumentNullException.ThrowIfNull(propertyInfo);
        ArgumentNullException.ThrowIfNull(parameterExpression);

        if (!propertyInfo.DeclaringType!.GetTypeInfo().IsAssignableFrom(parameterExpression.Type.GetTypeInfo()))
            throw new InvalidOperationException(
                $"The type of {nameof(parameterExpression)} ({parameterExpression.Type} " +
                $"is not assignable to the type of {nameof(propertyInfo.DeclaringType)} " +
                $"({propertyInfo.DeclaringType}) passed in the {nameof(propertyInfo)} parameter.");

        return Expression.Property(parameterExpression, propertyInfo);
    }

    /// <summary>
    /// Create get property lambda expression
    /// </summary>
    /// <param name="propertyInfo"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TProperty"></typeparam>
    /// <returns></returns>
    public static Expression<Func<T, TProperty>> CreateGetPropertyLambdaExpression<T, TProperty>(this PropertyInfo propertyInfo)
    {
        return propertyInfo.CreateGetPropertyLambdaExpression<T, TProperty>(typeof(T).CreateParameterExpression());
    }

    /// <summary>
    /// Create get property lambda expression
    /// </summary>
    /// <param name="propertyInfo"></param>
    /// <param name="parameterExpression"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TProperty"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static Expression<Func<T, TProperty>> CreateGetPropertyLambdaExpression<T, TProperty>(this PropertyInfo propertyInfo, ParameterExpression parameterExpression)
    {
        ArgumentNullException.ThrowIfNull(propertyInfo);
        ArgumentNullException.ThrowIfNull(parameterExpression);

        var propertyExpression = propertyInfo.CreateGetPropertyExpression(parameterExpression);

        Expression expression = propertyExpression;
        var type = typeof(TProperty);

        if (propertyInfo.PropertyType != type)
            expression = Expression.Convert(expression, type);

        // ReSharper disable once AssignNullToNotNullAttribute
        return Expression.Lambda<Func<T, TProperty>>(expression, (propertyExpression.Expression as ParameterExpression)!);
    }

    #endregion

    #region And/Or

    // https://stackoverflow.com/questions/457316/combining-two-expressions-expressionfunct-bool/457328#457328

    public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
    {
        var parameter = Expression.Parameter(typeof(T));

        var leftVisitor = new ReplaceExpressionVisitor(expr1.Parameters[0], parameter);
        var left = leftVisitor.Visit(expr1.Body);
        var rightVisitor = new ReplaceExpressionVisitor(expr2.Parameters[0], parameter);
        var right = rightVisitor.Visit(expr2.Body);

        ArgumentNullException.ThrowIfNull(left);
        ArgumentNullException.ThrowIfNull(right);

        return Expression.Lambda<Func<T, bool>>(Expression.OrElse(left, right), parameter);
    }

    public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
    {
        var parameter = Expression.Parameter(typeof(T));

        var leftVisitor = new ReplaceExpressionVisitor(expr1.Parameters[0], parameter);
        var left = leftVisitor.Visit(expr1.Body);
        var rightVisitor = new ReplaceExpressionVisitor(expr2.Parameters[0], parameter);
        var right = rightVisitor.Visit(expr2.Body);

        ArgumentNullException.ThrowIfNull(left);
        ArgumentNullException.ThrowIfNull(right);

        return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(left, right), parameter);
    }

    public static Expression<Func<T, bool>> AndIf<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2, bool condition)
    {
        if (!condition) return expr1;

        var parameter = Expression.Parameter(typeof(T));

        var leftVisitor = new ReplaceExpressionVisitor(expr1.Parameters[0], parameter);
        var left = leftVisitor.Visit(expr1.Body);
        var rightVisitor = new ReplaceExpressionVisitor(expr2.Parameters[0], parameter);
        var right = rightVisitor.Visit(expr2.Body);

        ArgumentNullException.ThrowIfNull(left);
        ArgumentNullException.ThrowIfNull(right);

        return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(left, right), parameter);
    }

    private sealed class ReplaceExpressionVisitor : ExpressionVisitor
    {
        private readonly Expression _oldValue;
        private readonly Expression _newValue;

        public ReplaceExpressionVisitor(Expression oldValue, Expression newValue)
        {
            _oldValue = oldValue;
            _newValue = newValue;
        }

        public override Expression Visit(Expression node)
        {
            return node == _oldValue ? _newValue : base.Visit(node)!;
        }
    }

    #endregion
}