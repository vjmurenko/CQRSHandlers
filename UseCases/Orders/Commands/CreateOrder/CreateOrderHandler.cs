using AppService.Interfaces;
using AutoMapper;
using Entities;
using Infrastracture.Interfaces;
using UseCases.Common.Commands.Create;
using UseCases.Orders.Dto;

namespace UseCases.Orders.Commands.CreateOrder
{
	public class CreateOrderHandler : CreateEntityCommandHandler<Order, CreateOrderCommand, ChangeOrderDto>
	{
		private readonly ICurrentUserService _currentUserService;

		public CreateOrderHandler(IDbContext dbContext, IMapper mapper, ICurrentUserService currentUserService) : base(dbContext, mapper)
		{
			_currentUserService = currentUserService;
		}

		protected override void InitializeEntity(Order entity)
		{
			entity.Email = _currentUserService.Email;
		}
	}
}