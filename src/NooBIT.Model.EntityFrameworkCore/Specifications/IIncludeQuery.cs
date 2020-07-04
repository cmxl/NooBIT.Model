using NooBIT.Model.Specifications;

namespace NooBIT.Model.EntityFrameworkCore.Specifications
{
    public interface IIncludeQuery<TEntity, TResult> : IQuery<TEntity, TResult>
    {
    }

    public interface IIncludeQuery<TEntity> : IIncludeQuery<TEntity, TEntity>, IQuery<TEntity>
    {
    }
}
