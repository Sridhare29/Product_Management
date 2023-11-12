using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Data;
using ProductManagement.Entities;
using ProductManagement.Models.DTO;
using ProductManagement.Repositories;

namespace ProductManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public readonly ProductDbContext dbContext;
        public readonly IProductRepositories _productRepositories;

        public ProductController(ProductDbContext dbContext, IProductRepositories productRepositories)
        {
            this.dbContext = dbContext;
            this._productRepositories = productRepositories;
        }


        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var productDomain = await _productRepositories.GetAllAync();

            var productDto = new List<ProductDto>();
            foreach (var product in productDomain)
            {
                productDto.Add(new ProductDto()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    ProductImageUrl = product.ProductImageUrl,
                    Price = product.Price,
                    CategoryId = product.CategoryId
                });
            }
            return Ok(productDomain);
        }


        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var productDomain = await _productRepositories.GetByIdAsync(id);

            if(productDomain == null)
            {
                return NotFound();
            }

            var productDto = new ProductDto
            {
                Id = productDomain.Id,
                Name = productDomain.Name,
                Description = productDomain.Description,
                ProductImageUrl = productDomain.ProductImageUrl,
                Price = productDomain.Price,
                CategoryId = productDomain.CategoryId
            };

            return Ok(productDto);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] AddProductRequestDto addProductRequestDto)
        {
            var productDomainModel = new Product
            {
                Name = addProductRequestDto.Name,
                Description = addProductRequestDto.Description,
                ProductImageUrl = addProductRequestDto.ProductImageUrl,
                Price = addProductRequestDto.Price,
                CategoryId = addProductRequestDto.CategoryId
            };

            productDomainModel = await _productRepositories.CreateAsync(productDomainModel);

            var productDto = new ProductDto
            {
                Id = productDomainModel.Id,
                Name = productDomainModel.Name,
                Description = productDomainModel.Description,
                ProductImageUrl = productDomainModel.ProductImageUrl,
                Price = productDomainModel.Price,
                CategoryId = productDomainModel.CategoryId
            };
            return CreatedAtAction(nameof(GetById),new {id = productDto.Id}, productDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> update([FromRoute] Guid id, UpdateProductRequestDto updateProductRequestDto)
        {
            var productDomainModel = new Product
            {
                Name = updateProductRequestDto.Name,
            Description = updateProductRequestDto.Description,
            ProductImageUrl = updateProductRequestDto.ProductImageUrl,
            Price = updateProductRequestDto.Price,
            CategoryId = updateProductRequestDto.CategoryId,
        };

        productDomainModel = await _productRepositories.UpdateAsync(id, productDomainModel);

            if(productDomainModel == null)
            {
                return NotFound();
            }

            //productDomainModel.Name = updateProductRequestDto.Name;
            //productDomainModel.Description = updateProductRequestDto.Description;
            //productDomainModel.ProductImageUrl = updateProductRequestDto.ProductImageUrl;
            //productDomainModel.Price = updateProductRequestDto.Price;
            //productDomainModel.CategoryId = updateProductRequestDto.CategoryId;

            //dbContext.SaveChanges();

            var productDto = new ProductDto
            {
                Id = productDomainModel.Id,
                Name = productDomainModel.Name,
                Description = productDomainModel.Description,
                ProductImageUrl = productDomainModel.ProductImageUrl,
                Price = productDomainModel.Price,
                CategoryId = productDomainModel.CategoryId,
            };

            return Ok(productDto);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var productDomainModel = await _productRepositories.DeleteAsync(id);

            if (productDomainModel == null)
            {
                return NotFound();
            }


            var productDto = new ProductDto
            {
                Id = productDomainModel.Id,
                Name = productDomainModel.Name,
                Description = productDomainModel.Description,
                ProductImageUrl = productDomainModel.ProductImageUrl,
                Price = productDomainModel.Price,
                CategoryId = productDomainModel.CategoryId,
            };

            return Ok(productDto);
        }
    }
}

