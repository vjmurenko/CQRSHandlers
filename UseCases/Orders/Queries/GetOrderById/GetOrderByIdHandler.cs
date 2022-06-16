using AutoMapper;
using Entities;
using Infrastracture.Interfaces;
using UseCases.Common.Queries.GetById;
using UseCases.Orders.Dto;

namespace UseCases.Orders.Queries.GetOrderById
{
    public class GetOrderByIdHandler : GetEntityByIdQueryHandler<Order, GetOrderByIdQuery, OrderDto>
    {
        public GetOrderByIdHandler(IReadOnlyDbContext readOnlyDbContext, IMapper mapper) : base(readOnlyDbContext, mapper)
        {
        }
    }
}