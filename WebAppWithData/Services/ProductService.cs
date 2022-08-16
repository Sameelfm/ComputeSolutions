using System.Data.SqlClient;
using WebAppWithData.Models;

namespace WebAppWithData.Services
{
    public class ProductService : IProductService
    {
        private readonly IConfiguration _configuration;
        public ProductService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        private SqlConnection GetConnectionString()
        {
            return new SqlConnection(_configuration["SQLConnection"]);
        }

        public List<Product> GetProducts()
        {
            SqlConnection connection = GetConnectionString();
            List<Product> products = new List<Product>();
            string query = "SELECT * FROM Products";
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    products.Add(
                        new Product()
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Quantity = reader.GetInt32(2)
                        }
                    );
                }
                connection.Close();
                return products;
            }
        }
    }
}
