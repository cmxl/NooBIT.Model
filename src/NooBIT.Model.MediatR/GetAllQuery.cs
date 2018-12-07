using MediatR;
using NooBIT.Model.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NooBIT.Model.MediatR
{
    public class GetAllQuery<TEntity> : IRequest<IList<TEntity>> where TEntity : class, IEntity
    {
    }

    public class GetAllQueryHandler<TEntity> : IRequestHandler<GetAllQuery<TEntity>, IList<TEntity>> where TEntity : class, IEntity
    {
        private readonly IReadEntities _readEntities;

        public GetAllQueryHandler(IReadEntities readEntities)
        {
            _readEntities = readEntities;
        }

        public async Task<IList<TEntity>> Handle(GetAllQuery<TEntity> query, CancellationToken token)
            => await Task.FromResult(_readEntities.Get<TEntity>().ToList());
    }
}