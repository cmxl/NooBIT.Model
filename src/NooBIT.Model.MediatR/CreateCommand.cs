using MediatR;
using NooBIT.Model.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace NooBIT.Model.MediatR
{
    public class CreateCommand<TEntity> : IRequest where TEntity : class, IEntity
    {
        public CreateCommand(TEntity entity, bool commit = false)
        {
            Entity = entity;
            Commit = commit;
        }

        public TEntity Entity { get; }
        public bool Commit { get; }
    }

    public class CreateCommandHandler<TEntity> : IRequestHandler<CreateCommand<TEntity>> where TEntity : class, IEntity
    {
        private readonly IWriteEntities _writeEntities;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCommandHandler(IWriteEntities writeEntities, IUnitOfWork unitOfWork)
        {
            _writeEntities = writeEntities;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateCommand<TEntity> command, CancellationToken token)
        {
            _writeEntities.Create(command.Entity);

            if (command.Commit)
                await _unitOfWork.SaveChangesAsync(token).ConfigureAwait(false);

            return Unit.Value;
        }
    }
}