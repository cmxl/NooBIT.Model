using MediatR;
using NooBIT.Model.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NooBIT.Model.MediatR
{
    public class BulkUpdateCommand<TEntity> : IRequest where TEntity : class, IEntity
    {
        public BulkUpdateCommand(IEnumerable<TEntity> entities, bool commit = false)
        {
            Entities = entities;
            Commit = commit;
        }

        public IEnumerable<TEntity> Entities { get; }
        public bool Commit { get; }
    }

    public class BulkUpdateCommandHandler<TEntity> : IRequestHandler<BulkUpdateCommand<TEntity>> where TEntity : class, IEntity
    {
        private readonly IWriteEntities _writeEntities;
        private readonly IUnitOfWork _unitOfWork;

        public BulkUpdateCommandHandler(IWriteEntities writeEntities, IUnitOfWork unitOfWork)
        {
            _writeEntities = writeEntities;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(BulkUpdateCommand<TEntity> command, CancellationToken token)
        {
            _writeEntities.BulkUpdate(command.Entities);

            if (command.Commit)
                await _unitOfWork.SaveChangesAsync(token).ConfigureAwait(false);

            return Unit.Value;
        }
    }
}