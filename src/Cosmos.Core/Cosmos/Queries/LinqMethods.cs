namespace Cosmos.Queries.Internals;
/*
 * Reference: https://github.com/liyanjie8712/BuildingBlocks
 *      Author: liyanjie8712
 *      License: MIT
 */

internal static class LinqMethods
{
    static readonly Func<MethodInfo, bool> _predicateHas2Parameters = _ => _.GetParameters()[1].ToString().Contains("Func`2");

    static MethodInfo GetMethod(string name, int parameterCount = 0, Func<MethodInfo, bool> predicate = null)
    {
        return typeof(Queryable)
               .GetTypeInfo()
               .GetDeclaredMethods(name)
               .Single(_ => _.GetParameters().Length == parameterCount + 1 && (predicate is null || predicate(_)));
    }

    public static readonly MethodInfo AllWithPredicate = GetMethod(nameof(Queryable.All), 1);
    public static readonly MethodInfo Any = GetMethod(nameof(Queryable.Any));
    public static readonly MethodInfo AnyWithPredicate = GetMethod(nameof(Queryable.Any), 1);
    public static readonly MethodInfo Count = GetMethod(nameof(Queryable.Count));
    public static readonly MethodInfo CountWithPredicate = GetMethod(nameof(Queryable.Count), 1);
    public static readonly MethodInfo Distinct = GetMethod(nameof(Queryable.Distinct));
    public static readonly MethodInfo ElementAtWithIndex = GetMethod(nameof(Queryable.ElementAt), 1);
    public static readonly MethodInfo ElementAtOrDefaultWithIndex = GetMethod(nameof(Queryable.ElementAtOrDefault), 1);
    public static readonly MethodInfo First = GetMethod(nameof(Queryable.First));
    public static readonly MethodInfo FirstWithPredicate = GetMethod(nameof(Queryable.First), 1);
    public static readonly MethodInfo FirstOrDefault = GetMethod(nameof(Queryable.FirstOrDefault));
    public static readonly MethodInfo FirstOrDefaultWithPredicate = GetMethod(nameof(Queryable.FirstOrDefault), 1);
    public static readonly MethodInfo GroupByWithKeySelector = GetMethod(nameof(Queryable.GroupBy), 1);
    public static readonly MethodInfo Last = GetMethod(nameof(Queryable.Last));
    public static readonly MethodInfo LastWithPredicate = GetMethod(nameof(Queryable.Last), 1);
    public static readonly MethodInfo LastOrDefault = GetMethod(nameof(Queryable.LastOrDefault));
    public static readonly MethodInfo LastOrDefaultWithPredicate = GetMethod(nameof(Queryable.LastOrDefault), 1);
    public static readonly MethodInfo Max = GetMethod(nameof(Queryable.Max));
    public static readonly MethodInfo MaxWithSelector = GetMethod(nameof(Queryable.Max), 1);
    public static readonly MethodInfo Min = GetMethod(nameof(Queryable.Min));
    public static readonly MethodInfo MinWithSelector = GetMethod(nameof(Queryable.Min), 1);
    public static readonly MethodInfo OrderByWithSelector = GetMethod(nameof(Queryable.OrderBy), 1);
    public static readonly MethodInfo OrderByDescendingWithSelector = GetMethod(nameof(Queryable.OrderByDescending), 1);
    public static readonly MethodInfo Reverse = GetMethod(nameof(Queryable.Reverse));
    public static readonly MethodInfo SelectWithSelector = GetMethod(nameof(Queryable.Select), 1, _predicateHas2Parameters);
    public static readonly MethodInfo Single = GetMethod(nameof(Queryable.Single));
    public static readonly MethodInfo SingleWithPredicate = GetMethod(nameof(Queryable.Single), 1);
    public static readonly MethodInfo SingleOrDefault = GetMethod(nameof(Queryable.SingleOrDefault));
    public static readonly MethodInfo SingleOrDefaultWithPredicate = GetMethod(nameof(Queryable.SingleOrDefault), 1);
    public static readonly MethodInfo SkipWithCount = GetMethod(nameof(Queryable.Skip), 1);
    public static readonly MethodInfo SkipWhileWithPredicate = GetMethod(nameof(Queryable.SkipWhile), 1, _predicateHas2Parameters);
    public static readonly MethodInfo Sum = GetMethod(nameof(Queryable.Sum));
    public static readonly MethodInfo SumWithSelector = GetMethod(nameof(Queryable.Sum), 1);
    public static readonly MethodInfo TakeWithCount = GetMethod(nameof(Queryable.Take), 1);
    public static readonly MethodInfo TakeWhileWithPredicate = GetMethod(nameof(Queryable.TakeWhile), 1, _predicateHas2Parameters);
    public static readonly MethodInfo ThenByWithSelector = GetMethod(nameof(Queryable.ThenBy), 1);
    public static readonly MethodInfo ThenByDescendingWithSelector = GetMethod(nameof(Queryable.ThenByDescending), 1);
    public static readonly MethodInfo WhereWithPredicate = GetMethod(nameof(Queryable.Where), 1, _predicateHas2Parameters);
}