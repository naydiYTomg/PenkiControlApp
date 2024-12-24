using PenkiControlApp.Core.DTOs;
using PenkiControlApp.Core.InputModels;
using PenkiControlApp.DAL;

namespace PenkiControlApp.BLL;

public class ProductTagRelManager
{
    private readonly ProductTagRelRepository _repository = new();

    public void AddTagsToProduct(int productId, List<int> tagsIds)
    {
        List<TagDTO> props = [];
        tagsIds.ForEach(x =>
        {
            props.Add(new TagDTO() { Id = x});
        });
        _repository.AddTagsToProduct(productId, props);
    }
}