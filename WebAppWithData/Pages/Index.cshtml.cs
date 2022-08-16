using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppWithData.Models;
using WebAppWithData.Services;

namespace WebAppWithData.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IProductService _productService;

        public IndexModel(IProductService productService, ILogger<IndexModel> logger)
        {
            _logger = logger;
            _productService = productService;
        }
        public List<Product> Products = null;

        public void OnGet()
        {
            Products = _productService.GetProducts();
        }
    }
}