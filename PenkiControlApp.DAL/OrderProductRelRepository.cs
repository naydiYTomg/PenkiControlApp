using Dapper;
using PenkiControlApp.Core.DTOs;
using PenkiControlApp.Core.Queries;
using PenkiControlApp.DAL.Internal;

namespace PenkiControlApp.DAL;

public class OrderProductRelRepository
{
    public List<OrderProductRelDTO> GetAllRelations()
    {
        var connection = new ConnectionBuilder().WithQuery(OrderProductRelQueries.GetAllRelationsQuery).Pack();
        return connection.Execute<OrderProductRelDTO>().AsList();
    }

    public void AddNewProductToOrder(int orderId, List<ProductDTO> products, int[] counts)
    {
        int i = 0;
        products.ForEach(x =>
        {
            var connection = new ConnectionBuilder().WithQuery(OrderProductRelQueries.AddNewProductToOrder)
                .WithProperties(new { OrderId = orderId, ProductId = x.Id, Count = counts[i] }).Pack();
            connection.Execute<int>();
            i++;
        });
    }
}