using PenkiControlApp.Core.OutputModels;
using PenkiControlApp.DAL;

namespace PenkiControlApp.BLL;

public class TagManager
{
    private readonly TagRepository _repository = new();
    private readonly CategoryRepository _category = new();

    public List<TagOutputModel> GetTagsByCategoryName(string name)
    {
        int id = _category.GetCategoryIdByName(name);
        return GetTagsByCategoryId(id);
    }

    public List<TagOutputModel> GetTagsByCategoryId(int id)
    {
        var got = _repository.GetTagsByCategoryId(id);
        List<TagOutputModel> outputModels = [];
        got.ForEach(x =>
        {
            outputModels.Add(new TagOutputModel{ Id = x.Id, Name = x.Name!, CategoryId = x.CategoryId });
        });
        return outputModels;
    }

    public List<TagForDisplayingOutputModel> GetAllTags()
    {
        var got = _repository.GetAllTags();
        List<TagForDisplayingOutputModel> outputModels = [];
        got.ForEach(x => outputModels.Add(new TagForDisplayingOutputModel { CategoryId = x.CategoryId, Id = x.Id, Name = x.Name! }));
        return outputModels;

    }
}