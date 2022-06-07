using System.Threading;
using System.Threading.Tasks;

namespace Infrastracture.Interfaces
{
    public interface IDbContext : IReadOnlyDbContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}