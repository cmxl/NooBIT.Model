using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using NooBIT.Model.Entities;
using NooBIT.Model.Contracts;
using Microsoft.EntityFrameworkCore;

namespace NooBIT.Model.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        private void SetAuditableEntityProperties(IPrincipal principal)
        {
            if (!_context.ChangeTracker.HasChanges())
                return;

            var entries = _context.ChangeTracker.Entries()
                .Where(x => x.Entity is IAuditableEntity
                            && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                if (!(entry.Entity is IAuditableEntity entity))
                    continue;

                var name = principal?.Identity?.Name ?? string.Empty;
                var now = DateTime.UtcNow;

                if (entry.State == EntityState.Added)
                {
                    entity.CreatedBy = name;
                    entity.CreatedDateUtc = now;
                }
                else
                {
                    _context.Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                    _context.Entry(entity).Property(x => x.CreatedDateUtc).IsModified = false;
                }

                entity.UpdatedBy = name;
                entity.UpdatedDateUtc = now;
            }
        }

        public async Task<int> SaveChangesAsync(CancellationToken token = default)
        {
            SetAuditableEntityProperties(null);
            return await _context.SaveChangesAsync(token);
        }

        public async Task<int> SaveChangesAsync(IPrincipal principal, CancellationToken token = default)
        {
            SetAuditableEntityProperties(principal);
            return await _context.SaveChangesAsync(token);
        }

        public Task DiscardChanges(CancellationToken token = default)
        {
            if (!_context.ChangeTracker.HasChanges())
                return Task.FromResult<object>(null);

            var reloadTasks = new List<Task>();
            foreach (var entry in _context.ChangeTracker.Entries().Where(x => x != null))
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Modified:
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Deleted:
                        reloadTasks.Add(entry.ReloadAsync(token));
                        break;
                }
            return Task.WhenAll(reloadTasks);
        }
    }
}