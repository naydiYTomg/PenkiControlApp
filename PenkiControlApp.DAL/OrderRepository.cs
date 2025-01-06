using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PenkiControlApp.Core.DTOs;
using PenkiControlApp.Core.Queries;
using PenkiControlApp.DAL.Internal;
namespace PenkiControlApp.DAL
{
    public class OrderRepository
    {

        public int InsertOrder(OrderDTO DTO)
        {
            var connection = new ConnectionBuilder().WithQuery(OrderQueries.INSERT_ORDER_QUERY).WithProperties(new {Id = DTO.Id, Sum = DTO.Sum, Date = DTO.Date, UserId  = DTO.UserId, ClientId  = DTO.ClientId}).Pack();
            return connection.ExecuteFirst<int>();
        }
    }
}
