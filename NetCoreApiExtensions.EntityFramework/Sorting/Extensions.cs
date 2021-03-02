using System;
using System.Linq;
using System.Linq.Expressions;
using NetCoreApiExtensions.Shared.Enumerations;

namespace NetCoreApiExtensions.EntityFramework
{
    public static partial class Extensions
    {
        public static IOrderedQueryable<T> OrderBy<T, TKey>(this IQueryable<T> query, Tuple<Expression<Func<T, TKey>>, SortDirection> sortTuple)
        {
            return query.OrderBy(sortTuple.Item1, sortTuple.Item2);
        }

        public static IOrderedQueryable<T> OrderBy<T, TKey>(this IQueryable<T> query, params Tuple<Expression<Func<T, TKey>>, SortDirection>[] sortTuples)
        {
            if (sortTuples.Length == 0)
            {
                throw new Exception("At least one sort must be specified");
            }

            var expressions = sortTuples.Select(st => new SortExpression<T, TKey>(st.Item1, st.Item2));

            return query.OrderBy(expressions.ToArray());
        }

        public static IOrderedQueryable<T> OrderBy<T, TKey>(this IQueryable<T> query, SortExpression<T, TKey> sortExpression)
        {
            return query.OrderBy(sortExpression.KeySelector, sortExpression.SortDirection);
        }

        public static IOrderedQueryable<T> OrderBy<T, TKey>(this IQueryable<T> query, params SortExpression<T, TKey>[] sortExpressions)
        {
            if (sortExpressions.Length == 0)
            {
                throw new Exception("At least one sort must be specified");
            }

            foreach (var sortExpression in sortExpressions)
            {
                query = query.OrderBy(new SortExpression<T, TKey>(sortExpression.KeySelector, sortExpression.SortDirection));
            }

            return (IOrderedQueryable<T>)query;
        }

        public static IOrderedQueryable<T> OrderBy<T, TKey>(this IQueryable<T> query, Expression<Func<T, TKey>> keySelector, SortDirection direction)
        {
            if (query is IOrderedQueryable<T> orderedQuery)
            {
                return orderedQuery.ThenBy(keySelector, direction);
            }

            return direction switch
                   {
                       SortDirection.Asc => query.OrderBy(keySelector),
                       SortDirection.Desc => query.OrderByDescending(keySelector),
                       _ => query.OrderBy(keySelector)
                   };
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
    }
}