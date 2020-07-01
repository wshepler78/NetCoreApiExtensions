using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetCoreApiExtensions.Shared;
using NetCoreApiExtensions.Shared.Enumerations;

namespace NetCoreApiExtensions.EntityFramework
{
    public static partial class Extensions
    {
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> query, Expression<Func<T, object>> keySelector, SortDirection direction)
        {
            return direction switch
                   {
                       SortDirection.Asc => query.OrderBy(keySelector),
                       SortDirection.Desc => query.OrderByDescending(keySelector),
                       _ => query
                   };
        }

        public static IQueryable<T> OrderBy<T>(this IQueryable<T> query, Tuple<Expression<Func<T, object>>, SortDirection> sortTuple)
        {
            return query.OrderBy(sortTuple.Item1, sortTuple.Item2);
        }

        public static IQueryable<T> OrderBy<T>(this IQueryable<T> query, params Tuple<Expression<Func<T, object>>, SortDirection>[] sortTuples)
        {
            return sortTuples.Aggregate(query, (current, sortTuple) => current.OrderBy(sortTuple));
        }

        public static IQueryable<T> OrderBy<T>(this IQueryable<T> query, SortExpression<T> sortExpression)
        {
            return query.OrderBy(sortExpression.KeySelector, sortExpression.SortDirection);
        }

        public static IQueryable<T> OrderBy<T>(this IQueryable<T> query, params SortExpression<T>[] sortExpressions)
        {
            return sortExpressions.Aggregate(query, (current, sortExpression) => current.OrderBy(sortExpression));
        }
    }
}