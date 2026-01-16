using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MobileStore.Models;

namespace MobileStore.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            // Seed Data mẫu
            builder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "iPhone", Icon = "bi-apple" },
                new Category { Id = 2, Name = "Samsung", Icon = "bi-phone" },
                new Category { Id = 3, Name = "Xiaomi", Icon = "bi-phone-fill" }
            );

            builder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "iPhone 15 Pro Max", Description = "Titanium design", Price = 34990000, StockQuantity = 10, CategoryId = 1, ImageUrl = "/images/products/iphone15.jpg", IsFeatured = true },
                new Product { Id = 2, Name = "Samsung Galaxy S24 Ultra", Description = "Galaxy AI", Price = 30990000, StockQuantity = 15, CategoryId = 2, ImageUrl = "/images/products/s24ultra.jpg", IsFeatured = true },
                new Product { Id = 3, Name = "Xiaomi 14", Description = "Leica Camera", Price = 22990000, StockQuantity = 20, CategoryId = 3, ImageUrl = "/images/products/xiaomi14.jpg", IsFeatured = false }
            );
        }
    }
}
