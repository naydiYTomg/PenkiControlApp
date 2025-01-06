using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PenkiControlApp.Core.DTOs;
using PenkiControlApp.Core.Queries;
using PenkiControlApp.DAL.Internal;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace PenkiControlApp.DAL
{
    public class OrderRepository
    {

        public int InsertOrder(OrderDTO DTO)
        {
            var connection = new ConnectionBuilder().WithQuery(OrderQueries.INSERT_ORDER_QUERY).WithProperties(new {Sum = DTO.Sum, Date = DTO.Date, UserId = DTO.UserId, ClientId = DTO.ClientId}).Pack();
            return connection.ExecuteFirst<int>();
        }
    }
}
