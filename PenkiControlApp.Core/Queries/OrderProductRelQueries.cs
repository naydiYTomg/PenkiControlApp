namespace PenkiControlApp.Core.Queries;

public class OrderProductRelQueries
{
    public const string GetAllRelationsQuery = """
                                               select * from "OrderProductRelationship"
                                               """;

    public const string AddNewProductToOrder = """
                                               insert into "OrderProductRelationship" ("OrderId", "ProductId", "Count") values (@OrderId, @ProductId, @Count) returning "ProductId"
                                               """;
}