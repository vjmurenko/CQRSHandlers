using AutoMapper;
using Entities;
using Infrastracture.Interfaces;
using UseCases.Common.Queries.GetById;
using UseCases.Products.Dto;

namespace UseCases.Products.Queries
{
	public class GetProductByIdHandler : GetEntityByIdQueryHandler<Product, GetProductByIdQuery, ProductDto>
	{
		public GetProductByIdHandler(IReadOnlyDbContext readOnlyDbContext, IMapper mapper) : base(readOnlyDbContext, mapper)
		{
		}
	}
}