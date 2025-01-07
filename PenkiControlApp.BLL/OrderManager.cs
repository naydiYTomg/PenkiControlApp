using PenkiControlApp.Core.OutputModels;
using PenkiControlApp.DAL;

namespace PenkiControlApp.BLL;

public class OrderManager
{
    private OrderRepository _repository = new();

    public List<OrderForDisplayingOutputModel> GetAllOrders()
    {
        var got = _repository.GetAllOrders();
        List<OrderForDisplayingOutputModel> outputModels = [];
        got.ForEach(x => outputModels.Add(new OrderForDisplayingOutputModel{ Id = x.Id, Sum = x.Sum, Date = x.Date, UserId = x.UserId, ClientId = x.ClientId }));
        return outputModels;
    }
        public int InsertOrder(OrderInputModel orderInputModel)
        {
            return _repository.InsertOrder(new Core.DTOs.OrderDTO { ClientId = orderInputModel.ClientId, UserId = orderInputModel.UserId, Date = orderInputModel.Date, Sum = orderInputModel.Sum});
        }
    }
