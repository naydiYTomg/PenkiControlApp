namespace PenkiControlApp.Core.Queries
{
    public static class OrderQueries
    {
        public const string GetAllOrdersQuery = """ select * from "Order" """;
        public const string INSERT_ORDER_QUERY = """
            insert into "Order" ("Sum", "Date", "UserId", "ClientId") values (@Sum, @Date, @UserId, @ClientId) returning "Id"
            """;
    }
}
