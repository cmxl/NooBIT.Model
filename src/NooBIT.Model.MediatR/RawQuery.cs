using MediatR;
using NooBIT.Model.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NooBIT.Model.MediatR
{
    public class RawQuery<TEntity> : IRequest<List<TEntity>> where TEntity : class, IEntity
    {
        public string CommandText { get; set; }
        public object[] CommandParameters { get; set; }
    }

    public class RawQueryHandler<TEntity> : IRequestHandler<RawQuery<TEntity>, List<TEntity>> where TEntity : class, IEntity
    {
        private readonly IWriteEntities _writeEntities;

        public RawQueryHandler(IWriteEntities writeEntities)
        {
            _writeEntities = writeEntities;
        }

        public async Task<List<TEntity>> Handle(RawQuery<TEntity> request, CancellationToken token)
            => await _writeEntities.ExecuteRawQuery<TEntity>(request.CommandText, request.CommandParameters, token);

    }
}