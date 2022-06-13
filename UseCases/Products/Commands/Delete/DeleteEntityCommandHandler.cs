using Entities;
using Infrastracture.Interfaces;
using UseCases.Common.Commands.Delete;

namespace UseCases.Products.Commands.Delete
{
    public class DeleteEntityCommandHandler : DeleteEntityCommandHandler<Product, DeleteProductCommand>
    {
        public DeleteEntityCommandHandler(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}