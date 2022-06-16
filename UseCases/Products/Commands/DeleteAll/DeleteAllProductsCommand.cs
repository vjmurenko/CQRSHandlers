using CqrsFramework;
using UseCases.Products.Dto;

namespace UseCases.Products.Commands.DeleteAll
{
    public class DeleteAllProductsCommand : IRequest
    {
        public DeleteAllDto DeleteAllDto { get; set; }
    }
}