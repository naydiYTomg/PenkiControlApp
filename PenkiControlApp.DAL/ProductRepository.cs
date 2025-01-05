using Dapper;
using PenkiControlApp.Core;
using PenkiControlApp.Core.DTOs;
using PenkiControlApp.Core.Queries;
using PenkiControlApp.DAL.Internal;

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

    public int AddNewProduct(string name, int categoryId, int cost)
    {
        var connection = new ConnectionBuilder().WithQuery(ProductQueries.AddProductQuery)
            .WithProperties(new { Name = name, CategoryId = categoryId, Cost = cost }).Pack();
        return connection.ExecuteFirst<int>();
    }
}