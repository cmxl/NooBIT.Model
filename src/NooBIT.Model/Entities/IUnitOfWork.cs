using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

namespace NooBIT.Model.Entities
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken token = default);
        Task<int> SaveChangesAsync(IPrincipal principal, CancellationToken token = default);
        Task DiscardChanges(CancellationToken token = default);
    }
}