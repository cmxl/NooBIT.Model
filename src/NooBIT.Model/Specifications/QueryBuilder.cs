using NooBIT.Model.Extensions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NooBIT.Model.Specifications
{
    public class QueryBuilder<TEntity> : QueryBuilder<TEntity, TEntity>, IQueryBuilder<TEntity>
    {
        public QueryBuilder()
        {
            Select(x => x);
        }
    }

    public class QueryBuilder<TEntity, TResult> : IQueryBuilder<TEntity, TResult>
    {
        private readonly Query<TEntity, TResult> _query = new Query<TEntity, TResult>();

        public virtual IQuery<TEntity, TResult> Build()
            => _query;

        public IQueryBuilder<TEntity, TResult> Distinct()
        {
            _query._distinct = true;
            return this;
        }

        public IQueryBuilder<TEntity, TResult> OrderBy(Expression<Func<TEntity, object>> expression)
        {
            _query._orders.Add(KeyValuePair.Create(expression, OrderByDirection.Ascending));
            return this;
        }

        public IQueryBuilder<TEntity, TResult> OrderByDescending(Expression<Func<TEntity, object>> expression)
        {
            _query._orders.Add(KeyValuePair.Create(expression, OrderByDirection.Descending));
            return this;
        }

        public IQueryBuilder<TEntity, TResult> Paging(int skip, int take)
        {
            _query._skip = skip;
            _query._take = take;
            return this;
        }

        public IQueryBuilder<TEntity, TResult> Select(Expression<Func<TEntity, TResult>> expression)
        {
            _query._selector = expression;
            return this;
        }

        public IQueryBuilder<TEntity, TResult> Where(Expression<Func<TEntity, bool>> expression)
        {
            _query._wheres.Add(expression);
            return this;
        }
    }
}
