using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cosmos.Judgments;

// ReSharper disable once CheckNamespace
namespace Cosmos.Optionals
{
    /// <summary>
    /// Optionals extensions
    /// </summary>
    public static partial class OptionalsExtensions
    {
        /// <summary>
        /// Return a safe <see cref="IQueryable{T}"/> value.<br />
        /// 安全获得 <see cref="IQueryable{T}"/> 集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        public static IQueryable<T> SafeQueryable<T>(this IQueryable<T> @query) =>
            CollectionJudgment.IsNullOrEmpty(query) ? new List<T>().AsQueryable() : query;

        /// <summary>
        /// Return a safe <see cref="IQueryable{T}"/> value.<br />
        /// 安全获得 <see cref="IQueryable{T}"/> 集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static IQueryable<T> SafeQueryable<T>(this IEnumerable<T> enumerable) =>
            enumerable.AsQueryable().SafeQueryable();

        /// <summary>
        /// Return a safe <see cref="IQueryable{T}"/> value.<br />
        /// 安全获得 <see cref="IQueryable{T}"/> 集合
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public static IQueryable SafeQueryable(this IQueryable query) =>
            CollectionJudgment.IsNullOrEmpty(query) ? new List<object>().AsQueryable() : query;

        /// <summary>
        /// Return a safe <see cref="IQueryable{T}"/> value.<br />
        /// 安全获得 <see cref="IQueryable{T}"/> 集合
        /// </summary>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static IQueryable SafeQueryable(this IEnumerable enumerable) =>
            enumerable.AsQueryable().SafeQueryable();
    }
}