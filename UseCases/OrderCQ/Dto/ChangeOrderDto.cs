using System.Collections.Generic;

namespace UseCases.OrderCQ.Dto
{
    public class ChangeOrderDto
    {
        public List<OrderItemDto> Items { get; set; }
    }
}