using AutoMapper;
using Entities;
using UseCases.OrderCQ.Dto;

namespace UseCases.OrderCQ.Utils
{
    public class OrderMapperProfile : Profile
    {
        public OrderMapperProfile()
        {
	        CreateMap<Order, OrderDto>();
            CreateMap<OrderItem, OrderItemDto>().ReverseMap();
            CreateMap<ChangeOrderDto, Order>();
        }
    }
}