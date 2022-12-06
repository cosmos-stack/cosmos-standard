using System.Linq.Expressions;
using Cosmos.Queries.Internals;

namespace Cosmos.Queries;

public static class QueryableExtensions
{
    #region Any

    public static bool Any(this IQueryable source)
    {
        ArgumentNullException.ThrowIfNull(source);
        return LinqHelper.Execute<bool>(source, LinqMethods.Any);
    }

    #endregion

    #region AsEnumerable

    public static IEnumerable<object> AsEnumerable(this IQueryable source)
    {
        foreach (var item in source)
        {
            yield return item;
        }
    }

    #endregion

    #region Average

    public static object Average(this IQueryable source)
    {
        ArgumentNullException.ThrowIfNull(source);
        return LinqHelper.ExecuteAverage(source);
    }

    #endregion

    #region Count

    public static int Count(this IQueryable source)
    {
        ArgumentNullException.ThrowIfNull(source);
        return LinqHelper.Execute<int>(source, LinqMethods.Count);
    }

    #endregion

    #region Distinct

    public static IQueryable Distinct(this IQueryable source)
    {
        ArgumentNullException.ThrowIfNull(source);
        return LinqHelper.CreateQuery(source, LinqMethods.Distinct);
    }

    #endregion

    #region ElementAt

    public static object ElementAt(this IQueryable source, int index)
    {
        ArgumentNullException.ThrowIfNull(source);
        if (index < 0)
            throw new ArgumentOutOfRangeException(nameof(index));
        return LinqHelper.Execute(source, LinqMethods.ElementAtWithIndex, Expression.Constant(index));
    }

    #endregion

    #region ElementAtOrDefault

    public static object ElementAtOrDefault(this IQueryable source, int index)
    {
        ArgumentNullException.ThrowIfNull(source);
        if (index < 0)
            throw new ArgumentOutOfRangeException(nameof(index));
        return LinqHelper.Execute(source, LinqMethods.ElementAtOrDefaultWithIndex, Expression.Constant(index));
    }

    #endregion

    #region First

    public static object First(this IQueryable source)
    {
        ArgumentNullException.ThrowIfNull(source);
        return LinqHelper.Execute(source, LinqMethods.First);
    }

    #endregion

    #region FirstOrDefault

    public static object FirstOrDefault(this IQueryable source)
    {
        ArgumentNullException.ThrowIfNull(source);
        return LinqHelper.Execute(source, LinqMethods.FirstOrDefault);
    }

    #endregion

    #region Last

    public static object Last(this IQueryable source)
    {
        ArgumentNullException.ThrowIfNull(source);
        return LinqHelper.Execute(source, LinqMethods.Last);
    }

    #endregion

    #region LastOrDefault

    public static object LastOrDefault(this IQueryable source)
    {
        ArgumentNullException.ThrowIfNull(source);
        return LinqHelper.Execute(source, LinqMethods.LastOrDefault);
    }

    #endregion LastOrDefault

    #region Max

    public static object Max(this IQueryable source)
    {
        ArgumentNullException.ThrowIfNull(source);
        return LinqHelper.ExecuteMaxMin(source, LinqMethods.Max);
    }

    #endregion

    #region Min

    public static object Min(this IQueryable source)
    {
        ArgumentNullException.ThrowIfNull(source);
        return LinqHelper.ExecuteMaxMin(source, LinqMethods.Min);
    }

    #endregion

    #region Reverse

    public static IQueryable Reverse(this IQueryable source)
    {
        ArgumentNullException.ThrowIfNull(source);
        return LinqHelper.CreateQuery(source, LinqMethods.Reverse);
    }

    #endregion

    #region Single

    public static object Single(this IQueryable source)
    {
        ArgumentNullException.ThrowIfNull(source);
        return LinqHelper.Execute(source, LinqMethods.Single);
    }

    #endregion

    #region SingleOrDefault

    public static object SingleOrDefault(this IQueryable source)
    {
        ArgumentNullException.ThrowIfNull(source);
        return LinqHelper.Execute(source, LinqMethods.SingleOrDefault);
    }

    #endregion

    #region Sum

    public static object Sum(this IQueryable source)
    {
        ArgumentNullException.ThrowIfNull(source);
        return LinqHelper.ExecuteSum(source);
    }

    #endregion

    #region Take

    public static IQueryable Take(this IQueryable source, int count)
    {
        ArgumentNullException.ThrowIfNull(source);
        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count));
        return LinqHelper.CreateQuery(source, LinqMethods.TakeWithCount, Expression.Constant(count));
    }

    #endregion
}