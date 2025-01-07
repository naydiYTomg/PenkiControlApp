using Dapper;
using PenkiControlApp.Core.DTOs;
using PenkiControlApp.Core.Queries;
using PenkiControlApp.DAL.Internal;

namespace PenkiControlApp.DAL;

public class ProductTagRelRepository
{
    public List<ProductTagRelDTO> GetRelations()
    {
        var connection = new ConnectionBuilder().WithQuery(ProductTagRelQueries.GetAllRelationsQuery).Pack();
        return connection.Execute<ProductTagRelDTO>().AsList();
    }

    public void AddTagsToProduct(int productId, List<TagDTO> tags)
    {
        tags.ForEach(x =>
        {
            var connection = new ConnectionBuilder().WithQuery(ProductTagRelQueries.AddNewTagForProductQuery)
                .WithProperties(new { ProductId = productId, TagId = x.Id }).Pack();
            connection.Execute<int>();
        });
    }
}