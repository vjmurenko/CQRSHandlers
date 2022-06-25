using System;
using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using AppService.Interfaces.Exceptions;

namespace WebApi {
	// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
	public class ExceptionMiddleware {
		private readonly RequestDelegate _next;

		public ExceptionMiddleware(RequestDelegate next) {
			_next = next;
		}

		public async Task Invoke(HttpContext httpContext) {

			try
			{
				await _next(httpContext);
			}
			catch (NotFoundException e)
			{
				httpContext.Response.StatusCode = (int) HttpStatusCode.NotFound;
			}
			catch (LowQuantityException e)
			{
				httpContext.Response.StatusCode = (int) HttpStatusCode.BadRequest;
			}
		}
	}

	// Extension method used to add the middleware to the HTTP request pipeline.
	public static class ExceptionMiddlewareExtensions {
		public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder) {
			return builder.UseMiddleware<ExceptionMiddleware>();
		}
	}
}
