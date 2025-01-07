using PenkiControlApp.Core.DTOs;
using PenkiControlApp.Core.OutputModels;
using PenkiControlApp.DAL;
using PenkiControlApp.Logging;

namespace PenkiControlApp.BLL;

public class ProductManager
{
    private readonly ProductRepository _repository = new();
    private readonly CategoryRepository _category = new();
    private readonly PCALogger _logger = PCALogger.GetInstance("ProductManagerLogging");

    public List<ProductForDisplayingOutputModel> GetAllProducts()
    {
        List<ProductForDisplayingOutputModel> outputModels = [];
        var got = _repository.GetAllProducts();
        _logger.LogMessage($"Got {got.Count} values, logging in next {got.Count} messages");
        got.ForEach(x =>
        {
            _logger.LogMessage($"{x.ToString()}");
            CategoryDTO category = _category.GetCategoryById((int)x.CategoryId!);
            outputModels.Add(new ProductForDisplayingOutputModel
            {
                Id = x.Id,
                Name = x.Name!,
                CategoryName = category.Name!,
                Cost = x.Cost
            });
            
        });
        return outputModels;
    }

    public int AddNewProduct(string name, int categoryId, int cost)
    {
        var got = _repository.AddNewProduct(name, categoryId, cost);
        return got;
    }

    public List<ProductForDisplayingOutputModel> GetRecommendedProductsByIds(int[] tagIds)
    {
        List<ProductForDisplayingOutputModel> outputModels = [];
        outputModels.AddRange(from tagId in tagIds select _repository.GetRandomProductByTag(tagId) into got let category = _category.GetCategoryById((int)got.CategoryId!) select new ProductForDisplayingOutputModel { Id = got.Id, Name = got.Name!, CategoryName = category.Name!, Cost = got.Cost });
        return outputModels;
    }
}