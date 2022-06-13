using System;
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

        protected Task<TResponse> HandleAsync<TRequest, TResponse>(TRequest request)
        {
            var handler = _serviceProvider.GetRequiredService<IRequestHandler<TRequest, TResponse>>();
            return handler.HandleAsync(request);
        }
    }
}