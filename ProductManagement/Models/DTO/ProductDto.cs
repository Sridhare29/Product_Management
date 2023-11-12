using System;
using ProductManagement.Entities;

namespace ProductManagement.Models.DTO
{
	public class ProductDto
	{
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public String? ProductImageUrl { get; set; }

        public decimal Price { get; set; }

        public Guid CategoryId { get; set; }
    }
}

