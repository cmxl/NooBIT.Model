using System.Linq;
using NooBIT.Model.Entities;

namespace NooBIT.Model.Queries
{
    public class DefaultQueryableRequestService<TEntity> : IQueryableRequestService<TEntity> where TEntity : class, IEntity
    {
        private readonly IReadEntities _readEntities;

        public DefaultQueryableRequestService(IReadEntities readEntities)
        {
            _readEntities = readEntities;
        }

        public IQueryable<TEntity> Get()
        {
            return _readEntities.Get<TEntity>();
        }
    }
}