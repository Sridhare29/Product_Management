using System;
using AutoMapper;
using ProductManagement.Entities;
using ProductManagement.Models.DTO;

namespace ProductManagement.Mappings
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<AddProductRequestDto, Product>().ReverseMap();
            CreateMap<UpdateProductRequestDto, Product>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
	}
}

