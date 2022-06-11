using AutoMapper;
using Entities;
using UseCases.Products.Dto;

namespace UseCases.Products.Utils
{
	public class ProductMapperProfile : Profile
	{
		public ProductMapperProfile()
		{
			CreateMap<Product, ProductDto>();
			CreateMap<ChangeProductDto, Product>();
		}
	}
}