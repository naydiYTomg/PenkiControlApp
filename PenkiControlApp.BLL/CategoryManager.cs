using PenkiControlApp.Core.OutputModels;
using PenkiControlApp.DAL;

namespace PenkiControlApp.BLL;

public class CategoryManager
{
    private readonly CategoryRepository _category = new();

    public List<CategoryOutputModel> GetCategories()
    {
        var got = _category.GetCategories();
        List<CategoryOutputModel> outputModels = [];
        got.ForEach(x => { outputModels.Add(new CategoryOutputModel{ Id = x.Id, Name = x.Name! }); });
        return outputModels;
    }

    public int GetCategoryIdByName(string name)
    {
        var got = _category.GetCategoryIdByName(name);
        return got;
    }

}