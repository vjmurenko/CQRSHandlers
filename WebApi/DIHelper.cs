using AppService.Implementations;
using AppService.Interfaces;
using AutoMapper;
using CqrsFramework;
using Infrastracture.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using UseCases.Orders.Middlewares;
using UseCases.Orders.Queries.GetOrderById;
using UseCases.Orders.Utils;
using UseCases.Products.Utils;
using WebApi.Services;

namespace WebApi
{
    public class DIHelper
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(OrderMapperProfile));
            services.AddAutoMapper(typeof(ProductMapperProfile));
			
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<IDispatcher, Dispatcher>();
            services.AddScoped(typeof(IMiddleware<,>), typeof(CheckOrderMiddleware<,>));
            services.AddScoped(typeof(IMiddleware<,>), typeof(CheckUpdateOrderMiddleware<,>));

            services.Scan(selector =>
                selector.FromAssemblyOf<GetOrderByIdQuery>()
                    .AddClasses(classes => classes.AssignableTo(typeof(IRequestHandler<,>)))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());
            services.AddScoped<IStatisticService, StatisticService>();
        }
    }
}