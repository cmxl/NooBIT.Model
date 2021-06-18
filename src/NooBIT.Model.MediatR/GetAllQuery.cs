using MediatR;
using NooBIT.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NooBIT.Model.MediatR
{
    [Obsolete("This is not truly asynchronous and should not be used when async methods are available for the underlying IReadEntities implementation!")]
    public class GetAllQuery<TEntity> : IRequest<IReadOnlyCollection<TEntity>> where TEntity : class, IEntity
    {
    }

    [Obsolete("This is not truly asynchronous and should not be used when async methods are available for the underlying IReadEntities implementation!")]
    public class GetAllQueryHandler<TEntity> : IRequestHandler<GetAllQuery<TEntity>, IReadOnlyCollection<TEntity>> where TEntity : class, IEntity
    {
        private readonly IReadEntities _readEntities;

        public GetAllQueryHandler(IReadEntities readEntities)
        {
            _readEntities = readEntities;
        }

        public Task<IReadOnlyCollection<TEntity>> Handle(GetAllQuery<TEntity> query, CancellationToken token)
        {
            IReadOnlyCollection<TEntity> result = _readEntities.Get<TEntity>().ToList().AsReadOnly();
            return Task.FromResult(result);
        }
    }
}