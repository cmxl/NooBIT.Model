using NooBIT.Model.Specifications;

namespace NooBIT.Model.EntityFrameworkCore.Specifications
{
    public interface IIncludeQuery<TEntity, TResult> : IQuery<TEntity, TResult> where TEntity : class
    {
    }

    public interface IIncludeQuery<TEntity> : IIncludeQuery<TEntity, TEntity>, IQuery<TEntity> where TEntity : class
    {
    }
}
