using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NooBIT.Model.Entities
{
    public interface IWriteEntities
    {
        void Delete<TEntity>(TEntity entity) where TEntity : class, IEntity;
        void BulkDelete<TEntity>(IEnumerable<TEntity> entities) where TEntity : class, IEntity;
        void Create<TEntity>(TEntity entity) where TEntity : class, IEntity;
        void BulkCreate<TEntity>(IEnumerable<TEntity> entities) where TEntity : class, IEntity;
        void Update<TEntity>(TEntity entity) where TEntity : class, IEntity;
        void BulkUpdate<TEntity>(IEnumerable<TEntity> entities) where TEntity : class, IEntity;
        Task Reload<TEntity>(TEntity entity, CancellationToken token) where TEntity : class, IEntity;
        Task<int> ExecuteRawQuery(string commandText, object[] commandParameters, CancellationToken token);
        Task<List<TEntity>> ExecuteRawQuery<TEntity>(string commandText, object[] commandParameters, CancellationToken token) where TEntity : class;
    }
}