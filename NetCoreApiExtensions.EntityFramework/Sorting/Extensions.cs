using System;
using System.Linq;
using System.Linq.Expressions;
using NetCoreApiExtensions.Shared.Enumerations;

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