using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace CqrsFramework
{
    public class Dispatcher : IDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public Dispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
        {
            var method = GetType().GetMethod(nameof(HandleAsync), BindingFlags.Instance | BindingFlags.NonPublic)
                .MakeGenericMethod(request.GetType(), typeof(TResponse));
            
            return (Task<TResponse>) method.Invoke(this, new[] {request});
        }

        protected Task<TResponse> HandleAsync<TRequest, TResponse>(TRequest request) where TRequest : IRequest<TResponse>
        {
            var handler = _serviceProvider.GetRequiredService<IRequestHandler<TRequest, TResponse>>();
            var middlewares = _serviceProvider.GetServices<IMiddleware<TRequest, TResponse>>();
            HandlerDelegate<TResponse> handlerDelegate = () => handler.HandleAsync(request);
            var resultDelegate = middlewares.Aggregate(handlerDelegate, (next, middleware) => () => middleware.HandleAsync(request, next));
            
            return resultDelegate();
        }
    }
}