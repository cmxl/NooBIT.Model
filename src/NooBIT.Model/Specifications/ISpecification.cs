namespace NooBIT.Model.Specifications
{
    public interface ISpecification<TEntity, TResult>
    {
        IQueryBuilder<TEntity, TResult> Query { get; }
    }

    public interface ISpecification<TEntity> : ISpecification<TEntity, TEntity> { }
}
