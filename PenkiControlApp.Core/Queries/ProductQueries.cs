namespace PenkiControlApp.Core.Queries;

public static class ProductQueries
{
    public const string GET_PRODUCTS_QUERY = "select * from \"Product\"";

    public const string AddProductQuery = """
                                            insert into "Product" ("Name", "CategoryId", "Cost") values (@Name, @CategoryId, @Cost) returning "Id"
                                          """;
}