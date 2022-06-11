using AutoMapper;
using Entities;
using Infrastracture.Interfaces;
using UseCases.Common.Commands.Create;
using UseCases.Products.Dto;

namespace UseCases.Products.Commands.CreateProduct
{
	public class CreateProductCommandHandler : CreateEntityCommandHandler<Product, CreateProductCommand, ChangeProductDto>
	{
		public CreateProductCommandHandler(IDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
		{
		}
	}
}