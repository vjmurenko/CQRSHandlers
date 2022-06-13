using System;
using System.Threading.Tasks;
using CqrsFramework;
using Infrastracture.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using UseCases.Products.Commands.Delete;

namespace UseCases.Products.Commands.DeleteAll
{
    public class DeleteAllProductsCommandHandler : RequestHandler<DeleteAllProductsCommand>
    {
        private readonly IDbContext _dbContext;
        private readonly IServiceProvider _serviceProvider;

        public DeleteAllProductsCommandHandler(IDbContext dbContext, IServiceProvider serviceProvider)
        {
            _dbContext = dbContext;
            _serviceProvider = serviceProvider;
        }

        protected override async Task HandleAsync(DeleteAllProductsCommand request)
        {
            using (var transaction = _dbContext.BeginTransaction())
            {
                var deleteHandler = _serviceProvider.GetRequiredService<IRequestHandler<DeleteProductCommand>>();
                foreach (var id in request.DeleteAllDto.Ids)
                {
                    await deleteHandler.HandleAsync(new DeleteProductCommand() {Id = id});
                }

                await transaction.CommitAsync();
            }
        }
    }
}