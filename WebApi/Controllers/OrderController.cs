using System.Threading.Tasks;
using CqrsFramework;
using Microsoft.AspNetCore.Mvc;
using UseCases.OrderCQ.Commands.CreateOrder;
using UseCases.OrderCQ.Commands.EditOrder;
using UseCases.OrderCQ.Dto;
using UseCases.OrderCQ.Queries.GetOrderById;

namespace WebApi.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class OrderController : ControllerBase
	{
		private readonly IRequestHandler<GetOrderByIdQuery, OrderDto> _requestHandler;

		public OrderController(IRequestHandler<GetOrderByIdQuery, OrderDto> requestHandler)
		{
			_requestHandler = requestHandler;
		}

		[HttpGet("{id}")]
		public Task<OrderDto> Get(int id)
		{
			return _requestHandler.HandleAsync(new GetOrderByIdQuery {Id = id});
		}


		[HttpPost]
		public Task<int> Create([FromBody] ChangeOrderDto chanerOrderDto, [FromServices] IRequestHandler<CreateOrderCommand, int> handler)
		{
			return handler.HandleAsync(new CreateOrderCommand() {ChangeOrderDto = chanerOrderDto});
		}

		[HttpPut("{id}")]
		public Task<Unit> Edit([FromBody] ChangeOrderDto changeOrderDto, int id, [FromServices] IRequestHandler<EditOrderCommand> handler)
		{
			return handler.HandleAsync(new EditOrderCommand() {ChangeOrderDto = changeOrderDto, OrderId = id});
		}
	}
}