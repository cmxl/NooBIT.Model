using NooBIT.Model.Specifications;

namespace NooBIT.Model.EntityFrameworkCore.Specifications
{
    public interface IIncludeQueryBuilder<TEntity, TResult> : IQueryBuilder<TEntity, TResult> where TEntity : class
    {
        IIncludeQueryBuilder<TEntity, TResult> Include(string path);
    }

    public interface IIncludeQueryBuilder<TEntity> : IIncludeQueryBuilder<TEntity, TEntity>, IQueryBuilder<TEntity> where TEntity : class
    {
    }
}
