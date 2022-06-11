using System.Threading.Tasks;
using CqrsFramework;
using Microsoft.AspNetCore.Mvc;
using UseCases.Orders.Queries.GetOrderById;
using UseCases.Products.Commands.CreateProduct;
using UseCases.Products.Commands.UpdateProduct;
using UseCases.Products.Dto;
using UseCases.Products.Queries;

namespace WebApi.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ProductController : ControllerBase
	{

		[HttpGet("{id}")]
		public Task<ProductDto> Get(int id, [FromServices] IRequestHandler<GetProductByIdQuery, ProductDto> requestHandler)
		{
			return requestHandler.HandleAsync(new GetProductByIdQuery {Id = id});
		}

		[HttpPost]
		public Task<int> Create([FromBody] ChangeProductDto changeProductDto, [FromServices] IRequestHandler<CreateProductCommand, int> requestHandler)
		{
			return requestHandler.HandleAsync(new CreateProductCommand {Dto = changeProductDto});
		}

		[HttpPut("{id}")]
		public Task Edit(int id, [FromBody] ChangeProductDto changeProductDto, [FromServices] IRequestHandler<UpdateProductCommand> requestHandler)
		{
			return requestHandler.HandleAsync(new UpdateProductCommand {Id = id, Dto = changeProductDto});
		}
	}
}