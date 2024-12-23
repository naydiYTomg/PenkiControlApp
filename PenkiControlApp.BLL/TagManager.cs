using PenkiControlApp.Core.OutputModels;
using PenkiControlApp.DAL;

namespace PenkiControlApp.BLL;

public class TagManager
{
    private readonly TagRepository _tag = new();
    private readonly CategoryRepository _category = new();

    public List<TagOutputModel> GetTagsByCategoryName(string name)
    {
        int id = _category.GetCategoryIdByName(name);
        var got = _tag.GetTagsByCategoryId(id);
        List<TagOutputModel> outputModels = [];
        got.ForEach(x =>
        {
            outputModels.Add(new TagOutputModel{ Id = x.Id, Name = x.Name!, CategoryId = x.CategoryId });
        });
        return outputModels;
    }
}