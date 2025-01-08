namespace PenkiControlApp.Core.Queries;

public static class ProductQueries
{
    public const string GET_PRODUCTS_QUERY = "select * from \"Product\"";

    public const string AddProductQuery = """
                                            insert into "Product" ("Name", "CategoryId", "Cost") values (@Name, @CategoryId, @Cost) returning "Id"
                                          """;

    public const string GetRandomProductByTagQuery = """
                                                     select "Name", "Id", "CategoryId", "Cost"
                                                     from "Product"
                                                     where "Id" = (select "ProductId" from "ProductTagRelationship" where "TagId"=@Id order by random() limit 1)
                                                     """;
}