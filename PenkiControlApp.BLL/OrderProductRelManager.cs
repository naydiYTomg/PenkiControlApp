using PenkiControlApp.Core.DTOs;
using PenkiControlApp.Core.InputModels;
using PenkiControlApp.DAL;

namespace PenkiControlApp.BLL;

public class OrderProductRelManager
{
    private readonly OrderProductRelRepository _repository = new();

    public void AddNewProductToOrder(List<ProductToOrderInputModel> inputModels, int orderId, int[] counts)
    {
        List<ProductDTO> dtos = [];
        inputModels.ForEach(x =>
        {
            dtos.Add(new ProductDTO { Id = x.Id, CategoryId = null, Name = null});
        });
        dtos.ForEach(x =>
        {
            Console.WriteLine(x.ToString());
        });
        _repository.AddNewProductToOrder(orderId, dtos, counts);
    }
}