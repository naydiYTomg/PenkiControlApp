using Dapper;
using PenkiControlApp.Core.DTOs;
using PenkiControlApp.Core.Queries;
using PenkiControlApp.DAL.Internal;

namespace PenkiControlApp.DAL;

public class OrderProductRelRepository
{
    public List<OrderProductRelDTO> GetAllOrderProductRels()
    {
        var connection = new ConnectionBuilder().WithQuery(OrderProductRelQueries.GetAllOrderProductRelsQuery).Pack();
        return connection.Execute<OrderProductRelDTO>().AsList();
    }
}