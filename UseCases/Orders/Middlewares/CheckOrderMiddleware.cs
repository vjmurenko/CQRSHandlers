using System;
using System.Threading.Tasks;
using AppService.Interfaces.Exceptions;
using CqrsFramework;
using Infrastracture.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace UseCases.Orders.Middlewares
{
    public class CheckOrderMiddleware<TRequest, TResponse> : IMiddleware<TRequest, TResponse>
        where TRequest : IRequest<TResponse>, ICheckOrderRequest
    {
        private readonly IReadOnlyDbContext _readOnlyDbContext;
        private readonly ICurrentUserService _currentUserService;

        public CheckOrderMiddleware(IReadOnlyDbContext readOnlyDbContext, ICurrentUserService currentUserService)
        {
            _readOnlyDbContext = readOnlyDbContext;
            _currentUserService = currentUserService;
        }
        public async Task<TResponse> HandleAsync(TRequest request, HandlerDelegate<TResponse> next)
        {
            var orders = await _readOnlyDbContext.Orders.ToListAsync();
            var orderCount = await _readOnlyDbContext.Orders.CountAsync(o => o.Id == request.Id && o.Email == _currentUserService.Email);
            if (orderCount != 1)
            {
                throw new NotFoundException();
            }

            return await next();
        }
    }
}