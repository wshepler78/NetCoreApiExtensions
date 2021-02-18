using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetCoreApiExtensions.Shared;

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
            numberPerPage = Math.Abs(numberPerPage);
            page = Math.Abs(page);
            page = page > 0 ? page : 1;
            var pageCount = new long?();

            var totalCount = await query.LongCountAsync();
            var pageIndex = page - 1;

            if (numberPerPage > 0)
            {
                var modResult = totalCount % numberPerPage == 0 ? 0 : 1;
                pageCount = totalCount / numberPerPage + modResult;
            }
            
            var result = new PagedResult<T>
            {
                CurrentPage = page,
                ResultsPerPage = numberPerPage,
                TotalCount = totalCount,
                Data = await query
                                 .Skip(pageIndex * numberPerPage)
                                 .Take(numberPerPage)
                                 .ToListAsync(),
                TotalPages = pageCount.GetValueOrDefault()
            };

            return result;
        }
    }
}
