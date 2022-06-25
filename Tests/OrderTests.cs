using System;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using CqrsFramework;
using DataAccess.MsSql;
using Entities;
using Infrastracture.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UseCases.Orders.Dto;
using UseCases.Orders.Queries.GetOrderById;
using WebApi;
using Xunit;

namespace Tests
{
    public class OrderTests
    {
        [Fact]
        public async void CheckOrderTest()
        {
            var services = new ServiceCollection();
            DIHelper.ConfigureServices(services);
        
            services.AddDbContext<IDbContext, AppDbContext>(builder => builder.UseInMemoryDatabase("Testing"));
            services.AddDbContext<IReadOnlyDbContext, AppDbContext>(builder => builder.UseInMemoryDatabase("Testing"));


            var factory = new AutofacServiceProviderFactory();
            var builder = factory.CreateBuilder(services);
            var serviceProvider = factory.CreateServiceProvider(builder);
            
            var dbContext = serviceProvider.GetRequiredService<IDbContext>();
            var currentUserService = serviceProvider.GetRequiredService<ICurrentUserService>();
            var dispatcher = serviceProvider.GetRequiredService<IDispatcher>();

            dbContext.Orders.AddRange(new[]
            {
                new Order {Id = 1, Email = "123"},
                new Order {Id = 2, Email = currentUserService.Email}
            });
            await dbContext.SaveChangesAsync();

            var get1Result = await dispatcher.SendAsync(new GetOrderByIdQuery {Id = 2});
            Assert.Equal(2, get1Result.Id);

            Func<Task<OrderDto>> get2Delegate = () => dispatcher.SendAsync(new GetOrderByIdQuery() {Id = 1});
            await Assert.ThrowsAsync<Exception>(get2Delegate);
            
            
        }
    }
}