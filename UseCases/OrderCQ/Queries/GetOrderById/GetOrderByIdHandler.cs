using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CqrsFramework;
using Infrastracture.Interfaces;
using Microsoft.EntityFrameworkCore;
using UseCases.OrderCQ.Dto;

namespace UseCases.OrderCQ.Queries.GetOrderById
{
    public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, OrderDto>
    {
        private readonly IMapper _mapper;
        private readonly IReadOnlyDbContext _readOnlyDbContext;

        public GetOrderByIdHandler(IMapper mapper, IReadOnlyDbContext readOnlyDbContext)
        {
            _mapper = mapper;
            _readOnlyDbContext = readOnlyDbContext;
        }

        public async Task<OrderDto> HandleAsync(GetOrderByIdQuery request)
        {
            return await _readOnlyDbContext.Orders
                .Where(o => o.Id == request.Id)
                .ProjectTo<OrderDto>(_mapper.ConfigurationProvider)
                .SingleAsync();
        }
    }
}