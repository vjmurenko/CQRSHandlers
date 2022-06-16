using System.Threading.Tasks;
using CqrsFramework;
using Microsoft.AspNetCore.Mvc;
using UseCases.Orders.Commands.Create;
using UseCases.Orders.Commands.Edit;
using UseCases.Orders.Dto;
using UseCases.Orders.Queries.GetOrderById;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;

        public OrderController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpGet("{id}")]
        public Task<OrderDto> Get(int id)
        {
           return _dispatcher.SendAsync(new GetOrderByIdQuery {Id = id});
        }

        [HttpPost]
        public Task<int> Create([FromBody] ChangeOrderDto chanerOrderDto)
        {
            return _dispatcher.SendAsync(new CreateOrderCommand {Dto = chanerOrderDto});
        }

        [HttpPut("{id}")]
        public Task<Unit> Edit([FromBody] ChangeOrderDto changeOrderDto, int id)
        {
            return _dispatcher.SendAsync(new EditOrderCommand {Dto = changeOrderDto, Id = id});
        }
    }
}