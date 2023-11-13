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
			CreateMap<AddProductRequestDto, Product>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();

            CreateMap<Category, CategoryDto>().ReverseMap();
        }
	}
}

