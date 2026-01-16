using Microsoft.AspNetCore.Identity;
using MobileStore.Models;

namespace MobileStore.Data
{
    public static class DbInitializer
    {
        public static async Task Initialize(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // Ensure database is created
            context.Database.EnsureCreated();

            // Seed Roles
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }
            if (!await roleManager.RoleExistsAsync("Customer"))
            {
                await roleManager.CreateAsync(new IdentityRole("Customer"));
            }

            // Seed Users
            if (await userManager.FindByEmailAsync("admin@mobilestore.com") == null)
            {
                var adminUser = new ApplicationUser
                {
                    UserName = "admin@mobilestore.com",
                    Email = "admin@mobilestore.com",
                    FullName = "Administrator",
                    EmailConfirmed = true,
                    Address = "MobileStore HQ"
                };
                var result = await userManager.CreateAsync(adminUser, "Admin@123");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }

            if (await userManager.FindByEmailAsync("customer@mobilestore.com") == null)
            {
                var customerUser = new ApplicationUser
                {
                    UserName = "customer@mobilestore.com",
                    Email = "customer@mobilestore.com",
                    FullName = "Khách Hàng Thân Thiết",
                    EmailConfirmed = true,
                    Address = "Hanoi, Vietnam"
                };
                await userManager.CreateAsync(customerUser, "Customer@123");
                await userManager.AddToRoleAsync(customerUser, "Customer");
            }

            // Seed Categories
            if (!context.Categories.Any())
            {
                var categories = new List<Category>
                {
                    new Category { Name = "iOS", Icon = "bi-apple" },
                    new Category { Name = "Android", Icon = "bi-android2" },
                    new Category { Name = "Phụ kiện", Icon = "bi-headphones" },
                    new Category { Name = "Laptop", Icon = "bi-laptop" },
                    new Category { Name = "Tablet", Icon = "bi-tablet" }
                };
                context.Categories.AddRange(categories);
                await context.SaveChangesAsync();
            }

            // Seed Products
            if (!context.Products.Any())
            {
                var iosCategory = context.Categories.First(c => c.Name == "iOS");
                var androidCategory = context.Categories.First(c => c.Name == "Android");
                var accessoriesCategory = context.Categories.First(c => c.Name == "Phụ kiện");

                var products = new List<Product>
                {
                    // iPhone 15 Series
                    new Product
                    {
                        Name = "iPhone 15 Pro Max 1TB",
                        Description = "Khung viền Titanium, Chip A17 Pro mạnh mẽ nhất, Nút Action Button mới. Màn hình Super Retina XDR 6.7 inch.",
                        Price = 46990000,
                        StockQuantity = 50,
                        ImageUrl = "https://cdn.tgdd.vn/Products/Images/42/305658/iphone-15-pro-max-blue-thumbnew-600x600.jpg",
                        IsFeatured = true,
                        CategoryId = iosCategory.Id
                    },
                    new Product
                    {
                        Name = "iPhone 15 Pro 512GB",
                        Description = "Thiết kế nhỏ gọn, hiệu năng đỉnh cao với A17 Pro. Camera chuyên nghiệp.",
                        Price = 37990000,
                        StockQuantity = 30,
                        ImageUrl = "https://cdn.tgdd.vn/Products/Images/42/303891/iphone-15-pro-blue-thumbnew-600x600.jpg",
                        IsFeatured = true,
                        CategoryId = iosCategory.Id
                    },
                    new Product
                    {
                        Name = "iPhone 15 Plus 256GB",
                        Description = "Màn hình lớn, Dynamic Island, Camera 48MP sắc nét.",
                        Price = 28990000,
                        StockQuantity = 40,
                        ImageUrl = "https://cdn.tgdd.vn/Products/Images/42/303833/iphone-15-plus-green-thumbnew-600x600.jpg",
                        IsFeatured = false,
                        CategoryId = iosCategory.Id
                    },
                    new Product
                    {
                        Name = "iPhone 15 128GB",
                        Description = "Thiết kế mới, cổng USB-C tiện lợi, màu sắc trẻ trung.",
                        Price = 22990000,
                        StockQuantity = 100,
                        ImageUrl = "https://cdn.tgdd.vn/Products/Images/42/281570/iphone-15-pink-thumbnew-600x600.jpg",
                        IsFeatured = false,
                        CategoryId = iosCategory.Id
                    },

                    // Samsung S24 Series
                    new Product
                    {
                        Name = "Samsung Galaxy S24 Ultra 1TB",
                        Description = "Quyền năng Galaxy AI, Khung viền Titan, S Pen tích hợp.",
                        Price = 44490000,
                        StockQuantity = 20,
                        ImageUrl = "https://cdn.tgdd.vn/Products/Images/42/307174/samsung-galaxy-s24-ultra-grey-thumbnew-600x600.jpg",
                        IsFeatured = true,
                        CategoryId = androidCategory.Id
                    },
                     new Product
                    {
                        Name = "Samsung Galaxy S24 Plus 512GB",
                        Description = "Màn hình QHD+ sắc nét, Pin lớn, Galaxy AI hỗ trợ.",
                        Price = 29990000,
                        StockQuantity = 25,
                        ImageUrl = "https://cdn.tgdd.vn/Products/Images/42/307172/samsung-galaxy-s24-plus-purple-thumbnew-600x600.jpg",
                        IsFeatured = true,
                        CategoryId = androidCategory.Id
                    },
                     new Product
                    {
                        Name = "Samsung Galaxy S24 256GB",
                        Description = "Nhỏ gọn, mạnh mẽ, thiết kế phẳng hiện đại.",
                        Price = 22990000,
                        StockQuantity = 50,
                        ImageUrl = "https://cdn.tgdd.vn/Products/Images/42/319665/samsung-galaxy-s24-yellow-thumbnew-600x600.jpg",
                        IsFeatured = false,
                        CategoryId = androidCategory.Id
                    },

                    // Xiaomi & Pixel
                    new Product
                    {
                        Name = "Xiaomi 14 Ultra 5G",
                        Description = "Đỉnh cao nhiếp ảnh Leica, cảm biến 1 inch thế hệ mới.",
                        Price = 29990000,
                        StockQuantity = 15,
                        ImageUrl = "https://cdn.tgdd.vn/Products/Images/42/314115/xiaomi-14-ultra-black-thumb-600x600.jpg",
                        IsFeatured = true,
                        CategoryId = androidCategory.Id
                    },
                    new Product
                    {
                        Name = "Xiaomi 14 5G",
                        Description = "Ống kính Leica Summilux, Snapdragon 8 Gen 3.",
                        Price = 20990000,
                        StockQuantity = 30,
                        ImageUrl = "https://cdn.tgdd.vn/Products/Images/42/312017/xiaomi-14-black-thumb-600x600.jpg",
                        IsFeatured = false,
                        CategoryId = androidCategory.Id
                    },
                    new Product
                    {
                        Name = "Google Pixel 8 Pro",
                        Description = "Google AI, Camera xuất sắc nhất, Android gốc mượt mà.",
                        Price = 24990000,
                        StockQuantity = 10,
                        ImageUrl = "https://lh3.googleusercontent.com/fA2LgM1kE8y5O7uD8KxJ3z8Xz9CqB9X1l5F4v3Z7n0m6b8V9c2x4z6l8k0j2h4g6f8d=w600-RW", // Example link
                        IsFeatured = true,
                        CategoryId = androidCategory.Id
                    },
                     new Product
                    {
                        Name = "Google Pixel 8",
                        Description = "Thông minh, hữu ích, kích thước vừa vặn.",
                        Price = 18990000,
                        StockQuantity = 20,
                        ImageUrl = "https://lh3.googleusercontent.com/fA2LgM1kE8y5O7uD8KxJ3z8Xz9CqB9X1l5F4v3Z7n0m6b8V9c2x4z6l8k0j2h4g6f8d=w600-RW", 
                        IsFeatured = false,
                        CategoryId = androidCategory.Id
                    },

                    // Accessories
                    new Product
                    {
                        Name = "AirPods Pro (2nd Gen)",
                        Description = "Chống ồn chủ động gấp 2 lần, USB-C.",
                        Price = 5990000,
                        StockQuantity = 100,
                        ImageUrl = "https://cdn.tgdd.vn/Products/Images/54/289708/airpods-pro-2-usb-c-thumb-600x600.jpg",
                        IsFeatured = true,
                        CategoryId = accessoriesCategory.Id
                    },
                    new Product
                    {
                        Name = "Samsung Galaxy Watch6",
                        Description = "Theo dõi sức khỏe toàn diện, thiết kế thời thượng.",
                        Price = 6490000,
                        StockQuantity = 50,
                        ImageUrl = "https://cdn.tgdd.vn/Products/Images/70/308355/samsung-galaxy-watch6-40mm-gold-thumb-600x600.jpg",
                        IsFeatured = false,
                        CategoryId = accessoriesCategory.Id
                    },
                    new Product
                    {
                        Name = "Sạc dự phòng Anker 10000mAh",
                        Description = "Sạc nhanh PD 20W, nhỏ gọn.",
                        Price = 850000,
                        StockQuantity = 200,
                        ImageUrl = "https://cdn.tgdd.vn/Products/Images/57/242273/pin-sac-du-phong-polymer-10000mah-type-c-pd-20w-anker-powercore-slim-a1244-thumb-600x600.jpeg",
                        IsFeatured = false,
                        CategoryId = accessoriesCategory.Id
                    },
                     new Product
                    {
                        Name = "Cáp sạc Belkin USB-C to Lightning",
                        Description = "MFI chứng nhận, siêu bền.",
                        Price = 350000,
                        StockQuantity = 150,
                        ImageUrl = "https://cdn.tgdd.vn/Products/Images/58/235887/cap-type-c-lightning-1m-belkin-caa003-trang-thumb-600x600.jpg",
                        IsFeatured = false,
                        CategoryId = accessoriesCategory.Id
                    }
                };
                context.Products.AddRange(products);
                await context.SaveChangesAsync();
            }
        }
    }
}
