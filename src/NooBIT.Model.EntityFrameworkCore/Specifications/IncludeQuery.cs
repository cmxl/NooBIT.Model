using Microsoft.EntityFrameworkCore;
using NooBIT.Model.Specifications;
using System.Collections.Generic;
using System.Linq;

namespace NooBIT.Model.EntityFrameworkCore.Specifications
{
    internal class IncludeQuery<TEntity, TResult> : IIncludeQuery<TEntity, TResult> where TEntity : class
    {
        internal IQuery<TEntity, TResult> _baseQuery;
        internal List<string> _includes = new();

        public IQueryable<TResult> Apply(IQueryable<TEntity> query)
        {
            foreach (var include in _includes)
                query = query.Include(include);

            return _baseQuery.Apply(query);
        }
    }
}
