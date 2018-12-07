using System.Linq;
using NooBIT.Model.Entities;

namespace NooBIT.Model.Queries
{
    public interface IQueryableRequestService<out TEntity> where TEntity : class, IEntity
    {
        IQueryable<TEntity> Get();
    }
}