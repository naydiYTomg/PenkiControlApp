using PenkiControlApp.Core.DTOs;
using PenkiControlApp.Core.OutputModels;
using PenkiControlApp.DAL;

namespace PenkiControlApp.BLL;

public class ProductManager
{
    private readonly ProductRepository _repository = new();
    private readonly CategoryRepository _category = new();

    public List<ProductForDisplayingOutputModel> GetAllProducts()
    {
        List<ProductForDisplayingOutputModel> outputModels = [];
        var got = _repository.GetAllProducts();
        got.ForEach(x =>
        {
            CategoryDTO category = _category.GetCategoryById(x.Category_Id);
            outputModels.Add(new ProductForDisplayingOutputModel
            {
                Id = x.Id,
                Name = x.Name!,
                CategoryName = category.Name!
            });
            
        });
        return outputModels;
    }
}