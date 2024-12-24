namespace PenkiControlApp.Core.Queries;

public static class ProductTagRelQueries
{
    public const string GetAllRelationsQuery = """
                                           select * from "ProductTagRelationship"
                                           """;

    public const string GetTagsOfProductQuery = """
                                           select "TagId" from "ProductTagRelationship" where "ProductId"=@Id
                                           """;

    public const string AddNewTagForProductQuery = """
                                                   insert into "ProductTagRelationship" ("ProductId", "TagId") values (@ProductId, @TagId) returning "TagId"
                                                   """;
}