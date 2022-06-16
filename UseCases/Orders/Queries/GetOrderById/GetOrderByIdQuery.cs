using UseCases.Common.Queries.GetById;
using UseCases.Orders.Dto;
using UseCases.Orders.Middlewares;

namespace UseCases.Orders.Queries.GetOrderById
{
	public class GetOrderByIdQuery : GetEntityByIdQuery<OrderDto>, ICheckOrderRequest
	{
	}
}