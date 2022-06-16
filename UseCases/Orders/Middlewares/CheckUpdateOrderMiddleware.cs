using System;
using System.Linq;
using System.Threading.Tasks;
using CqrsFramework;
using Infrastracture.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace UseCases.Orders.Middlewares
{
	public class CheckUpdateOrderMiddleware<TRequest, TResponse> : IMiddleware<TRequest, TResponse>
		where TRequest : IRequest<TResponse>, ICheckOrderRequest, ICheckUpdateOrderRequest
	{
		private readonly IDbContext _dbContext;

		public CheckUpdateOrderMiddleware(IDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public async Task<TResponse> HandleAsync(TRequest request, HandlerDelegate<TResponse> next)
		{
			var order = await _dbContext.Orders.Include(o => o.Items).FirstAsync(o => o.Id == request.Id);
			if (order.Items.Any(i => i.Quantity > 2))
			{
				throw new Exception("Quantity > 2");
			}

			return await next();
		}
	}
}