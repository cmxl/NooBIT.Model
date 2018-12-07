using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NooBIT.Model.Extensions
{
    public static class QueryableExtensions
    {
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