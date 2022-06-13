using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastracture.Interfaces
{
    public interface IDbContext : IReadOnlyDbContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        IDbContextTransaction BeginTransaction();
    }
}