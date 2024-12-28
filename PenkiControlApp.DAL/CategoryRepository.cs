using Dapper;
using Npgsql;
using PenkiControlApp.Core;
using PenkiControlApp.Core.DTOs;
using PenkiControlApp.Core.Queries;
using PenkiControlApp.DAL.Internal;
using PenkiControlApp.Logging;
namespace PenkiControlApp.DAL;

public class CategoryRepository
{
    private readonly PCALogger _logger = PCALogger.GetInstance();
    public CategoryDTO GetCategoryById(int id)
    {
        string connectionInfo = Constants.CONNECTION_INFO;
        using (var connection = new NpgsqlConnection(connectionInfo))
        {
            string query = CategoryQueries.GET_CATEGORY_BY_ID_QUERY;
            var properties = new
            {
                Id = id
            };
            CategoryDTO result = connection.QueryFirst<CategoryDTO>(query, properties);
            _logger.LogMessage($"Got this {result.ToString()}");
            return result;
        }
    }

    public int GetCategoryIdByName(string name)
    {
        var connection = new ConnectionBuilder().WithQuery(CategoryQueries.GetCategoryIdByName)
            .WithProperties(new { Name = name }).Pack();
        return connection.ExecuteFirst<int>();
    }

    public List<CategoryDTO> GetCategories()
    {
        var connection = new ConnectionBuilder().WithQuery(CategoryQueries.GET_CATEGORIES_QUERY).Pack();
        return connection.Execute<CategoryDTO>().AsList();
    }
}