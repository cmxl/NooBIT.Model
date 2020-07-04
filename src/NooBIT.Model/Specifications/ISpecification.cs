using NooBIT.Model.Entities;

namespace NooBIT.Model.Specifications
{
    public interface ISpecification<TEntity, TResult> where TEntity : class, IEntity
    {
        IQueryBuilder<TEntity, TResult> Query { get; }
    }

    public interface ISpecification<TEntity> : ISpecification<TEntity, TEntity> where TEntity : class, IEntity { }
}
