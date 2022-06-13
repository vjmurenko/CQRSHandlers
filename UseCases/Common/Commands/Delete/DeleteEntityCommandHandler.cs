using System.Threading.Tasks;
using CqrsFramework;
using Entities;
using Infrastracture.Interfaces;

namespace UseCases.Common.Commands.Delete
{
    public abstract class DeleteEntityCommandHandler<TEntity, TRequest> : RequestHandler<TRequest>
        where TEntity : Entity, new()
        where TRequest : DeleteEntityCommand
    {
        protected readonly IDbContext _dbContext;

        protected DeleteEntityCommandHandler(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected override async Task HandleAsync(TRequest request)
        {
            _dbContext.Set<TEntity>().Remove(new TEntity {Id = request.Id});
            await _dbContext.SaveChangesAsync();
        }
    }
}