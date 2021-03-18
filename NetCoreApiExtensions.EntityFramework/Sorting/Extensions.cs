using NetCoreApiExtensions.Shared.Enumerations;
using System;
using System.Linq;
using System.Linq.Expressions;
using NetCoreApiExtensions.Shared;

namespace NetCoreApiExtensions.EntityFramework
{
    public static partial class Extensions
    {
        public static IOrderedQueryable<T> OrderBy<T, TKey>(this IQueryable<T> query, Expression<Func<T, TKey>> keySelector, SortDirection direction)
        {
            return direction switch
            {
                SortDirection.Asc => query.OrderBy(keySelector),
                SortDirection.Desc => query.OrderByDescending(keySelector),
                _ => query.OrderBy(keySelector)
            };
        }

        public static IOrderedQueryable<T> OrderBy<T, TKey>(this IQueryable<T> query, params IListItem<Expression<Func<T, TKey>>, SortDirection>[] sortExpressions)
        {
            if (sortExpressions.Length < 1)
            {
                throw new InvalidOperationException("At least one SortExpression must be supplied");
            }

            var orderedResult = query.OrderBy(sortExpressions[0].Key, sortExpressions[0].Value);

            return sortExpressions.Length == 1 ? orderedResult : orderedResult.ThenBy(sortExpressions[1..]);
        }

        public static IOrderedQueryable<T> ThenBy<T, TKey>(this IOrderedQueryable<T> query, Expression<Func<T, TKey>> keySelector, SortDirection direction)
        {
            return direction switch
            {
                SortDirection.Asc => query.ThenBy(keySelector),
                SortDirection.Desc => query.ThenByDescending(keySelector),
                _ => query
            };
        }

        public static IOrderedQueryable<T> ThenBy<T, TKey>(this IOrderedQueryable<T> query, params IListItem<Expression<Func<T, TKey>>, SortDirection>[] sortExpressions)
        {
            return sortExpressions.Aggregate(query, (current, sortExpression) => current.ThenBy(sortExpression.Key, sortExpression.Value));
        }

    }
}