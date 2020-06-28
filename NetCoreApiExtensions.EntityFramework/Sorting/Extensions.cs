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
    }
}