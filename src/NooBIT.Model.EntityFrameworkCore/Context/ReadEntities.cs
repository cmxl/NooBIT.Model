using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NooBIT.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace NooBIT.Model.Context
{
    public class ReadEntities : IReadEntities
    {
        private readonly DbContext _context;

        public ReadEntities(DbContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> Get<TEntity>() where TEntity : class, IEntity 
            => _context.Set<TEntity>();

        public async Task<TEntity> Get<TEntity>(object firstKeyValue, CancellationToken token = default, params object[] otherKeyValues) where TEntity : class, IEntity
        {
            if (firstKeyValue == null) throw new ArgumentNullException(nameof(firstKeyValue));
            var keyValues = new List<object> {firstKeyValue};
            if (otherKeyValues != null) keyValues.AddRange(otherKeyValues);
            return await _context.Set<TEntity>().FindAsync(token, keyValues.ToArray());
        }
    }
}