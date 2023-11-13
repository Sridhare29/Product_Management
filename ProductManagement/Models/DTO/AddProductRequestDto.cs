using System;
using System.ComponentModel.DataAnnotations;

namespace ProductManagement.Models.DTO
{
	public class AddProductRequestDto
	{
        [Required]
        [MaxLength(100, ErrorMessage = "Name has to be a maximum of 100 characters")]
        public string Name { get; set; }

        [Required]
        [MaxLength(1000, ErrorMessage = "Name has to be a maximum of 1000 characters")]
        public string Description { get; set; }
        
        public String? ProductImageUrl { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a non-negative value")]
        public decimal Price { get; set; }

        public Guid CategoryId { get; set; }

    }
}

