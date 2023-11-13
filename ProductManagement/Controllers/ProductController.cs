using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Entities;
using ProductManagement.Models.DTO;
using ProductManagement.Repositories;

namespace ProductManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public readonly IProductRepositories _productRepositories;
        public readonly IMapper _mapper;

        public ProductController(IProductRepositories productRepositories,IMapper mapper)
        {
            this._productRepositories = productRepositories;
            this._mapper = mapper;
        }


        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var productDomainModel = await _productRepositories.GetAllAsync();

            //Map Entities to Dto
            return Ok(_mapper.Map<List<ProductDto>>(productDomainModel));
          
        }


        //[HttpGet]
        //[Route("{id:Guid}")]
        //public async Task<IActionResult> GetById([FromRoute] Guid id)
        //{
        //    var productDomain = await _productRepositories.GetByIdAsync(id);

        //    if(productDomain == null)
        //    {
        //        return NotFound();
        //    }

        //    var productDto = new ProductDto
        //    {
        //        Id = productDomain.Id,
        //        Name = productDomain.Name,
        //        Description = productDomain.Description,
        //        ProductImageUrl = productDomain.ProductImageUrl,
        //        Price = productDomain.Price,
        //    };

        //    return Ok(productDto);
        //}

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] AddProductRequestDto addProductRequestDto)
        {
            //Map Dto to Entity
            var productDomainModel = _mapper.Map<Product>(addProductRequestDto);

            await _productRepositories.CreateAsync(productDomainModel);

            //Map Entity to Dto
            return Ok(_mapper.Map<ProductDto>(productDomainModel));
        }

        //[HttpPut]
        //[Route("{id:Guid}")]
        //public async Task<IActionResult> update([FromRoute] Guid id, UpdateProductRequestDto updateProductRequestDto)
        //{
        //    var productDomainModel = new Product
        //    {
        //        Name = updateProductRequestDto.Name,
        //    Description = updateProductRequestDto.Description,
        //    ProductImageUrl = updateProductRequestDto.ProductImageUrl,
        //    Price = updateProductRequestDto.Price,
        //    CategoryId = updateProductRequestDto.CategoryId,
        //};

        //productDomainModel = await _productRepositories.UpdateAsync(id, productDomainModel);

        //    if(productDomainModel == null)
        //    {
        //        return NotFound();
        //    }

        //    //productDomainModel.Name = updateProductRequestDto.Name;
        //    //productDomainModel.Description = updateProductRequestDto.Description;
        //    //productDomainModel.ProductImageUrl = updateProductRequestDto.ProductImageUrl;
        //    //productDomainModel.Price = updateProductRequestDto.Price;
        //    //productDomainModel.CategoryId = updateProductRequestDto.CategoryId;

        //    //dbContext.SaveChanges();

        //    var productDto = new ProductDto
        //    {
        //        Id = productDomainModel.Id,
        //        Name = productDomainModel.Name,
        //        Description = productDomainModel.Description,
        //        ProductImageUrl = productDomainModel.ProductImageUrl,
        //        Price = productDomainModel.Price,
        //    };

        //    return Ok(productDto);
        //}

        //[HttpDelete]
        //[Route("{id:Guid}")]
        //public async Task<IActionResult> Delete([FromRoute] Guid id)
        //{
        //    var productDomainModel = await _productRepositories.DeleteAsync(id);

        //    if (productDomainModel == null)
        //    {
        //        return NotFound();
        //    }


        //    var productDto = new ProductDto
        //    {
        //        Id = productDomainModel.Id,
        //        Name = productDomainModel.Name,
        //        Description = productDomainModel.Description,
        //        ProductImageUrl = productDomainModel.ProductImageUrl,
        //        Price = productDomainModel.Price,
        //    };

        //    return Ok(productDto);
        //}
    }
}

