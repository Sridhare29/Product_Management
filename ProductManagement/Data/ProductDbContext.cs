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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var categories = new List<Category>()
            {
                new Category
                {
                    Id = Guid.Parse("3dda4c07-27bf-45d9-95ea-1350c4ddd971"),
                    Name = "Mac"
                },
                new Category
                {
                    Id = Guid.Parse("c2c74b01-69fd-4440-a8c1-11217e6ff9b7"),
                    Name = "iPad"
                },
                new Category
                {
                    Id = Guid.Parse("2bd55ae7-2979-48e6-b2d5-c26c6dc18647"),
                    Name = "iPhone"
                },
                new Category
                {
                    Id = Guid.Parse("0feff3cb-c005-422d-b5c0-cfbeae3582fb"),
                    Name = "Watch"
                },
                new Category
                {
                    Id = Guid.Parse("9825536e-74ee-4bdb-bd0b-47b1afb2867f"),
                    Name = "AirPods"
                },
                new Category
                {
                    Id = Guid.Parse("ebe6d95a-f0a8-4bcf-a6ef-293cf109ce07"),
                    Name = "TV & Home"
                },
                new Category
                {
                    Id = Guid.Parse("3b7a8617-2331-42e1-b69b-c1e92831cf28"),
                    Name = "Accessories"
                }
            };
            modelBuilder.Entity<Category>().HasData(categories);
        }
    }
}

