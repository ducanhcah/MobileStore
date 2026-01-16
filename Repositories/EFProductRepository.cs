using Microsoft.EntityFrameworkCore;
using MobileStore.Data;
using MobileStore.Models;

namespace MobileStore.Repositories
{
    public class EFProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public EFProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.Include(p => p.Category).ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> GetFeaturedProductsAsync()
        {
            return await _context.Products.Where(p => p.IsFeatured).Include(p => p.Category).ToListAsync();
        }
        
        public async Task<IEnumerable<Product>> GetByCategoryIdAsync(int categoryId)
        {
             return await _context.Products.Where(p => p.CategoryId == categoryId).Include(p => p.Category).ToListAsync();
        }

        public async Task<IEnumerable<Product>> SearchAsync(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return await GetFeaturedProductsAsync();
            }
            return await _context.Products
                .Where(p => p.Name.Contains(query) || (p.Description != null && p.Description.Contains(query)))
                .Include(p => p.Category)
                .ToListAsync();
        }
    }
}
