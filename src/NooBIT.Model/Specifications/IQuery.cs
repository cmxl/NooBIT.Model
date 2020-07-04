using System.Linq;

namespace NooBIT.Model.Specifications
{
    public interface IQuery<TEntity, TResult>
    {
        IQueryable<TResult> Apply(IQueryable<TEntity> query);
    }

    public interface IQuery<TEntity> : IQuery<TEntity, TEntity> { }
}
