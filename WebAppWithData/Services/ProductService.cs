using System.Data.SqlClient;
using WebAppWithData.Models;

namespace WebAppWithData.Services
{
    public class ProductService
    {
        private static string db_source = "appdbserverdev.database.windows.net";
        private static string db_user = "sameel";
        private static string db_password = "astech@j1d5qN";
        private static string db_database = "appdb";

        private SqlConnection GetConnectionString()
        {
            string connectionString = string.Empty;
            var _connectionBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = db_source,
                UserID = db_user,
                Password = db_password,
                InitialCatalog = db_database,
            };
            return new SqlConnection(_connectionBuilder.ConnectionString);
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
