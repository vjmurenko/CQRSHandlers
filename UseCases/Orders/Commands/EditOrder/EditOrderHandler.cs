using System.Linq;
using System.Threading.Tasks;
using AppService.Interfaces;
using AutoMapper;
using CqrsFramework;
using Entities;
using Infrastracture.Interfaces;
using Microsoft.EntityFrameworkCore;
using UseCases.Common.Commands.Update;
using UseCases.Orders.Dto;

namespace UseCases.Orders.Commands.EditOrder
{
	public class EditOrderHandler : UpdateEntityCommandHandler<Order, EditOrderCommand, ChangeOrderDto>
	{
		private readonly IStatisticService _statisticService;

		public EditOrderHandler(IDbContext dbContext, IMapper mapper, IStatisticService statisticService) : base(dbContext, mapper)
		{
			_statisticService = statisticService;
		}

		protected override async Task HandleAsync(EditOrderCommand request)
		{
			await _statisticService.WriteStatisticAsync("Order", request.Dto.Items.Select(s => s.ProductId)); 
			await base.HandleAsync(request);
		}

		protected override async Task<Order> GettrackedEntityAsync(EditOrderCommand request)
		{
			return await _dbContext.Orders.Include(o => o.Items).SingleAsync(o => o.Id == request.Id);
		}
	}
}