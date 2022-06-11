using AutoMapper;
using Entities;
using Infrastracture.Interfaces;
using UseCases.Common.Commands.Update;
using UseCases.Products.Dto;

namespace UseCases.Products.Commands.UpdateProduct
{
	public class UpdateProductCommandHandler : UpdateEntityCommandHandler<Product, UpdateProductCommand, ChangeProductDto>
	{
		public UpdateProductCommandHandler(IDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
		{
		}
	}
}