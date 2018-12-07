using NooBIT.Model.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace NooBIT.Model.Paging
{
    public class PagedQueryable<T> : PagedResultBase, IQueryable<T> where T : class, IEntity
    {
        private readonly IQueryable<T> _pagedQuery;
        private readonly Lazy<int> _rowCount;

        public PagedQueryable(IQueryable<T> initialQuery, int page, int pageSize)
        {
            _rowCount = new Lazy<int>(initialQuery.Count);
            _pagedQuery = initialQuery.Skip((page - 1) * pageSize).Take(pageSize);
            PageSize = pageSize;
            CurrentPage = page;
        }

        public IEnumerator<T> GetEnumerator()
            => _pagedQuery.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        public override int PageCount => (int)Math.Ceiling((double)RowCount / PageSize);
        public override int RowCount => _rowCount.Value;

        public Type ElementType => _pagedQuery.ElementType;
        public Expression Expression => _pagedQuery.Expression;
        public IQueryProvider Provider => _pagedQuery.Provider;
    }
}