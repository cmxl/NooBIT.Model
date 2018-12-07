using MediatR;
using NooBIT.Model.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace NooBIT.Model.MediatR
{
    public class RawCommand : IRequest<int>
    {
        public string CommandText { get; set; }
        public object[] CommandParameters { get; set; }
    }

    public class RawCommandHandler : IRequestHandler<RawCommand, int>
    {
        private readonly IWriteEntities _writeEntities;

        public RawCommandHandler(IWriteEntities writeEntities)
        {
            _writeEntities = writeEntities;
        }

        public async Task<int> Handle(RawCommand request, CancellationToken token)
            => await _writeEntities.ExecuteRawQuery(request.CommandText, request.CommandParameters, token);
    }
}