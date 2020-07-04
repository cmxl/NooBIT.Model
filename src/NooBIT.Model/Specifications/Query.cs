using NooBIT.Model.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace NooBIT.Model.Specifications
{
    public class Query<TEntity, TResult> : IQuery<TEntity, TResult>
    {
        internal readonly List<Expression<Func<TEntity, bool>>> _wheres = new List<Expression<Func<TEntity, bool>>>();
        internal readonly List<KeyValuePair<Expression<Func<TEntity, object>>, OrderByDirection>> _orders = new List<KeyValuePair<Expression<Func<TEntity, object>>, OrderByDirection>>();
        internal Expression<Func<TEntity, TResult>> _selector;
        internal bool _distinct = false;
        internal int? _skip = null;
        internal int? _take = null;
        private bool IsPaging => _skip.HasValue && _take.HasValue;

        public virtual IQueryable<TResult> Apply(IQueryable<TEntity> query)
        {
            foreach (var where in _wheres)
                query = query.Where(where);

            query = query.OrderBy(_orders);

            if (IsPaging)
            {
                query = query.Skip(_skip.Value);
                query = query.Take(_take.Value);
            }

            if (_selector == null)
                throw new InvalidOperationException("Cannot query data without selector");

            var q = query.Select(_selector);

            if (_distinct)
                return q.Distinct();

            return q;
        }
    }

    internal class Query<TEntity> : Query<TEntity, TEntity>, IQuery<TEntity>
    {
    }
}
