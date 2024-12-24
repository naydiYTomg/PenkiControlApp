using Dapper;
using PenkiControlApp.Core;
using PenkiControlApp.Core.DTOs;
using PenkiControlApp.Core.Queries;

namespace PenkiControlApp.DAL;

public class ProductRepository
{
    public List<ProductDTO> GetAllProducts()
    {
        string connectionInfo = Constants.CONNECTION_INFO;
        using (var connection = new Npgsql.NpgsqlConnection(connectionInfo))
        {
            string query = ProductQueries.GET_PRODUCTS_QUERY;
            List<ProductDTO> result = connection.Query<ProductDTO>(query).ToList();
            return result;
        }
    }
}