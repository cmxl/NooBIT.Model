using NooBIT.Model.Specifications;

namespace NooBIT.Model.EntityFrameworkCore.Specifications
{
    public abstract class IncludeSpecification<TEntity, TResult> : Specification<TEntity, TResult>, IIncludeSpecification<TEntity, TResult> where TEntity : class
    {
        public new IIncludeQueryBuilder<TEntity, TResult> Query => (IIncludeQueryBuilder<TEntity, TResult>)base.Query;

        public IncludeSpecification() : this(null)
        {
        }

        public IncludeSpecification(IIncludeQueryBuilder<TEntity, TResult> queryBuilder) : base(queryBuilder ?? new IncludeQueryBuilder<TEntity, TResult>())
        {
        }
    }


    public abstract class IncludeSpecification<TEntity> : IncludeSpecification<TEntity, TEntity>, IIncludeSpecification<TEntity> where TEntity : class
    {
        public IncludeSpecification() : this(null)
        {
        }

        public IncludeSpecification(IIncludeQueryBuilder<TEntity> queryBuilder) : base(queryBuilder ?? new IncludeQueryBuilder<TEntity>())
        {
        }
    }
}
