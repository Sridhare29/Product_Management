using System;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Entities;

namespace ProductManagement.Data
{
	public class ProductDbContext : DbContext
	{
		public ProductDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
		{
		}
        public DbSet<Product> products { get; set; }

        public DbSet<Category> categories { get; set; }

    }
}

