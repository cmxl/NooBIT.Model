using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NooBIT.Model.Entities;
using NooBIT.Model.Paging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace NooBIT.Model.Extensions
{
    public static class QueryableExtensions
    {
        public static PagedQueryable<T> Page<T>(this IQueryable<T> query, int page, int pageSize) where T : class, IEntity
        {
            return new PagedQueryable<T>(query, page, pageSize);
        }

        // IMPORTANT NOTE: IAsyncQueryProvider is an internal class and may break sometime in EFCore updates!!!

        public static Task<List<T>> ToListAsync2<T>(this IQueryable<T> query, CancellationToken cancellationToken)
        {
            if (query.Provider is IAsyncQueryProvider)
                return query.ToListAsync(cancellationToken);

            return Task.FromResult(query.ToList());
        }

        public static Task<int> CountAsync2<T>(this IQueryable<T> query, CancellationToken cancellationToken)
        {
            if (query.Provider is IAsyncQueryProvider)
                return query.CountAsync(cancellationToken);

            return Task.FromResult(query.Count());
        }
    }
}