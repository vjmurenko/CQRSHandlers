using System.Linq;
using System.Threading.Tasks;
using AppService.Interfaces;
using AutoMapper;
using CqrsFramework;
using Infrastracture.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace UseCases.OrderCQ.Commands.EditOrder
{
	public class EditOrderHandler : RequestHandler<EditOrderCommand>
	{
		private readonly IDbContext _dbContext;
		private readonly IMapper _mapper;
		private readonly IStatisticService _statisticService;

		public EditOrderHandler(IDbContext dbContext, IMapper mapper, IStatisticService statisticService)
		{
			_dbContext = dbContext;
			_mapper = mapper;
			_statisticService = statisticService;
		}

		protected override async Task HandleAsync(EditOrderCommand request)
		{
			_statisticService.WriteStatisticAsync("Order", request.ChangeOrderDto.Items.Select(s => s.ProductId));
			
			var order = await _dbContext.Orders
				.Include(o => o.Items)
				.SingleAsync(o => o.Id == request.OrderId);
			_mapper.Map(request.ChangeOrderDto, order);
			await _dbContext.SaveChangesAsync();
		}
	}
}