using AutoMapper;
using Entities;
using UseCases.Orders.Dto;

namespace UseCases.Orders.Utils
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