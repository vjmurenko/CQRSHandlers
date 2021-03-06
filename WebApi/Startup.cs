using AppService.Implementations;
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
using UseCases.Orders.Middlewares;
using UseCases.Orders.Queries.GetOrderById;
using UseCases.Orders.Utils;
using UseCases.Products.Utils;
using WebApi.Services;

namespace WebApi {
	public class Startup {
		public Startup(IConfiguration configuration) {
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();
			services.AddSwaggerGen(c => {
				c.SwaggerDoc("v1",new OpenApiInfo { Title = "WebApi",Version = "v1" });
			});
			services.AddDbContext<IDbContext, AppDbContext>(builder =>
				builder.UseSqlServer(Configuration.GetConnectionString("Database")));
			services.AddDbContext<IReadOnlyDbContext, ReadOnlyAppDbContext>(builder =>
				builder.UseSqlServer(Configuration.GetConnectionString("Database")));
			DIHelper.ConfigureServices(services);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app,IWebHostEnvironment env) {
			if(env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json","WebApi v1"));
			}

			app.UseExceptionMiddleware();
			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints => {
				endpoints.MapControllers();
			});
		}
	}
}
