using UseCases.Common.Commands.Update;
using UseCases.Orders.Dto;
using UseCases.Orders.Middlewares;
using UseCases.Products.Dto;

namespace UseCases.Orders.Commands.Edit
{
	public class EditOrderCommand : UpdateEntityCommand<ChangeOrderDto>,  ICheckOrderRequest, ICheckUpdateOrderRequest
	{
	}
}