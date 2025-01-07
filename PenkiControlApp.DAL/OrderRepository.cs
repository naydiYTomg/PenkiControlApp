using Dapper;
using PenkiControlApp.Core.DTOs;
using PenkiControlApp.Core.Queries;
using PenkiControlApp.DAL.Internal;

namespace PenkiControlApp.DAL;

public class OrderRepository
{
    public List<OrderDTO> GetAllOrders()
    {
        var connection = new ConnectionBuilder().WithQuery(OrderQueries.GetAllOrdersQuery).Pack();
        return connection.Execute<OrderDTO>().AsList();
    }
}