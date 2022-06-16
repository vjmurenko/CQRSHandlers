using UseCases.Common.Commands.Update;
using UseCases.Orders.Dto;
using UseCases.Orders.Middlewares;

namespace UseCases.Orders.Commands.Edit
{
	public class EditOrderCommand :UpdateEntityCommand<ChangeOrderDto>, ICheckOrderRequest, ICheckUpdateOrderRequest
	{
	}
}