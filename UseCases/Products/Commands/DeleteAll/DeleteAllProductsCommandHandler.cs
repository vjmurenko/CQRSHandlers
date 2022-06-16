using System.Threading.Tasks;
using CqrsFramework;
using Infrastracture.Interfaces;
using UseCases.Products.Commands.Delete;

namespace UseCases.Products.Commands.DeleteAll
{
    public class DeleteAllProductsCommandHandler : RequestHandler<DeleteAllProductsCommand>
    {
        private readonly IDbContext _dbContext;
        private readonly IDispatcher _dispatcher;

        public DeleteAllProductsCommandHandler(IDbContext dbContext, IDispatcher dispatcher)
        {
            _dbContext = dbContext;
            _dispatcher = dispatcher;
        }

        protected override async Task HandleAsync(DeleteAllProductsCommand request)
        {
            using (var transaction = _dbContext.BeginTransaction())
            {
                foreach (var id in request.DeleteAllDto.Ids)
                {
                    await _dispatcher.SendAsync(new DeleteProductCommand(){Id = id});
                }

                await transaction.CommitAsync();
            }
        }
    }
}