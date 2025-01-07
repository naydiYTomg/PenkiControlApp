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
        public int InsertOrder(OrderDTO DTO)
        {
            var connection = new ConnectionBuilder().WithQuery(OrderQueries.INSERT_ORDER_QUERY).WithProperties(new {Sum = DTO.Sum, Date = DTO.Date, UserId = DTO.UserId, ClientId = DTO.ClientId}).Pack();
            return connection.ExecuteFirst<int>();
        }
    }