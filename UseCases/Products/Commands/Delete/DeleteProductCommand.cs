using CqrsFramework;
using UseCases.Common.Commands.Delete;

namespace UseCases.Products.Commands.Delete
{
    public class DeleteProductCommand : DeleteEntityCommand, IRequest
    {
    }
}