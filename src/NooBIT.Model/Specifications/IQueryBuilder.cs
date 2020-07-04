using System;
using System.Linq.Expressions;

namespace NooBIT.Model.Specifications
{
    public interface IQueryBuilder<TEntity, TResult>
    {
        IQuery<TEntity, TResult> Build();
        IQueryBuilder<TEntity, TResult> Where(Expression<Func<TEntity, bool>> expression);
        IQueryBuilder<TEntity, TResult> Select(Expression<Func<TEntity, TResult>> expression);
        IQueryBuilder<TEntity, TResult> OrderBy(Expression<Func<TEntity, object>> expression);
        IQueryBuilder<TEntity, TResult> OrderByDescending(Expression<Func<TEntity, object>> expression);
        IQueryBuilder<TEntity, TResult> Distinct();
        IQueryBuilder<TEntity, TResult> Paging(int skip, int take);
    }

    public interface IQueryBuilder<TEntity> : IQueryBuilder<TEntity, TEntity>
    {
    }
}
