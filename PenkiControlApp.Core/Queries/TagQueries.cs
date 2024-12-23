namespace PenkiControlApp.Core.Queries;

public static class TagQueries
{
    public const string GetAllTagsQuery = """
                                          select * from "Tag"
                                          """;

    public const string GetTagsByCategoryIdQuery = """
                                                   select * from "Tag" where "CategoryId"=@CategoryId
                                                   """;
}