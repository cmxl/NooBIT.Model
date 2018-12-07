using MediatR;
using NooBIT.Model.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace NooBIT.Model.MediatR
{
    public class GetByIdQuery<TEntity, TKey> : IRequest<TEntity> where TEntity : class, IEntity<TKey>
    {
        public GetByIdQuery(TKey id)
        {
            Id = id;
        }

        public TKey Id { get; }
    }

    public abstract class GetByIdQueryHandler<TEntity, TKey> : IRequestHandler<GetByIdQuery<TEntity, TKey>, TEntity> where TEntity : class, IEntity<TKey>
    {
        public abstract Task<TEntity> Handle(GetByIdQuery<TEntity, TKey> query, CancellationToken token);
    }
}
