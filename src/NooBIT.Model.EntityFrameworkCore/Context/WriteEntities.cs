using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NooBIT.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace NooBIT.Model.Context
{
    public class WriteEntities : IWriteEntities
    {
        private readonly DbContext _context;

        public WriteEntities(DbContext context)
        {
            _context = context;
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class, IEntity
        {
            if (_context.Entry(entity).State != EntityState.Deleted)
                _context.Set<TEntity>().Remove(entity);
        }

        public void BulkDelete<TEntity>(IEnumerable<TEntity> entities) where TEntity : class, IEntity 
            => _context.Set<TEntity>().RemoveRange(entities);

        public void Create<TEntity>(TEntity entity) where TEntity : class, IEntity
        {
            if (_context.Entry(entity).State == EntityState.Detached)
                _context.Set<TEntity>().Add(entity);
        }

        public void BulkCreate<TEntity>(IEnumerable<TEntity> entities) where TEntity : class, IEntity 
            => _context.Set<TEntity>().AddRange(entities);

        public void Update<TEntity>(TEntity entity) where TEntity : class, IEntity 
            => _context.Set<TEntity>().Update(entity);

        public void BulkUpdate<TEntity>(IEnumerable<TEntity> entities) where TEntity : class, IEntity 
            => _context.Set<TEntity>().UpdateRange(entities);

        public async Task Reload<TEntity>(TEntity entity, CancellationToken token = default) where TEntity : class, IEntity 
            => await _context.Entry(entity).ReloadAsync(token).ConfigureAwait(false);

        public async Task<int> ExecuteRawQuery(string commandText, object[] commandParameters, CancellationToken token = default) 
            => await _context.Database.ExecuteSqlRawAsync(commandText, token, commandParameters).ConfigureAwait(false);

        public async Task<List<TEntity>> ExecuteRawQuery<TEntity>(string commandText, object[] commandParameters, CancellationToken token = default) where TEntity : class 
            => await _context.Set<TEntity>().FromSqlRaw(commandText, commandParameters).ToListAsync(token).ConfigureAwait(false);
    }
}