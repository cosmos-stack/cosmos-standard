using Cosmos.Expressions;
using Cosmos.Queries.Internals;
using Cosmos.Text;

namespace Cosmos.Queries;
/*
 * Reference: https://github.com/liyanjie8712/BuildingBlocks
 *      Author: liyanjie8712
 *      License: MIT
 */

public static class DynamicQueryableExtensions
{
    #region All

    public static bool All(this IQueryable source, string predicate, IDictionary<string, dynamic> variables = null)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));
        if (predicate.IsNotNullNorWhiteSpace())
            throw new ArgumentNullException(nameof(predicate));
        var predicateLambda = ExpressionParser.ParseLambda(source.ElementType, predicate, variables);
        return LinqHelper.Execute<bool>(source, LinqMethods.AllWithPredicate, predicateLambda);
    }

    #endregion

    #region Any

    public static bool Any(this IQueryable source, string predicate, IDictionary<string, dynamic> variables = null)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));
        if (predicate.IsNotNullNorWhiteSpace())
            throw new ArgumentNullException(nameof(predicate));
        var predicateLambda = ExpressionParser.ParseLambda(source.ElementType, predicate, variables);
        return LinqHelper.Execute<bool>(source, LinqMethods.AnyWithPredicate, predicateLambda);
    }

    #endregion

    #region Average

    public static object Average(this IQueryable source, string selector, IDictionary<string, dynamic> variables = null)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));
        if (selector.IsNotNullNorWhiteSpace())
            throw new ArgumentNullException(nameof(selector));
        var selectorLambda = ExpressionParser.ParseLambda(source.ElementType, selector, variables);
        return LinqHelper.ExecuteAverage(source, selectorLambda);
    }

    #endregion

    #region Count

    public static int Count(this IQueryable source, string predicate, IDictionary<string, dynamic> variables = null)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));
        if (predicate.IsNotNullNorWhiteSpace())
            throw new ArgumentNullException(nameof(predicate));
        var predicateLambda = ExpressionParser.ParseLambda(source.ElementType, predicate, variables);
        return LinqHelper.Execute<int>(source, LinqMethods.CountWithPredicate, predicateLambda);
    }

    #endregion

    #region First

    public static object First(this IQueryable source, string predicate, IDictionary<string, dynamic> variables = null)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));
        if (predicate.IsNotNullNorWhiteSpace())
            throw new ArgumentNullException(nameof(predicate));
        var predicateLambda = ExpressionParser.ParseLambda(source.ElementType, predicate, variables);
        return LinqHelper.Execute(source, LinqMethods.FirstWithPredicate, predicateLambda);
    }

    #endregion

    #region FirstOrDefault

    public static object FirstOrDefault(this IQueryable source, string predicate, IDictionary<string, dynamic> variables = null)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));
        if (predicate.IsNotNullNorWhiteSpace())
            throw new ArgumentNullException(nameof(predicate));
        var predicateLambda = ExpressionParser.ParseLambda(source.ElementType, predicate, variables);
        return LinqHelper.Execute(source, LinqMethods.FirstOrDefaultWithPredicate, predicateLambda);
    }

    #endregion

    #region GroupBy

    public static IQueryable GroupBy(this IQueryable source, string keySelector, IDictionary<string, dynamic> variables = null)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));
        if (keySelector.IsNotNullNorWhiteSpace())
            throw new ArgumentNullException(nameof(keySelector));
        var keySelectorLambda = ExpressionParser.ParseLambda(source.ElementType, keySelector, variables);
        return LinqHelper.CreateQuery(source, LinqMethods.GroupByWithKeySelector, keySelectorLambda);
    }

    #endregion

    #region Last

    public static object Last(this IQueryable source, string predicate, IDictionary<string, dynamic> variables = null)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));
        if (predicate.IsNotNullNorWhiteSpace())
            throw new ArgumentNullException(nameof(predicate));
        var predicateLambda = ExpressionParser.ParseLambda(source.ElementType, predicate, variables);
        return LinqHelper.Execute(source, LinqMethods.LastWithPredicate, predicateLambda);
    }

    #endregion

    #region LastOrDefault

    public static object LastOrDefault(this IQueryable source, string predicate, IDictionary<string, dynamic> variables = null)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));
        if (predicate.IsNotNullNorWhiteSpace())
            throw new ArgumentNullException(nameof(predicate));
        var predicateLambda = ExpressionParser.ParseLambda(source.ElementType, predicate, variables);
        return LinqHelper.Execute(source, LinqMethods.LastOrDefaultWithPredicate, predicateLambda);
    }

    #endregion LastOrDefault

    #region Max

    public static object Max(this IQueryable source, string selector, IDictionary<string, dynamic> variables = null)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));
        if (selector.IsNotNullNorWhiteSpace())
            throw new ArgumentNullException(nameof(selector));
        var selectorLambda = ExpressionParser.ParseLambda(source.ElementType, selector, variables);
        return LinqHelper.ExecuteMaxMin(source, LinqMethods.MaxWithSelector, selectorLambda);
    }

    #endregion

    #region Min

    public static object Min(this IQueryable source, string selector, IDictionary<string, dynamic> variables = null)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));
        if (selector.IsNotNullNorWhiteSpace())
            throw new ArgumentNullException(nameof(selector));
        var selectorLambda = ExpressionParser.ParseLambda(source.ElementType, selector, variables);
        return LinqHelper.ExecuteMaxMin(source, LinqMethods.MinWithSelector, selectorLambda);
    }

    #endregion

    #region OrderBy

    public static IOrderedQueryable OrderBy(this IQueryable source, string keySelector, IDictionary<string, dynamic> variables = null)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));
        if (keySelector.IsNotNullNorWhiteSpace())
            throw new ArgumentNullException(nameof(keySelector));
        var keySelectorLambda = ExpressionParser.ParseLambda(source.ElementType, keySelector, variables);
        return (IOrderedQueryable)LinqHelper.CreateQuery(source, LinqMethods.OrderByWithSelector, keySelectorLambda);
    }

    #endregion

    #region OrderByDescending

    public static IOrderedQueryable OrderByDescending(this IQueryable source, string keySelector, IDictionary<string, dynamic> variables = null)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));
        if (keySelector.IsNotNullNorWhiteSpace())
            throw new ArgumentNullException(nameof(keySelector));
        var keySelectorLambda = ExpressionParser.ParseLambda(source.ElementType, keySelector, variables);
        return (IOrderedQueryable)LinqHelper.CreateQuery(source, LinqMethods.OrderByDescendingWithSelector, keySelectorLambda);
    }

    #endregion

    #region Select

    public static IQueryable Select(this IQueryable source, string selector, IDictionary<string, dynamic> variables = null)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));
        if (selector.IsNotNullNorWhiteSpace())
            throw new ArgumentNullException(nameof(selector));
        var selectorLambda = ExpressionParser.ParseLambda(source.ElementType, selector, variables);
        return LinqHelper.CreateQuery(source, LinqMethods.SelectWithSelector, selectorLambda);
    }

    #endregion

    #region Single

    public static object Single(this IQueryable source, string predicate, IDictionary<string, dynamic> variables = null)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));
        if (predicate.IsNotNullNorWhiteSpace())
            throw new ArgumentNullException(nameof(predicate));
        var predicateLambda = ExpressionParser.ParseLambda(source.ElementType, predicate, variables);
        return LinqHelper.Execute(source, LinqMethods.SingleWithPredicate, predicateLambda);
    }

    #endregion

    #region SingleOrDefault

    public static object SingleOrDefault(this IQueryable source, string predicate, IDictionary<string, dynamic> variables = null)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));
        if (predicate.IsNotNullNorWhiteSpace())
            throw new ArgumentNullException(nameof(predicate));
        var predicateLambda = ExpressionParser.ParseLambda(source.ElementType, predicate, variables);
        return LinqHelper.Execute(source, LinqMethods.SingleOrDefaultWithPredicate, predicateLambda);
    }

    #endregion

    #region SkipWhile

    public static IQueryable SkipWhile(this IQueryable source, string predicate, IDictionary<string, dynamic> variables = null)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));
        if (predicate.IsNotNullNorWhiteSpace())
            throw new ArgumentNullException(nameof(predicate));
        var predicateLambda = ExpressionParser.ParseLambda(source.ElementType, predicate, variables);
        return LinqHelper.CreateQuery(source, LinqMethods.SkipWhileWithPredicate, predicateLambda);
    }

    #endregion

    #region Sum

    public static object Sum(this IQueryable source, string selector, IDictionary<string, dynamic> variables = null)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));
        if (selector.IsNotNullNorWhiteSpace())
            throw new ArgumentNullException(nameof(selector));
        var selectorLambda = ExpressionParser.ParseLambda(source.ElementType, selector, variables);
        return LinqHelper.ExecuteSum(source, selectorLambda);
    }

    #endregion

    #region TakeWhile

    public static IQueryable TakeWhile(this IQueryable source, string predicate, IDictionary<string, dynamic> variables = null)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));
        if (predicate.IsNotNullNorWhiteSpace())
            throw new ArgumentNullException(nameof(predicate));
        var predicateLambda = ExpressionParser.ParseLambda(source.ElementType, predicate, variables);
        return LinqHelper.CreateQuery(source, LinqMethods.TakeWhileWithPredicate, predicateLambda);
    }

    #endregion

    #region ThenBy

    public static IOrderedQueryable ThenBy(this IOrderedQueryable source, string keySelector, IDictionary<string, dynamic> variables = null)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));
        if (keySelector.IsNotNullNorWhiteSpace())
            throw new ArgumentNullException(nameof(keySelector));
        var keySelectorLambda = ExpressionParser.ParseLambda(source.ElementType, keySelector, variables);
        return (IOrderedQueryable)LinqHelper.CreateQuery(source, LinqMethods.ThenByWithSelector, keySelectorLambda);
    }

    #endregion

    #region ThenByDescending

    public static IOrderedQueryable ThenByDescending(this IOrderedQueryable source, string selector, IDictionary<string, dynamic> variables = null)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));
        if (selector.IsNotNullNorWhiteSpace())
            throw new ArgumentNullException(nameof(selector));
        var keySelectorLambda = ExpressionParser.ParseLambda(source.ElementType, selector, variables);
        return (IOrderedQueryable)LinqHelper.CreateQuery(source, LinqMethods.ThenByDescendingWithSelector, keySelectorLambda);
    }

    #endregion

    #region Where

    public static IQueryable Where(this IQueryable source, string predicate, IDictionary<string, dynamic> variables = null)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));
        if (predicate.IsNotNullNorWhiteSpace())
            throw new ArgumentNullException(nameof(predicate));
        var predicateLambda = ExpressionParser.ParseLambda(source.ElementType, predicate, variables);
        return LinqHelper.CreateQuery(source, LinqMethods.WhereWithPredicate, predicateLambda);
    }

    #endregion
}