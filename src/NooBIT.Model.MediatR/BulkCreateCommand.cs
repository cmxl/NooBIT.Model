using MediatR;
using NooBIT.Model.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NooBIT.Model.MediatR
{
    public class BulkCreateCommand<TEntity> : IRequest where TEntity : class, IEntity
    {
        public BulkCreateCommand(IEnumerable<TEntity> entities, bool commit = false)
        {
            Entities = entities;
            Commit = commit;
        }

        public IEnumerable<TEntity> Entities { get; }
        public bool Commit { get; }
    }

    public class BulkCreateCommandHandler<TEntity> : IRequestHandler<BulkCreateCommand<TEntity>> where TEntity : class, IEntity
    {
        private readonly IWriteEntities _writeEntities;
        private readonly IUnitOfWork _unitOfWork;

        public BulkCreateCommandHandler(IWriteEntities writeEntities, IUnitOfWork unitOfWork)
        {
            _writeEntities = writeEntities;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(BulkCreateCommand<TEntity> command, CancellationToken token)
        {
            _writeEntities.BulkCreate(command.Entities);

            if (command.Commit)
                await _unitOfWork.SaveChangesAsync(token);

            return Unit.Value;
        }
    }
}