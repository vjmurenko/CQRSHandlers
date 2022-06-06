using UseCases.OrderCQ.Dto;

namespace UseCases.OrderCQ.Commands.EditOrder
{
	public class EditOrderCommand
	{
		public int OrderId { get; set; }
		public ChangeOrderDto ChangeOrderDto { get; set; }
	}
}