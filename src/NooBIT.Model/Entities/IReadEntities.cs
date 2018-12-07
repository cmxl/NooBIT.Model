using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NooBIT.Model.Entities
{
    public interface IReadEntities
    {
        IQueryable<TEntity> Get<TEntity>() where TEntity : class, IEntity;
        Task<TEntity> Get<TEntity>(object firstKeyValue, CancellationToken token = default, params object[] otherKeyValues) where TEntity : class, IEntity;
    }
}