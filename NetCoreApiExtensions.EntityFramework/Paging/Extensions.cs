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
        public static async Task<PagedResult<T>> ToPagedResultAsync<T, TSource>(this IQueryable<TSource> query, Expression<Func<TSource, T>> projection, int page, int numberPerPage)
        {
            return await ToPagedResultAsync(query.Select(projection), page, numberPerPage);
        }

        public static async Task<PagedResult<T>> ToPagedResultAsync<T>(this IQueryable<T> query, int page, int numberPerPage)
        {
            var totalCount = await query.CountAsync();

            var pageIndex = page - 1 >= 0 ? page - 1 : 0;

            var result = new PagedResult<T>
            {
                CurrentPage = page,
                ResultsPerPage = numberPerPage,
                TotalCount = totalCount,
                Data = await query
                                 .Skip(pageIndex * numberPerPage)
                                 .Take(numberPerPage)
                                 .ToListAsync()
            };

            return result;
        }
    }
}
