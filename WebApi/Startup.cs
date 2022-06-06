using AppService.Interfaces;
using CqrsFramework;
using DataAccess.MsSql;
using Infrastracture.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using UseCases.OrderCQ.Commands.CreateOrder;
using UseCases.OrderCQ.Commands.EditOrder;
using UseCases.OrderCQ.Dto;
using UseCases.OrderCQ.Queries.GetOrderById;
using UseCases.OrderCQ.Utils;
using WebApi.Services;

namespace WebApi {
	public class Startup {
		public Startup(IConfiguration configuration) {
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services) {

			services.AddControllers();
			services.AddSwaggerGen(c => {
				c.SwaggerDoc("v1",new OpenApiInfo { Title = "WebApi",Version = "v1" });
			});
			services.AddDbContext<IDbContext, AppDbContext>(builder =>
				builder.UseSqlServer(Configuration.GetConnectionString("Database")));
			services.AddAutoMapper(typeof(OrderMapperProfile));
			services.AddScoped<ICurrentUserService, CurrentUserService>();
			services.AddScoped<IRequestHandler<GetOrderByIdQuery, OrderDto>, GetOrderByIdHandler>();
			services.AddScoped<IRequestHandler<CreateOrderCommand, int>, CreateOrderHandler>();
			services.AddScoped<IRequestHandler<EditOrderCommand>, EditOrderHandler>();

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app,IWebHostEnvironment env) {
			if(env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json","WebApi v1"));
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints => {
				endpoints.MapControllers();
			});
		}
	}
}
