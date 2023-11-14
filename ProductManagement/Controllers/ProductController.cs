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

            return Ok(_mapper.Map<List<ProductDto>>(productDomainModel));
          
        }


        [HttpGet]
        [Route("Get/{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var productDomainModel = await _productRepositories.GetByIdAsync(id);

            if (productDomainModel == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ProductDto>(productDomainModel));
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] AddProductRequestDto addProductRequestDto)
        {
            if (ModelState.IsValid)
            {
                var productDomainModel = _mapper.Map<Product>(addProductRequestDto);

                await _productRepositories.CreateAsync(productDomainModel);

                return Ok(_mapper.Map<ProductDto>(productDomainModel));
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        [Route("Update/{id:Guid}")]
        public async Task<IActionResult> update([FromRoute] Guid id, UpdateProductRequestDto updateProductRequestDto)
        {
            if (ModelState.IsValid)
            {
                var productDomainModel = _mapper.Map<Product>(updateProductRequestDto);

                productDomainModel = await _productRepositories.UpdateAsync(id, productDomainModel);

                if (productDomainModel == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<ProductDto>(productDomainModel));
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Route("Delete/{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var productDomainModel = await _productRepositories.DeleteAsync(id);

            if (productDomainModel == null)
            {
                return NotFound();
            }


            return Ok(_mapper.Map<ProductDto>(productDomainModel));
        }
    }
}

