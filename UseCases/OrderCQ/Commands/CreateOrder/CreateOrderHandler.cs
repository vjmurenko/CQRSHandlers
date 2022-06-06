using System.Threading.Tasks;
using AppService.Interfaces;
using AutoMapper;
using CqrsFramework;
using Entities;
using Infrastracture.Interfaces;

namespace UseCases.OrderCQ.Commands.CreateOrder {
	public class CreateOrderHandler:IRequestHandler<CreateOrderCommand,int> {
		private readonly IDbContext _dbContext;
		private readonly IMapper _mapper;
		private readonly ICurrentUserService _currentUserService;

		public CreateOrderHandler(IDbContext dbContext,IMapper mapper,ICurrentUserService currentUserService) {
			_dbContext = dbContext;
			_mapper = mapper;
			_currentUserService = currentUserService;
		}
		public async Task<int> HandleAsync(CreateOrderCommand request) {
			var order = _mapper.Map<Order>(request.ChangeOrderDto);
			order.Email = _currentUserService.Email;
			_dbContext.Orders.Add(order);
			await _dbContext.SaveChangesAsync();
			return order.Id;
		}
	}
}