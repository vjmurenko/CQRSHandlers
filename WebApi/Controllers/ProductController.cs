using System.Threading.Tasks;
using CqrsFramework;
using Microsoft.AspNetCore.Mvc;
using UseCases.Products.Commands.Create;
using UseCases.Products.Commands.Delete;
using UseCases.Products.Commands.DeleteAll;
using UseCases.Products.Commands.Update;
using UseCases.Products.Dto;
using UseCases.Products.Queries;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;

        public ProductController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }
        
        [HttpGet("{id}")]
        public Task<ProductDto> Get(int id)
        {
            return _dispatcher.SendAsync(new GetProductByIdQuery {Id = id});
        }

        [HttpPost]
        public Task<int> Create([FromBody] ChangeProductDto changeProductDto)
        {
            return _dispatcher.SendAsync(new CreateProductCommand {Dto = changeProductDto});
        }

        [HttpPut("{id}")]
        public Task Edit(int id, [FromBody] ChangeProductDto changeProductDto)
        {
            return _dispatcher.SendAsync(new UpdateProductCommand {Id = id, Dto = changeProductDto});
        }

        [HttpDelete("{id}")]
        public Task Delete(int id, [FromServices] IRequestHandler<DeleteProductCommand> requestHandler)
        {
            return _dispatcher.SendAsync(new DeleteProductCommand() {Id = id});
        }

        [HttpDelete]
        public Task DeleteAll([FromBody] DeleteAllDto deleteAllDto)
        {
            return _dispatcher.SendAsync(new DeleteAllProductsCommand(){DeleteAllDto = deleteAllDto});
        }
    }
}