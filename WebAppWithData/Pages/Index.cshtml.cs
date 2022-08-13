using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppWithData.Models;
using WebAppWithData.Services;

namespace WebAppWithData.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        //public IndexModel(ILogger<IndexModel> logger)
        //{
        //    _logger = logger;
        //}
        public List<Product> Products = null;

        public void OnGet()
        {
            ProductService prodService = new ProductService();
            Products = prodService.GetProducts();
        }
    }
}