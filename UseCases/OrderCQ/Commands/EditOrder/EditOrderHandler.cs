using System.Linq;
using System.Threading.Tasks;
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

		public EditOrderHandler(IDbContext dbContext, IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}

		protected override async Task HandleAsync(EditOrderCommand request)
		{
			var order = await _dbContext.Orders
				.Include(o => o.Items)
				.SingleAsync(o => o.Id == request.OrderId);
			_mapper.Map(request.ChangeOrderDto, order);
			await _dbContext.SaveChangesAsync();
		}
	}
}