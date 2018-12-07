using System.Security.Principal;
using MediatR;

namespace NooBIT.Model.MediatR
{
    public interface ISecureRequest : IRequest
    {
        IPrincipal Principal { get; }
    }

    public interface ISecureRequest<out TResponse> : IRequest<TResponse>
    {
         IPrincipal Principal { get; }
    }
}