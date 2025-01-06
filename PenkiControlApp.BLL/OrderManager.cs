using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.Configuration.Conventions;
using PenkiControlApp.Core.InputModels;
using PenkiControlApp.DAL;
namespace PenkiControlApp.BLL
{
    class OrderManager
    {
        private OrderRepository _repository = new();

        public int InsertOrder(OrderInputModel orderInputModel)
        {
            return _repository.InsertOrder(new Core.DTOs.OrderDTO { ClientId = orderInputModel.ClientId, UserId = orderInputModel.UserId, Date = orderInputModel.Date, Sum = orderInputModel.Sum, Id = orderInputModel.Id });
        }
    }
}
