using WebAppWithData.Models;

namespace WebAppWithData.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();
    }
}