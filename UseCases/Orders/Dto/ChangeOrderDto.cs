using System.Collections.Generic;

namespace UseCases.Orders.Dto
{
    public class ChangeOrderDto
    {
        public List<OrderItemDto> Items { get; set; }
    }
}