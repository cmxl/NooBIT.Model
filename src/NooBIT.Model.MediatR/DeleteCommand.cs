using MediatR;
using NooBIT.Model.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace NooBIT.Model.MediatR
{
    public class DeleteCommand<TEntity> : IRequest where TEntity : class, IEntity
    {
        public DeleteCommand(TEntity entity, bool commit = false)
        {
            Entity = entity;
            Commit = commit;
        }

        public TEntity Entity { get; }
        public bool Commit { get; }
    }

    public class DeleteCommandHandler<TEntity> : IRequestHandler<DeleteCommand<TEntity>> where TEntity : class, IEntity
    {
        private readonly IWriteEntities _writeEntities;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCommandHandler(IWriteEntities writeEntities, IUnitOfWork unitOfWork)
        {
            _writeEntities = writeEntities;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteCommand<TEntity> command, CancellationToken token)
        {
            _writeEntities.Delete(command.Entity);

            if (command.Commit)
                await _unitOfWork.SaveChangesAsync(token);

            return Unit.Value;
        }
    }
}