using PenkiControlApp.Core.DTOs;
using PenkiControlApp.Core.Queries;
using PenkiControlApp.DAL.Internal;

namespace PenkiControlApp.DAL;

public class TagRepository
{
    public List<TagDTO> GetTagsByCategoryId(int id)
    {
        var connection = new ConnectionBuilder().WithQuery(TagQueries.GetTagsByCategoryIdQuery)
            .WithProperties(new { CategoryId = id }).Pack();
        return connection.Execute<TagDTO>().ToList();
    }
}