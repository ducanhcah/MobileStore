using Microsoft.AspNetCore.Mvc;
using MobileStore.Repositories;

namespace MobileStore.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        // GET: /Product/Index?category=1
        public async Task<IActionResult> Index(int? category)
        {
            if (category.HasValue)
            {
                var products = await _productRepository.GetByCategoryIdAsync(category.Value);
                var cat = await _categoryRepository.GetByIdAsync(category.Value);
                ViewBag.CurrentCategory = cat?.Name ?? "Sản phẩm";
                return View(products);
            }
            
            var allProducts = await _productRepository.GetAllAsync();
            ViewBag.CurrentCategory = "Tất cả sản phẩm";
            return View(allProducts);
        }

        // GET: /Product/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // GET: /Product/Search?query=iphone
        public async Task<IActionResult> Search(string query)
        {
            var products = await _productRepository.SearchAsync(query);
            ViewBag.SearchQuery = query;
            return View("Index", products);
        }
    }
}
